namespace Carvices.API.Exceptions
{
    [Serializable]
    internal class UserIdNotFoundException : Exception
    {

        public UserIdNotFoundException() : base("User id was not found with request")
        {
        }
    }
}