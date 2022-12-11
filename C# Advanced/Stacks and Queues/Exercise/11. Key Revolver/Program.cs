using System;
using System.Collections.Generic;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var _bullets = Console.ReadLine().Split(" ");
            var bullets = new Stack<int>(Array.ConvertAll(_bullets, bullet => int.Parse(bullet)));
            var _locks = Console.ReadLine().Split(" ");
            var locks = new Queue<int>(Array.ConvertAll(_locks, curLock => int.Parse(curLock)));
            var intelValue = int.Parse(Console.ReadLine());
            var totalBulletsFired = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                var bullet = bullets.Pop();
                var curLock = locks.Peek();
                totalBulletsFired++;
                if (bullet <= curLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (totalBulletsFired % gunBarrelSize == 0 && bullets.Count > 0) Console.WriteLine("Reloading!");
            }

            if (locks.Count > 0) Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            else
            {
                var bulletsCost = totalBulletsFired * bulletPrice;
                var moneyEarned = intelValue - bulletsCost;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
