using Nancy;
using Nancy.ModelBinding;
using PetOffersApi.Interfaces;
using PetOffersApi.Models;
using PetOffersApi.Repositories;

namespace PetOffersApi.Modules
{
    public class UserModule : NancyModule
    {
        public readonly IUserRepository _repository;
        public UserModule(IUserRepository repository)
        {
            _repository = repository;

            Get("/user/", _ => _repository.GetAll());

            Get("/user/{id}", args =>
            {
                var user= _repository.Get(args.id);
                if (user == null) return null;
                return new User() { Email = user.Email, Id = user.Id, Name = user.Name };
            });

            Get("/sessions/{id}", args =>
            {
                var user = _repository.Get(args.id);
                return new { Allowed = user != null};
            });

            Post("/user/", args =>
            {
                var pessoa = this.Bind<User>();

                _repository.Add(pessoa);

                return pessoa;
            });

            Post("/login/", args =>
            {
                var u = this.Bind<User>();

                var user = _repository.Get(u.Id);
                if(user==null) return new { Allowed = false };

                return new { Allowed = user.Pwd.Equals(u.Pwd) }; ;
            });

            Put("/user/{id}", args =>
            {
                var pessoa = this.Bind<User>();

                pessoa.Id = args.id;

                _repository.Edit(pessoa);

                return pessoa;
            });
        }
    }
}
