using EventHub.Application.Services.EventApplication.Input;

namespace EventHub.Application.Services.EventApplication
{
    public class EventAdress
    {
        public AdressPublicPlace PublicPlace { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string AdressComplement { get; set; }
        public string AdressNumber { get; set; }
    }
}
