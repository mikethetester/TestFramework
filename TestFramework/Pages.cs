using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace TestFramework
{
    public class Pages
    {
        public class HomePage : Pages
        {
            IWebDriver theHomepage; 

            public HomePage()
            {
                ChromeOptions theOptions = new ChromeOptions();

                theOptions.PageLoadStrategy = PageLoadStrategy.Default;
                //theOptions.AddAdditionalCapability("pageLoadStrategy", "none");                     
                //capabilities.SetCapability("pageLoadStrategy", "none");
                theHomepage = new ChromeDriver(theOptions);
                theHomepage.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30.0);
                theHomepage.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30.0);

            }
            
            public void GoTo()
            {                                                      
                theHomepage.Url = "https://roll20.net";
                waitForPageLoad();
                //IJavaScriptExecutor js = (IJavaScriptExecutor)theHomepage;
                //js.ExecuteScript("window.stop");
            }

            private void waitForPageLoad()
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)theHomepage;
                string documentState = (string)js.ExecuteScript("return window.document.readyState");
                while (!documentState.Equals("complete"))
                {
                    try
                    {}
                    catch(Exception theException)
                    {
                        js.ExecuteScript("window.stop");
                        break;
                    }
                }
            }

            public bool diceRollAppeared()
            {
                var newestDiceRoll = theHomepage.FindElements(By.XPath("//div[contains(@class, 'message') and contains(@class, 'rollresult')]"));
                if (newestDiceRoll.Last().Text.Contains("rolling"))
                {
                    return true;
                }
                else return false; 
                //throw new NotImplementedException();
            }

            public void createCharSheet()
            {
                var journalTab = theHomepage.FindElement(By.XPath("//a[contains(@href, '#journal')]"));
                journalTab.Click();
                var addButton = theHomepage.FindElement(By.XPath("//button[contains(@href, '#superjournaladd')]"));
                addButton.Click();
                var addCharacter = theHomepage.FindElement(By.XPath("//a[contains(@id, 'addnewcharacter')]"));
                addCharacter.Click();
                //throw new NotImplementedException();
            }

            public bool isLaunchSuccessful()
            {
                var NameTag = theHomepage.FindElement(By.XPath("//div[contains(@class, 'playername') and contains(@class, 'player-bookmark')]"));
                if (NameTag.Text.Equals("Mike T."))
                { return true;

                 }
                else
                {
                    return false;
                }
                //throw new NotImplementedException();
                
            }

            public bool IsAt()
            {
                if(theHomepage.Title.Equals("Roll20: Online virtual tabletop for pen and paper RPGs and board games"))
                { return true; }
                else
                { return false; }
            }

            public void closePage()
            {

                theHomepage.Close();
                theHomepage.Quit();
            }

            public bool signInSuccess()
            {
                var recentGames = theHomepage.FindElement(By.XPath("/html/body/div[2]/div/div[1]/h2"));
                if (recentGames.Text.Equals("Recent Games"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                //throw new NotImplementedException();
            }

            public void createGame()
            {
                //At the dashboard
                var createGameButton = theHomepage.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div[1]/a[1]"));
                createGameButton.Click();
                waitForPageLoad();

                //At the Create Game Page
                var gameName = theHomepage.FindElement(By.Name("campaign_name"));
                Random gameNumber = new System.Random();
                int value = gameNumber.Next(0, 10000);
                gameName.SendKeys("Test Game " + value.ToString());
                var readyCreate = theHomepage.FindElement(By.PartialLinkText("I'm ready,"));
                readyCreate.Click();
                waitForPageLoad();

                //throw new NotImplementedException();
            }

            public void rollDice()
            {
                var diceroller = theHomepage.FindElement(By.XPath("//li[contains(@id, 'diceroller')]"));
                diceroller.Click();
                var advanceRoll = theHomepage.FindElement(By.XPath("//button[contains(@class, 'rolladvanced')]"));
                advanceRoll.Click();

                //throw new NotImplementedException();
            }

            public void launchGame()
            {
                var theTestGame = theHomepage.FindElement(By.LinkText("The Test Game"));
                theTestGame.Click();
                waitForPageLoad();
                var launchButton = theHomepage.FindElement(By.PartialLinkText("Launch Game"));
                launchButton.Click();
                
                //throw new NotImplementedException();
            }

            public void joinTestGame()
            {
                var launchLink = theHomepage.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div[4]/div[2]/a[2]"));
                launchLink.Click();
                //throw new NotImplementedException();
            }

            public bool isGameCreated()
            {
                var userProfilePanel = theHomepage.FindElement(By.ClassName("userprofile"));
                if(userProfilePanel.Text.StartsWith("Mike T."))
                {
                    return true; 
                }
                else
                {
                    return false;
                }
            }

            public bool signOutSuccess()
            {
                
                if (theHomepage.Title.Equals("Login | Roll20: Online virtual tabletop"))
                {
                    return true;

                }
                else { return false; }

                //throw new NotImplementedException();
            }

            public void signOut()
            {
                
                var accountMenu = theHomepage.FindElement(By.Id("signin"));              
                accountMenu.Click();                                               
                var signOutButton = theHomepage.FindElement(By.LinkText("Sign Out"));
                //var wait = new WebDriverWait(theHomepage, new TimeSpan(5));
                //wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Sign Out")));
                Thread.Sleep(500);
                signOutButton.Click();
                waitForPageLoad();
            }

            public void signIn()
            {
                
                
                var signInButton = theHomepage.FindElement(By.Id("signin"));            
                signInButton.Click();      
                var emailText = theHomepage.FindElement(By.Name("email"));
                emailText.SendKeys("mikethetester500@hotmail.com");          
                var passwordText = theHomepage.FindElement(By.Name("password"));
                passwordText.SendKeys("ffff4444");
                passwordText.Submit();
                waitForPageLoad();


                // var formSignInButton = theHomepage.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[9]/div[2]/form/button"));
                //formSignInButton.Submit();
                //throw new NotImplementedException();
            }
        }
    }
}
