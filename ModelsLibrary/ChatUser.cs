using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ModelsLibrary
{
    [Serializable]
    /// <summary>
    /// This class represent chat user
    /// </summary>
    public class ChatUser
    {
        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Color TextColor { get; set; }

        private string _nickName = "Anonymous";
        public string NickName
        {
            get
            { return _nickName; }
            set
            { _nickName = value; }
        }

        //private string _avatarUrl;
        //public string AvatarUrl
        //{
        //    get
        //    { return _avatarUrl ?? ChatConfigProvider.DefaultAvatarUrl; }
        //    set
        //    { _avatarUrl = value; }
        //}
        #endregion

        public ChatUser()
        {
            Id = new Guid();
        }//default c-tor

        public ChatUser(string userName) : this(userName, "", null, Color.Black)
        {
        }

        public ChatUser(string userName, string nickName) : this(userName, nickName, null, Color.Black)
        {
        }

        public ChatUser(string userName, string nickName, string avatarUrl) : this(userName, nickName, avatarUrl, Color.Black)
        {
        }

        public ChatUser(string userName, string nickName, string avatarUrl, Color color) : this()
        {

            Name = userName;
            NickName = nickName;
            // AvatarUrl = avatarUrl;
            TextColor = color;
        }

        public ChatUser(string userName, Color color) : this(userName, "", null, color)
        {
        }

        public override string ToString()
        {
            return String.Format("User ID: {0}\nUser Name: {1}", Id, Name);
        }
    }//User
}
