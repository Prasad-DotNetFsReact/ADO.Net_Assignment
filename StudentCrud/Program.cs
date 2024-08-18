using System;
using System.Data.SqlClient;
namespace DataBaseConnectity_ADO
{
    internal class Program
    {

        static SqlConnection connection;
        static SqlCommand command;

        static void Main(string[] args)
        {
            int ch = Menu();
            switch (ch)
            {
                case 1: GetRecords(); break;
                case 2: AddRecord(); break;
                case 3: DeleteRecord(); break;
                case 4: EditRecord(); break;
                default:
                    Console.WriteLine("invalid choice"); break;
            }
        }
        static SqlConnection GetConnection()
        {
            string connectionString = "server=DESKTOP-R35ILM0;database=PracticeDb;integrated security=true";
            connection = new SqlConnection(connectionString);
            return connection;
        }

        static int Menu()
        {
            Console.WriteLine("1. Get Records");
            Console.WriteLine("2. Insert Record");
            Console.WriteLine("3. Delete Record");
            Console.WriteLine("4. Edit Record");
            Console.WriteLine("enter your choice");
            int ch = byte.Parse(Console.ReadLine());
            return ch;
        }

        static void GetRecords()
        {

            string connectionString = "server=DESKTOP-R35ILM0;database=PracticeDb;integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "select * from Student";
            command.Connection = connection;
            connection.Open();  

          
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4] + " " + reader[5]);
                }
            }
            else
            {

                Console.WriteLine("there are no records");
            }
            reader.Close();
            connection.Close();
        }
        static void AddRecord()
        {
            string connectionString = "server=DESKTOP-R35ILM0;database=PracticeDb;integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "insert into Student values (1,'poul',null,89,'b','mech')";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); 
            connection.Close();

        }


        static void DeleteRecord()
        {
            string connectionString = "server=DESKTOP-R35ILM0;database=PracticeDb;integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "delete from Student where id=2";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }

        static void EditRecord()
        {
            string connectionString = "server=DESKTOP-R35ILM0;database=PracticeDb;integrated security=true";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandText = "update student set salary=50000 where id=1";
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery(); // for insert update delete
            connection.Close();

        }

    }

}
