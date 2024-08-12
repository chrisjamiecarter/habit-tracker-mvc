﻿using HabitTracker.Application.Repositories;
using HabitTracker.Domain.Entities;

namespace HabitTracker.Application.Services;

public class HabitLogService : IHabitLogService
{
    private readonly IHabitLogRepository _repository;

    public HabitLogService(IHabitLogRepository repository)
    {
        _repository = repository;
    }

    public int AddHabitLog(HabitLog habitLog)
    {
        // If habit already has an entry for the date, then merge (increase the quantity).
        var existing = _repository.GetHabitLogByDate(habitLog.HabitId, habitLog.Date);
        if (existing is null)
        {
            return _repository.AddHabitLog(habitLog);

        }
        else
        {
            // Additional date instance. Merge.
            habitLog.Quantity += existing.Quantity;
            return _repository.UpdateHabitLog(habitLog);
        }
    }

    public int DeleteHabitLog(Guid id)
    {
        return _repository.DeleteHabitLog(id);
    }

    public HabitLog? GetHabitLog(Guid id)
    {
        return _repository.GetHabitLog(id);
    }

    public List<HabitLog> GetHabitLogs()
    {
        return _repository.GetHabitLogs();
    }

    public List<HabitLog> GetHabitLogs(Guid habitId)
    {
        return _repository.GetHabitLogs(habitId);
    }

    public List<HabitLog> GetHabitLogsByDateRange(DateTime from, DateTime to)
    {
        return _repository.GetHabitLogsByDateRange(from, to);
    }

    public List<HabitLog> GetHabitLogsByDateRange(Guid habitId, DateTime from, DateTime to)
    {
        return GetHabitLogsByDateRange(habitId, from, to);
    }

    public int UpdateHabitLog(HabitLog habitLog)
    {
        return _repository.UpdateHabitLog(habitLog);
    }

}
