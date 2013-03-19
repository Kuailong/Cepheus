using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Procad.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
