// Автор: Кожемякин Даниил Сергеевич, группа: 231-3213. Контекст — неразделяемые поля + ссылка на легковес.

namespace CarFlyweight;

/// <summary>
/// Контекст (Context): неразделяемая сущность. Регистрационный номер и владелец уникальны для каждой записи;
/// ссылка на <see cref="CarFlyweight"/> — общая для машин с одинаковой маркой, моделью, цветом и годом.
/// </summary>
public sealed class RegisteredCar
{
    /// <summary>Разделяемый шаблон (легковес).</summary>
    public CarFlyweight Flyweight { get; }

    /// <summary>Регистрационный номер (экстринсик).</summary>
    public string RegistrationNumber { get; }

    /// <summary>Владелец (экстринсик).</summary>
    public string Owner { get; }

    public RegisteredCar(CarFlyweight flyweight, string registrationNumber, string owner)
    {
        Flyweight = flyweight;
        RegistrationNumber = registrationNumber;
        Owner = owner;
    }

    /// <summary>Полная информация об автомобиле в одной строке.</summary>
    public string GetFullInfo() => Flyweight.FormatWithExtrinsic(RegistrationNumber, Owner);
}
