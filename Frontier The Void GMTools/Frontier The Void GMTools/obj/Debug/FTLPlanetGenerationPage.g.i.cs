﻿#pragma checksum "..\..\FTLPlanetGenerationPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5F727D7547290CB25FEC6D33F653D10F"
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
    /// FTLPlanetGenerationPage
    /// </summary>
    public partial class FTLPlanetGenerationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hexXCoordinateTextBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox hexYCoordinateTextBox;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox planetaryGenerationRoll1TextBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox planetaryGenerationRoll2TextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ftlRoll1TextBox;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ftlRoll2TextBox;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ftlExplorerCheckbox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox seedHexCheckBox;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox seedPlanetaryGenerationCheckBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox seedFTLCheckBox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\FTLPlanetGenerationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox generatedPlanets;
        
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
            System.Uri resourceLocater = new System.Uri("/Frontier The Void GMTools;component/ftlplanetgenerationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FTLPlanetGenerationPage.xaml"
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
            this.hexXCoordinateTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\FTLPlanetGenerationPage.xaml"
            this.hexXCoordinateTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 24 "..\..\FTLPlanetGenerationPage.xaml"
            this.hexXCoordinateTextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 2:
            this.hexYCoordinateTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\FTLPlanetGenerationPage.xaml"
            this.hexYCoordinateTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 27 "..\..\FTLPlanetGenerationPage.xaml"
            this.hexYCoordinateTextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 3:
            this.planetaryGenerationRoll1TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\FTLPlanetGenerationPage.xaml"
            this.planetaryGenerationRoll1TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 39 "..\..\FTLPlanetGenerationPage.xaml"
            this.planetaryGenerationRoll1TextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 4:
            this.planetaryGenerationRoll2TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\FTLPlanetGenerationPage.xaml"
            this.planetaryGenerationRoll2TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 43 "..\..\FTLPlanetGenerationPage.xaml"
            this.planetaryGenerationRoll2TextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 46 "..\..\FTLPlanetGenerationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PlanetaryGenerationRoll);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ftlRoll1TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\FTLPlanetGenerationPage.xaml"
            this.ftlRoll1TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 53 "..\..\FTLPlanetGenerationPage.xaml"
            this.ftlRoll1TextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 7:
            this.ftlRoll2TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\FTLPlanetGenerationPage.xaml"
            this.ftlRoll2TextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CheckNumbersOnly_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 57 "..\..\FTLPlanetGenerationPage.xaml"
            this.ftlRoll2TextBox.AddHandler(System.Windows.DataObject.PastingEvent, new System.Windows.DataObjectPastingEventHandler(this.TextBoxPaste_CheckNumbers));
            
            #line default
            #line hidden
            return;
            case 8:
            this.ftlExplorerCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            
            #line 60 "..\..\FTLPlanetGenerationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.FTLGenerationRoll);
            
            #line default
            #line hidden
            return;
            case 10:
            this.seedHexCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 11:
            this.seedPlanetaryGenerationCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 12:
            this.seedFTLCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 13:
            
            #line 76 "..\..\FTLPlanetGenerationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateButtonClicked);
            
            #line default
            #line hidden
            return;
            case 14:
            this.generatedPlanets = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

