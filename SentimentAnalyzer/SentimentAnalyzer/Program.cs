//Software Engineering 4319 - Fall 2022

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
            ServerClient.InitializeClient();
            
            //Login.LoadUserDB(Application.StartupPath);
            Lexicon.LoadLexicon(Application.StartupPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());

            if (ServerClient.loggedin)
            {
                Lexicon.UpdateLexiconsFromServer();
                Application.Run(new SelectionForm());
            }
        }

        public static void RunBatch(Form calledFrom)
        {
            calledFrom.Close();
            Application.Run(new BatchReviewDisplay());
        }
        public static void RunSingle(Form calledFrom)
        {
            calledFrom.Close();
            Application.Run(new Form1());
        }
    }
}
