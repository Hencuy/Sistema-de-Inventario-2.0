   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Dashboard_WPF.Views.UsuariosDashboard_WPF.Views.Usuarios  5      /    )Dashboard_WPF.Views.Usuarios.SubVUsuario2   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Dashboard_WPF.Views.Usuarios     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  SubVUsuario2��5
       � 	Resources 5         DataGridColumnHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value��%�   &	        �� 5   
   "  62   .�5      ��  � �� �#2D43566+   �� 5       � ��
 �����6+   �� 5       � ��$ Center=�6;   5      5      .��5      � 
�������$	��420��6   $	��870��6+   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUsuarios��5         AutoGenerateColumns .     CanUserAddRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 #��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 64      HeaderStyle# [  6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6w   �� *Number+  5      $	 CI��6)   $
 * 65   # [  6?    6x   �� *CI+  5      $	 Nombre��6)   $
 * 69   # [  6C    6|   �� *Nombre+  5      $	 	Apellidos��6)   $
 * 6<   # [  6F    6   �� *	Apellidos+  5      $	 Cargo��6)   $
 * 68   # [  6B    6{   �� *Cargo+  5       $	 UserName��6)   $
 * 6;   # [  6E    6~   �� *
UserName+  5!      $	 Contraseña��6)   $
 * 6=   # [  6G    6�   �� *Contraseña+  5"      $	 Estado��6)   $
 * 69   # [  6C    6|   �� *Estado+4  .System.Windows.Controls.DataGridTemplateColumn  5$      $	 
Actualizar��6-   $
 * 6A   # [  6K      CellTemplate 5%      �� 5&      .R�5'   "   �� -   5        .��5(   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Pencil=�6>   $��16��6L   $��16��6X   $��Center=�6c   $��0 0 0 0q�6~   5)   #   5*      5,        5/      $	 Eliminar��6-   $
 * 6?   # [  6I    50      �� 51      .R�52   "   �� -   5        .��53   &     $ Delete=�6>   $��16��6L   $��16��6X   $��Center=�6c   $��0 0 0 0q�6~   54   #   55      57      59      5:      5;      