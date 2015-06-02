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

        public Action GetValueInfo { get; set; }

        public AddValueM(IAppPage previousPage, IAppPage workPage, SelectedMember member)
            : base(previousPage)
        {
            _bar = CreateBar();
            _workPage = workPage;

            Member = member;
        }

        public void GoToWorkPage(double value)
        {
            if (_workPage is WorkM)
            {
                MemberInfo info = new MemberInfo(
                    Member.Name,
                    value,
                    ToolsKit.GetColor(),
                    Member.Avatar,
                    Member.AdditionalInfo != null ? Member.AdditionalInfo.PhoneNumber : string.Empty);

                ((WorkM)_workPage).AddNewMember(info);
            }

            GoToPage(_workPage);
        }

        #region Private Methods

        private ApplicationBar CreateBar()
        {
            var bar = new ApplicationBar();

            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/Images/AppBar/check.png", UriKind.Relative));
            appBarButton.Text = AppResources.WorkBarAddMember;
            appBarButton.Click += appBarButton_Click;
            bar.Buttons.Add(appBarButton);

            return bar;
        }

        #endregion

        #region Events

        private void appBarButton_Click(object sender, EventArgs e)
        {
            if (GetValueInfo != null)
                GetValueInfo();
        }

        #endregion
    }
}
