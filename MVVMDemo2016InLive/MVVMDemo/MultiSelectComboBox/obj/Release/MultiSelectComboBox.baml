   M S B A M L   `   `   `  ����   MultiSelectComboBox-    'MultiSelectComboBox.MultiSelectComboBox   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     .���� -     ��Name$  MultiSelectCombo�� J� SnapsToDevicePixels .  � OverridesDefaultStyle . $
��Auto=�$
��Auto=���. $ �� IsSynchronizedWithCurrentItem$
 TrueY����� .R��� -   ���� *Title+ d� 	IsChecked ��  �� Path$ 
IsSelected� �� Mode$ TwoWay=�
 � Tag �� *FindAncestor+ �� AncestorType" ������ 	 �� 
TargetType"	 ��.R�� .+�d� 
 d�Name$
 ToggleButton��$��2��|�.   �� 	ClickMode$ Press=�$
��Left=� �� $ IsDropDownOpen�$ TwoWay=� �� RelativeSource �� *TemplatedParent+���� .R��  � ColumnDefinitions �� $��* ��� $��18 �.+���  ��Name$ Border��$��2�� �� CornerRadius$ 2��
�������
���   �$��1,1,1,1q��� $ 
BorderComp��$��0��$ 2��$��1q�
�������
���   �$��0,0,0,0q�._��� 
������� �� Padding$ 3q����� $
 Text� ��  �� Mode$ FindAncestor=�$ UserControlL�F�  F�Name$ Arrow��$��1��
���   �$��Center=�$��Center=�"����        � 	=  	= � z     	� $��Popup��$��Bottom=� � AllowsTransparency . |�.   �� IsDropDownOpen#��z $��Slide=�.��� $��DropDown�� .  � ActualWidth#��z  �� MaxDropDownHeight#��z .+��� $ DropDownBorder��$��1q�
�������
���   ��� $��4,6,4,6q� .  � DataContext �� .����  K� IsItemsHost . -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$ 	Contained=� �� Triggers P�  P� Property �@��HasItems P� Value .  . ���  �� 
TargetName$ DropDownBorder�� �� Property � �� �� Value$ 95��P�   P� 
SourceName$  Popup�� �@�AllowsTransparency . . ��� $ DropDownBorder�� �@��CornerRadius$ 4���� $ DropDownBorder�� � ��$ 0,2,0,0q�