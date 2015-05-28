using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace GiveItBack.Pages
{
    public partial class AddMemberPage : UserControl
    {
        public AddMemberPage()
        {
            InitializeComponent();
        }

        public void ShowKeyboard()
        {
            _txtName.Focus();
        }

        private void _txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            BindingExpression bindingExpr = listBox.GetBindingExpression(ListBox.SelectedIndexProperty);
            bindingExpr.UpdateSource();
        }
    }
}
