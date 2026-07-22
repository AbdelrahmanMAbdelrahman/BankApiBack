using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BankApi.Errors
{
    public static class Problem
    {
        public static ObjectResult ToProblem(this Result result)
        {

            //var problem = Results.Problem(statusCode:result.error.statusCode);
            //Type type = problem.GetType();
            //PropertyInfo? property = type.GetProperty(nameof(ProblemDetails));
            //object? value = property!.GetValue(property);
            //ProblemDetails? details = value as ProblemDetails;
            //details!.Extensions = new Dictionary<string, object>()
            //{
            //    {
            //    "errors",new object[]
            //    {
            //        result.error.code,
            //        result.error.description
            //    }
            //    }
            //}!;
            var problem = Results.Problem(statusCode:result.error.statusCode);
            var problemDetails = problem.GetType().GetProperty(nameof(ProblemDetails)).GetValue(problem)as ProblemDetails ;
            //var details = new ProblemDetails()
            //{
            //    Title = result.error.description,
            //    Detail = result.error.description,
            //    Status = result.error.statusCode
            //};
            problemDetails.Extensions["code"] = result.error.code;
            return new ObjectResult(problemDetails);

        }
    }
}
