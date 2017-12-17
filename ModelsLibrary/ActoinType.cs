using System;

namespace ModelsLibrary
{

    public delegate void ChatErrorHendler(Exception ex,ChatErrorEventArgs arg);
   // public delegate void ClientValidationHandler(string name);

    public enum ActionType
    {
        Add,
        Remove,
        Create,
        LogIn,
        LogOut
    }
}
