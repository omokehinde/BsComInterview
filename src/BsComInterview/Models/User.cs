using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BsComInterview.Models
{
    public class User
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Your last name should be at least 5 characters long.") MaxLength(65, ErrorMessage = "Your first name should be less than 65 characters.")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Your last name should be at least 5 characters long.") MaxLength(65, ErrorMessage = "Your last name should be less than 65 characters.")]
        public string LastName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Your Email must be at least 5 characters long.") MaxLength(65, ErrorMessage = "Your Email should be less than 65 characters.")]
        [EmailAddress(ErrorMessage = "Type in a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Type in your correct Transaction Number.")]
        public int TransactionNumber { get; set; }



        public List<Document> Documents { get; set; }
    }
}
