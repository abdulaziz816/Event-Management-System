using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProposal_Part1.Models;

namespace WebProposal_Part1.Pages
{
    public class AttendeesModel : PageModel
    {
        public List<Event> eventList = new List<Event>();
        public List<Registration> regList = new List<Registration>();
        public Event? ev;
        public bool showEmails = false;
        public string message = "";

        public void OnGet(int id, bool showEmails)
        {
            eventList = DataStore.events;
            this.showEmails = showEmails;

            if (id == 0)
            {
                return;
            }

            try
            {
                foreach (Event e in DataStore.events)
                {
                    if (e.eventID == id) ev = e;
                }

                if (ev == null)
                {
                    throw new Exception("Sorry, that event could not be found.");
                }

                foreach (Registration r in DataStore.registrations)
                {
                    if (r.eventID == id) regList.Add(r);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        public Student? findStudent(string stID)
        {
            foreach (Student s in DataStore.students)
            {
                if (s.stID == stID) return s;
            }
            return null;
        }
    }
}