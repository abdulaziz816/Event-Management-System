using System.ComponentModel.DataAnnotations;

namespace WebProposal_Part1.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please enter your student ID.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Student ID must be exactly 6 digits.")]
        public string stID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public string stName { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string stMail { get; set; }

        public Student() { }

        public Student(string stID, string stName, string stMail)
        {
            this.stID = stID;
            this.stName = stName;
            this.stMail = stMail;
        }

        public string getName()
        {
            return $"{stName} : {stID}";
        }
    }
}