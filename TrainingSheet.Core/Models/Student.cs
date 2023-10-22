using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSheet.Core.Models
{
    public class Student: BaseEntity
    {
        public Student(string fullName, DateTime birthDate, string email) 
            :base()
        {
            FullName = fullName;
            BirthDate = birthDate;
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; set; }



    }
}
