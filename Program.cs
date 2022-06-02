namespace MaxSubmatrixSum;

public class Program
{
    public static void Main()
    {
        var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var rows = input[0];
        var cols = input[1];
        var matrix = new int[rows, cols];

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            var inputElement = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = inputElement[col];
            }
        }

        var submatrixRow = int.Parse(Console.ReadLine());
        var submatrixCol = int.Parse(Console.ReadLine());

        var maxSum = int.MinValue;
        var startRowIndex = 0;
        var startColIndex = 0;
        if (submatrixRow <= matrix.GetLength(0) && submatrixCol <= matrix.GetLength(1))
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var tempMaxSum = 0;
                    if (row + submatrixRow <= matrix.GetLength(0) && col + submatrixCol <= matrix.GetLength(1))
                    {
                        for (int i = row; i < row + submatrixRow; i++)
                        {
                            for (int j = col; j < col + submatrixCol; j++)
                            {
                                tempMaxSum += matrix[i, j];
                            }
                        }
                    }

                    if (tempMaxSum > maxSum)
                    {
                        maxSum = tempMaxSum;
                        startRowIndex = row;
                        startColIndex = col;
                    }
                }
            }
        }

        Print(matrix, submatrixRow, submatrixCol, startRowIndex, startColIndex, maxSum);
    }

    private static void Print(int[,] matrix, int submatrixRow, int submatrixCol, int startRowIndex, int startColIndex, int maxSum)
    {
        for (int row = 0; row < submatrixRow; row++)
        {
            for (int col = 0; col < submatrixCol; col++)
            {
                Console.Write(matrix[startRowIndex + row, startColIndex + col] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine(maxSum);
    }
}