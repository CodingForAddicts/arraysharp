namespace GaulishMall;

public class Matrix
{
    public static int CountItems(int[,] shops, int price)
    {
        int occ = 0;
        for (int i = 0; i < shops.GetLength(0); ++i)
        {
            for (int j = 0; j < shops.GetLength(1); ++j)
                if (shops[i, j] == price)
                    occ++;
        }

        return occ;
    }
    private static void CustomSort(int[,] array)
    {
        int rows = array.GetLength(0);
        
        for (int i = 0; i < rows - 1; i++)
        {
            for (int j = 0; j < rows - i - 1; j++)
            {
                if (array[j, 0] > array[j + 1, 0])
                {
                    SwapRows(array, j, j + 1);
                }
                
                else if (array[j, 0] == array[j + 1, 0] && array[j, 1] > array[j + 1, 1])
                {
                    SwapRows(array, j, j + 1);
                }
            }
        }
    }

    private static void SwapRows(int[,] array, int row1, int row2)
    {
        (array[row1, 0], array[row2, 0]) = (array[row2, 0], array[row1, 0]);
        (array[row1, 1], array[row2, 1]) = (array[row2, 1], array[row1, 1]);
    }

    public static int[,] FindItems(int[,] shops, int price)
    {
        int[,] findprice;
        bool foundonce = false;
        findprice = new int[CountItems(shops, price), 2];
        int place = 0;
       
        
        for (int i = 0; i < shops.GetLength(0); i++)
        {
            for (int j = 0; j < shops.GetLength(1); j++)
                if (shops[i, j] == price)
                {
                    findprice[place, 0] = i;
                    findprice[place, 1] = j;
                    place++;
                    foundonce = true;
                }
        }
        CustomSort(findprice);
        if (foundonce) return findprice;
        return new int[0, 0];
    }

    public static int[,] RotateShops(int[,] shops)
    {
        int length = shops.GetLength(0);
        int width = shops.GetLength(1);

        int[,] rotated;
        rotated = new int[width, length];
        for (int i = 0; i < shops.GetLength(0); i++)
        {
            for (int j = 0; j < shops.GetLength(1); j++)
                rotated[j, i] = shops[i, j];
        }

        return rotated;
    }

    public static int CountJagged(int[][] shops, int price)
    {
        int occ = 0;
        for (int i = 0; i < shops.Length; ++i)
        {
            for (int j = 0; j < shops[i].Length; ++j)
                if (shops[i][j] <= 0)
                    throw new ArgumentException();
                else if (shops[i][j] == price)
                    occ++;
        }

        return occ;
    }

    public static string[][] Trim(string[][] arr, string[] forbidden)
    {
        string[][] banned;
        string[] temp;
        int curlen;
        int place;
        bool isBanned;
        banned = new string[arr.GetLength(0)][];
        
        for (int i = 0; i < arr.Length; i++)
        {
            curlen = arr[i].Length;
            place = 0;
            for (int j = 0; j < arr[i].Length; j++)
            {
                foreach (string ban in forbidden)
                {
                    if (ban == arr[i][j])
                        curlen--;
                }
            }
            temp = new string[curlen];
            for (int j = 0; j < arr[i].Length; j++)
            {
                isBanned = false;
                foreach (string ban in forbidden)
                {
                    if (ban == arr[i][j])
                        isBanned = true;
                }
                if (!isBanned)
                {
                    temp[place] = arr[i][j];
                    place++;
                }
            }
            banned[i] = temp;
        }
        return banned;
    }

    public static int SecondLargest(int[][] shops)
    {
        int max = 0;
        int secondmax = 0;
        bool secondmodif = false;
        for (int i = 0; i < shops.Length; ++i)
        {
            if (i == 0 && shops[i].Length < 2) throw new ArgumentException();
            for (int j = 0; j < shops[i].Length; ++j)
                if (j == 0 && i == 0) max = shops[i][j];
                else if (shops[i][j] >= max)
                {
                    if (shops[i][j] > max)
                    {
                        secondmax = max;
                        secondmodif = true;
                    }
                    max = shops[i][j];
                    
                } else if (shops[i][j] > secondmax)
                {
                    secondmax = shops[i][j];
                    secondmodif = true;
                }
        }
        if (!secondmodif) throw new ArgumentException();
        return secondmax;
    }

    public static int[][] Pascal(uint n)
    {
        int[][] pasc = new int[n +1][];
        
        for (int i = 0; i <= n; i++)
        {
            pasc[i] = new int[i+ 1];
            
            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i) pasc[i][j] = 1;
                else pasc[i][j] = pasc[i- 1][j]+ pasc[i-1][j -1];
            }
        }
        return pasc;
    }

}