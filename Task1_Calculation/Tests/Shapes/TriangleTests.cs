using GeoShapesCalculations;

namespace Tests.Shapes;

public class TriangleTests
{
    [Theory]
    [InlineData(3,4,5,6)]
    [InlineData(2, 3, 4, 2.9047375096555627)]
    public void Calculate_ValidSquare(
        double side1, 
        double side2, 
        double side3, 
        double expectedResult)
    {
        // Given
        // When
        var circle = ShapesFactory.CreateTriangle(side1, side2, side3);

        // Then
        var result = circle.GetSquare();
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(0.6, 0.8, 1, true)]
    [InlineData(3, 4, 5, true)]
    [InlineData(5, 12, 13, true)]
    [InlineData(1, 1, 1, false)]
    public void IsRectangular(
        double side1,
        double side2,
        double side3,
        bool expectedResult)
    {
        // Given
        // When
        var circle = ShapesFactory.CreateTriangle(side1, side2, side3);

        // Then
        var result = circle.IsRectangular();
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 4, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(-10, -20, 0)]
    public void ValidationFailsWithWrongParameters(
        double side1,
        double side2,
        double side3)
    {
        // Given
        // When
        Action action = () => ShapesFactory.CreateTriangle(side1, side2, side3);

        // Then
        ArgumentException exception = Assert.Throws<ArgumentException>(action);

        Assert.Equal("Triangle with provided parameters doesn't exist", exception.Message);
    }
}