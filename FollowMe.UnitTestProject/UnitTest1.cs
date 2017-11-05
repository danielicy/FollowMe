using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities.Managers;

namespace FollowMe.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IPAddressManager ipManager = new IPAddressManager();

        // string t =   ipManager.GetIP4Address();
          //  Assert.IsTrue(t != null);

        }
    }
}
