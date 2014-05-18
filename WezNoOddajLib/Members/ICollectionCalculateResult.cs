using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WezNoOddajLib.Members
{
    public interface ICollectionCalculateResult
    {
        List<IMemberInfo> MembersList { get; set; }
    }
}
