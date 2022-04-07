using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;

namespace RomanNumeralsSpecs {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        public void calculate_the_roman_numeral_from_normal_number(int number, string roman) {
            string result = RomanNumeral.FromNumberToRoman(number);
            Assert.AreEqual(roman, result);
        }
    }

    public class RomanNumeral {
        private static Dictionary<int, string> letters = new Dictionary<int, string> {
            { 1, "I" },
            { 5, "V" }
        };

        public static string FromNumberToRoman(int number) {
            var previous = 0;
            var next = 1;
            for (var i = 0; i < letters.Count; i++) {
                if (letters.ElementAt(i).Key == number) {
                    previous = i;
                    next = i;
                    break;
                }
                else if (letters.ElementAt(i).Key > number) {
                    previous = i - 1;
                    next = i;
                }
            }

            if (previous == next) return letters.ElementAt(previous).Value;
            if (letters.ElementAt(next).Key - number == 1) return string.Concat(letters.ElementAt(previous).Value, letters.ElementAt(next).Value);
            return string.Concat(Enumerable.Repeat(letters.ElementAt(previous).Value, number));
        }
    }
}