   M S B A M L   `   `   `  ����M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OPSMain.SupplierEntryOPSMain.SupplierEntry  5   	   =#clr-namespace:OPSMain.SupplierEntryOPSMain.SupplierEntry  5	   	   *    $OPSMain.SupplierEntry.SupplierMaster   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OPSMain.SupplierEntry     5   	   9	viewmodel#clr-namespace:OPSMain.SupplierEntry     5	   	   -   5          � Title$  SupplierMaster��5   	   $	��700��6    $	��981��6-    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5      -   'OPSMain.SupplierEntry.SupplierViewModel   	ViewModel �� 
TargetType �� Property �� Value��%t   &	        '��        5   
   6&   �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�6;   5      5      .��5      � .+�5   
   � $��0,0,0,0q�6J    � ShowGridLines .   � DataContext 6   ��  �� Source# [  	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $	��400 �6    �� 5      $	��100 �6    �� 5      $��* �6    �� 5      $
��Auto �6    
 � ColumnDefinitions
 5      �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   �� 5#      $��* �6#   �� 5$      $��* �6#   �� 5%      $��* �6#   �� 5&      $��* �6#   .+�5)      �� $��0��6   $��0��6!   $
��Name��61   $
��left=�6@   $
��Bold"�5*      $��0,0,0,0q�6#   $��1��64   �� 5+      $��0��6   $��1��6#   $��3��63   $	��250��6G   $
��left=�5,      $��0,0,0,0q�6m   ��61   �� *SelectedSupplier.SupplierName+ �� Mode$ TwoWay=�6m   �� 5.      $��0��6   $��4��6!   $��Active��61   $
��left=�6B   $
��Bold"�6]   �� 5/      $��0��6   $��5��6$    �� DisplayMemberPath$ ActiveCategory��51       �� SelectedValuePath$ ActiveId��52      $
��Left=�54      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��50      �� *ActiveTypes+ �� SelectedItem 53      �� *SelectedActiveType+$ TwoWay=�54   d   �� 55      -   5        $��btnAdd��55      $��2��6#   $��0��60   $��Center=�6_   $	��100��6|   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��6@   �� *
AddCommand+.��56      �� .��6   _Add Supplier58      59      �� 5:      $��2��6   $��1��6"   $��Center=�6U   $	��100��6r   $��	0,10,0,10q�6~   
������$
��Bold"�6�   ��63   �� *SubmitCommand+.��5;      �� .��6   Sa_ve Supplier5=      5>      �� 5@      $��2��6   $��2��6"   $��Center=�6S   $	��100��6p   $��	1,10,5,10q�6|   
������$
��Bold"�6�   ��62   �� *ResetCommand+.��5A      �� .��6   _Reset5C      5D      �� 5H      -   5        $��lstview��5J      ��. $��Visible=�5H   >   $��3��5I      $��0��6&   $��8��66   $��2,0,0,0q�5K   P   $��2��6a   ��5J   (   �� *	Suppliers+ 5K      �� *SelectedSupplier+$ TwoWay=� �� View 5M      �� 5N      ��. .P�5O      �� $��Supplier ID��6)    �� Width$ 70��6v    �� DisplayMemberBinding 6>   �� *
SupplierId+$ TwoWay=�6v   �� 5P      $
��Name��6)   $	 150��6q    67   �� *SupplierName+$ TwoWay=�6q   �� 5Q      $��IsActive��6)   $ 70��6q    6;   �� *
IsActive+$ TwoWay=�6q   �� 5R      $��	CreatedOn��6)   $ 70��6�    6<   �� *	CreatedOn+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm��6�   5S      5U      5V      5W      5X      