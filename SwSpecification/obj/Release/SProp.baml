   M S B A M L   `   `   `  ����   SwSpecification    SwSpecification.SProp   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  SProp�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�$	��420��$	��759��.��� -   $��GridHome�� � ColumnDefinitions �� $
��638* � � RowDefinitions �� $	��33* ��� $
��302* ��� $	��57* �.+�]� $��0��.+��� $��Раздел:��$
��Left=�$��Center=��� -   $��CboChangePartition��$��5q�$
��Left=�$��Center=�$	��150���� $��1��$��5q�.+�&   System.Windows.Controls.DataGrid  -   $��	DgMatProp��   AutoGenerateColumns .  $	��290��$��15(�   HorizontalGridLinesBrush �	#FF0B4EA2   VerticalGridLinesBrush �	#FF0B4EA2   CanUserAddRows .  	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Конфигурация��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto    
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Config+ �� UpdateSourceTrigger$ PropertyChanged=�  $
 Наименование��$ *  �� *Description+$ PropertyChanged=�  $
 
Код 1С��$ *  �� *Code1C+$ PropertyChanged=�  $
 
Длина��$ *  �� *Length+$ PropertyChanged=�  $
 Ширина��$ *  �� *Width+$ PropertyChanged=�  $
 Количество��$ *  �� *Summ+$ PropertyChanged=�  $
 Примечание��$ *  �� *Note+$ PropertyChanged=��� $��2��.+��� -   $��BtnSave��$��Применить��$��3q�$��Bottom=��� -   $��BtnClose��$��Закрыть��$��3q�$��Bottom=�