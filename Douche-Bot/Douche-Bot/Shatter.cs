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


        public Shatter(String _inputLine)
        {
            // split the lines sent from the server by spaces (seems to be the easiest way to parse them)
            splitInput = _inputLine.Split(new Char[] { ' ' });
            inputeLine = _inputLine;
        }

        public string[] SplitInput { get { return splitInput; } }

        public string extractMessage()
        {
            message = "Rien n'as été extrait";

            buffer = inputeLine.Split(':');
            message = buffer[2];
            return message;
        }
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
            if (inputeLine.Contains(" suce "))
            {
                return "C'est ta soeur qui suce";
            }
            else
            {
                 return "yup ?";
            }
           
        }
       
        
       
    }//***

}

