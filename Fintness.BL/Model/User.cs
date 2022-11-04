using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintness.BL.Model
{
    internal class User:IValidatableObject
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; init; }
        public Gender Gender { get; init; }
        /// <summary>
        /// Дата Рождения
        /// </summary>
        public DateTime Birthday { get; init; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }
        #endregion
        private User(string name,int age,Gender gender,DateTime birthday,double weight,double height)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Birthday = birthday;
            Weight = weight;
            Height = height;
        }
        #region Проверка Данных
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name)) results.Add(new ValidationResult("Заполните поле: Имя."));
            if(Age <= 0 || Age > 100) results.Add(new ValidationResult("Возраст должен быть действительным!"));
            if(Gender is null) results.Add(new ValidationResult("Заполните поле: Пол."));
            if (Birthday.Year > DateTime.Now.Year || Birthday.Year > DateTime.Now.Year - 100) results.Add(new ValidationResult("Возраст должен быть действительным!"));
            if(Weight <=0) results.Add(new ValidationResult("Вес должен быть действительным!"));
            if (Height <=0) results.Add(new ValidationResult("Рост должен быть действительным!"));

            return results;
        }
        #endregion

        public static User CreateUser(string name, int age, Gender gender, DateTime birthday, double weight, double height)
        {
            User user = new(name,age,gender,birthday,weight,height);
            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, results))
            {
                foreach (var item in results)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            else { return user; }
            throw new ArgumentException("Неверно указаны параметры!");
        }
    }
}
