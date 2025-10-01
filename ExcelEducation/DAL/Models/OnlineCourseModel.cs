namespace DAL.Models
{
    public class OnlineCourseModel
    {
        public int COURSE_ID { get; set; }
        public int M_COURSE_ID { get; set; }
        public string COURSE { get; set; }
        public decimal OFFLINE_FEES { get; set; } 
        public string ISACTIVE { get; set; }
        public string ISACTIVE_ENQUIRY { get; set; }
        public string ISACTIVE_OTHER { get; set; }
        public string PRODUCT_TYPE { get; set; }
        public decimal VIDEO_HR { get; set; }
        public int? TOTAL_NO_LECT { get; set; }
        public string VALIDITY_DAY { get; set; }   // Converted to string (from query)
        public decimal PRICE { get; set; }
        public decimal? DISCOUNT { get; set; }
        public string DiscountDISCOUNT_SPECIFIC_YES_NO_DATESpecificYesNoDate { get; set; }
        public string COURSE_LANGUAGE { get; set; }
        public string COURSE_APPLICABLEFOR { get; set; }
        public string DISCOUNT_SPECIFIC_DATE { get; set; }  // Converted to string (from query)
        public string THUMBNAIL { get; set; }
        public int? PRODUCT_ORDER { get; set; }
        public string PRODUCT_DESC { get; set; }
        public string PRODUCT_ACHEVEMENT { get; set; }
        public string COURSE_VIDEODEMOLINK { get; set; }    
        public string M_COURSE_NAME { get; set; }
        
    }

}
