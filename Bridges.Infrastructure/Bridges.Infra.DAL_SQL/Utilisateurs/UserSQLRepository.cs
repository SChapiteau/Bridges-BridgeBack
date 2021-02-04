﻿using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using Dapper;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Bridges.Infra.DAL_SQL.Utilisateurs
{
    public class UserSQLRepository : SQLRepository, IUserRepository
    {
        public UserSQLRepository(IConfiguration iconfig) : base(iconfig)
        {

        }
        public void AddUser(User user)
        {
            using (var transaction = CurrentSession.BeginTransaction())
            {
                this.CurrentSession.Save(user);
                transaction.Commit();
            }
        }    
    

        public IEnumerable<User> GetAll()
        {
            return this.CurrentSession.Query<User>().ToList();
        }

        public User GetByPseudo(string pseudo)
        {
            throw new NotImplementedException();
        }

        public void ModifierUtilisateur(User utilisateur)
        {
            throw new NotImplementedException();
        }

        public void SupprimerUtilisateur(Guid utilisateurId)
        {
            throw new NotImplementedException();
        }
    }
}