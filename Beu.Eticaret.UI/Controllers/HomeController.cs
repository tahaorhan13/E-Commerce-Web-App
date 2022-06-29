using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Beu.Eticaret.UI.Controllers
{
    public class HomeController : Controller
    {
        private IHostEnvironment _env;
        public HomeController(IHostEnvironment env)
        {
            _env = env;
        }
        public IActionResult Cart() => View();
        public IActionResult FileUpload() => View();
        public IActionResult TesbihYukle() => View();
        public IActionResult KolyeYukle() => View();
        public IActionResult YuzukYukle() => View();
        public IActionResult KupeYukle() => View();
        public IActionResult BileklikYukle() => View();
        public IActionResult Product() => View();
        public IActionResult Tesbih() => View();
        public IActionResult Bileklik() => View();
        public IActionResult Yüzük() => View();
        public IActionResult Kolye() => View();
        public IActionResult Kupe() => View();
        public IActionResult Register() => View();
        public IActionResult AdminRegister() => View();
        public IActionResult Login() => View();
        public IActionResult Profile() => View();
        public IActionResult Hakkımızda() => View();
        public IActionResult İletisim() => View();
        public IActionResult AccessDenied() => View();
        public IActionResult ProductDetails() => View();
        public IActionResult SingleFile(IFormFile file)
        {
            var dir = "C:\\Users\\tahao\\Desktop\\eticaret-main\\Beu.Eticaret.UI\\wwwroot\\images";
            using (var fileStream = new FileStream(Path.Combine(dir, file.FileName), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }
            return RedirectToAction("FileUpload");
        }
    }
}
