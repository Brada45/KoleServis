   M S B A M L   `   `   `  ����  
KoleServis     KoleServis.MVVM.View.Login   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
�������.��5	      �   � ColumnDefinitions  5
   
   �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   � $��0��6   .+�5      �� $ ��Resources\behind_logo.jpeg��6   $��0,-93,-57,-100q�68   �� 5      $��Resources\logo.png��6   $��Uniform=�5      $
��Left=�5      $��Center=�5      5      � 5   
   $��1��6   
������� � RowDefinitions 5      �� 5      $��1* �6    �� 5      $
��Auto �6    �� 5      $
��0.1* �6    �� 5      $
��Auto �6    �� 5      $��1* �6    �� 5      $
��Auto �6    .+�5       �� $��0��6    	  Login#���   6%   $��30(�6D   $��Oblique$�6R   $
��Bold"�6f   $��Center=�5!      $��Center=�6-   � 5"      $��1��6   $��Stretch=�6    $��100,0,100,0q�6>     5#      �� 5$      $
��Auto �6'   �� 5%      $��* �6'   .+�5(      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Account=�6*   $��24��5)      $��24��6)   $��Center=�5*      $��0,0,10,0q�5+      �� 5-      -   5         ��Name$ username��5-        Username)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5/   
      FloatingOffset$ 0,-20&�50   
   ���#c5c8cc$��	0 0 0 1.5q�52   
   $��Center=�53   
   $��1��54   
   ��5.   
   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�54   
   55      � 57      $��3��6   $��Stretch=�6    $��100,0,100,0q�6>     58      �� 59      $
��Auto �6'   �� 5:      $��* �6'   .+�5=        $
 Lock=�6*   $��24��5>      $��24��6)   $��Center=�5?      $��0,0,10,0q�5@      G� 5B      -   5         G�Name$ password��5B       ) %MaterialDesignFloatingHintPasswordBox#��[ 5C        Password# �  5D      $ 0,-20&�5E      ���#c5c8cc$��	0 0 0 1.5q�5G      $��Center=�5H      $��1��5I      5J      5L      � 5M      $��4��6   $��Stretch=�6    $��Stretch=�6>   .+�5N      ��   Warrning#���  5O      $
��Wrap=�5P      $��Center=�5Q      $	��Top=�5R      $
��Auto��5S      $��0,10,0,0q�6   ��5N      �� *WarrningColor+5S      �� 5U      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6   $
|�True��5V        CommandButton#��[ 5Y      	 � ToolTip$7	 1MaterialDesignRaisedDarkButton with Round Corners��5Z      $��100,0,100,0q�5[      ��5W      �� *LoginCommand+{�5X      �� *DataContext.ControlsEnabled+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType
 Window.��5\      ��   
LoginSmall#���  6    5]      d� 5^      $��Right=�5_      $��Bottom=�6$   $��0,0,10,2q�5b       d� 	IsChecked 5`      �� *	IsToggled+ �� Mode$ TwoWay=���5a      �� *ChangeLanguageCommand+.��5c      �� ��5d      �� 5e       �� 
TargetType" ��6$   .�5g   "   ��  �� Property � �� �� Value$  Resources/serbian-flag.png��6;    �� Triggers 5h   "   �� 5j   &    �� Binding 62   �� *	IsChecked+
 ��  ToggleButton �� Value True6�   .a�5k   *   ��  � ��$&  Resources/great-britain-flag.png��6C   5l   '   5n      5p      5q      5s      5t      5v      5w      