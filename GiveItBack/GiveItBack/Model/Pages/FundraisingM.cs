﻿using System;
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
    /// <summary>
    /// Podstrona głównego okna roboczego.
    /// </summary>
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

        public FundraisingM(WorkM workModel)
            : base(workModel)
        {
            MembersInfo = workModel.MembersInfo;
        }
    }
}
