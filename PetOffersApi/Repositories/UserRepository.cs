using System;
using PetOffersApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PetOffersApi.Interfaces;

namespace PetOffersApi.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private static Dictionary<string, User> _list;

        public UserRepository()
        {
            string filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\users.json";
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                _list = JsonConvert.DeserializeObject<Dictionary<string, User>>(json);
            }
            else
            {
                _list = new Dictionary<string, User>();
            }
        }

        public List<User> GetAll()
        {
            var result = new List<User>();
            foreach (KeyValuePair<string, User> user in _list)
            {
                result.Add(new User() { Email = user.Value.Email, Id = user.Value.Id });
            }

            return result;
        }

        public User Get(string id)
        {
            var user = _list.GetValueOrDefault(id);
            return user;
        }

        public User GetByEmail(string email)
        {
            var user = _list.FirstOrDefault(a=>a.Value.Email.Equals(email,StringComparison.InvariantCultureIgnoreCase));
            return user.Value;
        }

        public void Add(User u)
        {
            if (string.IsNullOrWhiteSpace(u.Id))
            {
                u.Id = Guid.NewGuid().ToString();
            }
            _list.Add(u.Id, u);
        }

        public void Edit(User u)
        {
            _list.Remove(u.Id);
            _list.Add(u.Id, u);
        }

        public void Delete(string id)
        {
            _list.Remove(id);
        }

        public void Dispose()
        {
            if (_list != null && _list.Count > 0)
            {
                string filename = $"{AppDomain.CurrentDomain.BaseDirectory}\\users.json";
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                string output = JsonConvert.SerializeObject(_list);
                File.WriteAllText(filename, output);
            }
        }
    }
}
