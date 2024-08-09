using System.ComponentModel.DataAnnotations;

namespace CarMgmt.Models
{
    public class CarRequestModel
    {
        [Key] 
        public long Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Class {  get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string MdoelCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Feature {  get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime DateOfManufacturing { get; set; }
        public int SortOrder {  get; set; }        
    }
}
