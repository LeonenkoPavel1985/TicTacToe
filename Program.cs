/*Задание. Игра "Крестики-Нолики".
Реализовать игру на C#. Отделить класс, отвечающий за логику игры от класса для отображения хода игры в консоли. 
Сделать, постараться сделать, красивый консольный интерфейс. Игровое поле 3х3. Результат - репозиторий в своём аккаунте 
на GitHub'е.*/

using System;
using System.Threading;

namespace Task_2_TicTacToe
{
    class Program
    {
        static int player = 1; // по умолчанию устанавливаем первого игрока (крестики).
        static int choice; // выбор хода.
        static Logic game = new Logic(); // класс Logic.
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            do
            {
                ScreenReload();
                do
                {
                    key = Console.ReadKey(true);
                    choice = key.KeyChar - 48;
                } 
                while (choice < 1 || choice > 9);
                //  проверяем занята ли позиция.
                if (game.EmptyPosition(choice))
                {
                    //  позиция свободна.
                    if (player % 2 == 0)
                    {
                        game.Moving(choice, 'O');
                    }
                    else
                    {
                        game.Moving(choice, 'X');
                    }
                    player++;
                }
                else
                {
                    //  позиция занята.
                    Console.SetCursorPosition(18, 27);
                    Console.WriteLine("\n\tЗанятая клетка.");
                    Thread.Sleep(2000);
                }
            } 
            while (game.StatusGame() == 'g');
            ScreenReload();
            if (game.StatusGame() == 'v')
            {
                Console.SetCursorPosition(18, 27);
                var winer = (player % 2) + 1;
                var symbol = (winer % 2) == 0 ? 'O' : 'X';
                Console.WriteLine($"Игрок {winer}: \"{symbol}\" выиграл.");
            }
            else
            {
                Console.SetCursorPosition(23, 27);
                Console.WriteLine("Победила дружба.");
            }
            Console.ReadKey();
        }
        static void ScreenReload ()
        {
            Console.Clear(); //очистка консоли.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("|--------------------Игра Крестики-Нолики.---------------------|");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("--Игрок 1 играет крестиками против Игрока 2 играющего ноликами--");
            Console.WriteLine("----------------------------------------------------------------");
            Console.ResetColor();
            game.Board();
            if (game.StatusGame() == 'g')
            {
                Console.SetCursorPosition(18, 27);
                Console.Write("Ходит: ");
                if (player % 2 == 0)
                {
                    Console.Write("Второй игрок: \"O\"");
                }
                else 
                {
                    Console.Write("Первый игрок: \"X\"");
                }
            }
        }
    }
}
