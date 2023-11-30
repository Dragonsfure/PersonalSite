using System.ComponentModel.DataAnnotations;

namespace PersonalSite.Models {
    public class MailItem {

        /// <summary>
        /// The ID for the Mail, so it can be saved to an Database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name/Adress of the Creator.
        /// </summary>
        [Required]
        [Display(Name = "NameCaption", ResourceType = typeof(Texts))]
        public string Name { get; set; }
        = string.Empty;

        /// <summary>
        /// Name/Adress of the Creator.
        /// </summary>
        [Display(Name = "FromMailCaption", ResourceType = typeof(Texts))]
        [EmailAddress]
        [Required]
        public string FromMail { get; set; }
        = string.Empty;

        /// <summary>
        /// Gets the Subject of the Mail or sets it.
        /// </summary>
        [Display(Name = "SubjectCaption", ResourceType = typeof(Texts))]
        [Required]
        public string Subject { get; set; }
        = string.Empty;

        /// <summary>
        /// Gets or sets the Content of the Mail.
        /// </summary>
        [Display(Name = "ContentCaption", ResourceType = typeof(Texts))]
        [Required]
        public string Content { get; set; }
        = string.Empty;

        /// <summary>
        /// Gets or sets the Datetime of the Creation/Sended Mail.
        /// </summary>
        public DateTime Created { get; set; }
        = DateTime.Now;
    }
}
