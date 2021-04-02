using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Models
{
    public class QuoteByPeople
    {
        [Key]
        public int QId { get; set; }
        [Required]
        //I had to name it quote notes because it woulnd't let me use quotes becasue I used that as the project name
        public string QuotesNote { get; set; }
        [Required]
        public string AuthorFirst { get; set; }

        [Required]
        public string AuthorLast { get; set; }

        public string? Subject { get; set; } ="none";

        public string? Citation { get; set; } = "none";
        [Required]
        public DateTime Date { get; set; }
    }
}
