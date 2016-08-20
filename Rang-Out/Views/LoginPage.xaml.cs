using Microsoft.Identity.Client;
using Rang_Out.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Rang_Out.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();

            this.Loaded += LoginPage_Loaded;
            AuthenticationHandler.Login += AuthenticationHandler_Login;
        }

        private void AuthenticationHandler_Login(EventArgs args)
        {
            this.Frame.Navigate(typeof(LandingPage));

            this.Frame.BackStack.Clear();
        }

        private async void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await AuthenticationHandler.LoginUser(true);
            }
            catch (Exception)
            {
                // we will show the interactive mode
                SignInButton.Opacity = 1;
            }
            
        }
        

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }
    }
}
