   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Dashboard_WPF.Views.VentasDashboard_WPF.Views.Ventas  5      ,    &Dashboard_WPF.Views.Ventas.SubVVentas3   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Dashboard_WPF.Views.Ventas     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  SubVProveedores3��5
      .��5      � 
�������$	��420��6   $	��870��6+   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��	0,0,0,336q�6K   $	��850��6^   .+�5      �� $��	0 30 80 0q�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   ���#455A64Fecha inicial (dia/mes/año)6�   '  !MaterialDesignThemes.Wpf.PackIcon  5      $��10��6.   $��10��6:      Kind$
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   ���#455A646}   5      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ FechaInicialPicker��5      
���   �$	��300��6L   5      �� 5      $��0 30 0 0q�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   ���#455A64Fecha final (dia/mes/año)6�     5      $��10��6.   $��10��6:   $
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   ���#455A646}   5        5      -   5        $ FechaFinalPicker��5      
���   �$	��300��6J   5      �� 5      -   5         ��Name$ BuscarButton��5      $��	20 13 0 0q�6+   $	��140��6>   .��5      � .+�5        $ Magnify=�6.   $��Center=�6=   $��0 0 7 0q�6X   �� 5      $��14(�6    Buscar66   5      5       5!      &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ VentasDataGrid��5"         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6p   $��0,73,0,0q�6�   	   	CellStyle	 5#      �� 5$      
 �� 
TargetType*  $System.Windows.Controls.DataGridCell"
  6   .�5%      ��  �� Property � �� �� Value$ Center=�6<   �� 5&       � ��$ Center=�6:   5'         Columns 5)      4  .System.Windows.Controls.DataGridTemplateColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Venta��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;      CellTemplate 5+      �� 5,      .R�5-      �� 
���   ���6(   �� *idProductosVenta+6J   5.      50        51      $ Precio de Compra��6)   $
 auto 6C    52      �� 53      .R�54      �� 
���   ���6(   �� *PrecioCompra+6F   55      57        58      $ Precio de Venta��6)   $
 auto 6B    59      �� 5:      .R�5;      �� 
���   ���6(   �� *PrecioVenta+6E   5<      5>        5?      $ Precio al Mayoreo��6)   $
 auto 6D    5@      �� 5A      .R�5B      �� 
���   ���6(   �� *PrecioMayoreo+6G   5C      5E        5F      $ ID Producto��6)   $
 auto 6>    5G      �� 5H      .R�5I      �� 
���   ���6(   �� *
idProducto+6D   5J      5L        5M      $ ID Detalles Venta��6)   $
 auto 6D    5N      �� 5O      .R�5P      �� 
���   ���6(   �� *idDetallesVenta+6I   5Q      5S        5T      $ Stock de Salida��6)   $
 auto 6B    5U      �� 5V      .R�5W      �� 
���   ���6(   �� *StockSalida+6E   5X      5Z      0  *System.Windows.Controls.DataGridTextColumn  5[      $ Fecha��6%   $
 auto 64   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6A   �� *Fecha+ 	  ElementStyle 5]      �� 5^      "
 ��6    .�5_      ��  � ��
 �   �6;   5`      5b      5d      5e      5f      