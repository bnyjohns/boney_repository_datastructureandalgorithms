using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    //Lets say 6 soldiers in a circle. Each soldier(position i) kills (i+2)th soldier.
    //First soldier kills 3rd soldier.
    //4th kills 6th. 1st kills 4th. 5th kills 2nd. 5th kills 5th. 1 is left.
    public class LastStandingSoldier
    {
        static bool[] killed = null;
        public static int GetLastStandingSoldier(int n)
        {
            killed = new bool[n];     
            int currentIndex = 0;
            var killedCount = 0;
            var resultIndex = -1;
            while(true)
            {
                resultIndex = currentIndex;
                currentIndex = GetNextFreeIndex(currentIndex, n, 2);
                killed[currentIndex] = true;
                killedCount++;
                if (killedCount == n - 1)
                    break;
                currentIndex = GetNextFreeIndex(currentIndex, n, 1);
            }
            resultIndex = GetNextFreeIndex(currentIndex, n, 1);
            return resultIndex + 1;
        }

        private static int GetNextFreeIndex(int currentIndex, int n, int move)
        {
            int moved = 0;
            while(moved < move)
            {
                currentIndex++;
                if (currentIndex == n)
                    currentIndex = 0;
                if (!killed[currentIndex])
                    moved++;
            }
            return currentIndex;
        }
    }
}
