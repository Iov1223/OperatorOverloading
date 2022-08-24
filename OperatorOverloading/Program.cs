using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Gamers
    {
        static private int myRandom()
        {
            Random random = new Random();
            var currentTime = DateTime.Now.Millisecond;
            int Number = currentTime;
            //Console.ReadKey();
            Number *= Number;
            int _myRandom = 1 + random.Next(Number) % 100;
            return _myRandom;
        }
        static private int myRandomHonor()
        {
            Random random = new Random();
            var currentTime = DateTime.Now.Millisecond;
            int Number = currentTime;
            //Console.ReadKey();
            Number *= Number;
            int _myRandom = 1 + random.Next(Number) % 1000;
            return _myRandom;
        }
        public Gamers()
        {
            name = "Gamer";
            coin = 1;
            honor = 1;
        }
        private string name;
        public string _name
        {
            get { return name; }
            set { name = value; coin = myRandom(); honor = 100; }
        }
        private int coin;

        public int _coin
        {
            get { return coin; }
        }
        private int honor;

        public int _honor
        {
            get { return honor; }
        }

        public static bool operator < (Gamers player1, Gamers player2)
        {
            bool result = false;
            bool _result = (player1._coin == player2._coin) & (player1._honor < player2._honor) || (player1._coin < player2._coin) & (player1._honor == player2._honor);
            if (_result)
            {
                result = true;
            }
            return result;
        }
        public static bool operator >(Gamers player1, Gamers player2)
        {
            bool result = false;
            bool _result = (player1._coin < player2._coin) & (player1._honor > player2._honor);
            if (_result)
            {
                result = true;
            }
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string name01, name02;
            try
            {
                name01 = args[0];
                name02 = args[1];
            }
            catch
            {
                Console.WriteLine("Введите имя 1-го игрока");
                name01 = Console.ReadLine();
                Console.WriteLine("Введите имя 2-го игрока");
                name02 = Console.ReadLine();
            }
            Gamers gamer01 = new Gamers();
            gamer01._name = name01;
            Gamers gamer02 = new Gamers();
            gamer02._name = name02;
            Console.WriteLine(
                "1-й игрок {0} имеет {1} монет, {2} доблести\n" +
                "2-й игрок {3} имеет {4} монет, {5} доблести",
                gamer01._name, gamer01._coin, gamer01._honor, gamer02._name, gamer02._coin, gamer02._honor);
            if (gamer01 > gamer02)
            {
                Console.WriteLine("игрок {0} успешней игрока {1}", gamer01._name, gamer02._name);
            }
            else
            {
                if (gamer01 < gamer02)
                {
                    Console.WriteLine("игрок {1} успешней игрока {0}", gamer01._name, gamer02._name);
                }
            }
        }
    }
}
//1.Монеты равны, но доблесть первого игрока уступает доблести второго => успешней 2-ой игрок
//2. Доблесть равна, но монеты первого игрока уступает монетам второго => успешней 2-ой игрок
//3. Монеты первого игрока уступает монетам второго, но доблесть первого игрока выше доблести второго => успешней 1-й игрок
