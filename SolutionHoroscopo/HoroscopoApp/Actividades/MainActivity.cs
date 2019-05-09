using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using HoroscopoApp.Models.Models;
using HoroscopoApp.Service.Delagate;
using HoroscopoApp.Utils.Properties;
using HoroscopoApp.Utils.Utils;
using Newtonsoft.Json;

namespace HoroscopoApp
{
    /// <summary>
    /// Main activity.
    /// </summary>
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true,
              ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
              Android.Content.PM.ConfigChanges.Orientation,
              ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        MyFirebaseIIDService myFirebaseIIDService;
        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            if (ValidationUtils.GetNetworkStatus())
            {
                await descargaInfoAsync();
                PerfilarUserAsync();
            }
            else
            {
                ToolsUtilsAndroid.alertDialogApplicationMessage(this
                                                                ,Constante.ALERT_TITLE
                                                                ,Constante.ALERT_MESSAGE_NOTCONNECTION_INTERNET
                                                                ,Constante.ALERT_POSITIVE_BUTTON
                                                                ,"", Resource.Mipmap.ic_logo);
            }
        }

        /// <summary>
        /// Perfilars the user async.
        /// </summary>
        void PerfilarUserAsync()
        {
            var existeUser = DataManager.RealmInstance.All<User>();
            if (existeUser != null){
                var userResponse = DataManager.RealmInstance.All<User>().FirstOrDefault();
                var jsonObj = JsonConvert.SerializeObject(userResponse);
                UserLogeado usr = JsonConvert.DeserializeObject<UserLogeado>(jsonObj);
                DataManager.UserLogeado = usr;
            }
        }


            /// <summary>
            /// Perfilars the async.
            /// </summary>
            /// <returns>The async.</returns>
            async Task descargaInfoAsync()
        {
            myFirebaseIIDService = new MyFirebaseIIDService();
            myFirebaseIIDService.OnTokenRefresh();
            var horoscopoDelDia = await ServiceDelegate.Instance.GetHoroscopo();
            if (horoscopoDelDia.Success)
            {
                DataManager.Horoscopos = horoscopoDelDia.Response as HoroscopoActual;
                Intent i = new Intent(this, typeof(HomeActivity));
                StartActivity(i);
            }else{
                ToolsUtilsAndroid.alertDialogApplicationMessage(this
                                                                , Constante.ALERT_TITLE
                                                                , Constante.ALERT_MESSAGE_ERROR_INESPERADO
                                                                , Constante.ALERT_POSITIVE_BUTTON
                                                                , "", Resource.Mipmap.ic_logo);
            }
        }
    }
}