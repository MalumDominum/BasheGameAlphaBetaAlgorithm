   M S B A M L   `   `   `  ����F  BBasheGamePA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BasheGamePABasheGamePA  5   	       BasheGamePA.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BasheGamePA     5   	   -   5          � Title$  Kill the Boss��5   	   $	��450��6   $	��800��6,    � 
ResizeMode$ NoResize=�5	   	    � Icon$ Icons/skull.ico��5
   	    � ShowInTaskbar .  � WindowStartupLocation$ CenterScreen=�5   	   ���#333.��5      � .+�5   
   �� $��24(�6   ���	#FF32EBFB$��200 0 0 105q�5      $��Center=�5      $��Center=�5      Boss Health Points6C   �� 5   
   -   5         ��Name$ BossHealthPointsTextBox��5       �� 	MaxLength$ 3��5      $	��190��5      $��65��5      $��24(�5      $��Stretch=�5      $��Center=�5      $��	200 0 0 0q�5      .��6%   156)   �� 5   
   -   5        $ DealDamageP1TextBox��5      $ 2��5      $	��120��5       $��45��5!      $��24(�5"      $��Bottom=�5#      $��Center=�5$      $��
200 0 0 50q�5%      .��6&   36)   �� 5&   
   -   5        $ DealDamageP2TextBox��5&      $ 2��5(      $	��120��5)      $��45��5*      $��24(�5+      $	��Top=�5,      $��Center=�5-      $��
200 50 0 0q�5.      .��6&   36)   �� 5/   
   -   5         ��Name$ P1TextBlock��5/      $��24(�50      ���	#FF32EBFB$��200 0 0 100q�52      $��Center=�53      $��Bottom=�54      Max Deal Damage6@   �� 55   
   -   5        $ P2TextBlock��55      $��24(�56      ���	#FF32EBFB$��
200 15 0 0q�58      $��Center=�59      $	��Top=�5:      Max Deal Damage6=   �� 5;   
   -   5        $ P1MaxDamage��5;      $��30(�5<      ���	#FF32EBFB$��	25 0 0 53q�5>      $��Center=�5?      $��Bottom=�5@      61   �� 5A   
   -   5        $ P2MaxDamage��5A      $��30(�5B      ���	#FF32EBFB$��	25 53 0 0q�5D      $��Center=�5E      $	��Top=�5F      6.   �� 5G   
   -	   5         ��Name$ GameModeComboBox��5G      $��60��5I      $	��240��6   $
��Left=�5J      $	��Top=�5K      $��	30 30 0 0q�5L      $��24(�5M      	 �� MaxDropDownHeight$		 600��5N      .@�5O      �� .��5P      �� 
 �� Orientation$
 
Horizontal=�6   .+�5Q      �� $��Center=�6    Two Players6H   �� 5R         	GamerIcon#��[  6!   $��Right=�5S   !   $��Center=�5T   !   $��30 0 0 0q�5U   !   5V      5W      �� 5X       �� 
IsSelected . .��5Y      �� $
 
Horizontal=�6   .+�5Z      �� $��Center=�6    	AI (Easy)6F   �� 5[        ComputerEasyIcon#��[ 6%   $��Right=�5\   %   $��Center=�5]   %   $��60 0 0 0q�5^   %   5_      5`      �� 5a      .��5b      �� $
 
Horizontal=�6   .+�5c      �� $��Center=�6    AI (Medium)6H   �� 5d        ComputerMediumIcon#��[ 6%   $��Right=�5e   %   $��Center=�5f   %   $��20 0 0 0q�5g   %   5h      5i      �� 5j      .��5k      �� $
 
Horizontal=�6   .+�5l      �� $��Center=�6    	AI (Hard)6F   �� 5m        ComputerHardIcon#��[ 6%   $��Right=�5n   %   $��Center=�5o   %   $��55 0 0 0q�5p   %   5q      5r      5s      �� 5t   
   -
   5         ��Name$ 
SwordCheck��5t      $
��Left=�5w      $��Center=�5x      $��60 300 0 80q�5y      $��17��6(   �� 5z   
   -   5        $ PotionCheck��5z      $
��Left=�5}      $��Center=�5~      $��	60 0 0 75q�5      $��17��6&   �� 5�   
   -   5         ��Name$ StartButton��5�       �� 	IsDefault . $��Bottom=�5�      $��Right=�5�      $��	0 0 50 50q�5�      $��50��6$   $	��120��60   $��Start��5�      $��30(�5�      �� 5�   
   -   5         ��Name$ 	EnemyIcon��5�        	EnemyIcon#��[ 5�      $��Right=�5�      $��Center=�5�      $��0 0 60 0q�5�      $��95��6+   $	��100��67   �� 5�   
   -   5        $ 
PotionIcon��5�        
PotionIcon#��[ 5�      $
��Left=�5�      $��Center=�5�      $��
100 0 0 80q�5�      $	��120��6-   $	��120��6:   $y�	Collapsed=�5�      �� 5�   
   -   5        $ PotionIconDisabled��5�        PotionIconDisabled#��[ 5�      $
��Left=�5�      $��Center=�5�      $��
100 0 0 80q�5�      $	��120��6-   $	��120��6:   �� 5�   
   -   5        $ 	SwordIcon��5�        	SwordIcon#��[ 5�      $
��Left=�5�      $��Center=�5�      $��
90 220 0 0q�5�      $	��120��6-   $	��120��6:   $y�	Collapsed=�5�      �� 5�   
   -   5        $ SwordIconDisabled��5�        SwordIconDisabled#��[ 5�      $
��Left=�5�      $��Center=�5�      $��
90 220 0 0q�5�      $	��120��6-   $	��120��6:   �� 5�   
   -   5        $ 
TrophyIcon��5�       	 
TrophyIcon#��[	 5�      $��Center=�5�      $��Center=�5�      $��0 0 110 300q�5�      $��90��6.   $��77��6:   $y�	Collapsed=�5�      �� 5�   
   -   5        $ FlagIcon��5�       
 FlagIcon#��[
 5�      $��Center=�5�      $��Center=�5�      $��0 250 110 0q�5�      $��90��6.   $��90��6:   $y�	Collapsed=�5�      5�      5�      