using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class chapterSettings : Form
    {
        public chapterSettings(bool is1, bool is2, bool is3, bool is4, bool is5, bool is7)
        {
            InitializeComponent();
            if (!is1)
            {
                tabPage1.Enabled = false;
                GenereationConfig.is1 = false;
            }
            if (!is2)
            {
                tabPage2.Enabled = false;
                GenereationConfig.is2 = false;
            }
            if (!is3)
            {
                tabPage3.Enabled = false;
                GenereationConfig.is3 = false;
            }
            if (!is4)
            {
                tabPage4.Enabled = false;
                GenereationConfig.is4 = false;
            }
            if (!is5)
            {
                tabPage5.Enabled = false;
                GenereationConfig.is5 = false;
            }
            if (!is7)
            {
                tabPage7.Enabled = false;
                GenereationConfig.is7 = false;
            }

        }

        private void chapterSettings_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage7)
            {
                //Запоминаем количество задач, которые хотим сгенерировать
                if (GenereationConfig.is1)
                {
                    GenereationConfig.amount1_1 = Convert.ToInt32(inputAmount1_1.Text);
                    GenereationConfig.amount1_2 = Convert.ToInt32(inputAmount1_2.Text);
                }

                if (GenereationConfig.is2)
                {
                    GenereationConfig.amount2_1 = Convert.ToInt32(inputAmount2_1.Text);
                    GenereationConfig.amount2_2 = Convert.ToInt32(inputAmount2_2.Text);
                }

                //TODO : Добавить остальные главы

                GenereationConfig.isConfigured = true;
                this.Close();
            }
        }
    }
}
