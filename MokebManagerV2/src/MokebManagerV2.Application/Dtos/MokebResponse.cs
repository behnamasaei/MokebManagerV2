using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokebManagerV2.Dtos
{
    public class MokebResponse<T> where T : class
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T? Data { get; set; }
    }
}
