using UnityEngine;
using TAMK.SpaceShooter.Interfaces;

namespace TAMK.SpaceShooter
{
	public class Timer : MonoBehaviour, ITimer
	{
		private float _currentTime;

		/// <summary>
		/// Kertoo, onko ajastin käynyt loppuun vai ei
		/// </summary>
		public bool IsCompleted
		{
			get
			{
				return CurrentTime <= 0;
			}
		}

		/// <summary>
		/// Kertoo, onko ajastin käynnissä vai ei
		/// </summary>
		public bool IsRunning { get; private set; }

		// Kertoo tämänhetkisen ajan
		public float CurrentTime
		{
			get { return _currentTime; }
			private set
			{
				_currentTime = Mathf.Max(value, 0);
			}
		}

		// Käynnistää ajastimen
		public void StartTimer()
		{
			IsRunning = true;
		}

		// Pysäyttää ajastimen
		public void Stop()
		{
			IsRunning = false;
		}

		// Asettaa ajan
		public void SetTime(float time)
		{
			// Jos IsRunning == false, suoritetaan if-blocki
			if(!IsRunning)
			{
				CurrentTime = time;
			}
		}

		private void Awake()
		{
			Stop();
		}

		private void Update()
		{
			if(IsRunning)
			{
				CurrentTime -= Time.deltaTime;
				if(IsCompleted)
				{
					Stop();
				}
			}
		}
	}
}
