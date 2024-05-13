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
        public static int amount2_3 = 0;
        public static int amount3_1 = 0;
        public static int amount3_2 = 0;
        public static int amount3_3 = 0;
        public static int amount4_1 = 0;
        public static int amount4_2 = 0;
        public static int amount4_3 = 0;
        public static int amount5_1 = 0;
        public static int amount5_2 = 0;
        public static int amount5_3 = 0;
        public static int amount5_4 = 0;
        public static int amount7_1 = 0;
        public static int amount7_2 = 0;
        public static int amount7_3 = 0;


        //TODO : Добавить остальные главы

        public static bool isConfigured = false;

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



    public class Tasks
    {
        private static Random rnd = new Random();

        private static double fi(double x)
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

        public static Tuple<string, string> task3_3_generate()
        {
            int kangaroo = rnd.Next(2, 5);
            int anteater = rnd.Next(3, 8);
            int gorillas = rnd.Next(4, 9);

            double kangaroo_prob = (double)(rnd.Next(1, 8)) / 10;
            double anteater_prob = (double)(rnd.Next(1, 8)) / 10;
            double gorillas_prob = (double)(rnd.Next(1, 8)) / 10;

            string task = "В зоопарке живут " + kangaroo + " кенгуру, " + anteater +
                " муравьедов и " + gorillas + " горилл. Условия содержания " +
                "млекопитающих таковы, что вероятность " +
                "заболеть у этих животных соответственно равна " +
                kangaroo_prob + ", " + anteater_prob + "и " + gorillas_prob +
                ". Животное, которое удалось поймать врачу, " +
                "оказалось здоровым. Какова вероятность того, что врач осматривал муравьеда?";

            int n = kangaroo + anteater + gorillas; 
            
            double ph1 = (double)kangaroo / (double)n;
            double ph2 = (double)anteater / (double)n;
            double ph3 = (double)gorillas / (double)n;

            double full_prob = ph1 * (1 - kangaroo_prob) 
                + ph2 * (1 - anteater_prob) + ph3 * (1 - gorillas_prob);
            double answer = Math.Round(((1 - anteater_prob) * ph2) / full_prob, 4);
            return new Tuple<string, string>(task, answer.ToString());
        }

        public static Tuple<string, string> task4_1_generate()
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

        public static Tuple<string, string> task4_2_generate()
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

        public static Tuple<string, string> task5_1_generate()
        {
            double prob = (double)(rnd.Next(1, 10)) / 10;
            int n = 5;

            string task = "Производятся последовательные испытания" +
                " надежности пяти приборов. Каждый следующий прибор" +
                " испытывается только в том случае, если предыдущий" +
                " оказался надежным. Составить ряд распределения" +
                " числа испытаний приборов, если вероятность выдержать" +
                " испытание для каждого прибора равна " + prob + "." +
                " Найти М(Х), D(X), s(X), F(X) этой случайной величины." +
                " Построить график F(X).";

            List<double> distribution_series = new List<double>(n);

            for (int i = 0; i < n; i++)
            {
                distribution_series.Add(Math.Pow(prob, i) * (1 - prob));
            }
            distribution_series[n - 1] += Math.Pow(prob, n);

            double MX = 0.0;

            for (int i = 0; i < n; i++)
            {
                MX += (i + 1) * distribution_series[i];
            }
            double DX = 0.0;
            for (int i = 0; i < n; i++)
            {
                DX += Math.Pow((i + 1), 2) * distribution_series[i];
            }
            DX -= Math.Pow(MX, 2);
            double sX = Math.Sqrt(DX);

            string answer = "X\t";

            for (int i = 0; i < n; i++)
                answer += (i + 1).ToString() + "\t";
            answer += "\np\t";
            foreach (double x in distribution_series)
            {
                answer += (Math.Round(x, 4).ToString() + "\t");
            }
            answer += "\nM(X) = " + Math.Round(MX, 4).ToString()
                + "\nD(X) = " + Math.Round(DX, 4).ToString()
                + "\ns(X) = " + Math.Round(sX, 4).ToString();
            
            List<double> F = new List<double>(6);
            double sum;
            for (int i = 0; i < n; i++)
            {
                sum = 0.0;
                for (int j = 0; j < i; j++)
                {
                    sum += distribution_series[j];
                }
                F.Add(sum);
            }

            answer += "\nF(x) = {\n\t0\t, X < 1;\n\t"
                + Math.Round(F[0], 4) + "\t, 1 < X < 2;\n\t"
                + Math.Round(F[1], 4) + "\t, 2 < X < 3;\n\t"
                + Math.Round(F[2], 4) + "\t, 3 < X < 4;\n\t"
                + Math.Round(F[3], 4) + "\t, 4 < X < 5;\n\t"
                + "1\t, X > 5\n\t}";

            return new Tuple<string, string>(task, answer);
        }

        public static Tuple<string, string> task5_2_generate()
        {
            double prob = (double)(rnd.Next(1, 10)) / 10;
            int n = 5;

            string task = "Составить ряд распределения числа" +
                " попаданий в цель, если произведено пять выстрелов," +
                " а вероятность попадания при одном выстреле равна " + prob
                + ". Найти M(X) и D(X) этой случайной величины.";

            List<double> distribution_series = new List<double>(n + 1);

            for (int i = 0; i < n + 1; i++)
            {
                distribution_series.Add(Math.Pow(prob, i) * Math.Pow(1 - prob, n - i));
            }

            double MX = 0.0;

            for (int i = 0; i < n + 1; i++)
            {
                MX += i * distribution_series[i];
            }
            double DX = 0.0;
            for (int i = 0; i < n + 1; i++)
            {
                DX += Math.Pow(i, 2) * distribution_series[i];
            }
            DX -= Math.Pow(MX, 2);

            string answer = "X\t";

            for (int i = 0; i < n + 1; i++)
                answer += i.ToString() + "\t";
            answer += "\np\t";
            foreach (double x in distribution_series)
            {
                answer += (Math.Round(x, 4).ToString() + "\t");
            }
            answer += "\nM(X) = " + Math.Round(MX, 4).ToString()
                + "\nD(X) = " + Math.Round(DX, 4).ToString();

            return new Tuple<string, string>(task, answer);
        }

        public static Tuple<string, string> task5_4_generate()
        {
            List<int> x_values = new List<int> { 2, 4, 5 };
            List<int> y_values = new List<int> { -1, 1 };

            double px1 = Math.Round((double)(rnd.Next(1, 9)) / 10, 1);
            double px3 = Math.Round((double)(rnd.Next(1, (int)((10 - px1 * 10)))) / 10, 1);
            double px2 = Math.Round(1 - px1 - px3, 1);

            List<double> px = new List<double> { px1, px2, px3 };

            double py1 = Math.Round((double)(rnd.Next(1, 10)) / 10, 1);
            double py2 = Math.Round(1 - py1, 1);

            List<double> py = new List<double> { py1, py2 };

            string task = "Независимые случайные величины X и Y " +
                "заданы таблицами распределений.\r\nНайти:\r\n" +
                "1) M(X), M(Y), D(X), D(Y);\r\n" +
                "2) таблицы распределения случайных величин Z_1 = 2X + Y, Z_2 = X * Y;\r\n" +
                "3) M(Z_1), M(Z_2), D(Z_1), D(Z_2) непосредственно по " +
                "таблицам распределений и на основании свойств " +
                "математического ожидания и дисперсии.\r\n";
            task += "X\t";
            for (int i = 0; i < px.Count; i++)
            {
                task += x_values[i].ToString() + "\t";
            }
            task += "\ty\t";
            for (int i = 0; i < py.Count; i++)
            {
                task += y_values[i].ToString() + "\t";
            }
            task += "\np\t";
            for (int i = 0; i < px.Count; i++)
            {
                task += px[i].ToString() + "\t";
            }
            task += "\tp\t";
            for (int i = 0; i < py.Count; i++)
            {
                task += py[i].ToString() + "\t";
            }

            double MX = 0.0;
            for (int i = 0; i < px.Count; i++)
            {
                MX += x_values[i] * px[i];
            }
            double DX = 0.0;
            for (int i = 0; i < px.Count; i++)
            {
                DX += Math.Pow(x_values[i], 2) * px[i];
            }
            DX -= Math.Pow(MX, 2);

            double MY = 0.0;
            for (int i = 0; i < py.Count; i++)
            {
                MY += y_values[i] * py[i];
            }
            double DY = 0.0;
            for (int i = 0; i < py.Count; i++)
            {
                DY += Math.Pow(y_values[i], 2) * py[i];
            }
            DY -= Math.Pow(MY, 2);

            string answer = "Ответ:\n1) M(X) = " + Math.Round(MX, 4) + ", D(X) = " + Math.Round(DX, 4)
                + ", M(Y) = " + Math.Round(MY, 4) + ", D(Y) = " + Math.Round(DY, 4) + "\n\n";

            List<int> z1_values = new List<int>();
            for (int i = 0;i < x_values.Count; i++)
            {
                for (int j = 0; j < y_values.Count; j++)
                {
                    z1_values.Add(2 * x_values[i] + y_values[j]);
                }
            }
            z1_values = z1_values.Distinct().ToList();
            z1_values.Sort();
            List<int> z2_values = new List<int>();
            for (int i = 0; i < x_values.Count; i++)
            {
                for (int j = 0; j < y_values.Count; j++)
                {
                    z2_values.Add(x_values[i] * y_values[j]);
                }
            }
            z2_values = z2_values.Distinct().ToList();
            z2_values.Sort();

            List<double> pz1 = new List<double>();
            foreach (int x in z1_values)
            {
                pz1.Add(0.0);
            }

            for (int k = 0; k < z1_values.Count; k++)
            {
                for (int i = 0; i < x_values.Count; i++)
                {
                    for (int j = 0; j < y_values.Count; j++)
                    {
                        if (2 * x_values[i] + y_values[j] == z1_values[k])
                        {
                            pz1[k] += px[i] * py[j];
                        }
                    }
                }
            }
            answer += "2)";
            answer += "\nz1\t";
            foreach (int i in z1_values)
                answer += i.ToString() + "\t";
            answer += "\np\t";
            foreach (double x in pz1)
            {
                answer += Math.Round(x, 4).ToString() + "\t";
            }
            List<double> pz2 = new List<double>();
            foreach (int x in z2_values)
            {
                pz2.Add(0.0);
            }

            for (int k = 0; k < z2_values.Count; k++)
            {
                for (int i = 0; i < x_values.Count; i++)
                {
                    for (int j = 0; j < y_values.Count; j++)
                    {
                        if (x_values[i] * y_values[j] == z2_values[k])
                        {
                            pz2[k] += px[i] * py[j];
                        }
                    }
                }
            }
            answer +="\n\nz2\t";
            foreach (int i in z2_values)
                answer += i.ToString() + "\t";
            answer += "\np\t";
            foreach (double x in pz2)
            {
                answer += Math.Round(x, 4).ToString() + "\t";
            }
            answer += "\n";
            double MZ1 = 0.0;
            for (int i = 0; i < pz1.Count; i++)
            {
                MZ1 += z1_values[i] * pz1[i];
            }
            double MZ2 = 0.0;
            for (int i = 0; i < pz2.Count; i++)
            {
                MZ2 += z2_values[i] * pz2[i];
            }

            double DZ1 = 0.0;
            for (int i = 0; i < pz1.Count; i++)
            {
                DZ1 += Math.Pow(z1_values[i], 2) * pz1[i];
            }
            DZ1 -= Math.Pow(MZ1, 2);
            double DZ2 = 0.0;
            for (int i = 0; i < pz2.Count; i++)
            {
                DZ2 += Math.Pow(z2_values[i], 2) * pz2[i];
            }
            DZ2 -= Math.Pow(MZ2, 2);

            answer += "\n3)\nM(Z1) = " + Math.Round(MZ1, 4) +
                ", M(Z2) = " + Math.Round(MZ2, 4) +
                ", D(Z1) = " + Math.Round(DZ1, 4) +
                ", D(Z2) = " + Math.Round(DZ2, 4);

            return new Tuple<string, string>(task, answer);
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