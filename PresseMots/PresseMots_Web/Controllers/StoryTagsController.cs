using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresseMots_DataAccess.Context;
using PresseMots_DataModels.Entities;

namespace PresseMots_Web.Controllers
{
    public class StoryTagsController : Controller
    {
        private readonly PresseMotsDbContext _context;

        public StoryTagsController(PresseMotsDbContext context)
        {
            _context = context;
        }


  
        public async Task<IActionResult> Create(int storyId)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(m => m.Id == storyId);
            if (story == null)
            {
                return NotFound();
            }
            ViewBag.StoryTitle = story.Title;


            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name");
            return View(new StoryTag() { Id=0, StoryId=storyId, TagId=0});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StoryId,TagId")] StoryTag storyTag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storyTag);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Stories", new { Id = storyTag.StoryId});
            }

            var story = await _context.Stories.FirstOrDefaultAsync(m => m.Id == storyTag.StoryId);
            if (story == null)
            {
                return NotFound();
            }
            ViewBag.StoryTitle = story.Title;

            ViewData["TagId"] = new SelectList(_context.Tags, "Id", "Name", storyTag.TagId);
            return View(storyTag);
        }

      

      


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StoryTags == null)
            {
                return NotFound();
            }

            var storyTag = await _context.StoryTags.FirstOrDefaultAsync(m => m.Id == id);
            if (storyTag == null)
            {
                return NotFound();
            }

            return View(storyTag);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StoryTags == null)
            {
                return Problem("Entity set 'PresseMotsDbContext.StoryTags'  is null.");
            }
            var storyTag = await _context.StoryTags.FindAsync(id);
            var storyId = storyTag.StoryId;
            if (storyTag != null)
            {
                _context.StoryTags.Remove(storyTag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Stories", new { Id=storyId});
        }

  
    }
}
