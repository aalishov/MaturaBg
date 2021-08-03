using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolReportsSystem.Models
{
    public class ErasmusKeyActivityOneReport
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public DateTime MobilityStartDate { get; set; }

        public DateTime MobilityEndDate { get; set; }

        public string CourseName { get; set; }

        public string ShortCourseReview { get; set; }
    }
}
