using System.ComponentModel.DataAnnotations;

namespace HikingEquipment.Services.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; } 
        public string Name { get; set; } 
        public int BrandId { get; set; } 
        public int EquipmentTypeId { get; set; } 
        
        public Brand Brand { get; set; } 
        public EquipmentType EquipmentType { get; set; } 
    }

}