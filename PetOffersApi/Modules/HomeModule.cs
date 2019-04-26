using Nancy;

namespace PetOffersApi.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", _ => "Tchubarundera!");
        }
    }
}
