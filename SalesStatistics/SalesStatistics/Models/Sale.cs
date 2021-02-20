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

        [Range(0, Int32.MaxValue)]
        public int Cost { get; set; }

        public DateTime Date { get; set; }
    }
}
