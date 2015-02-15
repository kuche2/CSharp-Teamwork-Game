using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class FileReadWrite
    {
        public static string fileResults;
        public static string path;

        public static void getPath()
        {
            path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        }

        public void FileReadWriteMain(string filename)
        {
            getPath();
            if(!File.Exists(path+filename))
            {
                create(filename);
            }
        }

        public static void create(string filename = null)
        {
            if(filename != null)
            {
                fileResults = filename;
            }
            FileInfo f = new FileInfo(fileResults);
            f.Create();
        }

        public static void write(string content)
        {
            FileInfo f = new FileInfo(fileResults);
            StreamWriter w = f.AppendText();
            w.WriteLine(content);
            w.Close();
        }

        public static string read()
        {
            FileInfo f = new FileInfo(fileResults);
            StreamReader w = f.OpenText();
            string content = w.ReadToEnd();
            return content;
        }
    }
}
