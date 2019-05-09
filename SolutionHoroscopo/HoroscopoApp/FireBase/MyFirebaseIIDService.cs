using System;
using Android.App;
using Firebase.Iid;

namespace HoroscopoApp
{
    /// <summary>
    /// My firebase IIDS ervice.
    /// </summary>
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService{
        static string refreshedToken;

        /// <summary>
        /// Ons the token refresh.
        /// </summary>
        public override void OnTokenRefresh(){
            try{
                refreshedToken = FirebaseInstanceId.Instance.Token;               
                if (refreshedToken == null){ 
                    refreshedToken = FirebaseInstanceId.Instance.Token;
                }
            }
            catch (Exception ex){
                Console.WriteLine("Exeption tokenFCM: " + ex);
            }        
        }

        /// <summary>
        /// Sends the registration to server.
        /// </summary>
        /// <returns>The registration to server.</returns>
        public static string SendRegistrationToServer(){
            return refreshedToken.ToString();
        }
    }
}