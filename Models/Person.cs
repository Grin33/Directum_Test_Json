using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Directum_Test_Json.Models
{
    public class Person
    {
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        public string MiddleName { get; set; }

        [Display(Name = "Дата Рождения")]
        [Required(ErrorMessage = "Поле обязательно к заполнению")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        public Person(string LastName, string FirstName, string MiddleName, DateOnly BirthDate)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.BirthDate = BirthDate;
        }
    }
}
