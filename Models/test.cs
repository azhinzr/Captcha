using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Captcha.Models
{
    public class test
    {
        public string key { get; set; }
        public FileStreamResult file { get; set; }
    }
}
