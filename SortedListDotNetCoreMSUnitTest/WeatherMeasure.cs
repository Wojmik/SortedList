using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList;

namespace WojciechMikołajewicz.SortedListDotNetCoreMSUnitTest
{
	public class WeatherMeasure
	{
		public string MeasureStationCode { get; set; }
		public DateTime MeasureDate { get; set; }
		public float Temperature { get; set; }
		public float Humidity { get; set; }
		public float WindStrength { get; set; }



		public void Find()
		{
			var listOfMeasures = new List<WeatherMeasure>();

			var measures = new SortedReadOnlyList<WeatherMeasure, string, DateTime>(listOfMeasures,
				new KeyData<WeatherMeasure, string>(measure => measure.MeasureStationCode, StringComparer.InvariantCultureIgnoreCase),
				new KeyData<WeatherMeasure, DateTime>(measure => measure.MeasureDate)
				);


			var anchorageMeasuresForDate = measures
				.BinaryFindGreaterOrEqual("Anchorage-2BA", new DateTime(2020, 9, 18))
				.BinaryFindLess("Anchorage-2BA", new DateTime(2020, 9, 19));


			//Suppose we have List of WeatherMeasure
			List<WeatherMeasure> weatherMeasures = null;

			//We need to sort that list in order to binary search it
			weatherMeasures.Sort(Comparer);

			var range = weatherMeasures.BinaryFindGreaterOrEqual(Range.All, measure =>
			{
				int cmp;

				if(0==(cmp=StringComparer.InvariantCultureIgnoreCase.Compare(measure.MeasureStationCode, "Anchorage-2BA")))
					cmp=measure.MeasureDate.CompareTo(new DateTime(2020, 9, 18));
				return cmp;
			});

			range = weatherMeasures.BinaryFindLess(range, measure =>
			{
				int cmp;

				if(0==(cmp=StringComparer.InvariantCultureIgnoreCase.Compare(measure.MeasureStationCode, "Anchorage-2BA")))
					cmp=measure.MeasureDate.CompareTo(new DateTime(2020, 9, 19));
				return cmp;
			});
		}

		//Sorting method
		private int Comparer(WeatherMeasure x, WeatherMeasure y)
		{
			int cmp;

			if(0==(cmp=StringComparer.InvariantCultureIgnoreCase.Compare(x.MeasureStationCode, y.MeasureStationCode)))
				cmp=x.MeasureDate.CompareTo(y.MeasureDate);
			return cmp;
		}
	}
}