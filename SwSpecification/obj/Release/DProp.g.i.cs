﻿#pragma checksum "..\..\DProp.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4BD437EF77234687BF230DE0AF8D65BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace SWPlus {
    
    
    /// <summary>
    /// DProp
    /// </summary>
    public partial class DProp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\DProp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal SWPlus.DProp DPropForm;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\DProp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CmdCancel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\DProp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CmdAllScale;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DProp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CmdScale;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DProp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ChkScale;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DProp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CboScale;
        
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
            System.Uri resourceLocater = new System.Uri("/SwSpecification;component/dprop.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DProp.xaml"
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
            this.DPropForm = ((SWPlus.DProp)(target));
            
            #line 4 "..\..\DProp.xaml"
            this.DPropForm.Loaded += new System.Windows.RoutedEventHandler(this.DPropForm_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CmdCancel = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\DProp.xaml"
            this.CmdCancel.Click += new System.Windows.RoutedEventHandler(this.CmdCancel_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CmdAllScale = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\DProp.xaml"
            this.CmdAllScale.Click += new System.Windows.RoutedEventHandler(this.CmdAllScale_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CmdScale = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\DProp.xaml"
            this.CmdScale.Click += new System.Windows.RoutedEventHandler(this.CmdScale_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChkScale = ((System.Windows.Controls.CheckBox)(target));
            
            #line 18 "..\..\DProp.xaml"
            this.ChkScale.Checked += new System.Windows.RoutedEventHandler(this.ChkScale_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CboScale = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
