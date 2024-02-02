namespace TaskService.Libraries {
  public class StudyHelper {


    public bool IsEvenNum(int vaule) 
    {

      int x = vaule % 2;

      if(x==0){
        return true;
      }
      else{
        return false;
      }
    }

  }
}