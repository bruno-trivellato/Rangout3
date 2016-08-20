using Rang_Out.Common;
using Rang_Out.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rang_Out.ViewModels
{
    public class AppShellViewModel
    {

        private RelayCommand _LogoutCommand;

        public RelayCommand LogoutCommand
        {
            get
            {
                if (_LogoutCommand == null)
                {
                    _LogoutCommand = new RelayCommand(
                      () =>
                      {
                          AuthenticationHandler.LogoutUser();
                      },
                      () =>
                      {
                          return true;
                      });
                    
                }
                return _LogoutCommand;
            }
        }


        public AppShellViewModel()
        {

        }
    }
}
