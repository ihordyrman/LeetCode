using Xunit;

namespace LeetCode.Problems.Easy;

/// <summary>
///     1603. Design Parking System
///     https://leetcode.com/problems/design-parking-system/
/// </summary>
public class _1603
{
    public _1603()
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
    private int big, medium, small;

    public ParkingSystem(int big, int medium, int small)
    {
        this.big = big;
        this.small = small;
        this.medium = medium;
    }

    public bool AddCar(int carType)
    {
        switch (carType)
        {
            case 1:
                if (big == 0)
                {
                    return false;
                }

                big--;
                return true;
            case 2:
                if (medium == 0)
                {
                    return false;
                }

                medium--;
                return true;
            default:
                if (small == 0)
                {
                    return false;
                }

                small--;
                return true;
        }
    }
}
