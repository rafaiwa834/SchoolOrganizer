using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolOrganizer.Shared.Infrastructure.Validation;

public class ValidationFilter: IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errorsInModelState = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { Error = x.Key, Message = x.Value.Errors.Select(x => x.ErrorMessage) })
                .ToList();
            var errorsList = new List<dynamic>();
            foreach (var error in errorsInModelState)
            {
                foreach (var subError in error.Message)
                {
                    errorsList.Add(new {Error= error.Error, Message = subError});
                }
            }

            context.Result = new BadRequestObjectResult(errorsList);
            return;
        }
        
        await next();
    }
}