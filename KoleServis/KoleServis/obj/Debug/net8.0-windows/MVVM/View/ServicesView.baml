   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      '    !KoleServis.MVVM.View.ServicesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   .+�5   
   � $��0��6   .+�5      &   System.Windows.Controls.DataGrid  
���   �   AutoGenerateColumns$ False��6p   ��6,   �� *Items+ �� SelectedItem 6J   �� *SelectedItem+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6)    	  Title   Header# �   6;      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6v   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6\   �� *Naziv+   ElementStyle 5      �� 5      	 �� 
TargetType"	 ��6$   .�5   "   �� 
 �� Property
 � �� �� Value$
 Wrap=�6A   �� 5   "   
 � ��$ Center=�6F   �� 5   "   
 � ��$
 Left=�6H   5      5        5      $
 True��6)    	 Price# �  6;   $
 0.3* 6w    6\   �� *Cijena+ 5      �� 5       "	 ��6$   .�5!   "   �� 
 � ��$
 Wrap=�6A   �� 5"   "   
 � ��$ Center=�6F   �� 5#   "   
 � ��$
 Left=�6H   5$      5&        5'      $
 True��6)     AddedBy# �  6;   $
 0.3* 6�    6^   �� *MenadzerOsobaKorisnickoIme+ 5(      �� 5)      "	 ��6$   .�5*   "   �� 
 � ��$
 Wrap=�6A   �� 5+   "   
 � ��$ Center=�6F   �� 5,   "   
 � ��$
 Left=�6H   5-      5/      51      52      � 53   
   $��1��6    � RowDefinitions 54      �� 55      $
��0.5* �6    �� 56      $
��0.1* �6    �� 57      $
��0.5* �6    .+�59      �� $��0��6   .+�5:      ��   	TitleName)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5;        font   
FontFamily# �  5<         FloatingOffset$ 0,-20&�5=      $��	0 0 0 1.5q�5>      $��Center=�5?      $��100,100,100,10q�5@      ��5:      �� *Title+5@      �� 5B      # �  5C      # �  5D      $ 0,-20&�5E      $��	0 0 0 1.5q�5F      $��Center=�5G      $��100,10,100,10q�5H      ��5B      �� *Price+5H      5I      �� 5K      $��3��6   .+�5L      � .+�5M      �� +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6     CommandButton#��[ 5P       � ToolTip$7 1MaterialDesignRaisedDarkButton with Round Corners��5Q      # �  5R      $��100,0,100,0q�5S      ��5N      �� *
AddCommand+{�5O      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��5T      ��   Add#���  6$   5U      5V      � 5W      .+�5X      �� $ 25��6   #��[ 5[      # �  5\      $7 1MaterialDesignRaisedDarkButton with Round Corners��5]      $��100,0,100,0q�5^      ��5Y      �� *UpdateCommand+{�5Z      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5_      ��  
 Update#���  6$   5`      5a      � 5b      .+�5c      �� $ 25��6   #��[ 5f      $7 1MaterialDesignRaisedDarkButton with Round Corners��5g      # �  6R   $��100,0,100,0q�5h      ��5d      �� *DeleteCommand+{�5e      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5i      ��  
 Delete#���  6$   5j      5l      � 5m      .+�5n      �� $ 25��6   #��[ 5q      $7 1MaterialDesignRaisedDarkButton with Round Corners��5r      # �  6O   $��100,0,100,0q�5s      ��5o      �� *ClearCommand+{�5p      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5t      ��  		 Clear#��� 	 6$   5u      5w      5x      5y      5z      5{      