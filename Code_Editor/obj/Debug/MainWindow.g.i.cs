﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "940D4519F023EDD82679AF1284E7BD4B"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using Code_Editor;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Editing;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
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


namespace Code_Editor {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstFolder;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox oppoCombo;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Message;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SendTXT;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem New;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Open;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Save;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem SaveAs;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Exit;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Cut;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Paste;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Undo;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Redo;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Sett;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem digFont;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem addop;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem Trans;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ICSharpCode.AvalonEdit.TextEditor CodeEditor;
        
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
            System.Uri resourceLocater = new System.Uri("/Code_Editor;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 9 "..\..\MainWindow.xaml"
            ((Code_Editor.MainWindow)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 9 "..\..\MainWindow.xaml"
            ((Code_Editor.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lstFolder = ((System.Windows.Controls.ListView)(target));
            
            #line 65 "..\..\MainWindow.xaml"
            this.lstFolder.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.lstFolder_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.oppoCombo = ((System.Windows.Controls.ComboBox)(target));
            
            #line 88 "..\..\MainWindow.xaml"
            this.oppoCombo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.oppoCombo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Message = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.SendTXT = ((System.Windows.Controls.TextBox)(target));
            
            #line 90 "..\..\MainWindow.xaml"
            this.SendTXT.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.New = ((System.Windows.Controls.MenuItem)(target));
            
            #line 99 "..\..\MainWindow.xaml"
            this.New.Click += new System.Windows.RoutedEventHandler(this.NewItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Open = ((System.Windows.Controls.MenuItem)(target));
            
            #line 100 "..\..\MainWindow.xaml"
            this.Open.Click += new System.Windows.RoutedEventHandler(this.Open_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Save = ((System.Windows.Controls.MenuItem)(target));
            
            #line 102 "..\..\MainWindow.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SaveAs = ((System.Windows.Controls.MenuItem)(target));
            
            #line 103 "..\..\MainWindow.xaml"
            this.SaveAs.Click += new System.Windows.RoutedEventHandler(this.SaveAs_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Exit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 105 "..\..\MainWindow.xaml"
            this.Exit.Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.Cut = ((System.Windows.Controls.MenuItem)(target));
            
            #line 108 "..\..\MainWindow.xaml"
            this.Cut.Click += new System.Windows.RoutedEventHandler(this.Cut_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Paste = ((System.Windows.Controls.MenuItem)(target));
            
            #line 109 "..\..\MainWindow.xaml"
            this.Paste.Click += new System.Windows.RoutedEventHandler(this.Paste_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Undo = ((System.Windows.Controls.MenuItem)(target));
            
            #line 110 "..\..\MainWindow.xaml"
            this.Undo.Click += new System.Windows.RoutedEventHandler(this.Undo_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.Redo = ((System.Windows.Controls.MenuItem)(target));
            
            #line 111 "..\..\MainWindow.xaml"
            this.Redo.Click += new System.Windows.RoutedEventHandler(this.Redo_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.Sett = ((System.Windows.Controls.MenuItem)(target));
            
            #line 114 "..\..\MainWindow.xaml"
            this.Sett.Click += new System.Windows.RoutedEventHandler(this.Settings_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.digFont = ((System.Windows.Controls.MenuItem)(target));
            
            #line 115 "..\..\MainWindow.xaml"
            this.digFont.Click += new System.Windows.RoutedEventHandler(this.digFont_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.addop = ((System.Windows.Controls.MenuItem)(target));
            
            #line 116 "..\..\MainWindow.xaml"
            this.addop.Click += new System.Windows.RoutedEventHandler(this.addop_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.Trans = ((System.Windows.Controls.MenuItem)(target));
            
            #line 117 "..\..\MainWindow.xaml"
            this.Trans.Click += new System.Windows.RoutedEventHandler(this.Trans_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.CodeEditor = ((ICSharpCode.AvalonEdit.TextEditor)(target));
            
            #line 122 "..\..\MainWindow.xaml"
            this.CodeEditor.TextInput += new System.Windows.Input.TextCompositionEventHandler(this.CodeEditor_TextInput);
            
            #line default
            #line hidden
            
            #line 122 "..\..\MainWindow.xaml"
            this.CodeEditor.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CodeEditor_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

