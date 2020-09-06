using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiCertificacion.Models
{
    public class LoginRequest
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }

    }
}