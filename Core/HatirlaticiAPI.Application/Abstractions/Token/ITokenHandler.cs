namespace HatirlaticiAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.TokenDTO CreateAccessToken(int second);
        string CreateRefreshToken();
    }
}
