using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using ProductExceptions;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
          bussiness ba = new bussiness();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\t----------------------------------------");
                Console.WriteLine("\t\t 1. Add Product\n\t\t 2. Update Product\n\t\t 3. Delete Product\n\t\t 4. View By ProductID\n\t\t 5. View All Products\n\t\t 6. Exit");
                Console.WriteLine("\t----------------------------------------");

                Console.WriteLine("\nEnter Choice: ");
                int choice = int.Parse(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 1:
                            ba.b_add();
                            break;

                        case 2:
                            ba.b_update();
                            break;

                        case 3:
                            ba.b_delete();
                            break;

                        case 4:
                            ba.b_show();
                            break;

                        case 5:
                            ba.b_showall();
                            break;

                        case 6:
                            flag = false;
                            break;

                        default:
                            break;

                    }
                }
                catch(productException ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }
           
           
           

            
        }
    }
}
