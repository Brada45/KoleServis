   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      Q-clr-namespace:KoleServis.MVVM.View.ComponentsKoleServis.MVVM.View.Components  5      $    KoleServis.MVVM.View.ItemsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      C	component-clr-namespace:KoleServis.MVVM.View.Components     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6      OverallBackground#���   6   .+�5      �  � RowDefinitions 5      �� 5      $
��0.2* �6$   �� 5      $
��0.8* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��0q�6C   .+�5      � $��Center=�6   $��Center=�66   $��	10,0,10,0q�6S     5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      �� 
������ 
������ ��6!   �� *SearchCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�66     ButtonForegroundColor#���  6E   $��Center=�6z   $��30��6�   $��30��6�   5       �� 5"      $��1��6"   $��Center=�5$       
 Search)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5%       �� TextWrapping$
 Wrap=�5&      $	��200��6+   $��10q�5'      ��5#      �� *
SearchItem+5'      5(      �� 5*      $��20,0,0,0q�6!   .+�5+      �   5,      �� 5-   "   �� 5.   "   .+�50      ��  	 Items#���  51       d� 	IsChecked 52      �� *ItemsChecked+�� 53      $��1��54      $��Right=�56       	 Clear#���  57        MaterialDesignFlatButton#��[ 58      ��55      �� *ClearCategoryCommand+58      59      �� 5:      $	��256��5;        Category# �  5<       " MaterialDesignOutlinedComboBox#��[ 5@      {�5=      ��  �� Path$ 	IsChecked� �� ElementName$% OutlinedComboBoxEnabledCheckBox����5>      �� *
Categories+	 �� SelectedItem	 5?      �� *SelectedSearchCategory+
 �� Mode$
 TwoWay=���5A      �� 5B   "   .R�5C   &   �� #���   6A     ButtonForegroundBrush#���  6r   ��60   �� 6r   5D   #   5F      5G      5H      �� 5I      $��1��6   ��6'   �� *
Dijelovi+	 6H   �� *SelectedItem+��5J      �� 5K      .R�5L      �  � Orientation$ 
Horizontal=�6(   5M      ��5O      �� 5P      .R�5Q      3   -KoleServis.MVVM.View.Components.ItemComponent  $��5q�6N    � DataContext 66   �� 6N   5R      5T      5U      5V      � 5W   
   $��1��6   #���   6    5X      �� 5Y      $
��0.7* �6    �� 5Z      $
��0.1* �6    �� 5[      $
��0.3* �6    .+�5]      �� $��0��6   .+�5_      ��  	 	TitleName# � 	 5`         FloatingOffset$ 0,-20&�5a      $��	0 0 0 1.5q�5b      $��Center=�5c      $��100,10,60,10q�5d      ��5_      �� *Title+5d      �� 5f      -   5         	
 Price# � 
 5g   
   $ 0,-20&�5h   
   $��	0 0 0 1.5q�5i   
   $��Center=�5j   
   $��100,10,60,10q�5k   
   ��5f      �� *Price+5m   
   �� 5p      -   5          Quantity# �  5q   
   $ 0,-20&�5r   
   $��	0 0 0 1.5q�5s   
   $��Center=�5t   
   $��100,10,60,10q�5u   
   ��5p      �� *
Quantity+5v   
   � 5x        5y      �� 5z      $
��0.5* �6+   �� 5{      $
��0.5* �6+   .+�5}      �� #���  6    $��100,10,0,10q�6C   �� 5~      $��Stretch=�6   $��Stretch=�6;   $��1��6Y    �� Text# �  6i   $	��140��6�   ��6�   �� *
Categories+	 6�   �� *SelectedCategory+��5      �� 5�      .R�5�   "   �� #���   6=     	ListColor#���  6n   ��6,   �� 6n   5�      5�      5�      � 5�        5�      �� 5�      $
��0.5* �6+   �� 5�      $
��0.5* �6+   .+�5�      �� $��1��5�      $��Uniform=�5�      $	��200��5�      $	��150��5�      $��Center=�5�      $��Center=�5�      $��5q�5�      ��5�      �� *SelectedImage+5�      �� 5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6   $��0��6K     CommandButton#��[ 5�      $��	50,0,50,0q�5�      ��5�      �� *UpdateImageCommand+{�5�      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType
 Window.��5�      �� $ 
Horizontal=�6%   .+�5�        $ FileUploadOutline=�66   �� 5�        UpdateImage#���  6(     CommandText#��[ 6N   5�      5�      5�      5�      � 5�      $��3��6    5�      �� 5�      $
��0.8* �6$   �� 5�      $
��0.2* �6$   .+�5�      �� $��0��6   .+�5�      � .+�5�      �� $ 25��6   #��[ 5�   
   $��100,0,100,0q�5�      ��5�      �� *
AddCommand+{�5�   
   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      �� $ 
Horizontal=�6)   .+�5�   "     $
 Plus=�6:   �� 5�   "     Add#���  6,   #��[ 6I   5�      5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      $��100,0,100,0q�5�      ��5�      �� *UpdateCommand+{�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ Refresh=�6:   �� 5�   "    
 Update#���  6,   #��[ 6L   5�      5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      $��100,0,100,0q�5�      ��5�      �� *DeleteCommand+{�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ DeleteOutline=�6:   �� 5�   "    
 Delete#���  6,   #��[ 6L   5�      5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      $��100,0,100,0q�5�      ��5�      �� *ClearCommand+{�5�      �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�      �� $ 
Horizontal=�6)   .+�5�   "     $ BackspaceOutline=�6:   �� 5�   "   #���  6,   #��[ 6K   5�      5�      5�      5�      �� 5�      $��1��6   $��Bottom=�6)     Info#���  6D   6d   5�      5�      5�      5�      