using System.ComponentModel.DataAnnotations;

namespace PackageAPI.Models
{
    public class gallery
    {
        [Key]
        public int PicId { get; set; }
        public int packageId { get; set; }
        public string PicUrl { get; set; }
    }
}
