namespace LeetCode.Problems.Medium;

/// <summary>
///     2545. Sort the Students by Their Kth Score
///     https://leetcode.com/problems/sort-the-students-by-their-kth-score
/// </summary>
public class _2545
{
    private static readonly (int[][] score, int k) Input = ([[10, 6, 9, 1], [7, 5, 11, 2], [4, 8, 3, 15]], 2);

    public static void Execute() => SortTheStudents(Input.score, Input.k).Display();

    private static int[][] SortTheStudents(int[][] score, int k)
    {
        for (var i = 0; i < score.Length; i++)
        {
            int max = i;
            for (int j = i; j < score.Length; j++)
            {
                if (score[j][k] > score[max][k])
                    max = j;
            }

            var buffer = score[i];
            score[i] = score[max];
            score[max] = buffer;
        }

        return score;
    }
}