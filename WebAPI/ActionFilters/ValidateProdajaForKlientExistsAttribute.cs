using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ActionFilters
{
    public class ValidateProdajaForKlientExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ValidateProdajaForKlientExistsAttribute(IRepositoryManager
       repository,
        ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
        ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ?
           true : false;
            var klientId = (Guid)context.ActionArguments["companyId"];
            var klient = await _repository.Klient.GetKlientAsync(klientId,
           false);
            if (klient == null)
            {
                _logger.LogInfo($"klient with id: {klientId} doesn't exist in the database.");
            return;
                context.Result = new NotFoundResult();
            }
            var id = (Guid)context.ActionArguments["id"];
            var prodaja = await _repository.Prodaja.GetProdajaAsync(klientId, id,
            trackChanges);
            if (prodaja == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
               
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("prodaja", prodaja);
                await next();
            }
        }
    }
}
