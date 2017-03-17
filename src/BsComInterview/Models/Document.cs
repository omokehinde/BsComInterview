using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BsComInterview.Models
{
    public enum TransactionNumber
    {

    }

    public class Document
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public byte[] File { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

    }
}
