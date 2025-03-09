using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain.Entities;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Infra.Context;

namespace UserAPI.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public User Get(string email)
        {
            //return _appDbContext.User
            //    .Where(x => x.Email.Equals(email))
            //    .FirstOrDefault();

            var sql = @"SELECT * FROM [USER] 
                        WHERE EMAIL = @email
                        ORDER BY NAME";

            return _appDbContext.Database.GetDbConnection().Query<User>(sql, new {email}).FirstOrDefault();
        }

        public User Get(string email, string password)
        {
            var sql = @"
                SELECT * FROM [USER]
                WHERE EMAIL = @email
                and PASSWORD = @password
                ORDER BY NAME
                ";

            return _appDbContext.Database.GetDbConnection().Query<User>(sql, new { email, password }).FirstOrDefault();
        }
    }
}
