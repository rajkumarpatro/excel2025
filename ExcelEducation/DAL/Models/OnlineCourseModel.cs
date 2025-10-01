namespace DAL.Models
{
    public class OnlineCourseModel
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int DurationMonths { get; set; }
        public int NumberOfLectures { get; set; }
        public string ModeOfClasses { get; set; }
        public decimal CourseFees { get; set; }
        public decimal? DiscountedFees { get; set; }
        public string DiscountNote { get; set; }
        public string ImageUrl { get; set; }  // Make sure this is correct pasth 
        public string StartDateText { get; set; }
        public int DisplayOrder { get; set; }
    }

}
