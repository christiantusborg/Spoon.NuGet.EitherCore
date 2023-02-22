namespace Spoon.NuGet.EitherCore.PipelineBehaviors;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Contracts;
using Enums;
using Exceptions;
using MediatR;

/// <summary>
/// Class EitherPipelineBehavior. This class cannot be inherited.
/// Implements the <see cref="IPipelineBehavior{TRequest,TResponse}" />.
/// </summary>
/// <typeparam name="TRequest">The type of the t request.</typeparam>
/// <typeparam name="TResponse">The type of the t response.</typeparam>
/// <seealso cref="IPipelineBehavior{TRequest, TResponse}" />
public sealed class EitherPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="next">The next.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>TResponse.</returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var responseResult = await next();

        if (typeof(TResponse).GetGenericTypeDefinition() != typeof(Either<>))
            return responseResult;

        var responseResultType = responseResult!.GetType();

        var eitherEnum = GetEitherEnum(responseResultType, responseResult);

        if (eitherEnum != EitherEnum.EitherError)
            return responseResult;

        var eitherError = GetEitherError(responseResultType, responseResult);

        var ext = new EitherException(
            request,
            eitherError.Origin,
            eitherError.Message,
            eitherError.StatusCode);

        var responseType = next.GetType();
        var responseInnerType = responseType.GetGenericArguments()[0];

        var result = (TResponse)Activator.CreateInstance(responseInnerType, ext) !;

        return result;
    }

    /// <summary>
    /// Gets the either error.
    /// </summary>
    /// <param name="resultType">Type of the result.</param>.
    /// <param name="result">The result.</param>
    /// <returns>EitherErrorMessage.</returns>
    private static EitherErrorMessage GetEitherError(IReflect resultType, [DisallowNull] TResponse result)
    {
        var eitherErrorField =
            resultType.GetField("EitherError", BindingFlags.NonPublic | BindingFlags.Instance);

        var eitherError = (EitherErrorMessage)eitherErrorField!.GetValue(result) !;
        return eitherError;
    }

    /// <summary>
    /// Gets the either enum.
    /// </summary>
    /// <param name="resultType">Type of the result.</param>
    /// <param name="result">The result.</param>
    /// <returns>EitherEnum.</returns>
    private static EitherEnum GetEitherEnum(IReflect resultType, [DisallowNull] TResponse result)
    {
        var eitherEnumField =
            resultType.GetField("EitherEnum", BindingFlags.NonPublic | BindingFlags.Instance);

        var eitherEnum = (EitherEnum)eitherEnumField!.GetValue(result) !;
        return eitherEnum;
    }
}