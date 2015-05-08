using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Common;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.Resources;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;

namespace GiveItBack.Model.Pages
{
    public class FundraisingM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new FundraisingPage() { DataContext = new FundraisingVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return null; } }

        public List<MemberInfo> MembersInfo { get; private set; }

        public FundraisingM(IAppPage previousPage)
            : base(previousPage)
        {
            MembersInfo = new List<MemberInfo>();
        }

        public void GoToAddMember()
        {
            var members = new AddMemberM(base.PreviousPage);
            base.GoToPage(members);
        }
    }
}
