   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Dashboard_WPF.Views.ComprasDashboard_WPF.Views.Compras  5      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks 5      .    (Dashboard_WPF.Views.Compras.SubVCompras1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:Dashboard_WPF.Views.Compras     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ZIconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material  5      -   5          N� Title$  SubVCompras1��5      .��5      � 
�������$	��420��6   $	��870��6+    � ColumnDefinitions 5   
   �� 5      $	��600 �6   6-   �� 5      $	��270 �6   6-   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $	��100 �6    6/   �� 5      6"   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��	30 20 0 0q�6   .+�5      �� $ 
Horizontal=�6!   .+�5      �� $��Center=�6%   $��15(�6@   $��0 0 0 0q�6N   $��Verdana)�6_   Codigo de Barras6�   5      �� 5      -   5        $��txtCodigoBarra��5      
���   �$	��350��6G   $��0 10 0 0q�6S   6g   5      �� 5       -   5        $��btnVerificarProducto��5       $��15 0 0 0q�65   
������ 
��� � �
������ .��5!      � .+�5"      '  !MaterialDesignThemes.Wpf.PackIcon  
��� � �   Kind$ CheckCircleOutline=�6E   $��Center=�6_   $��0 0 7 0q�6z   �� 5#      $��14(�6$   Verificar Producto6F   5$      5%      5&      �� 5'      $��1��6   .+�5(      &   System.Windows.Controls.DataGrid  -   5        $��TablaCompras��5(         
IsReadOnly .    CanUserAddRows .     DataGridColumnHeaderStyle1   ColumnHeaderStyle# �   6Y      Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Código de Barras��6-   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6G   �� *CodigoBarra+  5+      $	 Producto��6-   
 6?   �� *
Producto+  5,      $	 Cantidad��6-   
 6?   �� *
Cantidad+  5-      $	 Precio Compra��6-   
 6D   �� *PrecioCompra+  5.      $	 Precio Venta��6-      
Visibility$ 	Collapsed=�6c   
 6C   �� *PrecioVenta+6c     5/      $	 Precio Mayoreo��6-   $ 	Collapsed=�6g   
 6E   �� *PrecioMayoreo+6g     50      $	 SubTotal��6-   
 6?   �� *
SubTotal+4  .System.Windows.Controls.DataGridTemplateColumn  55      $	 Remover��61      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6T      CellTemplate 56      �� 57   "   .R�58   &   �� $ 
Horizontal=�61   .+�59   *   �� $
��auto��61   $��35��6>    �� CornerRadius$ 5��6J   $��
0 -10 0  0q�6[   $��2q�6p   ._�5:   .   �� $��btnEliminar��6o   -   5          gridEditButton#��[ 5:   6   
���  ��.��5;   2   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ TrashCan=�6H   $��25��6X   $��25��6d   
���   �6p   5<   /   5=   +   5>   '   5?   #   5A      5E      5F      5G      � 5H   
   $��1��6    5I      �� 5J      $��50 �6    6.   �� 5K      $��70 �6    6.   �� 5L      $��70 �6    6.   �� 5M      $��80 �6    6.   �� 5N      $��90 �6    6.   .+�5P      �� $��0��6   $��Center=�6%   $��Center=�6B   DATOS DE LA COMPRA6q   �� 5R      $��1��6   $��0 0 0 0q�6&   .+�5S      �� $ 
Horizontal=�6   .+�5T      �� $��Center=�6!   $��10(�6<   $��10 0 0 0q�6J   $��Verdana)�6\   Fecha6x     5U      $��10��6.   $��10��6:   $
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   5V      (	  "System.Windows.Controls.DatePicker	  5W      -   5        $��dtpFecha��5W      $	��250��6-   6;   5X      �� 5Z      $��2��6   $��0 0 0 0q�6&   .+�5[      �� $ 
Horizontal=�6   .+�5\      �� $��Center=�6!   $��10(�6<   $��10 0 0 0q�6J   $��Verdana)�6\   	Proveedor6|     5]      $��10��6.   $��10��6:   $
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   5^      �� 5_      -   5        $��CmbProve��5_      $	��250��6+   69   5`      �� 5a      $��3��6   $��Center=�6&   .+�5b      �� $ 
Horizontal=�6   .+�5c      �� 
SubTotal6+   �� 5d      -   5        $��txtSubtotal��5d       $��	100 0 0 0q�63   	$0.00 USD6Q   5e      �� 5f      $ 
Horizontal=�6   $��0 20 0 0q�66   .+�5g      �� 	IVA (18%)6+   �� 5h      -	   5        $��txtIva��5h       $��95 0 0 0q�6.   	$0.00 USD6K   5i      5j      �� 5k      $��4��6   $��Center=�6&   .+�5l      �� $ 
Horizontal=�6   .+�5m      �� Total6(   �� 5n      -
   5        $��txtTotal��5n       $��	120 0 0 0q�60   	$0.00 USD6N   5o      �� 5p      .+�5q      �� -   5        $��btnGuardarCompra��5q   :   $��Center=�6   $��0 20 0 0q�6R   ���#279EFF
�������
������  � Cursor$
 Hand��6�   .��5r      � .+�5s        
�������$ ContentSave=�6I   $��Center=�6]   $��0 0 0 0q�6x   �� 5t      $��10(�6(   Guardar Compra6F   5u      5v      5w      �� 5x      $ 
Horizontal=�6   $��0 10 0 0q�66   $��Center=�6H   .+�5y      �� $��Center=�6!   $��8(�6<   $��0 0 0 0q�6I   $��Verdana)�6Z   Los campos marcados con6�     5z      $��10��6.   $��10��6:   $
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   �� 5{      $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   son obligatorios6�   5|      5}      5      5�      5�      