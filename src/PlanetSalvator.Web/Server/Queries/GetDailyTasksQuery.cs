namespace PlanetSalvator.Web.Server.Queries;

using MediatR;

public record GetDailyTasksQuery(int TasksCount) : IRequest<IEnumerable<string>>;