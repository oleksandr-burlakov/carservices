namespace Carvices.API.Exceptions
{
    [Serializable]
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User not found")
        {
        }
    }
}