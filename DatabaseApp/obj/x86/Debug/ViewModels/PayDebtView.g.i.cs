﻿

#pragma checksum "D:\Coursework\SDGP\DatabaseApp\DatabaseApp\ViewModels\PayDebtView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E94372D1F00D0BFDE681C8F49EFB1B94"
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
    partial class PayDebtView : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock dCashback_label; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBox dPayAmount_box; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.DatePicker dPayDate_box; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button dPay_btn; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button dPayBack_btn; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///ViewModels/PayDebtView.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            dCashback_label = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("dCashback_label");
            dPayAmount_box = (global::Windows.UI.Xaml.Controls.TextBox)this.FindName("dPayAmount_box");
            dPayDate_box = (global::Windows.UI.Xaml.Controls.DatePicker)this.FindName("dPayDate_box");
            dPay_btn = (global::Windows.UI.Xaml.Controls.Button)this.FindName("dPay_btn");
            dPayBack_btn = (global::Windows.UI.Xaml.Controls.Button)this.FindName("dPayBack_btn");
        }
    }
}


