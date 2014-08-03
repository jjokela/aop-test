using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***\r\nBegin program - WITH logging\r\n");
            IRepository<Customer> customerRepo = new Repo<Customer>();
            IRepository<Customer> loggerRepo = new LoggerRepository<Customer>(customerRepo);

            var customer = new Customer { Id = 1, Name = "Tero Testaaja", Address = "Testikatu 1" };
            loggerRepo.Add(customer);
            loggerRepo.Update(customer);
            loggerRepo.Delete(customer);
            
            Console.WriteLine("\r\nEnd program - WITH logging\r\n***");
            Console.ReadLine();
        }
    }
}
