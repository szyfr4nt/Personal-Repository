﻿using AutoMapper;
using WebApi2Book.Common;
using WebApi2Book.Data.Exceptions;
using WebApi2Book.Data.QueryProcessors;
using WebApi2Book.Web.Api.Models;

namespace WebApi2Book.Web.Api.MaintenanceProcessing
{
    public class CompleteTaskWorkflowProcessor : ICompleteTaskWorkflowProcessor
    {
        private readonly IMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;
        public CompleteTaskWorkflowProcessor(ITaskByIdQueryProcessor taskByIdQueryProcessor,
        IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor, IMapper autoMapper,
        IDateTime dateTime)
        {
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
            _autoMapper = autoMapper;
            _dateTime = dateTime;
        }
        public Task CompleteTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }
            // Simulate some workflow logic...
            if (taskEntity.Status.Name != "In Progress")
            {
                throw new BusinessRuleViolationException(
                "Incorrect task status. Expected status of 'In Progress'.");
            }
            taskEntity.CompletedDate = _dateTime.UtcNow;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "Completed");
            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }
    }
}