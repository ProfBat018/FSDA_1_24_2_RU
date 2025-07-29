namespace Auth.API.DTOs;

public record UpsertRoleRequestDto(string RoleName, string? RoleId=null);
