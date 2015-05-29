using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.Resources;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;
using Tools;

namespace GiveItBack.Model.Pages
{
    public class AddMemberM : PageBase
    {
        #region Private Members

        private ApplicationBar _bar;

        #endregion

        public override Control Content
        {
            get
            {
                var page = new AddMemberPage() { DataContext = new AddMemberVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return _bar; ; } }

        public Action GetSelectedMember { get; set; }

        public AddMemberM(IAppPage previousPage)
            : base(previousPage)
        {
            _bar = CreateBar();
        }

        public void GoToValuePage(SelectedMember member)
        {
            GoToPage(new AddValueM(this, PreviousPage, member));
        }

        #region Private Methods

        private ApplicationBar CreateBar()
        {
            var bar = new ApplicationBar();

            ApplicationBarIconButton selectMemberButton = new ApplicationBarIconButton(new Uri("/Assets/Images/AppBar/check.png", UriKind.Relative));
            selectMemberButton.Text = AppResources.strWorkBarSelectMember;
            selectMemberButton.Click += selectMemberButton_Click;
            bar.Buttons.Add(selectMemberButton);

            return bar;
        }

        void selectMemberButton_Click(object sender, EventArgs e)
        {
            if (GetSelectedMember != null)
                GetSelectedMember();
        }

        #endregion
    }
}
