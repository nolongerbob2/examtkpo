// Автор: Кожемякин Даниил Сергеевич, группа: 231-3213. Контейнер учёта автомобилей.

namespace CarFlyweight;

/// <summary>
/// Контейнер учёта: хранит список зарегистрированных автомобилей (<see cref="List{T}"/>).
/// Демонстрирует работу с объектами контекста, разделяющими легковесы.
/// </summary>
public sealed class CarPark
{
    private readonly List<RegisteredCar> _cars = new();

    /// <summary>Добавить автомобиль в учёт.</summary>
    public void Add(RegisteredCar car) => _cars.Add(car);

    /// <summary>Все записи (для перечисления).</summary>
    public IReadOnlyList<RegisteredCar> Cars => _cars;
}
