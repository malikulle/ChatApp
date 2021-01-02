using ChatApplication.Core.Abstract;
using ChatApplication.Entities.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public ChatController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            if (id == 0)
            {
                return View(new Chat());
            }

            var chat = await _unitOfWork.ChatRepository.GetAsync(x => x.Id == id, x => x.Users, x => x.Messages);

            return View(chat);
        }

        [HttpGet]
        public async Task<IActionResult> JoinRoom(int id)
        {

            var user = await GetLoggedInUser();

            var chat = await _unitOfWork.ChatRepository.GetAsync(x => x.Id == id, x => x.Users);

            if (!chat.Users.Any(x=> x.UserId == user.Id))
            {
                var entity = new ChatUser
                {
                    UserId = user.Id,
                    ChatId = id,
                    UserRole = UserRoleEnum.Member
                };

                await _unitOfWork.ChatUserRepository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), new { id = id });
        }

        private async Task<User> GetLoggedInUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        [HttpGet]
        public async Task<IActionResult> Find()
        {
            var user = await GetLoggedInUser();

            var users = _userManager.Users.Where(x => x.Id != user.Id).ToList();

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> CreatePrivateChat(int Id)
        {
            var user = await GetLoggedInUser();


            var isExist = _unitOfWork.ChatRepository.Queryable()
                .Where(x => x.Type == ChatType.Private && x.Users.Any(i => i.UserId == Id) && x.Users.Any(i => i.UserId == user.Id)).FirstOrDefault();

            if (isExist != null)
            {
                return RedirectToAction(nameof(Index), new { id = isExist.Id });
            }

            var user2 = await _userManager.FindByIdAsync(Id.ToString());

            var entity = new Chat
            {
                Name = user.UserName + "-" + user2.UserName,
                Type = ChatType.Private,
            };
            entity.Users.Add(new ChatUser { UserId = user.Id, UserRole = UserRoleEnum.Member });
            entity.Users.Add(new ChatUser { UserId = Id, UserRole = UserRoleEnum.Member });

            await _unitOfWork.ChatRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { id = entity.Id });

        }
    }
}
