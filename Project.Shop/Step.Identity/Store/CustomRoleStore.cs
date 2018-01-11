using Microsoft.AspNet.Identity.EntityFramework;
using Step.Identity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step.Identity.Store
{
    public class CustomRoleStore : RoleStore<AppRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
