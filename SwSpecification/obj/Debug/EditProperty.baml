   M S B A M L   `   `   `  ����  SwSpecification#    SwSpecification.EditPropeprty   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$%  Редактор свойств��5   	   $	��350��6"   $	��525��6/    � WindowStartupLocation$ CenterScreen=�6;   $	��525��6`   $	��350��6o    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6�    � Topmost .  � 	Resources 5      ��%    5      .��5	      � -   5        $��GridHome��5	      .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��DataGridTable��5
         AutoGenerateColumns .     CanUserAddRows .  $��10,10,10,48q�5      $��14(�6P   ��6(   �� *ColumnNameTable+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   
IsReadOnly	 . 
   Header$
 Обозначение��67      MinWidth$	 120Q�5   %      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   L   �� *ColumnNumber+   ClipboardContentBinding 5   %   Z�    ElementStyle 5   &   �� 5   *    �� 
TargetType" ��60   .�5   .   ��  �� Property � �� �� Value$ Right=�6T   5   +   5        5      $
 Наименование��6%   $	 120Q�5   %   $ * 64    5   ;   �� *ColumnDescription+ 5   &   �� 5   *   " ��60   .�5   .   ��  � ��$
 Left=�6T   5   +   5!        5#      $/
 )Условное наименование��6%   $	 120Q�5$   %   $ * 64    5#   D   �� *CodFb+ 5%   &   �� 5&   *   " ��60   .�5'   .   ��  � ��$
 Left=�6T   5(   +   5*      5,      �� 5.   
   -   5        $��BtnOk��5.      $��Применить��6   $��
0,0,240,10q�62   $��Bottom=�6F   $��Right=�6u   $��75��6�   �� 5/   
   -   5        $��BtnOkAbdClose��5/      $*��$Применить и закрыть��6&   $��	0,0,99,10q�6D   $��Bottom=�6W   $��Right=�6�   $	��136��6�   �� 50   
   -   5         ��Name$ BtnClose��50      $��Закрыть��6#   $��	0,0,19,10q�65   $��Bottom=�6H   $��Right=�6z   $��75��6�   51      52      