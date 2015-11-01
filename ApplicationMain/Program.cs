using ApplicationConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationMain
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Initialize(args);
        }

        private static void Initialize(string[] args)
        {
            string invokedVerb = null;
            object invokedVerbInstance = null;

            var opts = new CmdArgs();
            if (args.Length == 0 || CommandLine.Parser.Default.ParseArguments(
                    args,
                    opts,
                    (verb, subOptions) =>
                    {
                        // if parsing succeeds the verb name and correct instance
                        // will be passed to onVerbCommand delegate (string,object)
                        invokedVerb = verb;
                        invokedVerbInstance = subOptions;
                    }))
            {
                if (invokedVerbInstance is CmdArgs.BatchSubOptions)
                {

                }
                else
                {
                    App.Main();
                }
            }
            else
            {
                AppConsole.Show();
                Console.WriteLine(opts.GetUsage(invokedVerb));
                AppConsole.Hide();
            }
        }
    }
}
