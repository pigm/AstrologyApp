namespace HoroscopoApp.Models.Models
{
    /// <summary>
    /// Horoscopo actual.
    /// </summary>
    public class HoroscopoActual
    {
        public string titulo { get; set; }
        public Horoscopo horoscopo { get; set; }
        public string fuente { get; set; }
        public string autor { get; set; }
    }
}
