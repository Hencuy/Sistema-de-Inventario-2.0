﻿#pragma checksum "..\..\..\..\Views\Clientes\VPClientes.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E8634141CD60B3CE1F3E99C3A0F88A3943BB53AC83D67E41ED1825FC9C4D524D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Dashboard_WPF.Views.Clientes;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Dashboard_WPF.Views.Clientes {
    
    
    /// <summary>
    /// VPClientes
    /// </summary>
    public partial class VPClientes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\Clientes\VPClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Page1;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\Clientes\VPClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button C1;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Views\Clientes\VPClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button C2;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Views\Clientes\VPClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button C3;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Views\Clientes\VPClientes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameClientes;
        
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
            System.Uri resourceLocater = new System.Uri("/Dashboard_WPF;component/views/clientes/vpclientes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Clientes\VPClientes.xaml"
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
            this.Page1 = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.C1 = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\Views\Clientes\VPClientes.xaml"
            this.C1.Click += new System.Windows.RoutedEventHandler(this.CL1_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.C2 = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\Views\Clientes\VPClientes.xaml"
            this.C2.Click += new System.Windows.RoutedEventHandler(this.CL2_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.C3 = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\Views\Clientes\VPClientes.xaml"
            this.C3.Click += new System.Windows.RoutedEventHandler(this.CL3_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FrameClientes = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

