   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Dashboard_WPF.Views.ProductosDashboard_WPF.Views.Productos  5      2    ,Dashboard_WPF.Views.Productos.Sub_MasVendido   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Dashboard_WPF.Views.Productos     5        N� Title$  Sub_MasVendido��5	       � 	Resources 5         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value2   ,Dashboard_WPF.Views.Productos.ImageConverter  ImageConverter��%�   &	        &	 �     �� 5   
   "  62   .�5      ��  � �� �#2D43566+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   5        5   
   6   5      .��5      � 
�������$	��420��6   $	��920��6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
Categorias��5         AutoGenerateColumns .     CanUserAddRows .     	CellStyle 5      �� 5      *  $System.Windows.Controls.DataGridCell"  6   .�5      ��  � ��$ Center=�6<   �� 5       � ��$ Center=�6:   5      	   Columns	 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Total Vendido��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6@      CellTemplate 5      �� 5      .R�5       �� 
���   ���6(   �� *TotalVendido+6F   5!      5#        5$      $

 Foto��6)   $
 auto 67    5%      �� 5&      .R�5'      �� $��50��6$   $��50��6/   ��5(   "   �� 5)   &    �� Path$
 Foto�6.    �� 	Converter# [ 6:   5+      5,      5.        50      $
 Código de Barra��6)   $
 auto 6B    51      �� 52      .R�53      �� 
���   ���6(   �� *CodigoBarra+6E   54      56        57      $
 Nombre��6)   $
 auto 69    58      �� 59      .R�5:      �� 
���   ���6(   �� *Nombre+6@   5;      5=        5>      $
 Presentación��6)   $
 auto 6?    5?      �� 5@      .R�5A      �� 
���   ���6(   �� *Presentacion+6F   5B      5D        5E      $
 Marca��6)   $
 auto 68    5F      �� 5G      .R�5H      �� 
���   ���6(   �� *Marca+6?   5I      5K        5L      $
 Modelo��6)   $
 auto 69    5M      �� 5N      .R�5O      �� 
���   ���6(   �� *Modelo+6@   5P      5R        5S      $
 Stock en Existencia��6)   $
 auto 6F    5T      �� 5U      .R�5V      �� 
���   ���6(   �� *StockExistencia+6I   5W      5Y        5Z      $
 Stock Mínimo��6)   $
 auto 6?    5[      �� 5\      .R�5]      �� 
���   ���6(   �� *StockMinimo+6E   5^      5`        5a      $
 Precio de Compra��6)   $
 auto 6C    5b      �� 5c      .R�5d      �� 
���   ���6(   �� *PrecioCompra+6F   5e      5g        5h      $
 Precio de Venta��6)   $
 auto 6B    5i      �� 5j      .R�5k      �� 
���   ���6(   �� *PrecioVenta+6E   5l      5n        5o      $
 Precio al Mayoreo��6)   $
 auto 6D    5p      �� 5q      .R�5r      �� 
���   ���6(   �� *PrecioMayoreo+6G   5s      5u        5v      $
 	Descuento��6)   $
 auto 6<    5w      �� 5x      .R�5y      �� 
���   ���6(   �� *	Descuento+6C   5z      5|        5}      $
 Tiene Vencimiento��6)   $
 auto 6D    5~      �� 5      .R�5�      �� 
���   ���6(   �� *TieneVencimiento+6J   5�      5�        5�      $
 Fecha de Vencimiento��6)   $
 auto 6G    5�      �� 5�      .R�5�      �� 
���   ���6(   �� *FechaVencimiento+6J   5�      5�        5�      $
 Estado��6)   $
 auto 69    5�      �� 5�      .R�5�      �� 
���   ���6(   �� *Estado+6@   5�      5�      5�      5�      5�      