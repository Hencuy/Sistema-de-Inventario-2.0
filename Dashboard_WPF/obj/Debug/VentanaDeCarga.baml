   M S B A M L   `   `   `  ����H  DDashboard_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Dashboard_WPFDashboard_WPF  5   	   "    Dashboard_WPF.VentanaDeCarga   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Dashboard_WPF     5   	   -   5          � Title$  VentanaDeCarga��5   	   $	��450��6    $	��730��6-    � WindowStyle$
 None=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency .    WindowStyle1#���   5      .��5      �� ._�5   
   � -   5        $��Inicio��5       K� ZIndex$ 3��6   $y�Visible=�6.    � Cursor$  ��6C    � 	Resources 5       �� 
TargetType	 �� Property
 �� Value-  'System.Windows.Media.Effects.BlurEffect   Radius��%|   '��       �� 5      " ��6   .�5      �� 	 �@J�Effect
 5        5      $ 5Q�6)   5      5      5      .+�5      ��  �� CornerRadius$ 10��6   $��2q�6'   
���   �
���   �$��64,19,76,19q�6b    J� Opacity$	 0.6Q�6w   � 5      $��10,0,0,0q�6   ��5      �� 5       �� ImageSource$+ %/recursos/imagen/VentanaPrincipal.png��6!   .+�5      �� -   5        $��
lblMensaje��5      $��
BIENVENIDO��6*   $��72(�6?   $��
199,20,0,0q�6M     LabelStyle1#���  6a   ���	#FF5FBDFF6�   �� 5      -   5         ��Name$ txtCargarNombre��5      $��NOMBRE��61   #���  6B   $��360,156,0,0q�6h   
���   �6}   �� 5       -   5        $ txtCargarApellido��5       $��	APELLIDOS��63   #���  6G   $��467,156,0,0q�6m   
���   �6�   �� 5!      -   5        $ txtCargo��5!      $��CARGO: ��6*   
���   �#���  6O   $��270,223,0,0q�6u   �� 5"      -   5        $ txtCargarCargos��5"      $��CARGOS USUARIO��61   
���   �#���  6]   $��409,223,0,0q�6�   � 5#      $��0 20 0 0q�6   .+�5$      � -   5         �Name$ ProgressBarCarga��5$   "    � Minimum$ 0Q�6<    � Maximum$ 10Q�6H    � Value$ 0Q�6U   $��Center=�6_   $	��Top=�6|   $	��484��6�   $��28��6�   $��	0,301,0,0q�6�   ��5%      �� 5&       �� EndPoint$ 0.5,1&�62    �� 
StartPoint$ 0.5,0&�6C   .��5'   "   �  � Color$ #5FBDFF��6/    � Offset$ 0Q�6?   � 5(   "   $ #5FBDFF��6/   $ 1Q�6?   5)      5+      �� 5,      $��Center=�6    $	��Top=�6=   $��16(�6U   $
��Bold"�6c   
�������$��	0,304,0,0q�6�   �� 5-      �6   ��  �� ElementName$ ProgressBarCarga�� �� Path$ Value� �� 5.      $	� / ��6    �� 5/      �6   �� $ ProgressBarCarga��$ Maximum�50      51      �� 52      -	   5        $ txtCargo_Copiar��52      $��NOMBRE: ��61   
���   �#���  6W   $��214,156,0,0q�6}   54      55      56      57      