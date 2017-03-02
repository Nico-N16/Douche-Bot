using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Douche_Bot
{
    public class IRCbot
    {
        // server to connect to (edit at will)
        private readonly string _server;
        // server port (6667 by default)
        private readonly int _port;
        // user information defined in RFC 2812 (IRC: Client Protocol) is sent to the IRC server 
        private readonly string _user;

        // the bot's nickname
        private readonly string _nick;
        // channel to join
        private readonly string _channel;

        private string _pass;
        private StreamWriter outputStream;
        private StreamReader inputStream;

        private readonly int _maxRetries;

        public IRCbot(string server, int port, string user, string nick, string channel,string pass, int maxRetries = 3)
        {
            _server = server;
            _port = port;
            _user = user;
            _nick = nick;
            _channel = channel;
            _pass = pass;
            _maxRetries = maxRetries;
        }


        public void Start()
        {


            var retry = false;
            var retryCount = 0;
            bool con = false;
            do
            {
                try
                {
                    using (var irc = new TcpClient(_server, _port))
                    using (var stream = irc.GetStream())
                    using (var reader = new StreamReader(stream))
                    using (var writer = new StreamWriter(stream))
                    {
                
                        writer.Write("PASS " + _pass + "\n");
                        writer.Flush();
                        writer.Write("NICK " + _user + "\n");
                        writer.Flush();
                       
                        while (true)
                        {
                           

                            string inputLine;
                            int compteur = 0;
                            while ((inputLine = reader.ReadLine()) != null)
                            {

                                Console.WriteLine("¯\\_(o.O)_/¯ " + inputLine);

                               
                                Shatter shatter = new Shatter(inputLine);
                                string[] splitInput = shatter.SplitInput;


                                if (splitInput[0] == "PING")
                                {
                                    string PongReply = splitInput[1];                            
                                    writer.WriteLine("PONG " + PongReply);
                                    writer.Flush();
                                    
                                }

                                    // vérification si le bot est applé
                                    if (shatter.BotCall(inputLine) == true)
                                    {
                                    string botRep = shatter.BotTalk();

                                    writer.WriteLine(":" + _nick + "!" + _nick + "@" + _nick +
                                     "tmi.twitch.tv PRIVMSG " + _channel + " : " + botRep);
                                     writer.Flush();
                                    Console.WriteLine("User : \n"
                                        + shatter.extractNom(inputLine));
                                    }
                                if (shatter.BadWord(inputLine) == true)
                                {
                                    shatter.TempBan(_channel, inputLine);

                                    writer.WriteLine(":" + _nick + "!" + _nick + "@" + _nick +
                                    "tmi.twitch.tv " + shatter.TempBan(_channel, inputLine));
                                    writer.Flush();
                                    Console.WriteLine("test ban");

                                    writer.WriteLine(":" + _nick + "!" + _nick + "@" + _nick +
                                    "tmi.twitch.tv PRIVMSG " + _channel + " : "
                                    + shatter.extractNom(inputLine) + ", les insulteeeees Bordel ! ");
                                    writer.Flush();
                                }
                                    //Ban temporaire si lien trouvé
                                    if(shatter.censure(inputLine))
                                    {
                                    shatter.TempBan(_channel, inputLine);

                                        writer.WriteLine(":" + _nick + "!" + _nick + "@" + _nick +
                                        "tmi.twitch.tv "+ shatter.TempBan(_channel, inputLine));
                                        writer.Flush();
                                        Console.WriteLine("test ban");

                                        writer.WriteLine(":" + _nick + "!" + _nick + "@" + _nick +
                                        "tmi.twitch.tv PRIVMSG " + _channel + " : " 
                                        + shatter.extractNom(inputLine) + ", les liens ne sont pas autorisé");
                                        writer.Flush();

                                    } 
                                

                                switch (splitInput[1])
                                {
                                    case "001":
                                        writer.WriteLine("JOIN " + _channel);
                                        writer.Flush();
                                        con = true;
                                        break;
  
                                    default:
                                        break;
                                }

                            

                                compteur++;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    // shows the exception, sleeps for a little while and then tries to establish a new connection to the IRC server
                    Console.WriteLine(e.ToString());
                    Thread.Sleep(5000);
                    retry = ++retryCount <= _maxRetries;
                }
            } while (retry);
        }

        


    }
}
