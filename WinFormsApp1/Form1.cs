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
        private int currentVariant = 1;
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
            bool is1 = chapter1Check.Checked, is2 = chapter2Check.Checked, is3 = chapter3Check.Checked, is4 = chapter4Check.Checked, is5 = chapter5Check.Checked, is7 = chapter7Check.Checked;
            if (!is1)
            {
                
                GenereationConfig.is1 = false;
            }
            if (!is2)
            {
                
                GenereationConfig.is2 = false;
            }
            if (!is3)
            {
                
                GenereationConfig.is3 = false;
            }
            if (!is4)
            {
                
                GenereationConfig.is4 = false;
            }
            if (!is5)
            {
                
                GenereationConfig.is5 = false;
            }
            if (!is7)
            {
                
                GenereationConfig.is7 = false;
            }

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
                    GenereationConfig.variantAmount = Convert.ToInt32(amountInput.Text);
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
            filePathAnswers += " Ответы.docx";
            wordDocAnswers = new WordDocument(filePathAnswers);

            for (int i = 0; i < GenereationConfig.variantAmount; i++)
            {
                currentNumber = 1;             
                if (currentVariant > 1) //Промежуток между вариантами
                {
                    for (int k = 0; k < 27; k++) //После всех задач подобрать нужное число
                    {
                        wordDoc.newParagraph("");
                    }
                }
                wordDoc.newParagraph($"Вариант {currentVariant}");
                wordDocAnswers.newParagraph($"Вариант {currentVariant++}");

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
            }

            

            //Закрытие документа
            wordDoc.closeDocument();
            wordDocAnswers.closeDocument();


        }

        private void generateChapter1()
        {
            wordDoc.newParagraph("ГЛАВА 1");
            //Задание 1
            for (int i = 0; i < GenereationConfig.amount1_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task1_1 = Tasks.task1_1_generate();
                wordDoc.appendText(task1_1.Item1);

                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task1_1.Item2);
            }

            //Задание 2
            for (int i = 0; i < GenereationConfig.amount1_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task1_2 = Tasks.task1_2_generate();
                wordDoc.appendText(task1_2.Item1);

                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task1_2.Item2);
            }
        }

        private void generateChapter2()
        {
            wordDoc.newParagraph("ГЛАВА 2");
            
            //1 задание
            for (int i = 0; i < GenereationConfig.amount2_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task2_1 = Tasks.task2_1_generate();
                wordDoc.appendText(task2_1.Item1);

                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task2_1.Item2);
            }

            //2 задание  
            for (int i = 0; i < GenereationConfig.amount2_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task2_2 = Tasks.task2_2_generate();
                wordDoc.appendText(task2_2.Item1);
                
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task2_2.Item2);
            }

            //// 3 задание
            for (int i = 0; i < GenereationConfig.amount2_3; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task2_3 = Tasks.task2_3_generate();
                wordDoc.appendText(task2_3.Item1);
                //Картинка
                string projectDirectory = Directory.GetCurrentDirectory();
                string imagePath = projectDirectory + "/Рисунок5.jpg";
                wordDoc.InsertAPicture(imagePath);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task2_3.Item2);
            }
        }

        private void generateChapter3()
        {
            wordDoc.newParagraph("ГЛАВА 3");
            //1 задание
            for (int i = 0; i < GenereationConfig.amount3_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task3_1 = Tasks.task3_1_generate();
                wordDoc.appendText(task3_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task3_1.Item2);
            }
            //2 задание

            for (int i = 0; i < GenereationConfig.amount3_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task3_2 = Tasks.task3_2_generate();
                wordDoc.appendText(task3_2.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task3_2.Item2);
            }

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
            wordDoc.newParagraph("ГЛАВА 4");
            //Задание 1
            for (int i = 0; i < GenereationConfig.amount4_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task4_1 = Tasks.task4_1_generate();
                wordDoc.appendText(task4_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task4_1.Item2);
            }

            //Задание 2

            for (int i = 0; i < GenereationConfig.amount4_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task4_2 = Tasks.task4_2_generate();
                wordDoc.appendText(task4_2.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task4_2.Item2);
            }

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
            wordDoc.newParagraph("ГЛАВА 5");
            //Задание 1

            for (int i = 0; i < GenereationConfig.amount5_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string, string[], string[,]> task5_1 = Tasks.task5_1_generate();
                wordDoc.appendText(task5_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.createTable(task5_1.Item3, task5_1.Item4);
                wordDocAnswers.newParagraph(task5_1.Item2);
                
            }

            //Задание 2
            for (int i = 0; i < GenereationConfig.amount5_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string, string[], string[,]> task5_2 = Tasks.task5_2_generate();
                wordDoc.appendText(task5_2.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.createTable(task5_2.Item3, task5_2.Item4);
                wordDocAnswers.newParagraph(task5_2.Item2);
            }

            //Задание 3
            for (int i = 0; i < GenereationConfig.amount5_3; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string, string[], string[,]> task5_3 = Tasks.task5_3_generate();
                wordDoc.appendText(task5_3.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.createTable(task5_3.Item3, task5_3.Item4);
                wordDocAnswers.newParagraph(task5_3.Item2);
            }

            //Задание 4
            for (int i = 0; i < GenereationConfig.amount5_4; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string, string[,], string[,], string[,], string[,], string> task5_4 = Tasks.task5_4_generate();
                //(task, answer, task_matrix_X, task_matrix_Y, answer_matrix_Z1, answer_matrix_Z2, answer2);

                wordDoc.appendText(task5_4.Item1);
                wordDoc.createTable(new string[] { "X", "p" }, task5_4.Item3);
                wordDoc.newParagraph("");
                wordDoc.createTable(new string[] { "Y", "p" }, task5_4.Item4);

                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task5_4.Item2);

                wordDocAnswers.createTable(new string[] { "Z1", "p" }, task5_4.Item5);
                wordDoc.newParagraph("");
                wordDocAnswers.createTable(new string[] { "Z2", "p" }, task5_4.Item6);

                wordDocAnswers.newParagraph(task5_4.Item7);

            }
        }

        private void generateChapter7()
        {
            wordDoc.newParagraph("ГЛАВА 7");
            //Задание 1
            for (int i = 0; i < GenereationConfig.amount7_1; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task7_1 = Tasks.task7_1_generate();
                wordDoc.appendText(task7_1.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task7_1.Item2);
            }

            //Задание 2
            for (int i = 0; i < GenereationConfig.amount7_2; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task7_2 = Tasks.task7_2_generate();
                wordDoc.appendText(task7_2.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task7_2.Item2);
            }

            //Задание 3
            for (int i = 0; i < GenereationConfig.amount7_3; i++)
            {
                wordDoc.newParagraph(currentNumber.ToString() + ". ");
                Tuple<string, string> task7_3 = Tasks.task7_3_generate();
                wordDoc.appendText(task7_3.Item1);
                wordDocAnswers.newParagraph((currentNumber++).ToString() + ".");
                wordDocAnswers.newParagraph(task7_3.Item2);
            }
        }
    }
}
