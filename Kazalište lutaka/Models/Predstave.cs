using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kazalište_lutaka.Models
{
    public class Predstave
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        public string Trajanje { get; set; }
        public string Uzrast { get; set; }



    }
}
