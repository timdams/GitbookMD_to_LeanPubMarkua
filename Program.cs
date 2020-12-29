using System;
using System.Collections.Generic;
using System.IO;

namespace leanpubprepper
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = DirSearch(Environment.CurrentDirectory);
            foreach (var f in files)
            {
                string text = File.ReadAllText(f);
                int start = -1;
                do
                {
                    start = text.IndexOf("<!---NOBOOKSTART--->");
                    int end = text.IndexOf("<!---NOBOOKEND--->") + "<!---NOBOOKEND--->".Length;
                    if (start != -1)
                        text = text.Remove(start, end - start);
                } while (start != -1);
   
                text = text.Replace("{% hint style='danger' %}", "{blurb, class: warning}");
                text = text.Replace("{% hint style='warning' %}", "{blurb, class: warning}");
                text = text.Replace("{% hint style='tip' %}", "{blurb, class: tip}");
                text = text.Replace("{% endhint %}", "{/blurb}" + Environment.NewLine);
                

                text = text.Replace("<!---", "");
                text = text.Replace("--->", "");

                File.WriteAllText(f, text);


            }
        }

        private static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir, "*.md"))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }

            return files;
        }
    }

}
