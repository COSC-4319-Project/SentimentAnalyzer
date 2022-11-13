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
        public static SelectionForm selectionForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            Client.InitializeClient();
            Lexicon.LoadLexicon(Application.StartupPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            selectionForm = new SelectionForm();

            Application.Run(new LoginForm());

            if (Client.loggedin)
            {
                Lexicon.UpdateLexiconsFromServer();
                Application.Run(selectionForm);
            }
        }
    }
}
