using System;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Utils
{
    public static class ResponseBase
    {
        public static JsonResult Responder(bool sucesso, string msg, object data, string error = null)
        {
            return BigJson(new
            {
                message = msg ?? "",
                success = sucesso,
                data,
                error
            });
        }

        public static  JsonResult ResponderSucesso(object data)
        {
            return BigJson(new
            {
                message = "Sucesso",
                success = true,
                data = data
            });
        }
        
        public static  RespostaPadrao ResponderRequisicao(object data)
        {
            return new RespostaPadrao()
            {
                message = "Sucesso",
                success = true,
                data = data
            };
        }
        
        public static  JsonResult JsonGrid(object data, decimal qtdItens)
        {
            return ResponderSucesso(new
            {
                totalItems = qtdItens,
                items = data 
            });
        }
        
        public static JsonResult ResponderErro(string message)
        {
            return Responder(false, message, null);
        }
        
        public static JsonResult ResponderErro(Exception ex)
        {
            var msg = ex.Message;
            if (!string.IsNullOrWhiteSpace(ex.InnerException?.Message))
                msg += " / " + ex.InnerException;

            return Responder(false, msg,null);
        }
        
        public static JsonResult BigJson(object data)
        {
            return new JsonResult(data);
        } 
    }
}