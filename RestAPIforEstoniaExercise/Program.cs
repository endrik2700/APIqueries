using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace RestAPIforEstoniaExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.Headers.Add("content-type", "application/x-www-form-urlencoded");
            Uri downLoadSite = new Uri("https://restcountries.eu/rest/v2/name/eesti");
            // string info = client.DownloadString(downLoadSite);
            string[] uriParts = new string[] { downLoadSite.Segments[0], downLoadSite.Segments[1], downLoadSite.Segments[2], downLoadSite.Segments[3], downLoadSite.Segments[4] };
            string name = uriParts[4];
            Stream stream = client.OpenRead(downLoadSite);
            StreamReader sReader = new StreamReader(stream);
            string dataFromtheStream = sReader.ReadToEnd();

            stream.Close();
            sReader.Close();
            
            List<string> Estonia = dataFromtheStream.Split(",").ToList();
            Console.WriteLine(dataFromtheStream);

            string[] temp = Estonia[3].Split(":");
            string cioc = temp[1];

            string domain = Estonia[1].Substring(Estonia[1].IndexOf("."),3);
            string capital = Estonia[5].Substring(Estonia[5].IndexOf(":") + 2).Trim('"');
            string region = Estonia[10].Substring(Estonia[10].IndexOf(":") + 2).Trim('"'); 
            string population = Estonia[12].Substring(Estonia[12].IndexOf(":") + 2).Trim('"'); 
            string language = Estonia[28].Substring(Estonia[28].IndexOf(":") + 2).Trim('"'); ;

           
            Console.WriteLine($" The country's name is: {name}");
            Console.WriteLine($" The cioc is: {cioc}");
            Console.WriteLine($" The domain is: {domain}");
            Console.WriteLine($"The capital of Estonia is: {capital}");
            Console.WriteLine($"The region of Estonia is: {region}"); 
            Console.WriteLine($"The population of Estonia is: {population}");
            Console.WriteLine($"The language of Estonia is: {language.ToLower()}");
           // Console.WriteLine(language);


            //Console.WriteLine(i);
          //  temp[i + 1] = Estonia[1].Split(":").ToString();
         
            
      

         
        }
    }
}
