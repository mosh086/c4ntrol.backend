using C4.Domain.UseCases.Security;
using System.Security.Cryptography;

namespace C4.Application.UseCases.Security.Role.Repositories;

public interface IRoleClaimRepository : IBaseRepository<AppRoleClaimEntity, long> { }