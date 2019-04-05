using CredentialManagement;
using System.Collections.Generic;

namespace WindowsCredentialLib
{
    public interface IWinCredentials
    {
        CredentialSet CurrentCredentials { get; set; }

        bool DeleteCredential(Credential credential);

        IList<Credential> GetCredentialsSearch(string targetText);

        bool UpdatePasswords(List<Credential> credentials);
    }
}