using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib.Models
{
    public class User
    {
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        public User(string email, string username, string password, string emailConfirmationBaseUrl, string description, string pronouns)
        {
            this.email = email;
            this.username = username;
            this.password = password;
            this.emailConfirmationBaseUrl = emailConfirmationBaseUrl;
            this.description = description;
            this.pronouns = pronouns;
        }

        required public string email {  get; set; }
        required public string username { get; set; }
        required public string password { get; set; }
        required public string emailConfirmationBaseUrl { get; set; }
        required public string description { get; set; }
        required public string pronouns { get; set; }
    }
}
