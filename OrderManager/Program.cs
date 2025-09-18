using OrderManager;

try
{
    Run();
}
catch ( Exception ex )
{
    Console.WriteLine( $"Ошибка: {ex.Message}" );
}

string ReadString( string promt )
{
    while ( true )
    {
        Console.Write( promt );
        string str = Console.ReadLine();
        if ( !String.IsNullOrEmpty( str ) )
        {
            return str;
        }
        Console.WriteLine( "Некорректное значение. Повторите ввод." );
    }
}

int AskCount()
{
    Console.Write( "Введите количество товара: " );
    while ( true )
    {
        if ( int.TryParse( Console.ReadLine(), out int result ) && result > 0 )
        {
            return result;
        }
        Console.WriteLine( "Некорректное колличество. Повторите ввод." );
    }
}

bool ConfirmOrder( string name, int count, string product, string address )
{
    Console.WriteLine( $"Здравствуйте, {name}, вы заказали {count} {product} на адрес {address}, все верно? (yes/no)" );
    string response = Console.ReadLine();
    return response == "yes";
}

void ShowOrder( string name, string product, int count, string address, DateTime data )
{
    Console.WriteLine( $"{name}! Ваш заказ {product} в количестве {count} оформлен! Ожидайте доставку по адресу {address} к {data}" );
}

bool IsValidOrder( string name, string product, string address )
{
    if ( String.IsNullOrEmpty( name ) || String.IsNullOrEmpty( product ) || String.IsNullOrEmpty( address ) )
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
    string product = ReadString( "Введите нзавние товара: " );
    int count = AskCount();
    string name = ReadString( "Введите имя получателя: " );
    string address = ReadString( "Введите адрес доставки: " );
    DateTime dateTime = DateTime.Today.AddDays( 3 );
    if ( !IsValidOrder( name, product, address ) )
    {
        Console.WriteLine( "Ваш заказ некорректен." );
        return;
    }
    if ( ConfirmOrder( name, count, product, address ) )
    {
        ShowOrder( name, product, count, address, dateTime );
    }
    else
    {
        Console.WriteLine( "Заказ отменён." );
    }
}

void HandleOperation( Operation? operation )
{
    switch ( operation )
    {
        case Operation.Order:
            ProcessOrder();
            break;
        case Operation.Exit:
            Console.WriteLine( "Программа завершена." );
            break;
        default:
            throw new Exception( "Неизвестная команда." );
    }
}
Operation? GetOperation()
{
    string operationStr = Console.ReadLine();
    bool isParse = Enum.TryParse( operationStr, out Operation operation );
    return isParse ? operation : null;
}
void Run()
{
    Operation? operation = null;
    while ( operation != Operation.Exit )
    {
        ShowOptions();
        operation = GetOperation();
        HandleOperation( operation );
    }
}


