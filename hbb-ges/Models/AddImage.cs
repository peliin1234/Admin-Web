namespace hbb_ges.Models
{
    public class AddImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }

    }
}
