using FirstStep.Новая_папка;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FirstStep
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool isalive = true;

            while (isalive)
            {
                Console.WriteLine("1 - Create\n2 - Update\n3 - Delete\n4 - SelectAll");
                int num = int.Parse(Console.ReadLine());
                if (num == 1)
                {
                    await Create();
                    
                }
                if (num == 2)
                {
                    Console.Write("Enter your Id = ");
                    await Update(int.Parse(Console.ReadLine()));
                }
                if (num == 3)
                {
                    await Delete();
                    isalive = false;
                }
                if (num == 4)
                {
                    await Select();
                }
            }
            


            #region
            //using (AppDbContext context = new AppDbContext())
            //{
            //    Employee empl = new Employee { FirstName = "Shahzod", LastName = "Akhmedov", MiddleName = "Alijonovich", DateOfBirth = DateTime.Parse("2000-02-01"), DocumentNumber = "AS789456123" };
            //    context.Employees.Add(empl);
            //    context.SaveChanges();
            //    Console.WriteLine("Data is saved!");
            //    var employee = context.Employees.ToList();
            //    foreach (var item in employee)
            //    {
            //        Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.MiddleName + " " + item.DateOfBirth + " " + item.DocumentNumber);
            //    }

            //}
            #endregion
        }

        private static async Task Update(int Id)
        {
            
            try
            {
                using (AppDbContext context = new AppDbContext())
                {

                    var employees = context.Employees.Find(Id);
                    Console.Write("Enter new name = ");
                    employees.FirstName = Console.ReadLine();
                    await context.SaveChangesAsync();
                    Console.WriteLine("The name is successfully UpDated! ");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            
        }

        private static async Task Create()
        {
            try
            {
                var @newEmployee = new Employee();
                Console.Write("FirstName = ");
                newEmployee.FirstName = Console.ReadLine();
                Console.Write("LastName = ");
                newEmployee.LastName = Console.ReadLine();
                Console.Write("MiddleName = ");
                newEmployee.MiddleName = Console.ReadLine();
                Console.Write("DateOfBirth = ");
                newEmployee.DateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.Write("DocumentNumber = ");
                newEmployee.DocumentNumber = Console.ReadLine();
                using (AppDbContext context = new AppDbContext())
                {
                    context.Employees.Add(newEmployee);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Data is saved!");
                    var employee = context.Employees.ToList();
                    foreach (var item in employee)
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.MiddleName + " " + item.DateOfBirth + " " + item.DocumentNumber);
                    }

                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private static async Task Delete()
        {
            try
            {
                Console.WriteLine("Id = ");
                var Id = int.Parse(Console.ReadLine());
                using (AppDbContext context = new AppDbContext())
                {
                    var employees = await context.Employees.FindAsync(Id);
                    context.Remove(employees);
                    await context.SaveChangesAsync();
                }
                Console.WriteLine("Successfully deleted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static async Task Select()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var employee = context.Employees.ToList();
                    await context.SaveChangesAsync();
                    foreach (var item in employee)
                    {
                        Console.WriteLine(item.FirstName + " " + item.LastName + "" + item.MiddleName + " " + item.DateOfBirth + " " + item.DocumentNumber);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

    }
}
