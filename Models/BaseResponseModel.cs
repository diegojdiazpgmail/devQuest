using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class BaseResponseModel<T> where T : class
    {
        [JsonPropertyName("IsExito")]
        public bool IsExito { get; set; }

        [JsonPropertyName("Codigo")]
        public int Codigo { get; set; }

        [JsonPropertyName("MensajeError")]
        public string MensajeError { get; set; }

        [JsonPropertyName("ListaErrorValidacion")]
        public List<string> ListaErrorValidacion { get; set; }

        [JsonPropertyName("Objeto")]
        public T Objeto { get; set; }

        public BaseResponseModel()
        {
            IsExito = false;
            Codigo = 0;
            MensajeError = null;
            ListaErrorValidacion = new List<string>();
            Objeto = null;
        }

        public BaseResponseModel(T respuesta)
        {
            IsExito = true;
            Codigo = (int)HttpStatusCode.OK;
            MensajeError = null;
            ListaErrorValidacion = new List<string>();
            Objeto = respuesta;
        }

        //public BaseResponseModel(ModelStateDictionary modelState)
        //{
        //    IsExito = false;
        //    Codigo = (int)HttpStatusCode.UnprocessableEntity;
        //    MensajeError = "Se encontraron errores de validación";
        //    ListaErrorValidacion = (from state in modelState.Values
        //                            from error in state.Errors
        //                            select error.ErrorMessage)
        //                            .ToList();
        //    Objeto = null;
        //}
    }
}
