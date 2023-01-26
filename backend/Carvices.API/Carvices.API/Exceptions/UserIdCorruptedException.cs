namespace Carvices.API.Exceptions
{
    [Serializable]
    internal class UserIdCorruptedException : Exception
    {
        public UserIdCorruptedException() : base("User id is corrupted")
        {
        }
    }
}