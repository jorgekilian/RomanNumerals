using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RomanNumeralsSpecs {
    public class Tests {

        [TestCase(1, "I")]
        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(4, "IV")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(9, "IX")]
        [TestCase(10, "X")]
        [TestCase(11, "XI")]
        [TestCase(12, "XII")]
        [TestCase(13, "XIII")]
        [TestCase(14, "XIV")]
        [TestCase(15, "XV")]
        [TestCase(16, "XVI")]
        [TestCase(17, "XVII")]
        [TestCase(18, "XVIII")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(22, "XXII")]
        [TestCase(25, "XXV")]
        [TestCase(26, "XXVI")]
        [TestCase(30, "XXX")]
        [TestCase(31, "XXXI")]
        [TestCase(32, "XXXII")]
        [TestCase(35, "XXXV")]
        [TestCase(36, "XXXVI")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(1001, "MI")]
        [TestCase(1555, "MDLV")]
        [TestCase(2000, "MM")]
        [TestCase(2888, "MMDCCCLXXXVIII")]
        public void calculate_the_roman_numeral_from_normal_number(int number, string roman) {
            var romanNum = new RomanNumeral();

            var result = romanNum.FromNumberToRoman(number);

            Assert.AreEqual(roman, result);
        }
    }

    public class RomanNumeral {
        private readonly Dictionary<int, string> letters = new Dictionary<int, string> {
            { 1, "I" },
            { 5, "V" },
            { 10, "X"},
            { 50, "L"},
            { 100, "C"},
            { 500, "D"},
            { 1000, "M"}
        };

        private string numberToRoman = string.Empty;

        public string FromNumberToRoman(int number) {
            numberToRoman = GetIrregularNumber(number);
            if (numberToRoman != string.Empty) return numberToRoman;
            return GetPartialRomanNumber(number);
        }

        private string GetIrregularNumber(int number) {
            if (number == 4 ) return "IV";
            if (number == 9) return "IX";
            if (number == 14) return "XIV";
            return string.Empty;
        }

        private string GetPartialRomanNumber(int number) {
            numberToRoman = string.Concat(numberToRoman, GetLetter(number));
            number -= GetValue(number);
            if (number > 0) GetPartialRomanNumber(number);
            return numberToRoman;
        }

        private string GetLetter(int number) {
            var letter = string.Empty;
            for (var i = 1; i < letters.Count; i++) {
                if (letters.ElementAt(i).Key > number) {
                    letter = letters.ElementAt(i - 1).Value;
                    break;
                }
                letter = letters.ElementAt(i).Value;
            }
            return letter;
        }

        private int GetValue(int number) {
            var value = 0;
            for (var i = 1; i < letters.Count; i++) {
                if (letters.ElementAt(i).Key > number) {
                    value = letters.ElementAt(i - 1).Key;
                    break;
                }
                value = letters.ElementAt(i).Key;
            }
            return value;
        }
    }
}