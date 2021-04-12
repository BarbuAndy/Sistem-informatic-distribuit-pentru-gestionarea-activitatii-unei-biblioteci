using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public interface IRepositoryWrapper
    {
        IBookRepository BookRepository { get; }

        void Save();
    }
}
