   M S B A M L   `   `   `  ���� M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OPSMain.ProductEntryOPSMain.ProductEntry  ;"clr-namespace:OPSMain.ProductEntryOPSMain.ProductEntry  (    "OPSMain.ProductEntry.ProductMaster   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:OPSMain.ProductEntry     8	viewmodel"clr-namespace:OPSMain.ProductEntry     c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  -     � Title$  Product Master��$	��700��$
��1000�� � WindowStartupLocation$ CenterScreen=� � 	Resources +   %OPSMain.ProductEntry.ProductViewModel   	ViewModel �� 
TargetType �� Property �� Value��%A   &	        '��        �� " ��.���  � ��$ Stretch=�.��� .+�� $��	0,-2,0,30q� � ShowGridLines .   � DataContext ��  �� Source# [  	 � RowDefinitions	 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $	��400 ��� $��* ��� $��* ��� $��* �
 � ColumnDefinitions
 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��1��$��Supplier��$
��left=�$
��Bold"�$��0,0,0,0q��� $��1��$��1�� �� DisplayMemberPath$ SupplierName�� �� SelectedValuePath$ 
SupplierId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��200��$��2������ *	Suppliers+ �� SelectedItem �� *SelectedSupplier+�� $��1��$��3��$��Bar Code No��$
��left=�$
��Bold"�$��20,0,0,0q��� -   $��txtBarCodeId��$��1��$��4��$	��138��$
��left=�$��2��$��20,0,0,0q����� *SelectedProduct.BarCodeId+ �� Mode$ TwoWay=�.��.  (System.Windows.Interactivity.Interaction   Triggers /  )System.Windows.Interactivity.EventTrigger     	EventName$ 	LostFocus��.  (System.Windows.Interactivity.TriggerBase   Actions. 6  0System.Windows.Interactivity.InvokeCommandAction     Command �� *SearchBarCodeCommand+.���� $��2��$��0��$��Product��$
��left=�$��0,0,0,0q�$
��Bold"�$	��Top=��� $��2��$��1��$��4��$	��500��$
��left=�$��0,0,0,0q����� *SelectedProduct.ProductName+$ TwoWay=��� $��2��$��6��$��Offer��$
��left=�$
��Bold"��� $��2��$��7��$ OfferOption��$ OfferId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��100��$��3������ *ProductOffer+ �� *SelectedProductOffer+�� $��3��$��0��$��Selling Price��$
��left=�$
��Bold"��� $��3��$��1��$	��100��$
��left=�$��2,0,0,0q����� *SelectedProduct.ProductPrice+$ TwoWay=��� $��3��$��2��$��
Cost Price��$
��left=�$
��Bold"��� $��3��$��3��$	��100��$
��left=�$��2,0,0,0q����� *" SelectedProduct.ProductCostPrice+$ TwoWay=��� $��3��$��4��$��VAT Category��$
��left=�$
��Bold"��� $��3��$��5��$ CategoryName��$ 
CategoryId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��100��$��3������ *ProductCategory+ �� *SelectedProductCategory+�� $��3��$��6��$��Active��$
��left=�$
��Bold"��� $��3��$��7��$ ActiveCategory��$ ActiveId��$
��Left=�$��0,0,0,0q�$	��Top=�$	��100��$��3������ *ActiveTypes+ �� *SelectedActiveType+�� -   $��btnAdd��$��4��$��0��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *
AddCommand+.���� .��_Add Product�� $��4��$��1��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *SubmitCommand+.���� .��Sa_ve Product�� $��4��$��2��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *
DelCommand+.���� .��_Delete Product�� $��4��$��3��$��Center=�$	��100��$��	0,10,0,10q�
������$
��Bold"����� *ResetCommand+.���� .��_Reset�� -   $��lstview����. $��Visible=�$��5��$��0��$��10��$��2,0,0,0q�$��2������ *ProductsDataView+ �� *SelectedProduct+$ TwoWay=� �� View �� ��. .P��� $��IsDirty�� �� Width$ 0�� �� DisplayMemberBinding �� *	IsDirty+$ TwoWay=��� $��Barcode��$ 70�� �� *	BarCodeId+$ TwoWay=��� $ 70�� �� *	ProductId+$ TwoWay=�.���� $��	ProductId��$��	ProductId������ *SortCommand+�� $	 200�� �� *ProductName+$ TwoWay=�.���� $
��Name��$��ProductName������ *SortCommand+�� $��SP��$ 70�� �� *ProductPrice+$ TwoWay=��� $ 70�� �� *ProductCostPrice+$ TwoWay=�.���� $��CP��$��ProductCostPrice������ *SortCommand+�� $	��VAT��$ 70�� �� *ProductVatCategory+$ TwoWay=��� $��VAT Rate��$ 70�� �� *	VatRate+$ TwoWay=��� $��	CPWithVAT��$ 70�� �� *	CPWithVAT+$ TwoWay=��� $��Profit��$ 70�� �� *Profit+$ TwoWay=��� $��Active��$ 70�� �� *
IsActive+$ TwoWay=��� $ 70�� �� *TotalAvailQty+$ TwoWay=�.���� $��	Avail.Qty��$��TotalAvailQty������ *SortCommand+�� $��
LastInward��$ 70�� �� *LastInwardDate+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm���� $��SupplierName��$ 70�� �� *SupplierName+$ TwoWay=��� $��Offer��$ 70�� �� *OfferOptionStr+$ TwoWay=��� $��8��$��0��$	��120��$
��left=�$��0,0,0,0q����� *ProductSearchCriteria+$ TwoWay=��� $��8��$��1��$
��Left=�$��2��$	��165��$��0,0,0,0q�
������$
��Bold"����� *SearchProductCommand+.���� .��Search with Product Name