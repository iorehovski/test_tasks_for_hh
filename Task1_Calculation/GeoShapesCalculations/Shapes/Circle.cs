namespace GeoShapesCalculations.Shapes;

public record Circle : IShape
{
    private double Radius { get; set; }

    public Circle(double radius)
    {
        if (radius <= 0) 
            throw new ArgumentException("Radius must be greater than 0");

        Radius = radius;
    }

    public double GetSquare()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}