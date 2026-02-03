using Microsoft.AspNetCore.Http.HttpResults;
using TaskManagement.Data.Entities.Tables;
using TaskManagement.Data.Interface;
using TaskManagement.Data.Models.Request;
using TaskManagement.Service.Interface;

namespace TaskManagement.Service.Implementation
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly ITaskManagementRepository _taskManagementRepository;
        public TaskManagementService(ITaskManagementRepository taskManagementRepository) 
        {
            _taskManagementRepository = taskManagementRepository;
        }

        public IEnumerable<TaskItem> GetAllTaskItems()
        {
            return _taskManagementRepository.GetAllTask();
        }

        public IEnumerable<TaskItem> GetTaskItemById(int id)
        {
            return _taskManagementRepository.GetTaskItemId(id);
        }

        public IEnumerable<TaskItem> AddTaskItem(TaskItemRequest taskItemRequest)
        {
            taskItemRequest.Status = "Pending";
            return _taskManagementRepository.AddTaskItem(taskItemRequest);
        }

        public IEnumerable<TaskItem> UpdateTaskItem(int id, string status)
        {
            var existingTask = _taskManagementRepository.GetTaskItemId(id);

            if(existingTask !=  null)
            {
                switch(existingTask!.FirstOrDefault()!.Status)
                {
                    case "Pending":
                        if(status != "InProgress")
                        {
                            throw new InvalidOperationException("Invalid Status passed");
                        }
                        break;
                    case "InProgress":
                        if (status != "Completed")
                        {
                            throw new InvalidOperationException("Invalid Status passed");
                        }
                        break;
                    case "Completed":
                            throw new InvalidOperationException("Cannot update the complted task");
                }
            }

            return _taskManagementRepository.UpdateTaskItem(id, status);
        }
    }
}
