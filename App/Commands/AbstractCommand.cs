using System;
using Lib.Extensions;

namespace App.Commands
{
    public abstract class AbstractCommand
    {
        protected static string GetVersion(Type type) => type.GetAssemblyVersion();
    }
}