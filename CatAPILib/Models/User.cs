using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CatAPILib.Models
{
    public class User
    {

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public User(string email, string username, string password, string emailConfirmationBaseUrl, string description, string pronouns)
        {
            this.email = email;
            this.username = username;
            this.password = password;
            this.emailConfirmationBaseUrl = emailConfirmationBaseUrl;
            this.description = description;
            this.pronouns = pronouns;
        }

        [JsonConstructor]
        public User(string? uid, string username, string? image, string? imageMime, string description, string pronouns, string[]? cats, string[]? wishlist)
        {
            this.uid = uid;
            this.username = username;
            this.image = image;
            this.imageMime = imageMime;
            this.description = description ?? "";
            this.pronouns = pronouns ?? "";
            this.cats = cats;
            this.wishlist = wishlist;
        }

        [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
        public User()
        {
        }

        public string? uid { get; set; }
        // login
        public string? email {  get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? emailConfirmationBaseUrl { get; set; }
        public string? description { get; set; }
        public string? pronouns { get; set; }
        // ----
        public string? image { get; set; }
        public string? imageMime { get; set; }
        public string[]? cats { get; set; }
        public string[]? wishlist { get; set; }
    }
}