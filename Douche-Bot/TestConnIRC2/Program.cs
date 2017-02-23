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
<<<<<<< HEAD
                user: "azrav",
                nick: "Douche-Bot",
                channel: "#azrav",
                pass : "oauth:sd0b0jy7z99jeojhuzptgsn9m8yt64"
=======
                user: "D0uch3_Bot",
                nick: "Douche-Bot",
                channel: "#altha_n16",
                //pass : "oauth:ymm54b9x2zs48ofbx46x2ghxmt4dju"
                pass: "oauth:05v40d9igfy7qs6f0b2eooczrfbveu"
>>>>>>> e03971461f2f0c7c5b319f2211e146ff605bcf46
            );

            ircBot.Start();
            
            
            
        }
    }
}
