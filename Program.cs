using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Reflection
{
    class Program
    {
        private static Dictionary<string, string> _methodDictionary;

        static void Main(string[] args)
        {
            Console.WriteLine("Reflection");
            Console.WriteLine("Reflection objects are used for obtaining type information at runtime.");
            Console.WriteLine();

            // our goal is to dynamically create an instance of StudentFunction and get values from GetName(), GetUniversity() and GetRoll() method at the compile time.
            _methodDictionary = new Dictionary<string, string>();
            _methodDictionary = GetMethodsDictionary();

            var type = typeof(StudentFunction);
            var studentFunctionInstance = Activator.CreateInstance(type);

            var testString = "Hello [GetName], your university name is [GetUniversity] and roll number is [GetRoll]";
            var match = Regex.Matches(testString, @"\[([A-Za-z0-9\-]+)]", RegexOptions.IgnoreCase);
            foreach (var v in match)
            {
                var originalString = v.ToString();
                var x = v.ToString();
                x = x.Replace("[", "");
                x = x.Replace("]", "");
                x = _methodDictionary[x];

                var toInvoke = type.GetMethod(x);
                var result = toInvoke.Invoke(studentFunctionInstance, null);
                testString = testString.Replace(originalString, result.ToString());
            }

            Console.WriteLine(testString);
        }

        private static Dictionary<string, string> GetMethodsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"GetName", "GetName"},
                {"GetUniversity", "GetUniversity"},
                {"GetRoll","GetRoll"}
            };
            return dictionary;
        }
    }
}