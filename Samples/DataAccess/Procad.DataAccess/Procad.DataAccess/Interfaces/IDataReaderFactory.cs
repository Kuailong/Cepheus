using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Procad.DataAccess.Interfaces
{
    public interface IDataReaderFactory<T>
    {
        T Fabricate(IDataReader dataReader);
    }
}
