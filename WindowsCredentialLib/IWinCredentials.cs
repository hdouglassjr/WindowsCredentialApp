using System.Collections.Generic;
using CredentialManagement;

namespace WindowsCredentialLib
{
    public interface IWinCredentials
    {
        CredentialSet CurrentCredentials { get; set; }

        bool DeleteCredential(Credential credential);
        List<Credential> GetCredentialsSearch(string targetText);
        bool UpdatePasswords(List<Credential> credentials);
    }
}