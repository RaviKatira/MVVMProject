   M S B A M L   `   `   `  ����M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OPSMain.CustomerEntryOPSMain.CustomerEntry  5   	   =#clr-namespace:OPSMain.CustomerEntryOPSMain.CustomerEntry  5   	   *    $OPSMain.CustomerEntry.CustomerMaster   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:OPSMain.CustomerEntry     5   	   9	viewmodel#clr-namespace:OPSMain.CustomerEntry     5   	   -   5          � Title$  Customer Master��5	   	   $	��700��6!   $	��981��6.    � WindowStartupLocation$ CenterScreen=�5
   	    � 	Resources 5      -   'OPSMain.CustomerEntry.CustomerViewModel   	ViewModel �� 
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
��left=�5,      $��0,0,0,0q�6e   ��61   �� *SelectedCustomer.Name+ �� Mode$ TwoWay=�6e   �� 5.      $��0��6   $��4��6!   $��Bar Code��61   $
��left=�6D   $
��Bold"�5/      $��0,0,0,0q�6#   $��1��64   �� 50      $��0��6   $��5��6#   $	��150��63   $��2��6@   $
��left=�51      $��0,0,0,0q�6q   ��61   �� *#!SelectedCustomer.Customer_barcode+$ TwoWay=�6q   �� 54      $��1��6   $��0��6!   $��Address��62   $
��left=�6D   $
��Bold"�55      $��0,0,0,0q�6#   $��1��64   �� 56      $��1��6   $��1��6#   $	��300��63   $��3��6@   $
��left=�57      $��0,0,0,0q�6h   ��61   �� *SelectedCustomer.Address+$ TwoWay=�6h   �� 59      $��1��6   $��4��6!   $��Phone��61   $
��left=�6A   $
��Bold"�5:      $��0,0,0,0q�6#   $��1��64   �� 5;      $��1��6   $��5��6#   $	��150��63   $��2��6?   $
��left=�5<      $��0,0,0,0q�6f   ��61   �� *SelectedCustomer.Phone+$ TwoWay=�6f   �� 5=      -   5        $��btnAdd��5=      $��2��6#   $��0��60   $��Center=�6_   $	��100��6|   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��6@   �� *
AddCommand+.��5>      �� .��6   _Add Customer5@      5A      �� 5B      $��2��6   $��1��6"   $��Center=�6U   $	��100��6r   $��	0,10,0,10q�6~   
������$
��Bold"�6�   ��63   �� *SubmitCommand+.��5C      �� .��6   Sa_ve Customer5E      5F      �� 5H      $��2��6   $��2��6"   $��Center=�6S   $	��100��6p   $��	1,10,5,10q�6|   
������$
��Bold"�6�   ��62   �� *ResetCommand+.��5I      �� .��6   _Reset5K      5L      �� 5N      $��2��6   $��5��6#   $��2��64   $	��150��6H   $
��left=�6T   
�������$��5,0,0,0q�6�   $��30��6�   ��6o   �� *CustomerSearchCriteria+$ TwoWay=�6�   �� 5O      $��2��6   $��6��6"   $��1��62   $��Center=�6h   $	��100��6�   $��0,0,0,0q�6�   
����� �$
��Bold"�6�   $��30��6�   ��6F   �� *SearchCommand+.��5P      �� .��6   _Search Name5R      5S      �� 5W      -   5        $��lstview��5Y      ��. $��Visible=�5W   >   $��3��5X      $��0��6&   $��8��66   $��2,0,0,0q�5Z   P   $��2��6a   ��5Y   (   �� *	Customers+ �� SelectedItem 5Z      �� *SelectedCustomer+$ TwoWay=� �� View 5\      �� 5]      ��. .P�5_      �� $��Cust ID��6)    �� Width$ 70��6n    �� DisplayMemberBinding 6:   �� *CustID+$ TwoWay=�6n   �� 5`      $
��Name��6)   $	 150��6i    67   �� *Name+$ TwoWay=�6i   �� 5a      $��Address��6)   $	 250��6o    6:   �� *	Address+$ TwoWay=�6o   �� 5b      $��Barcode��6)   $ 70��6x    6:   �� *Customer_barcode+$ TwoWay=�6x   �� 5c      $��Phone��6)   $ 70��6k    68   �� *Phone+$ TwoWay=�6k   �� 5d      $��Total Points��6)   $ 70��6    6?   �� *TotalRewardsPoints+$ TwoWay=�6   �� 5e      $��Consumed Points��6)   $	 100��6�    6B   �� *ConsumedRewardsPoints+$ TwoWay=�6�   �� 5h      $��Available Points��6)   $ 70��6D    �� CellTemplate 5i      �� 5j   "   .R�5k   &   �� 
���/���
���   ���60   �� *LeftRewardsPoints+$ TwoWay=�6x   5l   #   5n      �� 5p      $��	CreatedOn��6)   $ 70��6�    6<   �� *	CreatedOn+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm��6�   5�      5�      5�      5�      5�      