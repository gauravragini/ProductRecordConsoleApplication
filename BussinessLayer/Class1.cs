using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ProductExceptions;
using productEntity;

namespace BussinessLayer
{
    public class bussiness
    {
        dataAccess da = new dataAccess();
        public void b_add()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Enter Product id ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Product name ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Product price ");
                int price = int.Parse(Console.ReadLine());

                Product p = new Product(id, name, price);

                da.d_add(p);
            }            
            catch(Exception ex)
            {
                throw new productException(ex.Message);
            }
           
        }
        public void b_update()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Enter Product id to be updated:");
                int id = int.Parse(Console.ReadLine());
                if (da.checkifpresent(id))
                {
                    Console.WriteLine("Enter new Product name ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter new Product price ");
                    int price = int.Parse(Console.ReadLine());
                    Product p = new Product(id, name, price);
                    da.d_update(p);
                }
                else
                {
                    throw new productException("Record does not exist");
                }               
            }            
            catch(Exception ex)
            {
                throw new productException(ex.Message);
            }
            
        }
        public void b_delete()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Enter Product id to be deleted:");
                int id = int.Parse(Console.ReadLine());
                if (da.checkifpresent(id))
                    da.d_delete(id);
                else
                {
                    throw new productException("Record does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new productException(ex.Message);
            }
            
        }

        public void b_show()
        {
            try
            {
                Console.WriteLine("\n");
                Console.WriteLine("Enter Product id to be viewed: ");
                int id = int.Parse(Console.ReadLine());
                da.d_show(id);
            }
            catch (Exception ex)
            {
                throw new productException(ex.Message);
            }
            
        }

        public void b_showall()
        {
            da.d_showall();
        }

       
    }
}
