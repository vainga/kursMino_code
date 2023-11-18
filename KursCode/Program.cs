using Clients;

namespace KursCode
{

    class Program
    {
        public static void Main(string[] args)
        {
            User user = new User();
            corporationClass corporation = new corporationClass();
            workerClass worker = new workerClass();
            int id = 1;

            Console.WriteLine("1)Вход\n2)Регистрация");
            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                user.EnterInformation();
                id = user.Enter();
            }
            else if(x == 2)
            {
                user.EnterInformation();
                user.Registration();
            }
            Console.WriteLine("\n1)Добавить корпорацию\n2)Добавить работника");
            x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                corporation.EnterInformation();
                corporation.AddData(id);
            }
            else if (x == 2)
            {
                worker.EnterInformation();
                worker.AddData(id);
            }
        }
    }
}