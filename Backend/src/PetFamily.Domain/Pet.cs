using CSharpFunctionalExtensions;
using PetFamily.Domain.Species;

namespace PetFamily.Domain;

public class Pet : Entity
{
    public Guid Id { get; set; } //Id
    public string Name { get; set; } = string.Empty; //Кличка
    public Sex Sex { get; set; } //Пол
    public Species.Species Species { get; set; } //Вид(например - собака, кошка)
    public Breed Breed { get; set; } //Порода
    public string Description { get; set; } = string.Empty; //Общее описание
    //Окрас
    public string HealthInfo { get; set; } = string.Empty;//Информация о здоровье питомца
    public float WeightKg { get; set; } //Вес  
    public float HeightCm { get; set; } //Рост
    //Адрес, где находится питомец
    //Номер телефона для связи с владельцем
    public bool IsNeutered { get; set; } //Кастрирован или нет
    public bool IsVaccinated { get; set; } //Вакцинирован или нет
    public DateTime BirthDate { get; set; } //Дата рождения
    //Статус помощи - Нуждается в помощи/Ищет дом/Нашел дом
    //Реквизиты для помощи(у каждого реквизита будет название и описание, как сделать перевод), поэтому нужно сделать отдельный класс для реквизита.Это должен быть Value Object.
    public DateTime CreateDate { get; set; }//Дата создания
}

public enum Sex
{
    None = 0,
    Male = 1,
    Female = 2
}

