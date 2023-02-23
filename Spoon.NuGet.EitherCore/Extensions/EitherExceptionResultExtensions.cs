namespace Spoon.NuGet.EitherCore.Extensions;

using System.Collections;
using System.Dynamic;
using Exceptions;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Class EitherExceptionToActionResultExtensions.
/// </summary>
public static class EitherExceptionResultExtensions
{
    /// <summary>
    /// Converts to actionresult.
    /// </summary>
    /// <param name="eitherException">The either exception.</param>
    /// <returns>IResult.</returns>
    public static IResult ToResult(this EitherException eitherException)
    {
        var expandoObjCollection = eitherException.ExpandoObjCollection();

        var httpStatusCode = GetHttpStatusCode(eitherException);

        var result = Results.Json(expandoObjCollection, null, null, httpStatusCode);

        return result;
    }

    /// <summary>
    /// Gets the HTTP status code.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>System.Int32.</returns>
    private static int GetHttpStatusCode(Exception exception)
    {
        var httpStatusCode = 500;
        if (exception.Data.Contains("HttpStatusCode"))
            httpStatusCode = (int)(exception.Data["HttpStatusCode"] ?? 500);
        return httpStatusCode;
    }
}