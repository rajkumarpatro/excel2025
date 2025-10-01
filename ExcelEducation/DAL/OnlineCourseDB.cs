using Dapper;
using DAL.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public static class OnlineCourseDB
    {
        // Method to get all courses
        public async static Task<List<OnlineCourseModel>> LoadAllCoursesAsync()
        {
            using (IDbConnection db = new SqlConnection(Connection.MyConnection()))
            {
                db.Open();

                var query = @"SELECT dbo.TBL_COURSE.COURSE_ID, dbo.TBL_COURSE.M_COURSE_ID, dbo.TBL_COURSE.COURSE, 
                                    dbo.TBL_COURSE.OFFLINE_FEES, dbo.TBL_COURSE.ISACTIVE , dbo.TBL_COURSE.ISACTIVE_ENQUIRY, dbo.TBL_COURSE.ISACTIVE_OTHER, 
                                    dbo.TBL_COURSE.PRODUCT_TYPE, dbo.TBL_COURSE.VIDEO_HR, dbo.TBL_COURSE.TOTAL_NO_LECT, CONVERT(VARCHAR(10),dbo.TBL_COURSE.VALIDITY_DAY,105) as VALIDITY_DAY, dbo.TBL_COURSE.PRICE, 
                                    dbo.TBL_COURSE.DISCOUNT,dbo.TBL_COURSE.DISCOUNT_SPECIFIC_YES_NO_DATE,dbo.TBL_COURSE.COURSE_LANGUAGE,dbo.TBL_COURSE.COURSE_APPLICABLEFOR,
                                    CONVERT(VARCHAR(10),dbo.TBL_COURSE.DISCOUNT_SPECIFIC_DATE,105) as DISCOUNT_SPECIFIC_DATE, dbo.TBL_COURSE.THUMBNAIL, dbo.TBL_COURSE.PRODUCT_ORDER,
                                    dbo.TBL_COURSE.PRODUCT_DESC, dbo.TBL_COURSE.PRODUCT_ACHEVEMENT,dbo.TBL_COURSE.COURSE_VIDEODEMOLINK, dbo.TBL_COURSE_MASTER.M_COURSE_NAME
                                     FROM dbo.TBL_COURSE
                                     INNER JOIN dbo.TBL_COURSE_MASTER ON dbo.TBL_COURSE.M_COURSE_ID = dbo.TBL_COURSE_MASTER.M_COURSE_ID where dbo.TBL_COURSE.ISACTIVE='Yes' and dbo.TBL_COURSE.PRICE IS NOT NULL order by dbo.TBL_COURSE.COURSE_ID Desc";

               
                var res = await db.QueryAsync<OnlineCourseModel>(query);
                return res.ToList();
            }
        }
    }
}
