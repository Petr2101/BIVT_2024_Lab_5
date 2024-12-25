using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1

    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here

        if (n < 0 || k < 0 || k > n)
        {
            return 0;
        }
        answer = Factorial(n) / Factorial(k) / Factorial(n - k);

        // create and use Factorial(n);

        // end

        return answer;
    }


    public static double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static bool ValidateTriangle(double[] sides)
    {
        if (sides.Length != 3)
            return false;

        for (int i = 0; i < 3; i++)
            if (sides[i] <= 0)
                return false;

        if (sides[0] >= sides[1] + sides[2])
            return false;

        if (sides[1] >= sides[0] + sides[2])
            return false;

        if (sides[2] >= sides[1] + sides[0])
            return false;

        return true;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;
        // code here
        // create and use GeronArea(a, b, c);
        // first = 1, second = 2, equal = 0, error = -1

        if (!ValidateTriangle(first) || !ValidateTriangle(second))
            return -1;

        double area1 = GeronArea(first[0], first[1], first[2]),
            area2 = GeronArea(second[0], second[1], second[2]);

        if (area1 > area2)
            answer = 1;
        else if (area2 > area1)
            answer = 2;

        // end

        return answer;
    }

    public static double GetDistance(double v, double a, double t)
    {
        return v * t + a * t * t / 2;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;
        // code here
        // create and use GetDistance(v, a, t); t - hours
        // first = 1, second = 2, equal = 0

        double dist1 = GetDistance(v1, a1, time), dist2 = GetDistance(v2, a2, time);
        if (dist1 > dist2)
            answer = 1;
        else if (dist2 > dist1)
            answer = 2;

        // end

        return answer;
    }
    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;
        // code here

        // create and use GetDistance(v, a, t); t - hours
        int time = 1;

        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
        {
            time++;
        }

        // end

        return answer;
        return time;
    }
    #endregion

    #region Level 2

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMax(matrix);
        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMax(array);

        // end
        int ai = FindMaxIndex(A);
        int bi = FindMaxIndex(B);
        double[] arr;
        int imax;
        if (A.Length - ai > B.Length - bi)
        {
            arr = A;
            imax = ai;
        }
        else
        {
            arr = B;
            imax = bi;
        }
        double sr = 0, n = 0;
        for (int i = imax + 1; i < arr.Length; i++)
        {
            sr += arr[i];
            n += 1;
        }
        sr /= n;
        double max = arr[imax];
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == max) arr[i] = sr;
        }
    }
    int FindMaxIndex(double[] array)
    {
        int imax = 0;
        for (int i = 1; i < array.Length; i++)
            if (array[i] > array[imax])
                imax = i;
        return imax;
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        // create and use FindDiagonalMax(matrix);
        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        // use method FindDiagonalMax(matrix); from Task_2_3
        // use method FindDiagonalMaxIndex(matrix); from Task_2_3

        // end
        int ai = FindDiagonalMaxIndex(A);
        int bi = FindDiagonalMaxIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[ai, i], B[i, bi]) = (B[i, bi], A[ai, i]);
        }
    }
    int FindDiagonalMaxIndex(int[,] matrix)
    {
        int n = matrix.GetLength(0), imax = 0;
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > matrix[imax, imax]) imax = i;
        }
        return imax;
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindColumnMax(matrix, columnIndex);
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use DeleteElement(array, index);

        // end
        int ai = FindMax(A);
        int bi = FindMax(B);
        int[] a = DeleteElement(A, ai);
        int[] b = DeleteElement(B, bi);
        int[] ans = new int[a.Length + b.Length];
        int ind = 0;
        foreach (int x in a) ans[ind++] = x;
        foreach (int x in b) ans[ind++] = x;
        A = ans;
    }
    int FindMax(int[] array)
    {
        int imax = 0;
        for (int i = 0; i < array.Length; i++)
            if (array[i] > array[imax])
                imax = i;
        return imax;
    }
    int[] DeleteElement(int[] array, int index)
    {
        int[] ans = new int[array.Length - 1];
        for (int i = 0; i < index; i++) ans[i] = array[i];
        for (int i = index; i < ans.Length; i++) ans[i] = array[i + 1];
        return ans;
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);
        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
        int ai = FindMax(A) + 1;
        int bi = FindMax(B) + 1;
        SortArrayPart(A, ai);
        SortArrayPart(B, bi);
    }
    void SortArrayPart(int[] array, int startIndex)
    {
        for (int i = 0; i < array.Length - startIndex; i++)
        {
            for (int j = startIndex; j < array.Length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
            }
        }
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);
        // code here
        // create and use SumPositiveElementsInColumns(matrix);
        // end
        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
        int imaxX = 0, imaxY = 0;
        int iminX = 0, iminY = 1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j && matrix[i, j] > matrix[imaxX, imaxY])
                {
                    imaxX = i;
                    imaxY = j;
                }
                if (i < j && matrix[i, j] < matrix[iminX, iminY])
                {
                    iminX = i;
                    iminY = j;
                }
            }
        }
        int del1 = Math.Max(imaxY, iminY);
        int del2 = Math.Min(imaxY, iminY);
        RemoveColumn(ref matrix, del1);
        if (del1 != del2)
            RemoveColumn(ref matrix, del2);
    }
    void RemoveColumn(ref int[,] matrix, int columnIndex)
    {
        int[,] ans = new int[matrix.GetLength(0), matrix.GetLength(1) - 1];
        for (int j = 0; j < columnIndex; j++)
            for (int i = 0; i < matrix.GetLength(0); i++)
                ans[i, j] = matrix[i, j];
        for (int j = columnIndex; j < ans.GetLength(1); j++)
            for (int i = 0; i < matrix.GetLength(0); i++)
                ans[i, j] = matrix[i, j + 1];
        matrix = ans;
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMax(matrix); from Task_2_1
        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
        int aj = FindMaxColumnIndex(A);
        int bj = FindMaxColumnIndex(B);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            (A[i, aj], B[i, bj]) = (B[i, bj], A[i, aj]);
        }
    }
    int FindMaxColumnIndex(int[,] matrix)
    {
        int imax = 0, jmax = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > matrix[imax, jmax])
                {
                    imax = i;
                    jmax = j;
                }
            }
        }
        return jmax;
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        // create and use RemoveRow(matrix, rowIndex);

        // end
    }


    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            SortRow(matrix, i);
        }
    }
    void SortRow(int[,] matrix, int rowIndex)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
                if (matrix[rowIndex, j] > matrix[rowIndex, j + 1])
                    (matrix[rowIndex, j], matrix[rowIndex, j + 1]) = (matrix[rowIndex, j + 1], matrix[rowIndex, j]);
        }
    }


    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0; // 1 - increasing   0 - no sequence   -1 - decreasing
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
}

public void Task_2_16(int[] A, int[] B)
{
    // code here

    // create and use SortNegative(array);

    // end
    SortNegative(A);
    SortNegative(B);
}
void SortNegative(int[] array)
{
    int n = 0;
    for (int i = 0; i < array.Length; i++)
        if (array[i] < 0) n++;
    int[] temp = new int[n];
    int ind = 0;
    for (int i = 0; i < array.Length; i++)
        if (array[i] < 0) temp[ind++] = array[i];
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n - i - 1; j++)
            if (temp[j] < temp[j + 1])
                (temp[j], temp[j + 1]) = (temp[j + 1], temp[j]);
    ind = 0;
    for (int i = 0; i < array.Length; i++)
        if (array[i] < 0)
            array[i] = temp[ind++];
}

public void Task_2_17(int[,] A, int[,] B)
{
    // code here
    // create and use SortRowsByMaxElement(matrix);
    // end
}

public void Task_2_18(int[,] A, int[,] B)
{
    // code here

    // create and use SortDiagonal(matrix);

    // end
    SortDiagonal(A);
    SortDiagonal(B);
}
void SortDiagonal(int[,] matrix)
{
    int n = matrix.GetLength(0);
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (matrix[j, j] > matrix[j + 1, j + 1])
            {
                (matrix[j, j], matrix[j + 1, j + 1]) = (matrix[j + 1, j + 1], matrix[j, j]);
            }
        }
    }
}

public void Task_2_19(ref int[,] matrix)
{
    // code here
    // use RemoveRow(matrix, rowIndex); from 2_13
    // end
}
public void Task_2_20(ref int[,] A, ref int[,] B)
{
    // code here

    // use RemoveColumn(matrix, columnIndex); from 2_10

    // end
}
for (int j = 0; j < A.GetLength(1); j++)
{
    bool hasZero = false;
    for (int i = 0; i < A.GetLength(0); i++)
        if (A[i, j] == 0) { hasZero = true; break; }
    if (!hasZero)
    {
        RemoveColumn(ref A, j);
        j--;
    }
}
for (int j = 0; j < B.GetLength(1); j++)
{
    bool hasZero = false;
    for (int i = 0; i < B.GetLength(0); i++)
        if (B[i, j] == 0) { hasZero = true; break; }
    if (!hasZero)
    {
        RemoveColumn(ref B, j);
        j--;
    }
}
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
{
    answerA = null;
    answerB = null;
    // code here
    // create and use CreateArrayFromMins(matrix);
    // end
}

public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
{
    rows = null;
    cols = null;
    rows = new int[matrix.GetLength(0)];
    for (int i = 0; i < rows.Length; i++)
    {
        rows[i] = CountNegativeInRow(matrix, i);
    }
    cols = FindMaxNegativePerColumn(matrix);


    // code here

    // create and use GetNegativeCountPerRow(matrix);
    // create and use GetMaxNegativePerColumn(matrix);
    // create and use CountNegativeInRow(matrix, rowIndex);
    // create and use FindMaxNegativePerColumn(matrix);

    // end
}
int CountNegativeInRow(int[,] matrix, int rowIndex)
{
    int ans = 0;
    for (int j = 0; j < matrix.GetLength(1); j++) if (matrix[rowIndex, j] < 0) ans++;
    return ans;
}
int[] FindMaxNegativePerColumn(int[,] matrix)
{
    int[] ans = new int[matrix.GetLength(1)];
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        int max = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, j] > max && matrix[i, j] < 0) max = matrix[i, j];
        }
        ans[j] = max;
    }
    return ans;
}

public void Task_2_23(double[,] A, double[,] B)
{
    // code here
    // create and use MatrixValuesChange(matrix);
    // end
}

public void Task_2_24(int[,] A, int[,] B)
{
    // code here

    // use FindMax(matrix); from 2_1

    // end
    int row, col;
    FindMaxIndex(A, out row, out col);
    SwapColumnDiagonal(A, col);
    FindMaxIndex(B, out row, out col);
    SwapColumnDiagonal(B, col);
}
void FindMaxIndex(int[,] matrix, out int row, out int col)
{
    row = 0; col = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] > matrix[row, col])
            {
                row = i; col = j;
            }
        }
    }
}
void SwapColumnDiagonal(int[,] matrix, int columnIndex)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        (matrix[i, i], matrix[i, columnIndex]) = (matrix[i, columnIndex], matrix[i, i]);
    }
}

public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
{
    maxA = 0;
    maxB = 0;

    // code here

    // create and use FindMaxNegativeRow(int);
    // use GetNegativeCountPerRow(matrix); from 2_22
    // create and use FindRowWithMaxNegativeCount(matrix);
    // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

    // end
}

public void Task_2_26(int[,] A, int[,] B)
{
    // code here

    // use GetNegativeCountPerRow(matrix); from 2_22
    // create and use FindMaxIndex(array);

    // end
    int ai = FindRowWithMaxNegativeCount(A);
    int bi = FindRowWithMaxNegativeCount(B);
    for (int j = 0; j < A.GetLength(1); j++)
    {
        (A[ai, j], B[bi, j]) = (B[bi, j], A[ai, j]);
    }
}
int FindRowWithMaxNegativeCount(int[,] matrix)
{
    int imax = 0, maxNegCount = -1;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int negCount = CountNegativeInRow(matrix, i);
        if (negCount > maxNegCount)
        {
            maxNegCount = negCount;
            imax = i;
        }
    }
    return imax;
}

public void Task_2_27(int[,] A, int[,] B)
{
    // code here
    // create and use FindRowMaxIndex(matrix)

    // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
    // create and use ReplaceMaxElementOdd(matrix, row, column);
    // create and use ReplaceMaxElementEven(matrix, row, column);

    // end
}

public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
{
    answerFirst = FindSequence(first, 0, first.Length - 1);
    answerSecond = FindSequence(second, 0, second.Length - 1);
}
int FindSequence(int[] array, int A, int B)
{
    // code here

    // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing

    // end
    if (A >= B) return 0;
    bool inc = array[A] < array[A + 1];
    for (int i = A; i < B; i++)
    {
        if (inc && array[i] > array[i + 1]) return 0;
        if (!inc && array[i] < array[i + 1]) return 0;
    }
    return inc ? 1 : -1;
}

public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
{
    // code here

    // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a

    // end
    int n = 0;
    for (int i = 0; i < first.Length; i++)
    {
        for (int j = i + 1; j < first.Length; j++)
        {
            int seq = FindSequence(first, i, j);
            if (seq != 0) n++;
        }
    }
    answerFirst = new int[n, 2];
    n = 0;
    for (int i = 0; i < first.Length; i++)
    {
        for (int j = i + 1; j < first.Length; j++)
        {
            int seq = FindSequence(first, i, j);
            if (seq != 0)
            {
                answerFirst[n, 0] = i;
                answerFirst[n, 1] = j;
                n++;
            }
        }
    }

    n = 0;
    for (int i = 0; i < second.Length; i++)
    {
        for (int j = i + 1; j < second.Length; j++)
        {
            int seq = FindSequence(second, i, j);
            if (seq != 0) n++;
        }
    }
    answerSecond = new int[n, 2];
    n = 0;
    for (int i = 0; i < second.Length; i++)
    {
        for (int j = i + 1; j < second.Length; j++)
        {
            int seq = FindSequence(second, i, j);
            if (seq != 0)
            {
                answerSecond[n, 0] = i;
                answerSecond[n, 1] = j;
                n++;
            }
        }
    }
}

public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
{
    // code here

    // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b

    // end
    int s = 0, f = 0;
    for (int i = 0; i < first.Length; i++)
    {
        for (int j = i + 1; j < first.Length; j++)
        {
            int seq = FindSequence(first, i, j);
            if (seq != 0 && f - s < j - i)
            {
                s = i;
                f = j;
            }
        }
    }
    answerFirst = new int[] { s, f };

    s = 0; f = 0;
    for (int i = 0; i < second.Length; i++)
    {
        for (int j = i + 1; j < second.Length; j++)
        {
            int seq = FindSequence(second, i, j);
            if (seq != 0 && f - s < j - i)
            {
                s = i;
                f = j;
            }
        }
    }
    answerSecond = new int[] { s, f };
}
#endregion

#region Level 3
public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
{
    // code here

    // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
    // create and use public delegate SumFunction(x) and public delegate YFunction(x)
    // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
    // create and use 2 methods for both functions
    // create and use 2 methods for both functions calculating at specific x

    // end
}

public void Task_3_2(int[,] matrix)
{
    // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me
    SortRowStyle sortStyle = default(SortRowStyle);


    // code here
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sortStyle = (i % 2 == 0) ? SortAscending : SortDescending;
        sortStyle(matrix, i);
    }
}

// create and use public delegate SortRowStyle(matrix, rowIndex);
// create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
// change method in variable sortStyle in the loop here and use it for row sorting
// create and use public delegate SortRowStyle(matrix, rowIndex);
public delegate void SortRowStyle(int[,] matrix, int rowIndex);
// create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
public static void SortAscending(int[,] m, int ind)
{
    for (int i = 0; i < m.GetLength(1); i++)
    {
        for (int j = 0; j < m.GetLength(1) - 1 - i; j++)
        {
            if (m[ind, j] > m[ind, j + 1])
            {
                int temp = m[ind, j];
                m[ind, j] = m[ind, j + 1];
                m[ind, j + 1] = temp;
            }
        }
    }
}

// end
public static void SortDescending(int[,] m, int ind)
{
    for (int i = 0; i < m.GetLength(1); i++)
    {
        for (int j = 0; j < m.GetLength(1) - 1 - i; j++)
        {
            if (m[ind, j] < m[ind, j + 1])
            {
                int temp = m[ind, j];
                m[ind, j] = m[ind, j + 1];
                m[ind, j + 1] = temp;
            }
        }
    }
}
// change method in variable sortStyle in the loop here and use it for row sorting

// end



public double Task_3_3(double[] array)
{
    double answer = 0;
    // SwapDirection swapper = default(SwapDirection); - uncomment me
    // code here

    // create and use public delegate SwapDirection(array);
    // create and use methods SwapRight(array) and SwapLeft(array) and GetSum(array)
    // change method in variable swapper in the loop here and use it for array swapping
    // create and use methods SwapRight(array) and SwapLeft(array)
    // create and use method GetSum(array, start, h) that sum elements with a negative indexes
    // change method in variable swapper in the if/else and than use swapper(matrix)

    // end

    return answer;
}
public int Task_3_4(int[,] matrix, bool isUpperTriangle)
{
    int answer = 0;
    GetTriangle getTriangle;
    if (isUpperTriangle)
        getTriangle = GetUpperTriange;
    else
        getTriangle = GetLowerTriange;
    answer = GetSum(getTriangle, matrix);
    return answer;
}
// code here

// code here

// create and use public delegate GetTriangle(matrix);
// create and use methods GetUpperTriange(array) and GetLowerTriange(array)
// and GetSum(GetTriangle, matrix)
// create and use method GetSum(array) similar to GetSum in Task_3_3
// create and use public delegate GetTriangle(matrix);
public delegate int[] GetTriangle(int[,] matrix);
// create and use methods GetUpperTriange(array) and GetLowerTriange(array)
public int[] GetUpperTriange(int[,] matrix)
{
    int ii = matrix.GetLength(0);
    int[] vector = new int[ii * (ii + 1) / 2];
    int k = 0;
    for (int i = 0; i < ii; i++)
    {
        for (int j = i; j < ii; j++)
        {
            vector[k] = matrix[i, j];
            k++;
        }
    }
    return vector;
}
public int[] GetLowerTriange(int[,] matrix)
{
    int ii = matrix.GetLength(0);
    int[] vector = new int[ii * (ii + 1) / 2];
    int k = 0;
    for (int i = 0; i < ii; i++)
    {
        for (int j = 0; j <= i; j++)
        {
            vector[k] = matrix[i, j];
            k++;
        }
    }
    return vector;
}
// create and use GetSum(GetTriangle, matrix)
public int GetSum(GetTriangle Triangle, int[,] matrix)
{
    int[] vector = Triangle(matrix);
    int s = 0;
    foreach (int i in vector)
        s += i * i;
    return s;
}
// end

// end

return answer;
    }

    public void Task_3_5(out int func1, out int func2)
{
    func1 = 0;
    func2 = 0;
    // code here
    // use public delegate YFunction(x, a, b, h) from Task_3_1
    // create and use method CountSignFlips(YFunction, a, b, h);
    // create and use 2 methods for both functions
    // end
}
public void Task_3_6(int[,] matrix)
{
    // code here

    FindElementDelegate Diagonal = FindDiagonalMaxIndex;
    FindElementDelegate FirstRow = FindFirstRowMaxIndex;
    SwapColumns(matrix, Diagonal, FirstRow);
    // create and use public delegate FindElementDelegate(matrix);
    // use method FindDiagonalMaxIndex(matrix) from Task_2_3;
    // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
    // create and use method FindFirstRowMaxIndex(matrix);
    // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

    // end
}
public delegate int FindElementDelegate(int[,] matrix);

public int FindDiagonalMaxIndex(int[,] matrix)
{
    int indexmax = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, i] > matrix[indexmax, indexmax])
            indexmax = i;
    }
    return indexmax;
}

public int FindFirstRowMaxIndex(int[,] matrix)
{
    int indexmax = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[0, i] > matrix[0, indexmax])
            indexmax = i;
    }
    return indexmax;
}
public void SwapColumns(int[,] matrix, FindElementDelegate Diagonal, FindElementDelegate FirstRow)
{
    int i1 = Diagonal(matrix);
    int i2 = FirstRow(matrix);
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int temp = matrix[i, i1];
        matrix[i, i1] = matrix[i, i2];
        matrix[i, i2] = temp;
    }
}


public void Task_3_7(ref int[,] B, int[,] C)
{
    // code here
    // create and use public delegate CountPositive(matrix, index);
    // use CountRowPositive(matrix, rowIndex) from Task_2_7
    // use CountColumnPositive(matrix, colIndex) from Task_2_7
    // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

    // end
}

public void Task_3_10(ref int[,] matrix)
{
    // FindIndex searchArea = default(FindIndex); - uncomment me

    FindIndex maxBelow = FindMaxBelowDiagonalIndex;
    FindIndex minAbove = FindMinAboveDiagonalIndex;
    matrix = RemoveColumns(matrix, maxBelow, minAbove);
    // code here



    // create and use public delegate FindIndex(matrix);
    // create and use method FindMaxBelowDiagonalIndex(matrix);
    // create and use method FindMinAboveDiagonalIndex(matrix);
    // use RemoveColumn(matrix, columnIndex) from Task_2_10
    // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)
    // end
}

public delegate int FindIndex(int[,] matrix);

public int FindMaxBelowDiagonalIndex(int[,] matrix)
{
    int index = 0;
    int m = -1000;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j <= i; j++)
        {
            if (matrix[i, j] > m)
            {
                m = matrix[i, j];
                index = j;
            }
        }
    }
    return index;
}
public int FindMinAboveDiagonalIndex(int[,] matrix)
{
    int index = 0;
    int m = 1000;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = i + 1; j < matrix.GetLength(0); j++)
        {
            if (matrix[i, j] < m)
            {
                m = matrix[i, j];
                index = j;
            }
        }
    }
    return index;
}
public int[,] RemoveColumns(int[,] matrix, FindIndex maxBelow, FindIndex minAbove)
{
    int i1 = maxBelow(matrix);
    int i2 = minAbove(matrix);
    if (i1 == i2)
        matrix = RemoveColumn(matrix, i1);
    else
    {
        matrix = RemoveColumn(matrix, Math.Max(i1, i2));
        matrix = RemoveColumn(matrix, Math.Min(i1, i2));
    }
    return matrix;
}
public void Task_3_13(ref int[,] matrix)
{
    // code here
    // use public delegate FindElementDelegate(matrix) from Task_3_6
    // create and use method RemoveRows(matrix, findMax, findMin)
    // end
}
public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
{

    rows = null;
    cols = null;

    FindNegatives(matrix, out rows, out cols);
    // code here

    // create and use public delegate GetNegativeArray(matrix);
    // use GetNegativeCountPerRow(matrix) from Task_2_22
    // use GetMaxNegativePerColumn(matrix) from Task_2_22
    // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

    // end
}
public delegate int GetNegativeArray(int[,] matrix, int rowIndex);
public void FindNegatives(int[,] matrix, out int[] rows, out int[] cols)
{
    rows = new int[matrix.GetLength(0)];
    cols = new int[matrix.GetLength(1)];
    GetNegativeArray searcherRows = CountNegativeInRow;
    GetNegativeArray searcherCols = FindMaxNegativePerColumn;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        rows[i] = searcherRows(matrix, i);
    }

    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        cols[j] = searcherCols(matrix, j);
    }
}

public void Task_3_27(int[,] A, int[,] B)
{
    // code here
    // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
    // use ReplaceMaxElementOdd(matrix) from Task_2_27
    // use ReplaceMaxElementEven(matrix) from Task_2_27
    // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
    // end
}
public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
{
    // code here
    answerFirst = DefineSequence(first, 0, first.Length - 1);
    answerSecond = DefineSequence(second, 0, second.Length - 1);
    Console.WriteLine(answerFirst);

    // create public delegate IsSequence(array, left, right);
    // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
    // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
    // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);
}
public delegate bool IsSequence(int[] arrat, int left, int right);

// end
public bool FindIncreasingSequence(int[] array, int A, int B)
{
    bool answer = true;
    for (int i = A; i <= B - 1; i++)
    {
        if (array[i] > array[i + 1])
            answer = false;
    }
    return answer;
}
public bool FindDecreasingSequence(int[] array, int A, int B)
{
    bool answer = true;
    for (int i = A; i <= B - 1; i++)
    {
        if (array[i] < array[i + 1])
            answer = false;
    }
    return answer;
}
public int DefineSequence(int[] array, int A, int B)
{
    int answer = 0;
    IsSequence monotony = FindIncreasingSequence;
    if (monotony(array, A, B))
        answer = 1;
    monotony = FindDecreasingSequence;
    if (monotony(array, A, B))
        answer = -1;
    return answer;
}
// end


public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
{
    // code here

    IsSequence monotony = FindIncreasingSequence;
    answerFirstIncrease = FindLongestSequence(first, monotony);
    answerSecondIncrease = FindLongestSequence(second, monotony);
    monotony = FindDecreasingSequence;
    answerFirstDecrease = FindLongestSequence(first, monotony);
    answerSecondDecrease = FindLongestSequence(second, monotony);
    printarr(answerFirstIncrease);
    Console.WriteLine();
    printarr(answerSecondIncrease);
    Console.WriteLine();
    printarr(answerFirstDecrease);
    Console.WriteLine();
    printarr(answerSecondDecrease);
    // create public delegate IsSequence(array, left, right);
    // use method FindIncreasingSequence(array, A, B); from Task_3_28a
    // use method FindDecreasingSequence(array, A, B); from Task_3_28a
    // create and use method FindLongestSequence(array, sequence);

    // end
}
public int[] FindLongestSequence(int[] array, IsSequence sequence)
{
    int ans = 0;
    int ansi = -1;
    int ansj = -1;
    int[] answer = null;
    for (int i = 0; i < array.Length - 1; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (sequence(array, i, j) && j - i + 1 > ans)
            {
                ans = j - i + 1;
                ansi = i;
                ansj = j;
            }
        }
    }
    Console.WriteLine(ansi);
    Console.WriteLine(ansj);
    answer = new int[2];
    int k = 0;
    if (ansi == -1)
        return answer;
    answer[0] = ansi;
    answer[1] = ansj;
    return answer;
}
// end

#endregion
#region bonus part
public void Task_4(double[,] matrix, int index)

    public delegate void MatrixConverter(double[,] matrix);

public void ToUpperTriangular(double[,] matrix)
{
    // MatrixConverter[] mc = new MatrixConverter[3]; - uncomment me
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        for (int i = j + 1; i < matrix.GetLength(0); i++)
        {
            double k = matrix[i, j] / matrix[j, j];

            for (int jj = j; jj < matrix.GetLength(0); jj++)
            {
                matrix[i, jj] -= k * matrix[j, jj];
            }
        }
    }
}

// code here
public void ToLowerTriangular(double[,] matrix)
{
    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
    {
        for (int i = j - 1; i >= 0; i--)
        {
            double k = matrix[i, j] / matrix[j, j];

            for (int jj = j; jj >= 0; jj--)
            {
                matrix[i, jj] -= k * matrix[j, jj];
            }
        }
    }
}

// create public delegate MatrixConverter(matrix);
// create and use method ToUpperTriangular(matrix);
// create and use method ToLowerTriangular(matrix);
// create and use method ToDiagonal(matrix,);
public void ToLeftDiagonal(double[,] matrix)
{
    ToUpperTriangular(matrix);
    ToLowerTriangular(matrix);
}

// end
public void ToRightDiagonal(double[,] matrix)
{
    ToLowerTriangular(matrix);
    ToUpperTriangular(matrix);
}

public double[,] Task_4(double[,] matrix, int index)
{
    MatrixConverter[] mc = new MatrixConverter[] { ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal };

    mc[index](matrix);

    return matrix;
}

    #endregion
}
