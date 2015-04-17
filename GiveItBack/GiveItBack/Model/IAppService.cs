using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiveItBack.Model
{
    public interface IAppService
    {
        void GetData(Action<AppModel, Exception> callback);
    }
}
