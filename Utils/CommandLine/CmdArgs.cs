namespace ApplicationMain
{
    using CommandLine;
    using CommandLine.Text;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines all command line argument for this application
    /// </summary>
    public class CmdArgs
    {
        /// <summary>
        /// Gets the app banner in ASCII art
        /// </summary>
        public string Banner
        {
            get
            {
                return "           App Banner           ";
            }
        }

        /// <summary>
        /// Initializes a new instance of the application class
        /// </summary>
        static CmdArgs()
        {
            var opts = new CmdArgs();
            var tmpArgs = Environment.GetCommandLineArgs().ToList();
            if (tmpArgs.Any())
            {
                tmpArgs.RemoveAt(0);

                CommandLine.Parser.Default.ParseArguments(
                        tmpArgs.ToArray(),
                        opts,
                        (verb, subOptions) =>
                        {
                            // if parsing succeeds the verb name and correct instance
                            // will be passed to onVerbCommand delegate (string,object)
                            CommandLineArgs = subOptions as ICmdArgs;
                        });
            }
        }

        /// <summary>
        /// Initializes an instances of sub-options
        /// </summary>
        public CmdArgs()
        {
            this.BatchVerb = new BatchSubOptions();
        }

        /// <summary>
        /// Gets or sets the command line arguments that have been parsed
        /// </summary>
        public static ICmdArgs CommandLineArgs { get; set; }

        /// <summary>
        /// Gets or sets a value Indicating whether the application should be run in batch mode or not.
        /// </summary>
        [VerbOption("batch", HelpText = "Runs in batch mode (no window)")]
        public BatchSubOptions BatchVerb { get; set; }

        /// <summary>
        /// Gets a message which contains the command line argument usage of the application
        /// </summary>
        /// <param name="verb">The verb to display usage on.</param>
        /// <returns>Argument usage of the application</returns>
        [HelpVerbOption]
        public string GetUsage(string verb)
        {
            HelpText help;
            help = HelpText.AutoBuild(this, verb);

            var usage = new StringBuilder();

            help.MaximumDisplayWidth = 350;
            help.AddPreOptionsLine(this.Banner);
            help.AddPreOptionsLine(string.Format("CommandLine usage: {0} [options] <filenames>\n", System.AppDomain.CurrentDomain.FriendlyName));

            help.AddPostOptionsLine("Supported Modes:");

            help.Copyright = new CopyrightInfo("Company Corp.", 2015);
            help.Heading = new HeadingInfo("Application - Batch mode is unsupported.", "1.0");

            usage.AppendLine(help.ToString());
            return usage.ToString();
        }

        /// <summary>
        /// Batch verb options
        /// </summary>
        public class BatchSubOptions
        {
            /// <summary>
            /// Gets or sets a value Indicates whether the application should be run in batch mode or not.
            /// </summary>
            [Option('p', "parallel", Required = false, HelpText = "Runs jobs in parallel.")]
            public bool RunAsParallel { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the console window should remain open after running
            /// </summary>
            //#if DEBUG

            [Option("keep-open", HelpText = "Keep the console window open after running.")]
            //#endif

            public bool KeepWindowOpen { get; set; }

            /// <summary>
            /// Gets or sets a value indicating where the output data should be written
            /// </summary>
            [Option('o', "output", HelpText = "Specify the output file of the application")]
            public string OutputFile { get; set; }

            /// <summary>
            /// Gets or sets the list of input files that was given to the application
            /// </summary>
            [ValueList(typeof(List<string>))]
            public IList<string> InputFiles { get; set; }

            /// <summary>
            /// Gets a value indicating if an output file has been specified
            /// </summary>
            public bool HasOutputFile
            {
                get
                {
                    return !string.IsNullOrWhiteSpace(this.OutputFile);
                }
            }
        }
    }
}