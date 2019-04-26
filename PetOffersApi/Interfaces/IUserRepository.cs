using System.Collections.Generic;
using PetOffersApi.Models;

namespace PetOffersApi.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(string id);
        User GetByEmail(string email);
        void Add(User u);
         void Edit(User u);
        void Delete(string id);
    }
}
