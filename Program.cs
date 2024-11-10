using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Kaç adet x değeri gireceksiniz? ");
        int n = int.Parse(Console.ReadLine());
        List<double> values = new List<double>();

        for (int i = 0; i < n; i++)
        {
            Console.Write($"{i + 1}. x değerini girin: ");
            values.Add(double.Parse(Console.ReadLine()));
        }

        double result = StandartSapmaRekursif(values);
        Console.WriteLine($"Standart Sapma (Rekürsif): {result}");
    }

    static double StandartSapmaRekursif(List<double> values)
    {
        int n = values.Count;
        if (n == 0) return 0;

        double xm = MeanRecursive(values, n);
        double variance = VarianceRecursive(values, xm, n);

        return Math.Sqrt(variance);
    }

    static double MeanRecursive(List<double> values, int n)
    {
        if (values.Count == 0) return 0;
        return values[0] / n + MeanRecursive(values.GetRange(1, values.Count - 1), n);
    }

    static double VarianceRecursive(List<double> values, double xm, int n)
    {
        if (values.Count == 0) return 0;
        return Math.Pow(values[0] - xm, 2) / (n - 1) + VarianceRecursive(values.GetRange(1, values.Count - 1), xm, n);
    }
}