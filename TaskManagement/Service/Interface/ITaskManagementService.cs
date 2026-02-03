using TaskManagement.Data.Entities.Tables;
using TaskManagement.Data.Models.Request;

namespace TaskManagement.Service.Interface
{
    public interface ITaskManagementService
    {
        IEnumerable<TaskItem> GetAllTaskItems();
        IEnumerable<TaskItem> GetTaskItemById(int id);
        IEnumerable<TaskItem> AddTaskItem(TaskItemRequest taskItemRequest);
        IEnumerable<TaskItem> UpdateTaskItem(int id, string status);
    }
}
