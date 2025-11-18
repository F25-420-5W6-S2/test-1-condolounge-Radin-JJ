namespace CondoLounge.Data.Entities
{
    public class Condo
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public Building Building { get; set; }
        public int BuildingId { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
