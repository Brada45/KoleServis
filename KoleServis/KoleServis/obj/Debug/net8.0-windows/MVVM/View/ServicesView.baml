   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      '    !KoleServis.MVVM.View.ServicesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6   .+�5   
   � $��0��6   .+�5      �    OverallBackground#���   6    � RowDefinitions 5      �� 5      $
��0.1* �6$   �� 5      $
��0.8* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��0q�6C   .+�5      � $��Center=�6   $��Center=�66   $��	10,0,10,0q�6S     5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      �� 
������ 
������ ��6!   �� *SearchCommand+.��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�66   
���   �$��Center=�6X   $��30��6s   $��30��6~   5!      �� 5#      $��1��6"   $��Center=�5%       
 Search)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5&       �� TextWrapping$
 Wrap=�5'      $	��200��6+   $��10q�5(      ��5$      �� *
SearchItem+5(      5)      5,      &   System.Windows.Controls.DataGrid  5-      $��1��6   
���   �   AutoGenerateColumns$ False��6�   ��6=   �� *Items+ �� SelectedItem 6[   �� *SelectedItem+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly$
	 True��6-    	 Title
   Header#
 �  6?      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6`   �� *Naziv+   ElementStyle 51      �� 52   "    �� 
TargetType" ��6(   .�53   &   ��  �� Property � �� �� Value$
 Wrap=�6E   �� 54   &    � ��$ Center=�6J   �� 55   &    � ��$
 Left=�6L   56   #   58        59      $
	 True��6-    	 Price#
 �  6?   $
 0.3* 6{    6`   �� *Cijena+ 5:      �� 5;   "   " ��6(   .�5<   &   ��  � ��$
 Wrap=�6E   �� 5=   &    � ��$ Center=�6J   �� 5>   &    � ��$
 Left=�6L   5?   #   5A        5B      $
	 True��6-     AddedBy#
 �  6?   $
 0.3* 6�    6b   �� *MenadzerOsobaKorisnickoIme+ 5C      �� 5D   "   " ��6(   .�5E   &   ��  � ��$
 Wrap=�6E   �� 5F   &    � ��$ Center=�6J   �� 5G   &    � ��$
 Left=�6L   5H   #   5J      5L      5M      5N      � 5O   
   $��1��6   #���   6    5P      �� 5Q      $
��0.5* �6    �� 5R      $
��0.1* �6    �� 5S      $
��0.5* �6    .+�5U      �� $��0��6   .+�5V      ��   	TitleName# �  5W        font   
FontFamily# �  5X         FloatingOffset$ 0,-20&�5Y      $��	0 0 0 1.5q�5Z      $��Center=�5[      $��100,100,100,10q�5\      ��5V      �� *Title+5\      �� 5^      -   5        # �  5_      # �  5`      $ 0,-20&�5a      $��	0 0 0 1.5q�5b      $��Center=�5c      $��100,10,100,10q�5d      ��5^      �� *Price+5f      5g      �� 5i      $��3��6   .+�5j      � .+�5k      �� +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6     CommandButton#��[ 5m      # �  5n      $��100,0,100,0q�5o      ��5l      �� *
AddCommand+.��5p      �� $ 
Horizontal=�6%   .+�5q        $
 Plus=�66   �� 5r        Add#���  6(    	 CommandText#��[	 6E   5s      5t      5u      � 5v      .+�5w      �� $ 25��6   #��[ 5z      # �  5{      $��100,0,100,0q�5|      ��5x      �� *UpdateCommand+{�5y      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��5}      �� $ 
Horizontal=�6%   .+�5~        $ Refresh=�66   �� 5       

 Update#��� 
 6(   #��[	 6H   5�      5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      # �  5�      $��100,0,100,0q�5�      ��5�      �� *DeleteCommand+{�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      �� $ 
Horizontal=�6%   .+�5�        $ DeleteOutline=�66   �� 5�       
 Delete#���  6(   #��[	 6H   5�      5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      # �  5�      $��100,0,100,0q�5�      ��5�      �� *ClearCommand+{�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      �� $ 
Horizontal=�6%   .+�5�        $ BackspaceOutline=�66   �� 5�       	 Clear#���  6(   #��[	 6G   5�      5�      5�      5�      5�      5�      5�      