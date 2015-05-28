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

namespace GiveItBack.Model.Pages
{
    public class WorkM : PageBase
    {
        #region Private Members

        private ApplicationBar _bar;
        public List<MemberInfo> MembersInfo { get; private set; }

        #endregion

        public override Control Content
        {
            get
            {
                var page = new WorkPage() { DataContext = new WorkVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return _bar; } }

        public IAppPage FundraisingModel { get; private set; }
        public IAppPage MembersModel { get; private set; }

        public WorkM(IAppPage previousPage)
            : base(previousPage)
        {
            MembersInfo = new List<MemberInfo>();

            FundraisingModel = new FundraisingM(this);
            MembersModel = new MembersM(this);

            _bar = CreateBar();
        }

        public void AddNewMember(MemberInfo member)
        {
            MembersInfo.Add(member);
        }

        public void GoToAddMember()
        {
            var members = new AddMemberM(this);
            base.GoToPage(members);
        }

        public void GoToResults()
        {
            // TODO: Przejść do strony z wynikiem.
        }

        #region Private Methods

        private ApplicationBar CreateBar()
        {
            // TODO: Utworzyć menu dla obszaru roboczego tworzenia zrzuteczki.

            var bar = new ApplicationBar();

            ApplicationBarIconButton addMemberBtn = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            addMemberBtn.Text = AppResources.WorkBarAddMember;
            addMemberBtn.Click += appBarButton_Click;

            ApplicationBarIconButton calculateBtn = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            calculateBtn.Text = AppResources.WorkBarAddMember;
            calculateBtn.Click += calculateBtn_Click;

            bar.Buttons.Add(addMemberBtn);
            bar.Buttons.Add(calculateBtn);

            return bar;
        }

        void calculateBtn_Click(object sender, EventArgs e)
        {
            GoToResults();
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            GoToAddMember();
        }

        #endregion
    }
}
