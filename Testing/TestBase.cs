using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public abstract class TestBase: IDisposable
    {
        protected DbContext Context  { get; set; }
        protected ServiceProvider ServiceProvider { get; set; }

        protected TestBase()
        {

            var services = new ServiceCollection();

        }   //Configurar EF
          
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
