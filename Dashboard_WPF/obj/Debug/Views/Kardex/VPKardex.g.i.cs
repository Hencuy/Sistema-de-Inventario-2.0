﻿#pragma checksum "..\..\..\..\Views\Kardex\VPKardex.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "55FBBBD0F065016B3BE3781C6D337C2627E9AE6F452952768FCDD210B9A28FC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Dashboard_WPF.Views.Kardex;
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


namespace Dashboard_WPF.Views.Kardex {
    
    
    /// <summary>
    /// VPKardex
    /// </summary>
    public partial class VPKardex : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\Kardex\VPKardex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Page1;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Views\Kardex\VPKardex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKardexGeneral;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Views\Kardex\VPKardex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBuscarKardex;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Views\Kardex\VPKardex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKardexProducto;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Views\Kardex\VPKardex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameProveedores;
        
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
            System.Uri resourceLocater = new System.Uri("/Dashboard_WPF;component/views/kardex/vpkardex.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Kardex\VPKardex.xaml"
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
            this.btnKardexGeneral = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Views\Kardex\VPKardex.xaml"
            this.btnKardexGeneral.Click += new System.Windows.RoutedEventHandler(this.btnKardexGeneral_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnBuscarKardex = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Views\Kardex\VPKardex.xaml"
            this.btnBuscarKardex.Click += new System.Windows.RoutedEventHandler(this.btnBuscarKardex_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnKardexProducto = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\Views\Kardex\VPKardex.xaml"
            this.btnKardexProducto.Click += new System.Windows.RoutedEventHandler(this.btnKardexProducto_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FrameProveedores = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

