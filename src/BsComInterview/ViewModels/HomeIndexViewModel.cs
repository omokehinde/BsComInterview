using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BsComInterview.Models;
using Microsoft.AspNetCore.Http;

namespace BsComInterview.ViewModels
{
    public class HomeIndexViewModel
    {
        public IFormFile Document { get; set; }

        public User User { get; set; }


    }
}
