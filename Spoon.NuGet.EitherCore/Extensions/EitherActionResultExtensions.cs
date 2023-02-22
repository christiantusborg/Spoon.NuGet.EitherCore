namespace Spoon.NuGet.EitherCore.Extensions;

using System;
using Enums;
using Mapster;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// </summary>
public static class EitherActionResultExtensions
{
    /// <summary>
    ///     Converts to actionresult.
    /// </summary>
    /// <typeparam name="TResponse">The type of the t response.</typeparam>
    /// <param name="either"></param>
    /// <param name="noContent">if set to <c>true</c> [no content].</param>
    /// <returns>IResult.</returns>
    /// <exception cref="System.ArgumentNullException">Getinge.NuGet.EitherCore.Exceptions.ExceptionBase" + nameof(Success).</exception>
    public static IActionResult ToActionResult<TResponse>(this Either<TResponse> either, bool noContent = false)
    {
        if (either.EitherEnum != EitherEnum.Success)
            return either.GetFaulted().ToActionResult();

        if (noContent)
            return new NoContentResult();

        if (either.success is null)
            throw new ArgumentNullException("SilverSpoon.NuGet.Basic.Exceptions.ExceptionBase" + nameof(either.success));

        var x = typeof(TResponse).GetProperties();


        if (x.Length > 0)
        {
            var response = either.success.Adapt<TResponse>();


            var successResult = new ObjectResult(200)
            {
                StatusCode = 200,
                Value = response,
            };
            return successResult;
        }

        var xxx = Activator.CreateInstance(typeof(TResponse));
        return new ObjectResult(200)
        {
            StatusCode = 200,
            Value = xxx,
        };
    }
}