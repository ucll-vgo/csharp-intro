using System;


namespace FileSystemExercise
{
    public interface IFileSystem
    {
        event Action<string> FileCreated;

        event Action<string> FileWritten;

        event Action<string> FileDeleted;
    }
}