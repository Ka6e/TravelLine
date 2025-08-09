﻿namespace CarFactory.UI.Commands
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
    }
}
