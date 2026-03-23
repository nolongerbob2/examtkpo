/*
 * Идея реализации:
 * Марка, модель, цвет и год часто повторяются у разных машин — их выносим в легковес и
 * переиспользуем через фабрику с пулом (Dictionary). Регистрационный номер и владелец уникальны —
 * хранятся только в контексте RegisteredCar. Так уменьшается число объектов с одинаковыми
 * «типовыми» данными при большом количестве учётных записей.
 *
 * Автор: Кожемякин Даниил Сергеевич
 * Группа: 231-3213
 * Задание: паттерн «Легковес» — разделяемая и неразделяемая части информации об автомобилях.
 */

namespace CarFlyweight;

internal static class Program
{
    private static void Main()
    {
        var factory = new CarFlyweightFactory();
        var park = new CarPark();

        // Три записи: две Toyota одинаковой комплектации — один легковес в пуле.
        var toyotaTemplate = factory.GetFlyweight("Toyota", "Camry", "чёрный", 2020);
        park.Add(new RegisteredCar(toyotaTemplate, "А123ВС77", "Иванов И.И."));
        park.Add(new RegisteredCar(toyotaTemplate, "К555ТТ99", "Петров П.П."));

        var bmw = factory.GetFlyweight("BMW", "X5", "белый", 2022);
        park.Add(new RegisteredCar(bmw, "М777ОО50", "Сидорова А.К."));

        Console.WriteLine($"Уникальных легковесов в пуле: {factory.UniqueFlyweightCount} (записей в парке: {park.Cars.Count})");
        Console.WriteLine();

        foreach (var car in park.Cars)
            Console.WriteLine(car.GetFullInfo());
    }
}
