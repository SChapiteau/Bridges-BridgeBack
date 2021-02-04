using BridgeCore.Models;
using Bridges.Core.ServiceInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Bridges.Services.test
{
    [TestClass]
    public class AnnuaireTest
    {
        [TestMethod]
        public void Return_AllEntreprise_When_GetAll()
        {
            Mock<ICompanyRepository> entrepriseRepoMock = new Mock<ICompanyRepository>();
            entrepriseRepoMock.Setup(er => er.GetAll())
                .Returns(new List<Company>
            {
                new Company{SIRET = "123", Name="Entreprise 1"},
                new Company{SIRET = "222", Name="Entreprise 2"},
                new Company{SIRET = "333", Name="Entreprise 3"}
            }
            );

            CompanyService sut = new CompanyService(entrepriseRepoMock.Object);
            var listeEntreprise = sut.GetAll();

            Assert.AreEqual(3, listeEntreprise.Count());
        }
    }
}
