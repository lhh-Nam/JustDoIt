using JDI.Core.Application.Common.Interfaces;
using JDI.Models.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JDI.Handlers.User;

public class GetUserDetailHandler : IRequestHandler<UserDetailRequest, UserDetailResponse>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetUserDetailHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<UserDetailResponse> Handle(UserDetailRequest request, CancellationToken cancellationToken)
    {
        var user = await _applicationDbContext.Users.AsNoTracking()
            .Where(w => w.Id == request.Id)
            .Select(s => new UserDetailResponse
            {
                Id = s.Id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Address = s.Address
            }).FirstOrDefaultAsync(cancellationToken);

        return user;
    }
}