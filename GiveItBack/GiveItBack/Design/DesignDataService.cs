﻿using System;
using GiveItBack.Model;
using GiveItBack.ViewModel;

namespace GiveItBack.Design
{
    public class DesignDataService : IAppService
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