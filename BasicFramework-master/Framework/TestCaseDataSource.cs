using System.Collections;
using BasicFramework.Framework;
using NUnit.Framework;

namespace ChallengeTenFramework.Framework
{
    class TestCaseDataSource
    {
        public static IEnumerable AllUsers()
        {
            var usersList = Utils.GetUsersFromCSV();
            yield return new TestCaseData(usersList[0]).SetName("ChallengeTenOneByOneUserTest" + usersList[0].Login);
            yield return new TestCaseData(usersList[1]).SetName("ChallengeTenOneByOneUserTest" + usersList[1].Login);
            yield return new TestCaseData(usersList[2]).SetName("ChallengeTenOneByOneUserTest" + usersList[2].Login);
            yield return new TestCaseData(usersList[3]).SetName("ChallengeTenOneByOneUserTest" + usersList[3].Login);
            yield return new TestCaseData(usersList[4]).SetName("ChallengeTenOneByOneUserTest" + usersList[4].Login);
        }
    }
}
