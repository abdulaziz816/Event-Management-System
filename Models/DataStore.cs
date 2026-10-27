namespace WebProposal_Part1.Models
{
    public static class DataStore
    {

        public static List<Event> events = new List<Event>() {

            
            new Event(1, "SQU Eats", EventCategory.Social, new DateTime(2026, 11, 10, 16, 0, 0), "Student Center For Learning and Prep Studies", 200),
            new Event(2, "Meethaq", EventCategory.Seminar, new DateTime(2026, 11, 14, 10, 0, 0), "SQU Auditorium", 150),
            new Event(3, "CS Workshop", EventCategory.Workshop, new DateTime(2026, 11, 18, 13, 0, 0), "College of Science Lab 22S", 3),
            new Event(4, "Culture Day", EventCategory.Social, new DateTime(2026, 11, 25, 9, 0, 0), "By Science", 300)


        };

        public static List<Student> students = new List<Student>() {

            new Student("146852", "Mohammed Al Abdawani", "s146852@student.squ.edu.om"),
            new Student("145438", "Abdulaziz Junaid", "s145438@student.squ.edu.om"),
            new Student("146823", "Abdullah Fakhr Al Deen", "s146823@student.squ.edu.om"),
            new Student("154328", "Goku Al Lawati", "s154328@student.squ.edu.om")


        };

        public static List<Registration> registrations = new List<Registration>() { 
        
            new Registration(1, "146852", 3),
            new Registration(2, "145438", 3),
            new Registration(3, "146852", 1),
            new Registration(4, "154328", 4)

        };

        public static int countRegistrations(int eventID)
        {
            int count = 0;
            foreach (Registration r in registrations)
            {
                if (r.eventID == eventID) count++;
            }
            return count;
        }


    }
}
