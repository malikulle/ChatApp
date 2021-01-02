using ChatApplication.Core.Abstract;
using ChatApplication.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.ViewComponents
{
    public class RoomsViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public RoomsViewComponent(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            var chats = _unitOfWork.ChatRepository.GetAllAsync(x => x.Users.Any(i => i.UserId == user.Id)).Result;

            return View(chats);
        }
    }
}
