﻿

#pragma checksum "D:\Coursework\SDGP\DatabaseApp\DatabaseApp\ViewModels\SavingsTransactions.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "890371892C1F8B858213C2EAEF2E0759"
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
    partial class SavingsTransactions : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 13 "..\..\..\ViewModels\SavingsTransactions.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.stransListView_ItemClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 14 "..\..\..\ViewModels\SavingsTransactions.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.stransBackBtn_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


