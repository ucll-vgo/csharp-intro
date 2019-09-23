using System;
using Xunit;

namespace FileSystemExercise
{
    public class UnitTest
    {
        private MockFileSystem fs = new MockFileSystem();

        [Fact]
        public void SingleFileCreation()
        {
            var counter = new ChangedFilesCounter(fs);
            fs.CreateFile("a");

            Assert.Equal(1, counter.ChangeCount);
        }

        [Fact]
        public void SingleFileWrite()
        {
            var counter = new ChangedFilesCounter(fs);
            fs.WriteFile("a");

            Assert.Equal(1, counter.ChangeCount);
        }

        [Fact]
        public void SingleFileDeletion()
        {
            var counter = new ChangedFilesCounter(fs);
            fs.DeleteFile("a");

            Assert.Equal(1, counter.ChangeCount);
        }

        [Fact]
        public void SameFileCountsAsOne()
        {
            var counter = new ChangedFilesCounter(fs);
            fs.WriteFile("a");
            fs.DeleteFile("a");

            Assert.Equal(1, counter.ChangeCount);
        }

        [Fact]
        public void TwoDifferentFiles()
        {
            var counter = new ChangedFilesCounter(fs);
            fs.WriteFile("a");
            fs.CreateFile("b");

            Assert.Equal(2, counter.ChangeCount);
        }

        [Fact]
        public void NoChanges()
        {
            var counter = new ChangedFilesCounter(fs);

            Assert.Equal(0, counter.ChangeCount);
        }

        [Fact]
        public void ThriceSameFile()
        {
            var counter = new ChangedFilesCounter(fs);
            fs.CreateFile("x");
            fs.WriteFile("x");
            fs.DeleteFile("x");

            Assert.Equal(1, counter.ChangeCount);
        }
    }

    public class MockFileSystem : IFileSystem
    {
        public void CreateFile(string path)
        {
            FileCreated?.Invoke(path);
        }

        public void WriteFile(string path)
        {
            FileWritten?.Invoke(path);
        }

        public void DeleteFile(string path)
        {
            FileDeleted?.Invoke(path);
        }

        public event Action<string> FileCreated;

        public event Action<string> FileWritten;

        public event Action<string> FileDeleted;
    }
}
