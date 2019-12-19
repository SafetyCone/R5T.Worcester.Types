using System;

using R5T.Magyar.IO;


namespace R5T.Worcester
{
    public static class BinaryFileSerializer
    {
        public static T Deserialize<T>(string binaryFilePath)
        {
            using (var fileStream = FileStreamHelper.NewRead(binaryFilePath))
            {
                var output = BinaryStreamSerializer.Deserialize<T>(fileStream);
                return output;
            }
        }

        public static void Serialize<T>(string binaryFilePath, T value, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(binaryFilePath, overwrite))
            {
                BinaryStreamSerializer.Serialize(fileStream, value);
            }
        }
    }


    public class BinaryFileSerializer<T> : StreamFileSerializer<T>
    {
        public BinaryFileSerializer()
            : base(new BinaryStreamSerializer<T>())
        {
        }
    }
}
