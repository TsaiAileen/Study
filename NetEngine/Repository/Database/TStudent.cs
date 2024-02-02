using Repository.Bases;

namespace Repository.Database;



/// <summary>
/// 學生紀錄表
/// </summary>
public class TStudent : CD
{

  /// <summary>
  /// 姓名
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// 年齡
  /// </summary>
  public int Age { get; set; }

  /// <summary>
  /// 生日
  /// </summary>
  public DateOnly Birthday { get; set; }


}
