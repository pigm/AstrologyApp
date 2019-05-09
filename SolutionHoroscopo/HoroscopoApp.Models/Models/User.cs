using Realms;
namespace HoroscopoApp.Models.Models
{
    /// <summary>
    /// User.
    /// </summary>
    public class User : RealmObject
    {
        public string nombre { get; set; }
        public string signoZodiacal { get; set; }
        public int Id { get; set; }
    }
}
