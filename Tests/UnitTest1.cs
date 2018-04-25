using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFramework;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_go_to_HomePage()
        {
            Pages.HomePage homepage = new Pages.HomePage();

            homepage.GoTo();
            Assert.IsTrue(homepage.IsAt());

        }

        [TestMethod]
        public void Can_log_in()
        {
            Pages.HomePage homepage = new Pages.HomePage();
            homepage.GoTo();
            //To do: Click on sign in
            homepage.signIn();
            Assert.IsTrue(homepage.signInSuccess());
            //To do: Enter credentials 
            homepage.closePage();


        }

        [TestMethod]
        public void Can_log_out()
        {
            Pages.HomePage homepage = new Pages.HomePage();
            homepage.GoTo();
            homepage.signIn();
            homepage.signOut();
            Assert.IsTrue(homepage.signOutSuccess());
            homepage.closePage();
        }

        [TestMethod]
        public void Can_Create_Game()
        {
            Pages.HomePage homepage = new Pages.HomePage();
            homepage.GoTo();
            homepage.signIn();
            homepage.createGame();
            Assert.IsTrue(homepage.isGameCreated());

        }

        [TestMethod]
        public void canollDice()
        {
            Pages.HomePage homepage = new Pages.HomePage();
            homepage.GoTo();
            homepage.signIn();
            homepage.launchGame();
            //homepage.launchGame();
            homepage.rollDice();
            Assert.IsTrue(homepage.diceRollAppeared());

        }

        [TestMethod]
        public void canLaunchGame()
        {
            Pages.HomePage homepage = new Pages.HomePage();
            homepage.GoTo();
            homepage.signIn();
            homepage.launchGame();
            homepage.isLaunchSuccessful();
        }

        [TestMethod]
        public void canCreateCharactersheet()
        {
            Pages.HomePage homepage = new Pages.HomePage();
            homepage.GoTo();
            homepage.signIn();
            homepage.launchGame();
            homepage.createCharSheet();
        }
    }
}
