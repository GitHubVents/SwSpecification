   M S B A M L   `   `   `  ����J  FSwSpecification, Version=1.0.0.9, Culture=neutral, PublicKeyToken=null1clr-namespace:SwSpecificationSwSpecification  5   	   "    SwSpecification.FixAllConfig   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:SwSpecification     5   	     � Title$  FixAllConfig��5   	   $	��300��6   $	��500��6+    � Topmost . .��5
      � -   5        $��MainGrid��5
        � ShowGridLines . .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $	��Top=�6%   $	��227��6=      CanUserAddRows .  $
��auto��6a      AutoGenerateColumns .     CanUserResizeRows .  5   -   �� 5   
   -   5         ��Name$ SaveChangesOnGrid��5      $��Применить��6-   $
��Left=�6A   $��
24,239,0,0q�6\   $	��Top=�6p   $	��139��6�   6�   �� 5   
   -   5        $ UndoChanges��5      $*��$Применить и закрыть��6&   $
��Left=�6D   $��174,239,0,0q�6_   $	��Top=�6t   $	��139��6�   6�   �� 5   
   -   5        $ Close��5      $��Закрыть��6    $
��Left=�62   $��333,239,0,0q�6M   $	��Top=�6c   $	��139��6{   6�   5      5      