namespace lab1_v9_block2;

public class TBall : TDisk
{
    private double _z;

    public TBall(double radius, double x, double y, double z) : base(radius, x, y)
    {
        _z = z;
    }

    public override string ToString()
    {
        return base.ToString() + $" Z: {_z}";
    }
    
    public string Volume()
    {
        double volume = (4.0 / 3.0) * Math.Pow(Radius, 3);
        return Convert.ToString(volume) + "Pi";
    }

    public double Z
    {
        get { return _z; }
        set { _z = value; }
    }

    public new string Area()
    {
        double area = 4 * Math.Pow(Radius, 2);
        return area.ToString() + "Pi";
    }
    
    public bool IsExistPointInBall(double x, double y, double z)
    {
        return Math.Pow(x - X, 2) + Math.Pow(y - Y, 2) + Math.Pow(z - _z, 2) <= Math.Pow(Radius, 2);
    }

    public static TBall operator *(TBall ball, double k)
    {
        var temp = new TBall(Math.Abs(ball.Radius * k), ball.X * k, ball.Y * k, ball._z * k);
        return temp;
    }
    
    public static TBall operator *(double k, TBall ball)
    {
        var temp = new TBall(Math.Abs(ball.Radius) * k, ball.X * k, ball.Y * k, ball._z * k);
        return temp;

    }
    public static new TBall ReadFromConsole()
    {
        Console.WriteLine("Введіть радіус кулі, координати центра та додатково координату Z: ");
        double r = double.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double z = double.Parse(Console.ReadLine());

        return new TBall(r, x, y, z);
    }
    
    
}