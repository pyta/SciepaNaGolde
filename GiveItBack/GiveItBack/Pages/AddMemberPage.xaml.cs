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

        /// <summary>
        /// Przenosi fokus na kontrolkę tekstową pokazując klawiaturę.
        /// </summary>
        private void ShowKeyboard()
        {
            _txtName.Focus();
        }

        /// <summary>
        /// Przenosi fokus na główną formatkę ukrywając klawiaturę.
        /// </summary>
        private void HideKeyboard()
        {
            _btnKeyboard.Focus();
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ShowKeyboard();
        }

        private void _btnKeyboard_Click(object sender, RoutedEventArgs e)
        {
            HideKeyboard();
        }

        #endregion
    }
}
