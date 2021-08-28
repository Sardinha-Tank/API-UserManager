using System.Linq;
using System.Threading.Tasks;
using UserManager.Infra.Context;
using UserManager.Domain.Entities;
using UserManager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserManager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UserManagerContext _context;

        public UserRepository(UserManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                     .Where
                                     (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()
                                     )
                                     .AsNoTracking()
                                     .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUsers = await _context.Users
                                     .Where
                                     (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())
                                     )
                                     .AsNoTracking()
                                     .ToListAsync();

            return allUsers;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUsers = await _context.Users
                                     .Where
                                     (
                                        x =>
                                            x.Name.ToLower().Contains(name.ToLower())
                                     )
                                     .AsNoTracking()
                                     .ToListAsync();

            return allUsers;
        }
    }
}