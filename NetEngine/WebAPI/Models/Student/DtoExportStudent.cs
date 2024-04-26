namespace WebAPI.Models.Student
{
  public class DtoExportStudent
  {
    /// <summary>
    /// 標示Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 生日
    /// </summary>
    public DateOnly Birthday { get; set; }

  }
}