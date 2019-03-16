using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsCredentialLib;

namespace WindowsCredentialTests
{
    [TestClass]
    public class WindowsCredentialUnitTests
    {
        private WinCredImpl _credentialObj;

        [TestInitialize]
        public void Init()
        {
            _credentialObj = new WinCredImpl();
        }

        [TestCleanup]
        public void CleanUpTests()
        {
            _credentialObj = null;
        }
        [TestMethod]
        public void Test_WindowsCredential_Target_Count()
        {
            Assert.AreNotEqual(0, _credentialObj.CurrentCredentials.Count);
        }

        [TestMethod]
        public void Test_WindowsCredential_GT_Zero()
        {
            var count = _credentialObj.CurrentCredentials.Count;
            Assert.IsTrue(count > 0);
        }
        [TestMethod]
        public void Test_First_Index_Of_List()
        {
            bool HasMatch = false;

            foreach(CredentialManagement.Credential credential in _credentialObj.CurrentCredentials)
            {
                if(credential.Username != null)
                    if (credential.Username.Contains("Demo")) HasMatch = true;
            }
            Assert.IsTrue(HasMatch);
        }

        [TestMethod]
        public void Test_Get_Demo_Targets()
        {
            var results = _credentialObj.GetCredentialsSearch("Demo");
            Assert.IsNotNull(results);
        }
    }
}
