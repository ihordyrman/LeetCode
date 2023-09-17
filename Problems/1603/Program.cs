using Xunit;

namespace _1603;

internal static class Program
{
    private static void Main()
    {
        var parkingSystem = new ParkingSystem(1, 1, 0);
        Assert.True(parkingSystem.AddCar(1));
        Assert.True(parkingSystem.AddCar(2));
        Assert.False(parkingSystem.AddCar(3));
        Assert.False(parkingSystem.AddCar(1));
    }
}

public class ParkingSystem
{
    private int _big, _medium, _small;

    public ParkingSystem(int big, int medium, int small)
    {
        _big = big;
        _small = small;
        _medium = medium;
    }

    public bool AddCar(int carType)
    {
        switch (carType)
        {
            case 1:
                if (_big == 0)
                {
                    return false;
                }

                _big--;
                return true;
            case 2:
                if (_medium == 0)
                {
                    return false;
                }

                _medium--;
                return true;
            default:
                if (_small == 0)
                {
                    return false;
                }

                _small--;
                return true;
        }
    }
}
