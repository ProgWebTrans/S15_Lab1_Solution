using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresseMots_DataAccess.Context;
using PresseMots_DataModels.Entities;
using Vereyon.Web;

namespace PresseMots_Web.Controllers
{
    public class StoriesController : Controller
    {
        private readonly PresseMotsDbContext _context;

        public StoriesController(PresseMotsDbContext context)
        {
            _context = context;
        }

        // GET: Stories/Index/
        public  IActionResult Index(int? Id)
        {
                     
            var presseMotsDbContext = _context.Stories.Where(x=> Id == null || x.Id == Id);

            return View( presseMotsDbContext.ToList());
        }

        public IActionResult SearchByTag(string tagName) {

            //Implantez le
            var presseMotsDbContext = _context.Stories.Where(x=>x.StoryTags.Any(y=>y.Tag.Name.ToUpper() == tagName.ToUpper())).ToList();
            return View(nameof(Index), presseMotsDbContext);


        }


        // GET: Stories/Create
        public IActionResult Create()
        {
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Username");
            return View();
        }

        // POST: Stories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([FromServices] HtmlSanitizer sanitizer, [Bind("Title,Content,OwnerId")] Story story)
        {
            if (ModelState.IsValid)
            {
                story.CreationTime = DateTime.Now;
                story.PublishTime = null;
                story.LastEditTime = null;
                story.Draft = true;
               
                story.Content = sanitizer.Sanitize(story.Content);

                _context.Add(story);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Username", story.OwnerId);
            return View(story);
        }

        // GET: Stories/Edit/5
        public  IActionResult Edit(int id)
        {


            var story =  _context.Stories.Find(id);
            if (story == null)
            {
                return NotFound();
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Username", story.OwnerId);
            return View(story);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit([FromServices] HtmlSanitizer sanitizer, int id, [Bind("Id,Title,Content,Draft,OwnerId,CreationTime,LastEditTime,PublishTime")] Story story)
        {
            if (id != story.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    story.LastEditTime = DateTime.Now;
                    

                    story.Content = sanitizer.Sanitize(story.Content);

                    _context.Update(story);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryExists(story.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OwnerId"] = new SelectList(_context.Users, "Id", "Username", story.OwnerId);
            return View(story);
        }

        // GET: Stories/Delete/5
        public  IActionResult Delete(int id)
        {

            var story =  _context.Stories
                .FirstOrDefault(m => m.Id == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var story =  _context.Stories.Find(id);
            _context.Stories.Remove(story);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.Id == id);
        }
    }
}
