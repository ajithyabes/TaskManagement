using TaskManagement.Data.Entities.Tables;
using TaskManagement.Data.Models.Request;

namespace TaskManagement.Data.Interface
{
    public interface ITaskManagementRepository
    {
        IQueryable<TaskItem> AddTaskItem(TaskItemRequest taskItemRequest);
        IQueryable<TaskItem> UpdateTaskItem(int id, string status);
        IQueryable<TaskItem> GetAllTask();
        IQueryable<TaskItem> GetTaskItemId(int id);
    }
}
