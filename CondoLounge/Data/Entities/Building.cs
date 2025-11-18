namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string CondoNumber { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public ICollection<Condo> Condos { get; set; }
    }
}
