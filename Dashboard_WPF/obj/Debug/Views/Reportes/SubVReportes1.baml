   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Dashboard_WPF.Views.ReportesDashboard_WPF.Views.Reportes  5      0    *Dashboard_WPF.Views.Reportes.SubVReportes1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Dashboard_WPF.Views.Reportes     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$  SubVProveedores3��5
       � 	Resources 5         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%�   &	        �� 5   
   "  62   .�5      ��  � �� �#2D43566+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   5      5      .��5      � ���#F9F5F6$	��420��6    $	��870��6-   .+�5   
   �� .+�5      �� $��0 0 0 0q�6   .+�5      �� -   5         ��Name$ buenDia��5      $��Center=�6-   $��20(�6H   $��0 10 0 5q�6V   $��Verdana)�5      ���#455A64$��Center=�6B   -+Estadísticas de ventas de hoy (16-10-2023)5      � 5      
�������$	��120��6*   $	��870��67   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	EnAlmacen��5         AutoGenerateColumns .     CanUserAddRows .  	   
IsReadOnly	 . $��0q�6�   ��6N   �� *ventas+
   	CellStyle
 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6$   .�5   "   ��  � ��$ Center=�6H   �� 5   "    � ��$ Center=�6F   5         Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ ID Venta��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6P   �� *	IDVenta+  5#      $ Fecha de Compra��61   $
 auto 6J    6W   �� *FechaCompra+  5$      $ Hora de Compra��61   $
 auto 6I    6V   �� *
HoraCompra+  5%      $ Total en Ventas��61   $
 auto 6J    6W   �� *TotalEnVentas+  5&      $ Costo en Ventas��61   $
 auto 6J    6W   �� *CostoEnVentas+  5'      $ 	Ganancias��61   $
 auto 6D    6Q   �� *	Ganancias+5)      5*      �� 5+      -   5         ��Name$ btnGenerarPDF��5+      $��0 10 0 0q�60   $	��120��6B   
������ ���#2196F3.��5,      � .+�5-      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
FilePdfBox=�62   $��Center=�6D   $��0 0 7 0q�6_   �� 5.      $��14(�6$   
Imprimir6<   5/      50      51      �� 52      $��10 10 10 10q�6   ���#455A646D   �� 53      
�������$	��200��6,   $��
0,10,0,183q�69    �� Orientation$ Vertical=�6M   .+�54      �� $��Center=�6   $��20(�67   $��0 0 0 0q�6E   $��Verdana)�55      ���#455A64$��Center=�6B   Generar reporte personalizado57      �� 58      $ 
Horizontal=�6   $��Center=�66   .+�59      �� $��	0 30 80 0q�6!   .+�5:      �� $ 
Horizontal=�6%   .+�5;      �� $��Center=�6)   $��10(�6D   $��0 0 0 0q�6R   $��Verdana)�5<   %   ���#455A64Fecha inicial (dia/mes/año)5>        5?      $��10��66   $��10��6B   $
 Flag=�6M   $��Center=�6Y   $��0 0 0 0q�6t   ���#455A646�   5@      (	  "System.Windows.Controls.DatePicker	  5A      -   5        $��FechaInicial��5A   %   ���#455A64$	��300��6N   5B      �� 5C      $��0 30 0 0q�6!   .+�5D      �� $ 
Horizontal=�6%   .+�5E      �� $��Center=�6)   $��10(�6D   $��0 0 0 0q�6R   $��Verdana)�6c   ���#455A64Fecha final (dia/mes/año)6�     5F      $��10��66   $��10��6B   $
 Flag=�6M   $��Center=�6Y   $��0 0 0 0q�6t   ���#455A646�   5G      	  5H      -   5        $��
FechaFinal��5H   &   ���#455A64$	��300��6M   5I      5J      �� 5K      -   5        $ GenerarReporte��5K      $��0 40 0 0q�61   $	��160��6C   .��5L      � .+�5M        $ 
FilePdfBox=�62   $��Center=�6D   $��0 0 7 0q�6_   �� 5N      $��14(�6$   Generar Reporte6C   5O      5P      5Q      5R      5S      5T      