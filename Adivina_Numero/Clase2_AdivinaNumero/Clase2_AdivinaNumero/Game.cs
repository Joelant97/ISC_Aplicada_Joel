using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Clase2_AdivinaNumero
{
    class Game
    {
        #region "Enums"

        public enum eGameState
        {
            Starting,
            Playing,
            Over
        }

        public enum AttemptResult
        {
            Guessed,
            Lower,
            Greater

        }
        #endregion

        #region "Attributes"
        const int MIN = 1, MAX = 1001;
        const string DEFAULTPATH = "scoretext.txt";
        public int SecretNumber { get; set; }

        public eGameState CurrentState { get; set; }

        public int LastTry { get; set; }

        public int Attempts { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan TimeSpent
        {
            get
            {
                return EndTime.Subtract(StartTime);
            }
        }

        public string ScorePath { get; set; }
        #endregion


        #region "Behaviours"
        public void GameInit()
        {
            SecretNumber = GenerateNumber(MIN, MAX);
            CurrentState = eGameState.Starting;
            Attempts = 0;
            //Funcion Guarda periodos de Tiempos (TimeSpan):
            //TimeSpan tmp = TimeSpan();
            StartTime = DateTime.Now;
            ScorePath = DEFAULTPATH;
        }


        private int GenerateNumber(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public AttemptResult CheckIfGuessed()
        {
            Attempts++;
            if (LastTry == SecretNumber)
            {

                return AttemptResult.Guessed;
                EndTime = DateTime.Now;
            }
                
            else if (LastTry > SecretNumber)
                return AttemptResult.Greater;
            else
                return AttemptResult.Lower;

        }

        public void SaveState()
        {
            /*using (FileStream fstream = File.Open(ScorePath, FileMode.Append))
            {
                UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
                unicodeEncoding.GetBytes($"Tiempo:{TimeSpent.TotalSeconds} - Intentos: {Attempts}");
                fstream.Write(buffer, 0, buffer.Length);

            }*/

            var streamWriter = File.AppendText(ScorePath);
            streamWriter.Write($"Tiempo: {TimeSpent.TotalSeconds} - Intentos: {Attempts}");
            streamWriter.Flush();
            streamWriter.Close();

        }
        public string ReadScore()
        {
            return File.ReadAllText(ScorePath);
        }
        #endregion



    }
}
