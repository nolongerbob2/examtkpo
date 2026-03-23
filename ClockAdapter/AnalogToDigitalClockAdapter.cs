// Автор: Кожемякин Даниил Сергеевич, группа: 231-3213. Адаптер: углы стрелок → строка «ЧЧ : ММ».

namespace ClockAdapter;

/// <summary>
/// Адаптер (Adapter): реализует <see cref="IDigitalTimeDisplay"/> и внутри использует
/// <see cref="AnalogClock"/>. Переводит углы стрелок в часы и минуты по геометрии циферблата:
/// минутная стрелка — 6° на минуту; часовая — 30° на час плюс 0,5° за каждую минуту.
/// </summary>
public class AnalogToDigitalClockAdapter : IDigitalTimeDisplay
{
    private readonly AnalogClock _analog;

    /// <summary>
    /// Ключевой объект адаптера — ссылка на экземпляр стрелочных часов, показания которых переводятся.
    /// </summary>
    public AnalogToDigitalClockAdapter(AnalogClock analog)
    {
        _analog = analog ?? throw new ArgumentNullException(nameof(analog));
    }

    /// <inheritdoc />
    public string GetDigitalTime()
    {
        var (hour12, minute) = DecodeFromAngles(_analog.HourHandDegrees, _analog.MinuteHandDegrees);
        return $"{hour12:D2} : {minute:D2}";
    }

    /// <summary>
    /// Обратный расчёт: по углам стрелок восстанавливаем минуты и час (1–12 на 12-часовом циферблате).
    /// </summary>
    private static (int Hour12, int Minute) DecodeFromAngles(double hourDeg, double minuteDeg)
    {
        minuteDeg = NormalizeDegrees(minuteDeg);
        hourDeg = NormalizeDegrees(hourDeg);

        var minute = (int)Math.Round(minuteDeg / 6.0);
        minute %= 60;
        if (minute < 0) minute += 60;

        // Часовая стрелка: 30°·h + 0,5°·m (h в диапазоне 0…11 для положений «за 12»).
        var hourContributionFromMinutes = minute * 0.5;
        var rawHour = (hourDeg - hourContributionFromMinutes) / 30.0;
        var hourMod12 = (int)Math.Round(rawHour);
        hourMod12 %= 12;
        if (hourMod12 < 0) hourMod12 += 12;

        var hour12 = hourMod12 == 0 ? 12 : hourMod12;
        return (hour12, minute);
    }

    private static double NormalizeDegrees(double deg)
    {
        deg %= 360.0;
        if (deg < 0) deg += 360.0;
        return deg;
    }
}
