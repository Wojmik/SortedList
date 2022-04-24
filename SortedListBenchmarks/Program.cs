using BenchmarkDotNet.Running;
using SortedListBenchmarks;

var summary = BenchmarkRunner.Run(typeof(Program).Assembly);