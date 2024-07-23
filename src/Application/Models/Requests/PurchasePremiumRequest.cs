using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requests
{
    public class PurchasePremiumRequest
    {
        [Required(ErrorMessage = "El nombre del titular de la tarjeta es obligatorio.")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "El número de tarjeta es obligatorio.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "El CVV es obligatorio.")]
        public string CVV { get; set; }
    }
}
