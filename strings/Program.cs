using System;

namespace strings
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Here are some examples");
            Console.WriteLine("\nTask 1:\nPlease enter string to check if it is palindrome:");
            var inputStr = Console.ReadLine();

            var isPalindrome = StringUtils.IsPalindrome(inputStr);
            Console.WriteLine("Is your string palindrome? " + (isPalindrome ? "yes" : "no"));

            Console.WriteLine("Task 2:\nPrint FooBar");
            StringUtils.PrintFooBar();

            Console.WriteLine("\nTask 3:\nPlease enter text for which email addresses need to be removed (if you press Enter, default text will be used):");
            inputStr = Console.ReadLine();
            if (string.IsNullOrEmpty(inputStr))
            {
                inputStr = "Christian has the email address christian+123@gmail.com.\nChristian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com.\nJohn's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk.\nHer Twitter handle is @kira.cavebrown.";
            }
            var res = StringUtils.ReplaceEmails(inputStr);
            Console.WriteLine("Text after change:\n" + res);

            Console.WriteLine("\nTask 4:\nEnter word for which you want to find variations:");
            inputStr = Console.ReadLine();

            var wordList = StringUtils.GenerateWordList(inputStr);
            Console.WriteLine("Following list of words was created for word '" + inputStr + "':");
            foreach(var el in wordList)
            {
                Console.WriteLine(el);
            }



            Console.ReadKey();

        }
    }
}
