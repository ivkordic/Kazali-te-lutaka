using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kazalište_lutaka.Models
{
    public class Raspored
    {
        public int Id { get; set; }
        [Display(Name = "Datum i vrijeme izvođenja predstave")]
        public DateTime DatPredstave { get; set; }
        [Display(Name = "Naziv predstave")]
        public int PredstaveId { get; set; }
        public Predstave Predstave { get; set; }
    }
}
