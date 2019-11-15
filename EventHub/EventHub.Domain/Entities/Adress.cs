namespace EventHub.Domain.Entities
{
    public class Adress
    {
        public int Id { get; set; }
        public int PublicPlaceId { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string AdressComplement { get; set; }
        public string AdressNumber { get; set; }
    }
}
