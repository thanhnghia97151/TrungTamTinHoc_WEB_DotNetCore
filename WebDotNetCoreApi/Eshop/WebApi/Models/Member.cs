﻿namespace WebApi.Models
{
    public class Member
    {
        public string? MemberId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public IEnumerable<string>? Roles { get; set; }

    }
}
