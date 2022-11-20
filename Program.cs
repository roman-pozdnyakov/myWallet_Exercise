string[] currencies = {"RUB", "USD", "EUR", "BTC", "GBP", "JPY", "BYR"};
float[,] rates = {  {1, 1, 1, 1, 1, 1, 1},  // таблица с курсами
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1}, 
                    {1, 1, 1, 1, 1, 1, 1},
                    {1, 1, 1, 1, 1, 1, 1} };
float[] wallet = {50000, 100, 500, 2, 300, 3000, 15000}; // Начальные суммы
bool isContinue = true;

Console.Clear();
//int index = Array.IndexOf(currencies, "ETH");
//Console.WriteLine(index);

Console.WriteLine("Доступные суммы:");
for (int i = 0; i < currencies.Length; i++) Console.WriteLine(currencies[i] + " " + wallet[i]);

while (isContinue)
{
    Console.Write(">");
    string userEntry = Console.ReadLine();
    userEntry = userEntry.ToLower();
    
    switch (userEntry)
    {   case "display":
            Console.Clear();
            Console.WriteLine("Доступные суммы:");
            for (int i = 0; i < currencies.Length; i++) Console.WriteLine(currencies[i] + " " + wallet[i]);
            break;
        case "equiv":
            double equivAmount = 0;
            Console.Write("Отображение суммарного баланса в одной из валют. Введите код валюты: ");
            string chosenCurrency = Console.ReadLine();
            chosenCurrency = chosenCurrency.ToUpper();
            int chosenCurrencyIndex = Array.IndexOf(currencies, chosenCurrency);
            if (chosenCurrencyIndex != -1)
            for (int i = 0; i < currencies.Length; i++)
            {
                equivAmount = equivAmount + wallet[i]*rates[i, chosenCurrencyIndex];
            }
            else Console.WriteLine("Такой валюты нет. Введите код валюты или exit для возврата в предыдущее меню.");
            Console.WriteLine($"Эквивалент = {currencies[chosenCurrencyIndex]} {equivAmount}");
            break;
        /* case "transfer":
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
