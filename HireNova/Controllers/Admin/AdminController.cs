using HireNova.Data_Model.DTOs;
using HireNova.Data_Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace HireNova.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminLoginService _adminLoginService;
        private readonly IAdminDashboardService _dashboardService;
        private readonly IAdminUserService _adminUserService;
        private readonly ICandidateService _candidateService;
        private readonly IRecruiterService _recruiterService;

        public AdminController(
            IAdminLoginService adminLoginService,
            IAdminDashboardService dashboardService,
            IAdminUserService adminUserService,
            ICandidateService candidateService,
            IRecruiterService recruiterService)
        {
            _adminLoginService = adminLoginService;
            _dashboardService = dashboardService;
            _adminUserService = adminUserService;
            _candidateService = candidateService;
            _recruiterService = recruiterService;
        }

        // GET: /Admin/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("AdminId") != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(new AdminLoginDTO());
        }

        // POST: /Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var admin = await _adminLoginService
                .GetAdminByEmailAsync(model.Email);

            if (admin == null ||
                !_adminLoginService.VerifyPassword(
                    model.Password,
                    admin.PasswordHash))
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid email or password.");

                return View(model);
            }

            HttpContext.Session.SetInt32(
                "AdminId", admin.AdminId);

            HttpContext.Session.SetString(
                "AdminName", admin.FullName);

            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var dashboard =
                await _dashboardService.GetSummaryAsync();

            return View(dashboard);
        }

        // GET: /Admin/Users
        [HttpGet]
        public async Task<IActionResult> Users(string? search)
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
            {
                return RedirectToAction(nameof(Login));
            }

            ViewBag.Search = search;

            var users = await _adminUserService
                .GetUsersAsync(search);

            return View(users);
        }

        // GET: /Admin/Candidates
        [HttpGet]
        public async Task<IActionResult> Candidates(string? search)
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
            {
                return RedirectToAction(nameof(Login));
            }

            ViewBag.Search = search;

            var candidates = await _candidateService
                .GetCandidatesAsync(search);

            return View(candidates);
        }

        // GET: /Admin/Recruiters
        [HttpGet]
        public async Task<IActionResult> Recruiters(
            string? search,
            int statusFilter = -1)
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
            {
                return RedirectToAction(nameof(Login));
            }

            ViewBag.Search = search;
            ViewBag.StatusFilter = statusFilter;

            var recruiters = await _recruiterService
                .GetRecruitersAsync(search, statusFilter);

            return View(recruiters);
        }

        // GET: /Admin/CandidateDetails
        [HttpGet]
        public async Task<IActionResult> CandidateDetails(int id)
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
            {
                return RedirectToAction(nameof(Login));
            }

            if (id <= 0)
            {
                return BadRequest();
            }

            var candidate =
                await _candidateService.GetCandidateByIdAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            var education =
                await _candidateService.GetCandidateEducationAsync(id);

            ViewBag.Education = education;

            return View(candidate);
        }

        // POST: /Admin/UpdateCandidateStatus
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCandidateStatus(
            int userId,
            bool status)
        {
            if (HttpContext.Session.GetInt32("AdminId") == null)
            {
                return RedirectToAction(nameof(Login));
            }

            if (userId <= 0)
            {
                return BadRequest();
            }

            bool updated = await _candidateService
                .UpdateCandidateStatusAsync(userId, status);

            if (!updated)
            {
                TempData["ErrorMessage"] =
                    "Failed to update candidate status.";
            }
            else
            {
                TempData["SuccessMessage"] = status
                    ? "Candidate activated successfully."
                    : "Candidate deactivated successfully.";
            }

            return RedirectToAction(nameof(Candidates));
        }

        // GET: /Admin/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
