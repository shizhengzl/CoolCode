using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class DirectoryFileHelper
    {
        public static bool IsFindFile(string floder, string file)
        {
            string newFilePath = FindMatchFile(floder, file);
            if (string.IsNullOrEmpty(newFilePath))
            {
                return false;
            }
            if ((newFilePath.GetFileName() + newFilePath.GetFileExtension()) == file)
                return true;
            return false;
        }

        public static string FindMatchFile(string floder, string file)
        {
            List<string> fileList = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(floder);
            FileInfo[] chldFiles = folder.GetFiles("*.*");
            foreach (FileInfo chlFile in chldFiles)
            {
                fileList.Add(chlFile.FullName);
            }
            DirectoryInfo[] chldFolders = folder.GetDirectories();
            foreach (DirectoryInfo chldFolder in chldFolders)
            {
                GetFiles(chldFolder.FullName, fileList);
            }
            string[] items = SearchHelper.Search(file, fileList.ToArray());
            return items.Count() > 0 ? items[0] : string.Empty;
        }

        private static void GetFiles(string filePath, List<string> fileList)
        {
            if (!System.IO.Directory.Exists(filePath))
                return;
            DirectoryInfo folder = new DirectoryInfo(filePath);
            FileInfo[] chldFiles = folder.GetFiles("*.*");
            foreach (FileInfo chlFile in chldFiles)
            {
                fileList.Add(chlFile.FullName);
            }
            DirectoryInfo[] chldFolders = folder.GetDirectories();
            foreach (DirectoryInfo chldFolder in chldFolders)
            {
                GetFiles(chldFolder.FullName, fileList);
            }
        }
    }
}
