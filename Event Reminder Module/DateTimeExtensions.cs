using System;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public static class DateTimeExtensions
	{
		public static DateTime Cut(this DateTime date, DateTimeUnit unit)
		{
			var d = date;
			if (unit.HasFlag((DateTimeUnit)0b0001))
			{
				d = d.AddMilliseconds(-date.Millisecond);
			}
			if (unit.HasFlag((DateTimeUnit)0b0010))
			{
				d = d.AddSeconds(-date.Second);
			}
			if (unit.HasFlag((DateTimeUnit)0b0100))
			{
				d = d.AddMinutes(-date.Minute);
			}
			if (unit.HasFlag((DateTimeUnit)0b1000))
			{
				d = d.AddHours(-date.Hour);
			}
			return d;
		}

		public static DateTime CutSeconds(this DateTime date)
		{
			return date.Cut(DateTimeUnit.Seconds);
		}

		[Flags]
		public enum DateTimeUnit
		{
			Milliseconds = 0b0001,
			Seconds      = 0b0011,
			Minutes      = 0b0111,
			Hours        = 0b1111
		}
	}
}
