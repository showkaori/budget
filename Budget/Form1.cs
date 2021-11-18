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
            string syokuhi = s.GetSum();
            label5.Text = $"\\ {syokuhi}";
        }


    }
}
