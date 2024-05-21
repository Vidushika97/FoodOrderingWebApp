using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Dtos;


namespace Service
{
    public interface ITokenService
    {
        string CreateToken(AppUser user, string role);
    }
}