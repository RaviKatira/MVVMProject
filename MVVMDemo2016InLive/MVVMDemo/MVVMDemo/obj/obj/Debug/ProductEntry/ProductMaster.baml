   M S B A M L   `   `   `  ����M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OPSMain.ProductEntryOPSMain.ProductEntry  5   	   ;"clr-namespace:OPSMain.ProductEntryOPSMain.ProductEntry  5   	   (    "OPSMain.ProductEntry.ProductMaster   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:OPSMain.ProductEntry     5   	   8	viewmodel"clr-namespace:OPSMain.ProductEntry     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5          � Title$  Product Master��5
   
   $	��700��6!   $
��1000��6.    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      +   %OPSMain.ProductEntry.ProductViewModel   	ViewModel �� 
TargetType �� Property �� Value��%t   &	        '��        5   
   6%   �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�6;   5      5      .��5      � .+�5   
   � $��	0,-2,0,30q�6I    � ShowGridLines .   � DataContext 6   ��  �� Source# [  	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $	��400 �6    �� 5      $��* �6    �� 5      $��* �6    �� 5       $��* �6    
 � ColumnDefinitions
 5#      �� 5$      $��* �6#   �� 5%      $��* �6#   �� 5&      $��* �6#   �� 5'      $��* �6#   �� 5(      $��* �6#   �� 5)      $��* �6#   �� 5*      $��* �6#   �� 5+      $��* �6#   .+�5.      �� $��0��6   $��1��6$   $��Supplier��61   $
��left=�6D   $
��Bold"�5/      $��0,0,0,0q�6#   �� 50      $��1��6   $��1��6%    �� DisplayMemberPath$ SupplierName��52       �� SelectedValuePath$ 
SupplierId��53      $
��Left=�55      $��0,0,0,0q�6.   $	��Top=�6@   $	��200��6X   $��2��6d   ��51      �� *	Suppliers+ �� SelectedItem 54      �� *SelectedSupplier+55   d   �� 57      $��1��6   $��3��6!   $��Bar Code No��61   $
��left=�6G   $
��Bold"�58      $��20,0,0,0q�6&   �� 59      -   5        $��txtBarCodeId��59      $��1��5:      $��4��6#   $	��138��63   $
��left=�6?   $��2��6�   $��20,0,0,0q�6�   ��6Z   �� *SelectedProduct.BarCodeId+ �� Mode$ TwoWay=�.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 5;      /  )System.Windows.Interactivity.EventTrigger  5<         	EventName$ 	LostFocus��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5=      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *SearchBarCodeCommand+5>      .��5?   *   5@      �� 5B      $��2��6   $��0��6!   $��Product��61   $
��left=�6C   $��0,0,0,0q�6^   $
��Bold"�6o   $	��Top=�6�   �� 5C      $��2��6   $��1��6#   $��4��63   $	��500��6G   $
��left=�6S   $��0,0,0,0q�6�   ��6n   �� *SelectedProduct.ProductName+$ TwoWay=�6�   �� 5E      $��2��6   $��6��6!   $��Offer��61   $
��left=�6A   $
��Bold"�6\   �� 5F      $��2��6   $��7��6$   $ OfferOption��5H      $ OfferId��5I      $
��Left=�5K      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��5G      �� *ProductOffer+ 5J      �� *SelectedProductOffer+5K   d   �� 5S      $��3��6   $��0��6!   $��Selling Price��61   $
��left=�6I   $
��Bold"�6d   �� 5T      $��3��6   $��1��6#   $	��100��63   $
��left=�6?   $��2,0,0,0q�6�   ��6Z   �� *SelectedProduct.ProductPrice+$ TwoWay=�6�   �� 5U      $��3��6   $��2��6!   $��
Cost Price��61   $
��left=�6F   $
��Bold"�6a   �� 5V      $��3��6   $��3��6#   $	��100��63   $
��left=�6?   $��2,0,0,0q�6�   ��6Z   �� *" SelectedProduct.ProductCostPrice+$ TwoWay=�6�   �� 5W      $��3��6   $��4��6!   $��VAT Category��61   $
��left=�6H   $
��Bold"�6c   �� 5X      $��3��6   $��5��6$   $ CategoryName��5Z      $ 
CategoryId��5[      $
��Left=�5]      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��5Y      �� *ProductCategory+ 5\      �� *SelectedProductCategory+5]   d   �� 5^      $��3��6   $��6��6!   $��Active��61   $
��left=�6B   $
��Bold"�6]   �� 5_      $��3��6   $��7��6$   $ ActiveCategory��5a      $ ActiveId��5b      $
��Left=�5d      $��0,0,0,0q�6.   $	��Top=�6@   $	��100��6X   $��3��6d   ��5`      �� *ActiveTypes+ 5c      �� *SelectedActiveType+5d   d   �� 5e      -   5        $��btnAdd��5e      $��4��6'   $��0��64   $��Center=�6c   $	��100��6�   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��6D   �� *
AddCommand+.��5f      �� .��6   _Add Product5h      5i      �� 5j      $��4��6   $��1��6&   $��Center=�6Y   $	��100��6v   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��67   �� *SubmitCommand+.��5k      �� .��6   Sa_ve Product5m      5n      �� 5o      $��4��6   $��2��6&   $��Center=�6W   $	��100��6t   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��68   �� *
DelCommand+.��5p      �� .��6   _Delete Product6-   5q      �� 5r      $��4��6   $��3��6&   $��Center=�6W   $	��100��6t   $��	0,10,0,10q�6�   
������$
��Bold"�6�   ��66   �� *ResetCommand+.��5s      �� .��6   _Reset5u      5v      �� 5x      -   5        $��lstview��5z      ��. $��Visible=�5x   >   $��5��5y      $��0��6&   $��10��66   $��2,0,0,0q�5{   O   $��2��6`   ��5z   (   �� *ProductsDataView+ 5{      �� *SelectedProduct+$ TwoWay=� �� View 5}      �� 5~      ��. .P�5      �� $��IsDirty��6)    �� Width$ 0��6o    �� DisplayMemberBinding 6:   �� *	IsDirty+$ TwoWay=�6o   �� 5�      $��Barcode��6)   $ 70��6q    6:   �� *	BarCodeId+$ TwoWay=�6q   �� 5�      $ 70��6a    6*   �� *	ProductId+$ TwoWay=�.��5�      �� $��	ProductId��63   $��	ProductId��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $	 200��6c    6*   �� *ProductName+$ TwoWay=�.��5�      �� $
��Name��63   $��ProductName��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $��SP��6)   $ 70��6o    65   �� *ProductPrice+$ TwoWay=�6o   �� 5�      $ 70��6h    6*   �� *ProductCostPrice+$ TwoWay=�.��5�      �� $��CP��63   $��ProductCostPrice��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $	��VAT��6)   $ 70��6v    66   �� *ProductVatCategory+$ TwoWay=�6v   �� 5�      $��VAT Rate��6)   $ 70��6p    6;   �� *	VatRate+$ TwoWay=�6p   �� 5�      $��	CPWithVAT��6)   $ 70��6s    6<   �� *	CPWithVAT+$ TwoWay=�6s   �� 5�      $��Profit��6)   $ 70��6m    69   �� *Profit+$ TwoWay=�6m   �� 5�      $��Active��6)   $ 70��6o    69   �� *
IsActive+$ TwoWay=�6o   �� 5�      $ 70��6e    6*   �� *TotalAvailQty+$ TwoWay=�.��5�      �� $��	Avail.Qty��63   $��TotalAvailQty��5�      ��5�      �� *SortCommand+5�      5�      �� 5�      $��
LastInward��6)   $ 70��6�    6=   �� *LastInwardDate+$ TwoWay=� �� StringFormat$ dd-MMM-yy HH:mm��6�   �� 5�      $��SupplierName��6)   $ 70��6y    6?   �� *SupplierName+$ TwoWay=�6y   �� 5�      $��Offer��6)   $ 70��6t    68   �� *OfferOptionStr+$ TwoWay=�6t   5�      5�      �� 5�      $��8��6   $��0��6#   $	��120��63   $
��left=�6?   $��0,0,0,0q�6�   ��6Z   �� *ProductSearchCriteria+$ TwoWay=�6�   �� 5�      $��8��6   $��1��6"   $
��Left=�6]   $��2��6x   $	��165��6�   $��0,0,0,0q�6�   
������$
��Bold"�6�   ��63   �� *SearchProductCommand+.��5�      �� .��6   Search with Product Name5�      5�      5�      5�      5�      