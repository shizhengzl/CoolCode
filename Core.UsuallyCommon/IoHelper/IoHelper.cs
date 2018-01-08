using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class IoHelper
    {
        /// <summary>
        /// 替换字符串之间的类容
        /// </summary>
        /// <param name="oldchar"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ReplaceStartToEnd(string oldchar, string start, string end, string replace)
        {
            Int32 startidex = oldchar.IndexOf(start);
            Int32 endindex = oldchar.IndexOf(end);
            return oldchar.Replace(oldchar.Substring(startidex, endindex - startidex + 2), replace);

        }

        /// <summary>
        /// 读取字符串之间的类容
        /// </summary>
        /// <param name="oldchar"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ReadStartToEnd(string oldchar, string start, string end)
        {
            Int32 startidex = oldchar.IndexOf(start);
            Int32 endindex = oldchar.IndexOf(end);
            return oldchar.Substring(startidex + 2, endindex - startidex - 2);
        }

        /// <summary>
        /// 读取文件形成字符串
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <returns></returns>
        public static string FileReader(string Path)
        {
            StreamReader dvStreamReader = new StreamReader(Path, Encoding.GetEncoding("GB2312"));
            string result = dvStreamReader.ReadToEnd();
            dvStreamReader.Close();
            return result;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path">要写入的路径</param>
        /// <param name="content">要写入的内容</param>
        public static void WrireFile(string path, string content)
        {
            //StreamWriter writer = new FileInfo(path).CreateText();
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs, Encoding.GetEncoding("GB2312"));
            writer.Flush();
            writer.Write(content);
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// 覆盖文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public static void FileOverWrite(string path, string content)
        {

            StreamWriter writer = new StreamWriter(path, false, Encoding.GetEncoding("GB2312"));
            writer.Flush();
            writer.Write(content);
            writer.Close();

        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="Path">路劲</param>
        /// <param name="Content">内容</param>
        public static void CreateFile(string Path, string Content)
        {
            if (!System.IO.File.Exists(Path))
            {
                //StreamWriter sr = System.IO.File.CreateText(Path);
                FileStream fs = new FileStream(Path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("GB2312"));
                sw.Write(Content);
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 追加文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Content"></param>
        public static void AppendFile(string path, string Content)
        {
            if (!File.Exists(path))
            {
                FileInfo myfile = new FileInfo(path);
                FileStream fs = myfile.Create();
                fs.Close();
            }
            StreamWriter sw = File.AppendText(path);
            sw.WriteLine(Content);
            sw.Flush();
            sw.Close();
        }

        /// <summary>
        /// 追加方法 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="chr"></param>
        /// <param name="Count"></param>
        /// <param name="AppendContent"></param>
        public static string ReplaceToEndAndAppend(string Path, string chr, Int32 Count, string AppendContent)
        {
            string content = FileReader(Path);
            for (int i = 0; i < Count; i++)
            {
                content = content.Substring(0, content.LastIndexOf(chr));
            }

            for (int j = 0; j < Count; j++)
            {
                AppendContent += chr;
            }

            content += AppendContent;
            return content;
        }

        /// <summary>
        /// 追加方法 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="chr"></param>
        /// <param name="Count"></param>
        /// <param name="AppendContent"></param>
        public static string ReplaceToEndAndAppend_SET(string content, string chr, Int32 Count, string AppendContent)
        {

            for (int i = 0; i < Count; i++)
            {
                content = content.Substring(0, content.LastIndexOf(chr));
            }

            for (int j = 0; j < Count; j++)
            {
                AppendContent += chr;
            }

            content += AppendContent;
            return content;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
