namespace Bmg.Desafio.Users.Domain.Aggregates.UsersAgg.Commands;

using CrossCutting.Infra.Log.Contexts;
using Core.Domain.Aggregates.CommonAgg.Commands;
using Queries.Models; 
using Bmg.Desafio.Users.Application.DTO.Aggregates.UsersAgg.Requests; 
    public partial class CreateUserCommand : BaseRequestableCommand<UserQueryModel, UserDTO>
    {
        public bool UpdateIfExists { get; set; }
        public CreateUserCommand(ILogRequestContext ctx, UserDTO data, bool updateIfExists = true, UserQueryModel query = null) 
            : base(ctx, query, data) { this.UpdateIfExists = updateIfExists; }
    }
    public partial class DeleteUserCommand : BaseDeletionCommand<UserQueryModel>
    {
        public DeleteUserCommand(ILogRequestContext ctx, UserQueryModel query, bool isLogicalDeletion = true)
            : base(ctx, query, isLogicalDeletion) { }
    }
      public partial class DeleteRangeUserCommand : BaseDeletionCommand<UserQueryModel>
    {
        public DeleteRangeUserCommand(ILogRequestContext ctx, UserQueryModel query, bool isLogicalDeletion = true)
            : base(ctx, query, isLogicalDeletion) { }
    }
    public partial class UpdateRangeUserCommand : BaseRequestableRangeCommand<UserQueryModel, UserDTO>
    {
        public bool CreateIfNotExists { get; set; } = true;
        public UpdateRangeUserCommand(ILogRequestContext ctx, Dictionary<UserQueryModel, UserDTO> query)
            : base(ctx, query) { }
        public UpdateRangeUserCommand(ILogRequestContext ctx, UserQueryModel query, UserDTO data)
            : base(ctx, new Dictionary<UserQueryModel, UserDTO> { { query, data } }) { }
    }
    
    public partial class UpdateUserCommand : BaseRequestableCommand<UserQueryModel, UserDTO>
    {
        public bool CreateIfNotExists { get; set; } = true;
        public UpdateUserCommand(ILogRequestContext ctx, UserQueryModel query, UserDTO data, bool createIfNotExists = true)
            : base(ctx, query, data) { this.CreateIfNotExists = createIfNotExists; }
    }
    public partial class ActiveUserCommand : UserSearchableCommand
    {
        public ActiveUserCommand(ILogRequestContext ctx, UserQueryModel query)
            : base(ctx, query) { }
    }
    public partial class DeactiveUserCommand : UserSearchableCommand
    {
        public DeactiveUserCommand(ILogRequestContext ctx, UserQueryModel query)
            : base(ctx, query) { }
    }
    public class UserSearchableCommand : BaseSearchableCommand<UserQueryModel> {
        public UserSearchableCommand(ILogRequestContext ctx, UserQueryModel query)
            : base(ctx, query) { }
    }
