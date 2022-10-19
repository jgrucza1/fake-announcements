using Microsoft.AspNetCore.Mvc;

namespace fake_announcements.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FakeAnnouncementsController : Controller
    {
        private readonly AnnouncementsRepository _repository;

        public FakeAnnouncementsController()
        {
            _repository = new AnnouncementsRepository();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAnnouncements()
        {
            var announcements = _repository.GetAnnouncements();
            if (announcements == null || announcements.Count == 0)
            {
                return NotFound();
            }

            return announcements;
        }


        [HttpGet("dept")]
        public async Task<ActionResult<IEnumerable<Announcement>>> GetAnnouncements(string dept)
        {
            var announcements = _repository.GetAnnouncements(dept);
            if (announcements == null || announcements.Count == 0)
            {
                return NotFound();
            }

            return announcements;
        }


    }
}
