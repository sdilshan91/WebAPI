using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApi.Core.IRepositories;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Core.Repositories
{
    public class UsersRepository: GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Users>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All() Method Error", typeof(UsersRepository));
                return new List<Users>();
            }
        }

        public override async Task<bool> Update(Users user)
        {
            try
            {
                var existing_user = await _dbSet.FirstOrDefaultAsync(x => x.Id == user.Id);
                if (existing_user == null)
                {
                    return await Add(user);
                }

                existing_user.FirstName = user.FirstName;
                existing_user.LastName = user.LastName;
                existing_user.Email = user.Email;
                existing_user.JoinnedDate = user.JoinnedDate;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update() Method Error", typeof(UsersRepository));
                return false;
            }
        }

        public override async Task<bool> Remove(Users user)
        {
            try
            {
                var existing_user = await _dbSet.FirstOrDefaultAsync(x => x.Id == user.Id);
                if (existing_user != null)
                {
                    _dbSet.Remove(user);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"{Repo} Remove() Method Error", typeof(UsersRepository));
                return false;
            }
        }
    }
}
