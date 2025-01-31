using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Domain.Shares
{
    public static class OrderIdUtility
    {
        public static long GetNewOrderId()
        {
            long id = long.Parse(DateUtility.GetCurrentDateTimeAsString("yyyyMMddHHmmssffff")) - 200000000000000000;

            return id;
        }
    }
}
