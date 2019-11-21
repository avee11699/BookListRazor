using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListrazor.model
{
    public class books
    {
        [Key]

        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }
        public string Author { get; set; }

        public string ISPN { get; set; }

    }
}
