using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Douche_Bot;

namespace TestConnIRC2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             botName = "Douche-Bot";
             port = 6667;
             server = "irc.chat.twitch.tv";
            */
            // infoConnect Bot = new  infoConnect("Douche-Bot", "irc.chat.twitch.tv", "oauth:ymm54b9x2zs48ofbx46x2ghxmt4dju");

            // "Douche-Bot", "irc.chat.twitch.tv", "oauth:ymm54b9x2zs48ofbx46x2ghxmt4dju"

            Console.WriteLine("Test Connexion twitch \n");
            IRCbot ircBot = new IRCbot(
                server: "irc.chat.twitch.tv",
                port: 6667,
                user: "azrav",
                nick: "Douche-Bot",
                channel: "#azrav",
                pass : "oauth:sd0b0jy7z99jeojhuzptgsn9m8yt64"
            );

            ircBot.Start();
            
            
            
        }
    }
}
