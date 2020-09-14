using BridgeCore.Entreprise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Bridges.Services.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllTest()
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
