using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalSite.Data;
using PersonalSite.Models;
using PersonalSite.Vms;

namespace PersonalSite.Controllers;

public class AdminController : Controller {
    private readonly ILogger<AdminController> _logger;
    private readonly DataContext _context;

    private readonly UserManager<IdentityUser> userManger;
    private readonly SignInManager<IdentityUser> signInManager;

    /// <summary>
    /// Gets the Name of the Controller without the Controller Suffix.
    /// </summary>
    public static readonly string Name = nameof(AdminController)[..nameof(AdminController).IndexOf("Controller")];

    public AdminController(ILogger<AdminController> logger, DataContext context,
        UserManager<IdentityUser> _userManger, SignInManager<IdentityUser> _signInManager) {
        _logger = logger;
        _context = context;
        userManger = _userManger;
        signInManager = _signInManager;
    }

    [HttpGet]
    public IActionResult Index(AdminVm model) {


        return View(model);
    }


    [HttpGet]
    [Authorize]
    public IActionResult Privacy(MailVm mailVm) {
        return View(mailVm);
    }

    [HttpGet]
    [HttpPost]
    [Authorize]
    public IActionResult Skills() {
        try {
            SkillVm vm = new(_context);

            return View(vm);
        } catch (NullReferenceException ex) {
            return Problem(ex.Message);
        }
    }


    [HttpGet]
    public IActionResult Login() {
        LoginVm userLogin = new();
        return View(userLogin);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginAsync(LoginVm model) {
        if (ModelState.IsValid) {
            AdminVm? adminVm = model.Login();
            if (adminVm is not null) {
                var result = await signInManager.PasswordSignInAsync(model.Name, model.Password, false, true);
                if (result.Succeeded) {
                    return RedirectToAction(
                        actionName: nameof(HomeController.Index),
                        controllerName: Name);
                }
                ModelState.AddModelError("", "UserName or Password is incorrect");
            }
        }
        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> SignUserOut() {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Authorize]
    public IActionResult Contact() {

        return View();
    }


    [HttpGet]
    [Authorize]
    public IActionResult Blogs() {
        try {
            BlogsVm vm = new(_context);

            return View(vm);
        } catch (NullReferenceException ex) {
            return Problem(ex.Message);
        }
    }


    [HttpGet]
    [Authorize]
    public IActionResult DetailBlog(int id) {
        BlogItem? item = _context.BlogItems.FirstOrDefault(x => x.ID == id);

        if (item is not null) {
            return View(item);
        } else {
            return Problem("Entity set 'PersonalSite.BlogItems'  is null.");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult SendMail(MailVm mailVm) {
        if (ModelState.IsValid) {
            mailVm.SendMail();
            return RedirectToAction(nameof(Privacy), mailVm);
        }
        return View("Privacy", mailVm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
