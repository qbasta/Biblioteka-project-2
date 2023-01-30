﻿using System.Collections.Generic;

namespace Biblioteka_project_2.ViewModels
{
    public class UserRolesViewModel
    {
        public int? UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
