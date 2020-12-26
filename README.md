# Sorted List

Repository for extremally fast binary searching in sorted list for .Net. It is like database clustered index.

Regular .Net searchable lists like HasSet&lt;T&gt; or Dictionary&lt;T&gt; – based on equality, are able to search only by equality condition. Grater or less conditions are impossible. Searching by part of the key is impossible also.

Sorted list on the other hand, can be searched by equal, greater, greater or equal, less and less or equal conditions. It is also possible to search by part of the key under certain conditions.

Very simple example of sorted list is old fashioned phonebook. Phonebook is sorted by surname, first name and street address. Phonebook can be searched by surname, first name and street address but it can be also searched by surname and first name only (without street address) or by surname only. You only have to follow key order – surname, first name and street address. You cannot skip surname and search only by first name.

In phonebook you can also search by greater and less criterions. Let's say you want  to find all records from Smith Carolina to Smith John. It is perfectly possible.

Just imagine – phonebooks can contain hundreds thousands of records but it is pretty easy for human to find one particular entry. That is the power of binary search.

# SortedReadOnlyList

Repository contains very simple to use SortedReadOnlyList type in WojciechMikołajewicz.SortedList namespace.

Let's say you have records from automatic weather measuring stations. Weather measure is defined like follow:

```c#
public class WeatherMeasure
{
	public string MeasureStationCode { get; set; }
	public DateTime MeasureDate { get; set; }
	public float Temperature { get; set; }
	public float Humidity { get; set; }
	public float WindStrength { get; set; }
}
```

To make weather forecast it is crucial to find weather measures very efficiently.

We will need to find measures from particular station in a given time period. To do that we simply create a SortedReadOlnyList:

```c#
var measures = new SortedReadOnlyList<WeatherMeasure, string, DateTime>(listOfMeasures,
	new KeyData<WeatherMeasure, string>(measure => measure.MeasureStationCode, StringComparer.InvariantCultureIgnoreCase),
	new KeyData<WeatherMeasure, DateTime>(measure => measure.MeasureDate)
	);
```

First generic type is type of items in the list, next generic types are types of keys by which list will be sorted.

First constructor argument is source list of items, next are keys definitions. First key is MeasureStationCode, second is MeasureDate. To define the key we need to tell how to get key from item – by providing lambda expression and optionally key comparer. If no key comparer is provided, default key comparer will be used.

Now we can search. Suppose we want all measures from "Anchorage-2BA" station. All we need to do is:

```c#
var anchorageMeasures = measures.BinaryFindEqual("Anchorage-2BA");
```

That's it, anchorageMeasures now contains only measures from selected station. That was search by only first key.

Suppose we want all measures from "Anchorage-2BA" station from 2020-09-18:

```c#
var anchorageMeasuresForDate = measures
	.BinaryFindGreaterOrEqual("Anchorage-2BA", new DateTime(2020, 9, 18))
	.BinaryFindLess("Anchorage-2BA", new DateTime(2020, 9, 19));
```

And we have it. This was two searches by all – two keys.

It's worth mentioned that those searches are extremally fast and with zero allocation. The result list is only range in source SortedReadOnlyList so there is no items coping.