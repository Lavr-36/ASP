using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql.Internal.Postgres;

namespace Academy.Models
{
    public class Teacher:Human
    {
        [Key]
        [Column("teacher_id", TypeName = "smallint")]
        public int teacher_id { get; set; }

        public DateOnly work_since { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName = "numeric(10,4)")]
        public decimal rate { get; set; }

        //naviprop



    }
}
