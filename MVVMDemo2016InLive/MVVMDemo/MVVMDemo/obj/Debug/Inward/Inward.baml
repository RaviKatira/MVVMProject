   M S B A M L   `   `   `  ����M  IShreeDashamaStores, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPSMainOPSMain  5   	   !clr-namespace:OPSMainOPSMain  5   	       OPSMain.Inward   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OPSMain     5   	   +	viewmodelclr-namespace:OPSMain     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5          � Title$  Inventory Inward��5   	   $	��700��6"   $	��750��6/    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         OPSMain.InwardViewModel   	ViewModel �� 
TargetType �� Property �� Value��%t   &	        '��        5   
   6$   �� 5   
   " ��6   .�5      ��  � ��$ Stretch=�6;   5      5      .��5      � .+�5   
   � $��	0,-2,0,30q�6I    � ShowGridLines .   � DataContext 6   ��  �� Source# [  	 � RowDefinitions	 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $	��400 �6    �� 5      $��* �6    �� 5      $��* �6    �� 5       $��* �6    
 � ColumnDefinitions
 5#      �� 5$      $��* �6#   �� 5%      $��* �6#   �� 5&      $��* �6#   �� 5'      $��* �6#   �� 5(      $��* �6#   �� 5)      $��* �6#   .+�5+      �� $��1��6   $��0��6!   $��	Bill Date��61   $
��left=�6E   $
��Bold"�5,      (  "System.Windows.Controls.DatePicker  5-      -   5        $��dtDate��5-      
���   �$��1��5.      $��1��6#   $	��120��63   $
��left=�6?   $��32��6�   $��Bottom=�6�      SelectedDate 6Z   �� *InwardDetail.Dated+ �� StringFormat$ 	dd/MM/yyy��5/      �� 51      $��1��6   $��2��6!   $��Bar Code No��61   $
��left=�6G   $
��Bold"�52      �� 53      -   5        $��txtBarCodeId��53      
���   �$��1��54      $��3��6#   $	��138��63   $
��left=�6?   ��6Z   �� *InwardDetail.BarCodeId+ �� Mode$ TwoWay=�.��6�   .  (System.Windows.Interactivity.Interaction   Triggers 55      /  )System.Windows.Interactivity.EventTrigger  56         	EventName$ 	LostFocus��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 57      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *SearchBarCodeCommand+58      .��59   *   5:      �� 5;      $��1��6   $��4��6"   $��Center=�6W   $	��100��6t   $��0,0,0,0q�6�   ��62   �� *NewInwardCommand+.��5<      �� .��6   _New Inward5>      5?      �� 5@      $��2��6   $��0��6!   $��Product��61   $
��left=�6C   $��0,0,0,0q�6^   $
��Bold"�6o   $	��Top=�6�   �� 5A      $��2��6   $��1��6$    �� DisplayMemberPath$ ProductwithPrice��5C       �� SelectedValuePath$ 	ProductId��5D      $
��Left=�5F      $��0,0,0,0q�6.   $	��Top=�6@   $	��350��6X   $��3��6d   ��5B      �� *
Products+ �� SelectedItem 5E      �� *	Product+5F   d   �� 5G      $��3��6   $��0��6!   $��Quantity��61   $
��left=�6D   $
��Bold"�6_   �� 5H      -   5        $��txtQty��5H      $��3��6$   $��1��61   $	��100��6A   $
��left=�6M   $��2,0,0,0q�6�   ��6h   �� *InwardDetail.Quantity+$ TwoWay=� �� ValidatesOnDataErrors .  �� ValidatesOnExceptions .  �� NotifyOnValidationError . 6.  �� 5J      -   5        $��btnAdd��5J      $��4��6#   $��0��60   $��Center=�6_   $	��100��6|   $��	0,10,0,10q�6�   ��6@   �� *
AddCommand+.��5K      �� .��6   _Add5M      5N      �� 5O      $��4��6   $��1��6"   $��Center=�6U   $	��100��6r   $��	0,10,0,10q�6~   ��63   �� *SubmitCommand+.��5P      �� .��6   Sa_ve5R      5S      �� 5T      $��4��6   $��2��6"   $��Center=�6S   $	��100��6p   $��	0,10,0,10q�6|   ��64   �� *
DelCommand+.��5U      �� .��6   	_Delete6!   5V      �� 5W      $��4��6   $��3��6"   $��Center=�6S   $	��100��6p   $��	0,10,0,10q�6|   ��62   �� *ResetCommand+.��5X      �� .��6   _Reset5Z      5[      �� 5]      -   5        $��lstview��5_      ��. $��Visible=�5]   >   $��5��5^      $��0��6&   $��6��66   $��2,0,25,0q�5`   L   $��2��6^   ��5_   (   �� *InwardDetails+$ TwoWay=� 5`      �� *InwardDetail+$ TwoWay=� �� View 5a      �� 5b      ��. .P�5c      �� $��IsDirty��6)    �� Width$ 0��6o    �� DisplayMemberBinding 6:   �� *	IsDirty+$ TwoWay=�6o   �� 5d      $��Barcode��6)   $ 0��6q    6:   �� *	BarCodeId+$ TwoWay=�6q   �� 5e      $��	ProductId��6)   $ 70��6s    6<   �� *	ProductId+$ TwoWay=�6s   �� 5f      $��InwardDetailId��6)   $ 90��6}    6A   �� *InwardDetailId+$ TwoWay=�6}   �� 5g      $��Dated��6)   $ 70��6k    68   �� *Dated+$ TwoWay=�6k   �� 5h      $��Product��6)   $	 250��6:    �� CellTemplate 5i      �� 5j   "   .R�5k   &   ��  �� TextAlignment$
 Left=�6Y   $��Center=�6n   ��60   �� *ProductName+$ TwoWay=�6n   5l   #   5n      �� 5o      $��Quantity��6)   $ 60��6;    5p      �� 5q   "   .R�5r   &   �� $ Right=�6V   ��60   �� *
Quantity+$ TwoWay=�6V   5s   #   5v      5x      5z      �� 5{      $��8��6   $��0��6"   $	��130��6Z   $��0,0,0,0q�6f   
������$
��Bold"�6�   ��63   �� *SaveInwardCommand+.��5|      �� .��6   Save Bill Inward5~      5      �� 5�      $��8��6   $��1��6!   $��Supplier��61   $
��left=�6D   $��0,0,0,0q�6_   $
��Bold"�6p   $	��Top=�6�   �� 5�      $��8��6   $��2��6$   $ ProductwithPrice��5�      $ 	ProductId��5�      $
��Left=�5�      $��0,0,0,0q�6.   $	��Top=�6@   $��70��6X   $��1��6c   ��5�      �� *
Products+ 5�      �� *	Product+5�   c   �� 5�      $��8��6   $��3��6"   $	��130��6\   $��0,0,0,0q�6h   
������$
��Bold"�6�   ��63   �� *SearchInwardCommand+.��5�      �� .��6   Search Inward5�      5�      5�      5�      5�      