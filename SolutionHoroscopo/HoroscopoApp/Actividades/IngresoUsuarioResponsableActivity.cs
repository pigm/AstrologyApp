using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using FR.Ganfra.Materialspinner;
using HoroscopoApp.Models.Models;
using HoroscopoApp.Utils.Properties;
using HoroscopoApp.Utils.Utils;
using Newtonsoft.Json;

namespace HoroscopoApp
{
    /// <summary>
    /// Ingreso usuario responsable activity.
    /// </summary>
    [Activity(Label = "AstrologyApp", Theme = "@style/ThemeAstrologyApp", ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize |
              Android.Content.PM.ConfigChanges.Orientation,
              ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class IngresoUsuarioResponsableActivity : Activity{
        static Dialog customDialog = null;
        static IngresoUsuarioResponsableActivity instance = null;

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static IngresoUsuarioResponsableActivity Instance{
            get{
                if (instance == null)
                    instance = new IngresoUsuarioResponsableActivity();
                return instance;
            }
        }

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        protected override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ingreso_usuarioresponsable_dialog);
        }

        /// <summary>
        /// Views the formulario user.
        /// </summary>
        /// <param name="activity">Activity.</param>
        public void viewFormularioUser(Activity activity, bool dialogoCancelable){
            customDialog = new Dialog(activity, Resource.Style.Theme_Dialog_Translucent);
            var ha = (HomeActivity)activity;
            customDialog.SetCancelable(dialogoCancelable);
            customDialog.SetContentView(Resource.Layout.ingreso_usuarioresponsable_dialog);
            String[] Signos = { "Aries", "Tauro", "Géminis", "Cáncer", "Leo", "Virgo", "Libra", "Escorpión", "Sagitario", "Capricornio", "Acuario", "Piscis" };
            ArrayAdapter<String> adapterSignosZodiacales = new ArrayAdapter<String>(activity, Android.Resource.Layout.SimpleSpinnerItem, Signos);
            adapterSignosZodiacales.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            MaterialSpinner spiSignoZodiacal = customDialog.FindViewById<MaterialSpinner>(Resource.Id.spiSignoZodiacal);
            spiSignoZodiacal.Adapter = adapterSignosZodiacales;
            spiSignoZodiacal.SetPaddingSafe(0, 0, 0, 0);
            EditText txtNombreUsuario = customDialog.FindViewById<EditText>(Resource.Id.txtUser);
            TextView lblMensajeError = customDialog.FindViewById<TextView>(Resource.Id.lblMensajeError);
            txtNombreUsuario.ImeOptions = Android.Views.InputMethods.ImeAction.Done;
            LinearLayout llBtnIngresarUser = customDialog.FindViewById<LinearLayout>(Resource.Id.llBtnIngresarUser);
            llBtnIngresarUser.Click += delegate{
                if (txtNombreUsuario.Text.Trim().Length >= 5 
                    && !string.IsNullOrEmpty(txtNombreUsuario.Text) 
                    && !spiSignoZodiacal.SelectedItem.ToString().Equals("Signo Zodiacal")){
                    UserLogeado ul = new UserLogeado();
                    ul.nombre = txtNombreUsuario.Text;
                    ul.signoZodiacal = spiSignoZodiacal.SelectedItem.ToString();
                    int id = idSigno(spiSignoZodiacal.SelectedItem.ToString());
                    ul.Id = id;
                    DataManager.UserLogeado = ul;
                    using (var transUsr = DataManager.RealmInstance.BeginWrite()){
                        DataManager.RealmInstance.RemoveAll("User");
                        transUsr.Commit();
                    }
                    DataManager.RealmInstance.Write(() =>{
                        var userResponse = DataManager.UserLogeado;
                        var jsonObj = JsonConvert.SerializeObject(userResponse);
                        User usr = JsonConvert.DeserializeObject<User>(jsonObj);
                        DataManager.RealmInstance.Add<User>(usr);
                    });
                    Toast.MakeText(activity, "Usuario" + DataManager.UserLogeado.nombre + "Agregado exitosamente", ToastLength.Short).Show();
                    ha.signoUser(DataManager.UserLogeado.Id);
                    customDialog.Dismiss();
                }else{
                    lblMensajeError.Text = "Error al ingresar los datos";
                }
            };
            if (!string.IsNullOrEmpty(DataManager.UserLogeado.nombre)){
                txtNombreUsuario.Text = DataManager.UserLogeado.nombre;
                llBtnIngresarUser.Enabled = true;
                llBtnIngresarUser.SetBackgroundResource(Resource.Drawable.cssBotonAgregarProducto);
            }else{
                txtNombreUsuario.Text = string.Empty;
                llBtnIngresarUser.Enabled = false;
                llBtnIngresarUser.SetBackgroundResource(Resource.Drawable.cssBotonBloqueado);
            }

            txtNombreUsuario.TextChanged += delegate{
                if (txtNombreUsuario.Text.Trim().Length >= 5 || txtNombreUsuario.Text.Trim().Length == 0){
                    lblMensajeError.Text = string.Empty;
                }
                if (!string.IsNullOrEmpty(txtNombreUsuario.Text)){
                    llBtnIngresarUser.Enabled = true;
                    llBtnIngresarUser.SetBackgroundResource(Resource.Drawable.cssBotonAgregarProducto);
                }else{
                    llBtnIngresarUser.Enabled = false;
                    llBtnIngresarUser.SetBackgroundResource(Resource.Drawable.cssBotonBloqueado);
                }
            }; 
            customDialog.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            customDialog.Show();
        } 

        public int idSigno(string signoZodiacalUser){
            int id = 1;
            if (signoZodiacalUser.Equals(Constante.ARIES)){
                id = 1;
            }else if (signoZodiacalUser.Equals(Constante.TAURO)){
                id = 2;
            }else if (signoZodiacalUser.Equals(Constante.GEMINIS)){
                id = 3;
            }else if (signoZodiacalUser.Equals(Constante.CANCER)){
                id = 4;
            }else if (signoZodiacalUser.Equals(Constante.LEO)){
                id = 5;
            }else if (signoZodiacalUser.Equals(Constante.VIRGO)){
                id = 6;
            }else if (signoZodiacalUser.Equals(Constante.LIBRA)){
                id = 7;
            }else if (signoZodiacalUser.Equals(Constante.ESCORPION)){
                id = 8;
            }else if (signoZodiacalUser.Equals(Constante.SAGITARIO)){
                id = 9;
            }else if (signoZodiacalUser.Equals(Constante.CAPRICORNIO)){
                id = 10;
            }else if (signoZodiacalUser.Equals(Constante.ACUARIO)){
                id = 11;
            }else if (signoZodiacalUser.Equals(Constante.PISCIS)){
                id = 12;
            }
            return id;
        }
    }
}