namespace WebProposal_Part1.Models
{
    public class Registration
    {

        public int registrationID { get; set; }
        public string stID { get; set; }
        public int eventID { get; set; }
        public DateTime registrationDate { get; set; }

        public Registration() { }

        public Registration(int registrationID, string stID, int eventID)
        {

            this.registrationID = registrationID;
            this.stID = stID;
            this.eventID = eventID;
            this.registrationDate = DateTime.Now;

        }


    }
}
