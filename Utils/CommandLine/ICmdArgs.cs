using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    public interface ICmdArgs
    {

        /// <summary>
        /// Gets the argument with the given name from the underlying type
        /// </summary>
        /// <param name="argName">Argument to fetch</param>
        /// <returns>The argument wanted if exists or null</returns>
        object GetArg(string argName);
    }
}
