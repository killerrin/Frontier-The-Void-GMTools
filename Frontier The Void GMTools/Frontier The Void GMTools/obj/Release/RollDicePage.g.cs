﻿#pragma checksum "..\..\RollDicePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "96C71D1C51AF379E858B1290F103B92E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Frontier_The_Void_GMTools;
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


namespace Frontier_The_Void_GMTools {
    
    
    /// <summary>
    /// RollDicePage
    /// </summary>
    public partial class RollDicePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\RollDicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numberOfDiceTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\RollDicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sidesOnDiceTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\RollDicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button rollDiceButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\RollDicePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox rolledNumbers;
        
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
            System.Uri resourceLocater = new System.Uri("/Frontier The Void GMTools;component/rolldicepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RollDicePage.xaml"
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
            this.numberOfDiceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\RollDicePage.xaml"
            this.numberOfDiceTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 19 "..\..\RollDicePage.xaml"
            this.numberOfDiceTextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 2:
            this.sidesOnDiceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\RollDicePage.xaml"
            this.sidesOnDiceTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 22 "..\..\RollDicePage.xaml"
            this.sidesOnDiceTextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 3:
            this.rollDiceButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\RollDicePage.xaml"
            this.rollDiceButton.Click += new System.Windows.RoutedEventHandler(this.rollDiceButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rolledNumbers = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

