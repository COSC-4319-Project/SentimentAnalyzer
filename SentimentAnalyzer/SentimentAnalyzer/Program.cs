using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentimentAnalyzer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Lexicon.negLexLoc = Application.StartupPath + Lexicon.negLexLoc; //Apend Lexicon Location
            Lexicon.posLexLoc = Application.StartupPath + Lexicon.posLexLoc;

            Lexicon.LoadLexicon();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
