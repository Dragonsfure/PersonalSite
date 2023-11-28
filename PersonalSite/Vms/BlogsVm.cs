using Microsoft.EntityFrameworkCore;
using PersonalSite.Data;
using PersonalSite.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalSite.Vms
{
    public class BlogsVm
    {
        private readonly DataContext _context;

        public BlogsVm(DataContext context)
        {
            BlogItems = new List<BlogDummy>();

            _context = context;
            GetListAsync().Wait();
        }

        /// <summary>
        /// Gets the Items List and sets the Property with a duplicate.
        /// </summary>
        /// <returns>The Task to Async/await it.</returns>
        /// <exception cref="NullReferenceException">The Database Context is null.</exception>
        private async Task GetListAsync()
        {
            if (_context.SkillItem != null)
            {
                List<BlogItem> list = await _context.BlogItems.ToListAsync();
                foreach (BlogItem blog in list)
                {
                    BlogItems.Add(new BlogDummy()
                    {
                        Id = blog.ID,
                        Name = blog.Title,
                        Description = blog.ShortInfo,
                        Content = blog.Text,
                        Date = blog.Date
                    });
                }
            }
            else
            {
                throw new NullReferenceException("Entity set 'PersonalSite.BlogItems'  is null.");
            }
        }

        /// <summary>
        /// Gets the Blog-Items used for the View.
        /// </summary>
        internal List<BlogDummy> BlogItems
        {
            get;
            private set;
        }
    }

    internal class BlogDummy
    {

        public int Id { get; set; } = default;

        [Display(Name = "TitleCaption", ResourceType = typeof(Texts))]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "ShortInfoCaption", ResourceType = typeof(Texts))]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "TextCaption", ResourceType = typeof(Texts))]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "DateCaption", ResourceType = typeof(Texts))]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}