using NUnit.Framework;
using PhotoResizer;
using PhotoResizer.ViewModels.Repository;
using PhotoResizer.ViewModels;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NUnitPhotoResizer
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateModelComponent()
        {
            Component component = new Component("Name", "Image");
            Assert.AreEqual(component.Image, "Image");
            Assert.AreEqual(component.Name, "Name");
        }
        [Test]
        public void CreateModelComponentAreNull()
        {
            Component component = new Component(null, null);
            Assert.AreEqual(component.Image, null);
            Assert.AreEqual(component.Name, null);
        }
        [Test]
        public void CreateModelFileAreNull()
        {
            string name = "name";
            File file = new File(name, null, null, name);
            Assert.AreEqual(file.FileName, name);
            Assert.AreEqual(file.FileStream, null);
            Assert.AreEqual(file.Mini, null);
            Assert.AreEqual(file.FileNameFull, name);
        }

        [Test]
        public void CreateModelFile()
        {
            string name = "name";
            var requiredPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))) + @"\File\test.jpg";
            System.IO.Stream stream = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            System.IO.FileStream fs = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test2.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            File file = new File(name, fs, stream, name);
            stream.Close();
            fs.Close();
            Assert.AreEqual(file.FileName, name);
            Assert.AreEqual(file.FileStream, fs);
            Assert.AreEqual(file.Mini, stream);
        }
        [Test]
        public void AddingFileToFileRepository()
        {
            string name = "name";
            var requiredPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))) + @"\File\test.jpg";
            System.IO.Stream stream = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            System.IO.FileStream fs = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test2.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            File file = new File(name, fs, stream, name);
            FileRepository files = new FileRepository();
            files.Files.Add(file);
            stream.Close();
            fs.Close();
            Assert.IsTrue(files.Files.Count > 0);
            Assert.AreEqual(files.Files[0], file);
        }

        [Test]
        public void RemoveFileFromFileRepository()
        {
            string name = "name";
            var requiredPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))) + @"\File\test.jpg";
            System.IO.Stream stream = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            System.IO.FileStream fs = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test2.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            File file = new File(name, fs, stream, name);
            FileRepository files = new FileRepository();
            files.Files.Add(file);
            stream.Close();
            fs.Close();
            Assert.IsTrue(files.Files.Count > 0);
            files.RemoveFile(file.FileName);
            Assert.IsTrue(files.Files.Count == 0);
        }

        [Test]
        public void ClearFilesFromFileRepository()
        {
            string name = "name";
            var requiredPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))) + @"\File\test.jpg";
            System.IO.Stream stream = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            System.IO.FileStream fs = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test2.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            File file = new File(name, fs, stream, name);
            FileRepository files = new FileRepository();
            files.Files.Add(file);
            stream.Close();
            fs.Close();
            Assert.IsTrue(files.Files.Count > 0);
            files.ClearAll();
            Assert.IsTrue(files.Files.Count == 0);
        }

        [Test]
        public void CurrentIndexInFileRepository()
        {
            string name = "name";
            var requiredPath = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase))) + @"\File\test.jpg";
            System.IO.Stream stream = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            System.IO.FileStream fs = System.IO.File.Open(@"C:\Users\piotr\source\repos\PhotoResizer\NUnitPhotoResizer\File\test2.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Write, System.IO.FileShare.None);
            File file = new File(name, fs, stream, name);
            FileRepository files = new FileRepository();
            files.Files.Add(file);
            stream.Close();
            fs.Close();
            Assert.IsTrue(files.Files.Count > 0);
            Assert.AreEqual(files.CurrentIndex(file.FileName), 0);
        }
    }
}