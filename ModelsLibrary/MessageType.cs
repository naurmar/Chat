namespace ModelsLibrary
{
    public delegate void UpdateViewHandler(ChatMessage msg);
    public enum MessageType
    {
        Private,
        BroadCast,
        Close,
        ValidationError,
        RegistrationError,
        Accept,
        LogIn,
        LogOut
    }//MessageType
}