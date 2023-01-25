using Microsoft.AspNetCore.Authorization;

namespace InnoClinic.AppointmentsAPI.Attributes
{
    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
