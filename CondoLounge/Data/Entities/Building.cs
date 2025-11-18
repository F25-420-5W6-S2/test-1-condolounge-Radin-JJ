namespace CondoLounge.Data.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string CondoNumber { get; set; }
        public ICollection<Building> Buildings { get; set; }
        public ICollection<Condo> Condos { get; set; }
    }
}
