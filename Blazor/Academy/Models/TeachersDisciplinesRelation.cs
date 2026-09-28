using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Academy.Models
{
    [PrimaryKey("teacher","discipline")]
    public class TeachersDisciplinesRelation
    {
        [ForeignKey(nameof(Teacher))]
        [Column("teacher", TypeName = "smallint")]
        public int teacher { get; set; }

        [ForeignKey(nameof(Discipline))]
        [Column("discipline", TypeName = "smallint")]
        public int discipline { get; set; }

        //naviprops

        public Teacher Teacher { get; set; }
        public Discipline Discipline { get; set; }


    }
}
