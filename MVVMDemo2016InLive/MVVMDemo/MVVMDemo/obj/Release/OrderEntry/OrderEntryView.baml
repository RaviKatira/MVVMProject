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
��left=�{�.  ���� *Order.Price+$ TwoWay=��� $��4��$��2��' �� ContentStringFormat$' {0:0.##}��$
��left=����� *OrderSummary.TotalProfit+$ TwoWay=��� -   $��btnAdd��$��5��$��0��$��Center=�$	��100��$��0,10,0,0q����� *
AddCommand+.���� .��_Add�� $��5��$��1��$��Center=�$	��100��$��0,10,0,0q����� *SubmitCommand+.���� .��Sa_ve�� $��5��$��2��$��Center=�$	��100��$��0,10,0,0q����� *
DelCommand+.���� .��	_Delete�� $��5��$��3��$��Center=�$	��100��$��0,10,0,0q����� *ResetCommand+.���� .��_Reset� $��1��$��4��$��2��  .  $��9��$	��220��$��0,0,0,0q� �� ��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Bill No:��$
��Left=�$
��Bold"��� $��0��$��1��( �� TextAlignment$( Right=�$��20(�$
��Bold"�$	��Top=�{�.  ) �� 
IsReadOnly) . ���� *OrderSummary.BillNo+$ TwoWay=�* �� UpdateSourceTrigger$* PropertyChanged=��� $��1��$��0��$��Bill Amount:��$
��Left=�$
��Bold"��� $��1��$��1��$( Right=�$��20(�$
��Bold"�$	��Top=�{�. 
���   �) . 
������+   	IsTabStop+ .  ���� *OrderSummary.BillAmount+$ TwoWay=��� $��2��$��0��$��
Consume LP��$
��Left=�$
��Bold"��� $��2��$��1��$( Right=�$��20(�$
��Bold"�$	��Top=�
���   �
����ح�+ .  ���� *$"OrderSummary.ConsumedLoyaltyPoints+$ TwoWay=��� $��3��$��0��$��Net Bill��$
��Left=�$
��Bold"��� $��3��$��1��$( Right=�$��20(�$
��Bold"�$	��Top=�
���   �
������+ .  ���� *OrderSummary.NetBillAmt+$ TwoWay=��� $��4��$��0��$��Discount��$
��Left=�$
��Bold"�$	��Top=��� -   $��txtDiscount��$��4��$��1��$( Right=�$��20(�$
��Bold"�$	��Top=�
��� ������� *OrderSummary.Discount+$ TwoWay=��� $��5��$��0��$��Final Total��$
��Left=�$
��Bold"��� $��5��$��1��$( Right=�$��20(�$
��Bold"�$	��Top=�
������+ .  ���� *OrderSummary.FinalTotal+$ TwoWay=��� $��6��$��0��$��Cash Tendered��$
��Left=�$
��Bold"��� -	   $��txtCashTendered��$��6��$��1��$( Right=�$��20(�$
��Bold"�$	��Top=�
���   �
����������� *OrderSummary.CashTendered+$ TwoWay=��� $��7��$��0��$��Balance��$
��Left=�$
��Bold"�$	��Top=��� $��7��$��1��$��30��$( Right=�$��20(�$
��Bold"�$	��Top=�{�.  ) . ���� *OrderSummary.Balance+$ TwoWay=��� $��8��$��0��$��Payment Mode��$
��left=�$
��Bold"�$��0,0,0,0q��� $��8��$��1��, �� DisplayMemberPath$
, Mode��$ PaymentModeId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��110������ *PaymentModes+ �� *SelectedPaymentMode+�� $��9��$��1��$��Total Items:��$
��left=�$
��Bold"��� $��9��$��2��$	��100��$��30��$	��Top=�$( Right=�$
��Bold"�{�.  ) . $��0,0,0,0q����� *OrderSummary.TotalQty+$ TwoWay=��� $��9��$��3��$��Bill Return��$	��200��$��0,0,0,0q�
������$
��Bold"�- d� 	IsChecked- �� *OrderSummary.IsBillReturn+�� $��9��$��4��$	��130��$��0,0,0,0q�
������$
��Bold"����� *SaveBillCommand+.���� .��Save Bill and _Print�� $��9��$��6��$	��130��$��0,0,0,0q�
������$
��Bold"����� *SaveBillOnlyCommand+.���� .��
_Save Bill� $��6��$��0��$��4��$	��490��$	��300��$��0,0,0,0q� ��  �� $��* �.+��� -
   $��lstview����. $��Visible=�$��6��$��0��$	��490��$	��300��$��0,0,0,0q����� *Orders+$ TwoWay=� �� *Order+. �� View. �� ��. .P��� $��IsDirty��/ �� Width$/ 0��0 �� DisplayMemberBinding0 �� *	IsDirty+$ TwoWay=��� $��Barcode��$/ 0��0 �� *	BarCodeId+$ TwoWay=��� $��	ProductId��$/ 0��0 �� *	ProductId+$ TwoWay=��� $��OrderDetailId��$/ 0��0 �� *OrderDetailId+$ TwoWay=��� $��CP��$/ 0��0 �� *	CostPrice+$ TwoWay=��� $	��Pft��$/ 0��0 �� *Profit+$ TwoWay=��� $��Product��$	/ 250��1 �� CellTemplate1 �� .R��� $
! Left=�$��Center=����� *ProductName+$ TwoWay=��� $��Quantity��$/ 60��1 �� .R��� $! Right=����� *
Quantity+$ TwoWay=��� $��Price��$/ 60��1 �� .R��� $! Right=����� *Price+$ TwoWay=��� $��Total��$/ 60��1 �� .R��� $! Right=����� *Total+$ TwoWay=��� $��10��$��0��$��Cust. BarCode��$
��left=�$
��Bold"��� $��10��$��1��$	��100��$
��left=����� *Customer.Customer_barcode+$ TwoWay=�.��   $ 	LostFocus��.    �� * SearchCustomerByBarCodeCommand+.���� $��10��$��2��$��Name:��$
��left=�$
��Bold"��� $��10��$��3��$��3��$
��left=�
���   �$	��300��$
��Bold"����� *Customer.Name+$ TwoWay=��� $��11��$��0��$��Phone:��$
��left=�$
��Bold"��� $��11��$��1��$	��100��$
��left=����� *Customer.Phone+$ TwoWay=��� $��11��$��2��$��Cust Id:��$
��left=�$
��Bold"��� $��11��$��3��$
��left=�$	��100������ *Customer.CustID+$ TwoWay=��� $��12��$��0��$��Address:��$
��left=�$
��Bold"��� $��12��$��1��$��4��$
��left=�$	��500������ *Customer.Address+$ TwoWay=��� $��12��$��5��$��4��$��2q�$
��left=�$( Right=�$	��100�����	#FFDAD88F���� *%#OrderSummary.AvailableLoyaltyPoints+$ TwoWay=��� $��13��$��0��$��2��$
��Left=�$ ��Search Customer by Cust ID��$	��200��$��0,10,0,0q�$��Bottom=����� *SearchCustomerByCustIdCommand+�� $��13��$��2��$��2��$
��Left=�$��Search Customer by Phone��$	��200��$��0,10,0,0q�$��Bottom=����� *SearchCustomerByPhoneCommand+