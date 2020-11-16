using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasheGamePA
{
    public partial class MainWindow : Window
    {
        public static TextBox BossHealth { get; set; }
        private TextBox DealDamageP1 { get; set; }
        private TextBox DealDamageP2 { get; set; }
        public enum GM { TwoPlayers, AiEasy, AiMedium, AiHard }
        public enum GS { NotStarted, Started, Ended }
        public GM GameMode { get; set; }
        public GS GameState { get; set; }
        private BasheCore BC { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DealDamageP1 = DealDamageP1TextBox;
            DealDamageP2 = DealDamageP2TextBox;
            BossHealth = BossHealthPointsTextBox;
            GameMode = GM.AiEasy;
            BC = new BasheCore();
        }

        private void ChooseNumber_OnKeyDown(object sender, KeyEventArgs e)
        {
            var number = ChooseNumber(e);
            if (BC.Turn && number != "" && DealDamageP1.IsEnabled == true &&
                DealDamageP1.IsFocused == false && DealDamageP2.IsFocused == false &&
                BossHealth.IsFocused == false)
                DealDamageP1.Text = number;
            else if (number != "" && DealDamageP2.IsEnabled == true &&
                     DealDamageP1.IsFocused == false && DealDamageP2.IsFocused == false &&
                     BossHealth.IsFocused == false)
                DealDamageP2.Text = number;
        }

        private void PotionCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PotionIcon.Visibility = Visibility.Visible;
            PotionIconDisabled.Visibility = Visibility.Collapsed;
        }

        private void PotionCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PotionIcon.Visibility = Visibility.Collapsed;
            PotionIconDisabled.Visibility = Visibility.Visible;
        }

        private void SwordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SwordIcon.Visibility = Visibility.Visible;
            SwordIconDisabled.Visibility = Visibility.Collapsed;
        }

        private void SwordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SwordIcon.Visibility = Visibility.Collapsed;
            SwordIconDisabled.Visibility = Visibility.Visible;
        }

        private void GameModeComboBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            int gameModeIndex = 0;
            for (int i = 0; i < comboBox.Items.Count; i++)
                if ((ComboBoxItem)comboBox.ItemContainerGenerator.ContainerFromIndex(i) ==
                    (ComboBoxItem)comboBox.SelectedItem)
                    gameModeIndex = i;

            switch (gameModeIndex)
            {
                case 0:
                    GameMode = GM.TwoPlayers;
                    break;
                case 1:
                    GameMode = GM.AiEasy;
                    break;
                case 2:
                    GameMode = GM.AiMedium;
                    break;
                case 3:
                    GameMode = GM.AiHard;
                    break;
            }
        }

        private void StartButton_OnClick(object sender, RoutedEventArgs e)
        {
            var rnd = new Random();
            switch (GameState)
            {
                case GS.NotStarted:
                    if (!(DealDamageP1.Text.Length == DealDamageP1.Text.Count(char.IsDigit) &&
                        DealDamageP2.Text.Length == DealDamageP2.Text.Count(char.IsDigit)))
                        break;

                    BC.MaxDamage = Convert.ToInt32(DealDamageP1.Text);

                    StartGameGui();

                    if (GameMode == GM.TwoPlayers)
                    {
                        BC.Turn = rnd.Next(0, 2) == 1 ? true : false;
                        if (!BC.Turn)
                            DealDamageP2.IsEnabled = false;
                        else
                            DealDamageP1.IsEnabled = false;
                    }
                    else
                        DealDamageP2.IsEnabled = false;

                    GameState = GS.Started;
                    break;
                case GS.Started:
                    var dealDamage1 = Convert.ToInt32(DealDamageP1.Text);
                    var dealDamage2 = Convert.ToInt32(DealDamageP2.Text);
                    if (DealDamageP1.Text.Length == DealDamageP1.Text.Count(char.IsDigit) &&
                        DealDamageP2.Text.Length == DealDamageP2.Text.Count(char.IsDigit) &&
                        BC.MaxDamage >= dealDamage1 && dealDamage1 >= 1 &&
                        BC.MaxDamage >= dealDamage2 && dealDamage2 >= 1)
                    {
                        if (GameMode == GM.TwoPlayers)
                        {
                            DealDamageP2.IsEnabled = !DealDamageP2.IsEnabled;
                            DealDamageP1.IsEnabled = !DealDamageP1.IsEnabled;

                            BossHealthPointsTextBox.Text = BC.Turn ?
                                Convert.ToString(Convert.ToInt32(BossHealthPointsTextBox.Text) - dealDamage1) :
                                Convert.ToString(Convert.ToInt32(BossHealthPointsTextBox.Text) - dealDamage2);

                            BC.Turn = !BC.Turn;
                        }
                        else if (!BC.Turn)
                        {
                            BC.FirstTurn = BC.Turn;
                            switch (GameMode)
                            {
                                case GM.AiEasy:
                                    if (BC.MaxDamage >= Convert.ToInt32(BossHealth.Text))
                                    {
                                        BossHealth.Text = "0";
                                        DealDamageP2.Text = BC.MaxDamage.ToString();
                                    }
                                    else
                                    {
                                        int damage = rnd.Next(1, BC.MaxDamage + 1);
                                        BossHealth.Text = (Convert.ToInt32(BossHealth.Text) - damage).ToString();
                                        DealDamageP2.Text = damage.ToString();
                                    }
                                    break;
                                case GM.AiMedium:
                                    if (BC.MaxDamage >= Convert.ToInt32(BossHealth.Text))
                                    {
                                        BossHealth.Text = "0";
                                        DealDamageP2.Text = BC.MaxDamage.ToString();
                                    }

                                    var damaged = false;
                                    for (int i = 1; i <= BC.MaxDamage; i++)
                                    {
                                        if (i != Convert.ToInt32(BossHealth.Text) - BC.MaxDamage - 1) continue;
                                        BossHealth.Text = (Convert.ToInt32(BossHealth.Text) - i).ToString();
                                        DealDamageP2.Text = i.ToString();
                                        damaged = true;
                                        break;
                                    }

                                    if (!damaged)
                                    {
                                        BossHealth.Text = (Convert.ToInt32(BossHealth.Text) - BC.MaxDamage).ToString();
                                        DealDamageP2.Text = BC.MaxDamage.ToString();
                                    }
                                    break;
                                case GM.AiHard:
                                {
                                    var bestValue = -999;
                                    var move = 0;
                                    for (int i = 1; i <= BC.MaxDamage; i++)
                                    {
                                        var value = BC.AlphaBetaPruning(i, 
                                            Convert.ToInt32(BossHealth.Text), -99, 99, 
                                            Convert.ToInt32(BossHealth.Text), !BC.FirstTurn);
                                        if (value < bestValue) continue;
                                        bestValue = value;
                                        move = i;
                                    }

                                    BossHealth.Text = Convert.ToString(Convert.ToInt32(BossHealth.Text) - move);
                                    DealDamageP2.Text = move.ToString();
                                    break;
                                    }
                            }
                            DealDamageP1.IsEnabled = true;

                            BC.Turn = !BC.Turn;
                        }
                        else if (BC.Turn)
                        {
                            BossHealth.Text =
                                Convert.ToString(Convert.ToInt32(BossHealth.Text) -
                                                 Convert.ToInt32(DealDamageP1.Text));

                            DealDamageP1.IsEnabled = false;

                            BC.Turn = !BC.Turn;
                        }

                        if (Convert.ToInt32(BossHealthPointsTextBox.Text) <= 0)
                        {
                            EndGameGui();
                            GameState = GS.Ended;
                        }
                    }
                    break;
                case GS.Ended:
                    RestartGameGui();
                    GameState = GS.NotStarted;
                    break;
            }
        }

        private void StartGameGui()
        {
            P1TextBlock.Text = "Deal Damage";
            P2TextBlock.Text = "Deal Damage";
            StartButton.Content = "Attack";

            BossHealthPointsTextBox.IsEnabled = false;
            BossHealthPointsTextBox.Foreground =
                new SolidColorBrush((Color)ColorConverter.ConvertFromString("#08090A"));

            P1MaxDamage.Text = BC.MaxDamage.ToString();
            P2MaxDamage.Text = BC.MaxDamage.ToString();

            GameModeComboBox.IsEnabled = false;
            PotionCheck.IsEnabled = false;
            SwordCheck.IsEnabled = false;
        }

        private void EndGameGui()
        {
            StartButton.Content = "Restart";

            DealDamageP1.IsEnabled = false;
            DealDamageP2.IsEnabled = false;

            TrophyIcon.Visibility = Visibility.Visible;
            FlagIcon.Visibility = Visibility.Visible;
            if (BC.Turn)
            {
                TrophyIcon.Margin = new Thickness(0, 0, 110, 300);
                FlagIcon.Margin = new Thickness(0, 250, 110, 0);
            }
            else
            {
                TrophyIcon.Margin = new Thickness(0, 250, 110, 0);
                FlagIcon.Margin = new Thickness(0, 0, 110, 300);
            }

            BossHealthPointsTextBox.Text = "0";
            BossHealthPointsTextBox.Foreground = DealDamageP1.Foreground;
        }

        private void RestartGameGui()
        {
            StartButton.Content = "Start";

            BossHealthPointsTextBox.Text = "15";
            DealDamageP1.Text = "3";
            DealDamageP2.Text = "3";

            BossHealthPointsTextBox.IsEnabled = true;
            DealDamageP1.IsEnabled = true;
            DealDamageP2.IsEnabled = true;

            P1TextBlock.Text = "Max Deal Damage";
            P2TextBlock.Text = "Max Deal Damage";

            TrophyIcon.Visibility = Visibility.Collapsed;
            FlagIcon.Visibility = Visibility.Collapsed;

            P1MaxDamage.Text = "";
            P2MaxDamage.Text = "";

            GameModeComboBox.IsEnabled = true;
            PotionCheck.IsEnabled = true;
            SwordCheck.IsEnabled = true;
        }

        private string ChooseNumber(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1: case Key.NumPad1: return "1";
                case Key.D2: case Key.NumPad2: return "2";
                case Key.D3: case Key.NumPad3: return "3";
                case Key.D4: case Key.NumPad4: return "4";
                case Key.D5: case Key.NumPad5: return "5";
                case Key.D6: case Key.NumPad6: return "6";
                case Key.D7: case Key.NumPad7: return "7";
                case Key.D8: case Key.NumPad8: return "8";
                case Key.D9: case Key.NumPad9: return "9";
                default: return "";
            }
        }

        private void DealDamageP2TextBox_TextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            if (GameState != GS.NotStarted) return;
            try { DealDamageP1TextBox.Text = DealDamageP2TextBox.Text; }
            catch { }
        }

        private void DealDamageP1TextBox_TextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            if (GameState != GS.NotStarted) return;
            try { DealDamageP2TextBox.Text = DealDamageP1TextBox.Text; }
            catch { }
        }
    }
}
