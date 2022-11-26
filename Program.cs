bool isContinue = true;
string? fromCurrency;
double fromCurrAmt;
string? toCurrency;
double rubEquiv;

Dictionary<string, double> myWallet = new Dictionary<string, double>();
myWallet.Add("RUB", 50000);
myWallet.Add("USD", 100);
myWallet.Add("EUR", 500);
myWallet.Add("BTC", 0.002);
myWallet.Add("GBP", 300);
myWallet.Add("JPY", 3000);
myWallet.Add("BYR", 100);
myWallet.Add("CNY", 1000);

Dictionary<string, double> myRates = new Dictionary<string, double>();
myRates.Add("RUB", 1);
myRates.Add("USD", 60.4797);
myRates.Add("EUR", 62.8762);
myRates.Add("BTC", 1002406.54);
myRates.Add("GBP", 73.4345);
myRates.Add("JPY", 0.734345);
myRates.Add("BYR", 25.0320);
myRates.Add("CNY", 8.42448);

Console.Clear();

Console.WriteLine("Доступные суммы:");
foreach (KeyValuePair<string, double> kvp in myWallet)
{
    Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
}

while (isContinue)
{
    Console.Write(">");
    string userEntry = Console.ReadLine();
    userEntry = userEntry.ToLower();
    
    switch (userEntry)
    {   
        case "display":
            Console.Clear();
            Console.WriteLine("Доступные суммы:");
            foreach (KeyValuePair<string, double> kvp in myWallet)
            {
                Console.WriteLine("{0} -> {1}", kvp.Key, kvp.Value);
            }
            break;
        case "equiv":
            double equivAmount = 0;
            
            Console.WriteLine("Отображение суммарного баланса в одной из валют.");
            
            while(true)
            {
                Console.Write("Введите код валюты: ");
                string? chosenCurrency = Console.ReadLine();
                chosenCurrency = chosenCurrency.ToUpper();
                if (myWallet.ContainsKey(chosenCurrency))
                {
                    foreach (KeyValuePair<string, double> kvp in myWallet)
                    {
                        equivAmount += myWallet[kvp.Key] * myRates[kvp.Key];
// контроль                        Console.WriteLine(kvp.Key + " " + kvp.Value + " * " + myRates[kvp.Key] + " = " + equivAmount);
                    } 
// контроль                    Console.WriteLine("Cумма в рублях: " + equivAmount);
                    equivAmount = Math.Round(equivAmount / myRates[chosenCurrency],4);
                    Console.WriteLine($"Эквивалент кошелька в {chosenCurrency} {equivAmount}");
                    break;
                }
                else Console.WriteLine("Такой валюты нет.");
            }
            break;
        case "transfer":
            Console.WriteLine("Перевод сумм из одной валюты в другую.");
            while (true)
            {
                Console.Write("Введите исходную валюту: ");
                fromCurrency = Console.ReadLine();
                fromCurrency = fromCurrency.ToUpper();
                if (myWallet.ContainsKey(fromCurrency)) break;
                else Console.WriteLine("Такой валюты нет.");
            }
            while (true)
            {
                Console.Write("Введите сумму для перечисления: ");
                fromCurrAmt = Convert.ToDouble(Console.ReadLine());
                if (fromCurrAmt <= myWallet[fromCurrency]) break;
                else Console.WriteLine($"Введённая сумма больше имеющегося остатка ({fromCurrency} {myWallet[fromCurrency]})");
            }
            while (true)
            {
                Console.Write("Введите целевую валюту: ");
                toCurrency = Console.ReadLine();
                toCurrency = toCurrency.ToUpper();
                if (myWallet.ContainsKey(toCurrency)) break;
                else Console.WriteLine("Такой валюты нет.");
            }
            rubEquiv = fromCurrAmt * myRates[fromCurrency];
            myWallet[toCurrency] += rubEquiv / myRates[toCurrency];
            myWallet[fromCurrency] -= fromCurrAmt;
            Console.WriteLine("Остаток после операции:");
            Console.WriteLine(fromCurrency + " -> " + myWallet[fromCurrency]);
            Console.WriteLine(toCurrency + " -> " + myWallet[toCurrency]);
            break;

        case "convert":
            Console.WriteLine("Справочный пересчёт из одной валюты в другую.");
            double toCurrAmt;
            while (true)
            {
                Console.Write("Введите исходную валюту: ");
                fromCurrency = Console.ReadLine();
                fromCurrency = fromCurrency.ToUpper();
                if (myWallet.ContainsKey(fromCurrency)) break;
                else Console.WriteLine("Я не знаю такую валюту :(");
            }
            Console.Write("Введите сумму для конвертации: ");
            fromCurrAmt = Convert.ToDouble(Console.ReadLine());
            
            while (true)
            {
                Console.Write("Введите целевую валюту: ");
                toCurrency = Console.ReadLine();
                toCurrency = toCurrency.ToUpper();
                if (myWallet.ContainsKey(toCurrency)) break;
                else Console.WriteLine("Я не знаю такую валюту :(");
            }
            
            rubEquiv = fromCurrAmt * myRates[fromCurrency];
            toCurrAmt = Math.Round(rubEquiv / myRates[toCurrency], 2);

            Console.WriteLine($"Примерный эквивалент {fromCurrency} {fromCurrAmt} = {toCurrency} {toCurrAmt}");
            break;

       case "help":
            Console.WriteLine("Display     – Вывести остатки по валютам");
            Console.WriteLine("Equiv       – Отобразить эквивалент кошелька в одной из валют");
            Console.WriteLine("Transfer    – Перевести указанную сумму с одного счёта на другой)");
            Console.WriteLine("Convert     – Справочный пересчёт суммы из одной валюты в другую)");
            Console.WriteLine("ВНИМАНИЕ! Операции Equiv / Transfer / Convert проводятся через валюту RUB!");
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
