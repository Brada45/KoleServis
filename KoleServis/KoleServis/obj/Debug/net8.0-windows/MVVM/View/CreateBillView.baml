   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      E'clr-namespace:KoleServis.MVVM.ViewModelKoleServis.MVVM.ViewModel  5      Q-clr-namespace:KoleServis.MVVM.View.ComponentsKoleServis.MVVM.View.Components  5	      )    #KoleServis.MVVM.View.CreateBillView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      BlocalViewModel'clr-namespace:KoleServis.MVVM.ViewModel     5      C	component-clr-namespace:KoleServis.MVVM.View.Components     5	      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      .��5      � -   5          �Name$  CreateBillGrid��5       � ColumnDefinitions 5   
   �� 5      $
��0.6* �6   �� 5      $
��0.5* �6   .+�5   
   � $��0��6   .+�5      �  � RowDefinitions 5      �� 5      $
��0.2* �6$   �� 5      $
��0.8* �6$   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6*   $��0q�6C   .+�5      � $��Center=�6   $��Center=�66   $��	10,0,10,0q�6S    5      �� 5      $
��Auto �6/   �� 5      $��* �6/   .+�5      �� 
������ 
������ ��6!   �� *SearchCommand+.��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�66   $��Center=�6E   $��30��6`   $��30��6k   5!      �� 5#      $��1��6"   $��Center=�5%       
  Search)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   5&       �� TextWrapping$
 Wrap=�5'   '   $	��200��6;   $��10q�5(      ��5$      �� *
SearchItem+5(      5)      �� 5+      $��20,0,0,0q�6!   .+�5,      �  5-      �� 5.   "   �� 5/   "   .+�51      �� -   5         ��Name$% OutlinedComboBoxEnabledCheckBox��52   !    	 Items#���  53   "    d� 	IsChecked 54   "   �� *ItemsChecked+�� 55      $��1��56   "   $��Right=�58   "    	 Clear#���  59   "     MaterialDesignFlatButton#��[ 5:   "   ��57   !   �� *ClearCommand+5:   "   5;      �� 5<      $	��256��5=        Category# �  5>       " MaterialDesignOutlinedComboBox#��[ 5B      {�5?      �� 	 �� Path$	 	IsChecked�
 �� ElementName$%
 OutlinedComboBoxEnabledCheckBox����5@      �� *
Categories+ �� SelectedItem 5A      �� *SelectedCategory+ �� Mode$ TwoWay=���5C      �� 5D   "   .R�5E   &   ��   OverallBackground#���  6A     	ListColor#���  6r   ��60   �� 6r   5F   #   5H      5I      5J      � 5K      $��1��6   .+�5L      �� ��6   �� *
Dijelovi+ 6?   �� *SelectedItem+��5M      �� 5N   "   .R�5O   &   �  � Orientation$ 
Horizontal=�60   5P   #   ��5R      �� 5S   "   .R�5T   &   3   -KoleServis.MVVM.View.Components.ItemComponent  $��5q�6V    � DataContext 6>   �� 6V   5U   #   5W      5X      5Y      5Z      � 5[   
   $��1��6    5\      �� 5]      $��1* �6    �� 5^      $��1* �6    .+�5`      &   System.Windows.Controls.DataGrid  $��0��6      AutoGenerateColumns$ False��6p   ��6$   �� *	ItemsBill+ 6F   �� *SelectedItemBill+   Columns 5a      0  *System.Windows.Controls.DataGridTextColumn  5b      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.3* 6)    	 Title   Header# �  66   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   �� *Naziv+   ElementStyle 5c      �� 5d       �� 
TargetType" ��6$   .�5e   "   ��  �� Property � �� �� Value$
 Wrap=�6A   �� 5f   "    � ��$ Center=�6F   �� 5g   "    � ��$ Center=�6H   5h      5j        5l      $
 0.2* 6)    		 Price# � 	 66    6W   �� *Cijena+ 5m      �� 5n      " ��6$   .�5o   "   ��  � ��$
 Wrap=�6A   �� 5p   "    � ��$ Center=�6F   �� 5q   "    � ��$ Center=�6H   5r      5t      4	  .System.Windows.Controls.DataGridTemplateColumn	  5u      $
 0.2* 6-    
 Quantity# � 
 6:    	  CellTemplate 5v      �� 5w      .R�5x   "   � $��Center=�6'   $��Center=�6D    5y   &   �� 5z   *   $
��0.2* �6;   �� 5{   *   $
��0.2* �6;   �� 5|   *   $
��0.2* �6;   .+�5   &   �� $��20(�6.   $��Center=�6<   $��Center=�6W   $��50��6t   $��30��6   $��0��6�   ��6�   �� *DataContext.DecreaseCommand+ �� RelativeSource ��  �� AncestorType"  .��5�   *     $ 
MinusThick=�6B   5�   '   �� 5�   &   $��Center=�60   $��Center=�6K   $��50��6�   $��1��6�    �� TextAlignment$ Center=�6�   ��6h   �� *
Kolicina+6�   �� 5�   &   $��20(�6-   $��Center=�6;   $��Center=�6V   $��50��6s   $��30��6~   $��2��6�   ��6�   �� *DataContext.IncreaseCommand+ �� "  .��5�   *     $
 Plus=�6B   5�   '   5�   #   5�      5�        5�      $
 0.2* 6)     OverallPrice# �  66    6^   �� *UkupnaCijena+ �� StringFormat$ F2�� 5�      �� 5�      " ��6$   .�5�   "   ��  � ��$
 Wrap=�6A   �� 5�   "    � ��$ Center=�6F   �� 5�   "    � ��$ Center=�6H   5�      5�      	  5�      $
 0.1* 6-     
DeleteItem# �  6:    5�      �� 5�      .R�5�   "   �� 
������ 
���  ��
������ $��0q�5�   T   ��5�   )   �� *DataContext.DeleteCommand+ �� "  .��5�   &     $ DeleteOutline=�6>   $
��Left=�6S   $��Center=�6n   $��30��6�   $��30��6�   5�   #   5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $
��0.2* �6$   �� 5�      $
��0.7* �6$   .+�5�      � $��0��6    5�      �� 5�      $��1* �6+   �� 5�      $��1* �6+   .+�5�      �� $��0��6   $��Center=�5�      $
��Left=�5�        
BillNumber# �  5�      $��10q�5�   B   ��6   �� *Number+$ F2��6B   �� 5�      $��1��6   $��Center=�5�      $��Center=�5�       �� 
IsReadOnly$
 True��5�        TotalPayment# �  5�      $��10q�5�   E   ��6   �� *	PriceOver+$ F2��6E   5�      � 5�      $��1��6    5�      �� 5�      $��1* �6+   �� 5�      $��1* �6+   .+�5�      � $��0��6   .+�5�        $ False��6o   ��6#   �� *	Customers+ 6E   �� *SelectedCustomer+ 5�        5�   "   $
 0.3* 65     Customer# �  6B    6f   �� *Naziv+ 5�   &   �� 5�   *   " ��60   .�5�   .   ��  � ��$
 Wrap=�6M   �� 5�   .    � ��$ Center=�6R   �� 5�   .    � ��$ Center=�6T   5�   +   5�   #   5�      5�      � 5�      $��1��6    5�      �� 5�      $
��0.2* �6,   �� 5�      $
��0.8* �6,   .+�5�      �� $ 
Horizontal=�6%   $��0��6>   .+�5�      ��   SelectDateAndTime#���  6(   $��90��6S   $��Center=�6a   $
��Wrap=�6|   (
  "System.Windows.Controls.DatePicker
  5�      $��10q�6)   
���   � 
  SelectedDate 66   �� *SelectedDate+$ TwoWay=�6i   )  #MaterialDesignThemes.Wpf.TimePicker  5�      $��10q�68      	Is24Hours$
 True��6E       SelectedTime  5�      �� *SelectedTime+$ TwoWay=�5�      � 5�      $��1��6   .+�5�      �� .+�5�   "   �� $	��Top=�5�        SelectedCustomer# �  5�      ��5�      �� *CustomerName+�� 5�   "   +  %MaterialDesignThemes.Wpf.ButtonAssist!   CornerRadius$! 25��6)     CommandButton#��[ 5�   '     font"   
FontFamily#" �  5�   %   $��
10,10,10,0q�5�   *   ��5�   %   �� *CreateCommand+{�5�   '   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�   &   �� $ 
Horizontal=�61   .+�5�   *     $ ReceiptTextPlusOutline=�6B   �� 5�   *     
CreateBill#���  64     CommandText#��[ 6X   5�   '   5�   #   �� 5�   "   $! 25��6)   #��[ 5�   (   #" �  5�   &   $��
10,10,10,0q�5�   +   ��5�   &   �� *PrintCommand+{�5�   (   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�   &   �� $ 
Horizontal=�61   .+�5�   *     $ PrinterOutline=�6B   �� 5�   *    	 Print#���  64   #��[ 6S   5�   '   5�   #   �� 5�   "   $! 25��6)   #��[ 5�   (   #" �  5�   &   $��
10,10,10,0q�5�   +   ��5�   &   �� *PreviewCommand+{�5�   (   �� *DataContext.ControlsEnabled+ �� *FindAncestor+
 Window.��5�   &   �� $ 
Horizontal=�61   .+�5�   *     $ 
PrinterEye=�6B   �� 5   *     Preview#���  64   #��[ 6U   5  '   5  #   5     5     5     5     5     5
     5     5     