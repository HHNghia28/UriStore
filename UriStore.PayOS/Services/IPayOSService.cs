using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UriStore.PayOS.DTO;

namespace UriStore.PayOS.Services
{
    public interface IPayOSService
    {
        Task<string> CreatePaymentAsync(CreatePaymentDTO createPaymentDTO);
    }
}
