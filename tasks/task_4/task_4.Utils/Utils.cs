namespace task_4.Methods
{
    public static class Utils
    {
        public static string ReverseString(string s)
        {
            var l = 0;
            var r = s.Length - 1;
            Span<char> buffer = stackalloc char[s.Length];
            while (l <= r)
            {
                buffer[r] = s[l];
                buffer[l] = s[r];
                l++;
                r--;
            }
            return buffer.ToString();
        }

        public static bool IsPalindrome(string s)
        {
            var l = 0;
            var r = s.Length - 1;
            while (l < r)
            {
                if (s[l++] != s[r--])
                    return false;
            }
            return true;
        }

        public static IEnumerable<int> MissingElements(int[] arr)
        {
            Array.Sort(arr);
            var result = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] > 1)
                {
                    var missedValue = arr[i - 1] + 1;
                    while (missedValue != arr[i])
                    {
                        result.Add(missedValue);
                        missedValue++;
                    }
                }
            }
            return result;
        }

    }
}
