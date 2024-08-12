﻿namespace HabitTracker.WebUI.Models;

public class CreateHabitLogRequest
{
    #region Properties

    public Guid Id { get; private set; } = Guid.NewGuid();

    public Guid HabitId { get; set; }

    public DateTime Date { get; set; }

    public int Quantity { get; set; }

    #endregion
}
