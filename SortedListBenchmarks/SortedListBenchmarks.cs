using BenchmarkDotNet.Attributes;
using WojciechMikołajewicz.SortedList;

namespace SortedListBenchmarks;

[MemoryDiagnoser]
public class SortedListBenchmarks
{
	const int SampleListLength = 1_000_000;

	public readonly SortedReadOnlyList<int, int> SampleList;

	public SortedListBenchmarks()
	{
		SampleList = new SortedReadOnlyList<int, int>(Enumerable.Range(0, SampleListLength),
			new KeyData<int, int>(x => x)
			);
	}

	[Benchmark(Baseline = true)]
	[Arguments(557)]
	public SortedReadOnlyListRange<int, int> SearchEqual(int searchingValue)
	{
		var range = SampleList.BinaryFindEqual(searchingValue);

		return range;
	}
}