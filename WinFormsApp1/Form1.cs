using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string filePath;
        private int currentNumber = 1;
        WordDocument wordDoc;
        WordDocument wordDocAnswers;
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
            //Создание документов - вариант и ответы
            wordDoc = new WordDocument(filePath);
            string filePathAnswers = filePath.Substring(0, filePath.LastIndexOf('.'));
            filePathAnswers += "Ответы.docx";
            wordDocAnswers = new WordDocument(filePathAnswers);
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
            wordDocAnswers.closeDocument();


        }

        private void generateChapter1()
        {
            //Задание 1 - пока не сделано

            //Задание 2 - пока не сделано

        }

        private void generateChapter2()
        {
            //1 задание - пока не сделано

            //2 задание  
            for (int i = 0; i < GenereationConfig.amount2_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task2_2 = Tasks.task2_2_generate();
                wordDoc.appendText(task2_2.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task2_2.Item2);
            }

            // 3 задание
            for (int i = 0; i < GenereationConfig.amount2_3; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task2_3 = Tasks.task2_3_generate();
                wordDoc.appendText(task2_3.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task2_3.Item2);
            }


        }

        private void generateChapter3()
        {
            //1 задание
            for (int i = 0; i < GenereationConfig.amount3_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task3_1 = Tasks.task3_1_generate();
                wordDoc.appendText(task3_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task3_1.Item2);
            }
            //2 задание  - пока не сделано


            // 3 задание
            for (int i = 0; i < GenereationConfig.amount3_3; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task3_3 = Tasks.task3_3_generate();
                wordDoc.appendText(task3_3.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task3_3.Item2);
            }
        }

        private void generateChapter4()
        {
            //Задание 1
            for (int i = 0; i < GenereationConfig.amount4_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task4_1 = Tasks.task4_1_generate();
                wordDoc.appendText(task4_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task4_1.Item2);
            }

            //Задание 2 - пока не сделано

            //Задание 3

            for (int i = 0; i < GenereationConfig.amount4_3; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task4_3 = Tasks.task4_3_generate();
                wordDoc.appendText(task4_3.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task4_3.Item2);
            }
        }

        private void generateChapter5()
        {
            //Задание 1

            for (int i = 0; i < GenereationConfig.amount5_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task5_1 = Tasks.task5_1_generate();
                wordDoc.appendText(task5_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task5_1.Item2);
            }

            //Задание 2
            for (int i = 0; i < GenereationConfig.amount5_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task5_2 = Tasks.task5_2_generate();
                wordDoc.appendText(task5_2.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task5_2.Item2);
            }

            //Задание 3 - пока не сделано


            //Задание 4
            for (int i = 0; i < GenereationConfig.amount5_4; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task5_4 = Tasks.task5_4_generate();
                wordDoc.appendText(task5_4.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task5_4.Item2);
            }
        }

        private void generateChapter7()
        {
            //Задание 1 - пока не сделано

            //Задание 2 - пока не сделано

            //Задание 3 - пока не сделано

        }
    }
}
