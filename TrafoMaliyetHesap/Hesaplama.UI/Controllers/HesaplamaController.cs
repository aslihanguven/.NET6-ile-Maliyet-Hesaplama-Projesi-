using Hesaplama.DataLayer.Context;
using Hesaplama.DataLayer.Repositories.Interfaces.EntityTypeRepositories;
using Hesaplama.EntityLayer.Abstract;
using Hesaplama.EntityLayer.Concrete;
using Hesaplama.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace Hesaplama.UI.Controllers
{
    public class HesaplamaController : Controller
    {
        private readonly IHesaplamaRepository _hesaplamaRepository;
        private readonly ApplicationDbContext _context;

        public HesaplamaController(IHesaplamaRepository hesaplamaRepository, ApplicationDbContext context)
        {
            _hesaplamaRepository = hesaplamaRepository;
            _context = context;
        }

        public IActionResult Ekle()
        {
            return PartialView("_HesaplamaEklePartial");
        }
        [HttpPost]
        public IActionResult Ekle(HesaplamalarVM data)
        {
            if (ModelState.IsValid)
            {

                Hesaplamalar hesaplamalar = new Hesaplamalar();


                hesaplamalar.ProjeNo = data.ProjeNo;
                hesaplamalar.Guc = data.Guc;
                hesaplamalar.AGgerilim = data.AGgerilim;
                hesaplamalar.YGgerilim = data.YGgerilim;

                hesaplamalar.KazanUzunluk = data.KazanUzunluk;
                hesaplamalar.KazanGenislik = data.KazanGenislik;
                hesaplamalar.KazanYukseklik = data.KazanYukseklik;
                hesaplamalar.Maliyet = data.Maliyet;

                _hesaplamaRepository.Create(hesaplamalar);
                TempData["Success"] = "Hesaplama Ekleme Başarılı..!";
                return RedirectToAction("Liste");

            }
            return View(data);
        }
        public IActionResult Liste() => View(_hesaplamaRepository.GetByDefaults(x => x.Status != Status.Passive).OrderByDescending(x => x.CreateDate));

        public IActionResult Guncelle(int id)
        {
            Hesaplamalar hesaplamalar = _hesaplamaRepository.GetById(id);
            if (hesaplamalar != null)
            {
                HesaplamalarVM hesaplamalarVM = hesaplamalar.Adapt<HesaplamalarVM>();
                return PartialView("_HesaplamaGuncellePartial",hesaplamalarVM);
            }
            else
            {
                TempData["Warning"] = "Hesaplama Kaydı Bulunamadı..!";
                return RedirectToAction("Liste");
            }
        }
        [HttpPost]
        public IActionResult Guncelle(HesaplamalarVM data)
        {
            if (ModelState.IsValid)
            {
                Hesaplamalar hesaplamalar = _hesaplamaRepository.GetById(data.Id);
                if (hesaplamalar != null)
                {

                    hesaplamalar.ProjeNo = data.ProjeNo;
                    hesaplamalar.Guc = data.Guc;
                    hesaplamalar.AGgerilim = data.AGgerilim;
                    hesaplamalar.YGgerilim = data.YGgerilim;

                    hesaplamalar.KazanUzunluk = data.KazanUzunluk;
                    hesaplamalar.KazanGenislik = data.KazanGenislik;
                    hesaplamalar.KazanYukseklik = data.KazanYukseklik;
                    hesaplamalar.Maliyet = data.Maliyet;


                    _hesaplamaRepository.Update(hesaplamalar);
                    TempData["Success"] = "Hesaplama Güncelleme Başarılı..!";
                    return RedirectToAction("Liste");
                }
                else
                {
                    TempData["Warning"] = "Hesaplama Kaydı Bulunamadı";
                    return RedirectToAction("Liste");
                }
            }
            else
            {
                TempData["Error"] = "Hesaplama Kaydı Bulunamadı";
                return View(data);
            }
        }
        public IActionResult Sil(int id)
        {

            Hesaplamalar hesaplama = _hesaplamaRepository.GetById(id);
            if (hesaplama != null)
            {
                hesaplama.Status = Status.Passive;
                hesaplama.DeleteDate = DateTime.Now;
                _hesaplamaRepository.Delete(hesaplama);

                TempData["Success"] = "Hesaplama Kaydı Silindi..!";
                return RedirectToAction("Liste");
            }
            else
            {
                TempData["Error"] = "Hesaplama Kaydı Silinemedi..!";
                return RedirectToAction("Liste");
            }
        }
    }
}
