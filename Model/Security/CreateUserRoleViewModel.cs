using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace appPrevencionRiesgos.Model.Security
{
    public class CreateUserRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}
