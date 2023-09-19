﻿using System.Text.Json;

namespace Entities.LogModel;

public class LogDetails
{
    public object? ModelName { get; set; }
    public object? Controller { get; set; }
    public object? Action { get; set; }
    public object? Id { get; set; }
    public object? CreateAt { get; set; }

    public LogDetails()
    {
        CreateAt = DateTime.UtcNow;
    }

    public override string ToString() => JsonSerializer.Serialize(this);
}
