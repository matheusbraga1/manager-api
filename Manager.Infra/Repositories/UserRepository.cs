﻿using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users.Where(x => x.Email.ToLower() == email.ToLower()).AsNoTracking().ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUsersByEmail = await _context.Users.Where(x => x.Email.ToLower().Contains(email.ToLower())).AsNoTracking().ToListAsync();

            return allUsersByEmail;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUsersByName = await _context.Users.Where(x => x.Name.Contains(name)).AsNoTracking().ToListAsync();

            return allUsersByName;
        }
    }
}
