using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Budget
{
    public partial class Form1 : Form
    {
        Form3 f3;
        public Form1()
        {
            InitializeComponent();
        }

        //【Form1が表示されたら発生するイベント】
        private void Form1_Shown(object sender, EventArgs e)
        {
            //月の取得
            var month = DateTime.Now.ToString("yyyyMM");
            //カテゴリー別合計金額表示
            SQL s = new SQL();
            List<string> sum = s.GetSum(month);
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

            //ListViewに今月の全出費表示
            listView1.Items.Clear();
            //出費をListViewに表示
            SQL s1 = new SQL();
            List<Expenditure> allList = s1.GetAllList(month);

            ListViewItem lvi;
            foreach (Expenditure exp in allList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【今月の全出費リンククリック】
        private void linkLabel0_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //出費をListViewに表示
            SQL s = new SQL();
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            List<Expenditure> allList = s.GetAllList(month);

            ListViewItem lvi;
            foreach (Expenditure exp in allList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【追加ボタンクリック】
        private void Button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this); // 自フォームへの参照を渡す
            f2.Show(); // サブ・フォームを表示
        }

        //【食費リンククリック】
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //食費をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> syokuhinList = s.GetList(1, month);

            ListViewItem lvi;
            foreach (Expenditure exp in syokuhinList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【外食リンククリック】
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //外食をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> gaisyokuList = s.GetList(2, month);

            ListViewItem lvi;
            foreach (Expenditure exp in gaisyokuList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【交通費リンククリック】
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //交通費をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> koutsuList = s.GetList(3, month);

            ListViewItem lvi;
            foreach (Expenditure exp in koutsuList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【日用品のリンククリック】
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //日用品をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> nitiList = s.GetList(4, month);

            ListViewItem lvi;
            foreach (Expenditure exp in nitiList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【遊びリンククリック】
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //遊びをListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> asobiList = s.GetList(5, month);

            ListViewItem lvi;
            foreach (Expenditure exp in asobiList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【洋服・美容リンククリック】
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //洋服・美容をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> biList = s.GetList(6, month);

            ListViewItem lvi;
            foreach (Expenditure exp in biList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【教養リンククリック】
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //教養をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> kyouyouList = s.GetList(7, month);

            ListViewItem lvi;
            foreach (Expenditure exp in kyouyouList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【家族リンククリック】
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //家族をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> kazokuList = s.GetList(8, month);

            ListViewItem lvi;
            foreach (Expenditure exp in kazokuList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【家賃・住まいリンククリック】
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //家族をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> ieList = s.GetList(9, month);

            ListViewItem lvi;
            foreach (Expenditure exp in ieList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【光熱費リンククリック】
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //光熱費をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> kounetsuList = s.GetList(10, month);

            ListViewItem lvi;
            foreach (Expenditure exp in kounetsuList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【保険リンククリック】
        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //保険をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> hokenList = s.GetList(11, month);

            ListViewItem lvi;
            foreach (Expenditure exp in hokenList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【税金リンククリック】
        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //税金をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> zeikinList = s.GetList(12, month);

            ListViewItem lvi;
            foreach (Expenditure exp in zeikinList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【その他リンククリック】
        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            listView1.Items.Clear();
            //その他をListViewに表示
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            SQL s = new SQL();
            List<Expenditure> sonotaList = s.GetList(13, month);

            ListViewItem lvi;
            foreach (Expenditure exp in sonotaList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

        //【リストボックスで選択したデータの削除】
        private void button3_Click(object sender, EventArgs e)
        {
            var month = dateTimePicker1.Value.ToString("yyyyMM");
            if (listView1.SelectedItems.Count > 0)
            {
                //削除したいデータのID
                var id = listView1.SelectedItems[0].Text;
                SQL s = new SQL();
                s.Delete(id);
                listView1.Items.Remove(listView1.SelectedItems[0]);

                //カテゴリー別合計金額表示
                SQL s1 = new SQL();
                List<string> sum = s1.GetSum(month);
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
                foreach (var a in sum)
                {
                    sum1 += int.Parse(a);
                }
                label18.Text = $"\\ {sum1}";
            }

        }

        //【編集ボタンクリック】
        private void button4_Click(object sender, EventArgs e)
        {
            f3 = new Form3();
            if (listView1.SelectedItems.Count > 0)
            {
                //リストでクリックしているデータのID取得
                var id = listView1.SelectedItems[0].Text;
                Form3 f3 = new Form3(this); // 自フォームへの参照を渡す
                //編集したいIDをForm3に渡す
                f3.label10.Text = id;               
                f3.Show(); // サブ・フォームを表示
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string month = dateTimePicker1.Value.ToString("yyyyMM");
            Console.WriteLine($"表示したいページは {month}");

            //カテゴリー別合計金額表示
            SQL s = new SQL();
            List<string> sum = s.GetSum(month);
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
            foreach (var a in sum)
            {
                sum1 += int.Parse(a);
            }
            label18.Text = $"\\ {sum1}";

            //ListViewに今月の全出費表示
            listView1.Items.Clear();
            //出費をListViewに表示
            SQL s1 = new SQL();
            List<Expenditure> allList = s1.GetAllList(month);

            ListViewItem lvi;
            foreach (Expenditure exp in allList)
            {
                lvi = listView1.Items.Add(exp.Id.ToString());
                lvi.SubItems.Add(exp.strDay());
                lvi.SubItems.Add(exp.Detail);
                lvi.SubItems.Add(exp.Money.ToString());
                lvi.SubItems.Add(exp.Payment);
                lvi.SubItems.Add(exp.Memo);
            }
        }

    }
}
