using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP_POST_LIBRARY
{
    public class GenericUtils
    {
        public interface IScann
        {
            Task<List<String>> ScannALL(Task<List<string>> tasks,object tag);
            void CreatePost(Task<List<string>>[] data,object[] progressBar,List<string> name);
        }
        public static List<List<string>> generateEmbed(List<List<String>> lists,List<string> name,int episode)
        {
            List<List<string>> data = new List<List<string>>();
            for(int i =0;i<episode;i++)
            {
                List<string> ep = new List<string>();
                for (int j=0;j<name.Count;j++)
                {
                    ep.Add($"[{name[j]} id='{lists[j][i]}']");
                }
                data.Add(ep);
            }
            return data;
        }
        public static string Checksimiliarity(string jdlA,List<string> listJdl)
        {
            List<Tuple<string, decimal>> data = new List<Tuple<string, decimal>>();
            foreach (string jdlB in listJdl)
            {
                Decimal similiar = 0;
                char[] a = jdlA.ToCharArray(), b = jdlB.ToCharArray();
                int length = (a.Length > b.Length) ? b.Length : a.Length;
                for (int i = 0; i < length; i++)
                {
                    if (a[i] == b[i])
                    {
                        similiar++;
                    }
                }
                similiar = (similiar * 100) / length;
                if (similiar > 75)
                {
                    data.Add(new Tuple<string, decimal>(jdlB, similiar));
                }
            }
            string anime = "";
            if (data.Count > 0)
            {
               anime = data.Find(x => x.Item2 == data.Max(z => z.Item2)).Item1;
            }
            else
            {
                anime = "Not Found";
            }
            return anime;
        }
    }
}
