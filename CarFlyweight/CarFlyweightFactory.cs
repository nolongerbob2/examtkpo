// Автор: Кожемякин Даниил Сергеевич, группа: 231-3213. Фабрика легковесов с пулом.

namespace CarFlyweight;

/// <summary>
/// Фабрика легковесов: создаёт и кэширует объекты <see cref="CarFlyweight"/> по ключу
/// (марка, модель, цвет, год). Контейнер пула — <see cref="Dictionary{TKey,TValue}"/>.
/// </summary>
public sealed class CarFlyweightFactory
{
    private readonly Dictionary<string, CarFlyweight> _pool = new();

    /// <summary>
    /// Возвращает существующий легковес с заданными признаками или создаёт новый и помещает в пул.
    /// </summary>
    public CarFlyweight GetFlyweight(string brand, string model, string color, int year)
    {
        var key = MakeKey(brand, model, color, year);
        if (!_pool.TryGetValue(key, out var flyweight))
        {
            flyweight = new CarFlyweight(brand, model, color, year);
            _pool[key] = flyweight;
        }

        return flyweight;
    }

    /// <summary>Число уникальных разделяемых комбинаций в пуле.</summary>
    public int UniqueFlyweightCount => _pool.Count;

    private static string MakeKey(string brand, string model, string color, int year) =>
        $"{brand}\u001F{model}\u001F{color}\u001F{year}";
}
