using System;
using Android.App;
using Android.Gms.Ads;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using HoroscopoApp.Fragments;
using HoroscopoApp.Utils.Properties;
using HoroscopoApp.Utils.Utils;

namespace HoroscopoApp
{
    /// <summary>
    /// Home activity.
    /// </summary>
    [Activity(Label = "AstrologyApp", Theme = "@style/ThemeAstrologyApp", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
              Android.Content.PM.ConfigChanges.Orientation,
              ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeActivity : AppCompatActivity
    { 
        DrawerLayout drawerLayout;
        ImageView botonCerrarMenu;
        LinearLayout llBtnBurger, llBtnUser;
        RelativeLayout rlBotonCerrarMenu;
        TextView lblNombreAppToolbar, lblTituloMenu, lblSubtituloMenu;

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            if (DataManager.UserLogeado == null)
            {
                IngresoUsuarioResponsableActivity.Instance.viewFormularioUser(this, false);
            }
           
            var id = "ca-app-pub-5556823688798335~7001844355";
            Android.Gms.Ads.MobileAds.Initialize(this.ApplicationContext, id);
            var adView = FindViewById<AdView>(Resource.Id.adViewGoogle);
            var adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            llBtnUser = FindViewById<LinearLayout>(Resource.Id.llBtnUser);
            llBtnBurger = FindViewById<LinearLayout>(Resource.Id.llBtnBurger);
            lblNombreAppToolbar = FindViewById<TextView>(Resource.Id.lblNombreAppToolbar);
            llBtnBurger.Click += LlBtnBurger_Click;
            llBtnUser.Click += LlBtnUser_Click;
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            View hView = navigationView.GetHeaderView(0);
            lblTituloMenu = hView.FindViewById<TextView>(Resource.Id.lblTituloMenu);
            lblSubtituloMenu = hView.FindViewById<TextView>(Resource.Id.lblSubtituloMenu);
            var fuenteCharmonmanRegular = Typeface.CreateFromAsset(Assets, Constante.FUENTE_CHARMONMAN_REGULAR);
            lblNombreAppToolbar.Typeface = fuenteCharmonmanRegular;
            lblTituloMenu.Typeface = fuenteCharmonmanRegular;
            lblSubtituloMenu.Typeface = fuenteCharmonmanRegular;

            if (DataManager.UserLogeado != null){
                signoUser(DataManager.UserLogeado.Id);
            }else{
                signoUser(1);
            }
        }

        public void signoUser(int idSigno){
            var ft = FragmentManager.BeginTransaction();
            ft.AddToBackStack(null);
            ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(idSigno));
            ft.Commit();
        }

        /// <summary>
        /// Lls the button user click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void LlBtnUser_Click(object sender, EventArgs e)
        {
            alertDialogApplicationMessageCambioUser(this
                                                    , Constante.ALERT_TITLE
                                                    , Constante.ALERT_MESSAGE_CHANGE_USER
                                                    , Constante.ALERT_POSITIVE_BUTTON
                                                    , Constante.ALERT_NEGATIVE_BUTTON
                                                    , Resource.Mipmap.ic_logo
                                                    , true);

        }


        /// <summary>
        /// Buttons the burger click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void LlBtnBurger_Click(object sender, EventArgs e){
            drawerLayout.OpenDrawer(GravityCompat.End);
            if (rlBotonCerrarMenu == null){
                using (rlBotonCerrarMenu = FindViewById<RelativeLayout>(Resource.Id.rlBotonCerrarMenu)){
                    rlBotonCerrarMenu.Click += eventoCerrarMenu;
                }
                using (botonCerrarMenu = FindViewById<ImageView>(Resource.Id.botonCerrarMenu)){
                    botonCerrarMenu.Click += eventoCerrarMenu;
                }
            }
        }

        /// <summary>
        /// Eventos the cerrar menu.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void eventoCerrarMenu(object sender, EventArgs e){
            drawerLayout.CloseDrawer(GravityCompat.End);
        }

        /// <summary>
        /// Navigations the view navigation item selected.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e){
            var ft = FragmentManager.BeginTransaction();
            switch (e.MenuItem.ItemId){
                case (Resource.Id.nav_aries):					             
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(1));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_tauro):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(2));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_geminis):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(3));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_cancer):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(4));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_leo):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(5));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_virgo):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(6));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_libra):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(7));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_escorpion):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(8));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_sagitario):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(9));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_capricornio):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(10));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_acuario):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(11));
                    ft.Commit();
                    break;
                case (Resource.Id.nav_piscis):
                    ft.AddToBackStack(null);
                    ft.Add(Resource.Id.HomeLayout, new HoroscopoFragment(12));
                    ft.Commit();
                    break;
            }
            drawerLayout.CloseDrawers();
        }

        /// <summary>
        /// Ons the back pressed.
        /// </summary>
        public override void OnBackPressed(){
            ToolsUtilsAndroid.closeApplication(this);
        }

        /// <summary>
        /// Alerts the dialog application message cambio user.
        /// </summary>
        /// <param name="actividad">Actividad.</param>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="positiveButton">Positive button.</param>
        /// <param name="negativeButton">Negative button.</param>
        /// <param name="icon">Icon.</param>
        public static void alertDialogApplicationMessageCambioUser(Activity actividad, string title, string message, string positiveButton, string negativeButton, int icon, bool dialogCancelable)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(actividad);
            builder.SetTitle(title);
            builder.SetIcon(icon);
            builder.SetCancelable(false);
            builder.SetMessage(message);
            builder.SetNegativeButton(negativeButton, delegate { });
            builder.SetPositiveButton(positiveButton, delegate {
                IngresoUsuarioResponsableActivity.Instance.viewFormularioUser(actividad, dialogCancelable);
            });
            builder.Show();
        }
    }
}