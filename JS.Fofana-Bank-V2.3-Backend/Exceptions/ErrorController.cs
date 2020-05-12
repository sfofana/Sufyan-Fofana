using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JS.Fofana_Bank_V2._3_Backend.Exceptions
{
    
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")] 
        public IActionResult Error() => Problem();

    }
}
