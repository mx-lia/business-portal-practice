using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UsersApi.Dtos
{
    public class UsersByPageDto
    {
        public IEnumerable<User> Users { get; set; }
        public int CountOfPages { get; set; }
        public int CountOfRecords { get; set; }
    }
}
