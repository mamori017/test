using System;
using System.IO;
using System.Text;

namespace Common
{
    public static class IO
    {
        public static bool DirectoryCheck(string directoryPath, bool makeDir = false)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    if (makeDir)
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public enum EncodeType
        {
            utf8,
            sjis
        }

        public static bool CreateTextFile(string filePath, string fileName, string outputString, bool append = true, EncodeType encode = EncodeType.utf8)
        {

            String outputFilePath = "";
            Encoding objEncoding = null;
            StreamWriter objWriter = null;

            try
            {
                DirectoryCheck(filePath, true);

                if (filePath.Substring(filePath.Length - 1) != "\\")
                {
                    outputFilePath = filePath + "\\" + fileName;
                }
                else
                {
                    outputFilePath = filePath + fileName;
                }

                if (encode == EncodeType.sjis)
                {
                    objEncoding = Encoding.GetEncoding(932);
                }
                else
                {
                    objEncoding = Encoding.UTF8;
                }

                objWriter = new StreamWriter(outputFilePath, append, objEncoding);

                objWriter.Write(outputString);

                objWriter.Close();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objEncoding = null;
                objWriter = null;
            }
        }

    }
}
