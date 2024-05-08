using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security;

namespace WinFormsApp1
{

    public class GenereationConfig
    {
        public static bool is1 = true;
        public static bool is2 = true;
        public static bool is3 = true;
        public static bool is4 = true;
        public static bool is5 = true;
        public static bool is7 = true;

        public static int amount1_1 = 0;
        public static int amount1_2 = 0;
        public static int amount2_1 = 0;
        public static int amount2_2 = 0;

        //TODO : Добавить остальные главы

        public static bool isConfigured = false;


    }

    public class Tasks
    {
        //public static Tuple<string, string> task2_1_generate()
        //{
        //    Random rnd = new Random();
        //    bool a_term;
        //    if (rnd.Next(0, 1) == 0)
        //        a_term = false;
        //    else
        //        a_term = true;

        //    int b_term = rnd.Next(1, 6);
        //    int c_term = rnd.Next(1, 6);

        //    string task;
        //    if (a_term)
        //        task = "Эксперимент состоит в бросании игральной кости." +
        //            " Пусть событие А — появление четного числа очков, ";
        //    else
        //        task = "Эксперимент состоит в бросании игральной кости." +
        //            " Пусть событие А — появление нечетного числа очков, ";
        //    task += "В — непоявление " + b_term + " очков, С — непоявление " + c_term + " очков. " +
        //        "Постройте множество элементарных исходов и выявите состав подмножеств, " +
        //        "соответствующих событиям:\r\nа) A&B&C;\r\n б) AUB;\r\n в) !A&B\r\n";
            
        //    BitArray A = new BitArray(6);
        //    BitArray B = new BitArray(6);
        //    BitArray C = new BitArray(6);

        //    if (a_term)
        //    {
        //        for (int i = 0; i < 6; i++)
        //            if ((i + 1) / 2 == 0)
        //                A[i] = true;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 6; i++)
        //            if ((i + 1) / 2 == 1)
        //                A[i] = true;
        //    }

        //    for (int i = 0; i < 6; i++)
        //    {
        //        if (i + 1 != b_term)
        //            B[i] = true;
        //        if (i + 1 != c_term)
        //            C[i] = true;
        //    }

        //    // Потом доделаю
            
        //}

        public static Tuple<string, string> task2_2_generate()
        {
            Random rnd = new Random();
            double prob_dir = (double)(rnd.Next(1, 20)) / 20;
            double prob_act = (double)(rnd.Next(1, 20)) / 20;

            string task = "Вероятность опоздания режиссера на репетицию равна " +
               prob_dir + ", ведущей актрисы театра — " + prob_act + ". Какова вероятность " +
               "того, что в среду:\r\n а) на репетицию опоздают и режиссер, " +
               "и актриса;\r\n б) опоздает только актриса;\r\n в) никто не опоздает?\r\n";

            string answers = "а) " + prob_dir * prob_act + "\n" +
                "б) " + prob_act * (1 - prob_dir) + "\n" +
                "в) " + (1 - prob_dir) * (1 - prob_act);

            return new Tuple<string, string>(task, answers);
        }

        public static Tuple<string, string> task2_3_generate()
        {
            Random rnd = new Random();
            double prob = (double)(rnd.Next(1, 20)) / 20;

            string task = "При включении в сеть цепи (рис. 5) каждый " +
                "элемент выходит из строя с вероятностью " + prob + ". " +
                "Найти вероятность того, что в момент включения цепь не разомкнется";

            string answer = ((1 - prob * prob) * (1 - prob) * (1 - prob * prob)).ToString();

            return new Tuple<string, string>(task, answer);
        }

        public static Tuple<string, string> task3_1_generate()
        {
            Random rnd = new Random();
            int n = rnd.Next(25, 50);
            int k = rnd.Next(n / 2, n - 1);

            string task = "Студент пришел на зачет по математике, " +
                "зная " + k + " вопросов из " + n + ". Если он не может ответить, " +
                "ему предоставляется еще один шанс. Какова вероятность, " +
                "что он сдаст зачет?";
            
            int chisl = k * (n - 1) + (n - k) * k;
            int znam = n * (n - 1);
            string answer = chisl.ToString() + "/" + znam.ToString();

            return new Tuple<string, string>(task, answer);
        }
    }

    public class WordDocument
    {
        public WordprocessingDocument wordDoc;
        private Body body;
        private MainDocumentPart mainPart;
        private Paragraph currentPara;
        private Run currentRun;
        public WordDocument(string filePath)
        {
            wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document);
            // Добавление основного документа
            mainPart = wordDoc.AddMainDocumentPart();
            mainPart.Document = new Document();
            body = mainPart.Document.AppendChild(new Body());
        }
        public void appendText(string text)
        {
            currentRun.AppendChild(new Text(text));
            mainPart.Document.Save();
        }

        public void newParagraph(string text)
        {
            currentPara = body.AppendChild(new Paragraph());
            currentRun = currentPara.AppendChild(new Run());
            currentRun.AppendChild(new Text(text));
            mainPart.Document.Save();
        }

        public void closeDocument()
        {
           if (wordDoc != null)
            {
                wordDoc.Dispose();
            }
        }
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}