using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuseDeskApi.Models
{
    public class ApiFilter
    {
        [Required(ErrorMessage = "AppName é obrigatório")]
        public string AppName { get; set; }
        [Required(ErrorMessage = "ApiKey é obrigatório")]
        public string ApiKey { get; set; }
        [Display(Name = "Abertos depois de:")]
        public DateTime? OpenAfterFilter { get; set; }
        [Display(Name = "Abertos antes de:")]
        public DateTime? OpenBeforeFilter { get; set; }
        [Display(Name = "Fechados depois de:")]
        public DateTime? ClosedAfterFilter { get; set; }
        [Display(Name = "Fechados antes de:")]
        public DateTime? ClosedBeforeFilter { get; set; }
        [Display(Name = "Quantidade:")]
        [Required(ErrorMessage = "Quantidade é obrigatório")]
        public int Limit { get; set; }
        [Display(Name = "Status" )]
        public string Status { get; set; }
    }
}
