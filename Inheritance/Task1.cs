using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Money
{
    protected int Currency = 0;
    protected int Cents = 0;

    public Money(int currency, int cents)
    {
        Currency = currency;
        Cents = cents;

        if (Cents >= 100)
        {
            Currency += Cents / 100;
            Cents = Cents % 100;
        }

    }

    public override string ToString()
    {
        return $"Количество денег: {Currency}.{Cents:D2}";
    }

    public void SetValues(int currency, int cents)
    {
        Currency = currency;
        Cents = cents;

        if (Cents >= 100)
        {
            Currency += Cents / 100;
            Cents = Cents % 100;
        }

    }

    public void Decrease(int currency, int cents)
    {
        int sum = Currency * 100 + Cents;
        int decrease = currency * 100 + cents;

        if (sum >= decrease)
        {
            sum -= decrease;
            Currency = sum / 100;
            Cents = sum % 100;
        }
        else
        {
            Console.WriteLine("Сумма не может быть меньше 0");
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is Money money)
        {
            return Currency == money.Currency && Cents == money.Cents;
        }
        return false;
    }
}

class Product : Money
{
    private string Name;


    public Product(string name, int currency, int cents) : base(currency, cents)
    {
        Name = name;
    }

    public void Discount(int currency, int cents)
    {
        Console.WriteLine($"Продукт: {Name}, Цена: {currency}.{cents:D2}");
        Console.WriteLine($"{Currency}.{Cents:D2} - {currency}.{cents:D2}");
        Decrease(currency, cents);
    }

    public override string ToString()
    {
        return $"Продукт: {Name}, Общая цена: {Currency}.{Cents:D2}";
    }
}
