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
        var expandoObjCollection = ExpandoObjCollection(eitherException);

        var httpStatusCode = GetHttpStatusCode(eitherException);

        var result = Results.Json(expandoObjCollection, null, null, httpStatusCode);

        return result;
    }

    /// <summary>
    /// Converts to icollection.
    /// </summary>
    /// <param name="eitherException">The either exception.</param>
    /// <returns>ICollection&lt;KeyValuePair&lt;System.String, System.Object&gt;&gt;.</returns>
    public static ICollection<KeyValuePair<string, object>> ToICollection(this EitherException eitherException)
    {
        var expandoObjCollection = ExpandoObjCollection(eitherException);
        return expandoObjCollection;
    }

    /// <summary>
    /// Expandoes the object collection.
    /// </summary>
    /// <param name="eitherException">The either exception.</param>
    /// <returns>ICollection&lt;KeyValuePair&lt;System.String, System.Object&gt;&gt;.</returns>
    private static ICollection<KeyValuePair<string, object>> ExpandoObjCollection(EitherException eitherException)
    {
        var expandoObj = new ExpandoObject();
        var expandoObjCollection = expandoObj as ICollection<KeyValuePair<string, object>>;
        foreach (var data in eitherException.Data)
        {
            var value = (DictionaryEntry)data;
            var key = (string)value.Key;
            expandoObjCollection.Add(new KeyValuePair<string, object>(key, value.Value!));
        }

        return expandoObjCollection;
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