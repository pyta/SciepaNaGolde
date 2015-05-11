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

namespace GiveItBack.Model.Pages
{
    public class WorkM : PageBase
    {
        #region Private Members

        private ApplicationBar _bar;

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
            FundraisingModel = new FundraisingM(this);
            MembersModel = new MembersM(this);

            _bar = CreateBar();
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

            bar.Buttons.Add(addMemberBtn);
            bar.Buttons.Add(calculateBtn);

            return bar;
        }

        private void appBarButton_Click(object sender, EventArgs e)
        {
            ((FundraisingM)FundraisingModel).GoToAddMember();
        }

        #endregion
    }
}
