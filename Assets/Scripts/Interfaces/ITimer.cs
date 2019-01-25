namespace TAMK.SpaceShooter.Interfaces
{
	public interface ITimer
	{
		/// <summary>
		/// Kertoo, onko ajastin käynyt loppuun vai ei
		/// </summary>
		bool IsCompleted { get; }

		/// <summary>
		/// Kertoo, onko ajastin käynnissä vai ei
		/// </summary>
		bool IsRunning { get; }

		// Kertoo tämänhetkisen ajan
		float CurrentTime { get; }

		// Käynnistää ajastimen
		void StartTimer();

		// Pysäyttää ajastimen
		void Stop();

		// Asettaa ajan
		void SetTime(float time);
	}
}
