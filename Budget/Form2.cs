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

namespace Budget
{
    public partial class Form2 : Form
    {
        Form1 f1;

        public Form2(Form1 f)
        {
            f1 = f; // メイン・フォームへの参照を保存
            InitializeComponent();
        }

        //登録ボタンクリック
        private void Button1_Click(object sender, EventArgs e)
        {
            var day = dateTimePicker1.Value;    //購入日
            var category = comboBox1.SelectedItem.ToString();   //カテゴリー
            var detail = textBox1.Text; //購入品
            var money = int.Parse(textBox2.Text);   //金額
            var payment = comboBox2.SelectedItem.ToString();   //支払い方法
            var memo = textBox3.Text;   //メモ
            var month = day.ToString("yyyyMM"); //使用月

            var s = new SQL();
            //データベースに追加する
            s.AddExp(day, category, detail, money, payment, memo, month);
            //更新後の情報を受け取る
            List<string> sum = s.GetSum();
            //Form1の情報を更新する
            f1.label5.Text = $"\\ {sum[0]}";
            f1.label6.Text = $"\\ {sum[1]}";
            f1.label7.Text = $"\\ {sum[2]}";
            f1.label8.Text = $"\\ {sum[3]}";
            f1.label9.Text = $"\\ {sum[4]}";
            f1.label10.Text = $"\\ {sum[5]}";
            f1.label11.Text = $"\\ {sum[6]}";
            f1.label12.Text = $"\\ {sum[7]}";
            f1.label13.Text = $"\\ {sum[8]}";
            f1.label14.Text = $"\\ {sum[9]}";
            f1.label15.Text = $"\\ {sum[10]}";
            f1.label16.Text = $"\\ {sum[11]}";
            f1.label17.Text = $"\\ {sum[12]}";

            //合計金額を出す
            int sum1 = 0;
            foreach (var a in sum)
            {
                sum1 += int.Parse(a);
            }
            f1.label18.Text = $"\\ {sum1}";

            this.Close();   //Form2を消す
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
