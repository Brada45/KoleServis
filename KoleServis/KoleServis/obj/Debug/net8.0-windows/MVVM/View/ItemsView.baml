   M S B A M L   `   `   `  ����E  AKoleServis, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:KoleServis.MVVM.ViewKoleServis.MVVM.View  5      Q-clr-namespace:KoleServis.MVVM.View.ComponentsKoleServis.MVVM.View.Components  5      $    KoleServis.MVVM.View.ItemsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:KoleServis.MVVM.View     5      C	component-clr-namespace:KoleServis.MVVM.View.Components     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      
�������.��5      �   � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      �� $
��Auto=�6   .��5      �� ��6   �� *
Dijelovi+ �� SelectedItem 6;   �� *SelectedItem+��5      �� 5      .R�5      �  � Orientation$ 
Horizontal=�6(   5      ��5      �� 5      .R�5      3   -KoleServis.MVVM.View.Components.ItemComponent  $��5q�6N    � DataContext 66   �� 6N   5      5      5      5      � 5    
   $��1��6    � RowDefinitions 5!      �� 5"      $
��0.7* �6    �� 5#      $
��0.1* �6    �� 5$      $
��0.3* �6    .+�5&      �� $��0��6   .+�5(      ��    	TitleName)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �   5)         FloatingOffset$ 0,-20&�5*      $��	0 0 0 1.5q�5+      $��Center=�5,      $��100,10,60,10q�5-      ��5(      �� *Title+5-      �� 5/       	 Price# �  50      $ 0,-20&�51      $��	0 0 0 1.5q�52      $��Center=�53      $��100,10,60,10q�54      ��5/      �� *Price+54      �� 55        Quantity# �  56      $ 0,-20&�57      $��	0 0 0 1.5q�58      $��Center=�59      $��100,10,60,10q�5:      ��55      �� *
Quantity+5:      � 5;        5<      �� 5=      $
��0.5* �6+   �� 5>      $
��0.5* �6+   .+�5@      ��   Category#���  6    $��100,10,0,10q�6C   �� 5A      $��Stretch=�6   $��Stretch=�6;   $��1��6Y    �� Text# �  6i   $	��140��6�   ��6�   �� *
Categories+ 6�   �� *SelectedCategory+��5B      �� 5C      .R�5D       $� 5E      5G      5H      � 5I        5J      �� 5K      $
��0.5* �6+   �� 5L      $
��0.5* �6+   .+�5N      �� $��1��5O      $��Uniform=�5P      $	��200��5Q      $	��150��5R      $��Center=�5S      $��Center=�5T      $��5q�5U      ��5N      �� *SelectedImage+5U      �� 5V      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��6   $��0��6K     CommandButton#��[ 5Y      	 � ToolTip$7	 1MaterialDesignRaisedDarkButton with Round Corners��5Z      $��	50,0,50,0q�5[      ��5W      �� *UpdateImageCommand+{�5X      �� *DataContext.ControlsEnabled+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType
 Window.��5]      ��   UpdateImage#���  6$   5^      5_      5`      �� 5b      $��3��6   .+�5c      � .+�5d      �� $ 25��6   #��[ 5g   
   $7	 1MaterialDesignRaisedDarkButton with Round Corners��5i   
   $��100,0,100,0q�5j      ��5e      �� *
AddCommand+{�5f   
   �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5k      ��   Add#���  6$   5l      5m      � 5n      .+�5o      �� $ 25��6   #��[ 5r      $7	 1MaterialDesignRaisedDarkButton with Round Corners��5s      $��100,0,100,0q�5u      ��5p      �� *UpdateCommand+{�5q      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5v      ��  
 Update#���  6$   5w      5x      � 5y      .+�5z      �� $ 25��6   #��[ 5}      $7	 1MaterialDesignRaisedDarkButton with Round Corners��5~      $��100,0,100,0q�5      ��5{      �� *DeleteCommand+{�5|      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5�      ��  
 Delete#���  6$   5�      5�      � 5�      .+�5�      �� $ 25��6   #��[ 5�      $7	 1MaterialDesignRaisedDarkButton with Round Corners��5�      $��100,0,100,0q�5�      ��5�      �� *ClearCommand+{�5�      �� *DataContext.ControlsEnabled+
 �� *FindAncestor+
 Window.��5�      ��  		 Clear#��� 	 6$   5�      5�      5�      5�      5�      5�      