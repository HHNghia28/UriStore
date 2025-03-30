using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Application.Wrappers
{
    public class PagedRequestWithSearch : PagedRequest
    {
        public string Search { get; set; }
    }
}
