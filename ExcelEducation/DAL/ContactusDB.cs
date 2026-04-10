using DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContactusDB
    {
        public async static Task<bool> AddContact(ContactUS contact)
        {
            using (IDbConnection db = new SqlConnection(Connection.MyConnection()))
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("NAME", contact.Name);
                dp.Add("EMAIL", contact.Email);
                dp.Add("PHONE", contact.Phone);
                dp.Add("SUBJECT", contact.Subject);
                dp.Add("MESSAGE", contact.Message);
                dp.Add("ACTION", "1"); // insert

                int result = await db.ExecuteAsync("SP_CONTACTUS", dp, commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public async static Task<List<ContactUS>> LoadContact()
        {
            using (IDbConnection db = new SqlConnection(Connection.MyConnection()))
            {
                DynamicParameters dp = new DynamicParameters();
                dp.Add("ACTION", 4);

                var res = await db.QueryAsync<ContactUS>(
                    "SP_CONTACTUS",
                    dp,
                    commandType: CommandType.StoredProcedure);

                return res.ToList();
            }
        }
    }
}
