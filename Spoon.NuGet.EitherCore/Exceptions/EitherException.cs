namespace Spoon.NuGet.EitherCore.Exceptions;

using System;
using System.Collections.Generic;
using Enums;

/// <summary>
///     Class EitherException. This class cannot be inherited.
///     Implements the <see cref="System.Exception" />.
/// </summary>
/// <seealso cref="System.Exception" />
public sealed class EitherException : Exception
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="EitherException" /> class.
    /// </summary>
    /// <param name="commandValues">The command values.</param>
    /// <param name="origin">The origin.</param>
    /// <param name="message">The message.</param>
    /// <param name="statusCode">The status code.</param>
    public EitherException(object commandValues, string origin, string message, BaseHttpStatusCodes statusCode)
        : base(origin + "_" + message)
    {
        this.Data.Add("Command", commandValues.GetType().Name);
        this.Data.Add("CommandValues", commandValues);
        this.Data.Add("Origin", origin.Replace(".", "_"));
        this.Data.Add("HttpStatusCode", statusCode);
        this.Data.Add("Message", message);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="EitherException" /> class.
    /// </summary>
    /// <param name="commandValues">The command values.</param>
    /// <param name="origin">The origin.</param>
    /// <param name="message">The message.</param>
    /// <param name="statusCode">The status code.</param>
    /// <param name="generic">The generic.</param>
    public EitherException(object commandValues, string origin, string message, BaseHttpStatusCodes statusCode, Dictionary<string, object> generic)
        : base(origin + "_" + message)
    {
        this.Data.Add("Command", commandValues.GetType().Name);
        this.Data.Add("CommandValues", commandValues);
        this.Data.Add("Origin", origin.Replace(".", "_"));
        this.Data.Add("HttpStatusCode", statusCode);
        this.Data.Add("Message", message);

        foreach (var item in generic)
        {
            this.Data.Add(item.Key, item.Value);
        }
    }
}