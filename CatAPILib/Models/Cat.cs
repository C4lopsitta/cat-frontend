using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAPILib.Models
{
    public class Cat
    {
        required public string uid {  get; set; }
        required public string name { get; set; }
        required public int age { get; set; }
        required public string description { get; set; }
        required public string whenLastSeen { get; set; }
        required public string whereLastSeen { get; set; }
        required public string race { get; set; }
        required public string furColor { get; set; }
        required public int weight { get; set; }
        required public bool isStray { get; set; }
        required public int? price { get; set; }
        required public string owner { get; set; }
        required public string image { get; set; }
        required public string imageMime { get; set; }

        public Cat(string uid, string name, int age, string description, string whenLastSeen, string whereLastSeen, string race, string furColor, int weight, bool isStray, int? price, string owner, string image, string imageMime)
        {
            this.uid = uid;
            this.name = name;
            this.age = age;
            this.description = description;
            this.whenLastSeen = whenLastSeen;
            this.whereLastSeen = whereLastSeen;
            this.race = race;
            this.furColor = furColor;
            this.weight = weight;
            this.isStray = isStray;
            this.image = image;
            this.imageMime = imageMime;
            this.price = price;
            this.owner = owner;
        }
    }
}
