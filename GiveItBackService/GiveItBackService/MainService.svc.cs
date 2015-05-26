using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace GiveItBackService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MainService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MainService.svc or MainService.svc.cs at the Solution Explorer and start debugging.
    public class MainService : IMainService
    {
        public void DoWork()
        {
        }

        /// <summary>
        /// Dodanie nowego membersa z użyciem procedur składowanych. Prawie jak klepanie normalnego SQLa ale podobno tak jest szyciej
        /// a dodatkowo jakby zrobić Entity Framework to by się to uprościło 
        /// Struktura BatPost jest tylko do testu. 
        /// TODO: Stworzyć struktury do wymiany danych między klientem a serwerm - w z
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Zwraca string żeby łatwiej debugować co jest nie tak jak to już leży po stronie serwera.</returns>
        public string InsertMember(BatPost post)
        {
            SqlTransaction transaction = null;
            try
            {
                
                string conn = ConfigurationManager.AppSettings["ConnectionString"];
                using (var sqlConnection = new SqlConnection(conn))
                {
                    sqlConnection.Open();
                    transaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);

                    SqlCommand command = new SqlCommand("InsertMember", sqlConnection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Surname", typeof(string));
                    dataTable.Columns.Add("PhoneNumber", typeof(long));


                    dataTable.Rows.Add(
                                   post.Post,
                                   post.Title,
                                   123455
                             );

                 
                    //Insert
                    var recordsParameter = new SqlParameter("@record", SqlDbType.Structured)
                    {
                        TypeName = "dbo.Members",
                        Value = dataTable
                    };


                    command.Parameters.Add(recordsParameter);
                    command.ExecuteNonQuery();

                    transaction.Commit();

                }
            }
            catch(Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                return ex.Message + ex.InnerException + ex.Source + ex.StackTrace;
            }

            return string.Empty;
        }
        /// <summary>
        /// Metoda testowa do wyciągnięcia danych z bazy
        /// </summary>
        /// <returns></returns>
        public List<BatPost> GetAllData()
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            List<BatPost> result = new List<BatPost>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Members";
                    BatPost post = new BatPost();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        post.PostID = Int32.Parse(reader[0].ToString());
                        post.Title = reader.GetString(1);
                        post.Post = reader.GetString(2);
                        result.Add(post);
                    }

                    connection.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
