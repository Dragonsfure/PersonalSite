namespace PersonalSite.Models {
    public class BlogItem {

        /// <summary>
        /// Gets the Id or sets it, PrimaryKey for the Database.
        /// </summary>
        public int ID {
            get; 
            set;
        }

        /// <summary>
        /// Gets the Title or sets it.
        /// </summary>
        public string Title {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Gets the ShortInfo or sets it.
        /// </summary>
        public string ShortInfo {
            get;
            set;
        }= string.Empty;

        /// <summary>
        /// Gets the Text or sets it.
        /// </summary>
        public string Text {
            get;
            set;
        }=string.Empty;

        /// <summary>
        /// Gets the Date or sets it.
        /// </summary>
        /// <remarks>
        /// Gets updated, when Editing the Entry or Creating an new Entry.
        /// </remarks>
        public DateTime Date {
            get;
            set;
        }= DateTime.Now;
    }
}
