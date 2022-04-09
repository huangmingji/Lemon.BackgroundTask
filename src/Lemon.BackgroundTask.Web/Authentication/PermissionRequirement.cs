using Microsoft.AspNetCore.Authorization;

namespace Lemon.BackgroundTask.Web.Authentication
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
        
    }
}