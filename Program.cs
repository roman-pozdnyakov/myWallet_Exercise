string[] currencies = {"RUB", "USD", "EUR", "BTC", "GBP", "JPY", "BYR"};
float[,] rates = {  {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1} };
float[] wallet = {50000, 100, 500, 2, 300, 3000, 15000};
bool isContinue = true;

Console.Clear();
//int index = Array.IndexOf(currencies, "ETH");
//Console.WriteLine(index);

while (isContinue)
{
    Console.Write(">");
    string userEntry = Console.ReadLine();
    userEntry = userEntry.ToLower();
    
    switch (userEntry)
    {   case "display":
            Console.WriteLine("Доступные суммы:");
            for (int i = 0; i < currencies.Length; i++) Console.WriteLine(currencies[i] + " " + wallet[i]);
            break;
        /* case "equiv":
            Console.Write("Задайте пароль: ");
            userPassword = Console.ReadLine();
            break;
        case "transfer":
            if (userPassword != "")
            {
                Console.Write("Введите пароль: ");
                userEntry = Console.ReadLine();
                if (userEntry == userPassword) Console.WriteLine(userName);
                else Console.WriteLine("Неверный пароль");
            }
            else Console.WriteLine("Пароль не задан, сначала используйте команду SetPassword");
            break; */
        /*case "convert":
            while (true)
            {
                Console.Write("Доступные валюты:");
                for (int i = 0; i < currencies.Length; i++) Console.Write(currencies[i] + " ");
                Console.WriteLine();
                Console.Write("Из какой валюты? ");
                string fromCur = Console.ReadLine();
                Console.Write("Введите сумму: ");
                double fromAmount = ConverTo.Double(Console.ReadLine());
                Console.Write("В какую валюту? ");
                string fromCur = Console.ReadLine();
                
                double amount = Convert.ToDouble(Console.ReadLine());
            }
            if (userPassword != "")
            {
                Console.Write("Введите пароль: ");
                userEntry = Console.ReadLine();
                if (userEntry == userPassword) Console.WriteLine(userName);
                else Console.WriteLine("Неверный пароль");
            }
            else Console.WriteLine("Пароль не задан, сначала используйте команду SetPassword");
            break;*/
        case "help":
            Console.WriteLine("Display     – Вывести остатки по валютам");
            Console.WriteLine("Equiv       – Отобразить эквивалент кошелька в одной из валют");
            Console.WriteLine("Transfer    – Перевести указанную сумму с одного счёта на другой)");
            Console.WriteLine("Convert     – Справочный пересчёт суммы из одной валюты в другую)");
            Console.WriteLine("Exit        – Выход (на любом этапе ввода");
            Console.WriteLine("Help        – вывести список команд");
            break;
        case "exit":
            isContinue = false;
            break;
        default:
            Console.WriteLine("Команда не найдена");
            break;
    }

}
