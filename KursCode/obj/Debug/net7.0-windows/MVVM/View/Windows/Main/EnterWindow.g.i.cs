﻿#pragma checksum "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2F98E7B64514FBD9D9BF40803269F16D5096FC3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KursCode.MVVM.ViewModel;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace KursCode.View.Windows.Main {
    
    
    /// <summary>
    /// EnterWindow
    /// </summary>
    public partial class EnterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridContainer;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse closeEllipse;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid collapseButtonContainer;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse collapseEllipse;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EnterButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KursCode;component/mvvm/view/windows/main/enterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.13.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
            ((KursCode.View.Windows.Main.EnterWindow)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.drugWindow_LeftButtonDrag);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridContainer = ((System.Windows.Controls.Grid)(target));
            
            #line 25 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
            this.gridContainer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.closeApp_MauseLeftButtonDrag);
            
            #line default
            #line hidden
            return;
            case 3:
            this.closeEllipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            this.collapseButtonContainer = ((System.Windows.Controls.Grid)(target));
            
            #line 49 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
            this.collapseButtonContainer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.collapseApp_MauseLeftButtonDrag);
            
            #line default
            #line hidden
            return;
            case 5:
            this.collapseEllipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 6:
            
            #line 96 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
            ((System.Windows.Controls.PasswordBox)(target)).PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.EnterButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            
            #line 128 "..\..\..\..\..\..\..\MVVM\View\Windows\Main\EnterWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.TextBlock_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

