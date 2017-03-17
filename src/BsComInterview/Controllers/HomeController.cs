using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BsComInterview.ViewModels;
using Microsoft.AspNetCore.Authorization;
using BsComInterview.Models;

namespace BsComInterview.Controllers
{
    public class HomeController : Controller
    {

      
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost("UploadFiles")]
        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files, User u)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            //var filePath = Path.Combine(@"~/App_Data", "Files");


            foreach (var formFile in files)
            {
                System.Threading.Thread.Sleep(1000);

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath , FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            var createUser = new User
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Documents = u.Documents
            };

            HomeIndexViewModel vm = new HomeIndexViewModel
            {
                User = createUser
            };

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            //return Ok(new { count = files.Count, size, filePath });
            return View(vm);
        }

        public IActionResult Save()
        {
            return View();
        }

        // POST: /Save File
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Save(HomeIndexViewModel model)
        {
            
            //ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new HomeIndexViewModel
                {
                    User = model.User,
                    Document = model.Document

                };

                //using (var memoryStream = new MemoryStream())
                //{
                //    await model.Document.CopyToAsync(memoryStream);
                //    //user.AvatarImage = memoryStream.ToArray();
                //}

                using (var db = new UserDocContext())
                {
                    var newUser = new User
                    {
                        FirstName = model.User.FirstName,
                        LastName = model.User.LastName,
                        Email = model.User.Email,
                        Documents = model.User.Documents
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                // additional logic omitted
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
