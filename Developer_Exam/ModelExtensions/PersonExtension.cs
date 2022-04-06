using Developer_Exam.Helpers.DataAccess;
using Developer_Exam.Models;
using System.Data;
using System.Data.SqlClient;

namespace Developer_Exam.ModelExtensions
{
    public class PersonExtension
    {

        public static List<Person>? All(string connectionString)
        {
            DataTable datatable = MSSQL.GetDataTable(
                "usp_GetPerson",
                CommandType.StoredProcedure,
                connectionString
            );

            if (datatable.Rows.Count > 0)
            {
                return (
                    from DataRow row in datatable.Rows
                    select new Person()
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        FirstName =  string.IsNullOrEmpty(row["FirstName"].ToString()) ? "" : row["FirstName"].ToString(),
                        MiddleName = string.IsNullOrEmpty(row["MiddleName"].ToString()) ? "" : row["MiddleName"].ToString(),
                        LastName = string.IsNullOrEmpty(row["LastName"].ToString()) ? "" : row["LastName"].ToString(),
                    }
                ).ToList();
            }
            else
                return null;
        }

        public static int Save(Person model, string connectionString)
        {
            return MSSQL.ExecuteScalar<int>(
                 "usp_SavePerson",
                 CommandType.StoredProcedure,
                 connectionString,
                 new SqlParameter("Id", model.Id.ToString()),
                 new SqlParameter("FirstName", model.FirstName),
                 new SqlParameter("MiddleName", model.MiddleName),
                 new SqlParameter("LastName", model.LastName)
                );
        }


        public static int Delete(int id, string connectionString)
        {
            return MSSQL.ExecuteScalar<int>(
                 "usp_DeletePerson",
                 CommandType.StoredProcedure,
                 connectionString,
                 new SqlParameter("Id", id)
                );
        }


    }
}
