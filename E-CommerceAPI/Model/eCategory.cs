namespace E_CommerceAPI.Model
{
    public class eCategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<eSubCategory> SubCategories { get; set; } = new List<eSubCategory>();
    }
}
