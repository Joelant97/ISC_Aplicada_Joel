using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Clase2_AdivinaNumero
{
    class Program
    {
        public static Game CurrentGame;
        static Thread inputThread;

        static void Main(string[] args)
        {
            CurrentGame = new Game();
            CurrentGame.GameInit();
            inputThread = new Thread(Input);
            inputThread.Start();

           Console.Write(CurrentGame.ReadScore());

            while (CurrentGame.CurrentState != Game.eGameState.Over)
            {
                switch (CurrentGame.CurrentState)
                {
                    case Game.eGameState.Starting:
                        Console.WriteLine("Digite un valor entre 1 y 1000: ");
                        CurrentGame.CurrentState = Game.eGameState.Playing;
                        break;
                    case Game.eGameState.Playing:
                        if (CurrentGame.LastTry == 0)
                            continue;


                        //Check if secret number is guessed...
                        switch (CurrentGame.CheckIfGuessed())
                        {
                            case Game.AttemptResult.Greater:
                                Console.WriteLine("El número secreto es menor.");
                                break;
                            case Game.AttemptResult.Lower:
                                Console.WriteLine("El número secreto es mayor.");
                                break;
                            default:
                                Console.WriteLine("Ha Adivinado!");
                                CurrentGame.CurrentState = Game.eGameState.Over;
                                break;

                        }

                        if (CurrentGame.CurrentState != Game.eGameState.Over)
                            Console.WriteLine("Digite otro Valor: ");

                        // And reset the last try. 
                        CurrentGame.LastTry = 0;
                        break;
                }
            }
            inputThread.Abort();
            inputThread.Join();
            Console.Write($"Ha adivinado en {CurrentGame.Attempts} intentos.");
            Console.Write($"Ha Tomado {CurrentGame.TimeSpent.TotalSeconds} segundos.");
            Console.WriteLine("Gracias por Jugar. ");
            CurrentGame.SaveState();
            Console.ReadKey();

        }
        static void Input()
        {
            int _currentValue = 0;
            while (CurrentGame.CurrentState != Game.eGameState.Over)
            {
                _currentValue = Convert.ToInt32(Console.ReadLine());
                CurrentGame.LastTry = _currentValue;
            }
        }

    }
}
