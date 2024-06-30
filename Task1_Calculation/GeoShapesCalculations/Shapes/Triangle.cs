namespace GeoShapesCalculations.Shapes;

public record Triangle : IShape
{
    private double Side1 { get; set; }
    private double Side2 { get; set; }
    private double Side3 { get; set; }

    public Triangle(double side1, double side2, double side3)
    {
        if (side1 <=0 
            || side2 <= 0 
            || side3 <= 0 
            || (side1 + side2 <= side3) 
            || (side1 + side3 <= side2) 
            || (side2 + side3 <= side1))
            throw new ArgumentException("Triangle with provided parameters doesn't exist");

        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double GetSquare()
    {
        var halfPerimeter = (Side1 + Side2 + Side3) / 2;

        return Math.Sqrt(halfPerimeter
                         * (halfPerimeter - Side1)
                         * (halfPerimeter - Side2)
                         * (halfPerimeter - Side3));
    }

    public bool IsRectangular()
    {
        var items = new List<double> { Side1, Side2, Side3 };
        items.Sort();

        var (a, b, c) = (items[0], items[1], items[2]);

        return Math.Abs(Math.Pow(c, 2) - (Math.Pow(a, 2) + Math.Pow(b,2))) < 1e-9;
    }
}