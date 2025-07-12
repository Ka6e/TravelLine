Run();
string AskProduct()
{
    Console.Write( "Введите название товара: " );
    return Console.ReadLine();
}

int AskCount()
{
    Console.Write( "Введите колличество товара: " );
    while ( true )
    {
        if ( int.TryParse( Console.ReadLine(), out int result ) && result > 0 )
        {
            return result;
        }
        else
        {
            Console.WriteLine( "Это не число" );
        }
    }
}

string AskName()
{
    Console.Write( "Введите имя получателя: " );
    return Console.ReadLine();
}

string AskAdress()
{
    Console.Write( "Введите адресс доставки: " );
    return Console.ReadLine();
}

bool ConfirmOrder( string name, int count, string product, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (yes/no)" );
    string response = Console.ReadLine();
    return response == "yes" ? true : false;
}

void ShowOrder( string name, string product, int count, string address, DateTime data )
{
    Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {data}" );
}

bool IsValidOrder( string name, string product, string address )
{
    if ( name == string.Empty || product == string.Empty || address == string.Empty )
    {
        return false;
    }
    return true;
}
static void ShowOptions()
{
    Console.WriteLine( "1. Заказать товар" );
    Console.WriteLine( "2. Закрыть приложение" );
    Console.Write( "Выберите опцию: " );
}

void ProcessOrder()
{
    string product = AskProduct();
    int count = AskCount();
    string name = AskName();
    string address = AskAdress();
    DateTime dateTime = DateTime.Today.AddDays( 3 );
    if ( !IsValidOrder( name, product, address ) )
    {
        Console.WriteLine( "Ваш заказ некорректен." );
        return;
    }
    if ( !ConfirmOrder( name, count, product, address ) )
    {
        ShowOrder( name, product, count, address, dateTime );
    }
    else
    {
        Console.WriteLine( "Заказ отменён." );
    }
}
void Run()
{
    bool isRunning = true;
    string choice;
    while ( isRunning )
    {
        ShowOptions();
        choice = Console.ReadLine();
        switch ( choice )
        {
            case "1":
                ProcessOrder();
                break;
            case "2":
                isRunning = false;
                Console.WriteLine( "Программа завершена." );
                break;
            default:
                Console.WriteLine( "Неизвестная команда." );
                break;
        }
    }
}


