﻿#pragma checksum "..\..\..\..\Views\Reportes\SubVReportes1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "077233D5F54C12BFA7E0AC6E573ED8592605081864C10EC8AD9B243B78E7AA05"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Dashboard_WPF.Views.Reportes;
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


namespace Dashboard_WPF.Views.Reportes {
    
    
    /// <summary>
    /// SubVReportes1
    /// </summary>
    public partial class SubVReportes1 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock buenDia;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid EnAlmacen;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGenerarPDF;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FechaInicial;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FechaFinal;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerarReporte;
        
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
            System.Uri resourceLocater = new System.Uri("/Dashboard_WPF;component/views/reportes/subvreportes1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
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
            this.buenDia = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.EnAlmacen = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.btnGenerarPDF = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
            this.btnGenerarPDF.Click += new System.Windows.RoutedEventHandler(this.btnGenerarPDF_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FechaInicial = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.FechaFinal = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.GenerarReporte = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\Views\Reportes\SubVReportes1.xaml"
            this.GenerarReporte.Click += new System.Windows.RoutedEventHandler(this.GenerarReporte_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

