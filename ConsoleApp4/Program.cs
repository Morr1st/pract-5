using System;

class program
{
    static void Main()
    {
        Console.WriteLine("Выберите задание 1-5");
        int choose = Convert.ToInt32(Console.ReadLine());
        switch (choose)
        {
            case 1:
                List<IAnimal> animals = new List<IAnimal>();
                animals.Add(new Dog());
                animals.Add(new Cat());
                animals.Add(new Cow());
                animals.Add(new Owl());
                animals.Add(new Monkey());

                foreach (var animal in animals)
                {
                    Console.Write($"{animal} издаёт звук: ");
                    animal.Voice();

                }
                break;
            case 2:
                List<IHelloAll> listHello = new List<IHelloAll>();
                listHello.Add(new English());
                listHello.Add(new Russian());
                listHello.Add(new Germany());

                foreach (var item in listHello)
                {
                    item.SayHello();
                    Console.WriteLine($", будет на {item} языке");
                }
                break;
            case 3:
                DigitFilter filter = new DigitFilter();
                LetterFilter letterFilter = new LetterFilter();
                string message;
                Console.Write("Введите строку: ");
                message = Console.ReadLine().ToLower();
                Console.WriteLine($"\nВаша строка без букв: {filter.Execute(message)}\n");
                Console.WriteLine($"Ваша строка без цифр: {letterFilter.Execute(message)}");
                break;
            case 4:
                char symbol;
                Console.Write("Введите символ: ");
                symbol = Convert.ToChar(Console.ReadLine());

                Vertical vertical = new Vertical(symbol);
                HorizontalLine line = new HorizontalLine(symbol);
                Sqare sqare = new Sqare(symbol);

                int size;
                Console.Write("Укажите длину линии: ");
                size = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Ваша вертикальная линия из {symbol}.\n");
                vertical.Draw(size);
                Console.WriteLine($"\nВаша горизонтальная линия из {symbol}.\n");
                line.Draw(size);
                Console.WriteLine($"\n\nКвадрат из {symbol}.\n\n");
                sqare.Draw(size);
                break;
            case 5:
                Spell alohomora = new Spell(100, "Замок открывается");
                Spell vinigardiumLeviosa = new Spell(50, "Предмет поднимается в воздух");

                Magican GarryPotter = new Magican(100, "Гарри Поттер");


                GarryPotter.castSpell(alohomora);
                GarryPotter.castSpell(vinigardiumLeviosa);
                break;
        }
    }
}

// Задание 1
interface IAnimal
{
    void Voice();

}
class Dog : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Гав");
    }
}
class Cat : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Мяу");
    }
}
class Owl : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Ух! Ух!");
    }
}
class Cow : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("Му");
    }
}
class Monkey : IAnimal
{
    public void Voice()
    {
        Console.WriteLine("yadysdyasdyasdasy");
    }
}

//задание 2
interface IHelloAll
{
    void SayHello();
}
class English : IHelloAll
{
    public void SayHello()
    {
        Console.Write("Hello everybody!");
    }
}
class Russian : IHelloAll
{
    public void SayHello()
    {
        Console.Write("Привет всем!");
    }
}
class Germany : IHelloAll
{
    public void SayHello()
    {
        Console.Write("Hallo an alle!");
    }
}
//задание 3
interface IFilter
{
    string Execute(string textLine);
}

class DigitFilter : IFilter
{
    char[] numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public string Execute(string textLine)
    {
        string result = "";
        for (int i = 0; i < textLine.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (textLine[i] == numbers[j])
                {
                    result += numbers[j];
                }
            }
        }
        return result;
    }
}
class LetterFilter : IFilter
{
    char[] alphabet =
    { 'а', 'б', 'в', 'г',
      'д', 'е', 'ё', 'ж',
      'з', 'и', 'й', 'к',
      'л', 'м', 'н', 'о',
      'п', 'р', 'с', 'т',
      'у', 'ф', 'х', 'ц',
      'ч', 'ш', 'щ', 'ь',
      'ы', 'ъ', 'э', 'ю', 'я'};
    public string Execute(string textLine)
    {
        string result = "";
        for (int i = 0; i < textLine.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (textLine[i] == alphabet[j])
                {
                    result += alphabet[j];
                }
            }
        }
        return result;
    }
}
//Задание 4

interface IShare
{
    void Draw(int size);
}

class Vertical : IShare
{
    private char symbol;
    public Vertical(char symbol)
    {
        this.symbol = symbol;
    }

    public void Draw(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine(symbol);
        }
    }
}
class HorizontalLine : IShare
{
    private char symbol;
    public HorizontalLine(char symbol)
    {
        this.symbol = symbol;
    }

    public void Draw(int size)
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(symbol);
        }
    }
}
class Sqare : IShare
{
    private char symbol;
    public Sqare(char symbol)
    {
        this.symbol = symbol;
    }

    public void Draw(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(symbol);
            }
            Console.Write("\n");
        }
    }
}
//Задание 5
interface spell
{
    void castSpell(Spell spell);
}

class Spell
{
    public string Effect { get; private set; }
    public int Mana { get; private set; }
    public Spell(int mana, string effect)
    {
        Mana = mana;
        Effect = effect;
    }
    public string Use()
    {
        return Effect;
    }
}

class Magican : spell
{
    public int Mana { get; private set; }
    public string Name { get; private set; }
    public Magican(int mana, string name)
    {
        Mana = mana;
        Name = name;
    }
    public void castSpell(Spell spell)
    {
        if (Mana >= spell.Mana)
        {
            Console.WriteLine($"{Name} использует способность: '{spell.Use()}'");
            Mana -= spell.Mana;
            Console.WriteLine($"У {Name} осталось {Mana} маны\n");
        }
        else
        {
            Console.WriteLine($"Не хватает {spell.Mana - Mana} для использования заклинания: '{spell.Use()}'");
            Console.WriteLine($"{Name} советую выпить зелье восстановления маны!");
        }
    }
}