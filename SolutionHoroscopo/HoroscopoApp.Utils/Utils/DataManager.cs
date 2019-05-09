using HoroscopoApp.Models.Models;
using Realms;

namespace HoroscopoApp.Utils.Utils
{
    /// <summary>
    /// Data manager.
    /// </summary>
    public class DataManager
    {
        public static HoroscopoActual Horoscopos { get; set; }
        public static UserLogeado UserLogeado { get; set; }
        static Realm realm;

        /// <summary>
        /// Gets the realm instance.
        /// </summary>
        /// <value>The realm instance.</value>
        public static Realm RealmInstance
        {
            get
            {
                if (realm == null)
                {
                    try
                    {
                        RealmConfiguration config = new RealmConfiguration
                        {
                            SchemaVersion = 3,
                            ShouldDeleteIfMigrationNeeded = true
                        };
                        realm = Realm.GetInstance(config);
                    }
                    catch
                    {
                        realm = Realm.GetInstance();
                    }
                }
                return realm;
            }
        }
    }
}