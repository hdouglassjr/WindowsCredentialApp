using CredentialManagement;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WindowsCredentialLib
{
    public class WinCredImpl
    {
        public WinCredImpl()
        {
            WindowsCredentialCollection(GetTargets().ToList());
        }

        private IEnumerable<string> GetTargets()
        {
            const string cSplitString = "target="; // word "target" might differ in other languages

            var targets = new List<string>();
            var proc = new Process // We need separate process to get the output
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
                if (line.Contains(cSplitString))
                {
                    targets.Add(line.Substring(line.IndexOf(cSplitString) + cSplitString.Length));
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
                Credential credential = new Credential();
                credential.Target = target;
                credential.Load();
                CurrentCredentials.Add(credential);
            }
        }
    }
}