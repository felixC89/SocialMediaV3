using Microsoft.EntityFrameworkCore;
using SocialMediaV3.Core.Entities;
using SocialMediaV3.Core.Interfaces;
using SocialMediaV3.InfraStructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.InfraStructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Inyeccion de dependencias de la base de datos scaffoldeada con EF 
        private readonly SocialMediadbContext _context;

        public UserRepository(SocialMediadbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);

            return user;
        }
    }
}
