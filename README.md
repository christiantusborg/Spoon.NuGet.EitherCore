# Spoon.NuGet.EitherCore

.NET, Convention exceptions into a Http Response instead of throwing the exception, When using MediatR, and IPipelineBehavior


## Program.cs:

                   builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EitherPipelineBehavior<,>));
 
## MediatR Handler:
### On Error:

                   if (product is null)
                   {
                   return EitherHelper<ProductDeleteCommandResult>.EntityNotFound(typeof(ProductDeleteCommand));
                   }

### On Suscess:
                    return new Either<ProductDeleteCommandResult>(result);

## MinimalApi :
                    var commandResult = await sender.Send(command, cancellationToken);
                    var contentResult = commandResult.ToActionResult<ProductDeleteResult>();





 
