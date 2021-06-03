using BasicFramework.Framework;
using BasicFramework.Framework.Models;
using BasicFramework.Pages;
using ChallengeTenFramework.Framework;
using NUnit.Framework;

namespace BasicFramework.Tests
{
    [TestFixture]
    public class ChallengesTests : BaseTest
    {
        [Test, TestCaseSource(typeof(TestCaseDataSource), "AllUsers")]
        public void ChallengeTenOneByOneUserTest(User testUser)
        {
            UITest(() =>
            {
                Logger.Info($"Register new user {testUser.FirstName} {testUser.LastName}.");
                ChallengeTenPage challengeTenPage = SiteNavigator
                    .NavigateToChallengeTenPage(Driver)
                    .RegisterNewUser(testUser);

                Logger.Info($"Validate user first name: {testUser.FirstName} and last name: {testUser.LastName} in the table.");

                Assert.Multiple(() =>
                {
                    Assert.AreEqual(challengeTenPage.GetUserLoginByUserName(testUser.Login).Text, testUser.Login, "Wrong UserName/Login!");
                    Assert.AreEqual(challengeTenPage.GetUserPasswordByUserName(testUser.Login).Text, testUser.Password, "Wrong Password!");
                    Assert.AreEqual(challengeTenPage.GetUserFirstNameByUserName(testUser.Login).Text, testUser.FirstName, "Wrong First Name!");
                    Assert.AreEqual(challengeTenPage.GetUserLastNameByUserName(testUser.Login).Text, testUser.LastName, "Wrong Last Name!");
                });

                Logger.Info("Open Login page in new browser tab.");
                var loginPage = challengeTenPage.OpenLoginPageNewTab();

                Logger.Info($"Log-in as user first name: {testUser.FirstName} and last name: {testUser.LastName}.");
                var welcomePage = loginPage.Login(testUser);

                Logger.Info("Verify welcome message.");
                Assert.AreEqual("Wellcome To Your Personal Road Assitance", welcomePage.WelcomeMessage.Text, "Wrong message!");
            });
        }

        [Test]
        public void ChallengeTenAllUsersTest()
        {
            UITest(() =>
            {
                var usersList = Utils.GetUsersFromCSV();
                ChallengeTenPage challengeTenPage = SiteNavigator
                    .NavigateToChallengeTenPage(Driver);

                foreach (var testUser in usersList)
                {
                    Logger.Info($"Register new user {testUser.FirstName} {testUser.LastName}.");
                    challengeTenPage.RegisterNewUser(testUser);
                }

                foreach (var testUser in usersList)
                {
                    Logger.Info($"Validate user first name: {testUser.FirstName} and last name: {testUser.LastName} in the table.");

                    Assert.Multiple(() =>
                    {
                        Assert.AreEqual(challengeTenPage.GetUserLoginByUserName(testUser.Login).Text, testUser.Login, "Wrong UserName/Login!");
                        Assert.AreEqual(challengeTenPage.GetUserPasswordByUserName(testUser.Login).Text, testUser.Password, "Wrong Password!");
                        Assert.AreEqual(challengeTenPage.GetUserFirstNameByUserName(testUser.Login).Text, testUser.FirstName, "Wrong First Name!");
                        Assert.AreEqual(challengeTenPage.GetUserLastNameByUserName(testUser.Login).Text, testUser.LastName, "Wrong Last Name!");
                    });

                    Logger.Info("Open Login page in new browser tab.");
                    var loginPage = challengeTenPage.OpenLoginPageNewTab();

                    Logger.Info($"Log-in as user first name: {testUser.FirstName} and last name: {testUser.LastName}.");
                    var welcomePage = loginPage.Login(testUser);

                    Logger.Info("Verify welcome message.");
                    Assert.AreEqual("Wellcome To Your Personal Road Assitance", welcomePage.WelcomeMessage.Text, "Wrong message!");

                    Logger.Info("Close Welcome Page tab.");
                    welcomePage.CloseTabAndSwitchToPrevious();
                }
            });
        }
    }
}