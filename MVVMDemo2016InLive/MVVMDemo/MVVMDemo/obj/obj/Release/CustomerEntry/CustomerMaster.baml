   M S B A M L   `   `   `  ���� M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OPSMain.CustomerEntryOPSMain.CustomerEntry  =#clr-namespace:OPSMain.CustomerEntryOPSMain.CustomerEntry  *    $OPSMain.CustomerEntry.CustomerMaster   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:OPSMain.CustomerEntry     9	viewmodel#clr-namespace:OPSMain.CustomerEntry     -     � Title$  Customer Master��$	��700��$	��981�� � WindowStartupLocation$ CenterScreen=� � 	Resources -   'OPSMain.CustomerEntry.CustomerViewModel   	ViewModel �� 
TargetType �� Property �� Value��%A   &	        '��        �� " ��.���  � ��$ Stretch=�.��� .+�� $��0,0,0,0q� � ShowGridLines .   � DataContext ��  �� Source# [  	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��400 ��� $	��100 ��� $��* ��� $
��Auto �
 � ColumnDefinitions
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$
��Name��$
��left=�$
��Bold"�$��0,0,0,0q�$��1���� $��0��$��1��$��3��$	��250��$
��left=�$��0,0,0,0q����� *SelectedCustomer.Name+ �� Mode$ TwoWay=��� $��0��$��4��$��Bar Code��$
��left=�$
��Bold"�$��0,0,0,0q�$��1���� $��0��$��5��$	��150��$��2��$
��left=�$��0,0,0,0q����� *#!SelectedCustomer.Customer_barcode+$ TwoWay=��� $��1��$��0��$��Address��$
��left=�$
��Bold"�$��0,0,0,0q�$��1���� $��1��$��1��$	��300��$��3��$
��left=�$��0,0,0,0q����� *SelectedCustomer.Address+$ TwoWay=��� $��1��$��4��$��Phone��$
��left=�$
��Bold"�$��0,0,0,0q�$��1���� $��1��$��5��$	��150��$��2��$
��left=�$��0,0,0,0q����� *SelectedCustomer.Phone+$ TwoWay=��� -   $��btnAdd��$��2��$��0��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *
AddCommand+.���� .��_Add Customer�� $��2��$��1��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *SubmitCommand+.���� .��Sa_ve Customer�� $��2��$��2��$��Center=�$	��100��$��	1,10,5,10q�
������$
��Bold"����� *ResetCommand+.���� .��_Reset�� $��2��$��5��$��2��$	��150��$
��left=�
�������$��5,0,0,0q�$��30������ *CustomerSearchCriteria+$ TwoWay=��� $��2��$��6��$��1��$��Center=�$	��100��$��0,0,0,0q�
����� �$
��Bold"�$��30������ *SearchCommand+.���� .��_Search Name�� -   $��lstview����. $��Visible=�$��3��$��0��$��8��$��2,0,0,0q�$��2������ *	Customers+ �� SelectedItem �� *SelectedCustomer+$ TwoWay=� �� View �� ��. .P��� $��Cust ID�� �� Width$ 70�� �� DisplayMemberBinding �� *CustID+$ TwoWay=��� $
��Name��$	 150�� �� *Name+$ TwoWay=��� $��Address��$	 250�� �� *	Address+$ TwoWay=��� $��Barcode��$ 70�� �� *Customer_barcode+$ TwoWay=��� $��Phone��$ 70�� �� *Phone+$ TwoWay=��� $��Total Points��$ 70�� �� *TotalRewardsPoints+$ TwoWay=��� $��Consumed Points��$	 100�� �� *ConsumedRewardsPoints+$ TwoWay=��� $��Available Points��$ 70�� �� CellTemplate �� .R��� 
���/���
���   ����� *LeftRewardsPoints+$ TwoWay=��� $��	CreatedOn��$ 70�� �� *	CreatedOn+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm��