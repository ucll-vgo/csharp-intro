using System;


namespace Exercise
{
    public interface IFileSystem
    {
        event Action<string> FileCreated;

        event Action<string> FileWritten;

        event Action<string> FileDeleted;
    }
}