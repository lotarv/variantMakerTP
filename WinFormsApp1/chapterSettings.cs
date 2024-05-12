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
                tabPage6.Enabled = false;
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
                    GenereationConfig.amount2_3 = Convert.ToInt32(inputAmount2_3.Text);
                }

                if (GenereationConfig.is3)
                {
                    GenereationConfig.amount3_1 = Convert.ToInt32(inputAmount3_1.Text);
                    GenereationConfig.amount3_2 = Convert.ToInt32(inputAmount3_2.Text);
                    GenereationConfig.amount3_3 = Convert.ToInt32(inputAmount3_3.Text);
                }

                if (GenereationConfig.is4)
                {
                    GenereationConfig.amount4_1 = Convert.ToInt32(inputAmount4_1.Text);
                    GenereationConfig.amount4_2 = Convert.ToInt32(inputAmount4_2.Text);
                    GenereationConfig.amount4_3 = Convert.ToInt32(inputAmount4_3.Text);
                }

                if (GenereationConfig.is5)
                {
                    GenereationConfig.amount5_1 = Convert.ToInt32(inputAmount5_1.Text);
                    GenereationConfig.amount5_2 = Convert.ToInt32(inputAmount5_2.Text);
                    GenereationConfig.amount5_3 = Convert.ToInt32(inputAmount5_3.Text);
                    GenereationConfig.amount5_4 = Convert.ToInt32(inputAmount5_4.Text);
                }

                if (GenereationConfig.is7)
                {
                    GenereationConfig.amount7_1 = Convert.ToInt32(inputAmount4_1.Text);
                    GenereationConfig.amount7_2 = Convert.ToInt32(inputAmount4_2.Text);
                    GenereationConfig.amount7_3 = Convert.ToInt32(inputAmount4_3.Text);
                }



                GenereationConfig.isConfigured = true;
                this.Close();
            }
        }
    }
}
