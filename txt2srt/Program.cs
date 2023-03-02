namespace txt2srt
{
    internal class Program
    {
        public static List<IdozitettFelirat> IdoFelirat_ls = new();

        static void Main(string[] args)
        {
            FileStream fs = new FileStream("..\\..\\..\\src\\feliratok.txt", FileMode.Open);
            var sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                IdoFelirat_ls.Add(new IdozitettFelirat(sr.ReadLine(), sr.ReadLine()));
            }
            fs.Close();
            sr.Close();
            Console.WriteLine($"5. feladat - Feliratok száma: {IdoFelirat_ls.Count}");
            int maxszavak = int.MinValue;
            string maxfelirat = "";
            for (int i = 0; i < IdoFelirat_ls.Count; i++)
            {
                if (maxszavak < IdoFelirat_ls[i].SzavakSzama)
                {
                    maxszavak = IdoFelirat_ls[i].SzavakSzama;
                    maxfelirat = IdoFelirat_ls[i].Felirat;
                }
            }
            Console.WriteLine($"7. feladat - Legtöbb szóból álló felirat:\n{maxfelirat}"); ;
            FileStream fs2 = new FileStream(@"felirat.srt", FileMode.Create);
            var sw = new StreamWriter(fs2);
            int sz = 0;
            foreach (var i in IdoFelirat_ls)
            {
                sz++;
                sw.WriteLine($"{sz}\n{i.SrtIdozites}\n{i.Felirat}\n");
            }
            sw.Close();
            fs2.Close();
        }
    }
}