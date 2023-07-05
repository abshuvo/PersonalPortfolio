using System.ComponentModel.DataAnnotations;

namespace DigiPortfoli.Models.Entities
{
    public class FileInfo
    {
        [Key]
        public int Id { get; set; }
        public int SerialNo { get; set; }
        public string? TableName { get; set; }

        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
    }
}
