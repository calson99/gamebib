﻿#pragma checksum "D:\school\gameBib\gameBib\AddGameWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E9AADE0B185EF2CA2A546C13948F387B267B3E9983E2BB64281531E7E85093E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gameBib
{
    partial class AddGameWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // AddGameWindow.xaml line 54
                {
                    global::Microsoft.UI.Xaml.Controls.Button element2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Button>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Button)element2).Click += this.AddGame_Click;
                }
                break;
            case 3: // AddGameWindow.xaml line 51
                {
                    this.dpReleaseDate = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DatePicker>(target);
                }
                break;
            case 4: // AddGameWindow.xaml line 38
                {
                    this.lbGenres = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListBox>(target);
                }
                break;
            case 7: // AddGameWindow.xaml line 22
                {
                    this.cmbRating = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ComboBox>(target);
                }
                break;
            case 8: // AddGameWindow.xaml line 17
                {
                    this.txtGameName = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2306")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

