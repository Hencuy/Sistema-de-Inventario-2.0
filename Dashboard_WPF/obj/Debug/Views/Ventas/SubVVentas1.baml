   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Dashboard_WPF.Views.VentasDashboard_WPF.Views.Ventas  5      g cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137akOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.MaterialMahApps.Metro.IconPacks 5      ,    &Dashboard_WPF.Views.Ventas.SubVVentas1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Dashboard_WPF.Views.Ventas     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ZIconOclr-namespace:MahApps.Metro.IconPacks;assembly=MahApps.Metro.IconPacks.Material  5        N� Title$  SubVVentas1��5      .��5      � ���#EFF2F7$	��420��6    $	��870��6-    � ColumnDefinitions 5   
   �� 5      $	��600 �6   �� 5      .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��40 �6    �� 5      .+�5      �� ���#EFF2F7 �� Orientation$ 
Horizontal=�6/   .+�5      �� $	��160��6   
������ 
������ .��5      � .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�62   $��Center=�6A   $��0 0 7 0q�6\   
��� � �6m   �� 5      $��14(�6$   
��� � �Buscar Producto6V   5      5      �� 5      -   5        $��TbCodigoBarras��5   X   
���   �$	��250��6-   $��30��69   $��	10 0 10 0q�6E   6p   �� 5      -   5        $��BtnAgregarProd��5   %   $	��120��6   .��5       � .+�5!        $ 
PlusCircle=�62   $��Center=�6D   $��0 0 7 0q�6_   �� 5"      $��14(�6$   	Agregar6;   5#      5$      5%      � 5&      
�������$��1��6&   .+�5'      &   System.Windows.Controls.DataGrid  -   5        $��	ProdAgreg��5'   \      DataGridColumnHeaderStyle1   ColumnHeaderStyle# �   6      
IsReadOnly .     CanUserAddRows .     AutoGenerateColumns .  ��6�   �� *	productos+	   Columns	 5(      4  .System.Windows.Controls.DataGridTemplateColumn  5*      ,  &System.Windows.Controls.DataGridColumn
   Header$
 #��62      
IsReadOnly .    CanUserResize .     Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6e      CellTemplate 5+      �� 5,   "   .R�5-   &   �� $��Center=�6H   $��Center=�6e   ��60   �� *Numero+6e   5.   #   50        52      $
 Codigo de Barra��61    .  .  $
 auto 6r    53      �� 54   "   .R�55   &   �� $��Center=�6M   $��Center=�6j   ��60   �� *CodigoBarra+6j   56   #   58        5:      $
 Producto��62    .  .  $
 auto 6l    5;      �� 5<   "   .R�5=   &   �� $��Center=�6J   $��Center=�6g   ��60   �� *
Producto+6g   5>   #   5@        5B      $
 Cantidad��61    .  $
 auto 6V    5C      �� 5D   "   .R�5E   &   �� $��Center=�6m   $��Center=�6�   ��6.   �� *
Cantidad+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5F   #   5H        5M      $
 Precio��62    .  .  $
 auto 6j    5N      �� 5O   "   .R�5P   &   �� $��Center=�6H   $��Center=�6e   ��60   �� *Precio+6e   5Q   #   5S        5U      $
 SubTotal��62    .   .  $
 auto 6m    5V      �� 5W   "   .R�5X   &   �� $��Center=�6J   $��Center=�6g   ��60   �� *
SubTotal+6g   5Y   #   5[        5_      $
 Remover��61    . $
 auto 6T    5`      �� 5a   "   .R�5b   &   �� -   5          gridEditButton#��[ 5b   -   
���  ��
���  ��.��5c   *   .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ TrashCan=�6@   $��15��6P   $��15��6\   
�������6g   5d   '   5e   #   5g      5i      5j      5k      � 5l   
   $��1��6    5m      �� 5n      �� 5o      �� 5p      �� 5q      �� 5r      �� 5s      �� 5t      �� 5u      �� 5v      �� 5w      .+�5y      �� $��Center=�6   $��20(�64   $��Verdana)�6B   $��Center=�6W   $
��Bold"�6t   DATOS DE LA VENTA6�   �� 5{      $��0 0 0 0q�6   $��1��6*   .+�5|      �� $ 
Horizontal=�6   $��10 0 0 0q�66   .+�5}      �� $��Center=�6    $��10(�6;   $��0 0 0 0q�6I   $��Verdana)�6Z   Fecha6v   5~      (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
FechaVenta��5   Y   
���   �$	��260��60   $��23��6<   $��0 0 0 0q�6H   6o   5�      �� 5�      $��2��6   $ 
Horizontal=�6&   .+�5�      �� $��0 0 7 0q�6   .+�5�      �� $ 
Horizontal=�6!   $��10 0 0 0q�6:   .+�5�      �� $��Center=�6$   $��10(�6?   $��0 0 0 0q�6M   $��Verdana)�6^   $��Cliente (CI)��6s   5�      �� 5�      -   5        $��	CiCliente��5�      
���   �$	��200��6B   $��23��6N   $��7 0 0 0q�6Z   6m   5�      �� 5�      $��0 0 0 0q�6   $��20��6*   .��5�        $ ContentSaveCheck=�6.   $��Center=�6F   $��0 0 0 0q�6a   5�      5�      �� 5�      $��0 0 0 0q�6   $��3��6*   .+�5�      �� $ 
Horizontal=�6   $��10 0 0 0q�66   .+�5�      �� $��Center=�6    $��10(�6;   $��0 0 0 0q�6I   $��Verdana)�6Z   Descuento de venta(%)6�   5�      �� 5�      -   5        $��DescuentoVenta��5�      
���   �$	��260��6C   $��23��6O   $��0 0 0 0q�6[   6�   5�      �� 5�      $��0 0 0 0q�6   $��4��6*   .+�5�      �� $ 
Horizontal=�6   $��10 0 0 0q�66   .+�5�      �� $��Center=�6    $��10(�6;   $��0 0 0 0q�6I   $��Verdana)�6Z   Total pagado por el cliente6�     5�      $��10��6.   $��10��6:   $
 Flag=�6E   $��Center=�6Q   $��5 0 0 0q�6l   5�      �� 5�      -   5        $��TotalPagado��5�      
���   �$	��260��6@   $��23��6L   $��0 0 0 0q�6X   6�   5�      �� 5�      $��0 0 0 0q�6   $��5��6*   .+�5�      �� $ 
Horizontal=�6   $��10 0 0 0q�66   .+�5�      �� $��Center=�6    $��10(�6;   $��0 0 0 0q�6I   $��Verdana)�6Z   Cambio devuelto a cliente6�   5�      �� 5�      -	   5        $��CambioVenta��5�      
���   �$	��260��6@   $��23��6L   $��0 0 0 0q�6X   6k   5�      �� 5�      $��0 0 0 0q�6   $��6��6*   $��Center=�67   $��Center=�6R   $ 
Horizontal=�6o   .+�5�      �� $��Center=�6   $��10(�67   $��	0 0 150 0q�6E   $��Verdana)�6X   $
��Bold"�6m   
Subtotal6�   �� 5�      -
   5        $��SubTotalVenta��5�      $��Center=�61   $��10(�6L   $��0 0 0 0q�6Z   $��Verdana)�6k   
+ 0.00 BOB6�   5�      �� 5�      $��0 0 0 0q�6   $��7��6*   $��Center=�67   $��Center=�6R   $ 
Horizontal=�6o   .+�5�      �� $��Center=�6   $��10(�67   $��	0 0 150 0q�6E   $��Verdana)�6X   $
��Bold"�6m   
Decuento6�   �� 5�      -   5        $��DescuentoVentaTotal��5�      $��Center=�67   $��10(�6R   $��0 0 0 0q�6`   $��Verdana)�6q   
- 0.00 BOB6�   5�      �� 5�      $��0 0 0 0q�6   $��8��6*   $��Center=�67   $��Center=�6R   $ 
Horizontal=�6o   .+�5�      �� $��Center=�6   $��10(�67   $��	0 0 150 0q�6E   $��Verdana)�6X   $
��Bold"�6m   Total6�   �� 5�      -   5        $��
TotalVenta��5�      $��Center=�6.   $��10(�6I   $��0 0 0 0q�6W   $��Verdana)�6h   
0.00 BOB6�   5�      �� 5�      $��9��6   $��Center=�6&   .+�5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�      �� -   5        $��GuardarVenta��5�   :   $��0 0 0 0q�6   $��20��6.   .��5�      � .+�5�        $ ContentSaveCheck=�66   $��Center=�6N   $��0 0 7 0q�6i   �� 5�      $��10(�6(   	Guardar6?   5�      5�      5�      �� 5�      $ 
Horizontal=�6   $��0 5 0 0q�66   .+�5�      �� $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   Los campos marcados con6�     5�      $��15��6.   $��15��6:   $
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   �� 5�      $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   son obligatorios6�   5�      5�      5�      5�      5�      