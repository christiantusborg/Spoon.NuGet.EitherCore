namespace Spoon.NuGet.EitherCore.Extensions;

using System.Collections;
using System.Dynamic;
using Exceptions;

/// <summary>
/// 
/// </summary>
public static class EitherExceptionExtensions
{
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
    public static ICollection<KeyValuePair<string, object>> ExpandoObjCollection(this EitherException eitherException)
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
}