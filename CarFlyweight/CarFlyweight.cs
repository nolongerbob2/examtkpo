// Автор: Кожемякин Даниил Сергеевич, группа: 231-3213. Легковес — разделяемая часть данных об автомобиле.

namespace CarFlyweight;

/// <summary>
/// Легковес (Flyweight): разделяемая сущность. Хранит инвариантные для многих записей признаки:
/// марка, модель, цвет, год выпуска. Один экземпляр может использоваться многими «учётными» записями.
/// </summary>
public sealed class CarFlyweight
{
    /// <summary>Марка автомобиля.</summary>
    public string Brand { get; }

    /// <summary>Модель.</summary>
    public string Model { get; }

    /// <summary>Цвет кузова.</summary>
    public string Color { get; }

    /// <summary>Год выпуска.</summary>
    public int Year { get; }

    public CarFlyweight(string brand, string model, string color, int year)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Year = year;
    }

    /// <summary>
    /// Формирует полное описание, подставляя неразделяемые данные (номер, владелец).
    /// </summary>
    public string FormatWithExtrinsic(string registrationNumber, string owner) =>
        $"Марка: {Brand}, модель: {Model}, цвет: {Color}, год: {Year}, " +
        $"рег. номер: {registrationNumber}, владелец: {owner}";
}
