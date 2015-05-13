using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.Resources;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;
using Tools;

namespace GiveItBack.Model.Pages
{
    public class AddValueM : PageBase
    {
        #region Private Members

        private ApplicationBar _bar;
        private IAppPage _workPage;
        private SelectedMember _member;

        #endregion

        public override Control Content
        {
            get 
            {
                var page = new AddValuePage() { DataContext = new AddValueVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar
        {
            get { return _bar; }
        }

        public SelectedMember Member { get; private set; }

        /// <summary>
        /// Zwraca lub ustawia wysokość wkładu wniesionego przez uczestnika zrzuteczki.
        /// </summary>
        public double Value { get; set; }

        public AddValueM(IAppPage previousPage, IAppPage workPage, SelectedMember member)
            : base(previousPage)
        {
            _bar = CreateBar();
            _workPage = workPage;

            Member = member;
        }

        private ApplicationBar CreateBar()
        {
            // TODO: Utworzyć menu do zatwierdzania nowego uczestnika zrzuteczki.

            var bar = new ApplicationBar();

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.WorkBarAddMember;
            appBarButton.Click += appBarButton_Click;
            bar.Buttons.Add(appBarButton);

            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            bar.MenuItems.Add(appBarMenuItem);

            return bar;
        }

        void appBarButton_Click(object sender, EventArgs e)
        {
            MemberInfo info = new MemberInfo(
                Member.Name,
                Value, 
                ToolsKit.GetColor(), 
                Member.Avatar, 
                Member.AdditionalInfo != null ? Member.AdditionalInfo.PhoneNumber : string.Empty);

            if (_workPage is WorkM)
                ((WorkM)_workPage).AddNewMember(info);

            GoToPage(_workPage);
        }
    }
}
