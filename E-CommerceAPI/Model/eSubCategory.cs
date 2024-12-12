namespace E_CommerceAPI.Model
{
    public class eSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public eCategory Category { get; set; }
    }
}
