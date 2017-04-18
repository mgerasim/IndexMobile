using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexMobileEntity.Helper
{
    public class DataClass
    {
        private SQLiteConnection sqlite;

        public DataClass()
        {

            sqlite = new SQLiteConnection("Data Source=IndexMobile.db;Pooling=true;FailIfMissing=false;BinaryGUID=false;New=false;Compress=true;Version=3");
        }

        public DataTable selectQuery(string query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                sqlite.Open();  //Initiate connection to the db
                cmd = sqlite.CreateCommand();
                cmd.CommandText = query;  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            finally
            {
                sqlite.Close();
            }
            return dt;
        }
    }
}
