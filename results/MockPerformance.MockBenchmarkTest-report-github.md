``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.590 (1803/April2018Update/Redstone4)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0
  DefaultJob : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.3324.0


```
|          Method |       Mean |    Error |   StdDev |
|---------------- |-----------:|---------:|---------:|
| CreateRhinoMock |   753.1 us | 52.14 us | 153.7 us |
|   CreateMoqMock | 1,114.5 us | 52.21 us | 154.0 us |
