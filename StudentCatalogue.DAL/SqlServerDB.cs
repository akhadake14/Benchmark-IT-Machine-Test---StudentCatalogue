using StudentCatalogue.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCatalogue.DAL
{
    public class SqlServerDB : DatabaseActivity
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;

        public int SaveStudentData(Student clsStudentData)
        {
            SqlConnection sqlConnection;
            string sql = "INSERT INTO student (first_name, last_name, email,pocket_money,password) Values ('" + clsStudentData.FirstName + "', '" + clsStudentData.FirstName + "', '" + clsStudentData.Email + "', '" + clsStudentData.PckMoney + "', '" + clsStudentData.Password + "')";
            using(sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                int result = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return result;
            }          
        }

        public List<Student> StudentList()
        {
            SqlConnection sqlConnection;
            List<Student> lstStudent = new List<Student>();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Student", sqlConnection);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student");
                if (ds.Tables["Student"].Rows.Count > 0)
                {
                    DataView dv = new DataView();
                    dv = ds.Tables[0].DefaultView;

                    foreach (DataRowView drow in dv)
                    {
                        Student glob_StudentData = new Student();

                        glob_StudentData.ID = Convert.ToInt32(drow["StudentID"]);
                        glob_StudentData.FirstName = Convert.ToString(drow["FirstName"]);
                        glob_StudentData.LastName = Convert.ToString(drow["LastName"]);
                        glob_StudentData.Email = Convert.ToString(drow["Email"]);
                        glob_StudentData.PckMoney = Convert.ToString(drow["PckMoney"]);

                        lstStudent.Add(glob_StudentData);
                    }

                    return lstStudent;
                }
            }
            
            return lstStudent;
        }


        public Student SecondHighestPocketMoneyStudent()
        {
            SqlConnection sqlConnection;
            Student student = new Student();
            using (sqlConnection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 pocket_money FROM(SELECT TOP 2 pocket_money FROM student ORDER BY pocket_money DESC) AS TempTable ORDER BY pocket_money ASC", sqlConnection);
                DataSet ds = new DataSet();
                da.Fill(ds, "Student");
                if (ds.Tables["Student"].Rows.Count > 0)
                {
                    
                    var dataRow = ds.Tables[0].Rows[0];
                    student.ID = Convert.ToInt32(dataRow["StudentID"]);
                    student.FirstName = Convert.ToString(dataRow["FirstName"]);
                    student.LastName = Convert.ToString(dataRow["LastName"]);
                    student.Email = Convert.ToString(dataRow["Email"]);
                    student.PckMoney = Convert.ToString(dataRow["PckMoney"]);

                    return student;
                }
            }

            return student;
        }
    }
}
