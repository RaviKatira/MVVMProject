   M S B A M L   `   `   `  ���� M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OPSMain.SupplierEntryOPSMain.SupplierEntry  =#clr-namespace:OPSMain.SupplierEntryOPSMain.SupplierEntry  *    $OPSMain.SupplierEntry.SupplierMaster   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:OPSMain.SupplierEntry     9	viewmodel#clr-namespace:OPSMain.SupplierEntry     -     � Title$  SupplierMaster��$	��700��$	��981�� � WindowStartupLocation$ CenterScreen=� � 	Resources -   'OPSMain.SupplierEntry.SupplierViewModel   	ViewModel �� 
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
��left=�$��0,0,0,0q����� *SelectedSupplier.SupplierName+ �� Mode$ TwoWay=��� $��0��$��4��$��Active��$
��left=�$
��Bold"��� $��0��$��5�� �� DisplayMemberPath$ ActiveCategory�� �� SelectedValuePath$ ActiveId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��100��$��3������ *ActiveTypes+ �� SelectedItem �� *SelectedActiveType+$ TwoWay=��� -   $��btnAdd��$��2��$��0��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *
AddCommand+.���� .��_Add Supplier�� $��2��$��1��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *SubmitCommand+.���� .��Sa_ve Supplier�� $��2��$��2��$��Center=�$	��100��$��	1,10,5,10q�
������$
��Bold"����� *ResetCommand+.���� .��_Reset�� -   $��lstview����. $��Visible=�$��3��$��0��$��8��$��2,0,0,0q�$��2������ *	Suppliers+ �� *SelectedSupplier+$ TwoWay=� �� View �� ��. .P��� $��Supplier ID�� �� Width$ 70�� �� DisplayMemberBinding �� *
SupplierId+$ TwoWay=��� $
��Name��$	 150�� �� *SupplierName+$ TwoWay=��� $��IsActive��$ 70�� �� *
IsActive+$ TwoWay=��� $��	CreatedOn��$ 70�� �� *	CreatedOn+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm��