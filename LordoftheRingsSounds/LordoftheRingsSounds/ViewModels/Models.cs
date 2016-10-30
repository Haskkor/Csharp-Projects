namespace LordoftheRingsSounds.ViewModels
{
    public class Models
    {
        public Categories Fellowship { get; set; }
        public Categories Creatures { get; set; }
        public Categories Elves { get; set; }
        public Categories Hobbits { get; set; }
        public Categories Men { get; set; }
        public bool Loaded { get; set; }

        public void Load()
        {
            Fellowship = CreateFellowshipCategory();
            Creatures = CreateCreaturesCategory();
            Elves = CreateElvesCategory();
            Hobbits = CreateHobbitsCategory();
            Men = CreateMenCategory();

            Loaded = true;
        }

        private static Categories CreateFellowshipCategory()
        {
            var cat = new Categories { Title = "Fellowship" };

            cat.ListSounds.Add(new Sounds { Title = "Gandalf", Path = "Assets/Sounds/Fellowship/Gandalf.mp3", ImagePath = "Assets/Images/Fellowship/Gandalf.png" });
            cat.ListSounds.Add(new Sounds { Title = "Aragorn", Path = "Assets/Sounds/Fellowship/Aragorn.mp3", ImagePath = "Assets/Images/Fellowship/Aragorn.png" });
            cat.ListSounds.Add(new Sounds { Title = "Boromir", Path = "Assets/Sounds/Fellowship/Boromir.mp3", ImagePath = "Assets/Images/Fellowship/Boromir.png" });
            cat.ListSounds.Add(new Sounds { Title = "Frodo", Path = "Assets/Sounds/Fellowship/Frodo.mp3", ImagePath = "Assets/Images/Fellowship/Frodo.png" });
            cat.ListSounds.Add(new Sounds { Title = "Samwise", Path = "Assets/Sounds/Fellowship/Samwise.mp3", ImagePath = "Assets/Images/Fellowship/Samwise.png" });
            cat.ListSounds.Add(new Sounds { Title = "Peregrin", Path = "Assets/Sounds/Fellowship/Peregrin.mp3", ImagePath = "Assets/Images/Fellowship/Peregrin.png" });
            cat.ListSounds.Add(new Sounds { Title = "Meriadoc", Path = "Assets/Sounds/Fellowship/Meriadoc.mp3", ImagePath = "Assets/Images/Fellowship/Meriadoc.png" });
            cat.ListSounds.Add(new Sounds { Title = "Legolas", Path = "Assets/Sounds/Fellowship/Legolas.mp3", ImagePath = "Assets/Images/Fellowship/Legolas.png" });
            cat.ListSounds.Add(new Sounds { Title = "Gimli", Path = "Assets/Sounds/Fellowship/Gimli.mp3", ImagePath = "Assets/Images/Fellowship/Gimli.png" });

            return cat;
        }

        private static Categories CreateCreaturesCategory()
        {
            var cat = new Categories { Title = "Creatures" };

            cat.ListSounds.Add(new Sounds { Title = "Gollum", Path = "Assets/Sounds/Creatures/Gollum.mp3", ImagePath = "Assets/Images/Creatures/Gollum.png" });
            cat.ListSounds.Add(new Sounds { Title = "Treebeard", Path = "Assets/Sounds/Creatures/Treebeard.mp3", ImagePath = "Assets/Images/Creatures/Treebeard.png" });
            cat.ListSounds.Add(new Sounds { Title = "Lurtz", Path = "Assets/Sounds/Creatures/Lurtz.mp3", ImagePath = "Assets/Images/Creatures/Lurtz.png" });
            cat.ListSounds.Add(new Sounds { Title = "Snaga", Path = "Assets/Sounds/Creatures/Snaga.mp3", ImagePath = "Assets/Images/Creatures/Snaga.png" });
            cat.ListSounds.Add(new Sounds { Title = "Grishnakh", Path = "Assets/Sounds/Creatures/Grishnakh.mp3", ImagePath = "Assets/Images/Creatures/Grishnakh.png" });

            return cat;
        }

        private static Categories CreateElvesCategory()
        {
            var cat = new Categories { Title = "Elves" };

            cat.ListSounds.Add(new Sounds { Title = "Arwen", Path = "Assets/Sounds/Elves/Arwen.mp3", ImagePath = "Assets/Images/Elves/Arwen.png" });
            cat.ListSounds.Add(new Sounds { Title = "Celeborn", Path = "Assets/Sounds/Elves/Celeborn.mp3", ImagePath = "Assets/Images/Elves/Celeborn.png" });
            cat.ListSounds.Add(new Sounds { Title = "Elrond", Path = "Assets/Sounds/Elves/Elrond.mp3", ImagePath = "Assets/Images/Elves/Elrond.png" });
            cat.ListSounds.Add(new Sounds { Title = "Galadriel", Path = "Assets/Sounds/Elves/Galadriel.mp3", ImagePath = "Assets/Images/Elves/Galadriel.png" });
            cat.ListSounds.Add(new Sounds { Title = "Haldir", Path = "Assets/Sounds/Elves/Haldir.mp3", ImagePath = "Assets/Images/Elves/Haldir.png" });
            cat.ListSounds.Add(new Sounds { Title = "Legolas", Path = "Assets/Sounds/Elves/Legolas.mp3", ImagePath = "Assets/Images/Elves/Legolas.png" });

            return cat;
        }

        private static Categories CreateHobbitsCategory()
        {
            var cat = new Categories { Title = "Hobbits" };

            cat.ListSounds.Add(new Sounds { Title = "Bilbo", Path = "Assets/Sounds/Hobbits/Bilbo.mp3", ImagePath = "Assets/Images/Hobbits/Bilbo.png" });
            cat.ListSounds.Add(new Sounds { Title = "Frodo", Path = "Assets/Sounds/Hobbits/Frodo.mp3", ImagePath = "Assets/Images/Hobbits/Frodo.png" });
            cat.ListSounds.Add(new Sounds { Title = "Gaffer", Path = "Assets/Sounds/Hobbits/Gaffer.mp3", ImagePath = "Assets/Images/Hobbits/Gaffer.png" });
            cat.ListSounds.Add(new Sounds { Title = "Meriadoc", Path = "Assets/Sounds/Hobbits/Meriadoc.mp3", ImagePath = "Assets/Images/Hobbits/Meriadoc.png" });
            cat.ListSounds.Add(new Sounds { Title = "Old Noakes", Path = "Assets/Sounds/Hobbits/OldNoakes.mp3", ImagePath = "Assets/Images/Hobbits/OldNoakes.png" });
            cat.ListSounds.Add(new Sounds { Title = "Peregrin", Path = "Assets/Sounds/Hobbits/Peregrin.mp3", ImagePath = "Assets/Images/Hobbits/Peregrin.png" });
            cat.ListSounds.Add(new Sounds { Title = "Samwise", Path = "Assets/Sounds/Hobbits/Samwise.mp3", ImagePath = "Assets/Images/Hobbits/Samwise.png" });

            return cat;
        }

        private static Categories CreateMenCategory()
        {
            var cat = new Categories { Title = "Men" };

            cat.ListSounds.Add(new Sounds { Title = "Denethor", Path = "Assets/Sounds/Men/Denethor.mp3", ImagePath = "Assets/Images/Men/Denethor.png" });
            cat.ListSounds.Add(new Sounds { Title = "Eomer", Path = "Assets/Sounds/Men/Eomer.mp3", ImagePath = "Assets/Images/Men/Eomer.png" });
            cat.ListSounds.Add(new Sounds { Title = "Eowyn", Path = "Assets/Sounds/Men/Eowyn.mp3", ImagePath = "Assets/Images/Men/Eowyn.png" });
            cat.ListSounds.Add(new Sounds { Title = "Faramir", Path = "Assets/Sounds/Men/Faramir.mp3", ImagePath = "Assets/Images/Men/Faramir.png" });
            cat.ListSounds.Add(new Sounds { Title = "Gamling", Path = "Assets/Sounds/Men/Gamling.mp3", ImagePath = "Assets/Images/Men/Gamling.png" });
            cat.ListSounds.Add(new Sounds { Title = "Grima", Path = "Assets/Sounds/Men/Grima.mp3", ImagePath = "Assets/Images/Men/Grima.png" });
            cat.ListSounds.Add(new Sounds { Title = "Haleth", Path = "Assets/Sounds/Men/Haleth.mp3", ImagePath = "Assets/Images/Men/Haleth.png" });
            cat.ListSounds.Add(new Sounds { Title = "Hama", Path = "Assets/Sounds/Men/Hama.mp3", ImagePath = "Assets/Images/Men/Hama.png" });
            cat.ListSounds.Add(new Sounds { Title = "Theoden", Path = "Assets/Sounds/Men/Theoden.mp3", ImagePath = "Assets/Images/Men/Theoden.png" });
            cat.ListSounds.Add(new Sounds { Title = "Aragorn", Path = "Assets/Sounds/Men/Aragorn.mp3", ImagePath = "Assets/Images/Men/Aragorn.png" });
            cat.ListSounds.Add(new Sounds { Title = "Boromir", Path = "Assets/Sounds/Men/Boromir.mp3", ImagePath = "Assets/Images/Men/Boromir.png" });

            return cat;
        }
    }
}
