using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    internal class Gender
    {
        /// <summary>
        /// Имя пола
        /// </summary>
        public string Name { get; init; }
        public Gender(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Валидация и проверка данных.
        /// </summary>
        /// <param name="validationContext">Контекст валидации</param>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
