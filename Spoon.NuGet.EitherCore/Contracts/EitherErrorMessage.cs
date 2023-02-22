namespace Spoon.NuGet.EitherCore.Contracts;

using Enums;

/// <summary>
/// Struct EitherErrorMessage.
/// </summary>
public struct EitherErrorMessage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EitherErrorMessage"/> struct.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="origin">The origin.</param>
    /// <param name="statusCode">The status code.</param>
    public EitherErrorMessage(string message, string origin, BaseHttpStatusCodes statusCode)
    {
        this.Message = message;
        this.Origin = origin;
        this.StatusCode = statusCode;
    }

    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <value>The message.</value>
    public string Message { get; }

    /// <summary>
    /// Gets the origin.
    /// </summary>
    /// <value>The origin.</value>
    public string Origin { get; }

    /// <summary>
    /// Gets the status code.
    /// </summary>
    /// <value>The status code.</value>
    public BaseHttpStatusCodes StatusCode { get; }
}