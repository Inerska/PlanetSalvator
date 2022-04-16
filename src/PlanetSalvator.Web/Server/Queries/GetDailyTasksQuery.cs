namespace PlanetSalvator.Web.Server.Queries;

using MediatR;

public record GetDailyTasksQuery(int tasksCount) : IRequest<IEnumerable<string>>;