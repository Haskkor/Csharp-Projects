using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using _3NETMiniProjet1.Models;

namespace _3NETMiniProjet1.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<EventManagerEntities>
    {
        protected override void Seed(EventManagerEntities context)
        {
            base.Seed(context);

            var users = AddUsers(context);
            var roles = AddRoles(context);
            var events = AddEvents(context);
            var eventTypes = AddEventTypes(context);
            var eventStatus = AddEventStatuses(context);
            var contributions = AddContributions(context);
            var contributionTypes = AddContributionTypes(context);

            context.SaveChanges();
        }

        private static List<Role> AddRoles(EventManagerEntities context)
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Website Admin" },
                new Role { Name = "User" }
            };
            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
            return roles;
        }

        private static List<User> AddUsers(EventManagerEntities context)
        {
            var users = new List<User>
            {
                new User { FirstName = "Vincent", LastName = "Boyreau", Password = "vinboy", NickName = "vinboy", RoleId = 3, FriendsListId = new List<int>() {2}},
                new User { FirstName = "Francois", LastName = "Laffont", Password = "fralaf", NickName = "fralaf", RoleId = 2, FriendsListId = new List<int>() {1,3,7}},
                new User { FirstName = "Olivier", LastName = "Dalstein", Password = "olidal", NickName = "olidal", RoleId = 3, FriendsListId = new List<int>() {1,2,6,7}},
                new User { FirstName = "Mareme", LastName = "Diagne", Password = "mardia", NickName = "mardia", RoleId = 3, FriendsListId = new List<int>() {1,2,3,5,6,7}},
                new User { FirstName = "Jeremy", LastName = "Farnault", Password = "jerfar", NickName = "jerfar", RoleId = 1, FriendsListId = new List<int>()},
                new User { FirstName = "Carole", LastName = "Gobbo", Password = "cargob", NickName = "cargob", RoleId = 3, FriendsListId = new List<int>() {1,2,3,4,5,7}},
                new User { FirstName = "Joel", LastName = "Ortet", Password = "joeort", NickName = "joeort", RoleId = 3, FriendsListId = new List<int>() {1,2,5,6}}
            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            return users;
        }

        private static List<EventType> AddEventTypes(EventManagerEntities context)
        {
            var eventTypes = new List<EventType>
            {
                new EventType { Name = "Party" },
                new EventType { Name = "Lunch" },
                new EventType { Name = "Roleplaying Game" },
                new EventType { Name = "LAN" }
            };
            eventTypes.ForEach(s => context.EventTypes.Add(s));
            context.SaveChanges();
            return eventTypes;
        }

        private static List<EventStatus> AddEventStatuses(EventManagerEntities context)
        {
            var eventStatuses = new List<EventStatus>
            {
                new EventStatus { Name = "Open" },
                new EventStatus { Name = "Closed" },
                new EventStatus { Name = "Pending" }
            };
            eventStatuses.ForEach(s => context.EventStatuses.Add(s));
            context.SaveChanges();
            return eventStatuses;
        }

        private static List<Event> AddEvents(EventManagerEntities context)
        {
            var events = new List<Event>
            {
                new Event { Name = "Pathfinder Campaign", Address = "52 rue Fontvieille", Description = "Campagne Pathfinder.", Date = new DateTime(2014, 5, 18), Time = "19h00", GuestsList = new List<int>(){6,7}, EventStatusId = 1, EventTypeId = 3, CreatorId = 5},
                new Event { Name = "Partyyyyyy", Address = "69 rue du Hot Club", Description = "Boobs and booze.", Date = new DateTime(2014, 8, 3), Time = "22h00", GuestsList = new List<int>(){1,3,4,5,6,7}, EventStatusId = 3, EventTypeId = 1, CreatorId = 2},
                new Event { Name = "Lunch at home", Address = "2 rue de la pomme", Description = "Diner chez Carole.", Date = new DateTime(2014, 2, 5), Time = "20h00", GuestsList = new List<int>(){1,2,7}, EventStatusId = 2, EventTypeId = 2, CreatorId = 6}
            };
            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();
            return events;
        }

        private static List<ContributionType> AddContributionTypes(EventManagerEntities context)
        {
            var contributionTypes = new List<ContributionType>
            {
                new ContributionType { Name = "Money" },
                new ContributionType { Name = "Food" },
                new ContributionType { Name = "Beverage" }
            };
            contributionTypes.ForEach(s => context.ContributionTypes.Add(s));
            context.SaveChanges();
            return contributionTypes;
        }

        private static List<Contribution> AddContributions(EventManagerEntities context)
        {
            var contributions = new List<Contribution>
            {
                new Contribution { Name = "Chips pour JDR", Quantity = 2, ContributionTypeId = 2, EventId = 1},
                new Contribution { Name = "Monney for bitcheeeees", Quantity = 1500, ContributionTypeId = 1, EventId = 2}
            };
            contributions.ForEach(s => context.Contributions.Add(s));
            context.SaveChanges();
            return contributions;
        }
    }
}