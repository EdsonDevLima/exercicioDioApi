using API_TAREFAS.context;
using API_TAREFAS.entities;
using Microsoft.AspNetCore.Mvc;


namespace API_TAREFAS.controllers{


[ApiController]
[Route("[controller]")]
public class TasksController:ControllerBase{
    private readonly TasksContext _context;
    public TasksController(TasksContext context){
        _context = context;
    }
[HttpGet("{id}")]
public IActionResult GetById(int id){
    
    var task = _context.Tasks.Find(id);
    if(task == null){
      return  NotFound(new {mesage = "Tarefa nao encontrada"});
    }
        return Ok(task);

    
}
[HttpPut("{id}")]
public IActionResult UpdateTask(int id,Tasks task){
var oldTask = _context.Tasks.Find(id);
if(oldTask == null){
    return NotFound(new {message = "task nao encontrada"});
}
    return Ok(new {message = "usuario atualizado"});




}
[HttpDelete("{id}")]
public IActionResult RemoveTask(int id){
    var task = _context.Tasks.Find(id);
if(task == null){
    return NotFound(new {message = "task nao encontrada"});
}
   _context.Tasks.Remove(task);
   _context.SaveChanges();
   return Ok(new {message = "Task Excluida"});
}
[HttpGet("getAll")]
public IActionResult GetAllTaks(){
    var allTasks = _context.Tasks.ToList();
    return Ok(allTasks);
}
[HttpGet("getByTittle")]
public IActionResult GetByTittle(string Tittle){
var tasksByTitile = _context.Tasks.Where(taks => taks.Tittle.Contains(Tittle));
if(tasksByTitile == null){
    return NotFound(new {message = "nao existe tarefas com esse titulo"});
}
    return Ok(tasksByTitile);

}
[HttpGet("getByDate")]
public IActionResult GetByTittle(DateTime date){
var tasksByTitile = _context.Tasks.Where(task => task.Date.Date == date.Date);
if(tasksByTitile == null){
    return NotFound(new {message = "nao existe tarefas com esse horario"});
}
    return Ok(tasksByTitile);

}
[HttpGet("getByStatus")]
public IActionResult GetByStatus(StatusTask status){
    var taskByStatus = _context.Tasks.Where(task => task.Status == status);
    if(taskByStatus == null){
        return NotFound(new {message = "nao existe tarefas com esse status"});
    }
    return Ok(taskByStatus);
}

[HttpPost]
public IActionResult CreateTask(Tasks task){

    
    
        _context.Add(task);
        _context.SaveChanges();
        return Ok(new {message = "task criada"});
   

}














}






}