using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;

namespace GiveItBack.ViewModel
{
    public class MembersVM : ViewModelBase
    {
        #region Private Members

        private MembersM _model;

        #endregion

        public List<MemberInfo> Members { get { return _model.Members; } }

        /// <summary>
        /// Zwraca liczbę uczestników.
        /// </summary>
        public int MembersCount { get { return Members.Count; } }

        /// <summary>
        /// Zwraca całkowity wkład wniesiony przez wszystkich uczestników.
        /// </summary>
        public double TotalValue { get { return Members.Sum(x => x.Value); } }

        public MembersVM(MembersM model)
        {
            _model = model;
        }
    }
}
