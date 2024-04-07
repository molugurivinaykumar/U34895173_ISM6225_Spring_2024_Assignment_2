/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine($"Output: {numberOfUniqueNumbers}, nums = [{string.Join(",", nums1.Select(x => x == -1 ? "_" : x.ToString()))}]");

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Checking if the input array is null or empty
                // If so, we will return 0 since there are no elements to process
                if (nums == null || nums.Length == 0)
                    return 0;

                // Initializing a pointer 'uniqueIndex' to keep track of the position
                // where the next unique element should be placed
                int uniqueIndex = 0;

                // Iterating through the array starting from index 1
                for (int i = 1; i < nums.Length; i++)
                {
                    // Comparing the current element with the last unique element
                    // If they are different, it means we have found a new unique element
                    if (nums[i] != nums[uniqueIndex])
                    {
                        // Incrementing 'uniqueIndex' to point to the next position
                        // where the new unique element should be placed
                        uniqueIndex++;

                        // Placing the new unique element at the 'uniqueIndex' position
                        nums[uniqueIndex] = nums[i];
                    }
                    // If the current element is the same as the last unique element, skip it and continue to the next element
                }

                // Replacing the remaining elements after the unique elements with -1
                for (int i = uniqueIndex + 1; i < nums.Length; i++)
                {
                    nums[i] = -1;
                }

                // Returning the count of unique elements
                // Since 'uniqueIndex' is zero-based, we are adding 1 to get the count
                return uniqueIndex + 1;
            }
            catch (Exception)
            {
                // If any exception occurs during the execution of the code,
                // catch it and rethrow it to be handled by the calling code
                throw;
            }
        }

/*
Self Reflection:
This C# code removes duplicates from a sorted array in-place, returning the count of unique elements. We assumes the first element is unique, then iterates through the array, overwriting duplicates with unique elements found.
Recommendations:
Through this problem, I came across how we can use two pointers in one for loop while switching array positions. 
*/

        /*

        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]

        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Returning empty list if input array is null or empty
                if (nums == null || nums.Length == 0)
                    return new List<int>();

                // Pointer to track position of next non-zero element
                int nonZeroIndex = 0;

                // Moving non-zero elements to the front of the array
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        nums[nonZeroIndex] = nums[i];
                        nonZeroIndex++;
                    }
                }

                // Filling remaining positions with zeros
                while (nonZeroIndex < nums.Length)
                {
                    nums[nonZeroIndex] = 0;
                    nonZeroIndex++;
                }

                // Converting modified array to list and return
                return nums.ToList();
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }
/*
Self Reflection:
The solution moves all zeros to the end of the array while preserving the relative order of non-zero elements. I achieved this by using a single pointer to track the position of the next non-zero element, avoiding the need for an additional array.
Recommendations:
This technique of using a single pointer to maintain the relative order of elements can be applied to similar in-place array manipulation problems. 
 */

 /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Creating a list to store the triplets
                IList<IList<int>> result = new List<IList<int>>();

                // Returning empty list if input array is null or has fewer than 3 elements
                if (nums == null || nums.Length < 3)
                    return result;

                // Sorting the array in ascending order
                Array.Sort(nums);

                // Iterating through the array, fixing the first element of the triplet
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skipping duplicate elements to avoid duplicate triplets
                    if (i > 0 && nums[i] == nums[i - 1])
                        continue;

                    // Initializing pointers for the remaining two elements
                    int left = i + 1;
                    int right = nums.Length - 1;

                    // Finding pairs that sum up to the negation of the fixed element
                    while (left < right)
                    {
                        int sum = nums[i] + nums[left] + nums[right];

                        if (sum == 0)
                        {
                            // If a triplet is found, we add it to the result list
                            result.Add(new List<int>() { nums[i], nums[left], nums[right] });

                            // Skipping duplicate elements to avoid duplicate triplets
                            while (left < right && nums[left] == nums[left + 1])
                                left++;
                            while (left < right && nums[right] == nums[right - 1])
                                right--;

                            left++;
                            right--;
                        }
                        else if (sum < 0)
                        {
                            // Sum is too small, move the left pointer to increase the sum
                            left++;
                        }
                        else
                        {
                            // Sum is too large, move the right pointer to decrease the sum
                            right--;
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }
/*
Self Reflection:
For this question,we find all unique triplets in the input array that sum up to 0. I used a two-pointer approach after sorting the array, which allows it to efficiently identify valid triplets and skip duplicate elements.
Recommendations:
The two-pointer technique is a powerful tool for solving array-based problems, especially when dealing with sorted or partially sorted data.
*/

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Initializing variables to keep track of the count of consecutive ones
                int maxOnes = 0;
                int currentOnes = 0;

                // Iterating through the array
                foreach (int num in nums)
                {
                    if (num == 1)
                    {
                        // If the current element is 1, incrementing the count of consecutive ones
                        currentOnes++;
                        // Updat ingthe maximum count if necessary
                        maxOnes = Math.Max(maxOnes, currentOnes);
                    }
                    else
                    {
                        // If the current element is 0, resetting the count of consecutive ones
                        currentOnes = 0;
                    }
                }

                return maxOnes;
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }

/*
Self Reflection:
In this question we keep a track of the maximum count of consecutive ones in the binary array using a simple iterative approach. I updated the maximum count whenever a new sequence of ones is encountered and reset the count when a zero is found.
Recommendations:
This problem demonstrates the effectiveness of a simple iterative approach to keep track of the maximum count of a specific element in an array. 
*/

        /*
        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Initializing variables for decimal conversion
                int decimalNumber = 0;
                int baseValue = 1;

                // Iterating through each digit of the binary number
                while (binary > 0)
                {
                    // Getting the last digit of the binary number
                    int lastDigit = binary % 10;

                    // Removing the last digit from the binary number
                    binary = binary / 10;

                    // Adding the contribution of the last digit to the decimal number
                    decimalNumber += lastDigit * baseValue;

                    // Updating the base value for the next iteration
                    baseValue *= 2;
                }

                return decimalNumber;
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }

/*
Self Reflection:
In this problem, I converted a binary number to its decimal equivalent without using bitwise operators or the Math.Pow function. I relied on basic arithmetic operations to extract and process the digits of the binary number.
Recommendations:
When faced with the challenge of avoiding specific language features, it's important to explore alternative approaches using more fundamental operations. This can lead to interesting problem-solving techniques. 
*/


        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                // Returning 0 if the array contains less than 2 elements
                if (nums.Length < 2)
                    return 0;

                // Sorting the array in ascending order
                Array.Sort(nums);

                // Initializing a variable to store the maximum gap
                int maxGap = 0;

                // Iterating through the sorted array up to the second-to-last element
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    // Updating the maximum gap if the current gap is larger
                    maxGap = Math.Max(maxGap, nums[i + 1] - nums[i]);
                }

                return maxGap;
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }
 /*
Self Reflection:
Here in this problem I found the maximum gap between two successive elements in the sorted input array. I then achieved this by sorting the array and then iterating through the sorted array to compute the maximum gap.
Recommendations:
Sorting the array can be a helpful preprocessing step in many array-based problems, as it can simplify the logic and allow for efficient solutions. 
 */

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                // Returning 0 if the array has less than 3 elements
                if (nums == null || nums.Length < 3)
                    return 0;

                // Sorting the array in descending order
                Array.Sort(nums);
                Array.Reverse(nums);

                // Iterating through the sorted array starting from the first element
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Checking if the current three elements form a valid triangle
                    if (nums[i] < nums[i + 1] + nums[i + 2])
                    {
                        // Returning the perimeter of the valid triangle
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }

                // If no valid triangle is found, returning 0
                return 0;
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }
  /*
Self Reflection:
Through this solution, I identified the largest perimeter of a triangle that can be formed using the lengths in the input array. I sorted the array in descending order and checked if the current three elements form a valid triangle.
Recommendations:
Sorting the array in a specific order can be a useful technique to simplify the logic and identify valid solutions, as demonstrated in my solution. 
*/


        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Checking if either s or part is null or empty
                if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(part))
                    return s;

                // Finding the index of the first occurrence of part in s
                int index = s.IndexOf(part);

                // Keeping removing occurrences of part until no more are found
                while (index != -1)
                {
                    // Removing the occurrence of part from s
                    s = s.Remove(index, part.Length);

                    // Finding the index of the next occurrence of part in the updated s
                    index = s.IndexOf(part);
                }

                // Returning the modified string s
                return s;
            }
            catch (Exception)
            {
                // throw any exceptions for handling by calling code
                throw;
            }
        }
/*
 Self Reflection:
I removed all occurrences of a given substring from the input string by repeatedly finding and removing the leftmost occurrence of the substring until no more are found. I used the IndexOf method to efficiently locate the substring.
Recommendations:
Using built-in string manipulation functions, such as IndexOf, can be a powerful way to solve string-based problems, especially when dealing with finding and removing substrings. 
*/



        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}