using System.ComponentModel.DataAnnotations;

namespace ToDoRazor.Models;

public class Task
{
    public int Id { get; set; }

    [Required]
    public string? TaskName { get; set; }
    public bool Completed { get; set; } = false;
}