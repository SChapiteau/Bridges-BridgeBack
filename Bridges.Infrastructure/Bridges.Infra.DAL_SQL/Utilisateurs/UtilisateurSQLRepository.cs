using Bridges.Core.Models;
using Bridges.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using Dapper;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Bridges.Infra.DAL_SQL.Utilisateurs
{
    public class UtilisateurSQLRepository : SQLRepository, IUtilisateurRepository
    {
        public UtilisateurSQLRepository(IConfiguration iconfig) : base(iconfig)
        {

        }
        public void AjoutUtilisateur(Utilisateur utilisateur)
        {
            //var sqlStatement = @"
            //    INSERT INTO Utilisateur 
            //    (Manufacturer
            //    ,Model
            //    ,RegistrationNumber
            //    ,FirstClassCapacity
            //    ,RegularClassCapacity
            //    ,CrewCapacity
            //    ,ManufactureDate
            //    ,NumberOfEngines
            //    ,EmptyWeight
            //    ,MaxTakeoffWeight)
            //    VALUES (@Manufacturer
            //    ,@Model
            //    ,@RegistrationNumber
            //    ,@FirstClassCapacity
            //    ,@RegularClassCapacity
            //    ,@CrewCapacity
            //    ,@ManufactureDate
            //    ,@NumberOfEngines
            //    ,@EmptyWeight
            //    ,@MaxTakeoffWeight)";

            //CurrentConnection.Execute(sqlStatement, utilisateur);

            string procedure = "UtilisateurAJout";
            CurrentConnection.Execute(procedure, utilisateur);

            //CurrentConnection. (sqlStatement, utilisateur);            
        }    
    

        public IEnumerable<Utilisateur> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utilisateur GetByPseudo(string pseudo)
        {
            throw new NotImplementedException();
        }

        public void ModifierUtilisateur(Utilisateur utilisateur)
        {
            throw new NotImplementedException();
        }

        public void SupprimerUtilisateur(Guid utilisateurId)
        {
            throw new NotImplementedException();
        }
    }
}
