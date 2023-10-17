using System;

namespace CalculationMethods_L4_WPF;

public static class KhaletskyMethod
{

    public static string Khaletsky(double[,] a_matrix, double[] b_vector, int size)
    {
        var Lt = new double[size, size]; //Верняя треугольная матрица
        var L = new double[size, size]; //Нижняя треугольная матрица
        var y = new double[size]; //Вектор у-ков
        var x_vector = new double[size]; //Вектор иксов

        //Находим нижнюю треугольную матрицу 
        L[0, 0] = Math.Sqrt(a_matrix[0, 0]); //Задаем первый элемент матрицы L как корень из первого элемента матрицы А
        for (var i = 1; i < size; i++)
        {
            var SumJ_El = 0.0;
            for (var j = 1; j < size + 1; j++)
            {
                if (j - 1 >= i) continue;
                for (var k = 0; k < j - 1; k++)
                    SumJ_El += L[i, k] * L[j - 1, k];
                L[i, j - 1] = (a_matrix[i, j - 1] - SumJ_El) / L[j - 1, j - 1];
            }

            var SumI_El = 0.0;
            for (var k = 0; k < i; k++)
            {
                SumI_El += L[i, k] * L[i, k];
            }

            L[i, i] = Math.Sqrt(a_matrix[i, i] - SumI_El);
        }

        //Транспонируем матрицу L и получаем матрицу LT
        for (var i = 0; i < size; i++)
        for (var j = 0; j < size; j++)
            Lt[i, j] = L[j, i];

        //Рассчитываем вектор у
        var summa = 0.0;
        for (var i = 0; i < size; i++)
        {
            summa = 0.0;
            for (var j = 0; j < i; j++)
            {
                summa += (L[i, j] * y[j]);
            }

            y[i] = (b_vector[i] - summa) / L[i, i];
        }

        //Наконец то находим значение наших иксов
        for (var i = size - 1; i >= 0; i--)
        {
            summa = 0;
            for (var j = size - 1; j > i; j--)
            {
                summa += Lt[i, j] * x_vector[j];
            }

            x_vector[i] = (y[i] - summa) / Lt[i, i];
        }
        var output = "";
        for (var i = 0; i < size; i++)
            output += "x" + (i + 1) + " = " + x_vector[i] + "\n";
        return output;
    }

}