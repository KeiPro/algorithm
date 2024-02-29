using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorhtim
{
    // 680. Valid Palindrome II
    // https://leetcode.com/problems/valid-palindrome-ii/description/

    class Class1
    {
        static void Main()
        {
            Solution sol = new Solution();

            //string s = "abcba";
            //string s = "abccfba";
            string s = "abcba";
            Console.WriteLine(sol.ValidPalindrome(s));
        }

        public class Solution
        {
            public bool ValidPalindrome(string s)
            {
                return isValidPalindromeHelper(s, 0, s.Length-1, false);
            }

            private bool isValidPalindromeHelper(string s, int left, int right, bool isDeleted)
            {
                while (left < right)
                {
                    if (s[left] != s[right])
                    {
                        if (isDeleted)
                            return false;

                        return isValidPalindromeHelper(s, left + 1, right, true) || isValidPalindromeHelper(s, left, right - 1, true);
                    }

                    left++;
                    right--;
                }

                return true;
            }
        }
    }


}
