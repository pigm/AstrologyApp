using Android.App;

namespace HoroscopoApp.Utils.Utils
{
    /// <summary>
    /// Tools utils android.
    /// </summary>
    public class ToolsUtilsAndroid
    {
        /// <summary>
        /// Closes the application.
        /// </summary>
        public static void closeApplication(Activity actividad)
        {
            var activity = actividad;
            activity.FinishAffinity();
        }

        /// <summary>
        /// Alerts the dialog application message.
        /// </summary>
        /// <param name="actividad">Actividad.</param>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="positiveButton">Positive button.</param>
        public static void alertDialogApplicationMessage(Activity actividad, string title, string message, string positiveButton, string negativeButton, int icon)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(actividad);
            builder.SetTitle(title);
            builder.SetIcon(icon);
            builder.SetCancelable(false);
            builder.SetMessage(message);
            builder.SetNegativeButton(negativeButton, delegate {});
            builder.SetPositiveButton(positiveButton, delegate { 
                ToolsUtilsAndroid.closeApplication(actividad);
            });
            builder.Show();
        }

        /// <summary>
        /// Loading this instance.
        /// </summary>
        public static void alertDialogApplicationLoading(Activity actividad, string title, string message)
        {
            ProgressDialog _progressDialog = new ProgressDialog(actividad);
            _progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            _progressDialog.SetTitle(title);
            _progressDialog.SetMessage(message);
            _progressDialog.Show();
            _progressDialog.SetCancelable(false);
        }
    }
}