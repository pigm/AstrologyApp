using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using HoroscopoApp.Utils.Properties;
using HoroscopoApp.Utils.Utils;

namespace HoroscopoApp.Fragments
{
    /// <summary>
    /// Horoscopo fragment.
    /// </summary>
    public class HoroscopoFragment : Fragment
    {
        int tipo;
        ImageButton btnDinero, btnAmor, btnSalud, btnCompartir;
        ImageView imgSigno;
        RelativeLayout rlImagenSigno;
        TextView lblNombreSigno, lblFechaSigno, lblNumero, lblColor, lblHintCategoriaDescripcion, lblCategoriaDescripcion, lblFechaDelDia;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:HoroscopoApp.Fragments.HoroscopoFragment"/> class.
        /// </summary>
        /// <param name="tipo">Tipo.</param>
        public HoroscopoFragment(int tipo){
            this.tipo = tipo;
        }

        /// <summary>
        /// Ons the create.
        /// </summary>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override void OnCreate(Bundle savedInstanceState){
            base.OnCreate(savedInstanceState);

        }

        /// <summary>
        /// Ons the create view.
        /// </summary>
        /// <returns>The create view.</returns>
        /// <param name="inflater">Inflater.</param>
        /// <param name="container">Container.</param>
        /// <param name="savedInstanceState">Saved instance state.</param>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
            ViewGroup v = (ViewGroup)inflater.Inflate(Resource.Layout.horoscopoFragment, container, false);
            var id = "ca-app-pub-5556823688798335~7001844355";
            Android.Gms.Ads.MobileAds.Initialize(this.Activity.ApplicationContext, id);
            var adView = v.FindViewById<AdView>(Resource.Id.adView);
            var adRequest = new AdRequest.Builder().Build();
            adView.LoadAd(adRequest);
            imgSigno = v.FindViewById<ImageView>(Resource.Id.imgSigno);
            rlImagenSigno = v.FindViewById<RelativeLayout>(Resource.Id.rlImagenSigno);
            btnDinero = v.FindViewById<ImageButton>(Resource.Id.btnDinero);
            btnAmor = v.FindViewById<ImageButton>(Resource.Id.btnAmor);
            btnSalud = v.FindViewById<ImageButton>(Resource.Id.btnSalud);
            btnCompartir = v.FindViewById<ImageButton>(Resource.Id.btnCompartir);
            btnCompartir.Click +=BtnCompartir_Click;
            lblNombreSigno = v.FindViewById<TextView>(Resource.Id.lblNombreSigno);
            lblFechaSigno = v.FindViewById<TextView>(Resource.Id.lblFechaSigno);
            lblNumero = v.FindViewById<TextView>(Resource.Id.lblNumero);
            lblColor = v.FindViewById<TextView>(Resource.Id.lblColor);
            lblFechaDelDia = v.FindViewById<TextView>(Resource.Id.lblFechaDelDia);
            lblFechaDelDia.Text = DataManager.Horoscopos.titulo;
            lblHintCategoriaDescripcion = v.FindViewById<TextView>(Resource.Id.lblHintCategoriaDescripcion);
            lblCategoriaDescripcion = v.FindViewById<TextView>(Resource.Id.lblCategoriaDescripcion);
            clean();
            refreshView();
            return v;
        }

        /// <summary>
        /// Buttons the compartir click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void BtnCompartir_Click(object sender, EventArgs e){
            string infoSignoRedesSociales = "";
            if (tipo == 1){
                infoSignoRedesSociales =    DataManager.Horoscopos.horoscopo.aries.nombre 
                                                    + "\nAmor: "+ DataManager.Horoscopos.horoscopo.aries.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.aries.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.aries.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.aries.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.aries.color;
            }else if (tipo == 2){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.tauro.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.tauro.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.tauro.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.tauro.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.tauro.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.tauro.color;
            }else if (tipo == 3){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.geminis.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.geminis.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.geminis.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.geminis.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.geminis.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.geminis.color;
            }else if (tipo == 4){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.cancer.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.cancer.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.cancer.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.cancer.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.cancer.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.cancer.color;
            }else if (tipo == 5){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.leo.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.leo.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.leo.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.leo.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.leo.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.leo.color;
            }else if (tipo == 6){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.virgo.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.virgo.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.virgo.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.virgo.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.virgo.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.virgo.color;
            }else if (tipo == 7){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.libra.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.libra.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.libra.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.libra.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.libra.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.libra.color;
            }else if (tipo == 8){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.escorpion.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.escorpion.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.escorpion.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.escorpion.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.escorpion.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.escorpion.color;
            }else if (tipo == 9){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.sagitario.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.sagitario.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.sagitario.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.sagitario.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.sagitario.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.sagitario.color;
            }else if (tipo == 10){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.capricornio.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.capricornio.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.capricornio.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.capricornio.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.capricornio.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.capricornio.color;
            }else if (tipo == 11){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.acuario.nombre
                                                    + "\nAmor: " + DataManager.Horoscopos.horoscopo.acuario.amor
                                                    + "\nDinero: " + DataManager.Horoscopos.horoscopo.acuario.dinero
                                                    + "\nSalud: " + DataManager.Horoscopos.horoscopo.acuario.salud
                                                    + "\nNúmero: " + DataManager.Horoscopos.horoscopo.acuario.numero
                                                    + "\nColor: " + DataManager.Horoscopos.horoscopo.acuario.color;
            }else if (tipo == 12){
                infoSignoRedesSociales = DataManager.Horoscopos.horoscopo.piscis.nombre
                                                    + "\n\nAmor: " + DataManager.Horoscopos.horoscopo.piscis.amor
                                                    + "\n\nDinero: " + DataManager.Horoscopos.horoscopo.piscis.dinero
                                                    + "\n\nSalud: " + DataManager.Horoscopos.horoscopo.piscis.salud
                                                    + "\n\nNúmero: " + DataManager.Horoscopos.horoscopo.piscis.numero
                                                    + "\n\nColor: " + DataManager.Horoscopos.horoscopo.piscis.color;
            }
            Intent sendIntent = new Intent();
            sendIntent.SetAction(Intent.ActionSend);
            sendIntent.PutExtra(Intent.ExtraText, infoSignoRedesSociales);
            sendIntent.SetType(Constante.TIPO_ENVIO_REDES_SOCIALES);
            StartActivity(Intent.CreateChooser(sendIntent, Constante.NOMBRE_APP));
        }


        /// <summary>
        /// Clean this instance.
        /// </summary>
        void clean(){
            lblNombreSigno.Text = "";
            lblFechaSigno.Text = "";
        }

        /// <summary>
        /// Refreshs the view.
        /// </summary>
        void refreshView(){
            if (tipo == 1){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_aries);
                cambioColor(Resource.Color.fondo_aries);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.aries.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.aries.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.aries.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.aries.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.aries.color;
                clickBtnTabs(1, DataManager.Horoscopos.horoscopo.aries.dinero
                             , DataManager.Horoscopos.horoscopo.aries.amor
                             , DataManager.Horoscopos.horoscopo.aries.salud);
            }else if(tipo == 2){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_tauro);
                cambioColor(Resource.Color.fondo_tauro);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.tauro.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.tauro.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.tauro.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.tauro.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.tauro.color;
                clickBtnTabs(2, DataManager.Horoscopos.horoscopo.tauro.dinero
                             , DataManager.Horoscopos.horoscopo.tauro.amor
                             , DataManager.Horoscopos.horoscopo.tauro.salud);
            }else if (tipo == 3){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_gemini);
                cambioColor(Resource.Color.fondo_geminis);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.geminis.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.geminis.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.geminis.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.geminis.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.geminis.color;
                clickBtnTabs(3, DataManager.Horoscopos.horoscopo.geminis.dinero
                             , DataManager.Horoscopos.horoscopo.geminis.amor
                             , DataManager.Horoscopos.horoscopo.geminis.salud);
            }else if (tipo == 4){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_cancer);
                cambioColor(Resource.Color.fondo_cancer);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.cancer.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.cancer.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.cancer.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.cancer.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.cancer.color;
                clickBtnTabs(4, DataManager.Horoscopos.horoscopo.cancer.dinero
                             , DataManager.Horoscopos.horoscopo.cancer.amor
                             , DataManager.Horoscopos.horoscopo.cancer.salud);
            }else if (tipo == 5){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_leo);
                cambioColor(Resource.Color.fondo_leo);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.leo.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.leo.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.leo.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.leo.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.leo.color;
                clickBtnTabs(5, DataManager.Horoscopos.horoscopo.leo.dinero
                             , DataManager.Horoscopos.horoscopo.leo.amor
                             , DataManager.Horoscopos.horoscopo.leo.salud);
            }else if (tipo == 6){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_virgo);
                cambioColor(Resource.Color.fondo_virgo);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.virgo.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.virgo.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.virgo.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.virgo.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.virgo.color;
                clickBtnTabs(6, DataManager.Horoscopos.horoscopo.virgo.dinero
                             , DataManager.Horoscopos.horoscopo.virgo.amor
                             , DataManager.Horoscopos.horoscopo.virgo.salud);
            }else if (tipo == 7){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_libra);
                cambioColor(Resource.Color.fondo_libra);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.libra.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.libra.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.libra.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.libra.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.libra.color;
                clickBtnTabs(7, DataManager.Horoscopos.horoscopo.libra.dinero
                             , DataManager.Horoscopos.horoscopo.libra.amor
                             , DataManager.Horoscopos.horoscopo.libra.salud);
            }else if (tipo == 8){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_escorpion);
                cambioColor(Resource.Color.fondo_escorpion);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.escorpion.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.escorpion.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.escorpion.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.escorpion.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.escorpion.color;
                clickBtnTabs(8, DataManager.Horoscopos.horoscopo.escorpion.dinero
                             , DataManager.Horoscopos.horoscopo.escorpion.amor
                             , DataManager.Horoscopos.horoscopo.escorpion.salud);
            }else if (tipo == 9){
                clean();
                lblFechaDelDia.SetTextColor(lblFechaDelDia.Context.Resources.GetColor(Resource.Color.white));
                lblFechaSigno.SetTextColor(lblFechaSigno.Context.Resources.GetColor(Resource.Color.white));
                lblNombreSigno.SetTextColor(lblNombreSigno.Context.Resources.GetColor(Resource.Color.white));
                imgSigno.SetImageResource(Resource.Drawable.ic_sagitario);
                cambioColor(Resource.Color.fondo_sagitario);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.sagitario.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.sagitario.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.sagitario.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.sagitario.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.sagitario.color;
                clickBtnTabs(9, DataManager.Horoscopos.horoscopo.sagitario.dinero
                             , DataManager.Horoscopos.horoscopo.sagitario.amor
                             , DataManager.Horoscopos.horoscopo.sagitario.salud);
            }else if (tipo == 10){
                clean();
                lblFechaDelDia.SetTextColor(lblFechaDelDia.Context.Resources.GetColor(Resource.Color.white));
                lblFechaSigno.SetTextColor(lblFechaSigno.Context.Resources.GetColor(Resource.Color.white));
                lblNombreSigno.SetTextColor(lblNombreSigno.Context.Resources.GetColor(Resource.Color.white));
                imgSigno.SetImageResource(Resource.Drawable.ic_capricornio);
                cambioColor(Resource.Color.fondo_capricornio);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.capricornio.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.capricornio.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.capricornio.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.capricornio.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.capricornio.color;
                clickBtnTabs(10, DataManager.Horoscopos.horoscopo.capricornio.dinero
                             , DataManager.Horoscopos.horoscopo.capricornio.amor
                             , DataManager.Horoscopos.horoscopo.capricornio.salud);
            }else if (tipo == 11){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_aquario);
                cambioColor(Resource.Color.fondo_acuario);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.acuario.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.acuario.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.acuario.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.acuario.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.acuario.color;
                clickBtnTabs(11, DataManager.Horoscopos.horoscopo.acuario.dinero
                             , DataManager.Horoscopos.horoscopo.acuario.amor
                             , DataManager.Horoscopos.horoscopo.acuario.salud);
            }else if (tipo == 12){
                clean();
                imgSigno.SetImageResource(Resource.Drawable.ic_piscis);
                cambioColor(Resource.Color.fondo_piscis);
                lblNombreSigno.Text = DataManager.Horoscopos.horoscopo.piscis.nombre;
                lblFechaSigno.Text = DataManager.Horoscopos.horoscopo.piscis.fechaSigno;
                lblCategoriaDescripcion.Text = DataManager.Horoscopos.horoscopo.piscis.dinero;
                lblNumero.Text = DataManager.Horoscopos.horoscopo.piscis.numero;
                lblColor.Text = DataManager.Horoscopos.horoscopo.piscis.color;
                clickBtnTabs(12, DataManager.Horoscopos.horoscopo.piscis.dinero
                             , DataManager.Horoscopos.horoscopo.piscis.amor
                             , DataManager.Horoscopos.horoscopo.piscis.salud);
            }
        }

        /// <summary>
        /// Cambios the color.
        /// </summary>
        /// <param name="color">Color.</param>
        void cambioColor(int color){
            rlImagenSigno.SetBackgroundResource(color);
        }

        /// <summary>
        /// Clicks the button tabs.
        /// </summary>
        /// <param name="signo">Signo.</param>
        /// <param name="descripcionDinero">Descripcion dinero.</param>
        /// <param name="descripcionAmor">Descripcion amor.</param>
        /// <param name="descripcionSalud">Descripcion salud.</param>
        void clickBtnTabs(int signo, string descripcionDinero, string descripcionAmor, string descripcionSalud){
            btnDinero.Click += delegate {
                if (tipo == signo){
                    lblHintCategoriaDescripcion.Text = Constante.DINERO;
                    lblCategoriaDescripcion.Text = descripcionDinero;
                }
                btnDinero.SetImageResource(Resource.Drawable.ic_dinero_act);
                btnAmor.SetImageResource(Resource.Drawable.ic_amor_des);
                btnSalud.SetImageResource(Resource.Drawable.ic_salud_des);
            };
            btnAmor.Click += delegate {
                if (tipo == signo){
                    lblHintCategoriaDescripcion.Text = Constante.AMOR;
                    lblCategoriaDescripcion.Text = descripcionAmor;
                }
                btnDinero.SetImageResource(Resource.Drawable.ic_dinero_des);
                btnAmor.SetImageResource(Resource.Drawable.ic_amor_act);
                btnSalud.SetImageResource(Resource.Drawable.ic_salud_des);
            };
            btnSalud.Click += delegate {
                if (tipo == signo){
                    lblHintCategoriaDescripcion.Text = Constante.SALUD;
                    lblCategoriaDescripcion.Text = descripcionSalud;
                }
                btnDinero.SetImageResource(Resource.Drawable.ic_dinero_des);
                btnAmor.SetImageResource(Resource.Drawable.ic_amor_des);
                btnSalud.SetImageResource(Resource.Drawable.ic_salud_act);
            };
        }
    }
}