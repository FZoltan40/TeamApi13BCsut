namespace TeamApi.Models;

public partial class Data
{
    public Guid Id { get; set; }

    public DateTime? InCourt { get; set; }

    public DateTime? OutCourt { get; set; }

    public int? Try { get; set; }

    public int? Goal { get; set; }

    public int? Fault { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public Guid? PlayerId { get; set; }

    public virtual Player? Player { get; set; }
}
