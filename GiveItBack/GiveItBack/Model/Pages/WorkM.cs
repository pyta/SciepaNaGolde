using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Common.Interfaces;
using GiveItBack.Pages;
using GiveItBack.ViewModel;

namespace GiveItBack.Model.Pages
{
    public class WorkM : PageBase
    {
        public override Control Content
        {
            get
            {
                var page = new WorkPage() { DataContext = new WorkVM(this) };
                return base.SetDefaultPageAttributes(page);
            }
        }

        public IAppPage FundraisingModel { get; private set; }
        public IAppPage MembersModel { get; private set; }

        public WorkM(IAppPage previousPage)
            : base(previousPage)
        {
            FundraisingModel = new FundraisingM(this);
            MembersModel = new MembersM(this);
        }
    }
}
