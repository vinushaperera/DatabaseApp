﻿

#pragma checksum "D:\Coursework\SDGP\DatabaseApp\DatabaseApp\ViewModels\SavingsMainView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9570076C3189C05300F2533F3DD63E39"
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
    partial class SavingsMainView : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\..\ViewModels\SavingsMainView.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.OnItemClickHandler;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\..\ViewModels\SavingsMainView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.smBack_btn_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 15 "..\..\..\ViewModels\SavingsMainView.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.smNew_btn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


