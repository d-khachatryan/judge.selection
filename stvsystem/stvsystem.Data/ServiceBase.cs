using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace stvsystem.Data
{
    public class ServiceBase
    {
        protected StvContext db;
        protected Exception exception;
        public Exception ServiceException
        {
            get
            {
                return exception;
            }

        }

        public ServiceBase()
        {
            //Testing
            var optionsBuilder = new DbContextOptionsBuilder<StvContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.\SQL2014;Database=stvsystemDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True", null);
            db = new StvContext(optionsBuilder.Options);
        }

        public ServiceBase(StvContext context)
        {
            db = context;
        }
    }
}
