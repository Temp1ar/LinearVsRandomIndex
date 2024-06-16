using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace LinearVsRandomIndex;

// [MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net472)]
[SimpleJob(RuntimeMoniker.Net80)]
[DisassemblyDiagnoser]
public class Benchmark
{
    private const int ElementCount = 16_000_000;
    private readonly ulong[] myData = new ulong[ElementCount];
    private int myResult = 0;
    private readonly int[] myAscendingIndices;
    private readonly int[] myRandomIndices;

    public Benchmark()
    {
        var random = new Random();
        for (int i = 0; i < myData.Length; i++)
        {
            var next = (ulong)random.Next();
            myResult += (int)next;
            myData[i] = next;
        }

        myAscendingIndices = Enumerable.Range(0, myData.Length).ToArray();
        myRandomIndices = Enumerable.Range(0, myData.Length).OrderBy(_ => random.Next()).ToArray();
    }

    [Benchmark(Baseline = true)]
    public void AscendingIndicesAccess()
    {
        var result0 = 0;
        var result1 = 0;
        var result2 = 0;
        var result3 = 0;
        var result4 = 0;
        var result5 = 0;
        var result6 = 0;
        var result7 = 0;
        for (int i = 0; i < myAscendingIndices.Length; i += 8)
        {
            result0 += (int)myData[myAscendingIndices[i + 0]];
            result1 += (int)myData[myAscendingIndices[i + 1]];
            result2 += (int)myData[myAscendingIndices[i + 2]];
            result3 += (int)myData[myAscendingIndices[i + 3]];
            result4 += (int)myData[myAscendingIndices[i + 4]];
            result5 += (int)myData[myAscendingIndices[i + 5]];
            result6 += (int)myData[myAscendingIndices[i + 6]];
            result7 += (int)myData[myAscendingIndices[i + 7]];
        }

        if ((result0 + result1 + result2 + result3 + result4 + result5 + result6 + result7) != myResult)
        {
            throw new ApplicationException($"Results differ");
        }
    }

    [Benchmark]
    public void RandomIndicesAccess()
    {
        var result0 = 0;
        var result1 = 0;
        var result2 = 0;
        var result3 = 0;
        var result4 = 0;
        var result5 = 0;
        var result6 = 0;
        var result7 = 0;
        for (int i = 0; i < myRandomIndices.Length; i += 8)
        {
            result0 += (int)myData[myRandomIndices[i + 0]];
            result1 += (int)myData[myRandomIndices[i + 1]];
            result2 += (int)myData[myRandomIndices[i + 2]];
            result3 += (int)myData[myRandomIndices[i + 3]];
            result4 += (int)myData[myRandomIndices[i + 4]];
            result5 += (int)myData[myRandomIndices[i + 5]];
            result6 += (int)myData[myRandomIndices[i + 6]];
            result7 += (int)myData[myRandomIndices[i + 7]];
        }

        if ((result0 + result1 + result2 + result3 + result4 + result5 + result6 + result7) != myResult)
        {
            throw new ApplicationException($"Results differ");
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmark>();
    }
}