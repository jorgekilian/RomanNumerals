using NUnit.Framework;

namespace RomanNumeralsSpecs {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [TestCase(1,"I")]
        public void calculate_the_roman_numeral_from_normal_number(int number, string roman) {
            string result = RomanNumeral.FromNumberToRoman(number);
            Assert.AreEqual(roman, result);
        }
    }

    public class RomanNumeral {
        public static string FromNumberToRoman(int number) {
            return "I";
        }
    }
}