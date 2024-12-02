namespace GaulishMall;

public class Shop
{
    public static string[] CreateShops(string shop1, string shop2, string shop3, string shop4)
    {
        string[] shops = { shop1, shop2, shop3, shop4 };
        return shops;
    }

    public static void SwapShops(string[] shop1, string[] shop2, int i, int j)
    {
        
        if (i < 1 || i > 4 || j < 1 || j > 4)
        {
            throw new ArgumentException();
        }

        i--;
        j--;

        if (i == j) (shop1[i], shop2[j]) = (shop2[j], shop1[i]);
        else (shop1[i], shop1[j], shop2[i], shop2[j]) = (shop2[j], shop2[i], shop1[j], shop1[i]);
    }

    public static void Reverse(char[] name)
    {
        int start = 0;
        int end = name.Length - 1;
        while (start < end)
        {
            (name[start], name[end]) = (name[end], name[start]);
            start++;
            end--;
        }
    }

    public static int[] WhereIsCaesar(string owner, string[] register)
    {
        int occ = 0;
        int[] whereis;
        
        foreach (string c in register)
        {
            if (owner == c) occ += 1;
        }
        
        whereis = new int[occ];

        int place = 0;
        int count = 0;
        foreach (string c in register)
        {
            if (owner == c)
            {
                whereis[place] = count;
                place += 1;
            }
            count += 1;

        }
        return whereis;
    }

    public static void BubbleSort(int[] keys)
    {
        int len = keys.Length;
        bool swapped ;
        foreach (int _ in keys)
        {
            swapped = len == 1;
            
            while (!swapped)
            {
                swapped = false;
                for (int i = 1; i <= len-1; i++)
                {
                    if (keys[i - 1] > keys[i])
                    {
                        (keys[i - 1], keys[i]) = (keys[i], keys[i - 1]);
                    }
                    swapped = true;
                }
            }
        }
    }

    public static int[] Selection(int[] array, int budget)
    {
        if (budget <=0)
            throw new ArgumentException();
        BubbleSort(array);
        int spent = 0;
        int size = 0;
        int[] basket;
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] <= 0) throw new ArgumentException();
            if ((spent + array[i]) <= budget)
            {
                size++;
                spent += array[i];
            }
        }
        basket = new int[size];
        int place = 0;
        spent = 0;
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] <= 0) throw new ArgumentException();
            if ((spent + array[i]) <= budget)
            {
                basket[place] = array[i];
                place++;
                spent += array[i];
            }
        }
        BubbleSort(basket);
        return basket;
    }

    public static int Binarix(int[] array, int x)
    {
        int l = 0;
        int r = array.Length - 1;
        int m;
        while (l <= r)
        {
            m = ((l+r)/2);
            if ((l+r)/2 < 0 && (l+r)/2 != m) m -= 1;
            if (array[m] < x) l = m + 1;
            else if (array[m] > x)
            {
                r = m - 1;
            }
            else return m;
        }
        return l;
    }
}