using EtheReal.Data;
using EtheReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtheReal.Areas.admin.Controllers
{
    [Area("admin")]
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;

        public CommentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        { 
            var model= _context.Comments.Include(e => e.CustomUser).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.CustomUser = _context.CustomUsers.ToList();


            return View();
        }

        [HttpPost]
        
        public IActionResult Create(Comment model)
        {

            ViewBag.CustomUser = _context.CustomUsers.ToList();

            _context.Comments.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Comment");

        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            ViewBag.CustomUser = _context.CustomUsers.ToList();
            Comment comment =  _context.Comments.Find(id);

            return View(comment);
        }
        [HttpPost]

        public IActionResult Update(Comment model)
        {

            _context.Comments.Update(model);
            _context.SaveChanges();
            return RedirectToAction("index", "comment");


        }

        public IActionResult Delete(int? id)
        {
            Comment model = _context.Comments.Find(id);

            _context.Comments.Remove(model);
            _context.SaveChanges();

            return RedirectToAction("index", "comment");



        }


    }
}
