using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace strings
{
    /// <summary>
    /// Here are all functions solving tasks
    /// </summary>
    public static class StringUtils
    {
        // Task 1.
        public static bool IsPalindrome(string str)
        {
            var result = true;
            var normalizedStr = str.Replace(" ", "").Replace("-","").Replace(",","").Replace(".","");

            int strLength = normalizedStr.Length;
            int midVal = strLength/2;

          
            for(int i = 0; i<midVal && result; i++)
            {
                if(normalizedStr[i] != normalizedStr[strLength-1-i])
                {
                    result = false;
                }
            }

            return result;
        }

        // Task 2.
        public static void PrintFooBar()
        {
            string el;
            for(int i = 1; i<=100; i++)
            {
                el = "";
                if(i%3 != 0 && i%5 != 0)
                {
                    el = i.ToString();
                }
                else
                {
                    if(i%3 == 0)
                    {
                        el = "Foo";
                    }
                    if(i%5 == 0)
                    {
                        el = el + "Bar";
                    }
                }

                Console.WriteLine(el);
            }
        }

        // Task 3.
        public static string ReplaceEmails(string initialText, string replaceWith = "")
        {
            var result = "";
            var emailPattern = @"\S+\@\S+\.[^\s\.\,\;\:\-]+";
            result = Regex.Replace(initialText, emailPattern, replaceWith);

            return result;
        }



        // Task 4 a.
        public static List<string> GenerateWordList(string initialWord)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";

            var asStringBuilder = new StringBuilder(initialWord);
            char[] asCharArr = initialWord.ToCharArray();

           
            var leng = initialWord.Length;

            var swapped = SwapLetters(asCharArr, leng);
            var deleted = DeleteLetters(initialWord, leng);
            var replaced = ReplaceLetters(asStringBuilder, leng,alphabet, asCharArr);
            var added = AddLetters(asStringBuilder, leng, alphabet, asCharArr);

            var result = new List<string>(swapped.Count + deleted.Count + replaced.Count + added.Count);
            result.AddRange(swapped);
            result.AddRange(deleted);
            result.AddRange(replaced);
            result.AddRange(added);

            return result;
        }


        /** Comment:
         * without full initial word I have no data to estimate how many repetitions will happen from swapping letters here
         * So result is just estimate of how many repetitions can be created from replacing letters        
         */        
        // Task 4 b.
        public static int CalculateWordRepetitions(int wordLenght, int alphabetLength = 26)
        {
            // delete, insert operations alone don't create repetitions
            // without inital word we cannot estimate how many repetitions can be created from swapping letters
            // we can estimate how many reptitions will be created from replacing letters, and that is the same as number of letters in word
            return wordLenght;
        }



        private static List<string> SwapLetters(char[] asCharArr, int length)
        {
            var swapped = new List<string>();

            for (int i = 0; i < length - 1; i++)
            {
                // only if letters are different
                if (asCharArr[i] != asCharArr[i + 1])
                {
                    var temp = asCharArr[i + 1];
                    asCharArr[i + 1] = asCharArr[i];
                    asCharArr[i] = temp;
                    swapped.Add(asCharArr.ToString());

                    // return array to previous state
                    temp = asCharArr[i + 1];
                    asCharArr[i + 1] = asCharArr[i];
                    asCharArr[i] = temp;
                }
            }

            return swapped;
        }

        private static List<string> DeleteLetters(string initialWord, int length )
        {
            var deleted = new List<string>();
            StringBuilder copy = new StringBuilder(initialWord);
            for (int i = 0; i < length-1; i++)
            {
                copy = new StringBuilder(initialWord);
                var newWord = copy.Remove(i, 1).ToString();
                deleted.Add( newWord );
            }

            return deleted;
        }

        private static List<string> ReplaceLetters(StringBuilder sb, int length, string alphabet, char[] asCharArr)
        {
            var replaced = new List<string>();

            for (int i = 0; i < length; i++)
            {
                foreach (var ch in alphabet)
                {
                    if (ch != asCharArr[i])
                    {
                        replaced.Add( sb.Replace(asCharArr[i], ch, i, 1).ToString());

                        // reset string back
                        sb.Replace(ch, asCharArr[i], i, 1);
                    }
                }
            }

            return replaced;
        }

        private static List<string> AddLetters(StringBuilder sb, int length, string alphabet, char[] asCharArr)
        {
            var added = new List<string>();

            for (int i = 0; i <= length; i++)
            {
                foreach (var ch in alphabet)
                {
                    added.Add(sb.Insert(i, ch.ToString()).ToString());
                    
                    // reset string
                    sb.Remove(i, 1);
                }

            }

            return added;
        }

    }
}
