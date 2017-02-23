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

        public void sendIrcMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
        }

        public void sendChatMessage(string message)
        {
            sendIrcMessage(":" + _user + "!" + _user + "@" + _user + ".tmi.twitch.tv PRIVMSG #" + _channel + ":" + message);
        }

        public string readMessage()
        {
            string message = inputStream.ReadLine();
            return message;
        }
       


        public void Start()
        {


            var retry = false;
            var retryCount = 0;
            do
            {
                try
                {
                    using (var irc = new TcpClient(_server, _port))
                    using (var stream = irc.GetStream())
                    using (var reader = new StreamReader(stream))
                    using (var writer = new StreamWriter(stream))
                    {
                        //writer.WriteLine("NICK " + _nick);
                        //writer.WriteLine("NICK " + _user);
                        writer.Write("PASS " + _pass + "\n");
                        
                       // writer.WriteLine("PASS " + _pass + " NICK " + _nick);
                      //  writer.WriteLine("NICK " + _user + " PASS " + _pass);

                        writer.Flush();
                      writer.Write("NICK " + _user + "\n");
                        writer.Flush();

                        while (true)
                        {
                           

                            string inputLine;
                            while ((inputLine = reader.ReadLine()) != null)
                            {
                                Console.WriteLine("<- " + inputLine);
                                if (inputLine.Contains("!hello"))
                                {
                                    writer.WriteLine(":" + _user + "!" + _user + "@" + _user + ".tmi.twitch.tv PRIVMSG " + _channel + " :Sacrebleu !");
                                    writer.Flush();
                                }
                                // split the lines sent from the server by spaces (seems to be the easiest way to parse them)
                                string[] splitInput = inputLine.Split(new Char[] { ' ' });

                                if (splitInput[0] == "PING")
                                {
                                    string PongReply = splitInput[1];
                                    //Console.WriteLine("->PONG " + PongReply);
                                    writer.WriteLine("PONG " + PongReply);
                                    writer.Flush();
                                    //continue;
                                }

                                switch (splitInput[1])
                                {
                                    case "001":
                                        writer.WriteLine("JOIN " + _channel);
                                        writer.Flush();
                                        break;
                                    default:
                                        break;
                                }
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
