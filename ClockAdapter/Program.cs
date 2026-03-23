/*
 * Автор: Кожемякин Даниил Сергеевич
 * Группа: 231-3213
 * Задание: паттерн «Адаптер», проект «Часы» — интерпретация показаний стрелочных часов в формат ЧЧ : ММ.
 */

namespace ClockAdapter;

internal static class Program
{
    private static void Main()
    {
        var analog = new AnalogClock();
        IDigitalTimeDisplay display = new AnalogToDigitalClockAdapter(analog);

        // Пример: 14:30 на 24-часовых — на 12-часовом циферблате это 2:30.
        analog.SetHandsByAngles(hourHandFrom12ClockwiseDeg: 75.0, minuteHandFrom12ClockwiseDeg: 180.0);
        Console.WriteLine($"2:30 (углы 75° и 180°) -> {display.GetDigitalTime()}");

        // Задание через «чужой» API (обороты): 10:15.
        analog.SetHandsByTurns(hourHandTurns: (10 * 30 + 15 * 0.5) / 360.0, minuteHandTurns: (15 * 6) / 360.0);
        Console.WriteLine($"10:15 через обороты -> {display.GetDigitalTime()}");

        // Полдень: обе стрелки у «12».
        analog.SetHandsByAngles(0, 0);
        Console.WriteLine($"12:00 -> {display.GetDigitalTime()}");
    }
}
