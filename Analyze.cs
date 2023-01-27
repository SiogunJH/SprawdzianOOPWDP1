using System;
using System.Collections.Generic;

namespace Sprawdzian
{
    class Zadanie1
    {
        public static void Analyze(string rawLogs)
        {
            string[] logs = rawLogs.Split('\n');

            Dictionary<string, SortedSet<string>> UsersIP = new Dictionary<string, SortedSet<string>>();

            foreach (string log in logs)
            {
                string[] logData = log.Split(' ');

                string user = logData[2];
                string ip = logData[3];

                if (!UsersIP.ContainsKey(user))
                {
                    UsersIP[user] = new SortedSet<string>();
                }

                if (!UsersIP[user].Contains(ip))
                {
                    UsersIP[user].Add(ip);
                }
            }

            List<string> UserOneIP = new List<string>();

            foreach (var user in UsersIP)
            {
                if (user.Value.Count == 1)
                {
                    UserOneIP.Add(user.Key);
                }
            }

            UserOneIP.Sort();
            UserOneIP.Reverse();

            if (UserOneIP.Count == 0)
                Console.WriteLine("empty");
            else
                Console.WriteLine(string.Join(", ", UserOneIP));

        }
    }
}