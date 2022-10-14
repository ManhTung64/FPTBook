using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.ComponentModel.DataAnnotations;
using FPTBook.Validation;

namespace FPTBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [MinLength(3, ErrorMessage = "Title has to be more than 3 chars")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [MinLength(3, ErrorMessage = "Author's name has to be more than 3 chars")]
        public string Author { get; set; }
        [MinLength(3, ErrorMessage = "Publisher's name has to be more than 3 chars")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [DateValidation(ErrorMessage = "Year is invalid")]
        public int Year { get; set; }
        [Range(1,999999,ErrorMessage = "Max is 99999, min is 1")]
        public int Page { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [Range(1, 999999, ErrorMessage = "Max is 999999, min is 1")]
        public double Price { get; set; }
        [Required(ErrorMessage = "This field cannot be empty")]
        [Range(1, 999, ErrorMessage = "Max is 999, min is 1")]
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
