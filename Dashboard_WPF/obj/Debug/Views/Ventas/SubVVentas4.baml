   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Dashboard_WPF.Views.VentasDashboard_WPF.Views.Ventas  5      ,    &Dashboard_WPF.Views.Ventas.SubVVentas4   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Dashboard_WPF.Views.Ventas     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  SubVProveedores3��5
      .��5      � 
�������$	��420��6   $	��870��6+   .+�5   
   �� ���#F9F5F6$	��200��6*   $��
0,37,0,183q�67    �� Orientation$ Vertical=�6K   .+�5      �� $��14(�6   $��Center=�6&   #!Introduzca el código de la venta6e   �� 5      -   5        $	��ugu��5      
���   �$	��400��64   $��0 30 0 0q�6@   6T   �� 5      -   5        $��0 40 0 0q�5      $	��150��6'   .��5      � .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6.   $��Center=�6=   $��0 0 7 0q�6X   �� 5      $��14(�6    Buscar66   5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ VentasDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6p   $��	0,192,0,0q�6�      	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      �� 	 �� Property	 � ��
 �� Value$
 Center=�6<   �� 5      	 � ��$
 Center=�6:   5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Venta��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;      CellTemplate 5       �� 5!      .R�5"      �� 
���   ���6(   �� *idProductosVenta+6J   5#      5%        5&      $ Precio de Compra��6)   $
 auto 6C    5'      �� 5(      .R�5)      �� 
���   ���6(   �� *PrecioCompra+6F   5*      5,        5-      $ Precio de Venta��6)   $
 auto 6B    5.      �� 5/      .R�50      �� 
���   ���6(   �� *PrecioVenta+6E   51      53        54      $ Precio al Mayoreo��6)   $
 auto 6D    55      �� 56      .R�57      �� 
���   ���6(   �� *PrecioMayoreo+6G   58      5:        5;      $ ID Producto��6)   $
 auto 6>    5<      �� 5=      .R�5>      �� 
���   ���6(   �� *
idProducto+6D   5?      5A        5B      $ ID Detalles Venta��6)   $
 auto 6D    5C      �� 5D      .R�5E      �� 
���   ���6(   �� *idDetallesVenta+6I   5F      5H        5I      $ Stock de Salida��6)   $
 auto 6B    5J      �� 5K      .R�5L      �� 
���   ���6(   �� *StockSalida+6E   5M      5O      0  *System.Windows.Controls.DataGridTextColumn  5P      $ Fecha��6%   $
 auto 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Fecha+   ElementStyle 5R      �� 5S      " ��6    .�5T      �� 	 � ��

 �   �6;   5U      5W      5Y      5Z      5[      