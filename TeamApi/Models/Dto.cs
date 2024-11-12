namespace TeamApi.Models
{
    public record CreatePlayerDto(string Name, int Height, int Weight);
    public record UpdatePlayerDto(string Name, int Weight);
}
