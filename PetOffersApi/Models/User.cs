using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetOffersApi.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
