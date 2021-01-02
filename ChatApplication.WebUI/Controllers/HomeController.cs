using ChatApplication.Core.Abstract;
using ChatApplication.Entities.Domain;
using ChatApplication.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await GetLoggedInUser();

            var entity = new Chat
            {
                Name = name,
                Type = ChatType.Room,                
            };
            entity.Users.Add(new ChatUser { UserId = user.Id, UserRole = UserRoleEnum.Admin });

            await _unitOfWork.ChatRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private async Task<User> GetLoggedInUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
