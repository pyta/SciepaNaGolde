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
using WezNoOddaj.Members;
using WezNoOddaj.Members.Helpers;

namespace WezNoOddaj.Panels
{
    public partial class PiePanel : UserControl
    {
        #region Members

        public ICollectionCalculateResult Result { get; set; }

        #endregion

        public PiePanel()
        {
            InitializeComponent();
        }

        public void FillData(ICollectionCalculateResult result)
        {
            Result = result;

            Telerik.Windows.Controls.PieSeries serie = new Telerik.Windows.Controls.PieSeries();

            List<SimpleMember> info = result.MembersList.Where(x => x is SimpleMember).OfType<SimpleMember>().ToList();
            serie.ItemsSource = info;

            pieMembers.Series.Add(serie);
        }
    }
}
