using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budget
{
    public partial class Form3 : Form
    {
        Form1 f1;

        public Form3()
        {
        }

        public Form3(Form1 f)
        {
            f1 = f; // メイン・フォームへの参照を保存
            InitializeComponent();
        }

        private void Form3_shown(object sender, EventArgs e)
        {
            //エラーアイコンを点滅させない
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            var id = label10.Text.Trim();   //id(string)
            //データの取得
            SQL s = new SQL();
            Expenditure exp = s.Select(id);
            dateTimePicker1.Text = exp.strDay();
            comboBox1.Text = exp.Category;
            textBox1.Text = exp.Detail;
            textBox2.Text = exp.Money.ToString();
            comboBox2.Text = exp.Payment;
            textBox3.Text = exp.Memo; 
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // ErrorProviderをクリアします。
            errorProvider1.Clear();
            errorProvider2.Clear();

            var id = label10.Text.Trim();
            var day1 = DateTime.Parse(dateTimePicker1.Text);
            var category = comboBox1.Text;
            var detail = textBox1.Text;
            if (string.IsNullOrWhiteSpace(detail))
            {
                // 未入力ならエラーを通知する。
                var msg = "支払対象を入力してください";
                errorProvider1.SetError(textBox1, msg);
            }
            else if(string.IsNullOrWhiteSpace(textBox2.Text))
            {
                var msg = "金額を入力してください";
                errorProvider2.SetError(textBox2, msg);
            }
            else
            {
                var money = textBox2.Text;
                var payment = comboBox2.Text;
                var memo = textBox3.Text;
                var month = day1.ToString("yyyyMM"); //使用月

                SQL s = new SQL();
                //データベースを更新する
                s.Update(id, day1, category, detail, money, payment, memo, month);

                //更新後の情報を受け取る
                var month1 = day1;
                f1.dateTimePicker1.Value = month1;
                List<string> sum = s.GetSum(month);
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

                //ListViewに今月の全出費表示
                f1.listView1.Items.Clear();
                //出費をListViewに表示
                SQL s1 = new SQL();
                List<Expenditure> allList = s1.GetAllList(month);

                ListViewItem lvi;
                foreach (Expenditure exp1 in allList)
                {
                    lvi = f1.listView1.Items.Add(exp1.Id.ToString());
                    lvi.SubItems.Add(exp1.strDay());
                    lvi.SubItems.Add(exp1.Detail);
                    lvi.SubItems.Add(exp1.Money.ToString());
                    lvi.SubItems.Add(exp1.Payment);
                    lvi.SubItems.Add(exp1.Memo);
                }

                this.Close();   //Form3を消す
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
