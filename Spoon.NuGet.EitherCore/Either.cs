namespace Spoon.NuGet.EitherCore;

using Contracts;
using Enums;
using Exceptions;

/// <summary>
/// Class Either.
/// </summary>
/// <typeparam name="TSuccess">The type of the t success.</typeparam>
public class Either<TSuccess>
{
    /// <summary>
    /// The either enum.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "We need use this reflection in Piplines")]
    internal readonly EitherEnum EitherEnum = EitherEnum.None;

    /// <summary>
    /// The faulted.
    /// </summary>
    private readonly EitherException? faulted = null;

    /// <summary>
    /// The success.
    /// </summary>
    internal readonly TSuccess? success = default;

    /// <summary>
    /// The either error.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:Elements should be ordered by access", Justification = "We need use this reflection in Piplines")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "We need use this reflection in Piplines")]
    internal readonly EitherErrorMessage? EitherError = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TSuccess}"/> class.
    /// </summary>
    /// <param name="eitherException">The either exception.</param>
    public Either(EitherException eitherException)
    {
        this.faulted = eitherException;

        this.EitherEnum = EitherEnum.IsFaulted;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TSuccess}"/> class.
    /// </summary>
    /// <param name="eitherError">The either error.</param>
    public Either(EitherErrorMessage eitherError)
    {
        this.EitherError = eitherError;
        this.EitherEnum = EitherEnum.EitherError;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TSuccess}"/> class.
    /// </summary>
    /// <param name="success">The success.</param>
    public Either(TSuccess? success)
    {
        this.success = success;
        this.EitherEnum = EitherEnum.Success;
    }

    /// <summary>
    /// Matches the specified faulted.
    /// </summary>
    /// <typeparam name="T">Type of result.</typeparam>
    /// <param name="faulted">The faulted.</param>
    /// <param name="success">The success.</param>
    /// <returns>T.</returns>
    public T Match<T>(Func<EitherException, T> faulted, Func<TSuccess, T> success)
    {
        return this.EitherEnum == EitherEnum.Success ? success(this.success!) : faulted(this.GetFaulted());
    }

    /// <summary>
    /// Gets the faulted.
    /// </summary>
    /// <returns>EitherException.</returns>
    /// <exception cref="System.ArgumentNullException">Getinge.NuGet.EitherCore.Exceptions.ExceptionBase EitherError->IsNull.</exception>
    /// <exception cref="System.ArgumentOutOfRangeException">When EitherError is null. SHOULD NEVER HAPPEN.</exception>
    internal EitherException GetFaulted()
    {
        switch (this.EitherEnum)
        {
            case EitherEnum.IsFaulted:
                return this.faulted!;
            case EitherEnum.EitherError:
                if (this.EitherError is null)
                    throw new ArgumentNullException("Getinge.NuGet.EitherCore.Exceptions.ExceptionBase EitherError->IsNull");
                return new EitherException(
                    string.Empty,
                    this.EitherError.Value.Origin,
                    this.EitherError.Value.Message,
                    this.EitherError.Value.StatusCode);
            case EitherEnum.Success:
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}