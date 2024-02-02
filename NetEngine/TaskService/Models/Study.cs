using COSXML.Model.Bucket;

namespace TaskService.Models{

  public class Study{

#region 整数类型

    public short S1  { get; set; }

    public int I1 { get; set; }

    public long Ld  { get; set; }

    #endregion

    public float Password  { get; set; }

    public double MobilePhone { get; set; }

    public decimal UserName {get;set;} 

    public string Nickname { get; set; }

    public bool  user_name  {get;set;}

    public DateTime Dx { get; set; }

    public DateTimeOffset DC  { get; set; }

    public DateOnly Dxx { get; set; }

    public TimeOnly Tx { get; set; }

    public TimeSpan TxT  { get; set; }

    public Guid Id { get; set; } 

  }

}