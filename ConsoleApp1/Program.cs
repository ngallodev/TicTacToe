using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PlayTicTacToe();
                Console.WriteLine("Press any key to play again.");
                Console.ReadKey();
            }
        }

        private static void PlayTicTacToe()
        {
            string[,] boardArray = new string[3, 3];
            int winner = 0;
            int player = 1;
            int count = 0;
            while (winner == 0)
            {
                //clear screan
                Console.Clear();
                //output board
                PrintBoard(boardArray);
                // prompt for input
                while (!MakePlay(player, ref boardArray))
                    Console.WriteLine("Fail");
                count++;
                //evaluate board
                if (EvaluateBoard(boardArray))
                    winner = player;
                if (winner == 0 && count == 9)
                    winner = 3;
                //switch player
                if (player == 1)
                    player = 2;
                else
                    player = 1;

            }
            if (winner == 3)
                Console.WriteLine("There is no winner.");
            else
                Console.WriteLine("Winner is Player {0}", winner);
            Console.ReadKey();
        }

        private static void PrintBoard(string [,] boardArray)
        {
            int counter = 1;
            for(int i = 0; i < 3; i++)
            {
                StringBuilder sb = new StringBuilder();
                for(int j = 0; j<3; j++)
                {
                    if (boardArray[i, j] == null)
                    {
                        sb.Append(counter.ToString());
                    }
                    else
                    {
                        sb.Append(boardArray[i, j]);
                    }
                    if (j < 2)
                        sb.Append("|");
                    counter++;
                }
                Console.WriteLine(sb.ToString());
            }
        }
        private static bool MakePlay(int player, ref string[,] boardArray)
        {
            Console.WriteLine("Player {0}, please choose a square. (1-9)", player.ToString());
            string input = Console.ReadLine();
            Regex rx = new Regex("[1-9]");
            if(rx.IsMatch(input) && input.Length == 1)
            {
                bool success = false;
                switch (input)
                {
                    case "1":
                        if (SetBoardValue(ref boardArray[0, 0], player))
                            success = true;
                        break;
                    case "2":
                        if (SetBoardValue(ref boardArray[0, 1], player))
                            success = true;
                        break;
                    case "3":
                        if (SetBoardValue(ref boardArray[0, 2], player))
                            success = true;
                            break;
                    case "4":
                        if (SetBoardValue(ref boardArray[1, 0], player))
                            success = true;
                        break;
                    case "5":
                        if (SetBoardValue(ref boardArray[1, 1], player))
                            success = true;
                        break;
                    case "6":
                        if (SetBoardValue(ref boardArray[1, 2], player))
                            success = true;
                        break;
                    case "7":
                        if (SetBoardValue(ref boardArray[2, 0], player))
                            success = true;
                        break;
                    case "8":
                        if (SetBoardValue(ref boardArray[2, 1], player))
                            success = true;
                        break;
                    case "9":
                        if (SetBoardValue(ref boardArray[2, 2], player))
                            success = true;
                        break;
                    default:
                        break;
                }
                if (success)
                    return true;
                
            }
               
            return false;
        }

        private static bool SetBoardValue(ref string boardArrayLocation, int player)
        {
            if (boardArrayLocation == null)
            {
                boardArrayLocation = player == 1 ? "X" : "O";
                return true;
            }
            return false;
        }
        private static bool EvaluateBoard(string[,] boardArray)
        {
            if (
                (boardArray[0, 0] != null && (boardArray[0, 0] == boardArray[0, 1]) && (boardArray[0, 1] == boardArray[0, 2]))
                || (boardArray[0, 0] != null && (boardArray[0, 0] == boardArray[1, 0]) && (boardArray[1, 0] == boardArray[2, 0]))
                || (boardArray[0, 0] != null && (boardArray[0, 0] == boardArray[1, 1]) && (boardArray[1, 1] == boardArray[2, 2]))
                || (boardArray[1, 0] != null && (boardArray[1, 0] == boardArray[1, 1]) && (boardArray[1, 1] == boardArray[1, 2]))
                || (boardArray[2, 0] != null && (boardArray[2, 0] == boardArray[2, 1]) && (boardArray[2, 1] == boardArray[2, 2]))
                || (boardArray[2, 0] != null && (boardArray[2, 0] == boardArray[1, 1]) && (boardArray[1, 1] == boardArray[0, 2]))
                || (boardArray[0, 1] != null && (boardArray[0, 1] == boardArray[1, 1]) && (boardArray[1, 1] == boardArray[2, 1]))
                || (boardArray[0, 2] != null && (boardArray[0, 2] == boardArray[1, 2]) && (boardArray[1, 2] == boardArray[2, 2]))
                )
                return true;
            return false;
        }
    }
}
