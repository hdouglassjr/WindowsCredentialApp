﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsCredentialLib
{
    public interface IWindowsCredential
    {
        IEnumerable<string> GetTargets();
        void WindowsCredentialColl(IEnumerable<string> targets);
    }
}