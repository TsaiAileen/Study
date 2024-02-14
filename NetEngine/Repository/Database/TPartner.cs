using Repository.Bases;

namespace Repository.Database;



/// <summary>
/// 贊助/合作商
/// </summary>
public class TPartner : CD
{

  /// <summary>
  /// 合作商名
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// 關係
  /// </summary>
  public int Relation { get; set; }

}
