   M S B A M L   `   `   `  ����M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OPSMain.ProductEntryOPSMain.ProductEntry  5   	   N JMultiSelectComboBox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:MultiSelectComboBox;assembly=MultiSelectComboBoxMultiSelectComboBox 5   	   ;"clr-namespace:OPSMain.ProductEntryOPSMain.ProductEntry  5	   	   (    "OPSMain.ProductEntry.ProductMaster   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OPSMain.ProductEntry     5   	   Rcontrol>clr-namespace:MultiSelectComboBox;assembly=MultiSelectComboBox     5   	   8	viewmodel"clr-namespace:OPSMain.ProductEntry     5	   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   	   -   5          � Title$  Product Master��5   
   $	��700��6!   $
��1000��6.    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      +   %OPSMain.ProductEntry.ProductViewModel   	ViewModel �� 
TargetType �� Property �� Value��%t   &	        '��        5   
   6%   �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�6;   5      5      .��5      � .+�5   
   � $��	0,-2,0,30q�6I    � ShowGridLines .   � DataContext 6   ��  �� Source# [  	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $	��400 �6    �� 5      $��* �6    �� 5       $��* �6    �� 5!      $��* �6    
 � ColumnDefinitions
 5$      �� 5%      $��* �6#   �� 5&      $��* �6#   �� 5'      $��* �6#   �� 5(      $��* �6#   �� 5)      $��* �6#   �� 5*      $��* �6#   �� 5+      $��* �6#   �� 5,      $��* �6#   .+�5/      �� $��0��6   $��1��6$   $��Supplier��61   $
��left=�6D   $
��Bold"�50      $��0,0,0,0q�6#   �� 51      $��1��6   $��1��6%    �� DisplayMemberPath$ SupplierName��53       �� SelectedValuePath$ 
SupplierId��54      $
��Left=�56      $��0,0,0,0q�6.   $	��Top=�6@   $	��200��6X   $��2��6d   ��52      �� *	Suppliers+ �� SelectedItem 55      �� *SelectedSupplier+56   d   �� 58      $��1��6   $��3��6!   $��Bar Code No��61   $
��left=�6G   $
��Bold"�59      $��20,0,0,0q�6&   �� 5:      -   5        $��txtBarCodeId��5:      $��1��5;      $��4��6#   $	��138��63   $
��left=�6?   $��2��6�   $��20,0,0,0q�6�   ��6Z   �� *SelectedProduct.BarCodeId+ �� Mode$ TwoWay=�.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5<      /  )System.Windows.Interactivity.EventTrigger  5=         	EventName$ 	LostFocus��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5>      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *SearchBarCodeCommand+5?      .��5@   *   5A      �� 5C      $��2��6   $��0��6!   $��Product��61   $
��left=�6C   $��0,0,0,0q�6^   $
��Bold"�6o   $	��Top=�6�   �� 5D      $��2��6   $��1��6#   $��4��63   $	��500��6G   $
��left=�6S   $��0,0,0,0q�6�   ��6n   �� *SelectedProduct.ProductName+$ TwoWay=�6�   �� 5F      $��2��6   $��6��6!   $��Offer��61   $
��left=�6A   $
��Bold"�6\   �� 5G      $��2��6   $��7��6$   $ OfferOption��5I      $ OfferId��5J      $
��Left=�5L      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��5H      �� *ProductOffer+ 5K      �� *SelectedProductOffer+5L   d   �� 5T      $��3��6   $��0��6!   $	��MRP��61   $
��left=�6?   $
��Bold"�6Z   �� 5U      -   5        $��txtMRP��5U      $��3��6$   $��1��61   $	��100��6A   $
��left=�6M   $��2,0,0,0q�6�   ��6h   �� *SelectedProduct.MRP+$ TwoWay=�6�   �� 5V      $��3��6   $��2��6!   $��Selling Price��61   $
��left=�6I   $
��Bold"�6d   �� 5W      -   5        $��txtSellingPrice��5W      $��3��6-   $��3��6:   $	��100��6J   $
��left=�6V   $��2,0,0,0q�6�   ��6q   �� *SelectedProduct.ProductPrice+$ TwoWay=�6�   �� 5X      $��3��6   $��4��6!   $��
Cost Price��61   $
��left=�6F   $
��Bold"�6a   �� 5Y      -   5        $��txtCostPrice��5Y      $��3��6*   $��5��67   $	��100��6G   $
��left=�6S   $��2,0,0,0q�6�   ��6n   �� *" SelectedProduct.ProductCostPrice+$ TwoWay=�6�   �� 5Z      $��3��6   $��6��6!   $��VAT Category��61   $
��left=�6H   $
��Bold"�6c   �� 5[      $��3��6   $��7��6$   $ CategoryName��5]      $ 
CategoryId��5^      $
��Left=�5`      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��5\      �� *ProductCategory+ 5_      �� *SelectedProductCategory+5`   d   �� 5a      $��1��6   $��6��6!   $��Active��61   $
��left=�6B   $
��Bold"�6]   �� 5b      $��1��6   $��7��6$   $ ActiveCategory��5d      $ ActiveId��5e      $
��Left=�5g      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��5c      �� *ActiveTypes+ 5f      �� *SelectedActiveType+5g   d   �� 5h      $��4��6   $��0��6!   $��	Treatment��61   $
��left=�6E   $
��Bold"�6`   $��0,0,0,0q�6r   �� 5i       �� IsTextSearchEnabled .  w� TextPath$ TreatmentName��62   $��2��6V   $	��200��5j      $��4��5k      $��1��6"   $ TreatmentId��5m      $
��Left=�5o      $��0,0,0,0q�6.   $	��Top=�6@   ��5l      �� *
Treatments+ 5n      �� *SelectedTreatment+��5p      �� 5q      .R�5r      ��  �� Orientation$ 
Horizontal=�6%   .+�5s      �� $��20��6H    d� 	IsChecked 6'   �� *
IsSelected+6H   �� 5t      $	��180��6H   ��6)   �� *TreatmentName+6V   5v      5w      5z      �� 5�      -   5        $��btnAdd��5�      $��4��6#   $��3��60   $��Center=�6_   $	��100��6|   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��6@   �� *
AddCommand+.��5�      �� .��6   _Add Product5�      5�      �� 5�      $��4��6   $��4��6"   $��Center=�6U   $	��100��6r   $��	0,10,0,10q�6~   
������$
��Bold"�6�   ��63   �� *SubmitCommand+.��5�      �� .��6   Sa_ve Product5�      5�      �� 5�      $��4��6   $��5��6"   $��Center=�6S   $	��100��6p   $��	0,10,0,10q�6|   
������$
��Bold"�6�   ��64   �� *
DelCommand+.��5�      �� .��6   _Delete Product6)   5�      �� 5�      $��4��6   $��6��6"   $��Center=�6S   $	��100��6p   $��	0,10,0,10q�6|   
������$
��Bold"�6�   ��62   �� *ResetCommand+.��5�      �� .��6   _Reset5�      5�      �� 5�      -   5        $��lstview��5�      ��. $��Visible=�5�   >   $��5��5�      $��0��6&   $��10��66   $��2,0,0,0q�5�   O   $��2��6`   ��5�   (   �� *ProductsDataView+ 5�      �� *SelectedProduct+$ TwoWay=� 5�       �� Triggers �� Binding �� Value��%�   '��       �� 5�      " ��6    5�      �� 5�       6*   �� *
IsActive+	 False5�      .a�5�   "   ��  � �� �#ffb3d15�      5�      5�      5�       �� View 5�      �� 5�      ��. .P�5�      �� $��IsDirty��6)    �� Width$ 0��6o    �� DisplayMemberBinding 6:   �� *	IsDirty+$ TwoWay=�6o   �� 5�      $��Barcode��6)   $ 70��6q    6:   �� *	BarCodeId+$ TwoWay=�6q   �� 5�      $ 70��6a    6*   �� *	ProductId+$ TwoWay=�.��5�      �� $��	ProductId��63   $��	ProductId��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $	 200��6c    6*   �� *ProductName+$ TwoWay=�.��5�      �� $
��Name��63   $��ProductName��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6[    6*   �� *MRP+$ TwoWay=�.��5�      �� $	��MRP��63   $	��MRP��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6d    6*   �� *ProductPrice+$ TwoWay=�.��5�      �� $��SP��63   $��ProductPrice��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6h    6*   �� *ProductCostPrice+$ TwoWay=�.��5�      �� $��CP��63   $��ProductCostPrice��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6j    6*   �� *ProductVatCategory+$ TwoWay=�.��5�      �� $	��VAT��63   $��ProductVatCategory��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6_    6*   �� *	VatRate+$ TwoWay=�.��5�      �� $��GST Rate��63   $��VatRate��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6a    6*   �� *	CPWithVAT+$ TwoWay=�.��5�      �� $��	CPWithGST��63   $��	CPWithVAT��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6^    6*   �� *Profit+$ TwoWay=�.��5�      �� $��Profit��63   $��Profit��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6`    6*   �� *
IsActive+$ TwoWay=�.��5�      �� $��Active��63   $��IsActive��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6e    6*   �� *TotalAvailQty+$ TwoWay=�.��5�      �� $��	Avail.Qty��63   $��TotalAvailQty��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6�    6*   �� *LastInwardDate+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm��.��5�      �� $��
LastInward��63   $��LastInwardDate��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6d    6*   �� *SupplierName+$ TwoWay=�.��5�      �� $��SupplierName��63   $��SupplierName��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $ 70��6f    6*   �� *OfferOptionStr+$ TwoWay=�.��5�      �� $��Offer��63   $��OfferOptionStr��5�      ��5�      �� *SortCommand+5�      5�      5     5     �� 5     $��8��6   $��0��6"   $��Product Name��62   $
��left=�6I   $
��Bold"�5     $��0,0,0,0q�6#   �� 5     $��8��6   $��1��6#   $	��120��63   $
��left=�6?   $��0,0,0,0q�6�   ��6Z   �� *ProductSearchCriteria+$ TwoWay=�6�   �� 5     $��2��6   $��8��6$   $��Supplier��61   $
��left=�6D   $
��Bold"�5     $��0,0,0,0q�6#   �� 5     $��8��6   $��3��6%   $ SupplierName��5     $ 
SupplierId��5     $
��Left=�5     $��0,0,0,0q�6.   $	��Top=�6@   $	��200��6X   $��2��6d   ��5     �� *SuppliersFilterList+ 5     �� *SelectedSupplierFilterList+5  d   �� 5      $��8��6   $��5��6"   $
��Left=�6]   $��2��6x   $	��100��6�   $��0,0,0,0q�6�   
������$
��Bold"�6�   ��63   �� *SearchProductCommand+.��5!     �� .��6   Search5#     5$     5&     5(     5)     