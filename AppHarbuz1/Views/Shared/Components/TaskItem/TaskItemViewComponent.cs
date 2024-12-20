using Microsoft.AspNetCore.Mvc;
using AppHarbuz.Domain.Entities;

namespace AppHarbuz1.Views.Shared.Components.TaskItem
{
    public class TaskItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(TaskApp task)
        {
            return View(task);
        }
    }
}
