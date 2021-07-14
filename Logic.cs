using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_TicTacToe
{
    class Logic
    {
        static char [] array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // создаем массив из десяти символов. 0 не используется.
        //array [0] = 'v'; победа (victory).
        //array [0] = 'd';  ничья (drow).
        //array [0] = 'c' продолжение игры (continuation game).

        // Создаем поле для игры.
        public void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", array[1], array[2], array[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", array[4], array[5], array[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", array[7], array[8], array[9]);
            Console.WriteLine("     |     |      ");
        }
        //Проверка на выигрыш игрока.
        static void CheckWin()
        {
            // совпадение в первой строке (победа).
            if (array[1] == array[2] && array[2] == array[3])
            {
                array[0] = 'v';
                return;
            }
            // совпадение во второй строке (победа).
            else if (array[4] == array[5] && array[5] == array[6])
            {
                array[0] = 'v';
                return;
            }
            // совпадение во второй строке (победа).
            else if (array[6] == array[7] && array[7] == array[8])
            {
                array[0] = 'v';
                return;
            }
            // совпадение в первой колонке (победа).
            else if (array[1] == array[4] && array[4] == array[7])

            {
                array[0] = 'v';
                return;
            }
            // совпадение в второй колонке (победа).
            else if (array[2] == array[5] && array[5] == array[8])
            {
                array[0] = 'v';
                return;
            }
            // совпадение в третей колонке (победа).
            else if (array[3] == array[6] && array[6] == array[9])
            {
                array[0] = 'v';
                return;
            }
            // совпадение по первой диагонали (победа).
            else if (array[1] == array[5] && array[5] == array[9])
            {
                array[0] = 'v';
                return;
            }
            // совпадение по второй диагонали (победа).
            else if (array[3] == array[5] && array[5] == array[7])
            {
                array[0] = 'v';
                return;
            }
            // проверяем на ничью (не возможно определить победителя).
            if (array[1] != '1' && array[2] != '2' && array[3] != '3' && array[4] != '4' && array[5] != '5' && array[6] != '6' && array[7] != '7' && array[8] != '8' && array[9] != '9')
            {
                array[0] = 'd';
                return;
            }
            // продолжение игры.
            else
            {
                array[0] = 'c';
            }
        }
        public char StatusGame ()// статус игры.
        {
            return array[0];
        }
        // Проверка пустой позиции.
        public bool EmptyPosition (int position)
        {
            if (array[position] != 'O' && array[position] != 'X')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Moving (int position, char player)
        {
            array[position] = player;
            CheckWin();
        }
    }  
}
