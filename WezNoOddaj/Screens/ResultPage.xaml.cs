using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using WezNoOddajLib.Members;

namespace WezNoOddaj.Screens
{
    public partial class ResultPage : UserControl
    {
        public ICollectionCalculateResult Result { get; set; }

        public ResultPage(ICollectionCalculateResult result)
        {
            InitializeComponent();

            Margin = new Thickness(0, 0, 0, 0);

            Result = result;
            panelPie.FillData(Result);
        }
    }
}
