using Microsoft.EntityFrameworkCore;
using System;
using TaskManagement.Data.Entities.DBContext;
using TaskManagement.Data.Entities.Tables;
using TaskManagement.Data.Interface;
using TaskManagement.Data.Models.Request;

namespace TaskManagement.Data.Implementation
{
    public class TaskManagementRepository : ITaskManagementRepository
    {
        public AppDbContext _context;

        public TaskManagementRepository(AppDbContext context) 
        { 
            _context = context;
        }
              
        public IQueryable<TaskItem> AddTaskItem(TaskItemRequest taskItemRequest)
        {
            if (taskItemRequest == null) throw new ArgumentNullException(nameof(taskItemRequest));

            var taskItem = new TaskItem
            {
                Title = taskItemRequest.Title!,
                Description = taskItemRequest.Description!,
                Status = taskItemRequest.Status!,
                Priority = taskItemRequest.Priority!,
                CreatedAt = DateTime.UtcNow
            };
            _context.TaskItems.Add(taskItem);
            _context.SaveChanges();

            int currentID = _context.TaskItems.Max(x => x.ID);
            return GetTaskItemId(currentID);
        }

        public IQueryable<TaskItem> UpdateTaskItem(int id, string status)
        {
            if (id == 0 || status == null) throw new ArgumentNullException(nameof(id));

            var currentData = _context.TaskItems.Where(x => x.ID == id).FirstOrDefault();
            if (currentData == null) throw new ArgumentNullException(nameof(id));

            currentData.Status = status;

            _context.TaskItems.Update(currentData);

            _context.SaveChanges();

            return GetTaskItemId(id);
        }

        public IQueryable<TaskItem> GetAllTask()
        {
            return _context.TaskItems;
        }

        public IQueryable<TaskItem> GetTaskItemId(int id)
        {
            return _context.TaskItems.Where(x => x.ID == id);
        }

    }
}
