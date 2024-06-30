using GeoShapesCalculations;

namespace Tests.Shapes;

public class CircleTests
{
    [Theory]
    [InlineData(10, 314.159265358979323846)]
    [InlineData(20, 1256.6370614359172954)]
    public void Calculate_ValidSquare(double radius, double expectedResult)
    {
        // Given
        // When
        var circle = ShapesFactory.CreateCircle(radius);

        // Then
        var result = circle.GetSquare();
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void ValidationFailsWithWrongParameters(double radius)
    {
        // Given
        // When
        Action action = () => ShapesFactory.CreateCircle(radius);

        // Then
        ArgumentException exception = Assert.Throws<ArgumentException>(action);

        Assert.Equal("Radius must be greater than 0", exception.Message);
    }
}