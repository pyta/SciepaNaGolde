using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;
using Common.Interfaces;
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

        #region Private Methods

        private bool ShowKeyboard()
        {
            return _txtName.Focus();
        }

        #endregion

        #region Events

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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            BindingExpression bindingExpr = checkBox.GetBindingExpression(CheckBox.IsCheckedProperty);
            bindingExpr.UpdateSource();
        }

        #endregion
    }
}
