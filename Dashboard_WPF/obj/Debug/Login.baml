   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Dashboard_WPFDashboard_WPF  5          Dashboard_WPF.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -localclr-namespace:Dashboard_WPF     5      -   5        $	��600��5      $	��850��6     � WindowStyle$
  None=�5	       � 
ResizeMode$ NoResize=�5
       � WindowStartupLocation$ CenterScreen=�5       � AllowsTransparency .    WindowStyle1#���   5      .��5      ��  �� CornerRadius$ 12��6     BorderStyle1#���  6   ��6F   Z� ._�5   
   � -   5        $��Inicio��5       K� ZIndex$ 3��6   $y�Visible=�6.    � Cursor$  ��6C    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value-  'System.Windows.Media.Effects.BlurEffect   Radius��%|   '��       �� 5      " ��6   .�5      �� 	 �@J�Effect
 5        5      $ 3Q�6)   5      5      5      .+�5      �� $+��%/recursos/imagen/VentanaPrincipal.png��6   $��	-2,0,0,-6q�6C    J� RenderTransformOrigin$ 0.5,0.5&�6V   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ -0.217Q�6(   �� 5      T� 5       T� X$ 1.196Q�6-   5       5"      �� 5#      $ 10��6   $��2q�6'   $��45,78,446,75q�6;   ��5$      �� 5%       �� ImageSource$% /recursos/imagen/ImagenCel1.png��6!   5'      �� 5(      $��INICIO DE SESION��6   $��40(�6/   
���   �$��498,173,65,363q�6P   $��Impact)�6h   �� 5)      $��Username��6   ���	#FF5FBDFF$��20(�6?   $��Medium"�6M   $��
Montserrat)�6a   $��509,267,65,302q�6y   �� 5*      -   5         ��Name$ 
txtusuario��5*      $��509,297,65,269q�5+      $��13(�5,      $��Medium"�5-      $��
Montserrat)�5.      
���   � �� 
CaretBrush
 ��������	#FF5FBDFF$��0,0,0,2q�52      $��28��53      $��Center=�54      $
 Hand��67   .��6E   ��55      �� 56      .��57   &   58      �� 59      $��Password��6   ���	#FF5FBDFF$��20(�6?   $��Medium"�6M   $��
Montserrat)�6a   $��509,344,65,225q�6y   $	��270��6�   G� 5:      -   5         G�Name$ txtPass��5:      $��509,369,65,197q�6,   $��15(�6D   $��Medium"�6R   $��
Montserrat)�6f   
���   � G� 
CaretBrush
 ��������	#FF5FBDFF$��0,0,0,2q�6�   $��28��6�   $��Center=�6�   
������ $	��270��6;  �� 5;      -   5         ��Name$ btnLogin��5;      $��0q�5<      $��INGRESAR��5=      
�������$��20(�5?      $��
Montserrat)�5@      $
 Hand��5A      $��545,420,0,134q�5B      $	��198��6C   $
��Left=�6O   ��5C      �� 5D      " ��6   .�5E      �� 	 � ��
 �#5FBDFF67    �� Triggers 5F      P� 5G       P� Property �@J�IsMouseOver P� Value . . �5H   "   �� 	 � ��
 �	#FF103ABE6?   5I      5K      ��5M      �� 5N       �� 
TargetType" ��6&   .R�5O      �� $	��300��6!   $��40��6-   $ 1��69   #��z��6J   ._�5P      �� $��Center=�6/   $
��Left=�6J   $��20��6e   $��98��6q   $��52,0,0,0q�6|   5Q      5R      5T      �� 5U      $
��Left=�6   $��28��6/   $��476,369,0,0q�6;   $	��Top=�6P   $��30��6h   $!��/recursos/imagen/cerrar.png��6s   �� 5V      $
��Left=�6   $��28��6/   $��479,297,0,0q�6;   $	��Top=�6P   $��25��6h   $%��/recursos/imagen/usuario(3).png��6s   5W      5X      5Y      