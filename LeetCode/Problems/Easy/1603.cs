namespace LeetCode.Problems.Easy;

/// <summary>
///     1603. Design Parking System
///     https://leetcode.com/problems/design-parking-system/
/// </summary>
public class _1603
{
    private readonly ParkingSystem system = new(1, 1, 0);

    [BenchmarkGen]
    public void ParkingSystem() => system.AddCar(2);
}

public class ParkingSystem(int big, int medium, int small)
{
    private int big = big, medium = medium, small = small;

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
