using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательным")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "В фамилии должно быть от 2 до 100 символов")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Отчетсво является обязательным")]      
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст является обязательным")]     
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Должность является обязательной")]    
        [Display(Name = "Должность")]
        public string Position { get; set; }

    }
}
