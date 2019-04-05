using System.Collections.Generic;

namespace WindowsCredentialLib
{
    public interface IWindowsCredential
    {
        IEnumerable<string> GetTargets();

        void WindowsCredentialColl(IEnumerable<string> targets);
    }
}