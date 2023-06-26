namespace DatabaseCreation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DB Database = new DB();
                Database.GetEmployee();

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}