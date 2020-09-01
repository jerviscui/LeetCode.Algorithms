using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Solution
    {
        /*
        Given an array of integers nums and and integer target, return the indices of the two numbers such that they add up to target.

        You may assume that each input would have exactly one solution, and you may not use the same element twice.

        You can return the answer in any order.
        */

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int a = target - nums[i];

                //search
                var skip = i + 1;
                var index = IndexOf(nums.AsSpan(skip), a);
                if (index != -1)
                {
                    index += skip;
                    return new[] { i, index };
                }
            }

            return Array.Empty<int>();
        }

        private int IndexOf(Span<int> nums, int item)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == item)
                {
                    return i;
                }
            }

            return -1;
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.TryGetValue(nums[i], out int index))
                {
                    return new[] { index, i };
                }

                int a = target - nums[i];
                dic.TryAdd(a, i);
            }

            return Array.Empty<int>();
        }
    }
}
