﻿#pragma checksum "..\..\VentanaDeCarga.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8EE590A02A5A0507C49A46C9AA5F92179334B6E3A3EA0391F0B1F9FC266165C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Dashboard_WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Dashboard_WPF {
    
    
    /// <summary>
    /// VentanaDeCarga
    /// </summary>
    public partial class VentanaDeCarga : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Inicio;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMensaje;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtCargarNombre;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtCargarApellido;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtCargo;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtCargarCargos;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ProgressBarCarga;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\VentanaDeCarga.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txtCargo_Copiar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Dashboard_WPF;component/ventanadecarga.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VentanaDeCarga.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\VentanaDeCarga.xaml"
            ((Dashboard_WPF.VentanaDeCarga)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MOVER);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Inicio = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.lblMensaje = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.txtCargarNombre = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtCargarApellido = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.txtCargo = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.txtCargarCargos = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.ProgressBarCarga = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 9:
            this.txtCargo_Copiar = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

