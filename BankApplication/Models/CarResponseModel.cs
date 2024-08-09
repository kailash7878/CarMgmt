using System.ComponentModel.DataAnnotations;

namespace CarMgmt.Models
{
    public class CarResponseModel
    {        
        public long Id { get; set; }        
        public string Brand { get; set; }        
        public string Class { get; set; }        
        public string ModelName { get; set; }        
        public string MdoelCode { get; set; }        
        public string Description { get; set; }        
        public string Feature { get; set; }        
        public decimal Price { get; set; }        
        public DateTime DateOfManufacturing { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
    }
}
