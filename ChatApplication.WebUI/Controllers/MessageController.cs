using ChatApplication.Core.Abstract;
using ChatApplication.Entities.Domain;
using ChatApplication.WebUI.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.WebUI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly UserManager<User> _userManager;

        public MessageController(IUnitOfWork unitOfWork, IHubContext<ChatHub> hubContext, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hubContext = hubContext;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage(string message, string chatId)
        {
            var user = await GetLoggedInUser();

            var entity = new Message
            {
                ChatId = Convert.ToInt32(chatId),
                UserId = user.Id,
                Name = user.UserName,
                TimeStamp = DateTime.Now,
                Text = message,
            };

            await _unitOfWork.MessageRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            await _hubContext.Clients.Group(chatId).SendAsync("ReceiveMessage", entity);

            return Ok();
        }



        private async Task<User> GetLoggedInUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

    }
}
