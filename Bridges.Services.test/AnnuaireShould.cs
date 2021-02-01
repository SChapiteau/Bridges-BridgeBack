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
            Mock<IEntrepriseRepository> entrepriseRepoMock = new Mock<IEntrepriseRepository>();
            entrepriseRepoMock.Setup(er => er.GetAll())
                .Returns(new List<Entreprise>
            {
                new Entreprise{SIRET = "123", Nom="Entreprise 1"},
                new Entreprise{SIRET = "222", Nom="Entreprise 2"},
                new Entreprise{SIRET = "333", Nom="Entreprise 3"}
            }
            );

            Annuaire sut = new Annuaire(entrepriseRepoMock.Object);
            var listeEntreprise = sut.GetAll();

            Assert.AreEqual(3, listeEntreprise.Count());
        }
    }
}
