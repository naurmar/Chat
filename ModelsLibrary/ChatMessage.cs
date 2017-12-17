using System;
using System.Drawing;

namespace ModelsLibrary
{
    /// <summary>
    /// This class represent message between client and server
    /// </summary>
    [Serializable]
    public class ChatMessage
    {
        #region Properties
        public MessageType Type { get; set; }
        public Color TextColor { get; set; }
        public string[] Sender { get; set; }

        private string[] _recipient = new string[] { string.Empty, string.Empty };
        public string[] Recipient
        {
            get { return _recipient; }
            set { _recipient = value; }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private DateTime _sentDate;
        public DateTime SentDate
        {
            get { return _sentDate; }
            set { _sentDate = value; }
        }

        #endregion

        public ChatMessage()
        {
            Sender = new string[2];
            Recipient = new string[2];
            SentDate = DateTime.Now;
            Type = MessageType.BroadCast;
        }//default c-tor

        public ChatMessage(string[] sender, string[] recipient, string text, Color color) : this(sender, text, color)
        {
            Recipient = recipient;
            Type = MessageType.Private;
        }//c-tor

        public ChatMessage(string[] sender, string text, Color color) : this()
        {
            Sender = sender;
            TextColor = color;
            Text = text;
        }//c-tor

        public ChatMessage(ChatUser user, string text) : this(new string[] { user.Id.ToString(), user.Name }, text, user.TextColor)
        {
        }//c-tor

        public ChatMessage(ChatUser user, string[] recipient, string text) : this(new string[] { user.Id.ToString(), user.Name }, recipient, text, user.TextColor)
        {
        }//c-tor

        public override string ToString()
        {
            //  return string.Format("From: {0} {1} ", Sender[1], Text);
            return $"Sent from: {Sender[1]}  {Text}";
        }
    }//ChatMessage
}
