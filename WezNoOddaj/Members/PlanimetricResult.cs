using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WezNoOddajLib.Members;
using WezNoOddaj.Members.Results;

namespace WezNoOddaj.Members
{
    class PlanimetricResult : ICollectionCalculateResult
    {
        #region Members

        private Graph _graph;

        #endregion

        public PlanimetricResult(List<IMemberInfo> members)
        {
            MembersList = members;
        }

        #region ICollectionCalculateResult Members

        public List<IMemberInfo> MembersList { get; set; }

        #endregion
    }
}
