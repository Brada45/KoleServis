   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      Q-clr-namespace:KoleServis.MVVM.View.ComponentsKoleServis.MVVM.View.Components  5      )    #KoleServis.MVVM.View.CreateBillView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      C	component-clr-namespace:KoleServis.MVVM.View.Components     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      
�������.��5      � -   5          �Name$  CreateBillGrid��5       � ColumnDefinitions 5   
   �� 5      $
��0.6* �6   �� 5      $
��0.5* �6   .+�5   
   � $��0��6   .+�5      �  � RowDefinitions 5      �� 5      $
��0.2* �6$   �� 5      $
��0.8* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��0q�6C   .+�5      � $��Center=�6   $��Center=�66   $��	10,0,10,0q�6S    5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      �� 
������ 
������ ��6!   �� *SearchCommand+.��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�66   $��Center=�6E   $��30��6`   $��30��6k   5       �� 5"      $��1��6"   $��Center=�5$       
  Search)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   5%       �� TextWrapping$
 Wrap=�5&   '   $	��200��6;   $��10q�5'      ��5#      �� *
SearchItem+5'      5(      �� 5*      $��20,0,0,0q�6!   .+�5+      �  5,      �� 5-   "   �� 5.   "   .+�50      �� -   5         ��Name$% OutlinedComboBoxEnabledCheckBox��51   !    	 Items#���  52   "    d� 	IsChecked 53   "   �� *ItemsChecked+�� 54      $��1��55   "   $��Right=�57   "    	 Clear#���  58   "     MaterialDesignFlatButton#��[ 59   "   ��56   !   �� *ClearCommand+59   "   5:      �� 5;      $	��256��5<        Category# �  5=       " MaterialDesignOutlinedComboBox#��[ 5A      {�5>      �� 	 �� Path$	 	IsChecked�
 �� ElementName$%
 OutlinedComboBoxEnabledCheckBox����5?      �� *
Categories+ �� SelectedItem 5@      �� *SelectedCategory+ �� Mode$ TwoWay=�5A      5B      5C      � 5D      $��1��6   .+�5E      �� ��6   �� *
Dijelovi+ 6?   �� *SelectedItem+��5F      �� 5G   "   .R�5H   &   �  � Orientation$ 
Horizontal=�60   5I   #   ��5K      �� 5L   "   .R�5M   &   3   -KoleServis.MVVM.View.Components.ItemComponent  $��5q�6V    � DataContext 6>   �� 6V   5N   #   5P      5Q      5R      5S      � 5T   
   $��1��6    5U      �� 5V      $��1* �6    �� 5W      $��1* �6    .+�5Y      &   System.Windows.Controls.DataGrid  $��0��6      AutoGenerateColumns$ False��6p   ��6$   �� *	ItemsBill+ 6F   �� *SelectedItemBill+   Columns 5Z      0  *System.Windows.Controls.DataGridTextColumn  5]      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6)    	 Title   Header# �  66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   �� *Naziv+   ElementStyle 5^      �� 5_       �� 
TargetType" ��6$   .�5`   "   ��  �� Property � �� �� Value$
 Wrap=�6A   �� 5a   "    � ��$ Center=�6F   �� 5b   "    � ��$ Center=�6H   5c      5e        5h      $
 0.2* 6)    	 Price# �  66    6W   �� *Cijena+ 5i      �� 5j      " ��6%   .�5k   #   ��  � ��$
 Wrap=�6B   �� 5l   #    � ��$ Center=�6G   �� 5m   #    � ��$ Center=�6I   5n       5p      4	  .System.Windows.Controls.DataGridTemplateColumn	  5r      $
 0.2* 6-     Quantity# �  6:    	  CellTemplate 5s      �� 5t      .R�5u   "   � $��Center=�6'   $��Center=�6D    5v   &   �� 5w   *   $
��0.2* �6;   �� 5x   *   $
��0.2* �6;   �� 5y   *   $
��0.2* �6;   .+�5}   &   �� $��-��6-   $��20(�69   $��Center=�6G   $��Center=�6b   $��50��6   $��30��6�   $��0��6  ��6�   �� *DataContext.DecreaseCommand+ �� RelativeSource ��  �� AncestorType"  6  �� 5�   &   $��Center=�60   $��Center=�6K   $��50��6�   $��1��6�    �� TextAlignment$ Center=�6�   ��6h   �� *
Kolicina+6�   �� 5�   &   $��+��6-   $��20(�69   $��Center=�6G   $��Center=�6b   $��50��6   $��30��6�   $��2��6  ��6�   �� *DataContext.IncreaseCommand+ �� "  6  5�   #   5�      5�        5�      $
 0.2* 6)    	 OverallPrice# � 	 66    6^   �� *UkupnaCijena+ 5�      �� 5�      " ��6$   .�5�   "   ��  � ��$
 Wrap=�6A   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��$ Center=�6H   5�      5�      	  5�      $ 0.15* 6-    

 Delete# � 
 6;    5�      �� 5�      .R�5�   "   �� 
������ 
���   �
������ ��6)   �� *DataContext.DeleteCommand+ �� "  .��5�   &     $ Delete=�6>   $��Center=�6L   $��30��6g   $��30��6r   5�   #   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��0.2* �6$   �� 5�      $
��0.7* �6$   .+�5�      � $��0��6   .+�5�      �� $��Center=�5�      # � 	 5�      ��5�      �� *	PriceOver+5�      � 5�      $��1��6    5�      �� 5�      $��1* �6+   �� 5�      $��1* �6+   .+�5�      � $��0��6   .+�5�        $ False��6o   ��6#   �� *	Customers+ 6E   �� *SelectedCustomer+ 5�        5�   "   $
 0.3* 65     Customer# �  6B    6f   �� *Naziv+ 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$
 Wrap=�6M   �� 5�   .    � ��$ Center=�6R   �� 5�   .    � ��$ Center=�6T   5�   +   5�   #   5�      5�      � 5�      $��1��6    5�      �� 5�      $
��0.2* �6,   �� 5�      $
��0.8* �6,   .+�5�      �� $ 
Horizontal=�6%   $��0��6>   .+�5�      (
  "System.Windows.Controls.DatePicker
  $��10q�6)    
  SelectedDate 66   �� *SelectedDate+$ TwoWay=�)  #MaterialDesignThemes.Wpf.TimePicker  5�      $��10q�68      	Is24Hours$
 True��6E      SelectedTime 5�      �� *SelectedTime+$ TwoWay=�5�      � 5�      $��1��6   .+�5�      �� .+�5�   "   �� $	��Top=�5�        SelectedCustomer# �  5�      ��5�      �� *CustomerName+�� 5�   "   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6)     CommandButton#��[ 5�   '     font    
FontFamily#  �  5�   %   ! � ToolTip$7! 1MaterialDesignRaisedDarkButton with Round Corners��5�   '   $��
10,10,10,0q�5�   *   ��5�   %   �� *CreateCommand+{�5�   '   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�   &   ��   
CreateBill#���  60   5�   #   �� 5�   "   $ 25��6)   #��[ 5�   (   #  �  5�   &   $7! 1MaterialDesignRaisedDarkButton with Round Corners��5�   (   $��
10,10,10,0q�5�   +   ��5�   &   �� *PrintCommand+{�5�   (   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�   &   ��  	 Print#���  60   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      