   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Dashboard_WPF.Views.CategoriasDashboard_WPF.Views.Categorias  5      8    2Dashboard_WPF.Views.Categorias.ActualizarCategoria   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Dashboard_WPF.Views.Categorias     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6B   -   5          N� Title$  ActualizarCategoria��5	      .��5      � 
�������$	��420��6   $	��870��6+    � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      $	��100 �6   6+   �� 5      $	��140 �6   6+   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��15,0,0,0q�6;   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  $��35��6&   $��35��62      Kind$ InformationCircleOutline=�6=   $��Center=�6]   $��7 0 0 0q�6x   �� 5      $��Center=�6   $��23(�64   $��10 0 0 0q�6B   $��Verdana)�6T   Información de la categoría6�   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0,10,0,0q�6;   .+�5      �� $��30 0 0 0q�6   .+�5      �� $ Vertical=�6   .+�5      �� $ 
Horizontal=�6!   .+�5      �� $��Center=�6%   $��15(�6@   $��0 0 0 0q�6N   $��Verdana)�6_   Nombre categoría6�     5      $��15��62   $��15��6>   $
 Flag=�6I   $��Center=�6U   $��0 0 0 0q�6p   5      �� 5      -   5         ��Name$ 	txtNombre��5      
���   �$	��260��6D   $��0 7 0 0q�6P   6d   5      5      �� 5      $��20 0 0 0q�6   $ Vertical=�6+   .+�5       �� $ Vertical=�6   .+�5!      �� $ 
Horizontal=�6!   .+�5"      �� $��Center=�6%   $��15(�6@   $��0 0 0 0q�6N   $��Verdana)�6_   #!Pasillo o ubicación del producto6�     5#      $��15��62   $��15��6>   $
 Flag=�6I   $��Center=�6U   $��0 0 0 0q�6p   5$      �� 5%      -   5        $ txtUbicacion��5%      
���   �$	��260��6G   $��0 7 0 0q�6S   6f   5&      5'      �� 5(      $��20 0 0 0q�6   $ Vertical=�6+   .+�5)      �� $ Vertical=�6   .+�5*      �� $ 
Horizontal=�6!   .+�5+      �� $��Center=�6%   $��15(�6@   $��0 0 0 0q�6N   $��Verdana)�6_   Estado de la categoría6�     5,      $��15��62   $��15��6>   $
 Flag=�6I   $��Center=�6U   $��0 0 0 0q�6p   5-      �� 5.      -   5         ��Name$ ComboEstado��5.      $	��230��64   $��0 10 0 0q�6@    �� SelectedIndex$ 0��6R   .@�5/      �� .��6'   Desabilitado65   �� 50      .��6'   
Habilitado63   51      52      53      54      �� 55   
   -   5        $��btnRegresar��55      $��732,18,10,30q�6%    � Cursor$
 Hand��6<   .��56      � .+�57        $ ArrowLeftTopBold=�6*   $��Center=�6B   $��0 0 7 0q�6]   �� 58      $��14(�6   
Regresar64   59      5:      �� 5;   
   $��2��6   $��Center=�6"   $��Center=�6?   .+�5<      �� $ 
Horizontal=�6   .+�5=      �� -   5        $��btnActualizar��5=      $��20 0 0 0q�6.   ���	#FF21F339���	#FF21F339.��5>      � .+�5?        $ Pencil=�62   $��Center=�6@   $��0 0 7 0q�6[   �� 5@      $��14(�6$   
Actualizar6>   5A      5B      5D      �� 5E      $ 
Horizontal=�6   $��0 20 0 0q�62   5F      5G      5H      