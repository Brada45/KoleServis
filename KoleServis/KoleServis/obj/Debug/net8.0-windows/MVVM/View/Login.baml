   M S B A M L   `   `   `  ����  
KoleServis     KoleServis.MVVM.View.Login   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
�������.��5	      �   J� InputBindings  5
   
   �� 5      
 �� Key$ Enter��6    �� Command 5      �� *LoginCommand+ � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   � $��0��6   .+�5      �� $ ��Resources\behind_logo.jpeg��6   $��0,-93,-57,-100q�68   �� 5      $��Resources\slika.png��6   $��Uniform=�5      $
��Left=�5      $��Center=�5      5      � 5   
   $��1��6      OverallBackground#���   6    � RowDefinitions 5      �� 5      $��1* �6    �� 5      $
��Auto �6    �� 5      $
��0.1* �6    �� 5       $
��Auto �6    �� 5!      $��1* �6    �� 5"      $
��Auto �6    .+�5$      �� $��0��6    	 Login#���  6%   $��30(�6D   $��Oblique$�6R   $
��Bold"�6f   $��Center=�5%      $��Center=�6-   � 5&      $��1��6   $��Stretch=�6    $��100,0,100,0q�6>    5'      �� 5(      $
��Auto �6'   �� 5)      $��* �6'   .+�5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6*   $��24��5-      $��24��6)   $��Center=�5.      $��0,0,10,0q�5/      �� 51      -   5         ��Name$ username��51        Username)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  53   
      FloatingOffset$ 0,-20&�54   
   ���#c5c8cc$��	0 0 0 1.5q�56   
   $��Center=�57   
   $��1��58   
   ��52   
   �� *
Username+	 �� UpdateSourceTrigger$	 PropertyChanged=�58   
   59      � 5;      $��3��6   $��Stretch=�6    $��100,0,100,0q�6>    5<      �� 5=      $
��Auto �6'   �� 5>      $��* �6'   .+�5A        $
 Lock=�6*   $��24��5B      $��24��6)   $��Center=�5C      $��0,0,10,0q�5D      G� 5F      -   5        
 G�Name$
 password��5F       ) %MaterialDesignFloatingHintPasswordBox#��[ 5G        Password# �  5H      $ 0,-20&�5I      ���#c5c8cc$��	0 0 0 1.5q�5K      $��Center=�5L      $��1��5M      5O      5Q      � 5R      $��4��6   $��Stretch=�6    $��Stretch=�6>   .+�5S      ��   Warrning#���  5T      $
��Wrap=�5U      $��Center=�5V      $	��Top=�5W      $
��Auto��5X      $��0,10,0,0q�6   ��5S      �� *WarrningColor+5X      �� 5Z      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6     CommandButton#��[ 5\      $��100,0,100,0q�5]      ��5[      �� *LoginCommand+.��5^      ��  �� Orientation$ 
Horizontal=�6!   .+�5_        $ Login=�62   �� 5`        
LoginSmall#���  6$     CommandText#��[ 6H   5a      5b      d� 5c      $��Right=�5d      $��Bottom=�6$   $��0,0,10,2q�5g       d� 	IsChecked 5e      �� *	IsToggled+ �� Mode$ TwoWay=���5f      �� *ChangeLanguageCommand+.��5h      �� ��5i      �� 5j       �� 
TargetType" ��6$   .�5l   "   ��  �� Property � �� �� Value$  Resources/serbian-flag.png��6;    �� Triggers 5m   "   �� 5o   &    �� Binding 62   �� *	IsChecked+ �� RelativeSource ��  �� AncestorType ToggleButton �� Value True6�   .a�5p   *   ��  � ��$&  Resources/great-britain-flag.png��6C   5q   '   5s      5u      5v      5x      5y      5{      5|      