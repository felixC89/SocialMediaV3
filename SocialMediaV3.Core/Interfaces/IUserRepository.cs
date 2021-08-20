using SocialMediaV3.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMediaV3.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
    }
}