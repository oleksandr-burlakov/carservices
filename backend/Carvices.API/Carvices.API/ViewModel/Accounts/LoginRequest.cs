namespace Carvices.API.ViewModel.Accounts
{
    public record LoginRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
