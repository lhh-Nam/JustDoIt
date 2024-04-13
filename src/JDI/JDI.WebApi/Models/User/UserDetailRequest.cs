using MediatR;

namespace JDI.Models.User;

public class UserDetailRequest : IRequest<UserDetailResponse>
{
    public int Id { get; init; }
}