   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      $    KoleServis.MVVM.View.BillsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $
��2.5* �6   �� 5      $
��1.5* �6   .+�5   
   � $��0��6      	GridColor#���   6!   .+�5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6      SelectionMode$ Single=�5      ��5      �� *Bills+ �� SelectedItem 5      �� *SelectedBill+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.5* 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	IdRacun+6Q     5        Customer# �  6)   $ 1* 6j    6M   �� *
Customer+6j     5        Date# �  6)   $ 1* 6c    6I   �� *Datum+6c     5       	 Price# �  6)   $
 0.5* 6e    6J   �� *Cijena+6e   5      5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $
��0.1* �6    �� 5      $��1* �6    .+�5       � $��0��6   #���   6    .+�5!      ��   SelectedBill#���  6   $
��Left=�6B   $��Center=�6]   $��20(�6x   5"      � 5#      $��1��6   .+�5$        $ False��6   $ Single=�5&      ��5%      �� *Items+ 5'        5(      	   
IsReadOnly$
	 True��6-    	 Title# �  6@   $
 0.5* 6{    6a   �� *Naziv+
   ElementStyle
 5)      �� 5*   "    �� 
TargetType" ��6(   .�5+   &   ��  �� Property � �� �� Value$
 Wrap=�6E   5,   #   5.        5/      $
	 True��6-   # �  6A   $
 0.3* 6�    6b   �� *CijenaKomad+6�     50      $
	 True��6-     Quantity# �  6?   $
 0.3* 6�    6d   �� *
Kolicina+6�   52      53      54      55      56      