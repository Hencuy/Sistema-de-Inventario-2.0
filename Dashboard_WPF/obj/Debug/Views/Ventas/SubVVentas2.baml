   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Dashboard_WPF.Views.VentasDashboard_WPF.Views.Ventas  5      ,    &Dashboard_WPF.Views.Ventas.SubVVentas2   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Dashboard_WPF.Views.Ventas     5        N� Title$  SubVProveedores2��5	       � 	Resources 5
         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%�   &	        �� 5   
   "  62   .�5      ��  � �� �#2D43566+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   5      5      .��5      � 
�������$	��420��6   $	��920��6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ VentasDataGrid��5         AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly . $��0q�6p   	   	CellStyle	 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6   .�5      ��  � ��$ Center=�6<   �� 5       � ��$ Center=�6:   5      
   Columns
 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Venta��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6;      CellTemplate 5      �� 5      .R�5      �� 
���   ���6(   �� *idProductosVenta+6J   5       5"        5#      $ Precio de Compra��6)   $
 auto 6C    5$      �� 5%      .R�5&      �� 
���   ���6(   �� *PrecioCompra+6F   5'      5)        5*      $ Precio de Venta��6)   $
 auto 6B    5+      �� 5,      .R�5-      �� 
���   ���6(   �� *PrecioVenta+6E   5.      50        51      $ Precio al Mayoreo��6)   $
 auto 6D    52      �� 53      .R�54      �� 
���   ���6(   �� *PrecioMayoreo+6G   55      57        58      $ ID Producto��6)   $
 auto 6>    59      �� 5:      .R�5;      �� 
���   ���6(   �� *
idProducto+6D   5<      5>        5?      $ ID Detalles Venta��6)   $
 auto 6D    5@      �� 5A      .R�5B      �� 
���   ���6(   �� *idDetallesVenta+6I   5C      5E        5F      $ Stock de Salida��6)   $
 auto 6B    5G      �� 5H      .R�5I      �� 
���   ���6(   �� *StockSalida+6E   5J      5L      5N      5O      5P      