using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool is1 = chapter1Check.Checked, is2 = chapter2Check.Checked, is3 = chapter3Check.Checked, is4 = chapter4Check.Checked, is5 = chapter5Check.Checked, is7 = chapter7Check.Checked;
            chapterSettings nextForm = new chapterSettings(is1, is2, is3, is4, is5, is7);
            nextForm.Show();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GenereationConfig.isConfigured == false)
            {
                MessageBox.Show("Сначала завершите настройку глав!");
                return;
            }

            //Заполнение документа с задачами: (TEST VERSION)

            // Открытие диалогового окна выбора файла
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Word Documents (*.docx)|*.docx",
                Title = "Сохраните документ Word",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                WordDocument wordDoc = new WordDocument(filePath);
                wordDoc.newParagraph("hello world");
                wordDoc.newParagraph("hello world ");
                wordDoc.appendText("2");
                wordDoc.closeDocument();

                MessageBox.Show("Документ успешно создан или обновлен");
            }
        }


    }
}
