   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Dashboard_WPF.Views.ClientesDashboard_WPF.Views.Clientes  5      0    *Dashboard_WPF.Views.Clientes.SubVClientes4   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Dashboard_WPF.Views.Clientes     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6@     N� Title$  SubVClientes4��5	      .��5
      �� -   5        $��Page1��5
       �� CornerRadius$ 15��6   ���#EFF2F7$	��420��6A   $	��870��6N   ._�5   
   � 
�������$	��420��6"   $	��810��6/    � RowDefinitions 5      �� 5      $��90 �6    �� 5      $	��180 �6    �� 5      $��90 �6    �� 5      $��90 �6    .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6&   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��35��6*   $��35��66      Kind$ AccountDetailsOutline=�6A   $��Center=�6^   $��7 0 0 0q�6y   �� 5      $��Center=�6   $��23(�68   $��10 0 0 0q�6F   $��Verdana)�6X   Información personal6�   �� 5      -   5        $��btnRegresar��5      $��	300 0 0 0q�6-    � Cursor$
 Hand��6A   .��5      � .+�5        $ ArrowLeftTopBold=�62   $��Center=�6J   $��0 0 7 0q�6e   �� 5      $��14(�6$   
Regresar6<   5      5      5      �� 5      $��1��6   $ Vertical=�6&   $	��350��6=   $	��Top=�6J   .+�5       �� $ 
Horizontal=�6   $��Center=�66   $��0,20,0,0q�6S   $	��768��6e   .+�5!      �� $��0 0 0 0q�6!   .+�5"      �� $ Vertical=�6%   $	��350��6<   .+�5#      �� $ 
Horizontal=�6)   .+�5$   "   �� $��Center=�6-   $��15(�6H   $��0 0 0 0q�6V   $��Verdana)�6g   
Número CI6�     5%   "   $��15��6:   $��15��6F   $
 Flag=�6Q   $��Center=�6]   $��0 0 0 0q�6x   5&      �� 5'      -   5         ��Name$ txtidCliente��5'   &   
���   �$
��auto��6O   $��0 7 0 0q�6\   6�   5(      5)      5*      �� 5-      $ 
Horizontal=�6   $��Center=�66   $��0,30,0,0q�6S   $	��768��6e   .+�5.      �� $��0 0 0 0q�6!   .+�5/      �� $ Vertical=�6%   $	��350��6<   .+�50      �� $ 
Horizontal=�6)   .+�51   "   �� $��Center=�6-   $��15(�6H   $��0 0 0 0q�6V   $��Verdana)�6g   	Nombres6�     52   "   $��15��6:   $��15��6F   $
 Flag=�6Q   $��Center=�6]   $��0 0 0 0q�6x   53      �� 54      -   5        $ txtNombreCliente��54   &   
���   �$
��Auto��6S   $��0 7 0 0q�6`   6�   55      56      �� 57      $��40 0 0 0q�6!   .+�58      �� $ Vertical=�6%   $	��350��6<   .+�59      �� $ 
Horizontal=�6)   .+�5:   "   �� $��Center=�6-   $��15(�6H   $��0 0 0 0q�6V   $��Verdana)�6g   	Apellidos6�     5;   "   $��15��6:   $��15��6F   $
 Flag=�6Q   $��Center=�6]   $��0 0 0 0q�6x   5<      �� 5=      -   5        $ txtApellidosCliente��5=   &   
���   �$
��auto��6V   $��0 10 0 0q�6c   6�   5>      5?      5@      5A      �� 5G      $��2��6   $��Center=�6&   .+�5H      �� $ 
Horizontal=�6   .+�5I      �� -   5         ��Name$ 
btnlimpiar��5I      $��0 0 0 0q�61   
�������.��5J      � .+�5K        $ Broom=�66   $��Center=�6C   $��0 0 7 0q�6^   �� 5L      $��14(�6(   	Limpiar6?   5M      5N      �� 5O      -   5        $ btnActualizarClientes��5O      $��20 0 0 0q�6<   .��5P      � .+�5Q        $ ContentSaveCheck=�66   $��Center=�6N   $��0 0 7 0q�6i   �� 5R      $��14(�6)   
Actualizar6C   5S      5T      5U      �� 5V      $ 
Horizontal=�6   $��0 20 0 0q�66   .+�5W      �� $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   Los campos marcados con6�     5X      $��15��6.   $��15��6:   $
 Flag=�6E   $��Center=�6Q   $��0 0 0 0q�6l   �� 5Y      $��Center=�6!   $��10(�6<   $��0 0 0 0q�6J   $��Verdana)�6[   son obligatorios6�   5Z      5[      5\      5]      5^      