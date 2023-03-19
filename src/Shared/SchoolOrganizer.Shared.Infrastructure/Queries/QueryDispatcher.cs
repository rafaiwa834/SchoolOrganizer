using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Shared.Abstractions.Queries;

namespace SchoolOrganizer.Shared.Infrastructure.Queries;

public class QueryDispatcher: IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;


    public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
    {
        using var scope = _serviceProvider.CreateScope();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
        var handler = scope.ServiceProvider.GetRequiredService(handlerType);

        return await (Task<TResult>) handlerType
            .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
            ?.Invoke(handler, new object[] {query, cancellationToken});
    }
}