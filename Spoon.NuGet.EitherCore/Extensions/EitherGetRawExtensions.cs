namespace Spoon.NuGet.EitherCore.Extensions;

using Enums;
using Mapster;
using Microsoft.AspNetCore.Http;

/// <summary>
/// </summary>
public static class EitherGetRawExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="either"></param>
    /// <param name="responseRaw"></param>
    /// <param name="iResult"></param>
    /// <typeparam name="TResponse"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool TryGetResponseRaw<TResponse>(this Either<TResponse> either, out TResponse? responseRaw, out IResult? iResult )
    {
        if (either.EitherEnum != EitherEnum.Success)
        {
            iResult = either.GetFaulted().ToResult();
            responseRaw = default;
            return false;
        }

        if (either.success is null)
            throw new ArgumentNullException("Getinge.NuGet.EitherCore.Exceptions.ExceptionBase" + nameof(either.success));

        responseRaw = either.success;
        iResult = null;
        return true;

    }    
}