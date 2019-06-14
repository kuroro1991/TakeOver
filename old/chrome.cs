using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Threading;

class OpenChrome {
    public static void Main() {
        string apl_path = @".\resource\apl_path.csv";
        string file_path = @".\resource\file_path.csv";
        // List<string> apl_lists = new List<string>();
        var apl_lists = new Dictionary<string, string>();
        List<string> file_lists = new List<string>();

        // string chrome = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
        // string ie = @"C:\Program Files (x86)\Internet Explorer\iexplore.exe";
        // string script = "wscript.exe";
        // string teraterm = @"C:\Program Files (x86)\teraterm\ttermpro.exe";
        // string explorer = @"C:\Windows\explorer.exe";

        // ファイル読み込み(apl_path.txt)
        StreamReader sr_apl = new StreamReader(apl_path, Encoding.GetEncoding("SHIFT_JIS"));
        StreamReader sr_file = new StreamReader(file_path, Encoding.GetEncoding("SHIFT_JIS"));

        int apl_index = 0;
        Console.WriteLine("***** APL LIST *****");

        while(sr_apl.EndOfStream == false) {
            // 一行読み込み
            string apl_line = sr_apl.ReadLine();
            // 先頭2文字が"//"のものはコメントとして除外
            if(apl_line.Substring(0, 2) != "//") {
                // apl_lists.Add(apl_line);
                // Console.WriteLine("apl_lists[{0}]: {1}", apl_index, apl_lists[apl_index]);
                string[] temp = apl_line.Split(',');
                apl_lists.Add(temp[0], temp[1]);
                
                // Console.WriteLine("[{0}], [{1}]", temp[0], temp[1]);
                apl_index++;
           }
        }

        foreach(KeyValuePair<string, string> item in apl_lists) {
            Console.WriteLine("[{0}:{1}]", item.Key, item.Value);
        }

        Console.WriteLine();
        sr_apl.Close();

        // Console.WriteLine("Key:" + apl_lists["chrome"]);
        // System.Diagnostics.Process.Start(apl_lists["chrome"]);
        // System.Diagnostics.Process.Start(apl_lists["ie"]);

        int file_index = 0;
        Console.WriteLine("***** FILE LIST *****");

        while(sr_file.EndOfStream == false) {
            // 一行読み込み
            string file_line = sr_file.ReadLine();
            // 先頭2文字が"//"のものはコメントとして除外
            if(file_line.Substring(0, 2) != "//") {
                //file_lists.Add(file_line);
                //Console.WriteLine("file_lists[{0}]: {1}", file_index, file_lists[file_index]);
                string[] temp = file_line.Split(',');

                if(temp[0] == "ie") {
                    Console.WriteLine("ERROR: Unsupported");
                }
                else {
                    Console.WriteLine("OK: " + temp[0]);
                    System.Diagnostics.Process.Start(apl_lists[temp[0]], temp[1]);
                }
                file_index++;
            }
        }
        sr_file.Close();




        // MessageBox.Show("Chrome");
        // System.Diagnostics.Process.Start(chrome, "http://google.com");
        // System.Diagnostics.Process.Start(chrome, "https://www.youtube.com/?hl=ja&gl=JP");
        // Thread.Sleep(500);

        // MessageBox.Show("IE");
        // System.Diagnostics.Process.Start(script, @"C:\Users\kuroro\Desktop\ie_run.vbs");
        // System.Diagnostics.Process.Start(ie, )
        // Thread.Sleep(500);

        // MessageBox.Show("TeraTerm");
        // System.Diagnostics.Process.Start(teraterm);

        // System.Diagnostics.Process.Start(explorer, @"C:\Windows");
    }
}