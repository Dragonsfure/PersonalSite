using PersonalSite.Models;
using PersonalSite.Tools;
using System.ComponentModel.DataAnnotations;

namespace PersonalSite.Vms {

    /// <summary>
    /// Represents a simple Login Viewmodel to handle Login attempts.
    /// </summary>
    public class LoginVm {
        public LoginVm() { }

        /// <summary>
        /// Username of the Login.
        /// </summary>
        [Display(Name = "NameCaption", ResourceType = typeof(Texts))]
        public string Name { get; set; }
        = string.Empty;

        /// <summary>
        /// Password to Login with.
        /// </summary>
        [Display(Name = "PasswordCaption", ResourceType = typeof(Texts))]
        public string Password { get; set; }
        = string.Empty;


        /// <summary>
        /// Checks the Login, if Login is right an AdminVm Instance gets created, if not not.
        /// </summary>
        /// <returns>The Admin Vm, if Login check passed. If not its null.</returns>
        internal AdminVm? Login() {
            if (Name.IsNtEmptyNull() && Password.IsNtEmptyNull()) {
                if (Name == Config.AdminUsername && Password == Config.AdminPassword) {
                    return new AdminVm();
                } else {
                    // Can send Login attempt Mail or so.
                    // if that is wanted.
                    // Or Logs the Attempt.
                }
            }
            return null;
        }
    }
}
