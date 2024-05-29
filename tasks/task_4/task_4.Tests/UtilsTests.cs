using task_4.Methods;
namespace task_4.Tests
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        [DataRow("even line")]
        [DataRow("odd line")]
        public void ReverseString_SmokeTests(string s)
        {
            var expected = new string(s.Reverse().ToArray());
            string actual = Utils.ReverseString(s);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("not palindrome", false)]
        [DataRow("palindrome", false)]
        [DataRow("papapap", true)]
        [DataRow("pap", true)]
        [DataRow("", true)]
        [DataRow("c", true)]
        public void IsPalindrome_SmokeTests(string s, bool expected)
        {
            var result = Utils.IsPalindrome(s);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        [DataRow(new int[] { 4, 6, 9 }, new int[] {5, 7, 8})]
        [DataRow(new int[] { 2 }, new int[] { })]
        [DataRow(new int[] { 1, 3, 4 }, new int[] {2})]
        [DataRow(new int[] {}, new int[] {})]
        public void MissingElements_SmokeTests(int[] arr, int[] expected)
        {
            var result = Utils.MissingElements(arr);

            CollectionAssert.AreEqual(expected, result.ToArray());
        }
    }
}