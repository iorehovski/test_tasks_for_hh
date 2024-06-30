using GeoShapesCalculations.Shapes;

namespace GeoShapesCalculations;

public static class ShapesFactory
{
    public static Circle CreateCircle(double radius)
    {
        return new Circle(radius);
    }

    public static Triangle CreateTriangle(double side1, double side2, double side3)
    {
        return new Triangle(side1, side2, side3);
    }
}