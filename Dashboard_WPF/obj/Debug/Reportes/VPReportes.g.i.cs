﻿#pragma checksum "..\..\..\Reportes\VPReportes.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3A0708D875B599ED968E7D9714A2168F0F97907654D485AF50FA330FCFFA9263"
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
    /// VPReportes
    /// </summary>
    public partial class VPReportes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Reportes\VPReportes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Page1;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Reportes\VPReportes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReporteGeneral;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Reportes\VPReportes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReporteInven;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Reportes\VPReportes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReporteCosto;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Reportes\VPReportes.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Dashboard_WPF;component/reportes/vpreportes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reportes\VPReportes.xaml"
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
            this.btnReporteGeneral = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Reportes\VPReportes.xaml"
            this.btnReporteGeneral.Click += new System.Windows.RoutedEventHandler(this.btnReporteGeneral_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnReporteInven = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Reportes\VPReportes.xaml"
            this.btnReporteInven.Click += new System.Windows.RoutedEventHandler(this.btnReporteInven_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnReporteCosto = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Reportes\VPReportes.xaml"
            this.btnReporteCosto.Click += new System.Windows.RoutedEventHandler(this.btnReporteCosto_Click);
            
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
