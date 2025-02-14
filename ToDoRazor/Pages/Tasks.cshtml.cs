using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ToDoRazor.Models;
using ToDoRazor.Services;

namespace ToDoRazor.Pages;

public class TasksListModel : PageModel
{
    private readonly TaskService _taskService;

    [BindProperty]
    public ToDoRazor.Models.Task newTask { get; set; } = default!;

    public IList<ToDoRazor.Models.Task> listTasks { get; set; } = default!;



    public TasksListModel(TaskService service)
    {
        _taskService = service;
    }

    public void OnGet()
    {
        listTasks = _taskService.GetTasks();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid || newTask == null)
        {
            return Page();
        }
        _taskService.AddTask(newTask);
        return RedirectToAction("Get");
    }

    public IActionResult OnPostDelete(int id)
    {
        _taskService.DeleteTask(id);
        return RedirectToAction("Get");
    }
}

