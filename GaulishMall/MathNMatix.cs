namespace GaulishMall;

public class MathNMatix
{
    public static string Compress(string uncompressed)
    {
        if (string.IsNullOrEmpty(uncompressed)) return "";

        bool uncomplete = true;
        char currentChar = '\0';
        int occChar;
        string compressed = "";
        int currIndex = 0;

        while (uncomplete)
        {
            occChar = 0;
            for (int j = currIndex; j < uncompressed.Length; j++)
            {
                
                if (j == currIndex) currentChar = uncompressed[j];
                
                if (uncompressed[j] == currentChar && occChar < 9) occChar++;
                
                else { currIndex = j; break; }
                
                if (j == uncompressed.Length - 1) currIndex = j + 1;
            }
            
            compressed += occChar.ToString() + currentChar;
            
            if (currIndex >= uncompressed.Length) uncomplete = false;
        }

        return compressed;
    }

    public static string Uncompress(string compressed)
    {
        if (string.IsNullOrEmpty(compressed))
            return "";
        string uncompressed = "";
        for (int i = 0; i < compressed.Length; i++)
        {
            if (48 <= compressed[i] && compressed[i] <= 57)
            {
                if (i == compressed.Length - 1) throw new ArgumentException();
                for (int j = 0; j < compressed[i] - 48; j++)
                {
                    uncompressed += compressed[i + 1];
                }

                i++;
            }
            else throw new ArgumentException();
        }

        return uncompressed;

    }

    public static int[,] MatrixMult(int[,] mat1, int[,] mat2)
    {
        if (mat1.GetLength(1) != mat2.GetLength(0)) throw new ArgumentException();

        int rows = mat1.GetLength(0);
        int cols = mat2.GetLength(1);
        int common = mat1.GetLength(1);

        int[,] product = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                for (int k = 0; k < common; k++)
                {
                    product[i, j] += mat1[i, k] * mat2[k, j];
                }
            }
        }

        return product;
    }
}