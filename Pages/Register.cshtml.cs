using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProposal_Part1.Models;

namespace WebProposal_Part1.Pages
{
    public class RegisterModel : PageModel
    {
        public Event? ev;
        public Student st = new Student();
        public string message = "";
        public bool success = false;

        public void OnGet(int id)
        {
            ev = findEvent(id);
            if (ev == null)
            {
                message = "Sorry, that event could not be found.";
            }
        }

        public void OnPost(int id, Student st)
        {
            this.st = st;
            ev = findEvent(id);

            try
            {
                if (ev == null)
                {
                    throw new Exception("Sorry, that event could not be found.");
                }

                if (!ModelState.IsValid)
                {
                    return;
                }

                foreach (Registration r in DataStore.registrations)
                {
                    if (r.eventID == ev.eventID && r.stID == st.stID)
                    {
                        throw new Exception("You are already registered for this event.");
                    }
                }

                int registered = DataStore.countRegistrations(ev.eventID);
                if (ev.isFull(registered))
                {
                    throw new Exception("Sorry, this event is full.");
                }

                bool studentExists = false;
                foreach (Student s in DataStore.students)
                {
                    if (s.stID == st.stID) studentExists = true;
                }
                if (!studentExists)
                {
                    DataStore.students.Add(st);
                }

                int newID = DataStore.registrations.Count + 1;
                DataStore.registrations.Add(new Registration(newID, st.stID, ev.eventID));

                success = true;
                message = $"You have successfully registered for {ev.title}!";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        private Event? findEvent(int id)
        {
            foreach (Event e in DataStore.events)
            {
                if (e.eventID == id) return e;
            }
            return null;
        }
    }
}