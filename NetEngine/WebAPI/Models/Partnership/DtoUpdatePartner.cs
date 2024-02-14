namespace WebAPI.Models.Partnership
{
  public class DtoUpdatePartner
  {
    public long Id { get; set; }


    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 合作關係
    /// </summary>
    public int Relation { get; set; }

  }
}