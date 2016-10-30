using System.Collections.Generic;

namespace LordoftheRingsSounds.ViewModels
{
    public class Categories
    {
        public Categories()
        {
            ListSounds = new List<Sounds>();
        }

        public List<Sounds> ListSounds { get; set; }
        public string Title { get; set; }
    }
}
