using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PresseMots_DataAccess.Context;
using PresseMots_DataModels.Entities;
using PresseMots_Web.Models;

namespace PresseMots_Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly PresseMotsDbContext _context;

        public UsersController(PresseMotsDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return View(await _context.Users.Select(x=>new SimpleUserViewModel(x.Id,x.Username,x.Email, x.Stories.Count())).ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id )
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);

            if (user == null)
            {
                return NotFound();
            }


            var userStories = user.Stories.Where(x => !x.Draft);
            var stories = userStories.Select(x=>new UserProfileStoryViewModel(x)).ToList();
            var likes = user.Stories.SelectMany(x => x.Likes.Select(y => y.Story)).Select(x => new UserProfileStoryViewModel(x)).ToList();
            var shares = user.Stories.SelectMany(x => x.Shares.Select(y => y.Story)).Select(x => new UserProfileStoryViewModel(x)).ToList();

            var tags = user.Stories.SelectMany(x => x.StoryTags.Select(y => y.TagId)).ToList();
            var likeables = _context.Stories.Where(x => x.StoryTags.Any(x => tags.Contains(x.TagId))).Select(x => new UserProfileStoryViewModel(x)).ToList();

            var userVM = new UserProfileViewModel(user,string.Empty,true,false,false,false, stories,likes,shares, likeables);




            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> DetailsSearch(int? UserId, string SearchTerm, bool AuthoredOpened, bool LikedStoriesOpened, bool SharedStoriesOpened, bool LikeableStoriesOpened)
        {
            if (UserId == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == UserId);

            if (user == null)
            {
                return NotFound();
            }


            var userStories = findStories(user.Stories, SearchTerm);
            var stories = userStories.Select(x => new UserProfileStoryViewModel(x)).ToList();
            var likes = findStories(user.Stories, SearchTerm).SelectMany(x => x.Likes.Select(y => y.Story)).Select(x => new UserProfileStoryViewModel(x)).ToList();
            var shares = findStories(user.Stories, SearchTerm).SelectMany(x => x.Shares.Select(y => y.Story)).Select(x => new UserProfileStoryViewModel(x)).ToList();

            var tags = user.Stories.SelectMany(x => x.StoryTags.Select(y => y.TagId)).ToList();
            var likeables = findStories(_context.Stories, SearchTerm).Where(x => x.StoryTags.Any(x => tags.Contains(x.TagId))).Select(x => new UserProfileStoryViewModel(x)).ToList();

            var userVM = new UserProfileViewModel(user, string.Empty, AuthoredOpened, LikedStoriesOpened,SharedStoriesOpened, LikeableStoriesOpened, stories, likes, shares, likeables);

            return View("Details",userVM);

        }

        private IQueryable<Story> findStories(IEnumerable<Story> stories, string searchText) {

            var elem = stories.AsQueryable();
            searchText = searchText?.ToUpper() ?? String.Empty;
            var searchTextSplit = searchText.Split(" ");
            foreach (var searchItem in searchTextSplit)
            {
                elem = elem.Where(x => x.Title.ToUpper().Contains(searchItem) || x.Content.ToUpper().Contains(searchItem));
                
            }
            return elem;

        
        
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Email,Password")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(new SimpleUserViewModel(user,user.Stories.Count()));
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'PresseMotsDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.Id == id);
        }
    }
}
