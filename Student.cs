using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms1
{
    class Student
    {
        public void CheckConnection()
        {
            try
            {
                Connect().Open();
                MessageBox.Show("Connection Open  !");
                Connect().Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Fail  !");
            }
        }

        public void CreatDB()
        {
            String sql = "CREATE TABLE `db`.`student` ( `ID` INT NOT NULL , `Name` CHAR(25) NOT NULL , `Email` CHAR(25) NOT NULL );";
            SqlCommand command = new SqlCommand(sql, Connect());
            command.ExecuteNonQuery();
            MessageBox.Show("DB has been Creat  !");
        }

        public void Insert(String ID, String Name, String Email)
        {
            String sql = "INSERT INTO `student` (`ID`, `Name`, `Email`) VALUES('" + ID + "', '" + Name + "', '" + Email + "');";
            SqlCommand command = new SqlCommand(sql, Connect());
            command.ExecuteNonQuery();
            MessageBox.Show("DB has been Creat  !");
        }

        public void Delete(String ID)
        {
            String sql = "DELETE FROM `student` WHERE `ID` = " + ID + ";";
            SqlCommand command = new SqlCommand(sql, Connect());
            command.ExecuteNonQuery();
            MessageBox.Show("DB has been Creat  !");
        }

        public SqlConnection Connect()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "your_password";
            builder.InitialCatalog = "master";
            SqlConnection cnn = new SqlConnection(builder.ConnectionString);
            return cnn;
        }
    }
}
