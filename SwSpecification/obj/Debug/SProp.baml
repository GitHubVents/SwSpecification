   M S B A M L   `   `   `  ����  SwSpecification    SwSpecification.SProp   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  SProp��5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�6-   $	��420��6R   $	��759��6_   .��5      � -   5        $��GridHome��5       � ColumnDefinitions 5   
   �� 5      $
��638* �6    � RowDefinitions 5	   
   �� 5
      $	��33* �6   �� 5      $
��302* �6   �� 5      $	��57* �6   .+�5   
   ]� $��0��6   .+�5      �� $��Раздел:��6   $
��Left=�6&   $��Center=�6A   �� 5      -   5        $��CboChangePartition��5      $��5q�61   $
��Left=�6<   $��Center=�6W   $	��150��6r   6~   5      �� 5   
   $��1��6   $��5q�6"   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��	DgMatProp��5         AutoGenerateColumns .  $	��290��6D   $��15(�5         HorizontalGridLinesBrush �	#FF0B4EA2   VerticalGridLinesBrush �	#FF0B4EA2   CanUserAddRows .  	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Конфигурация��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6A      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *Config+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5      $
 Наименование��6)   $ * 6A    6K   �� *Description+$ PropertyChanged=�  5      $
 
Код 1С��6)   $ * 6A    6K   �� *Code1C+$ PropertyChanged=�  5      $
 
Длина��6)   $ * 6A    6K   �� *Length+$ PropertyChanged=�  5      $
 Ширина��6)   $ * 6A    6K   �� *Width+$ PropertyChanged=�  5      $
 Количество��6)   $ * 6A    6K   �� *Summ+$ PropertyChanged=�  5      $
 Примечание��6)   $ * 6A    6K   �� *Note+$ PropertyChanged=�5!      5"      �� 5#   
   $��2��6   .+�5$      �� -   5        $��BtnSave��5$      $��Применить��6$   $��3q�68   $��Bottom=�6C   5%      �� 5&      -   5        $��BtnClose��5&      $��Закрыть��6%   $��3q�67   $��Bottom=�6B   5'      5(      5)      5*      