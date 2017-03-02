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

            if (inputeLine.Contains("??"))
            {
                return "ok";
            }
            else
            { 

                return "grr";
            }
           
        }
        public string extractNom(String MsgIn)
        {
            
            string UserName = MsgIn;

            this.userName = UserName.Split('!', '@')[1];

            return userName;
        }
        // methode permettant de parser chaque mot d'une chaine et verifier si une url existe
        public bool censure(String MsgIn)
        {
            
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
                     
                     return buff;
                 }
              //  Console.WriteLine("debug : "+MsgIn.Split(' ')[i].TrimStart(':'));

            }
            if(inputeLine.Contains(".com") || inputeLine.Contains(".fr") || 
               inputeLine.Contains(".net") || inputeLine.Contains(".biz")  ||
               inputeLine.Contains(".org") || inputeLine.Contains(".en")
               )
            {
                return false;
            }
            return buff;
                
        }

        public string TempBan(string channel, string MsgIn)
        {

           return (" PRIVMSG "+channel+" : .timeout " + extractNom(MsgIn) + " 5");
        }

        public bool BadWord(String theChaine)
        {
            bool Bad = false;
            String[] find = new String[] {
            "nique", "niquer","encule","enculer","enculé", "foutre","batar","batard","bâtard","biatch",
            "bite","bougnoul","bougnoule","bouffon","bounioul","branleur","branler","couille","couilles",
            "chiennasse","con","conar","connar","conard","connard","conasse","conase","ducon","merde",
            "emmerde","emmerder","emmerdeur","emmerdeuse","pute","putain","bordel","fdp","fiotte","garce",
            "gouine","merdeux","negre","pd",
        };
            int longueur = find.Length;
            int i = 0;

            while (i < longueur)
            {
                if (theChaine.IndexOf(find[i], StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
    }//***



}//***



