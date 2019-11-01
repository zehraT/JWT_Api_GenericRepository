﻿using Exam.API.Interfaces;
using Exam.API.Models;
using System.Linq;

namespace Exam.API.Service
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        public bool FindByUser(string userName)
        {
            bool result = false;
            var user = _dataContext.Users.Where(x => x.username.Equals(userName));

            if (user != null)
            {
                result = true;
            }

            return result;
        }
    }
}
