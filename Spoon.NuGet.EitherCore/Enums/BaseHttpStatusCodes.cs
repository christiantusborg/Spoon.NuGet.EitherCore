namespace Spoon.NuGet.EitherCore.Enums;

/// <summary>
/// Enum BaseHttpStatusCodes.
/// </summary>
public enum BaseHttpStatusCodes
{
    /// <summary>
    /// The status100 continue.
    /// </summary>
    Status100Continue = 100,

    /// <summary>
    /// The status101 switching protocols.
    /// </summary>
    Status101SwitchingProtocols = 101,

    /// <summary>
    /// The status102 processing.
    /// </summary>
    Status102Processing = 102,

    /// <summary>
    /// The status200 ok.
    /// </summary>
    Status200OK = 200,

    /// <summary>
    /// The status201 created.
    /// </summary>
    Status201Created = 201,

    /// <summary>
    /// The status202 accepted.
    /// </summary>
    Status202Accepted = 202,

    /// <summary>
    /// The status203 non authoritative.
    /// </summary>
    Status203NonAuthoritative = 203,

    /// <summary>
    /// The status204 no content.
    /// </summary>
    Status204NoContent = 204,

    /// <summary>
    /// The status205 reset content.
    /// </summary>
    Status205ResetContent = 205,

    /// <summary>
    /// The status206 partial content.
    /// </summary>
    Status206PartialContent = 206,

    /// <summary>
    /// The status207 multi status.
    /// </summary>
    Status207MultiStatus = 207,

    /// <summary>
    /// The status208 already reported.
    /// </summary>
    Status208AlreadyReported = 208,

    /// <summary>
    /// The status226 im used.
    /// </summary>
    Status226IMUsed = 226,

    /// <summary>
    /// The status300 multiple choices.
    /// </summary>
    Status300MultipleChoices = 300,

    /// <summary>
    /// The status301 moved permanently.
    /// </summary>
    Status301MovedPermanently = 301,

    /// <summary>
    /// The status302 found.
    /// </summary>
    Status302Found = 302,

    /// <summary>
    /// The status303 see other.
    /// </summary>
    Status303SeeOther = 303,

    /// <summary>
    /// The status304 not modified.
    /// </summary>
    Status304NotModified = 304,

    /// <summary>
    /// The status305 use proxy.
    /// </summary>
    Status305UseProxy = 305,

    /// <summary>
    /// The status306 switch proxy.
    /// </summary>
    Status306SwitchProxy = 306,

    /// <summary>
    /// The status307 temporary redirect.
    /// </summary>
    Status307TemporaryRedirect = 307,

    /// <summary>
    /// The status308 permanent redirect.
    /// </summary>
    Status308PermanentRedirect = 308,

    /// <summary>
    /// The status400 bad request.
    /// </summary>
    Status400BadRequest = 400,

    /// <summary>
    /// The status401 unauthorized.
    /// </summary>
    Status401Unauthorized = 401,

    /// <summary>
    /// The status402 payment required.
    /// </summary>
    Status402PaymentRequired = 402,

    /// <summary>
    /// The status403 forbidden.
    /// </summary>
    Status403Forbidden = 403,

    /// <summary>
    /// The status404 not found.
    /// </summary>
    Status404NotFound = 404,

    /// <summary>
    /// The status405 method not allowed.
    /// </summary>
    Status405MethodNotAllowed = 405,

    /// <summary>
    /// The status406 not acceptable.
    /// </summary>
    Status406NotAcceptable = 406,

    /// <summary>
    /// The status407 proxy authentication required.
    /// </summary>
    Status407ProxyAuthenticationRequired = 407,

    /// <summary>
    /// The status408 request timeout.
    /// </summary>
    Status408RequestTimeout = 408,

    /// <summary>
    /// The status409 conflict.
    /// </summary>
    Status409Conflict = 409,

    /// <summary>
    /// The status410 gone.
    /// </summary>
    Status410Gone = 410,

    /// <summary>
    /// The status411 length required.
    /// </summary>
    Status411LengthRequired = 411,

    /// <summary>
    /// The status412 precondition failed.
    /// </summary>
    Status412PreconditionFailed = 412,

    /// <summary>
    /// The status413 request entity too large.
    /// </summary>
    Status413RequestEntityTooLarge = 413,

    /// <summary>
    /// The status413 payload too large.
    /// </summary>
    Status413PayloadTooLarge = 413,

    /// <summary>
    /// The status414 request URI too long.
    /// </summary>
    Status414RequestUriTooLong = 414,

    /// <summary>
    /// The status414 URI too long.
    /// </summary>
    Status414UriTooLong = 414,

    /// <summary>
    /// The status415 unsupported media type.
    /// </summary>
    Status415UnsupportedMediaType = 415,

    /// <summary>
    /// The status416 requested range not satisfiable.
    /// </summary>
    Status416RequestedRangeNotSatisfiable = 416,

    /// <summary>
    /// The status416 range not satisfiable.
    /// </summary>
    Status416RangeNotSatisfiable = 416,

    /// <summary>
    /// The status417 expectation failed.
    /// </summary>
    Status417ExpectationFailed = 417,

    /// <summary>
    /// The status418 im a teapot.
    /// </summary>
    Status418ImATeapot = 418,

    /// <summary>
    /// The status419 authentication timeout.
    /// </summary>
    Status419AuthenticationTimeout = 419,

    /// <summary>
    /// The status421 misdirected request.
    /// </summary>
    Status421MisdirectedRequest = 421,

    /// <summary>
    /// The status422 unprocessable entity.
    /// </summary>
    Status422UnprocessableEntity = 422,

    /// <summary>
    /// The status423 locked.
    /// </summary>
    Status423Locked = 423,

    /// <summary>
    /// The status424 failed dependency.
    /// </summary>
    Status424FailedDependency = 424,

    /// <summary>
    /// The status426 upgrade required.
    /// </summary>
    Status426UpgradeRequired = 426,

    /// <summary>
    /// The status428 precondition required.
    /// </summary>
    Status428PreconditionRequired = 428,

    /// <summary>
    /// The status429 too many requests.
    /// </summary>
    Status429TooManyRequests = 429,

    /// <summary>
    /// The status431 request header fields too large.
    /// </summary>
    Status431RequestHeaderFieldsTooLarge = 431,

    /// <summary>
    /// The status451 unavailable for legal reasons.
    /// </summary>
    Status451UnavailableForLegalReasons = 451,

    /// <summary>
    /// The status498 invalid token.
    /// </summary>
    Status498InvalidToken = 498,

    /// <summary>
    /// The status499 token required.
    /// </summary>
    Status499TokenRequired = 499,

    /// <summary>
    /// The status500 internal server error.
    /// </summary>
    Status500InternalServerError = 500,

    /// <summary>
    /// The status501 not implemented.
    /// </summary>
    Status501NotImplemented = 501,

    /// <summary>
    /// The status502 bad gateway.
    /// </summary>
    Status502BadGateway = 502,

    /// <summary>
    /// The status503 service unavailable.
    /// </summary>
    Status503ServiceUnavailable = 503,

    /// <summary>
    /// The status504 gateway timeout.
    /// </summary>
    Status504GatewayTimeout = 504,

    /// <summary>
    /// The status505 HTTP version notsupported.
    /// </summary>
    Status505HttpVersionNotsupported = 505,

    /// <summary>
    /// The status506 variant also negotiates.
    /// </summary>
    Status506VariantAlsoNegotiates = 506,

    /// <summary>
    /// The status507 insufficient storage.
    /// </summary>
    Status507InsufficientStorage = 507,

    /// <summary>
    /// The status508 loop detected.
    /// </summary>
    Status508LoopDetected = 508,

    /// <summary>
    /// The status510 not extended.
    /// </summary>
    Status510NotExtended = 510,

    /// <summary>
    /// The status511 network authentication required.
    /// </summary>
    Status511NetworkAuthenticationRequired = 511,
}