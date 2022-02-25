using BackendProjectJuan.Helpers;
using BackendProjectJuan.Models;
using BackendProjectJuan.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Controllers
{
    public class AccountController : Controller
    {
        private readonly JuanContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(JuanContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            
            if (!ModelState.IsValid)
                return View();

            AppUser member = await _userManager.FindByNameAsync(registerVM.UserName);

            if (member != null)
            {
                ModelState.AddModelError("UserName", "Username already exists");
            }

            member = new AppUser
            {
                FullName = registerVM.FullName,
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(member, "Member");

            if (!roleResult.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
                return View();
            }

            await _signInManager.SignInAsync(member, true);

            return RedirectToAction("index", "home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginVM.UserName && !x.IsAdmin);

            if (member == null)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(member, loginVM.Password, loginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        [Authorize(Roles = "Member")]
        public IActionResult Profile()
        {
            AppUser member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

            MemberProfileViewModel profileVM = new MemberProfileViewModel
            {
                Member = new MemberProfileUpdateViewModel
                {
                    FullName = member.FullName,
                    UserName = member.UserName,
                    Address = member.Address,
                    Country = member.Country,
                    City = member.City,
                    Phone = member.PhoneNumber,
                    Email = member.Email
                },
                Orders = _context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Product).Where(x => x.AppUserId == member.Id).ToList()
            };
            return View(profileVM);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Edit(MemberProfileUpdateViewModel memberVM)
        {
            MemberProfileViewModel profileVM = new MemberProfileViewModel
            {
                Member = memberVM
            };

            if (!ModelState.IsValid)
                return View("profile", profileVM);

            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            if (member.UserName != memberVM.UserName && _userManager.Users.Any(x => x.NormalizedUserName == memberVM.UserName.ToUpper()))
            {
                ModelState.AddModelError("UserName", "UserName has already taken");
                return View("profile", profileVM);
            }

            if (member.Email != memberVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == memberVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email has already taken ");
                return View("profile", profileVM);
            }

            member.Email = memberVM.Email;
            member.FullName = memberVM.FullName;
            member.UserName = memberVM.UserName;
            member.PhoneNumber = memberVM.Phone;
            member.Country = memberVM.Country;
            member.City = memberVM.City;
            member.Address = memberVM.Address;

            var result = await _userManager.UpdateAsync(member);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("profile", profileVM);
            }

            if (memberVM.Password != null)
            {
                if (string.IsNullOrWhiteSpace(memberVM.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword is required");
                    return View("profile", profileVM);
                }

                if (! await _userManager.CheckPasswordAsync(member, memberVM.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword is incorrect");
                    return View("profile", profileVM);
                }

                var changeResult = await _userManager.ChangePasswordAsync(member, memberVM.CurrentPassword, memberVM.Password);

                if (! changeResult.Succeeded)
                {
                    foreach (var error in changeResult.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                    return View("profile", profileVM);
                }
            }

            TempData["Success"] = "Profile info updated";
            return RedirectToAction("profile");

           
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var member = await _userManager.FindByEmailAsync(email);
            if (member == null)
                return NotFound();

            var token = await _userManager.GeneratePasswordResetTokenAsync(member);

            var link = Url.Action("ResetPassword", "Account", new { member.Id, token }, protocol: HttpContext.Request.Scheme);

            var message = $"<a href='{link}'>Click to reset your password</a>";

            await EmailUtil.SendEmailAsync(email, "Reset Password", message);

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> ResetPassword(string id, string token)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(token))
                return BadRequest();

            var member = await _userManager.FindByIdAsync(id);
            if (member == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string id, string token, ResetPasswordViewModel resetPasswordVm)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(token))
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return View();
            }

            var member = await _userManager.FindByIdAsync(id);
            if (member is null)
                return NotFound();

            var result = await _userManager.ResetPasswordAsync(member, token, resetPasswordVm.NewPassword);

            if (result.Errors == null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Login");
        }

    }
}
