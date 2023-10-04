﻿using Loja_Games.Model;

namespace Loja_Games.Service
{
        public interface IUserService
        {
            Task<IEnumerable<User>> GetAll();

            Task<User?> GetById(long id);

            Task<User?> GetByUsuario(string usuario);

            Task<User?> Create(User usuario);

            Task<User?> Update(User usuario);
        }
    
}
