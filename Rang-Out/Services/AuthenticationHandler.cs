using Microsoft.Identity.Client;
using Rang_Out.Common;
using Rang_Out.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Rang_Out.Services
{
    public class AuthenticationHandler
    {
        public static string taskServiceUrl = "https://aadb2cplayground.azurewebsites.net";
        public static string aadInstance = "https://login.microsoftonline.com/";
        public static string redirectUri = "urn:ietf:wg:oauth:2.0:oob";

        // TODO: Replace these five default with your own configuration values
        public static string tenant = "rangoutb2c.onmicrosoft.com";
        public static string clientId = "d59b96d5-2493-4745-a963-09cb7e2c8b40";
        public static string signInPolicy = "b2c_1_signin";
        public static string signUpPolicy = "b2c_1_signup";
        public static string signUpSignInPolicy = "b2c_1_signupsignin";
        public static string editProfilePolicy = "b2c_1_profile";
        public static string resetPass = "b2c_1_passreset";

        public static string[] Scopes = { clientId };

        public static string authority = string.Concat(aadInstance, tenant);

        public static PublicClientApplication PCApplication { get; set; }

        public static event LogoutEventHandler Logout;
        public delegate void LogoutEventHandler(EventArgs args);

        private static void OnLogout(EventArgs args)
        {
            Logout?.Invoke( args );
        }

        public static event LoginEventHandler Login;
        public delegate void LoginEventHandler(EventArgs args);

        private static void OnLogin(EventArgs args)
        {
            Login?.Invoke(args);
        }
        

        public static void Init()
        {
            PCApplication = new PublicClientApplication(authority, clientId);
        }

        public static void LogoutUser()
        {
            PCApplication.UserTokenCache.Clear(PCApplication.ClientId);

            AppShell shell = Window.Current.Content as AppShell;
            shell.AppFrame.Navigate(typeof(LoginPage));

            OnLogout(EventArgs.Empty);

        }


        public async static Task LoginUser(bool isSilent = false)
        {
            if (!isSilent)
            {
                try
                {
                    AuthenticationResult ar = await AuthenticationHandler.PCApplication.AcquireTokenAsync(AuthenticationHandler.Scopes, "", UiOptions.SelectAccount, string.Empty, null, AuthenticationHandler.authority, AuthenticationHandler.signUpSignInPolicy);

                    OnLogin(EventArgs.Empty);
                }
                catch (MsalException ee)
                {

                    if (ee.Message != null && ee.Message.Contains("AADB2C90118"))
                    {
                        OnForgotPassword();
                    }

                    if (ee.ErrorCode != "authentication_canceled")
                    {
                        await new MessageDialog("Exception message: " + ee.Message, "An error has occurred").ShowAsync();
                    }
                }
                
            }
            else
            {
                try
                {
                    AuthenticationResult ar = await AuthenticationHandler.PCApplication.AcquireTokenSilentAsync(AuthenticationHandler.Scopes, "", AuthenticationHandler.authority, AuthenticationHandler.signUpSignInPolicy, false);

                    OnLogin(EventArgs.Empty);
                }
                catch (Exception)
                {
                    throw;
                    
                }
                
            }
            
        }

        private static async void OnForgotPassword()
        {
            try
            {
                AuthenticationResult ar = await AuthenticationHandler.PCApplication.AcquireTokenAsync(AuthenticationHandler.Scopes, "", UiOptions.SelectAccount, string.Empty, null, AuthenticationHandler.authority, AuthenticationHandler.resetPass);

            }
            catch (MsalException ee)
            {
                if (ee.ErrorCode != "authentication_canceled")
                {
                    await new MessageDialog("Exception message: " + ee.Message, "An error has occurred").ShowAsync();
                }
            }
        }

    }
}
