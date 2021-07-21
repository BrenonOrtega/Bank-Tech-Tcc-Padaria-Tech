using System.Linq;
using PadariaTech.Models;

namespace PadariaTech.Services
{
    public class StockService
    {
        private readonly IBakedProductRepository _bpRepository;
        private readonly IProductRepository _pRepository;

        public StockService(IBakedProductRepository bpRepository, IProductRepository pRepository)
        {
            _bpRepository = bpRepository;
            _pRepository = pRepository;
        }

    }
}