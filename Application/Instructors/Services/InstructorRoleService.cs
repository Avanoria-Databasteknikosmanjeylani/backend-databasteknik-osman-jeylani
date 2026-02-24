using Application.Common.Results;
using Application.Instructors.Contracts;
using Application.Instructors.Inputs;
using Domain.Instructors;
using Domain.Instructors.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Instructors.Services;

public sealed class InstructorRoleService(IMemoryCache cache, IInstructorRoleRepository roleRepo) : IInstructorRoleService
{
    public Task<Result<InstructorRole?>> CreateInstructorRoleAsync(string roleName, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteInstructorRoleAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteInstructorRoleAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<InstructorRole?>> GetInstructorRoleByAsync(int id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IReadOnlyList<InstructorRole>>> GetInstructorRolesAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Result<InstructorRole?>> UpdateInstructorRoleByIdAsync(UpdateInstructorRoleInput input, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    private static class CacheKeys
    {
        public static string ById(string id) => $"instructorRoles:id:{id}";
        public static string ByRoleName(string roleName) => $"instructorRoles:roleName:{roleName}";
        public const string All = "instructorRoles:all";
    }

}