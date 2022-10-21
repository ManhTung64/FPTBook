using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTBook.Models
{
    public class Bill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
