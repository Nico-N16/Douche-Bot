using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Douche_Bot
{
    public class Shatter
    {

        private string[] splitInput;
        private string inputeLine;
        private string message;
        private string[] buffer;
        private string userName;


        public Shatter(String _inputLine)
        {
            // split the lines sent from the server by spaces (seems to be the easiest way to parse them)
            splitInput = _inputLine.Split(new Char[] { ' ' });
            inputeLine = _inputLine;
        }

        public string[] SplitInput { get { return splitInput; } }


        public bool BotCall( string inputeLine)
        {
            if (inputeLine.Contains("??"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string BotTalk () // ¯\_(ツ)_/¯
        {
            //mystring.Contains(myStringToCheck, StringComparison.OrdinalIgnoreCase);

            if (inputeLine.Contains(" suce ") || inputeLine.Contains(" Suce "))
            {
                return "C'est ta soeur qui suce ¯\\_(ツ)_/¯";
            }
            
           /* if(inputeLine.Contains("yolo", StringComparison.OrdinalIgnoreCase))
            {

            }*/
            else {
    
                return "grr";
            }


        }
        public string extractNom(String MsgIn)
        {
            /*
            string input = "User name (sales)";
            string output = input.Split('(', ')')[1];
            */
            string UserName = MsgIn;

            this.userName = UserName.Split('!', '@')[1];

            return userName;
        }
        // methode permettant de parser chaque mot d'une chaine et verifier si une url existe
        public bool censure(String MsgIn)
        {
            bool res = false;
            bool buff = false;
            string debug;
            for(int i = 1; i< MsgIn.Split(' ').Length; i++)
            {
                 buff = Uri.IsWellFormedUriString(
                         MsgIn.Split(' ')[i].TrimStart(':'),
                     UriKind.Absolute);
                 debug = MsgIn.Split(' ')[i];

                 if (buff == true)   
                 {
                     res = true;
                     return res;
                 }
                Console.WriteLine("debug : "+MsgIn.Split(' ')[i].TrimStart(':'));

            }
            return res;
                



            /*
             string test1 = "www.google.com";
               string test2 = "gateau.yolo";
                string buff1 = "false";
                string buff2 = "false";

                if (Uri.IsWellFormedUriString(test1, UriKind.RelativeOrAbsolute))
                    {
                    buff1 = "true";
                   }
                if (Uri.IsWellFormedUriString(test2, UriKind.RelativeOrAbsolute))
                    {
                    buff1 = "true";
                }


                Console.WriteLine("test 1" + buff1 + " // test2 "+ buff2);
            */


            /*if (MsgIn.Contains("http://") ||
                MsgIn.Contains("https://") ||
                MsgIn.Contains("www.") ||
                MsgIn.Contains(".com") ||
                MsgIn.Contains(".fr") ||
                MsgIn.Contains(".en") ||
                MsgIn.Contains(".org") ||
                MsgIn.Contains(" twitch.tv"))
           
            {
                // return (" PRIVMSG #CHANNEL : .timeout "+extractNom(MsgIn)+" 5");
                return true;
            }

            // PRIVMSG #CHANNEL :.timeout USERNAME 600
            // /timeout <username> [seconds]

            else
            {
                return false;
            }*/
        }

        public string TempBan(string channel, string MsgIn)
        {

           return (" PRIVMSG "+channel+" : .timeout " + extractNom(MsgIn) + " 5");
        }
           
        
       
        
       
    }//***

}

