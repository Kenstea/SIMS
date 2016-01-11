using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.ViewModels.Item
{
    public class UpdateInventoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string OldName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int EndangeredQuantity { get; set; }
        
        public bool Endangered { get; set; }
        [Required]
        public int Expected { get; set; }
        [Required]
        public int Actual { get; set; }
        [Required]
        public int Promised { get; set; }
    }
}
