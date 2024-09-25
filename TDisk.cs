using System.Data;

namespace lab1_v9_block2;
/* Клас “круг” – TDisk
 * Поля: для зберігання радіуса;  для зберігання центра кола
 * Методи:
 *  конструктор без параметрів, конструктор з параметрами, конструктор копіювання;
    override public string ToString();
    введення/виведення даних;
    визначення площі круга;
    перевірка належності точки кругу;
    перевантаження операторів * (множення радіуса на число, при збереженні координат
   центра; забезпечити, щоб домноження могло відбуватися хоч як «число*круг», хоч як
   «круг*число»).
   
   2. Створити клас-нащадок TBall (куля) на основі класу TDisk. Додати поле третьої
   координати центра, метод знаходження об’єму кулі та перевизначити відповідні методи.
 */ 
public class TDisk
{
    private double _radius;
    private double _x, _y;

    public TDisk()
    {
        _radius = 2;
        _x = 0;
        _y = 0;
    }

    public TDisk(double radius, double x, double y)
    {
        if (radius < 0)
        {
            throw new ArgumentException("Radius must be > 0");
        }
        _radius = radius;
        _x = x;
        _y = y;
    }

    public TDisk(TDisk previousDisk)
    {
        _radius = previousDisk._radius;
        _x = previousDisk._x;
        _y = previousDisk._y;
    }

    public override string ToString()
    {
        return $"Радіус: {_radius}. " +
               $"Координати центра: X: {_x} Y: {_y}";
    }

    public double Radius
    {
        get { return _radius;}
        set
        {
            if (value > 0)
                _radius = value;
            throw new ArgumentException("Radius must be > 0");
        }
        
    }
    public double X { 
        get { return _x; }
        set { _x = value; } 
    }
    public double Y { 
        get { return _y; }
        set { _y = value; } 
    }
    
    public string Area()
    {
        double area = Math.Pow(_radius, 2);
        return area.ToString() + "Pi";
    }

    public bool IsExistPointInCircle(double x, double y)
    {
        if (Math.Pow(x - _x, 2) + (y - _y) <= Math.Pow(_radius, 2))
            return true;
        return false;
    }

    public static TDisk operator *(TDisk circle, double k)
    {
        var temp = new TDisk(Math.Abs(circle._radius) * k, circle._x * k, circle._y * k );
        return temp;
    }
    
    public static TDisk operator *(double k, TDisk circle)
    {
        var temp = new TDisk(Math.Abs(circle._radius) * k, circle._x * k, circle._y * k );
        return temp;
    }
    
    public static TDisk ReadFromConsole()
    {
        Console.WriteLine("Введіть радіус кола та координати центра: ");
        double r = double.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());

        return new TDisk(r, x, y);
    }
    
}
