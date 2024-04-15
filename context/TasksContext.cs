using Microsoft.EntityFrameworkCore;
using API_TAREFAS.entities;
namespace API_TAREFAS.context{
public class TasksContext:DbContext{
    public TasksContext(DbContextOptions<TasksContext> options):base(options){

    }
    public DbSet<Tasks> Tasks{get;set;}
}




}