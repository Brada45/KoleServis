   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      &     KoleServis.MVVM.View.WorkersView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $
��0.5* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      &   System.Windows.Controls.DataGrid  
���   �   AutoGenerateColumns$ False��6r   ��6*   �� *	Persons+ �� SelectedItem 6J   �� *SelectedPerson+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6)      Username   Header# �   6<      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6`   �� *KorisnickoIme+   ElementStyle 5      �� 5      	 �� 
TargetType"	 ��6$   .�5   "   �� 
 �� Property
 � �� �� Value$
 Wrap=�6A   �� 5   "   
 � ��$ Center=�6F   �� 5   "   
 � ��$
 Left=�6H   5      5        5      $
 True��6)   # � ��6<   $
 0.3* 6t    6\   �� *Ime+ 5      �� 5      "	 ��6$   .�5   "   �� 
 � ��$
 Wrap=�6A   �� 5    "   
 � ��$ Center=�6F   �� 5!   "   
 � ��$
 Left=�6H   5"      5$        5%      $
 True��6)     Surname# �  6<   $
 0.3* 6{    6_   �� *	Prezime+ 5&      �� 5'      "	 ��6$   .�5(   "   �� 
 � ��$
 Wrap=�6A   �� 5)   "   
 � ��$ Center=�6F   �� 5*   "   
 � ��$
 Left=�6H   5+      5-      5/      50      � 51   
   $��1��6    � RowDefinitions 52      �� 53      $��1* �6    �� 54      $
��0.1* �6    �� 55      $
��0.5* �6    .+�57      �� $��0��6   .+�58      �� )  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   5:        font   
FontFamily# �  5;         FloatingOffset$ 0,-20&�5<      $��	0 0 0 1.5q�5=      $��Center=�5>      $��100,10,100,10q�5?      ��58      �� *
Username+{�59      �� *EditUsername+5?      �� 5A      # � ��5B      # �  5C      $ 0,-20&�5D      $��	0 0 0 1.5q�5E      $��Center=�5F      $��100,10,100,10q�5G      ��5A      �� *Name+5G      �� 5I      # �  5J      # �  5K      $ 0,-20&�5L      $��	0 0 0 1.5q�5M      $��Center=�5N      $��100,10,100,10q�5O      ��5I      �� *	Surname+5O      �� 5Q        Password# �  5R      # �  5S      $ 0,-20&�5T      $��	0 0 0 1.5q�5U      $��Center=�5V      $��100,10,100,10q�5W      ��5Q      �� *
Password+{�64   �� *EditUsername+5W      �� 5Y        ConfirmPassword# �  5Z      # �  5[      $ 0,-20&�5\      $��	0 0 0 1.5q�5]      $��Center=�5^      $��100,10,100,10q�5_      ��5Y      �� *ConfirmPassword+{�6;   �� *EditUsername+5_      5`      �� 5b      $��3��6   .+�5c      � .+�5d      �� +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6     CommandButton#��[ 5g       � ToolTip$7 1MaterialDesignRaisedDarkButton with Round Corners��5h      # �  5i      $��100,0,100,0q�5j      ��5e      �� *
AddCommand+{�5f      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��5k      ��   Add#���  6$   5l      5m      � 5n      .+�5o      �� $ 25��6   #��[ 5r      # �  5s      $7 1MaterialDesignRaisedDarkButton with Round Corners��5t      $��100,0,100,0q�5u   "   ��5p      �� *UpdateCommand+{�5q      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5v      ��  
 Update#���  6$   5w      5x      � 5y      .+�5z      �� $ 25��6   #��[ 5}      # �  5~      $7 1MaterialDesignRaisedDarkButton with Round Corners��5      $��100,0,100,0q�5�   !   ��5{      �� *DeleteCommand+{�5|      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      ��  
 Delete#���  6$   5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      # �  5�      $7 1MaterialDesignRaisedDarkButton with Round Corners��5�      $��100,0,100,0q�5�      ��5�      �� *ClearCommand+{�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      ��  		 Clear#��� 	 6$   5�      5�      5�      5�      5�      5�      