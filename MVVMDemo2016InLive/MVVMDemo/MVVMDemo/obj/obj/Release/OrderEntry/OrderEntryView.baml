   M S B A M L   `   `   `  ���� M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MVVMDemoMVVMDemo  9!clr-namespace:OPSSystem.ConverterOPSSystem.Converter  5clr-namespace:OPSMain.BehaviourOPSMain.Behaviour      MVVMDemo.OrderEntryView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,	viewmodelclr-namespace:MVVMDemo     7	converter!clr-namespace:OPSSystem.Converter     5	behaviourclr-namespace:OPSMain.Behaviour     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -     � Title$  Order Entry System��$	��710��$��751.5�� � WindowStartupLocation$ CenterScreen=� � 	Resources    MVVMDemo.ViewModel   	ViewModel1   +OPSSystem.Converter.DatetimeToDateConverter  MyConverter �� 
TargetType �� Property �� Value  TextErrorStyle �� Triggers P� Property P� Value	 �� Self
 �� RelativeSource �� Path��%�   &	        &	      '�� 
     &	 2         �� " ��.���  � ��$ Stretch=��� " �� P�  �@=�HasError . . ���  � ��
 �  ����  �@�ToolTip �� #
 Z	 $) #(Validation.Errors)[0].ErrorContent�.��� $��0,0,0,18q�.+�� $��	0,-2,0,30q� � DataContext ��  �� Source# [   � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��300 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��$��0��$��Bar Code No��$
��left=�$
��Bold"��� -   $��
txtBarCode��
���   �$��1��$��1��$	��138��$
��left=�-  'System.Windows.Input.KeyboardNavigation   TabIndex$ 0��&    OPSMain.Behaviour.FocusExtension   	IsFocused �� *IsBarCodeFocused+ �� Mode$ TwoWay=����� *Order.BarCodeId+$ TwoWay=�.��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ 	LostFocus��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *SearchBarCodeCommand+.���� -   $��btnSearchandAdd��$��1��$��2��$
��Left=�$	��100�� �� 	IsDefault . $��0,10,0,0q����� *SearchBarCodeCommand+.���� .��	Aut_o Add�� -   $��
btnNewBill��$��1��$��3��$
��Left=�$	��100�� . $��0,10,0,0q����� *NewBillCommand+.���� .��	_New Bill�� $��2��$��0��$��Product��$
��left=�$��0,0,0,0q�$
��Bold"�$	��Top=��� -   $��cmbProductName�� �� IsTextSearchEnabled .  w� TextPath$ ProductName��$��2��$��1�� �� SelectedValuePath$ 	ProductId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��350��$��3������ *
Products+ �� SelectedItem �� *	Product+���� .R���  �� Orientation$ 
Horizontal=�.+��� ���� *ProductName+�� $��     -----------  ���� $
��Bold"�
��� � ����� *ProductPrice+�� $��     ---------  ���� $��Black"�
����  ����� *TotalAvailQty+���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� ��  �� 
TargetType" ��.R��� $��templateBorder�� �� Padding$ 2q� J� SnapsToDevicePixels . ._��� ���   � ShowGridLines  .  �� �� �� .+��� $��2q�$��0��$	��250������ *ProductName+�� $��2q�$��1��$��40��
���   �$
��Bold"�! �� TextAlignment$! Right=����� *ProductPrice+�� $��2q�$��2��$��40��
����  �$! Right=����� *TotalAvailQty+" �� Triggers" P�  �@��IsHighlighted . . ��� # Z� � ���� # �� 
TargetName$# templateBorder��# Z	� � ���� $��3��$��0��$��Quantity��$
��left=�$
��Bold"��� -   $��txtQty��$��3��$��1��$	��100��$
��left=�$��2,0,0,0q����� *Order.Quantity+$ TwoWay=�$ �� ValidatesOnDataErrors$ . % �� ValidatesOnExceptions% . & �� NotifyOnValidationError& . �� $��4��$��0��$��Price��$
��left=�$
��Bold"��� $��4��$��1��$	��100��$
��left=�{�.  ���� *Order.Price+$ TwoWay=��� -   $��btnAdd��$��5��$��0��$��Center=�$	��100��$��0,10,0,0q����� *
AddCommand+.���� .��_Add�� $��5��$��1��$��Center=�$	��100��$��0,10,0,0q����� *SubmitCommand+.���� .��Sa_ve�� $��5��$��2��$��Center=�$	��100��$��0,10,0,0q����� *
DelCommand+.���� .��	_Delete�� $��5��$��3��$��Center=�$	��100��$��0,10,0,0q����� *ResetCommand+.���� .��_Reset�� $��1��$��4��$��Bill No:��$
��Left=�$
��Bold"��� $��1��$��5��$	��100��' �� TextAlignment$' Right=�$��20(�$
��Bold"�{�.  ( �� 
IsReadOnly( . ���� *OrderSummary.BillNo+$ TwoWay=�) �� UpdateSourceTrigger$) PropertyChanged=��� $��2��$��4��$��Bill Amount:��$
��Left=�$
��Bold"��� $��2��$��5��$	��100��$' Right=�$��20(�$
��Bold"�{�. 
���   �( . 
������*   	IsTabStop* .  ���� *OrderSummary.BillAmount+$ TwoWay=��� $��3��$��4��$��
Consume LP��$
��Left=�$
��Bold"��� $��3��$��5��$	��100��$' Right=�$��20(�$
��Bold"�$��33��$��	11,0,12,0q�$��Bottom=�
���   �
����ح�* .  ���� *$"OrderSummary.ConsumedLoyaltyPoints+$ TwoWay=��� $��4��$��4��$��Net Bill��$
��Left=�$
��Bold"��� $��4��$��5��$	��100��$' Right=�$��20(�$
��Bold"�$��33��$��	11,0,12,0q�$��Bottom=�
���   �
������* .  ���� *OrderSummary.NetBillAmt+$ TwoWay=��� $��5��$��4��$��Cash Tendered��$
��Left=�$
��Bold"��� -   $��txtCashTendered��$��5��$��5��$	��100��$' Right=�$��20(�$
��Bold"�$��33��$��	11,0,12,0q�$��Bottom=�
���   �
����������� *OrderSummary.CashTendered+$ TwoWay=��� $��6��$��4��$��Balance��$
��Left=�$
��Bold"�$	��Top=��� $��6��$��5��$	��100��$��30��$	��Top=�$' Right=�$��20(�$
��Bold"�{�.  ( . $��11.667,0,11.333,168q����� *OrderSummary.Balance+$ TwoWay=��� $��7��$��1��$��Total Items:��$
��left=�$
��Bold"��� $��7��$��2��$	��100��$��30��$	��Top=�$' Right=�$
��Bold"�{�.  ( . $��0,0,0,0q����� *OrderSummary.TotalQty+$ TwoWay=��� $��7��$��3��$��Bill Return��$	��200��$��0,0,0,0q�
������$
��Bold"�+ d� 	IsChecked+ �� *OrderSummary.IsBillReturn+�� $��7��$��4��$	��130��$��0,0,0,0q�
������$
��Bold"����� *SaveBillCommand+.���� .��Save Bill and _Print�� $��7��$��6��$	��130��$��0,0,0,0q�
������$
��Bold"����� *SaveBillOnlyCommand+.���� .��
_Save Bill�� -	   $��lstview����. $��Visible=�$��6��$��0��$��4��$	��490��$	��300��$��0,0,0,0q����� *Orders+$ TwoWay=� �� *Order+, �� View, �� ��. .P��� $��IsDirty��- �� Width$- 0��. �� DisplayMemberBinding. �� *	IsDirty+$ TwoWay=��� $��Barcode��$- 0��. �� *	BarCodeId+$ TwoWay=��� $��	ProductId��$- 0��. �� *	ProductId+$ TwoWay=��� $��OrderDetailId��$- 0��. �� *OrderDetailId+$ TwoWay=��� $��Product��$	- 250��/ �� CellTemplate/ �� .R��� $
! Left=�$��Center=����� *ProductName+$ TwoWay=��� $��Quantity��$- 60��/ �� .R��� $! Right=����� *
Quantity+$ TwoWay=��� $��Price��$- 60��/ �� .R��� $! Right=����� *Price+$ TwoWay=��� $��Total��$- 60��/ �� .R��� $! Right=����� *Total+$ TwoWay=��� $��8��$��0��$��Cust. BarCode��$
��left=�$
��Bold"��� $��8��$��1��$	��100��$
��left=����� *Customer.Customer_barcode+$ TwoWay=�.��   $ 	LostFocus��.    �� * SearchCustomerByBarCodeCommand+.���� $��8��$��2��$��Name:��$
��left=�$
��Bold"��� $��8��$��3��$��3��$
��left=�
���   �$	��300��$
��Bold"����� *Customer.Name+$ TwoWay=��� $��9��$��0��$��Phone:��$
��left=�$
��Bold"��� $��9��$��1��$	��100��$
��left=����� *Customer.Phone+$ TwoWay=��� $��9��$��2��$��Cust Id:��$
��left=�$
��Bold"��� $��9��$��3��$
��left=�$	��100������ *Customer.CustID+$ TwoWay=��� $��10��$��0��$��Address:��$
��left=�$
��Bold"��� $��10��$��1��$��4��$
��left=�$	��500������ *Customer.Address+$ TwoWay=��� $��10��$��5��$��4��$��2q�$
��left=�$' Right=�$	��100�����	#FFDAD88F���� *%#OrderSummary.AvailableLoyaltyPoints+$ TwoWay=��� $��11��$��0��$��2��$
��Left=�$ ��Search Customer by Cust ID��$	��200��$��0,10,0,0q�$��Bottom=����� *SearchCustomerByCustIdCommand+�� $��11��$��2��$��2��$
��Left=�$��Search Customer by Phone��$	��200��$��0,10,0,0q�$��Bottom=����� *SearchCustomerByPhoneCommand+