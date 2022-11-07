using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresseMots_DataAccess.Context;
using PresseMots_DataModels.Entities;
using PresseMots_Utility;
using PresseMots_Web.Models;

namespace PresseMots_Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly PresseMotsDbContext _context;

        public CommentsController(PresseMotsDbContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index([FromServices] WordCounter wordCounter, int? storyId)
        {
            if (storyId == null) return RedirectToAction("Index", "Stories");


            var story  = await _context.Stories.Where(x => x.Id == storyId).FirstOrDefaultAsync();


            if (story == null) return NotFound();




            var wordCount = wordCounter.Count(story.Content);
            var title = story.Title;
            var maxSubStr = story.Content?.Length ?? 0;
            if (maxSubStr > 300) maxSubStr = 300;
            var shortStory = story.Content?.Substring(0, maxSubStr);

            var vm = new CommentViewModel();

            vm.WordCount = wordCount;
            vm.ShortTitle = title;
            vm.ShortStory = shortStory;
            vm.StoryId = storyId;
            vm.Comments = story.Comments.Where(x => !x.Hidden).OrderBy(x => x.Id).ToList();



            return View(vm);
        }

 
        // GET: Comments/Create
        public IActionResult Create(int? storyId)
        {
            if (storyId == null) return RedirectToAction("Index", "Stories");
            var comment = new Comment();

            comment.StoryId = storyId ?? 0;

            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Email,DisplayName,Rating,Content,StoryId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public  IActionResult Edit(int id)
        {
        

            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,Email,DisplayName,Rating,Content,Hidden,StoryId")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index),new { storyId=comment.StoryId });
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public  IActionResult Delete(int id)
        {
     

            var comment = _context.Comments.FirstOrDefault(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var comment = _context.Comments.Find(id);
            comment.Hidden = true;
            _context.Update(comment);
            _context.SaveChanges();


            //utiliser le/les delete que vous avez override.

            return RedirectToAction(nameof(Index), new { storyId=comment.StoryId});
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Find(id) != null;
        }
    }
}
