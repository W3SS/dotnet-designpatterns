using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MvcDesignPattern.Core
{
    [Serializable]
    public class UploadedFile : IUploadedFile
    {
        public string FileName { get; set; }
        public long Size { get; set; }
        public string ContentType { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] FileContent { get; set; }

        public IUploadedFile Clone()
        {
            return (IUploadedFile)MemberwiseClone();
        }

        public IUploadedFile DeepCopy()
        {
            if (!GetType().IsSerializable)
                throw new ArgumentException("The object provided is not serializable");

            var formatter = new BinaryFormatter();
            var ms = new MemoryStream();
            formatter.Serialize(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            var deepcopy = (IUploadedFile)formatter.Deserialize(ms);
            ms.Close();
            return deepcopy;
        }
    }
}
