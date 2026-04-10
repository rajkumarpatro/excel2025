using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ContactUS
    {
        public int CONTACT_ID { get; set; }
        public string Name { get; set; }
         
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }
         
        public string Message { get; set; }

      
        public string CONTACT_FILEPATH { get; set; }
    }
}
