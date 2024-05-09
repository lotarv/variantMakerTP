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
        private Random rnd = new Random();

        private double fi(double x)
        {
            return (1.0 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-x * x / 2);
        }

        private static int factorial(int n)
        {
            if (n == 0) return 1;
            else return n * factorial(n - 1);
        }
        private static int combinations(int n, int k)
        {
            return factorial(n) / (factorial(k) * factorial(n - k));
        }

        public static Tuple<string, string> task2_1_generate()
        {
            Random rnd = new Random();
            bool a_term;
            if (rnd.Next(0, 1) == 0)
                a_term = false;
            else
                a_term = true;

            int b_term = rnd.Next(1, 6);
            int c_term = rnd.Next(1, 6);

            string task;
            if (a_term)
                task = "Эксперимент состоит в бросании игральной кости." +
                    " Пусть событие А — появление четного числа очков, ";
            else
                task = "Эксперимент состоит в бросании игральной кости." +
                    " Пусть событие А — появление нечетного числа очков, ";
            task += "В — непоявление " + b_term + " очков, С — непоявление " + c_term + " очков. " +
                "Постройте множество элементарных исходов и выявите состав подмножеств, " +
                "соответствующих событиям:\r\nа) A&B&C;\r\n б) AUB;\r\n в) !A&B\r\n";

            BitArray A = new BitArray(6);
            BitArray B = new BitArray(6);
            BitArray C = new BitArray(6);

            if (a_term)
            {
                for (int i = 0; i < 6; i++)
                    if ((i + 1) / 2 == 0)
                        A[i] = true;
            }
            else
            {
                for (int i = 0; i < 6; i++)
                    if ((i + 1) / 2 == 1)
                        A[i] = true;
            }

            for (int i = 0; i < 6; i++)
            {
                if (i + 1 != b_term)
                    B[i] = true;
                if (i + 1 != c_term)
                    C[i] = true;
            }

            // Потом доделаю
            return null;
        }

        public static Tuple<string, string> task2_2_generate()
        {
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
            double prob = (double)(rnd.Next(1, 20)) / 20;

            string task = "При включении в сеть цепи (рис. 5) каждый " +
                "элемент выходит из строя с вероятностью " + prob + ". " +
                "Найти вероятность того, что в момент включения цепь не разомкнется";

            string answer = ((1 - prob * prob) * (1 - prob) * (1 - prob * prob)).ToString();

            return new Tuple<string, string>(task, answer);
        }

        public static Tuple<string, string> task3_1_generate()
        {
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

        public static task4_1_generate()
        {
            int n = rnd.Next(4, 9);
            int k = rnd.Next(1, n / 2);
            double prob = (double)(rnd.Next(1, 10)) / 100;

            double result = 0.0;
            for (int i = 0; i <= k; i++)
            {
                result += (combinations(n, i) * Math.Pow(prob, i) * Math.Pow(1 - prob, n - i));
            }

            string task = "Вероятность отказа локомотива на линии за время полного" +
                " оборота составляет " + prob + ". Найти вероятность того, что" +
                " в " + n + " поездах произойдет не более " + k + " отказ(а)(ов)" +
                " локомотива на линии.";

            string answer = (Math.Round(result, 4)).ToString();
            return new Tuple<string, string>(task, answer);
        }

        public static task4_2_generate()
        {
            int k = rnd.Next(21, 40) * 10;
            double prob = (double)rnd.Next(3, 9) / 10.0;

            int n = (int)(Math.Round((double)k / prob / 10)) * 10 + rnd.Next(-4, 4) * 10;

            string task = "В каждом из " + n + " независимых испытаний событие" +
                " А происходит с постоянной вероятностью " + prob + ". Найти " +
                "вероятность того, что событие А наступит:" +
                "\r\nа) точно " + k + " раз;\r\nб) менее " +
                "чем 240 и более чем 180 раз.\r\n";

            // а)
            
            double x = (k - n * prob) / Math.Sqrt(n * prob * (1 - prob));
            /*if (Math.Round((1 / Math.Sqrt(n * prob * (1 - prob))) * fi(x), 4) == 0)
            {
                generate();
                return;
            } это слишком гениальная идея чтобы юзать ее...*/
            
            string answer = "а) " + Math.Round((1 / Math.Sqrt(n*prob*(1- prob))) * fi(x), 4).ToString();

            // пункт б) пока что откладывается...
            return null;
        }

        public static Tuple<string, string> task4_3_generate()
        {
            double prob = (double)(rnd.Next(1, 10)) / 1000;

            int k = rnd.Next(2, 6);

            int lambda = rnd.Next(1, 10);
            int n = (int)((double)lambda / prob);

            while (Math.Round((double)(n) / 100) != (double)n / 100)
            {
                lambda = rnd.Next(1, 10);
                n = (int)((double)lambda / prob);
            }

            string task = "Прядильщица обслуживает " + n + " веретен. " +
                "Вероятность обрыва нити на одном веретене в течение часа " +
                "равна " + prob + ". Какова вероятность того, что в " +
                "течение часа нить оборвется на " + k + " веретенах?";

            string answer = "(" + lambda + "^" + k + "*e^" + (-lambda) + ")/(" + k + "!) ~ "
                + Math.Round((Math.Pow(lambda, k) * Math.Exp(-lambda)) / factorial(k), 4).ToString();

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