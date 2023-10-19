using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] X = { 3, 5, 2, 7, 4, 8, 9, 1, 6 };
        int minIndex = Array.IndexOf(X, X.Min());
        int temp = X[0];
        X[0] = X[minIndex];
        X[minIndex] = temp;
        int maxIndex = Array.IndexOf(X, X.Max());
        int[] primes = new int[X.Length - maxIndex - 1];
        int j = 0;
        for (int i = maxIndex + 1; i < X.Length; i++)
        {
            if (IsPrime(X[i]))
            {
                primes[j] = i;
                j++;
            }
        }
        Array.Reverse(primes);
        foreach (int prime in primes)
        {
            X = X.Where((source, index) => index != prime).ToArray();
        }
        double averageBeforeRemoval = X.Take(maxIndex).Average();
        double averageAfterRemoval = X.Skip(maxIndex).Average();
        Console.WriteLine("Array after swapping first and minimum element: [" + string.Join(", ", X) + "]");
        Console.WriteLine("Average of elements before removal: " + averageBeforeRemoval);
        Console.WriteLine("Average of elements after removal: " + averageAfterRemoval);
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        var boundary = (int)Math.Floor(Math.Sqrt(number));
        for (int i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;
        return true;
    }
}
