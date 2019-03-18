using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amazing_Bash
{
    class Program
    {
        static void Main(string[] args)
        {
            string road = "";
            Console.Write("\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------AMAZİNG BASH------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n" +
                          "\t\t\t\t\t\t------------------------------------\n");
            string path = @"C:/Users/" + Environment.UserName + "/Desktop/UserInfoAmazingBash.txt";
            Directory.CreateDirectory("C:/Users/" + Environment.UserName + "/Desktop/diary");
            if (!File.Exists(path))
            {
                Console.Write("Please write your username :");
                string username = Console.ReadLine();
                TextWriter tw = new StreamWriter(path);
                tw.WriteLine(username);
                Console.Write("Please write your password :");
                string pass = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);
                tw.WriteLine(pass);
                tw.Close();
            }
            else
            {
                Console.Write("Please write your username :");
                string username = Console.ReadLine();
                Console.Write("Please write your password :");
                string pass = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        pass += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                        {
                            pass = pass.Substring(0, (pass.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                } while (true);
                string[] lines = System.IO.File.ReadAllLines(@"C:/Users/" + Environment.UserName + "/Desktop/UserInfoAmazingBash.txt");
                if (lines[0].Equals(username) && lines[1].Equals(pass))
                {
                    Console.Write("\nWelcome to amazing bash. If you need help please write --help\n");
                    string command = "";
                    while (!command.Equals("exit"))
                    {
                        Console.Write(username + ">>>");
                        command = Console.ReadLine();
                        if (command.Equals("clear"))
                        {
                            Console.Clear();
                        }
                        else if (command.Equals("--help"))
                        {
                            Console.WriteLine("Here is the things which amazing bash can do.\n");
                            Console.Write("ip\n - Shows your ip address.\n");
                            Console.Write("time\n - Shows your computer running time.\n");
                            Console.Write("sbr\n - It gives you a divided entry.\n");
                            Console.Write("reverse\n - It reverse your entry.\n");
                            Console.Write("bunny\n - It shows website ip address.\n");
                            Console.Write("diary\n - You can write a diary. It will be complete secure.\n\n");
                            Console.Write("tr\n - Show files");
                        }
                        else if (command.Equals("sbr"))
                        {
                            Console.Write("please write your sbr word :");
                            string sbrwrd = Console.ReadLine();
                            string sub = "";
                            for (int i = 0; i < sbrwrd.Length; i++)
                            {
                                sub += sbrwrd[i] + " ";
                            }
                            Console.WriteLine(sub);
                            Console.WriteLine();
                        }
                        else if (command.Equals("reverse"))
                        {
                            Console.Write("Please Write your word :");
                            string word = Console.ReadLine();
                            string holder = "";
                            for (int i = word.Length - 1; i >= 0; i--)
                            {
                                holder += word[i];
                            }
                            Console.WriteLine(holder);
                        }
                        else if (command.Equals("time"))
                        {
                            using (var uptime = new PerformanceCounter("System", "System Up Time"))
                            {
                                uptime.NextValue();
                                Console.WriteLine(TimeSpan.FromSeconds(uptime.NextValue()));
                                Console.WriteLine();
                            }
                        }
                        else if (command.Equals("ip"))
                        {
                            string hostName = Dns.GetHostName();
                            Console.WriteLine(hostName);
                            string myIP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
                            Console.WriteLine("My IP Address is :" + myIP);
                            Console.WriteLine();
                        }
                        else if (command.Equals("bunny"))
                        {
                            Console.Write("Please write url for getting ip address :");
                            string host = Console.ReadLine();
                            string response = "";
                            if (GetIPAddress(host).Equals(""))
                            {
                                Console.WriteLine("There is no such a thing.");
                            }
                            else
                            {
                                response = GetIPAddress(host).ToString();
                                Console.WriteLine(response);
                            }
                        }
                        else if (command.Equals("diary"))
                        {
                            Console.Write("please write name of file :");
                            string name = Console.ReadLine();
                            try
                            {
                                string road1 = @"C:/Users/" + Environment.UserName + "/Desktop/diary/" + name + ".txt";
                                Console.Write("Please write what happened in your life :\n");
                                string content = Console.ReadLine();
                                TextWriter tw = new StreamWriter(road1);
                                tw.Write(content);
                                tw.Close();
                                Console.WriteLine("Saved Succesfully.");
                            }
                            catch
                            {
                                Console.Write("Please change name of file");
                            }
                        }

                        else if (command.Equals("tr"))
                        {
                            Console.Write("If you want a create file please write 'add' inside command line. If you write extension of file you " +
                                "can create that file with extension. If you need help please write --help.");
                            string inside_command = "tr";
                            string holder = "";

                            //string[] files = Directory.GetFiles(@"C:/", "*.xml", SearchOption.AllDirectories);    Show all directories.
                            string[] array1 = Directory.GetDirectories(@"C:/" + road + "");
                            Console.WriteLine("--- Files: ---");
                            foreach (string name in array1)
                            {
                                Console.WriteLine(name);
                            }
                            while (!inside_command.Equals("quit"))
                            {

                                Console.Write("\nCommand :");
                                inside_command = Console.ReadLine();
                                if (inside_command.Equals("in"))
                                {
                                    Console.Write("Please write file name which you want to go in :");
                                    road += Console.ReadLine() + "/";
                                    try
                                    {
                                        array1 = Directory.GetDirectories(@"C:/" + road + "");
                                        holder = inside_command;
                                        foreach (string name in array1)
                                        {
                                            Console.WriteLine(name);
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Error in file name");
                                        road = "";
                                        array1 = Directory.GetDirectories(@"C:/" + road + "");
                                        holder = inside_command;
                                        foreach (string name in array1)
                                        {
                                            Console.WriteLine(name);
                                        }
                                    }
                                }
                                else if (inside_command.Equals("create folder"))
                                {
                                    Console.Write("Please write your folder name :");
                                    string name_of_folder = Console.ReadLine();
                                    Directory.CreateDirectory(@"C:" + road + "/" + name_of_folder + "");
                                }
                                else if (inside_command.Equals("create file"))
                                {
                                    Console.Write("Please write your file name :");
                                    string name_of_file = Console.ReadLine();
                                    string create_file_path = @"C:/" + road + "/" + name_of_file + ".txt";
                                    TextWriter tw = new StreamWriter(create_file_path);
                                    Console.Write("What do you want to write inside your file :\n\n");
                                    string text = Console.ReadLine();
                                    tw.Write(text);
                                    tw.Close();
                                    Console.Write("saved succesfully.");

                                }
                                else if (inside_command.Equals("out"))
                                {
                                    road = "";
                                    array1 = Directory.GetDirectories(@"C:/");
                                    foreach (string name in array1)
                                    {
                                        Console.WriteLine(name);
                                    }
                                }
                                else if (inside_command.Equals("clear"))
                                {
                                    Console.Clear();
                                    Console.WriteLine("--- Files: ---");
                                    foreach (string name in array1)
                                    {
                                        Console.WriteLine(name);
                                    }
                                }
                                else if (inside_command.Equals("show"))
                                {
                                    Console.Clear();
                                    Console.WriteLine("--- Files: ---");
                                    foreach (string name in array1)
                                    {
                                        Console.WriteLine(name);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\n\n\nFail.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
        }
        //getting ip website ip address
        public static string GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            try
            {
                var replay = ping.Send(hostName);
                if (replay.Status == IPStatus.Success)
                {
                    return replay.Address.ToString();
                }
            }
            catch
            {
                return "";
            }
            return "";
        }
    }
}