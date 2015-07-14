using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GiveItBack.Model.Pages;
using GalaSoft.MvvmLight.Command;

namespace GiveItBack.ViewModel
{
    public class ServiceTestVM :ViewModelBase
    {
        #region Private members

        private ServiceTestM _model;

        #endregion

        public ServiceTestVM(ServiceTestM model)
        {
            _model = model;
            _model.StatusMessage = "Nowy status;";
           // CheckConnection();
        }
        

        private void CheckConnection()
        {
            GiveItBackService.MainServiceClient client = new GiveItBackService.MainServiceClient();

          
            client.GetMembersCompleted += client_GetMembersCompleted;
            client.GetMembersAsync();
        }

        void client_GetMembersCompleted(object sender, GiveItBackService.GetMembersCompletedEventArgs e)
        {
            try
            {
                List<GiveItBackService.MembersModel> members = e.Result.ToList();
                if(members.Any())
                {
                    _model.IsConnected = true;
                }
            }
            catch(Exception ex)
            {
                 
            }
        }
    }
}
