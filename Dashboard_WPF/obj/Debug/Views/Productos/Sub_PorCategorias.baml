   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Dashboard_WPF.Views.ProductosDashboard_WPF.Views.Productos  5      5    /Dashboard_WPF.Views.Productos.Sub_PorCategorias   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Dashboard_WPF.Views.Productos     5      -   5          N� Title$  Sub_PorCategorias��5	       � 	Resources 5
         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value2   ,Dashboard_WPF.Views.Productos.ImageConverter  ImageConverter��%�   &	        &	 �     �� 5   
   "  62   .�5      ��  � �� �#2D43566+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   5        5   
   6   5      .��5      � 
�������$	��420��6   $	��920��6+   .+�5   
   �� $	��Top=�6   $��15(�6-   $��10,21,685,0q�6;   $��Verdana)�6P   Seleccionar categoría:6}   �� 5   
   -   5         ��Name$ ComboboxCategorias��5      $	��230��6/   $��192,19,498,0q�6;    �� SelectedIndex$ 0��6Q   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
Categorias��5         AutoGenerateColumns .  	   CanUserAddRows	 .  $��0,60,0,0q�6Z   
   	CellStyle
 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6   .�5      ��  � ��$ Center=�6<   �� 5       � ��$ Center=�6:   5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Foto��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 67      CellTemplate 5       �� 5!      .R�5"      �� $��50��6$   $��50��6/   ��5#   "   �� 5$   &    �� Path$
 Foto�6.    �� 	Converter# [ 6:   5&      5'      5)        5+      $ Código de Barra��6)   $
 auto 6B    5,      �� 5-      .R�5.      �� 
���   ���6(   �� *CodigoBarra+6E   5/      51        52      $ Nombre��6)   $
 auto 69    53      �� 54      .R�55      �� 
���   ���6(   �� *Nombre+6@   56      58        59      $ Presentación��6)   $
 auto 6?    5:      �� 5;      .R�5<      �� 
���   ���6(   �� *Presentacion+6F   5=      5?        5@      $ Marca��6)   $
 auto 68    5A      �� 5B      .R�5C      �� 
���   ���6(   �� *Marca+6?   5D      5F        5G      $ Modelo��6)   $
 auto 69    5H      �� 5I      .R�5J      �� 
���   ���6(   �� *Modelo+6@   5K      5M        5N      $ Stock en Existencia��6)   $
 auto 6F    5O      �� 5P      .R�5Q      �� 
���   ���6(   �� *StockExistencia+6I   5R      5T        5U      $ Stock Mínimo��6)   $
 auto 6?    5V      �� 5W      .R�5X      �� 
���   ���6(   �� *StockMinimo+6E   5Y      5[        5\      $ Precio de Compra��6)   $
 auto 6C    5]      �� 5^      .R�5_      �� 
���   ���6(   �� *PrecioCompra+6F   5`      5b        5c      $ Precio de Venta��6)   $
 auto 6B    5d      �� 5e      .R�5f      �� 
���   ���6(   �� *PrecioVenta+6E   5g      5i        5j      $ Precio al Mayoreo��6)   $
 auto 6D    5k      �� 5l      .R�5m      �� 
���   ���6(   �� *PrecioMayoreo+6G   5n      5p        5q      $ 	Descuento��6)   $
 auto 6<    5r      �� 5s      .R�5t      �� 
���   ���6(   �� *	Descuento+6C   5u      5w        5x      $ Tiene Vencimiento��6)   $
 auto 6D    5y      �� 5z      .R�5{      �� 
���   ���6(   �� *TieneVencimiento+6J   5|      5~        5      $ Fecha de Vencimiento��6)   $
 auto 6G    5�      �� 5�      .R�5�      �� 
���   ���6(   �� *FechaVencimiento+6J   5�      5�        5�      $ Estado��6)   $
 auto 69    5�      �� 5�      .R�5�      �� 
���   ���6(   �� *Estado+6@   5�      5�      5�      5�      5�      