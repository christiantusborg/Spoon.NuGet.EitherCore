namespace Spoon.NuGet.EitherCore.Extensions;

using Enums;
using Mapster;
using Microsoft.AspNetCore.Http;

/// <summary>
/// </summary>
public static class EitherResultExtensions
{
/*
    /// <summary>
    ///     Converts to actionresult.
    /// </summary>
    /// <typeparam name="TResponse">The type of the t response.</typeparam>
    /// <param name="either"></param>
    /// <param name="noContent">if set to <c>true</c> [no content].</param>
    /// <returns>IResult.</returns>
    /// <exception cref="System.ArgumentNullException">Getinge.NuGet.EitherCore.Exceptions.ExceptionBase" + nameof(Success).</exception>
    public static IResult ToResult<TResponse>(this Either<TResponse> either, bool noContent = false)
    {
        if (either.EitherEnum != EitherEnum.Success)
            return either.GetFaulted().ToResult();

        if (noContent)
            return Results.NoContent();

        if (either.success is null)
            throw new ArgumentNullException("Getinge.NuGet.EitherCore.Exceptions.ExceptionBase" + nameof(either.success));

        var properties = typeof(TResponse).GetProperties();

        if (properties.Length > 0)
        {
            var response = either.success.Adapt<TResponse>();

            return Results.Ok(response);
        }

        var responseObject = Activator.CreateInstance(typeof(TResponse));

        return Results.Ok(responseObject);
    }
*/
    /// <summary>
    /// </summary>
    /// <param name="either"></param>
    /// <param name="type"></param>
    /// <param name="noContent"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IResult ToResult<TResponse>(this Either<TResponse> either, Type type, bool noContent = false)
    {
        if (either.EitherEnum != EitherEnum.Success)
            return either.GetFaulted().ToResult();

        if (noContent)
            return Results.NoContent();

        if (either.success is null)
            throw new ArgumentNullException("Getinge.NuGet.EitherCore.Exceptions.ExceptionBase" + nameof(either.success));

        var properties = typeof(TResponse).GetProperties();

        if (properties.Length > 0)
        {
            var responseTyped = Activator.CreateInstance(type);
            var response = either.success.Adapt(responseTyped);

            return Results.Ok(response);
        }

        var responseObject = Activator.CreateInstance(type);

        return Results.Ok(responseObject);
    }
}