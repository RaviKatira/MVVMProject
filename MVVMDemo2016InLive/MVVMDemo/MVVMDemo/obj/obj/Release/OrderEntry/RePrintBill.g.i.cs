﻿#pragma checksum "..\..\..\OrderEntry\RePrintBill.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DCE0C882E4F0857F966316425C1C19A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MVVMDemo;
using OPSMain.OrderEntry;
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


namespace OPSMain.OrderEntry {
    
    
    /// <summary>
    /// RePrintBill
    /// </summary>
    public partial class RePrintBill : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\OrderEntry\RePrintBill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRePrintBillNo;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\OrderEntry\RePrintBill.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrint;
        
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
            System.Uri resourceLocater = new System.Uri("/ShreeDashamaStores;component/orderentry/reprintbill.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\OrderEntry\RePrintBill.xaml"
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
            
            #line 9 "..\..\..\OrderEntry\RePrintBill.xaml"
            ((OPSMain.OrderEntry.RePrintBill)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRePrintBillNo = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\..\OrderEntry\RePrintBill.xaml"
            this.txtRePrintBillNo.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.txtRePrintBillNo_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\OrderEntry\RePrintBill.xaml"
            this.txtRePrintBillNo.GotMouseCapture += new System.Windows.Input.MouseEventHandler(this.txtRePrintBillNo_GotMouseCapture);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPrint = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

