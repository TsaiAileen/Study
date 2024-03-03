namespace WebAPI.Models.Student
{
  public class DtoEditStudent
  {

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