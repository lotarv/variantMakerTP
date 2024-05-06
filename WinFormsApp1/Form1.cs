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
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    // Добавление основного документа
                    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавление абзаца
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());

                    // Добавление текста
                    run.AppendChild(new Text($"Создаем следующие задачи:\n\n"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text("Глава 1"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text($"{GenereationConfig.amount1_1} задач #1 и {GenereationConfig.amount1_2} задач #2"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text("Глава 2"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text($"{GenereationConfig.amount2_1} задач # 1 и {GenereationConfig.amount2_2} задач #2"));




                    // Сохранение документа
                    mainPart.Document.Save();
                }

                MessageBox.Show("Документ успешно создан или обновлен.");
            }




        }
    }
}
