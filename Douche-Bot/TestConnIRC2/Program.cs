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
        // infoConnect Bot = new  infoConnect("Douche-Bot", "irc.chat.twitch.tv", "oauth:ymm54b9x2zs48ofbx46x2ghxmt4dju");

            // "Douche-Bot", "irc.chat.twitch.tv", "oauth:ymm54b9x2zs48ofbx46x2ghxmt4dju"

            Console.WriteLine("Test Connexion twitch \n");
            IRCbot ircBot = new IRCbot(
                server: "irc.chat.twitch.tv",
                port: 6667,
                user: "altha_n16",
                nick: "Douche-Bot",
                channel: "#altha_n16",
                pass : "oauth:ymm54b9x2zs48ofbx46x2ghxmt4dju"
            );

            ircBot.Start();
            
        }
    }
}
