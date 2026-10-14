using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
	public class Student
	{
		public int ID { get; set; }
		[Required]
		[DisplayName("Фамилия")]
		public string LastName { get; set; }

		[Required]
		[DisplayName("Имя")]
		public string FirstName { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		[Display(Name = "Дата поступления")]
		public DateTime EnrollmentDate { get; set; }

		//Calculated properties:
		[Display(Name = "Студент")]
		public string FullName
		{
			get => $"{LastName} {FirstName}";
		}

		//Navigation properties:
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}
