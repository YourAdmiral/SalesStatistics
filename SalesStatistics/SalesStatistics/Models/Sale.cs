using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalesStatistics.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Product { get; set; }

        [Required]
        [MaxLength(40)]
        public string Client { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public double Cost { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
