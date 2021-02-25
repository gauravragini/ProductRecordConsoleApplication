using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductExceptions;
using productEntity;

namespace DataAccessLayer
{
    public class dataAccess
    {
        SqlConnection c = new SqlConnection("Data Source=DESKTOPRAGINI;Initial Catalog=Training;Integrated Security=True");

        public void d_add(Product p)
        {
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandText = "insert into product values(@pid,@pname,@price)";

                //Assigning Values to parameters
                cmd.Parameters.AddWithValue("@pid", p.pid);
                cmd.Parameters.AddWithValue("@pname",p.pname);
                cmd.Parameters.AddWithValue("@price", p.price);

                //Execute Insert 
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record added");
                c.Close();
            }
            catch(Exception ex)
            {
                throw new productException(ex.Message);
            }
            finally
            {
                c.Close();
            }
          
        }

        public void d_update(Product p)
        {
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandText = "update product set pname=@pname, price =@price where pid=@pid";

                //Assigning Values to parameters
                cmd.Parameters.AddWithValue("@pid", p.pid);
                cmd.Parameters.AddWithValue("@pname", p.pname);
                cmd.Parameters.AddWithValue("@price", p.price);

                //Execute Insert 
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Updated");
            }
            catch(Exception ex)
            {
                throw new productException(ex.Message);
            }
            finally
            {
                c.Close();
            }

        }
        public void d_delete(int id)
        {
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandText = "delete from product where pid = @pid";
                cmd.Parameters.AddWithValue("@pid", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record deleted");
                c.Close();
            }
            catch (Exception ex)
            {
                throw new productException(ex.Message);
            }
            finally
            {
                c.Close();
            }

        }
        public void d_show(int id)
        {
            try
            {
                c.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = c;
                cmd.CommandText = "select * from product where pid = @pid";
                cmd.Parameters.AddWithValue("@pid", id);

                SqlDataReader rd = cmd.ExecuteReader();

                rd.Read();

                Console.WriteLine("\nProduct id: " + rd.GetInt32(0));
                Console.WriteLine("Product name: " + rd.GetString(1));
                Console.WriteLine("Price: " + rd.GetInt32(2));

                c.Close();
            }
            catch (Exception ex)
            {
                throw new productException("Product Does not exist");
            }
            finally
            {
                c.Close();
            }

        }

        public void d_showall()
        {

            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;            
            cmd.CommandText = "select * from product ";

            SqlDataReader rd = cmd.ExecuteReader();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t\tALL PRODUCTS");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            while (rd.Read())  
            {
                Console.WriteLine("\n");
                Console.WriteLine("\t\tProduct id: " + rd.GetInt32(0)); 
                Console.WriteLine("\t\tProduct name: " + rd.GetString(1));
                Console.WriteLine("\t\tPrice: " + rd.GetInt32(2));              
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n");
            c.Close();
        }

        public bool checkifpresent(int id)
        {
            c.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = c;

            cmd.CommandText = "select * from product where pid = @pid";
            cmd.Parameters.AddWithValue("@pid", id);

            SqlDataReader rd1 = cmd.ExecuteReader();

            bool x = rd1.Read();

            c.Close();
            return x;

            
        }


    }
}
