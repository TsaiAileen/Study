namespace WebAPI.Models.Student
{
  public class DtoUpdateStudent
  {
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