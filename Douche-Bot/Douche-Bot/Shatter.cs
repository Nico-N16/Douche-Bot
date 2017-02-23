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
            if (inputeLine.Contains("?Douche-Bot"))
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
            else { return "grr"; }


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

        public bool censure(String MsgIn)
        {

          //  Uri uriResult;
          //  bool result = Uri.TryCreate(MsgIn, UriKind.Absolute, out uriResult)
          //      && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (MsgIn.Contains("http://") ||
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
            }
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
            "gouine","merdeux","negre",
        };
        int longueur = find.Length;
        // bool isBad = false;
       // String replace = " ***** ";
        int i = 0;
        while( i < longueur) {
            if (theChaine.Contains(find[i]))
                {
                    Bad = true;
                }
            i++;
        }
        return Bad;
    }
    }//***


}

