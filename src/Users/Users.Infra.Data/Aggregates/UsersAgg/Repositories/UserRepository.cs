namespace Bmg.Desafio.Users.Infra.Data.Aggregates.UsersAgg.Repositories;

using Core.Infra.Data.Repositories;
using Context;
using Domain.Aggregates.UsersAgg.Entities;
using Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Repositories;

	public partial class UserRepository : Repository<User>, IUserRepository { public UserRepository(UsersAggContext ctx) : base(ctx) { } }

