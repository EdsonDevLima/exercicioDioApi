namespace API_TAREFAS.entities{
   public enum StatusTask{Done,InProgress,Pending}
    public  class Tasks{
      public int Id{get;set;}
      public string Tittle{get;set;}
      public string Description {get;set;}
      public DateTime Date{get;set;}
      public StatusTask  Status {get;set;} 


    
}






}