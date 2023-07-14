
namespace ADODotNetDemo
{
    public class program
    {
        public static void Main(string[] args)
        {
            bool check=true;
            Customer customerobj = new Customer();
            while (check)
            {
                Console.WriteLine(" \nWelcome to CustomerDatabase");
                Console.WriteLine("1.Create Database\n2.create Table\n" +
                         "3.Insert data in Table\n4.Add PhoneNumber in table\n" +
                         "5.Update data in table.\n6.Delete data from table.\n" +
                         "7.Display table.\n8.Insert data using store procedure.\n" +
                         "9.Display data using store procedure.");
                int result = (int)Convert.ToInt32(Console.ReadLine());
                switch(result)
                {
                case 1:
                        Customer.CreateDatabase();
                        break;
                case 2:
                        Customer.CreateTable();
                        break;
                case 3:
                         Customer.InsertTable();
                        break;
                case 4:
                        Customer.AlterTable();
                        break;
                case 5:
                        Customer.UpdateTable();
                        break;
                case 6:
                        Customer.DeleteTable();
                        break;
                case 7:
                        Customer.Display();
                        break;
                case 8:
                        CustomerMode customermodeobj = new CustomerMode();
                        customermodeobj.Name = "kartik";
                        customermodeobj.City = "pune";
                        customermodeobj.Phone_Number = 99999999;
                        customerobj.InsertStoreProcedure(customermodeobj);
                        break;
                case 9:
                        CustomerMode customermodeobj2 = new CustomerMode();
                        customerobj.DisplayStoreProcedure(customermodeobj2);
                        break;
                }
            } 
        }
    }
}