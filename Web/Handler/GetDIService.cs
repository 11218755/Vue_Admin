using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.IServices;

namespace Web.Handler
{
    public static class GetDIService
    {
        public static IServiceScope Instance { get; set; }
    }
}
