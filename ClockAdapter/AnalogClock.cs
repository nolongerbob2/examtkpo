// Автор: Кожемякин Даниил Сергеевич, группа: 231-3213. Адаптируемый класс — стрелочные часы.

namespace ClockAdapter;

/// <summary>
/// Адаптируемый класс (Adaptee) — модель стрелочных часов.
/// Предоставляет только «аналоговое» представление: углы стрелок от линии «12 часов»
/// по часовой стрелке в градусах [0; 360). Не реализует строковый цифровой вывод.
/// </summary>
public class AnalogClock
{
    /// <summary>Угол часовой стрелки отметки «12» по часовой стрелке, градусы.</summary>
    public double HourHandDegrees { get; private set; }

    /// <summary>Угол минутной стрелки отметки «12» по часовой стрелке, градусы.</summary>
    public double MinuteHandDegrees { get; private set; }

    /// <summary>
    /// Задаёт положение стрелок по углам на циферблате (как у физических часов).
    /// </summary>
    public void SetHandsByAngles(double hourHandFrom12ClockwiseDeg, double minuteHandFrom12ClockwiseDeg)
    {
        HourHandDegrees = NormalizeDegrees(hourHandFrom12ClockwiseDeg);
        MinuteHandDegrees = NormalizeDegrees(minuteHandFrom12ClockwiseDeg);
    }

    /// <summary>
    /// Задаёт стрелки через доли полного оборота (0…1 — один оборот = 360°).
    /// Имитирует «чужой» API прибора, который отдаёт не часы/минуты, а обороты.
    /// </summary>
    public void SetHandsByTurns(double hourHandTurns, double minuteHandTurns)
    {
        SetHandsByAngles(hourHandTurns * 360.0, minuteHandTurns * 360.0);
    }

    private static double NormalizeDegrees(double deg)
    {
        deg %= 360.0;
        if (deg < 0) deg += 360.0;
        return deg;
    }
}
