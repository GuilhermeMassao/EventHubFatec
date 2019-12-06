namespace EventHub.Domain.Input
{
    public class EventAdress
    {
        public int PublicPlaceId { get; set; }
        public string PlaceName { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string AdressComplement { get; set; }
        public string AdressNumber { get; set; }
    }
}
