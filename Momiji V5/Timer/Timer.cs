using Momiji.Bot.V5.Modules.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core.Timer
{
	public class Timer
	{
		private long DeltaTime = 0L;
		private Stopwatch stopwatch = new Stopwatch();
		private long Time1 = 0;
		private int pos10s, pos1m, pos10m, pos1h, pos3h, pos12h, pos24h = 0;
		private bool enabled = true;

		public Timer()
		{
			TimerEvent += new _TimerHandler(() => {
				DeltaTime = stopwatch.ElapsedMilliseconds;
				Time1 += DeltaTime;
				var date = DateTime.Now;
				if (Time1 >= 1000)
				{
					OnTimer?.Invoke((TimerType) 1);
					Time1 -= 1000;
					pos10s++;
				}
				if (pos10s >= 10)
				{
					OnTimer?.Invoke((TimerType) 2);
					pos10s -= 10;
					pos1m++;
				}
				if (pos1m >= 6)
				{
					OnTimer?.Invoke((TimerType) 3);
					pos1m -= 6;
					pos10m++;
				}
				if (pos10m >= 10)
				{
					OnTimer?.Invoke((TimerType) 4);
					pos10m -= 10;
				}
				if (pos1h >= 6)
				{
					OnTimer?.Invoke((TimerType) 5);
					pos1h -= 6;
					pos3h++;
					pos12h++;
					pos24h++;
				}
				if (pos3h >= 3)
				{
					OnTimer?.Invoke((TimerType) 6);
					pos3h -= 3;
				}
				if (pos12h >= 12)
				{
					OnTimer?.Invoke((TimerType) 7);
					pos12h -= 12;
				}
				if (pos24h >= 24)
				{
					OnTimer?.Invoke((TimerType) 8);
					pos24h -= 24;
				}
			});

			Thread thread = new Thread((e) => {
				while (enabled)
				{
					stopwatch.Restart();
					Thread.Sleep(249);
					TimerEvent?.Invoke();
				}
			});
			thread.IsBackground = true;
			thread.SetApartmentState(ApartmentState.MTA);
			thread.Priority = ThreadPriority.Highest;
			thread.Start();
		}

		private event _TimerHandler TimerEvent;
		private delegate void _TimerHandler();

		public event TimerHandler OnTimer;

		public delegate void TimerHandler(TimerType type);
	}
}
