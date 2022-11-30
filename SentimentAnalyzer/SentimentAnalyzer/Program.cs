//Software Engineering 4319 - Fall 2022

using System;
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
            Client.InitializeClient(); //Initilize Network objects on client
            Lexicon.LoadLexicon(Application.StartupPath); //Load lexicon data

            //Default calls for windows forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            selectionForm = new SelectionForm();// Get refrence to selection form
            
            Application.Run(new LoginForm());//Run login form

            if (Client.loggedin) //If login sucesfull launch selection
            {
                Lexicon.UpdateLexiconsFromServer();
                Application.Run(selectionForm);
            }
            //If not terminate execution
        }
    }
}
