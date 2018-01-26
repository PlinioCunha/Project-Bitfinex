using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Base
{
    public class BaseController : Controller
    {

        protected JsonResult RetornaErroValidacao(ModelStateDictionary modelState)
        {
            List<string> retornoErros = new List<string>();
            IEnumerable<ModelError> allErrors = modelState.Values.SelectMany(v => v.Errors);
            foreach (var item in allErrors)
                retornoErros.Add(item.ErrorMessage);

            Response.StatusCode = 500;
            //Response.ContentType = "application/json";

            return Json(retornoErros);
        }

        private JsonResult Json(List<string> retornoErros, string v, object allowGet)
        {
            throw new NotImplementedException();
        }

        protected JsonResult RetornaErroValidacao(string[] Mensagens)
        {
            Response.StatusCode = 500;
            //Response.ContentType = "application/json";
            return Json(Mensagens);
        }
        protected JsonResult RetornaErroValidacao(string Mensagens)
        {
            Response.StatusCode = 500;
            return Json(Mensagens);
        }

    }
}
