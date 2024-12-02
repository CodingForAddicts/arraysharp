using GaulishMall;

namespace Tests;

public class UnitTest1
{
    
    [Theory]
    [InlineData("ShopA", "ShopB", "ShopC", "ShopD", new [] { "ShopA", "ShopB", "ShopC", "ShopD" })]
    [InlineData("Bakery", "Grocery", "Pharmacy", "Clothing", new [] { "Bakery", "Grocery", "Pharmacy", "Clothing" })]
    [InlineData("", "", "", "", new [] { "", "", "", "" })] // Cas où toutes les chaînes sont vides
    [InlineData("Shop1", null, "Shop3", "Shop4", new [] { "Shop1", null, "Shop3", "Shop4" })] // Cas avec des valeurs nulles
    public void CreateShops_ReturnsExpectedArray(string shop1, string shop2, string shop3, string shop4, string[] expected)
    {
        var result = Shop.CreateShops(shop1, shop2, shop3, shop4);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(
        new [] { "ShopA", "ShopB", "ShopC", "ShopD" }, // shop1 initial
        new [] { "ShopW", "ShopX", "ShopY", "ShopZ" }, // shop2 initial
        2, 4,                                               // indices à échanger
        new [] { "ShopA", "ShopZ", "ShopC", "ShopX" }, // shop1 attendu
        new [] { "ShopW", "ShopD", "ShopY", "ShopB" }  // shop2 attendu
    )]
    [InlineData(
        new [] { "A1", "A2", "A3", "A4" }, 
        new [] { "B1", "B2", "B3", "B4" }, 
        3, 1, 
        new [] { "B3", "A2", "B1", "A4" }, 
        new [] { "A3", "B2", "A1", "B4" }
    )]
    [InlineData(
        new [] { "A1", "A2", "A3", "A4" }, 
        new [] { "B1", "B2", "B3", "B4" }, 
        1, 1, 
        new [] { "B1", "A2", "A3", "A4" }, 
        new [] { "A1", "B2", "B3", "B4" }
    )]
    public void SwapShops_SwapsElementsCorrectly(
        string[] shop1,
        string[] shop2,
        int i,
        int j,
        string[] expectedShop1,
        string[] expectedShop2)
    {
        Shop.SwapShops(shop1, shop2, i, j);
        
        Assert.Equal(expectedShop1, shop1); // Vérifie que shop1 est modifié correctement
        Assert.Equal(expectedShop2, shop2); // Vérifie que shop2 est modifié correctement
    }

    [Theory]
    [InlineData(0, 2)]  // Indice négatif
    [InlineData(3, 0)]   // Indice hors limites
    [InlineData(0, 4)] 
    [InlineData(-1, 3)]// Indice hors limites
    public void SwapShops_ThrowsArgumentException_WhenIndicesAreInvalid(int i, int j)
    {
        var shop1 = new [] { "ShopA", "ShopB", "ShopC", "ShopD" };
        var shop2 = new [] { "ShopW", "ShopX", "ShopY", "ShopZ" };
        
        Assert.Throws<ArgumentException>(() => Shop.SwapShops(shop1, shop2, i, j));
    }
    
    [Theory]
    [InlineData(new [] { 'a', 'b', 'c', 'd' }, new [] { 'd', 'c', 'b', 'a' })]
    [InlineData(new [] { 'x', 'y', 'z' }, new [] { 'z', 'y', 'x' })]
    [InlineData(new [] { 'a' }, new [] { 'a' })] // Un seul élément
    [InlineData(new char[] { }, new char[] { })]         // Tableau vide
    public void Reverse_CorrectlyReversesArray(char[] input, char[] expected)
    {
        Shop.Reverse(input);
        
        Assert.Equal(expected, input); // Vérifie que le tableau est inversé correctement
    }
    
    [Theory]
    [InlineData("Caesar", new [] { "Caesar", "Mark", "Caesar", "Antony" }, new [] { 0, 2 })] // Caesar est trouvé aux indices 0 et 2
    [InlineData("Mark", new [] { "Caesar", "Mark", "Caesar", "Mark" }, new [] { 1, 3 })]    // Mark est trouvé aux indices 1 et 3
    [InlineData("Antony", new [] { "Caesar", "Mark", "Caesar", "Antony" }, new [] { 3 })]   // Antony est trouvé à l'indice 3
    [InlineData("Cleopatra", new [] { "Caesar", "Mark", "Caesar", "Antony" }, new int[] { })]  // Cleopatra n'est pas trouvé
    [InlineData("", new [] { "Caesar", "", "Mark", "" }, new [] { 1, 3 })]                 // Cas avec chaînes vides
    [InlineData("Caesar", new string[] { }, new int[] { })]                                         // Tableau vide
    public void WhereIsCaesar_FindsOccurrencesCorrectly(string owner, string[] register, int[] expected)
    {
        var result = Shop.WhereIsCaesar(owner, register);
        
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(new [] { 5, 3, 8, 6, 2 }, new [] { 2, 3, 5, 6, 8 })] // Cas standard
    [InlineData(new [] { 1, 2, 3, 4, 5 }, new [] { 1, 2, 3, 4, 5 })] // Déjà trié
    [InlineData(new [] { 5, 4, 3, 2, 1 }, new [] { 1, 2, 3, 4, 5 })] // Complètement inversé
    [InlineData(new [] { 10 }, new [] { 10 })]                      // Tableau avec un seul élément
    [InlineData(new int[] { }, new int[] { })]                            // Tableau vide
    public void BubbleSort_SortsCorrectly(int[] input, int[] expected)
    {
        Shop.BubbleSort(input);
        
        Assert.Equal(expected, input); 
    }
    
    [Theory]
    [InlineData(new [] { 1, 2, 3, 4, 5 }, 10, new [] { 1, 4, 5 })]
    [InlineData(new [] { 5, 15, 20 }, 5, new [] { 5 })]
    [InlineData(new [] { 10, 15, 20 }, 42, new int[] {15,20 })]
    [InlineData(new int[] { }, 10, new int[] { })]
    public void Selection_ValidInputs_ReturnsExpected(int[] array, int budget, int[] expected)
    {
        var result = Selection(array, budget);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new [] { 1, 2, -3 }, 10)]
    [InlineData(new [] { 0, 2, 3 }, 10)]
    [InlineData(new [] { 0, 2, 3 }, -10)]
    public void Selection_NegativeOrZeroPrices_ThrowsArgumentException(int[] array, int budget)
    {
        Assert.Throws<ArgumentException>(() => Selection(array, budget));
    }

    [Theory]
    [InlineData(new [] { 1, 2, 3 }, 0)]
    [InlineData(new [] { 1, 2, 3 }, -1)]
    public void Selection_BudgetNonPositive_ThrowsArgumentException(int[] array, int budget)
    {
        Assert.Throws<ArgumentException>(() => Selection(array, budget));
    }
    
    private static int[] Selection(int[] array, int budget)
    {
        return Shop.Selection(array, budget); 
    }
    
    [Theory]
    [InlineData(new int[] { }, 5, 0)] 
    
    [InlineData(new [] { 3 }, 2, 0)]
    [InlineData(new [] { 3 }, 3, 0)]
    [InlineData(new [] { 3 }, 4, 1)]
    
    [InlineData(new [] { 1, 3, 5, 7 }, 0, 0)] 
    [InlineData(new [] { 1, 3, 5, 7 }, 2, 1)] 
    [InlineData(new [] { 1, 3, 5, 7 }, 4, 2)]
    [InlineData(new [] { 1, 3, 5, 7 }, 6, 3)]
    [InlineData(new [] { 1, 3, 5, 7 }, 8, 4)]
    [InlineData(new [] { 1, 3, 5, 7 }, 5, 2)] 
    
    [InlineData(new [] { -10, -5, 0, 5, 10 }, -15, 0)]
    [InlineData(new [] { -10, -5, 0, 5, 10 }, -7, 1)]
    [InlineData(new [] { -10, -5, 0, 5, 10 }, 7, 4)]
    [InlineData(new [] { -10, -5, 0, 5, 10 }, 15, 5)]
    
    [InlineData(new [] { 1, 3, 3, 3, 5 }, 3, 2)]
    [InlineData(new [] { 1, 3, 3, 3, 5 }, 4, 4)] 
    [InlineData(new [] { 1, 3, 3, 3, 5 }, 6, 5)] 
    public void TestBinarix(int[] array, int x, int expected)
    {
        int result = Shop.Binarix(array, x);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestBinarix_HandlesLargeInputs()
    {
        int largeValue = int.MaxValue - 1;
        int[] array = new int[] { largeValue };
        int x = int.MaxValue;
        
        int result = Shop.Binarix(array, x);
        
        Assert.Equal(1, result); 
    }
    
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 3, 5, 1)] // 3x3 matrix, one occurrence of 5
    [InlineData(new int[] { 10, 20, 30, 10, 20, 30 }, 2, 3, 10, 2)]   // 2x3 matrix, two occurrences of 10
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1 }, 2, 3, 1, 6)]          // 2x3 matrix, six occurrences of 1
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0 }, 2, 3, 0, 6)]          // 2x3 matrix, six occurrences of 0
    [InlineData(new int[] { 0, 0, 1, 0, 0, 2 }, 2, 3, 3, 0)]          // 2x3 matrix, no occurrences of 3
    [InlineData(new int[] { }, 0, 0, 1, 0)]                           // Empty matrix
    public void CountItems_ReturnsExpectedOccurrence(
        int[] flatShops, int rows, int cols, int price, int expected)
    {
        int[,] shops = To2DArray(flatShops, rows, cols);
        
        int result = Matrix.CountItems(shops, price);
        
        Assert.Equal(expected, result);
    }

    private static int[,] To2DArray(int[] flatArray, int rows, int cols)
    {
        int[,] result = new int[rows, cols];
        for (int i = 0; i < flatArray.Length; i++)
        {
            int row = i / cols;
            int col = i % cols;
            result[row, col] = flatArray[i];
        }
        return result;
    }
    
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 7, 8, 9 }, 3, 3, 5, new int[] { 1, 1, 1, 2 })] // 2 occurrences de 5 aux indices (1,1) et (1,2)
    [InlineData(new int[] { 10, 20, 30, 10, 20, 30 }, 2, 3, 10, new int[] { 0, 0, 1, 0 })]  // 2 occurrences de 10 aux indices (0,0) et (1,0)
    [InlineData(new int[] { 1, 1, 1, 1, 1, 1 }, 2, 3, 1, new int[] { 0, 0, 0, 1, 0, 2, 1, 0, 1, 1, 1, 2 })] // Toutes les positions
    [InlineData(new int[] { 0, 0, 0, 0, 0, 0 }, 2, 3, 3, new int[] { })]                      // Pas d'occurrence
    [InlineData(new int[] { }, 88, 7, 1, new int[] { })]                                      // Matrice vide
    public void FindItems_ReturnsCorrectCoordinates(
        int[] flatShops, int rows, int cols, int price, int[] expectedFlatResult)
    {
        int[,] shops = To2DArray(flatShops, rows, cols);
        int[,] expected = To2DArray(expectedFlatResult, expectedFlatResult.Length / 2, 2);
        int[,] result = Matrix.FindItems(shops, price);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 2, 3, new int[] { 1, 4, 2, 5, 3, 6 }, 3, 2)] // Matrice 2x3 devient 3x2
    [InlineData(new int[] { 1, 2, 3, 4 }, 2, 2, new int[] { 1, 3, 2, 4 }, 2, 2)]             // Matrice carrée 2x2
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 3, 3, new int[] { 1, 4, 7, 2, 5, 8, 3, 6, 9 }, 3, 3)] // Matrice carrée 3x3
    [InlineData(new int[] { }, 0, 0, new int[] { }, 0, 0)]                                   // Matrice vide
    public void RotateShops_ReturnsTransposedMatrix(
        int[] flatShops, int rows, int cols, int[] expectedFlatResult, int expectedRows, int expectedCols)
    {
        int[,] shops = To2DArray(flatShops, rows, cols);
        int[,] expected = To2DArray(expectedFlatResult, expectedRows, expectedCols);
        int[,] result = Matrix.RotateShops(shops);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [MemberData(nameof(GetValidData))]
    public void CountJagged_ReturnsCorrectOccurrences(int[][] shops, int price, int expected)
    {
        int result = Matrix.CountJagged(shops, price);
        
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(GetInvalidData))]
    public void CountJagged_ThrowsArgumentException_WhenInvalidData(int[][] shops, int price)
    {
        Assert.Throws<ArgumentException>(() => Matrix.CountJagged(shops, price));
    }

    public static IEnumerable<object[]> GetValidData()
    {
        yield return new object[] { new [] { new [] { 1, 2, 3 }, new [] { 4, 5, 6 }, new [] { 7, 8, 9 } }, 5, 1 };
        yield return new object[] { new [] { new [] { 10, 20 }, new [] { 10 }, new [] { 30 } }, 10, 2 };
        yield return new object[] { new [] { new [] { 1, 1, 1 }, new [] { 1, 1 } }, 1, 5 };
        yield return new object[] { new int[][] { }, 1, 0 };
    }

    public static IEnumerable<object[]> GetInvalidData()
    {
        yield return new object[] { new [] { new [] { -1, 2 }, new [] { 3, 4 } }, 2 };
        yield return new object[] { new [] { new [] { 1, 2 }, new [] { 3, 4 } }, 0 };
    }
    
    [Theory]
    [MemberData(nameof(GetTrimData))]
    public void Trim_RemovesForbiddenElements(string[][] input, string[] forbidden, string[][] expected)
    {
        string[][] result = Matrix.Trim(input, forbidden);
        
        Assert.Equal(expected, result);
    }

    public static IEnumerable<object[]> GetTrimData()
    {
        yield return new object[]
        {
            new string[][] 
            { 
                new string[] { "apple", "banana", "cherry" }, 
                new string[] { "date", "fig", "grape" } 
            },
            new string[] { "banana", "fig" },
            new string[][] 
            { 
                new string[] { "apple", "cherry" }, 
                new string[] { "date", "grape" } 
            }
        };
        yield return new object[]
        {
            new string[][] 
            { 
                new string[] { "cat", "dog", "mouse" }, 
                new string[] { "elephant", "frog" } 
            },
            new string[] { "dog", "mouse", "elephant" },
            new string[][] 
            { 
                new string[] { "cat" }, 
                new string[] { "frog" } 
            }
        };
        yield return new object[]
        {
            new string[][] 
            { 
                new string[] { "one", "two", "three" }, 
                new string[] { "four", "five" } 
            },
            new string[] { },
            new string[][] 
            { 
                new string[] { "one", "two", "three" }, 
                new string[] { "four", "five" } 
            } // Aucun élément interdit
        };
        yield return new object[]
        {
            new string[][] { },
            new string[] { "anything" },
            new string[][] { } // Tableau jagged vide
        };
        yield return new object[]
        {
            new string[][] 
            { 
                new string[] { "alpha", "beta", "gamma" }, 
                new string[] { "delta", "epsilon", "zeta" } 
            },
            new string[] { "omega" },
            new string[][] 
            { 
                new string[] { "alpha", "beta", "gamma" }, 
                new string[] { "delta", "epsilon", "zeta" } 
            } // Aucun élément interdit présent
        };
    }
    
    [Fact]
    public void Pascal_ReturnsCorrectTriangle_WhenNIsZero()
    {
        uint n = 0;
        int[][] expected = new int[][]
        {
            new int[] { 1 }
        };
        int[][] result = Matrix.Pascal(n);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Pascal_ReturnsCorrectTriangle_WhenNIsOne()
    {
        uint n = 1;
        int[][] expected = new int[][]
        {
            new int[] { 1 },
            new int[] { 1, 1 }
        };
        int[][] result = Matrix.Pascal(n);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Pascal_ReturnsCorrectTriangle_WhenNIsTwo()
    {
        uint n = 2;
        int[][] expected = new int[][]
        {
            new int[] { 1 },
            new int[] { 1, 1 },
            new int[] { 1, 2, 1 }
        };
        int[][] result = Matrix.Pascal(n);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Pascal_ReturnsCorrectTriangle_WhenNIsThree()
    {
        uint n = 3;
        int[][] expected = new int[][]
        {
            new int[] { 1 },
            new int[] { 1, 1 },
            new int[] { 1, 2, 1 },
            new int[] { 1, 3, 3, 1 }
        };
        int[][] result = Matrix.Pascal(n);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Pascal_ReturnsCorrectTriangle_WhenNIsFour()
    {
        uint n = 4;
        int[][] expected = new int[][]
        {
            new int[] { 1 },
            new int[] { 1, 1 },
            new int[] { 1, 2, 1 },
            new int[] { 1, 3, 3, 1 },
            new int[] { 1, 4, 6, 4, 1 }
        };
        int[][] result = Matrix.Pascal(n);
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Pascal_ReturnsCorrectTriangle_ForLargeNumbers()
    {
        
        uint n = 20; 
        int[][] result = Matrix.Pascal(n);
        
        Assert.NotNull(result);
        
        int[] expectedRow = new int[] { 1, 20, 190, 1140, 4845, 15504, 38760, 77520, 125970, 167960, 184756, 167960, 125970, 77520, 38760, 15504, 4845, 1140, 190, 20, 1 };
        Assert.Equal(expectedRow, result[20]);
    }

    [Fact]
    public void Pascal_ReturnsCorrectTriangle_ForEdgeCase()
    {
        uint n = 10;
        int[][] result = Matrix.Pascal(n);
        
        Assert.NotNull(result);
        Assert.Equal(11, result.Length);
        
        int[] expectedRow = new int[] { 1, 10, 45, 120, 210, 252, 210, 120, 45, 10, 1 };
        Assert.Equal(expectedRow, result[10]);
    }
    
    [Fact]
    public void SecondLargest_ReturnsCorrectValue_ForValidInput()
    {
        // Arrange
        int[][] shops = new int[][]
        {
            new int[] { 1, 1 },
            new int[] { 1,3 },
            new int[] { 1, 1 },
            new int[] { 1,1,1 },
            new int[] { 1, 1, 1 },
        };

        // Act
        int result = Matrix.SecondLargest(shops);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void SecondLargest_ThrowsArgumentException_WhenArrayIsEmpty()
    {
        // Arrange
        int[][] shops = new int[][] { };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Matrix.SecondLargest(shops));
    }

    [Fact]
    public void SecondLargest_ThrowsArgumentException_WhenNoSecondLargestExists()
    {
        // Arrange
        int[][] shops = new int[][]
        {
            new int[] { 1, 1, 1 }
        };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => Matrix.SecondLargest(shops));
    }

    [Fact]
    public void SecondLargest_ReturnsCorrectValue_WhenNegativeNumbersArePresent()
    {
        // Arrange
        int[][] shops = new int[][]
        {
            new int[] { -3, -5, -7 },
            new int[] { -2, -8 },
            new int[] { -9, -1 }
        };

        // Act
        int result = Matrix.SecondLargest(shops);

        // Assert
        Assert.Equal(-2, result);
    }
    
    [Theory]
    [InlineData("", "")] // Chaîne vide
    [InlineData("H", "1H")] // Un seul caractère
    [InlineData("Hello!", "1H1e2l1o1!")] // Exemple de la spécification
    [InlineData("aaabbbccc", "3a3b3c")] // Plusieurs groupes de caractères
    [InlineData("aaaaaaaaaaa", "9a2a")] // Plus de 9 occurrences d'un même caractère
    [InlineData("xx", "2x")] // Deux occurrences
    [InlineData("abababab", "1a1b1a1b1a1b1a1b")] // Alternance de caractères
    [InlineData("    ", "4 ")] // Espaces consécutifs
    [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïð", "1A1B1C1D1E1F1G1H1I1J1K1L1M1N1O1P1Q1R1S1T1U1V1W1X1Y1Z1a1b1c1d1e1f1g1h1i1j1k1l1m1n1o1p1q1r1s1t1u1v1w1x1y1z1À1Á1Â1Ã1Ä1Å1Æ1Ç1È1É1Ê1Ë1Ì1Í1Î1Ï1Ð1Ñ1Ò1Ó1Ô1Õ1Ö1Ø1Ù1Ú1Û1Ü1Ý1Þ1ß1à1á1â1ã1ä1å1æ1ç1è1é1ê1ë1ì1í1î1ï1ð"
    )] // Espaces consécutifs
    public void Compress_ReturnsCorrectString(string input, string expected)
    {
        // Act
        string result = MathNMatix.Compress(input);

        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("", "")] // Chaîne vide
    [InlineData("1H1e2l1o1!", "Hello!")] // Cas standard
    [InlineData("9a2a", "aaaaaaaaaaa")] // Plusieurs occurrences
    [InlineData("1A1B1C", "ABC")] // Simples caractères
    [InlineData("1@","@")] // Caractère spécial
    [InlineData("1A1B1C1D1E1F1G1H1I1J1K1L1M1N1O1P1Q1R1S1T1U1V1W1X1Y1Z1a1b1c1d1e1f1g1h1i1j1k1l1m1n1o1p1q1r1s1t1u1v1w1x1y1z1À1Á1Â1Ã1Ä1Å1Æ1Ç1È1É1Ê1Ë1Ì1Í1Î1Ï1Ð1Ñ1Ò1Ó1Ô1Õ1Ö1Ø1Ù1Ú1Û1Ü1Ý1Þ1ß1à1á1â1ã1ä1å1æ1ç1è1é1ê1ë1ì1í1î1ï1ð","ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïð")] // Ordre incorrect
    public void Uncompress_ValidCompressedString_ReturnsCorrectResult(string compressed, string expected)
    {
        string result = MathNMatix.Uncompress(compressed);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1H1e2l1")] // Pas de caractère après le dernier chiffre
    [InlineData("10a")] // Nombre invalide (dépasse 9)
    [InlineData("H")] // Aucun nombre avant un caractère
    public void Uncompress_InvalidCompressedString_ThrowsArgumentException(string compressed)
    {
        Assert.Throws<ArgumentException>(() => MathNMatix.Uncompress(compressed));
    }
    
    [Fact]
    public void MatrixMult_ValidMatrices_ReturnsCorrectProduct()
    {
        int[,] mat1 = { { 1, 2, 3 }, { 4, 5, 6 } }; // 2x3
        int[,] mat2 = { { 7, 8 }, { 9, 10 }, { 11, 12 } }; // 3x2

        int[,] expected = { { 58, 64 }, { 139, 154 } }; // 2x2
        int[,] result = MathNMatix.MatrixMult(mat1, mat2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void MatrixMult_IncompatibleDimensions_ThrowsArgumentException()
    {
        int[,] mat1 = { { 1, 2 } }; // 1x2
        int[,] mat2 = { { 1, 2 }, { 3, 4 }, { 5, 6 } }; // 3x2

        Assert.Throws<ArgumentException>(() => MathNMatix.MatrixMult(mat1, mat2));
    }

    [Fact]
    public void MatrixMult_EmptyMatrices_ReturnsEmptyMatrix()
    {
        int[,] mat1 = new int[0, 0];
        int[,] mat2 = new int[0, 0];

        int[,] result = MathNMatix.MatrixMult(mat1, mat2);
        Assert.Empty(result);
    }

    public class StartingBoxCoordTests
    {
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 3, 0)]
        [InlineData(2, 6, 0)]
        [InlineData(3, 0, 3)]
        [InlineData(4, 3, 3)]
        [InlineData(5, 6, 3)]
        [InlineData(6, 0, 6)]
        [InlineData(7, 3, 6)]
        [InlineData(8, 6, 6)]
        public void StartingBoxCoord_ValidBox_ReturnsCorrectCoordinates(int box, int expectedX, int expectedY)
        {
           // var (startx, starty) = Sudokus.StartingBoxCoord(box);
           // Assert.Equal(expectedX, startx);
            //Assert.Equal(expectedY, starty);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(9)]
        public void StartingBoxCoord_InvalidBox_ThrowsArgumentException(int box)
        {
           // Assert.Throws<ArgumentException>(() => Sudokus.StartingBoxCoord(box));
        }
    }
}

public class InBoxTests
{
    [Fact]
    public void InBox_FoundDigit_ReturnsTrue()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.True(Sudokus.InBox(grid, 0, 9)); // La boîte 0 contient le chiffre 9
        Assert.True(Sudokus.InBox(grid, 1, 7)); // La boîte 1 contient le chiffre 7
        Assert.True(Sudokus.InBox(grid, 8, 8)); // La boîte 1 contient le chiffre 8
    }

    [Fact]
    public void InBox_NotFoundDigit_ReturnsFalse()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.False(Sudokus.InBox(grid, 0, 1)); // La boîte 0 ne contient pas le chiffre 1
    }

    [Fact]
    public void InBox_InvalidBox_ThrowsArgumentException()
    {
        int[,] grid = new int[9, 9];

        Assert.Throws<ArgumentException>(() => Sudokus.InBox(grid, -1, 5));
        Assert.Throws<ArgumentException>(() => Sudokus.InBox(grid, 9, 5));
    }
}

public class InColTests
{
    [Fact]
    public void InCol_FoundDigit_ReturnsTrue()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.True(Sudokus.InCol(grid, 1, 3)); // La colonne 1 contient le chiffre 3
    }

    [Fact]
    public void InCol_NotFoundDigit_ReturnsFalse()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.False(Sudokus.InCol(grid, 1, 5)); // La colonne 1 ne contient pas le chiffre 5
    }

    [Fact]
    public void InCol_InvalidColumn_ThrowsIndexOutOfRangeException()
    {
        int[,] grid = new int[9, 9];

        Assert.Throws<IndexOutOfRangeException>(() => Sudokus.InCol(grid, -1, 5));
        Assert.Throws<IndexOutOfRangeException>(() => Sudokus.InCol(grid, 9, 5));
    }
}

public class InLineTests
{
    [Fact]
    public void InLine_FoundDigit_ReturnsTrue()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.True(Sudokus.InLine(grid, 1, 9)); // La ligne 1 contient le chiffre 9
    }

    [Fact]
    public void InLine_NotFoundDigit_ReturnsFalse()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.False(Sudokus.InLine(grid, 1, 8)); // La ligne 1 ne contient pas le chiffre 8
    }

    [Fact]
    public void InLine_InvalidLine_ThrowsIndexOutOfRangeException()
    {
        int[,] grid = new int[9, 9];

        Assert.Throws<IndexOutOfRangeException>(() => Sudokus.InLine(grid, -1, 5));
        Assert.Throws<IndexOutOfRangeException>(() => Sudokus.InLine(grid, 9, 5));
    }
}

public class SolveSudokuTests
{
    [Fact]
    public void SolveSudoku_ValidGrid_ReturnsTrue()
    {
        int[,] grid = 
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        Assert.True(Sudokus.Solver(grid));
    }

    [Fact]
    public void SolveSudoku_NoSolution_ReturnsFalse()
    {
        int[,] grid = 
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        Assert.False(Sudokus.Solver(grid));
    }
}
