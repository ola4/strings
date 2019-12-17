using System;

namespace strings
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var res = StringUtils.ReplaceEmails("Christian has the email address christian+123@gmail.com.\nChristian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com.\nJohn's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk.\nHer Twitter handle is @kira.cavebrown.");
            Console.WriteLine(res);

            Console.ReadKey();

        }
    }
}
