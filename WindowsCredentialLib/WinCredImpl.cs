using System;
using CredentialManagement;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WindowsCredentialLib
{
    public class WinCredImpl : IWinCredentials
    {
        public WinCredImpl()
        {
            WindowsCredentialCollection(GetTargets().ToList());
        }

        public IList<Credential> GetCredentialsSearch(string targetText)
        {
            return CurrentCredentials.FindAll(c => c.Target.Contains(targetText)).ToList();
        }

        public bool UpdatePasswords(List<Credential> credentials)
        {
            return false;
        }

        public bool DeleteCredential(Credential credential)
        {
            return false;
        }

        private IEnumerable<string> GetTargets()
        {
            const string cSplitString = "target="; 

            var targets = new List<string>();
            var proc = new Process 
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmdkey.exe",
                    Arguments = "/list",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                if (line != null && line.Contains(cSplitString))
                {
                    targets.Add(line.Substring(line.IndexOf(cSplitString, StringComparison.Ordinal) + cSplitString.Length));
                }
            }
            return targets;
        }

        public CredentialSet CurrentCredentials { get; set; }

        private void WindowsCredentialCollection(List<string> targets)
        {
            CurrentCredentials = new CredentialSet();

            foreach (var target in targets)
            {
                Credential credential = new Credential {Target = target};
                credential.Load();
                CurrentCredentials.Add(credential);
            }
        }
    }
}