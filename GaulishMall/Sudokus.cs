namespace GaulishMall;

public class Sudokus
{
    public static bool InLine(int[,] grid, int line, int digit)
    {
        for (int i = 0; i < grid.GetLength(1); i++)
        {
            if (grid[line, i] == digit) return true;
        }

        return false;

    }

    public static bool InCol(int[,] grid, int col, int digit)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            if (grid[i, col] == digit) return true;
        }

        return false;
    }

    private static (int startx, int starty) StartingBoxCoord(int box)
    {
        if (box < 0 || box > 8)
            throw new ArgumentException();

        int startx = (box % 3) * 3;
        int starty = (box / 3) * 3;

        return (startx, starty);
    }

    public static bool InBox(int[,] grid, int box, int digit)
    {
        (int startx, int starty) = StartingBoxCoord(box);

        for (int i = starty; i < starty+3; i++)
        {
            for (int j = startx; j < startx+3; j++)
            {
                if (grid[i, j] == digit) return true;
            }
        }

        return false;
    }
    public static bool IsValidGrid(int[,] grid)
{
    for (int row = 0; row < grid.GetLength(0); row++)
    {
        bool[] seen = new bool[10]; 
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            int digit = grid[row, col];
            if (digit != 0)
            {
                if (seen[digit]) return false;
                seen[digit] = true;
            }
        }
    }
    
    for (int col = 0; col < grid.GetLength(1); col++)
    {
        bool[] seen = new bool[10];
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            int digit = grid[row, col];
            if (digit != 0)
            {
                if (seen[digit]) return false;
                seen[digit] = true;
            }
        }
    }
    
    for (int box = 0; box < 9; box++)
    {
        bool[] seen = new bool[10];
        (int startX, int startY) = StartingBoxCoord(box);
        for (int row = startY; row < startY + 3; row++)
        {
            for (int col = startX; col < startX + 3; col++)
            {
                int digit = grid[row, col];
                if (digit != 0)
                {
                    if (seen[digit]) return false;
                    seen[digit] = true;
                }
            }
        }
    }

    return true; 
}

public static bool Solver(int[,] grid)
{
    if (!IsValidGrid(grid)) return false;

    for (int row = 0; row < grid.GetLength(0); row++)
    {
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            if (grid[row, col] == 0)
            {
                for (int digit = 1; digit <= 9; digit++)
                {
                    int box = (row / 3) * 3 + (col / 3);

                    if (!InLine(grid, row, digit) &&
                        !InCol(grid, col, digit) &&
                        !InBox(grid, box, digit))
                    {
                        grid[row, col] = digit;

                        if (Solver(grid))
                            return true;

                        grid[row, col] = 0;
                    }
                }

                return false;
            }
        }
    }

    return true;
}



}


