using Microsoft.EntityFrameworkCore;

namespace BOSSAProje.Models
{
    public class Hareket
    {
        public int HAREKET_NUMARASI { get; set; }
        public string? CIHAZ_NO { get; set; }
        public string? HATA_ACIKLAMASI { get; set; }
        public string? KULLANICI_ADSOYAD { get; set; }
        public string? YETKILI_ADSOYAD { get; set; }
        public int? CAGRI_DURUM { get; set; }
        public DateTime CAGRI_ACILIS { get; set; }
        public DateTime? CAGRI_YANIT { get; set; }
        public DateTime? CAGRI_KAPANIS { get; set; }

    }
}
