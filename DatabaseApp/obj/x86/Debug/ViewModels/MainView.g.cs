﻿

#pragma checksum "D:\Coursework\SDGP\DatabaseApp\DatabaseApp\ViewModels\MainView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "75DE530FB9059ACFD609F4F18F315C2C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseApp.ViewModels
{
    partial class MainView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 19 "..\..\..\ViewModels\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.mainview_transaction_btn_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 20 "..\..\..\ViewModels\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.mainview_list_btn_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 21 "..\..\..\ViewModels\MainView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.mainview_more_btn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

