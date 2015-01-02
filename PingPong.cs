using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JustPingPong
{
    class Program
    {
       
        static int firstPlayerPadSize = 4;
        static int secondPlayerPadSize = 4;
        static int ballPositionX = 0;
        static int ballPositionY = 0;
        // determines if the ball direction is up
        static bool ballDirectionUp = true;
        static bool ballDirectionRight = true;
        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;
        static int firstPlayerResult = 0;
        static int secondPlayerResult = 0;
        static Random randomGenerator = new Random();


        static void RemoveScrollBars()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPosition + firstPlayerPadSize; y++)
            {
                PrintAtPosition(0, y, '|');
                PrintAtPosition(1, y, '|');
            }
        }

        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPosition + secondPlayerPadSize; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '|');
                PrintAtPosition(Console.WindowWidth - 2, y, '|');
            }
        }

        static void SetInitialPositions()
        {
            firstPlayerPosition =  Console.WindowHeight /2 - firstPlayerPadSize /2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            //ballPositionX = Console.WindowWidth / 2;
            //ballPositionY = Console.WindowHeight / 2;
            SetBallAtTheMiddleOfTheGameField();
        }

        static void SetBallAtTheMiddleOfTheGameField()
        {
            ballPositionX = Console.WindowWidth / 2;
            ballPositionY = Console.WindowHeight / 2;
        }


        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@');
        }

       static void PrintResult()
        {
            Console.SetCursorPosition(((Console.WindowWidth / 2) - 1), 0);
            Console.Write("{0}-{1}",firstPlayerResult,secondPlayerResult);
        }


       static void MoveFistPlayerDown()
       {
           // TODO: move first player down
           if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
           {
               firstPlayerPosition++;
           }
       }

       static void MoveFirstPlayerUp()
       {
           //TODO: move first player up
           if (firstPlayerPosition > 0)
           {
               firstPlayerPosition--;
           }
       }

       static void MoveSecondPlayerDown()
       {
           // TODO: move second player down
           if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
           {
               secondPlayerPosition++;
           }
       }

       static void MoveSecondPlayerUp()
       {
           //TODO: move second player up
           if (secondPlayerPosition > 0)
           {
               secondPlayerPosition--;
           }
       }

       static void SecondPlayerAIMove()
       {
           int randomNumber = randomGenerator.Next(1, 101);
           //if (randomNumber == 0)
           //{
           //    MoveSecondPlayerUp();
           //}
           //if (randomNumber == 1)
           //{
           //    MoveSecondPlayerDown();
           //}
           if (randomNumber <= 99)
           {
               if (ballDirectionUp == true)
               {
                   MoveSecondPlayerUp();
               }
               else
               {
                   MoveSecondPlayerDown();
               }
           }
       }
       static void MoveBall()
       {
           if (ballPositionY == 0)
           {
               ballDirectionUp = false;
           }

           if (ballPositionY == Console.WindowHeight - 1)
           {
               ballDirectionUp = true;
           }

           if (ballPositionX == Console.WindowWidth - 1)
           {
               //ballPositionX = Console.WindowWidth / 2;
               //ballPositionY = Console.WindowHeight / 2;
               SetBallAtTheMiddleOfTheGameField();
               //TODO second player loses
               ballDirectionRight = false;
               ballDirectionUp = true;
               firstPlayerResult++;
               Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
               Console.WriteLine("First player wins!");
               Console.ReadKey();
           }
           if (ballPositionX == 0)
           {
               SetBallAtTheMiddleOfTheGameField();
               //TODO first player loses
               ballDirectionRight = true;
               ballDirectionUp = true;
               secondPlayerResult++;
               Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
               Console.WriteLine("Second player wins!");
               Console.ReadKey();
           }

           if (ballPositionX < 3)
           {
               if (ballPositionY >= firstPlayerPosition && ballPositionY < firstPlayerPosition + firstPlayerPadSize)
               {
                   ballDirectionRight = true;
               }
           }

           if (ballPositionX >= Console.WindowWidth - 3 - 1)
           {
               if (ballPositionY >= secondPlayerPosition && ballPositionY < secondPlayerPosition + secondPlayerPadSize)
               {
                   ballDirectionRight = false;
               }
           }

           if (ballDirectionUp)
           {
               ballPositionY--;
           }
           else
           {
               ballPositionY++;
           }
           if (ballDirectionRight)
           {
               ballPositionX++;
           }
           else
           {
               ballPositionX--;
           }

          //TODO: Implement
       }



        static void Main(string[] args)
        {
            RemoveScrollBars();
            SetInitialPositions();

            // Remove scroll bar
            //Console.BufferHeight = Console.WindowHeight;
            //Console.BufferWidth = Console.WindowWidth;

            while (true)//(firstPlayerResult <= 7 || secondPlayerResult <= 7)//(true)
            {
                // Za da ne spira konzolata!
                if (Console.KeyAvailable)
                {
                    // Move first Player
                    // keys
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFistPlayerDown();
                    }
                }
                
                // Move second Player
                SecondPlayerAIMove();
                // Move ball
                MoveBall();
                // Redraw all
                // - clear all
                Console.Clear();
                // - draw fist player
                DrawFirstPlayer();
                // - draw second player
                DrawSecondPlayer();
                // - draw ball
                DrawBall();
                // - print result
                PrintResult();
                Thread.Sleep(60);
            }
        }

       

    }
}


/*
 ________________________________   

 *            *                 *
 *                              *
 *                              *
 *                              *

 ________________________________
 
*/
