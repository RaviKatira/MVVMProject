   M S B A M L   `   `   `  ���� M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPSMainOPSMain  !clr-namespace:OPSMainOPSMain      OPSMain.Inward   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:OPSMain     +	viewmodelclr-namespace:OPSMain     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -     � Title$  Inventory Inward��$	��700��$	��750�� � WindowStartupLocation$ CenterScreen=� � 	Resources    OPSMain.InwardViewModel   	ViewModel �� 
TargetType �� Property �� Value��%A   &	        '��        �� " ��.���  � ��$ Stretch=�.��� .+�� $��	0,-2,0,30q� � ShowGridLines .   � DataContext ��  �� Source# [  	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��400 ��� $��* ��� $��* ��� $��* �
 � ColumnDefinitions
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��1��$��0��$��	Bill Date��$
��left=�$
��Bold"�(  "System.Windows.Controls.DatePicker  -   $��dtDate��
���   �$��1��$��1��$	��120��$
��left=�$��32��$��Bottom=�   SelectedDate �� *InwardDetail.Dated+ �� StringFormat$ 	dd/MM/yyy���� $��1��$��2��$��Bar Code No��$
��left=�$
��Bold"��� -   $��txtBarCodeId��
���   �$��1��$��3��$	��138��$
��left=����� *InwardDetail.BarCodeId+ �� Mode$ TwoWay=�.��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ 	LostFocus��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *SearchBarCodeCommand+.���� $��1��$��4��$��Center=�$	��100��$��0,0,0,0q����� *NewInwardCommand+.���� .��_New Inward�� $��2��$��0��$��Product��$
��left=�$��0,0,0,0q�$
��Bold"�$	��Top=��� $��2��$��1�� �� DisplayMemberPath$ ProductwithPrice�� �� SelectedValuePath$ 	ProductId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��350��$��3������ *
Products+ �� SelectedItem �� *	Product+�� $��3��$��0��$��Quantity��$
��left=�$
��Bold"��� -   $��txtQty��$��3��$��1��$	��100��$
��left=�$��2,0,0,0q����� *InwardDetail.Quantity+$ TwoWay=� �� ValidatesOnDataErrors .  �� ValidatesOnExceptions .  �� NotifyOnValidationError . �� -   $��btnAdd��$��4��$��0��$��Center=�$	��100��$��	0,10,0,10q����� *
AddCommand+.���� .��_Add�� $��4��$��1��$��Center=�$	��100��$��	0,10,0,10q����� *SubmitCommand+.���� .��Sa_ve�� $��4��$��2��$��Center=�$	��100��$��	0,10,0,10q����� *
DelCommand+.���� .��	_Delete�� $��4��$��3��$��Center=�$	��100��$��	0,10,0,10q����� *ResetCommand+.���� .��_Reset�� -   $��lstview����. $��Visible=�$��5��$��0��$��6��$��2,0,25,0q�$��2������ *InwardDetails+$ TwoWay=� �� *InwardDetail+$ TwoWay=� �� View �� ��. .P��� $��IsDirty�� �� Width$ 0�� �� DisplayMemberBinding �� *	IsDirty+$ TwoWay=��� $��Barcode��$ 0�� �� *	BarCodeId+$ TwoWay=��� $��	ProductId��$ 70�� �� *	ProductId+$ TwoWay=��� $��InwardDetailId��$ 90�� �� *InwardDetailId+$ TwoWay=��� $��Dated��$ 70�� �� *Dated+$ TwoWay=��� $��Product��$	 250�� �� CellTemplate �� .R���  �� TextAlignment$
 Left=�$��Center=����� *ProductName+$ TwoWay=��� $��Quantity��$ 60�� �� .R��� $ Right=����� *
Quantity+$ TwoWay=��� $��8��$��0��$	��130��$��0,0,0,0q�
������$
��Bold"����� *SaveInwardCommand+.���� .��Save Bill Inward�� $��8��$��1��$��Supplier��$
��left=�$��0,0,0,0q�$
��Bold"�$	��Top=��� $��8��$��2��$ ProductwithPrice��$ 	ProductId��$
��Left=�$��0,0,0,0q�$	��Top=�$��70��$��1������ *
Products+ �� *	Product+�� $��8��$��3��$	��130��$��0,0,0,0q�
������$
��Bold"����� *SearchInwardCommand+.���� .��Search Inward