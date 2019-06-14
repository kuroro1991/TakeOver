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
        var apl_lists = new Dictionary<string, string>();
        List<string> file_lists = new List<string>();

        string vbscript = @".\resource\ie_run_kai.vbs";

        // ファイル読み込み(apl_path.txt)
        StreamReader sr_apl = new StreamReader(apl_path, Encoding.GetEncoding("SHIFT_JIS"));
        StreamReader sr_file = new StreamReader(file_path, Encoding.GetEncoding("SHIFT_JIS"));

        Console.WriteLine("***** APL LIST *****");

        while(sr_apl.EndOfStream == false) {
            // 一行読み込み
            string apl_line = sr_apl.ReadLine();
            // 先頭2文字が"//"のものはコメントとして除外
            if(apl_line.Substring(0, 2) != "//") {
                string[] temp = apl_line.Split(',');
                apl_lists.Add(temp[0], temp[1]);
           }
        }

        // アプリリスト表示
        foreach(KeyValuePair<string, string> item in apl_lists) {
            Console.WriteLine("[{0}]: {1}", item.Key, item.Value);
        }

        Console.WriteLine();
        sr_apl.Close();

        Console.WriteLine("***** FILE LIST *****");

        while(sr_file.EndOfStream == false) {
            // 1行読み込み
            string file_line = sr_file.ReadLine();
            // 先頭2文字が"//"のものはコメントとして除外
            if(file_line.Substring(0, 2) != "//") {
                string[] temp = file_line.Split(',');

                if(temp[0] == "ie") {
                    Console.WriteLine("[{0}] {1}", temp[0], temp[1]);
                    System.Diagnostics.Process.Start(vbscript, temp[1]);
                    Thread.Sleep(1000);
                }
                else {
                    Console.WriteLine("[{0}] {1}", temp[0], temp[1]);
                    System.Diagnostics.Process.Start(apl_lists[temp[0]], temp[1]);
                }
            }
        }
        sr_file.Close();

    }
}