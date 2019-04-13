using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using CredentialManagement;
using WindowsCredentialLib;

namespace WindowsCredentialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WinCredImpl credImpl = new WinCredImpl();
            var stringBuilder = new StringBuilder();
            IList<Credential> credentials = credImpl.CurrentCredentials;

            foreach(var credential in credentials)
            {
                if(credential.Target.Contains("outlook"))
                {
                    stringBuilder.Append("Persistence Type:  " + credential.PersistanceType);
                    stringBuilder.Append("  UserName: " + (credential.Username  ?? "null"));
                    stringBuilder.AppendLine("  Target:  " + credential.Target);
                    //stringBuilder.AppendLine(" ");

                    Console.WriteLine(stringBuilder.ToString());
                }
            }

            Console.ReadLine();
        }
    }
}