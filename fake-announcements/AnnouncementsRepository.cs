using Microsoft.AspNetCore.Hosting.Server;
using System.Text.Json;

namespace fake_announcements
{
    internal class AnnouncementsRepository
    {
        private readonly string dataFileName = "announcementData.json";
        private static JsonSerializerOptions defaultSerializerSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };



        internal List<Announcement> announcements;
        
        public AnnouncementsRepository()
        {
            announcements = GetAnnouncementData();            
        }

        private List<Announcement>? GetAnnouncementData()
        {            
            announcements = JsonSerializer.Deserialize<List<Announcement>>(File.ReadAllText(dataFileName), defaultSerializerSettings);
            //object obj = JsonSerializer.Deserialize<object>(File.ReadAllText(dataFileName));
            return announcements;
        }

        public List<Announcement> GetAnnouncements()
        {
            return announcements;
        }

        internal List<Announcement> GetAnnouncements(string department)
        {
            return announcements.Where(x => x.Department == department).ToList();
        }
    }
}