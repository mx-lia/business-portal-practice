﻿
namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GetUserName();

        int GetUserId();

        string AppendSecurityToken();
    }
}
