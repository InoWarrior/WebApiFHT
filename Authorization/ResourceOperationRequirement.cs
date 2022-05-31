using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace WebApiFHT.Authorization
{
    public enum ResourceOperaton
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class ResourceOperationRequirement : IAuthorizationRequirement
    {
        public ResourceOperationRequirement(ResourceOperaton resourceOperaton)
        {
            ResourceOperaton = resourceOperaton;
        }
        public ResourceOperaton ResourceOperaton { get; }
    }
}
