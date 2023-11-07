global using Microsoft.VisualStudio.TestTools.UnitTesting;
using account;

namespace accountTests
{
    [TestClass]
    public class CompteTests
    {
        [TestMethod]
        public void TestDebit()
        {
            // arrange
            double montant = 5000;
            double account = 10000;
            double expected = 5000;
            Client client = new Client("123", "gruwe", "fred");
            Compte Compte = new Compte(account, client);

            // act
            Compte.Debiter(montant);

            // assert
            double actual = Compte.Solde;
            Assert.AreEqual(expected, actual, 0, "Account not correctly debited");

        }
    }
}