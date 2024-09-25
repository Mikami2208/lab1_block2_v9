using System.Threading.Channels;
using lab1_v9_block2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1. Створити коло. ");
        Console.WriteLine("2. Створити кулю. ");
        Console.Write("Виберіть 1 або 2: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                var disk = DiskFromUserInput();
                FindAreaAndPoint(disk);
                MultiplyUserDisk(disk);
                break;
            case 2:
                var ball = BallFromUserInput();
                FindBallAreaVolumeAndPoint(ball);
                MultiplyUserBall(ball);
                break;
            
        }
    }

    static TDisk DiskFromUserInput()
    {
        var disk = TDisk.ReadFromConsole();
        Console.WriteLine(disk.ToString());
        return disk;

    }

    static void FindAreaAndPoint(TDisk disk)
    {
        Console.WriteLine(disk.Area());
        Console.WriteLine("Введіть точку для перевірки, чи належить вона колу: ");
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        if (disk.IsExistPointInCircle(x, y))
            Console.WriteLine($"Точка [{x}, {y}] належить колу!");
        else
            Console.WriteLine($"Точка [{x}, {y}] не належить колу!");
    }

    static void MultiplyUserDisk(TDisk disk)
    { 
        Console.Write("Хочете домножити число на радиус, " +
                   "координати кола та знайти його площу та перевірити належність точки? (Так/ні): ");
        string diskMultiplyChoice = Console.ReadLine();
        
        if (diskMultiplyChoice.ToLower() == "так")
        {
            Console.Write("Введіть число, на яке хочете домножити: ");
            int index = int.Parse(Console.ReadLine());
            var newDisk = disk * index;
            Console.WriteLine( newDisk.ToString());
            FindAreaAndPoint(newDisk);
        }
        else
        {
            return;
        }
    }
    
    static TBall BallFromUserInput()
    {
        var ball = TBall.ReadFromConsole();
        Console.WriteLine(ball.ToString());
        return ball;
    }
    
    static void FindBallAreaVolumeAndPoint(TBall ball)
    {
        Console.WriteLine("Площа кулі: " + ball.Area());   
        Console.WriteLine("Обʼєм кулі: " + ball.Volume());
        Console.WriteLine("Введіть координати x, y, z для перевірки, чи належить вона колу: ");
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double z = double.Parse(Console.ReadLine());
        if (ball.IsExistPointInBall(x, y, z))
            Console.WriteLine($"Точка [{x}, {y}, {z}] належить кулі!");
        else
            Console.WriteLine($"Точка [{x}, {y}, {z}] не належить кулі!");
    }

    static void MultiplyUserBall(TBall ball)
    {
        Console.Write("Хочете домножити число на радиус, " +
                      "координати кулі та знайти її площу та перевірити належність точки? (Так/ні): ");
        string ballMultiplyChoice = Console.ReadLine();
        if (ballMultiplyChoice.ToLower() == "так")
        {
            Console.Write("Введіть число, на яке хочете домножити: ");
            int index = int.Parse(Console.ReadLine());
            var newBall = index * ball;
            ball.ToString();
            FindBallAreaVolumeAndPoint(newBall);
        }
        else
        {
            return;
        }
    }
}