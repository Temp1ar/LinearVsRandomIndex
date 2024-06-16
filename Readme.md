```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK 8.0.101
  [Host]               : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET 8.0             : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI
  .NET Framework 4.7.2 : .NET Framework 4.8.1 (4.8.9241.0), X64 RyuJIT VectorSize=256


```
| Method                 | Job                  | Runtime              | Mean      | Error     | StdDev    | Ratio | RatioSD | Code Size |
|----------------------- |--------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|----------:|
| AscendingIndicesAccess | .NET 8.0             | .NET 8.0             |  5.114 ms | 0.0226 ms | 0.0200 ms |  1.00 |    0.00 |     514 B |
| RandomIndicesAccess    | .NET 8.0             | .NET 8.0             | 82.442 ms | 0.6040 ms | 0.5650 ms | 16.12 |    0.10 |     514 B |
|                        |                      |                      |           |           |           |       |         |           |
| AscendingIndicesAccess | .NET Framework 4.7.2 | .NET Framework 4.7.2 |  6.618 ms | 0.0216 ms | 0.0191 ms |  1.00 |    0.00 |     632 B |
| RandomIndicesAccess    | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 84.459 ms | 0.4180 ms | 0.3910 ms | 12.77 |    0.08 |     632 B |
