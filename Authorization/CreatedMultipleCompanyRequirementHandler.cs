using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using WebApiFHT.Entities;
using System.Security.Claims;

namespace WebApiFHT.Authorization
{
    public class CreatedMultipleCompanyRequirementHandler : AuthorizationHandler<CreatedMultipleCompanyRequirement>
    {
        private readonly FHTDbContext _context;
        public CreatedMultipleCompanyRequirementHandler(FHTDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CreatedMultipleCompanyRequirement requirement)
        {
            var UserId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var createdCompanyCount = _context.Company.Count(r => r.CreatedById == UserId);

            if(createdCompanyCount >= requirement.MinimumCompanyCreated)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }

        
    }
}
