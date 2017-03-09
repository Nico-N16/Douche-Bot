using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Douche_Bot
{
    class Speaker
    {

        // server to connect to (edit at will)
        private readonly string server;
        // server port (6667 by default)
        private readonly int port;
        // user information defined 
        private readonly string user;
        // the bot's nickname
        private readonly string nick;
        // channel to join
        private readonly string channel;
        private string pass;
        private Shatter sha;
        private string BaseString;
        private string BanString;

        public Speaker(string server, int port, string user, string nick, 
                        string channel, string pass)
        {
            this.server = server;
            this.port = port;
            this.user = user;
            this.nick = nick;
            this.channel = channel;
            this.pass = pass;

            BaseString = ":" + nick + "!" + nick + "@" + nick +
                                     "tmi.twitch.tv PRIVMSG " + channel + " : ";
            BanString = ":" + nick + "!" + nick + "@" + nick +
                                        "tmi.twitch.tv ";
            sha = new Shatter();
            

        }

        /*
        ":" + _nick + "!" + _nick + "@" + _nick +
                                     "tmi.twitch.tv PRIVMSG " + _channel + " : " + botRep
        */
        private string BotTalk(string inputeLine) // ¯\_(ツ)_/¯
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

        // 0= test, 1=liens, 2=insultes
        public string CreatMsg(string inputLine, int phrase)
        {
            
            switch (phrase)
            {
                case 1: //test reaction Bot
                    return BaseString + BotTalk(inputLine);                 
                case 2: //TimeOut
                    return BanString + sha.TempBan(channel, inputLine);
                case 3: //Phrase TimeOut lien
                    return BaseString + " : " + sha.extractNom(inputLine) + 
                        ", les liens ne sont pas autorisé";
                case 4: //Phrase TimeOut insultes
                    return BaseString + " : Putain " + sha.extractNom(inputLine) +
                        ", on surveille son language !! ";
                default:
                    return BaseString + BotTalk(inputLine);
                   
            }
            
        }

    }
}
               