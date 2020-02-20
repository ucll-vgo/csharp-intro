using System;
using System.Collections.Generic;
using FileSystemExercise;

namespace Solution
{
    public class ChangedFilesCounter
    {
        private HashSet<string> files;

        public ChangedFilesCounter(IFileSystem fs)
        {
            this.files = new HashSet<string>();

            fs.FileCreated += OnFileModified;
            fs.FileDeleted += OnFileModified;
            fs.FileWritten += OnFileModified;
        }

        public int ChangeCount => files.Count;

        private void OnFileModified(string path)
        {
            files.Add(path);
        }
    }
}
