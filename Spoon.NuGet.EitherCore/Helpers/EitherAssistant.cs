namespace Spoon.NuGet.EitherCore.Helpers;

using System.Diagnostics;
using Contracts;
using Enums;

/// <summary>
/// Class EitherAssistant.
/// </summary>
/// <typeparam name="T">Tyep of result.</typeparam>
public static class EitherHelper<T>
{
    /// <summary>
    /// Entities the not found.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Either&lt;T&gt;.</returns>
    public static Either<T> EntityNotFound(Type entity) =>
        Create($"Entity_{entity.Name}_NotFound", BaseHttpStatusCodes.Status404NotFound);

    /// <summary>
    /// Entities the already exists.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Either&lt;T&gt;.</returns>
    public static Either<T> EntityAlreadyExists(Type entity) =>
        Create($"Entity_{entity.Name}_AlreadyExists", BaseHttpStatusCodes.Status409Conflict);

    /// <summary>
    /// Administrators the role required.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Either&lt;T&gt;.</returns>
    public static Either<T> AdministratorRoleRequired(Type entity) =>
        Create($"AdministratorRoleRequired_{entity.Name}", BaseHttpStatusCodes.Status401Unauthorized);

    /// <summary>
    /// Bads the permissions.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Either&lt;T&gt;.</returns>
    public static Either<T> BadPermissions(Type entity) =>
        Create($"BadPermissions_{entity.Name}", BaseHttpStatusCodes.Status403Forbidden);

    /// <summary>
    /// Creates the specified message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="statusCodes">The status codes.</param>
    /// <returns>Either&lt;T&gt;.</returns>
    public static Either<T> Create(string message, BaseHttpStatusCodes statusCodes = BaseHttpStatusCodes.Status400BadRequest)
    {
        var callingMethod = new StackTrace()?.GetFrame(2)?.GetMethod()?.DeclaringType?.DeclaringType?.FullName ?? "Unknown";

        var eitherError = new EitherErrorMessage(message, callingMethod, statusCodes);
        var either = new Either<T>(eitherError);

        return either;
    }
}