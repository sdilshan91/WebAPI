using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Core.IRepositories
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }

        Task CompleteAsync();
    }
}
