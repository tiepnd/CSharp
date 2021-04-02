using DependencyInjection.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Service.Implement
{
    public class ProductService : IProductService

    {
        public int Get()
        {
            return 1;
        }
    }
}
