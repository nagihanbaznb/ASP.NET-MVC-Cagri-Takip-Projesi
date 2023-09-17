

using BOSSAProje.Contexts;
using BOSSAProje.Contexts.Abstract;
using BOSSAProje.Models;
using BOSSAProje.Views.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BOSSAProje.Controllers
{
    public class CihazlarController : Controller
    {
        private readonly ICihazDal _cihazDal;
        private readonly IHareketDal _hareketDal;
        private readonly IHesapDal _hesapDal;

        public Cihaz cihaz;

        //private readonly HareketContext _hareketContext;

        public CihazlarController(ICihazDal cihazDal, IHareketDal hareketDal, IHesapDal hesapdal)
        {
            _hareketDal = hareketDal;
            _cihazDal = cihazDal;
            _hesapDal = hesapdal;
        }

        public ActionResult GetAllCihaz()
        {
            //var result = _cihazDal.GetAll();
            return View();
        }

        public ActionResult GetCihaz(string SERI_NO)
        {
            var result = _cihazDal.Get(c => c.SERI_NO == SERI_NO);

            cihaz = new Cihaz
            {
                FABRIKA_KOD = result.FABRIKA_KOD,
                FABRIKA_ADI = result.FABRIKA_ADI,
                CIHAZ_NO = result.CIHAZ_NO,
                CIHAZ_GRUBU_ADI = result.CIHAZ_GRUBU_ADI,
                CIHAZ_ALT_GRUBU = result.CIHAZ_ALT_GRUBU,
                CIHAZ_ALT_GRUP_ADI = result.CIHAZ_ALT_GRUP_ADI,
                Markası = result.Markası,
                CIHAZ_MODELI = result.CIHAZ_MODELI,
                MODEL_ADI = result.MODEL_ADI,
                PROCESSOR_KODU = result.PROCESSOR_KODU,
                SIRKET_KODU = result.SIRKET_KODU,
                SIRKET_ADI = result.SIRKET_ADI,
                ISY_KODU = result.ISY_KODU,
                KULLANICI_SICIL_NO = result.KULLANICI_SICIL_NO,
                KULLANICI_AD_SOYAD = result.KULLANICI_AD_SOYAD,
                CALISIYOR_MU = result.CALISIYOR_MU,
                DEPARTMAN_KODU = result.DEPARTMAN_KODU,
                DEPARTMAN_ADI = result.DEPARTMAN_ADI,
                PERT_MI = result.PERT_MI,
                BULUNDUGU_YER = result.BULUNDUGU_YER
               

            };

            TempData["CihazNoGecis"] = result.CIHAZ_NO;
            TempData["KULLANICI_AD_SOYAD"] = result.KULLANICI_AD_SOYAD;


            //return RedirectToAction("CihazGiris", "Home", new { cihaz = result });

            //return View("GetCihaz", cihaz);
            //return RedirectToAction("Cagrigiris", "Home", cihaz);

            //TempData["seri"] = Request.Form["SERI_NO"].ToString();

            //RedirectToAction("AddHareket", "CihazlarController", new { data = Request.Form["SERI_NO"].ToString() });

            return View("GetCihaz", cihaz);


            //return (result);

            //return View(cihaz);

        }

        //protected ISession Session => HttpContext.Session;

        public ActionResult Logout() //sonradan eklendi.
        {
            //HttpContext.Session.Clear(); // Tüm oturum verilerini temizler

            HttpContext.Session.Remove("kullanici_adi"); // Belirli bir oturum verisini siler

            return RedirectToAction("LoginPage", "Home");
        }

        public ActionResult LoginCheck(string uname, string pass) // eklendi
        {
            var kullanıcı = _hesapDal.Get(a => a.KULLANICI_ADI == uname);

            if (kullanıcı != null)
            {
                Hesap hesap = new Hesap
                {
                    KULLANICI_ADI = kullanıcı.KULLANICI_ADI,
                    KULLANICI_SIFRE = kullanıcı.KULLANICI_SIFRE
                };

                // Basarili giris.
                if (uname == hesap.KULLANICI_ADI && pass == hesap.KULLANICI_SIFRE)
                {
                    HttpContext.Session.SetString("kullanici_adi", kullanıcı.KULLANICI_ADI);

                    //HttpContext.Session.SetString("kullanıcı_adı", kullanıcı.KULLANICI_ADI);

                    //Session["kullanıcı_adı"] = kullanıcı.KULLANICI_ADI;
                    return RedirectToAction("Giris", "Home");
                }

                // Hatali sifre.
                else
                {
                    TempData["AlertMessage"] = "Hatali kullanici adi veya sifre!";
                    return RedirectToAction("LoginPage", "Home");
                }
            }

            // Kullanici adi kayitli degil.
            else
            {
                //ViewBag.ErrorMessage = "Böyle bir kullanıcı bulunmamaktadır!";

                TempData["AlertMessage"] = "Hatali kullanici adi veya sifre!";
                return RedirectToAction("LoginPage", "Home");
            }

            //return View();
        }
        
        public ActionResult AddHareket(string message)
        {
            string CihazNo = TempData["CihazNoGecis"].ToString();
            string KULLANICI_AD_SOYAD = TempData["KULLANICI_AD_SOYAD"].ToString();

            //string CihazNo = TempData["CihazNoGecis"].ToString();

            Hareket hareket = new Hareket
            {
               
                CAGRI_ACILIS = DateTime.Now,
                CAGRI_DURUM = 1,    // values = "1: cihaz arıza verdi", "2: arıza ile ilgileniliyor", "3: arıza çözüldü".
                CAGRI_KAPANIS = null,
                CAGRI_YANIT = null,
                CIHAZ_NO = CihazNo,
                HATA_ACIKLAMASI = message,
                KULLANICI_ADSOYAD = KULLANICI_AD_SOYAD,
                YETKILI_ADSOYAD = null
            };

            _hareketDal.AddHareket(hareket);

            TempData["AlertMessage"] = "Basariyla gonderilmistir.";

            //return View();
            return RedirectToAction("Giris", "Home");
        }

        public ActionResult GetUserCall(string uname)
        {
            //string kullaniciAdi = HttpContext.Session.GetString("kullanıcı_adı");

            //List<Hareket> allData = _hareketDal.GetAll();
            //List<Hareket> allData = _hareketDal.GetAll(c => c.KULLANICI_ADSOYAD == "user");

            var hesapKullanici = HttpContext.Session.GetString("kullanici_adi"); //eklendi

            List<Hareket> allData = _hareketDal.GetAll(c => c.KULLANICI_ADSOYAD == hesapKullanici); //filtre eklendi c

            //HttpContext.Session.Remove("kullanici_adi");    // buradan silinecek

            //List<Hareket> allData = _hareketDal.GetAll(c => c.KULLANICI_ADSOYAD == kullaniciAdi);


            //return RedirectToAction("EskiCagrilar", "Home");
            return View("EskiCagrilar", allData);
        }

        //public ActionResult SendReport(string message)
        //{

        //    //string seri = Request.Form["SERI_NO"];

        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.Hareket.Add(seriNo);
        //    //    db.SaveChanges();
        //    //    return RedirectToAction("Cagrigiris", "Home");
        //    //}

        //    //Hata model = new Hata(); // Bu kısmı modelinize göre düzenlemeniz gerekebilir

        //    //// Veritabanı bağlantısı ve veriyi tabloya ekleme işlemleri burada gerçekleştirilecek

        //    //string seri = Request.Form["SERI_NO"].ToString();

        //    string cihazNo = TempData["seri"] as string;

        //    // Veriyi kullanmak veya görüntülemek için View döndürün
        //    ViewBag.cihazNo = cihazNo;

        //    DateTime now = DateTime.Now;


        //    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Database=Cihaz;Trusted_Connection=true";

        //    Hareket hareket = new Hareket();
        //    //Cihaz cihaz1 = new Cihaz { KULLANICI_AD_SOYAD = cihaz.KULLANICI_AD_SOYAD };
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        string insertQuery = "INSERT INTO Hareket (HAREKET_NUMARASI, CIHAZ_NO, HATA_ACIKLAMASI, KULLANICI_ADSOYAD, YETKILI_ADSOYAD, CAGRI_DURUM, CAGRI_ACILIS, CAGRI_YANIT, CAGRI_KAPANIS) VALUES (@HAREKET_NUMARASI, @CIHAZ_NO, @HATA_ACIKLAMASI, @KULLANICI_ADSOYAD, @YETKILI_ADSOYAD, @CAGRI_DURUM, @CAGRI_ACILIS, @CAGRI_YANIT, @CAGRI_KAPANIS)";
        //        string ForLastPrimaryquery = "SELECT MAX(HAREKET_NUMARASI) AS enyuksekdeger from Hareket";

        //        //using (SqlCommand command = new SqlCommand(ForLastPrimaryquery, connection))
        //        //{
        //        //    // ExecuteScaler() methoduyla sorguyu çalıştırır ve sonucu alır.
        //        //    ForLastPrimary = command.ExecuteScalar();
        //        //}

        //        //var max = _hareketContext.Hareket.Max(p => p.HAREKET_NUMARASI);

        //        using (SqlCommand readCommand = new SqlCommand(ForLastPrimaryquery, connection))
        //        {
        //            var ForLastPrimary = readCommand.ExecuteScalar();

        //            //Hareket hareket = new Hareket();

        //            hareket.CIHAZ_NO = cihazNo;
        //            hareket.HATA_ACIKLAMASI = message;
        //            hareket.HAREKET_NUMARASI = (int)ForLastPrimary + 1;
        //            hareket.CAGRI_ACILIS = now;
        //            //Cihaz cihaz1 = cihaz;

        //            using (SqlCommand command = new SqlCommand(insertQuery, connection))
        //            {

        //                command.Parameters.AddWithValue("@CIHAZ_NO", hareket.CIHAZ_NO); // Modeldeki değerleri buraya göre düzenlemeniz gerekebilir
        //                command.Parameters.AddWithValue("@HATA_ACIKLAMASI", hareket.HATA_ACIKLAMASI);
        //                command.Parameters.AddWithValue("@HAREKET_NUMARASI", hareket.HAREKET_NUMARASI);
        //                command.Parameters.AddWithValue("@KULLANICI_ADSOYAD", cihaz.KULLANICI_AD_SOYAD);
        //                command.Parameters.AddWithValue("@YETKILI_ADSOYAD", "11111");
        //                command.Parameters.AddWithValue("@CAGRI_DURUM", 0);    // values = "1: cihaz arıza verdi", "2: arıza ile ilgileniliyor", "3: arıza çözüldü".
        //                command.Parameters.AddWithValue("@CAGRI_ACILIS", hareket.CAGRI_ACILIS);
        //                command.Parameters.AddWithValue("@CAGRI_YANIT", "");
        //                command.Parameters.AddWithValue("@CAGRI_KAPANIS", "");

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //    //return View("Cagrigiris");
        //    //return View("EskiCagrilar", hareket);

        //    return RedirectToAction("Giris", "Home");
        //    //return View("Giris", "Home");

        //    //return View();
        //    //return RedirectToAction("CagriGiris", "Home");
        //}

        //public ActionResult GetAllHareket(string username)
        //{
        //    //var userSpecificData = _.UserData.Where(u => u.UserID == targetUserID).ToList();
        //    //return View(userSpecificData);

        //    var result = _cihazDal.Get(c => c.SERI_NO == Request.Form["SERI_NO"].ToString());

        //    //return RedirectToAction("CihazGiris", "Home", new { cihaz = result });

        //    //return View("GetCihaz", cihaz);
        //    //return RedirectToAction("Cagrigiris", "Home", cihaz);

        //    TempData["seri"] = Request.Form["SERI_NO"].ToString();

        //    RedirectToAction("SendReport", "CihazlarController", new { data = Request.Form["SERI_NO"].ToString() });

        //    //return View("GetCihaz", cihaz);


        //    return View("GetCihaz");

        //    //return View(cihaz);

        //}

        //[HttpPost]
        //public ActionResult GetCihaz(string seriNo)
        //{
        //    var result = _cihazDal.Get(c => c.SERI_NO == seriNo);
        //    return View(seriNo);
        //}

        // GET: CihazlarController
        /*public ActionResult modeleveriyerlestir()
        {
            SqlCommand 
            return View();
        }
        */
        public ActionResult Index()
        {
            return View();
        }

        // GET: CihazlarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CihazlarController/Create
        public ActionResult Create(Cihaz cihaz)
        {
            //_.AddCihaz(cihaz);
            return View();
        }

        // POST: CihazlarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CihazlarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CihazlarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CihazlarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CihazlarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
