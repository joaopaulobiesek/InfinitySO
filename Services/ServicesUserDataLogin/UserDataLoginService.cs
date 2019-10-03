using InfinitySO.Data;
using InfinitySO.Models.ModelsUserDataLogin;
using InfinitySO.Services.ServicesAdministration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InfinitySO.Services.ServicesUserDataLogin
{
    public class UserDataLoginService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MainBoardService _mainBoardService;

        public UserDataLoginService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, MainBoardService mainBoardService)
        {
            _context = context;
            _userManager = userManager;
            _mainBoardService = mainBoardService;
        }

        public async Task<List<UserDataLogin>> FindAllAsync()
        {
            return await _context.UserDataLogin.Include(obj => obj.MainBoard).ToListAsync();
        }

        public async Task InsertAsync(UserDataLogin obj)
        {
            var resultEmail = await _mainBoardService.FindByIdAsync(obj.MainBoardId);
            ApplicationUser app = new ApplicationUser { UserName = resultEmail.Email, Email = resultEmail.Email, MainBoardId = obj.MainBoardId };
            var result = await _userManager.CreateAsync(app, obj.PasswordUser);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(app, new Claim("Home", "1"));
                foreach (var item in obj.SystemControllers)
                {
                    if (item.IsCheck)
                    {
                        await _userManager.AddClaimAsync(app, new Claim(item.NameClaim, "1"));
                    }
                }
                foreach (var item2 in obj.SystemSubControllers)
                {
                    if (item2.IsCheck)
                    {
                        await _userManager.AddClaimAsync(app, new Claim(item2.NameClaim, "2"));
                    }
                }
                UserDataLogin l1 = new UserDataLogin { UserName = resultEmail.Email, PasswordUser = obj.PasswordUser, MainBoardId = obj.MainBoardId };
                _context.Add(l1);
                await _context.SaveChangesAsync();
            }
        }
    }
}