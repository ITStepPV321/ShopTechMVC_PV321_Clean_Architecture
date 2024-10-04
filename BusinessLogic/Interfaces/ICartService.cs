using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICartService
    {
        List<ProductDto> GetProducts();
        void Add(int id);
        void Remove(int id);
        void Clear();
    }
}
