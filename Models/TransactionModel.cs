using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TransactionModel
    {
        public string MensajeResultado { get; set; }
        public bool Resultado { get; set; }

        public TransactionModel()
        {
            MensajeResultado = string.Empty;
            Resultado = false;
        }
    }
}
