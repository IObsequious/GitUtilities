// -----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace RepoGen
{
    public static class Utilities
    {
        public static IEnumerable<StartProgram> GetStartPrograms => Enum.GetValues(typeof(StartProgram)).Cast<StartProgram>();
    }
}
