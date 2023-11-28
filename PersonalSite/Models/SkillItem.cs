using System.ComponentModel.DataAnnotations;

namespace PersonalSite.Models
{
    public class SkillItem
    {
        /// <summary>
        /// Gets the ID of the Skill Item or sets it. (Primary Key for the Database)
        /// </summary>
        public int ID {
            get; 
            set; 
        }

        /// <summary>
        /// Gets the Programming Language or Sets it.
        /// </summary>
        public string ProgrammingLanguage {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Gets the Progress of the Skill Item or sets it.
        /// </summary>
        public ProgressEnum Progress {
            get;
            set;
        } = ProgressEnum.HelloWorld;

        /// <summary>
        /// Gets the Icon Path of the Skill Item or sets it.
        /// </summary>
        public string IconLink {
            get;
            set; 
        } = string.Empty;


        /// <summary>
        /// Gets the Path of an Tutorial/Link to the Language or Skill.
        /// </summary>
        public string Tutorial {
            get;
            set; 
        }= string.Empty;
    }
}