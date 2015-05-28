using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.ViewModel;
using Microsoft.Phone.Shell;

namespace GiveItBack.Model.Pages
{
    public class MembersM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new MembersPage() { DataContext = new MembersVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public override ApplicationBar ApplicationBar { get { return null; } }

        public List<MemberInfo> Members { get; private set; }

        public MembersM(WorkM workModel)
            : base(workModel)
        {
            Members = workModel.MembersInfo;
        }
    }
}
