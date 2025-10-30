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

                var query = @"SELECT 
                    c.COURSE_ID,
                    c.M_COURSE_ID,
                    c.COURSE,
                    c.OFFLINE_FEES,
                    c.ISACTIVE,
                    c.ISACTIVE_ENQUIRY,
                    c.ISACTIVE_OTHER,
                    c.PRODUCT_TYPE,
                    c.VIDEO_HR,
                    c.TOTAL_NO_LECT,
                    CONVERT(VARCHAR(10), c.VALIDITY_DAY, 105) AS VALIDITY_DAY,
                    c.PRICE,
                    c.DISCOUNT,
                    c.DISCOUNT_SPECIFIC_YES_NO_DATE,
                    c.COURSE_LANGUAGE,
                    c.COURSE_APPLICABLEFOR,
                    CONVERT(VARCHAR(10), c.DISCOUNT_SPECIFIC_DATE, 105) AS DISCOUNT_SPECIFIC_DATE,
                    c.THUMBNAIL,
                    c.PRODUCT_ORDER,
                    c.PRODUCT_DESC,
                    c.PRODUCT_ACHEVEMENT,
                    c.COURSE_VIDEODEMOLINK,
                    m.M_COURSE_NAME
                FROM 
                    dbo.TBL_COURSE AS c
                INNER JOIN 
                    dbo.TBL_COURSE_MASTER AS m 
                    ON c.M_COURSE_ID = m.M_COURSE_ID
                WHERE 
                    c.ISACTIVE = 'Yes'
                    AND c.PRICE IS NOT NULL
                ORDER BY 
                    m.M_COURSE_ID ASC";

               
                var res = await db.QueryAsync<OnlineCourseModel>(query);
                return res.ToList();
            }
        }
    }
}
