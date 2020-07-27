using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace HrgaEnhance.Models
{
    public class ClsLogin
    {
        [Required(ErrorMessage = "Nrp harus diisi")]
        public String userid { get; set; }

        [Required(ErrorMessage = "Password harus diisi")]
        public String password { get; set; }

        public IQueryable<tblLogin> getLogin()
        {
            LtsAdroWebDataContext dataContext = new LtsAdroWebDataContext();
            return dataContext.tblLogins;
        }
    }
}