﻿namespace ToDoLite.Core.Contracts
{
    public interface ISettings
    {
        bool ShowCompleted { get; set; }
        bool CloseToTray { get; set; }
        bool MinimizeToTray { get; set; }
    }
}