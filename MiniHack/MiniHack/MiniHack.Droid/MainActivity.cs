using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
//using Microsoft.WindowsAzure.Mobile;
//using Microsoft.WindowsAzure.Mobile.Ext;
using MiniHack;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace MiniHack.Droid
{
    [Activity(Label = "MiniHack", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity , MainPage.IAuthenticate
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);


          MainPage.Init((MainPage.IAuthenticate)this);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private MobileServiceUser user;
        MobileServiceClient client = new MobileServiceClient("https://minihackazure.azurewebsites.net");

        public MobileServiceAuthenticationProvider ServiceProvider { get; private set; }
        public async Task<bool> Authenticate(int Provider)
        {
            var success = false;
            var message = string.Empty;

            switch (Provider)
            {
                case 0:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.Google;
                        break;
                    }
                case 1:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.Twitter;
                        break;
                    }
                case 2:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.MicrosoftAccount;
                        break;
                    }
                case 3:
                    {
                        ServiceProvider = MobileServiceAuthenticationProvider.Facebook;
                        break;
                    }

            }



            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await client.LoginAsync(this,
                    ServiceProvider);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            // Display the success or failure message.
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle("Sign-in result");
            builder.Create().Show();

            return success;
        }


    }
}

