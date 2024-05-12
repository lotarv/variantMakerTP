using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string filePath;
        WordDocument wordDoc;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            bool is1 = chapter1Check.Checked, is2 = chapter2Check.Checked, is3 = chapter3Check.Checked, is4 = chapter4Check.Checked, is5 = chapter5Check.Checked, is7 = chapter7Check.Checked;
            chapterSettings nextForm = new chapterSettings(is1, is2, is3, is4, is5, is7);
            nextForm.Show();
        }

        private void generateBtn_Click(object sender, EventArgs e)
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
                filePath = saveFileDialog.FileName;
                try
                {
                    generate();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void generate()
        {

            wordDoc = new WordDocument(filePath);
            wordDoc.newParagraph("generating next variant:");
            if (GenereationConfig.is1)
            {
                generateChapter1();
            }

            if (GenereationConfig.is2)
            {
                generateChapter2();
            }

            if (GenereationConfig.is3)
            {
                generateChapter3();
            }

            if (GenereationConfig.is4)
            {
                generateChapter4();
            }

            if (GenereationConfig.is5)
            {
                generateChapter5();
            }

            if (GenereationConfig.is7)
            {
                generateChapter7();
            }

            //Закрытие документа
            wordDoc.closeDocument();


        }

        private void generateChapter1()
        {
            wordDoc.newParagraph("1");
        }

        private void generateChapter2()
        {
            wordDoc.newParagraph("2");
        }

        private void generateChapter3()
        {
            wordDoc.newParagraph("3");
        }

        private void generateChapter4()
        {
            wordDoc.newParagraph("4");
        }

        private void generateChapter5()
        {
            wordDoc.newParagraph("5");
        }

        private void generateChapter7()
        {
            wordDoc.newParagraph("7");
        }
    }
}
