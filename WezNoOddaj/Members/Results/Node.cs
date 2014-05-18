using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WezNoOddajLib.Members;

namespace WezNoOddaj.Members.Results
{
    public class Node
    {
        #region Members

        IMemberInfo _memberInfo;

        public float CurrentValue { get; set; }

        #endregion

        public Node(IMemberInfo memberInfo)
        {
            _memberInfo = memberInfo;
            CurrentValue = memberInfo.Share;
        }

        public Edge Connect(Node node, float debt)
        {
            CurrentValue += debt;
            node.CurrentValue -= debt;

            return new Edge(debt, this, node);
        }

        public bool AlreadyExist(IMemberInfo member)
        {
            return _memberInfo == member;
        }
    }
}
