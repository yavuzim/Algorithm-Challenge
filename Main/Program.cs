using System;
using System.Collections.Generic;
namespace Main
{
    class Program
    {
        public static (List<string>, List<string>) UsernameControl(List<string> usernames)
        {
            List<string> yesNo = new List<string>();
            List<string> degistirilen = new List<string>();
            for (int i = 0; i < usernames.Count; i++)
            {
                string username = usernames[i];
                Random rnd = new Random();
                int[] indis = new int[2];
                for (int k = 0; k < 2; k++)
                    indis[k] = rnd.Next(0, username.Length);
                int indis0, indis1;
                indis0 = indis[0];
                indis1 = indis[1];

                string[] freeUsername = new string[username.Length];
                for (int j = 0; j < username.Length; j++)
                    freeUsername[j] = username[j].ToString();
                char a;
                a = char.Parse(freeUsername[indis0]);
                freeUsername[indis0] = freeUsername[indis1];
                freeUsername[indis1] = a.ToString();
                string kullanici = "";
                foreach (string p in freeUsername)
                    kullanici += p;
                degistirilen.Add(kullanici);
                string[] yesNocontrol = { kullanici, username };
                Array.Sort(yesNocontrol);
                if (yesNocontrol[0] == kullanici)
                    yesNo.Add("YES");
                else
                    yesNo.Add("NO");
            }
            return (yesNo, degistirilen);
        }
        static void Main(string[] args)
        {
            int usernameCount = 1;
            string degerTip = usernameCount.GetType().Name;
            while (degerTip == "Int32" || usernameCount < 0)
            {
                Console.Write("Kullanıcı Adı Adedi: ");
                usernameCount = Convert.ToInt32(Console.ReadLine());
                if (usernameCount >= 0)
                    break;

            }
            List<string> usernames = new List<string>();
            for (int i = 0; i < usernameCount; i++)
            {
                Console.Write((i + 1) + ". kullanıcı adı: ");
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            List<string> usernameControl = new List<string>();
            List<string> usernameControl1 = new List<string>();
            (usernameControl, usernameControl1) = UsernameControl(usernames);
            Console.WriteLine();
            Console.WriteLine("Girilen Kullanıcı Adları");
            foreach (string item in usernames)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine();
            foreach (string item in usernameControl1)
                Console.Write(item + " ");
            Console.WriteLine();
            Console.WriteLine();
            foreach (string item in usernameControl)
                Console.Write(item + " ");
            Console.ReadLine();
        }
    }
}
