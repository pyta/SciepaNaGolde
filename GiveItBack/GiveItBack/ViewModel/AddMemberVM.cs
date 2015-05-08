using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiveItBack.Model.Pages;
using Telerik.Windows.Controls;

namespace GiveItBack.ViewModel
{
    public class AddMemberVM : ViewModelBase
    {
        private AddMemberM _model;

        public AddMemberVM(AddMemberM model)
        {
            _model = model;
        }
    }
}
