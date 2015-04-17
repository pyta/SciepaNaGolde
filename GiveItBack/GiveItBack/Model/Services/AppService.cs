using System;
using GiveItBack.ViewModel;

namespace GiveItBack.Model.Services
{
    public class AppService : IAppService
    {
        public void GetData(Action<AppModel, Exception> callback)
        {
            try
            {
                var item = AppModel.AppModelInstance;
                callback(item, null);
            }
            catch (Exception ex)
            {
                callback(null, ex);
            }
        }
    }
}