using System;
using System.Collections.Generic;

namespace algorhtim
{
    class Program
    {
        // Greedy Algorithm
        // 문제 : https://school.programmers.co.kr/learn/courses/30/lessons/42862
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            int n = 5;
            int[] lost = { 1, 2, 4 };
            int[] reserve = { 1, 2, 3, 5 };

            int answer = solution.solution(n, lost, reserve);
            Console.WriteLine(answer);
        }

        public class Solution
        {
            public int solution(int n, int[] lost, int[] reserve)
            {
                int answer = n - lost.Length;

                Array.Sort(lost);
                Array.Sort(reserve);

                List<int> lostList = new List<int>(lost);
                List<int> reserveList = new List<int>(reserve);

                int prevNumber = 0;
                int nextNumber = 0;

                for (int i = 0; i < lostList.Count; i++)
                {
                    int index = reserveList.FindIndex(item => item == lostList[i]);
                    if (index != -1)
                    {
                        lostList.RemoveAt(i);
                        reserveList.RemoveAt(index);
                        answer++;
                        i--;
                    }
                }

                for (int i = 0; i < lostList.Count; i++)
                {
                    for (int j = 0; j < reserveList.Count; j++)
                    {
                        prevNumber = lostList[i] - 1;
                        nextNumber = lostList[i] + 1;

                        if (reserveList[j] == prevNumber || reserveList[j] == nextNumber)
                        {
                            reserveList.RemoveAt(j);
                            answer++;
                            break;
                        }
                    }
                }

                return answer;
            }
        }
    }
}
