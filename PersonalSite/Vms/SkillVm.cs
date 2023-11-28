using Microsoft.EntityFrameworkCore;
using PersonalSite.Data;
using PersonalSite.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonalSite.Vms {

    /// <summary>
    /// Represents a simple Skill Viewmodel.
    /// </summary>
    public class SkillVm {

        /// <summary>
        /// The Basic DataContext with DefaultString Rights.
        /// </summary>
        private readonly DataContext _context;

        public SkillVm(DataContext context) {
            SkillItems = new List<DummySkill>();
            _context = context;

            GetListAsync().Wait();
        }

        /// <summary>
        /// Gets the Items List and sets the Property with a duplicate.
        /// </summary>
        /// <returns>The Task to Async/await it.</returns>
        /// <exception cref="NullReferenceException">The Database Context is null.</exception>
        private async Task GetListAsync() {
            if (_context.SkillItem != null) {
                List<SkillItem> list = await _context.SkillItem.ToListAsync();

                foreach (SkillItem item in list) {
                    SkillItems.Add(new() {
                        Language = item.ProgrammingLanguage,
                        Prog = item.Progress,
                        IcLink = item.IconLink,
                        Tutorial = item.Tutorial,
                    });
                }
            } else {
                throw new NullReferenceException("Entity set 'PersonalSite.SkillItem'  is null.");
            }
        }

        /// <summary>
        /// Gets the DummySkills as a Copy from the DataContext.
        /// </summary>
        internal IList<DummySkill> SkillItems {
            get;
            private set;
        }
    }


    /// <summary>
    /// Represents a DummySkillItem.
    /// </summary>
    internal class DummySkill {

        /// <summary>
        /// Gets the Programming Language or Sets it.
        /// </summary>
        [Display(Name = "ProgrammingCaption", ResourceType = typeof(Texts))]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Progress of the Skill Item or sets it.
        /// </summary>
        [Display(Name = "ProgressCaption", ResourceType = typeof(Texts))]
        public ProgressEnum Prog { get; set; } = ProgressEnum.HelloWorld;

        /// <summary>
        /// Gets the Icon Path of the Skill Item or sets it.
        /// </summary>
        [Display(Name = "IconCaption", ResourceType = typeof(Texts))]
        public string IcLink { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Path of an Tutorial/Link to the Language or Skill.
        /// </summary>
        [Display(Name = "TutorialCaption", ResourceType = typeof(Texts))]
        public string Tutorial { get; set; } = string.Empty;
    }
}
