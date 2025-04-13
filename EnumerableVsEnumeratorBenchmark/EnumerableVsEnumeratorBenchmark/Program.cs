using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Windows.Markup;


public class EnumerableVsEnumerator
{
    private static readonly Random Random = new(420);
    //private readonly List<int> _numbers =
    //    Enumerable.Range(0, 10_000).Select(_ => Random.Next(0, 10_000)).ToList();
    private readonly List<decimal> _productPrices= Enumerable.Range(0, 10_000)
        .Select(i => (decimal)i)
        .ToList();

    [Benchmark]
    public decimal TestIEnumerable() 
    {
       
        var sum = 0m;
        foreach (var price in _productPrices) 
        {
            sum += price;
        }

        return sum;
    }


    [Benchmark]
    public decimal TestIEnumerator() 
    {
        List<decimal>.Enumerator numberEnumerator = _productPrices.GetEnumerator();
        var sum = 0m;
        while(numberEnumerator.MoveNext())
        {
            sum += numberEnumerator.Current;
        }
        return sum;
    }

    public static void Main() => BenchmarkRunner.Run<EnumerableVsEnumerator>();
}
