﻿#pragma checksum "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2ACF87F6116E3176737C2461BA7FCC96293BBA8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KursCode.MVVM.View.UserControls;
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


namespace KursCode.MVVM.View.Windows.Dialog {
    
    
    /// <summary>
    /// AddWorker
    /// </summary>
    public partial class AddWorker : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridContainer;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse closeEllipse;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border imageBorder;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image selectedImage;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon photoIcon;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel SkillsWrapPanel;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel QualitiesWrapPanel;
        
        #line default
        #line hidden
        
        
        #line 235 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock errorText;
        
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
            System.Uri resourceLocater = new System.Uri("/KursCode;V1.0.0.0;component/mvvm/view/windows/dialog/addworker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
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
            this.gridContainer = ((System.Windows.Controls.Grid)(target));
            
            #line 21 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
            this.gridContainer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.closeApp_MauseLeftButtonDrag);
            
            #line default
            #line hidden
            return;
            case 2:
            this.closeEllipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 3:
            this.imageBorder = ((System.Windows.Controls.Border)(target));
            
            #line 78 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
            this.imageBorder.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ImageBorder_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.selectedImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.photoIcon = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            return;
            case 6:
            this.SkillsWrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 7:
            
            #line 110 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addSkillButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.QualitiesWrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 9:
            
            #line 118 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.addQualityButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.errorText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            
            #line 246 "..\..\..\..\..\..\..\MVVM\View\Windows\Dialog\AddWorker.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.last_button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

