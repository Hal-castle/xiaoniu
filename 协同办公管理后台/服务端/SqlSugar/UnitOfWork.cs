using System;
using System.Collections.Generic;
using System.Text;

namespace SqlSugar
{
    public class UnitOfWork
    {
        public DbContext<T> db<T>() where T : class, new()
        {
            return new DbContext<T>();
        }
    }
}
