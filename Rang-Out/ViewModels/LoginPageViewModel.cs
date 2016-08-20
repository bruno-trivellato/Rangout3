using Rang_Out.Common;
using Rang_Out.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;

namespace Rang_Out.ViewModels
{
    public class LoginPageViewModel
    {


        private RelayCommand _LoginCommand;

        public RelayCommand LoginCommand
        {
            get
            {
                if (_LoginCommand == null)
                {
                    _LoginCommand = new RelayCommand(
                      () =>
                      {
                          AuthenticationHandler.LoginUser();
                      },
                      () =>
                      {
                          return true;
                      });
                    
                }
                return _LoginCommand;
            }
        }



        public LoginPageViewModel()
        {

        }

        
    }
}
