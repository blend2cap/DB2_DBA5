using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace DB2_DBA5
{
    class Program
    {
        static int cont = 0;
        static void Main(string[] args)
        {

            const string dba2_path = @"C:\Users\blend\Desktop\Programming\DBA2_DBA5\DBA2.txt";
            const string dba5_path = @"C:\Users\blend\Desktop\Programming\DBA2_DBA5\DBA5.txt";
            const string report_path = @"C:\Users\blend\Desktop\Programming\DBA2_DBA5\report.txt";

            if (File.Exists(report_path))
            {
                File.Delete(report_path); 
            }
            string[] dba2_allLines = File.ReadAllLines(dba2_path);
            string[] dba5_allLines = File.ReadAllLines(dba5_path);

            List<Record> dba2_list = new List<Record>();
            List<Record> dba5_list = new List<Record>();

            
            for (int i = 0; i < dba2_allLines.Length; i++)
            {
                dba2_list.Add(Format_DB(dba2_allLines[i], i));
            }
            
            for (int i = 0; i < dba5_allLines.Length; i++)
            {
                dba5_list.Add(Format_DB(dba5_allLines[i], i));
            }
            var notPresentInDB5 = dba2_list.Except(dba5_list, new RecordComparer());
            foreach (var item in notPresentInDB5)
            {
                //Console.WriteLine(item.one);
                var formattedString = string.Format("{0,-40} {1,40}", item.one, item.row)+Environment.NewLine;
                File.AppendAllText(report_path, formattedString);
                cont++;
            }
            File.AppendAllText(report_path, Environment.NewLine+"Totale: "+cont.ToString());
            Console.WriteLine("Cont: {0}", cont);
            Console.ReadKey();
            System.Diagnostics.Process.Start(report_path);
        }


        private static Record Format_DB(string record, int row)
        {
            string[] splitted = Split(record);
            if (!splitted[0].Contains("#"))
            {
                var s = splitted;
                Record rec = new Record(s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7], row);

                if (rec.one.Equals(String.Empty)) rec.one = "vuoto";
                return rec;
            }
            return null;
        }

        private static string[] Split(string record)
        {
            char comma = ',';
            var line = Regex.Replace(record, @"[^u0000-u007F\s.+-]", "#"); //replace bad chars with #
            line = Regex.Replace(line, @"[a-z]", "#");
            line = Regex.Replace(line, @"\s+", ","); //insert commas in whitespaces
            string[] splitted = line.Split(comma);
            return splitted;
        }

    }
}
