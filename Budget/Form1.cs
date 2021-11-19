using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;// MySQLを使用
using System.Collections.ObjectModel;

namespace Budget
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Form1が表示されたら発生するイベント
        private void Form1_Shown(object sender, EventArgs e)
        {
            //年月の表示
            label2.Text = DateTime.Now.ToString("yyyy年MM月");
            //食費の合計金額表示
            SQL s = new SQL();
            List<string> sum = s.GetSum();
            label5.Text = $"\\ {sum[0]}";
            label6.Text = $"\\ {sum[1]}";
            label7.Text = $"\\ {sum[2]}";
            label8.Text = $"\\ {sum[3]}";
            label9.Text = $"\\ {sum[4]}";
            label10.Text = $"\\ {sum[5]}";
            label11.Text = $"\\ {sum[6]}";
            label12.Text = $"\\ {sum[7]}";
            label13.Text = $"\\ {sum[8]}";
            label14.Text = $"\\ {sum[9]}";
            label15.Text = $"\\ {sum[10]}";
            label16.Text = $"\\ {sum[11]}";
            label17.Text = $"\\ {sum[12]}";

            //合計金額を出す
            int sum1 = 0;
            foreach(var a in sum)
            {
                sum1 += int.Parse(a);
            }
            label18.Text = $"\\ {sum1}";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //食費をListViewに表示
            SQL s = new SQL();
            List<Expenditure> syokuhinList = s.GetSyokuhi();



            /*
            foreach (Expenditure exp in syokuhinList)
            {
                //データが取得できているか
                string[] a = exp.DataStr();
                Console.Write(a[0]);
                Console.Write(a[1]);
                Console.Write(a[2]);
                Console.Write(a[3]);
                Console.Write(a[4]);
                Console.WriteLine(a[5]);
                //listViewに表示
                listView1.Items.Add(new ListViewItem(a));
            }
            */
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this); // 自フォームへの参照を渡す
            f2.Show(); // サブ・フォームを表示
        }
    }
}
