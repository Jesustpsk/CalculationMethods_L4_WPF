using System;

namespace CalculationMethods_L4_WPF;

public static class KhaletskyMethod
{
    public static string Khaletsky(double[,] A, double[] b)
    {
        var n = A.GetLength(0);

        var L = new double[n, n];
        var Lt = new double[n, n];

        // Разложение матрицы A на произведение L и Lt
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < (i + 1); j++)
            {
                var sum = 0.0;
                for (var k = 0; k < j; k++)
                {
                    sum += L[i, k] * Lt[k, j];
                }

                if (i == j)
                {
                    L[i, j] = Math.Sqrt(A[i, i] - sum);
                }
                else
                {
                    L[i, j] = (A[i, j] - sum) / L[j, j];
                }

                Lt[j, i] = L[i, j];
            }
        }

        // Решение системы Ly = b методом прямого хода
        var y = new double[n];
        for (var i = 0; i < n; i++)
        {
            var sum = 0.0;
            for (var j = 0; j < i; j++)
            {
                sum += L[i, j] * y[j];
            }
            y[i] = (b[i] - sum) / L[i, i];
        }

        // Решение системы Ltx = y методом обратного хода
        var x = new double[n];
        for (var i = n - 1; i >= 0; i--)
        {
            var sum = 0.0;
            for (var j = i + 1; j < n; j++)
            {
                sum += Lt[i, j] * x[j];
            }
            x[i] = (y[i] - sum) / Lt[i, i];
        }

        var output = "Solution: ";
        for (var i = 0; i < n; i++)
        {
            output += ("x[{0}] = {1}", i, x[i]) + "\n";
        }

        return output;
    }
}