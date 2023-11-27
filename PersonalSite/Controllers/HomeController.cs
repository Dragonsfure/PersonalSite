using Microsoft.AspNetCore.Mvc;
using PersonalSite.Data;
using PersonalSite.Models;
using PersonalSite.Vms;
using System.Diagnostics;

namespace PersonalSite.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        /// <summary>
        /// Gets the Name of the Controller without the Controller Suffix.
        /// </summary>
        public static readonly string Name = nameof(HomeController)[..nameof(HomeController).IndexOf("Controller")];

        public HomeController(ILogger<HomeController> logger, DataContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Gets the Index Page of the Home-Controller.
        /// </summary>
        /// <returns>The Index Page.</returns>
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        /// <summary>
        /// Gets the Privacy Page of the Home-Controller.
        /// </summary>
        /// <returns>The Privacy Page.</returns>
        [HttpGet]
        public IActionResult Privacy() {
            return View();
        }

        /// <summary>
        /// Gets the Skills Page of the Home-Controller.
        /// </summary>
        /// <returns>The Skills Page.</returns>
        [HttpGet]
        [HttpPost]
        public IActionResult Skills() {
            try {
                SkillVm vm = new(_context);

                return View(vm);
            } catch (NullReferenceException ex) {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets the Blogs Page of the Home-Controller.
        /// </summary>
        /// <returns>The Blogs Page.</returns>
        [HttpGet]
        public IActionResult Blogs() {
            try {
                BlogsVm vm = new(_context);

                return View(vm);
            } catch (NullReferenceException ex) {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Gets the Detailblog Page by the Id.
        /// </summary>
        /// <param name="id">Gets the Blogitem by Id.</param>
        /// <returns>The DetailBlog Page for the Item.</returns>
        [HttpGet]
        public IActionResult DetailBlog(int id) {
            BlogItem? item = _context.BlogItems.FirstOrDefault(x => x.ID == id);

            if (item is not null) {
                return View(item);
            } else {
                return Problem("Entity set 'PersonalSite.BlogItems'  is null.");
            }
        }

        /// <summary>
        /// Gets the Contact Page for the Home-Controller.
        /// </summary>
        /// <returns>The Contact Page.</returns>
        [HttpGet]
        public IActionResult Contact() {
            MailVm vm = new();
            return View(vm);
        }


        /// <summary>
        /// Sends the Mail from the Contact Form.
        /// </summary>
        /// <param name="mailVm">The Mail that should be send.</param>
        /// <returns>The Contact Page with a little Message.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMail(MailVm mailVm) {
            if (ModelState.IsValid) {
                mailVm.SendMail();
                return RedirectToAction(nameof(Privacy), mailVm);
            }
            return View(nameof(Contact), mailVm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}