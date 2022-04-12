using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

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
        [TestCase(19, "XIX")]
        [TestCase(20, "XX")]
        [TestCase(21, "XXI")]
        [TestCase(22, "XXII")]
        [TestCase(24, "XXIV")]
        [TestCase(25, "XXV")]
        [TestCase(26, "XXVI")]
        [TestCase(29, "XXIX")]
        [TestCase(30, "XXX")]
        [TestCase(31, "XXXI")]
        [TestCase(32, "XXXII")]
        [TestCase(34, "XXXIV")]
        [TestCase(35, "XXXV")]
        [TestCase(36, "XXXVI")]
        [TestCase(40, "XL")]
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

        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("VI", 6)]
        public void calculate_the_normal_numeral_from_roman_number(string roman, int number) {
            var romanNum = new RomanNumeral();

            var result = romanNum.FromRomanToNumber(roman);

            Assert.AreEqual(number, result);
        }
    }

    public class RomanNumeral {
        private readonly Dictionary<int, string> letters = new Dictionary<int, string> {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX"},
            { 10, "X"},
            { 40, "XL"},
            { 50, "L"},
            { 90, "XC"},
            { 100, "C"},
            { 400, "CD"},
            { 500, "D"},
            { 900, "CM"},
            { 1000, "M"}
        };

        private readonly Dictionary<string, int> numbers = new Dictionary<string, int> {
            { "I" , 1},
            { "IV" , 4},
            { "V" , 5},
            { "IX", 9},
            { "X", 10},
            { "XL", 40},
            { "L", 50},
            { "XC", 90},
            { "C", 100},
            { "CD", 400},
            { "D", 500},
            { "CM", 900},
            { "M", 1000}
        };

        private string numberToRoman = string.Empty;
        private int romanToNumber = 0;

        public string FromNumberToRoman(int number) {
            return GetPartialRomanNumber(number);
        }
        public int FromRomanToNumber(string roman) {
            return GetPartialNumberRoman(roman);
        }

        private int GetPartialNumberRoman(string roman) {
            var length = 1;
            if (roman.Length > 1 && numbers.ContainsKey(roman.Substring(0, 2))) {
                length = 2;
            }
            romanToNumber += GetIntValue(roman.Substring(0, length)); ;
            roman = roman.Substring(length);
            if (roman != string.Empty) GetPartialNumberRoman(roman);
            return romanToNumber;
        }

        private int GetIntValue(string roman) {
            return numbers[roman];
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