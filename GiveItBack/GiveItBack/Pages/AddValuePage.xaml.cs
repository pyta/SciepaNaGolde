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
    public partial class AddValuePage : UserControl
    {
        public AddValuePage()
        {
            InitializeComponent();
        }

        #region Private Methods

        private void ShowKeyboard()
        {
            _txtValue.Focus();
        }

        #endregion

        #region Events

        private void _txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowKeyboard();
        }

        #endregion
    }
}
