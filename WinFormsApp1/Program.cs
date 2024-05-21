﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.IO;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Collections;

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

        public static int amount1_1 = 1;
        public static int amount1_2 = 1;
        public static int amount2_1 = 1;
        public static int amount2_2 = 1;
        public static int amount2_3 = 1;
        public static int amount3_1 = 1;
        public static int amount3_2 = 1;
        public static int amount3_3 = 1;
        public static int amount4_1 = 1;
        public static int amount4_2 = 1;
        public static int amount4_3 = 1;
        public static int amount5_1 = 1;
        public static int amount5_2 = 1;
        public static int amount5_3 = 1;
        public static int amount5_4 = 1;
        public static int amount7_1 = 1;
        public static int amount7_2 = 1;
        public static int amount7_3 = 1;


        public static int variantAmount = 1;

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

        public void InsertAPicture(string fileName)
        {
            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            AddImageToBody(mainPart.GetIdOfPart(imagePart));
            mainPart.Document.Save();
        }
        private void AddImageToBody(string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 1980000L, Cy = 1584000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 1980000L, Cy = 1584000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            if (wordDoc.MainDocumentPart is null || wordDoc.MainDocumentPart.Document.Body is null)
            {
                throw new ArgumentNullException("MainDocumentPart and/or Body is null.");
            }

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }

        public void createTable(string[] headers, string[,] matrix)
        {
            // Create an empty table.
            Table table = new Table();

            // Create a TableProperties object and specify its border information.
            TableProperties tblProp = new TableProperties(
                new TableBorders(
                    new TopBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.ClassicalWave),
                        Size = 12
                    },
                    new BottomBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.ClassicalWave),
                        Size = 12
                    },
                    new LeftBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.ClassicalWave),
                        Size = 12
                    },
                    new RightBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.ClassicalWave),
                        Size = 12
                    },
                    new InsideHorizontalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.ClassicalWave),
                        Size = 12
                    },
                    new InsideVerticalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.ClassicalWave),
                        Size = 12
                    }
                )
            );

            // Append the TableProperties object to the empty table.
            table.AppendChild<TableProperties>(tblProp);


            //TableRow tr = new TableRow();



            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                TableRow tr = new TableRow();
                TableCell rowHeader = new TableCell();
                rowHeader.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1200" }));
                rowHeader.Append(new Paragraph(new Run(new Text(headers[i]))));
                tr.Append(rowHeader);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    TableCell tc = new TableCell();
                    tc.Append(new TableCellProperties(
                        new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "1200" }));
                    tc.Append(new Paragraph(new Run(new Text(matrix[i, j].ToString()))));
                    tr.Append(tc);

                }
                table.Append(tr);
            }

            if (wordDoc.MainDocumentPart is null || wordDoc.MainDocumentPart.Document.Body is null)
            {
                throw new ArgumentNullException("MainDocumentPart and/or Body is null.");
            }

            // Append the table to the document.
            wordDoc.MainDocumentPart.Document.Body.Append(table);
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

        private static int gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }

        private static Tuple<int, int> reduceFraction(int chisl, int znam)
        {
            int gcd_val = gcd(chisl, znam);
            chisl /= gcd_val;
            znam /= gcd_val;
            return new Tuple<int, int>(chisl, znam);
        }

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

        private static double f(double x)
        {
            return (1.0 / Math.Sqrt(2 * Math.PI)) * Math.Exp(-(x * x) / 2);
        }

        private static double func_laplace(double x)
        {
            double h = x / 100.0;
            double integral = 0;

            List<double> x_vals = new List<double>(101);
            for (int i = 0; i < x_vals.Count; i++)
            {
                x_vals[i] = i * h;
            }

            for (int i = 1; i < x_vals.Count; i++)
            {
                integral += (h / 6) * (f(x_vals[i - 1]) + 4 * f((x_vals[i] + x_vals[i - 1]) / 2) + f(x_vals[i]));
            }
            return Math.Abs(integral);
        }

        public static Tuple<string, string> task2_1_generate()
        {
            Random rnd = new Random();
            bool a_term;
            if (rnd.Next(0, 2) == 0)
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
                    if ((i + 1) % 2 == 0)
                        A[i] = true;
            }
            else
            {
                for (int i = 0; i < 6; i++)
                    if ((i + 1) % 2 == 1)
                        A[i] = true;
            }

            for (int i = 0; i < 6; i++)
            {
                if (i + 1 != b_term)
                    B[i] = true;
                if (i + 1 != c_term)
                    C[i] = true;
            }

            BitArray answer1 = new BitArray(A);
            answer1.And(B);
            answer1.And(C);

            string answer = "Ответы:\n";
            answer += "а) {";

            bool first = true;
            for (int i = 0; i < 6; i++)
            {
                if (answer1[i] == true)
                {
                    if (first)
                    {
                        answer += (i + 1).ToString();
                        first = false;
                    }
                    else
                        answer += ", " + (i + 1).ToString();
                }
            }
            answer += "}; б) {";

            BitArray answer2 = new BitArray(A);
            answer1.Or(B);

            first = true;
            for (int i = 0; i < 6; i++)
            {
                if (answer2[i] == true)
                {
                    if (first)
                    {
                        answer += (i + 1).ToString();
                        first = false;
                    }
                    else
                        answer += ", " + (i + 1).ToString();
                }
            }
            answer += "}; в) {";

            BitArray answer3 = new BitArray(A.Not());
            answer3.And(B);

            first = true;
            for (int i = 0; i < 6; i++)
            {
                if (answer3[i] == true)
                {
                    if (first)
                    {
                        answer += (i + 1).ToString();
                        first = false;
                    }
                    else
                        answer += ", " + (i + 1).ToString();
                }
            }
            answer += "}";
            return new Tuple<string, string> (task, answer);
        }

        public static Tuple<string, string> task2_2_generate()
        {
            double prob_dir = (double)(rnd.Next(1, 20)) / 20;
            double prob_act = (double)(rnd.Next(1, 20)) / 20;

            string task = "Вероятность опоздания режиссера на репетицию равна " +
               prob_dir + ", ведущей актрисы театра — " + prob_act + ". Какова вероятность " +
               "того, что в среду:\r\n а) на репетицию опоздают и режиссер, " +
               "и актриса;\r\n б) опоздает только актриса;\r\n в) никто не опоздает?\r\n";

            string answers = "а) " + Math.Round(prob_dir * prob_act, 4) + "\n" +
                "б) " + Math.Round(prob_act * (1 - prob_dir), 4) + "\n" +
                "в) " + Math.Round((1 - prob_dir) * (1 - prob_act), 4);

            return new Tuple<string, string>(task, answers);
        }

        public static Tuple<string, string> task2_3_generate()
        {
            double prob = (double)(rnd.Next(1, 20)) / 20;

            string task = "При включении в сеть цепи (рис. 5) каждый " +
                "элемент выходит из строя с вероятностью " + prob + ". " +
                "Найти вероятность того, что в момент включения цепь не разомкнется";

            string answer = Math.Round((1 - prob * prob) * (1 - prob) * (1 - prob * prob), 4).ToString();

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
            Tuple<int, int> fraction = reduceFraction(chisl, znam);
            chisl = fraction.Item1;
            znam = fraction.Item2;
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

            int n = (int)Math.Round((double)k / prob / 10) * 10 + rnd.Next(-4, 4) * 10;

            if (Math.Abs((k - n * prob) / Math.Sqrt(n * prob * (1 - prob))) > 4)
            {
                k = rnd.Next(21, 40) * 10;
                prob = (double)rnd.Next(3, 9) / 10.0;
                n = (int)Math.Round((double)k / prob / 10) * 10 + rnd.Next(-4, 4) * 10;
            }

            string task = "В каждом из " + n + " независимых испытаний событие" +
                " А происходит с постоянной вероятностью " + prob + ". Найти " +
                "вероятность того, что событие А наступит:" +
                "\r\nа) точно " + k + " раз;\r\nб) менее " +
                "чем 240 и более чем 180 раз.\r\n";

            // а)

            double x = (k - n * prob) / Math.Sqrt(n * prob * (1 - prob));

            string answer = "а) " + Math.Round((1 / Math.Sqrt(n * prob * (1 - prob))) * fi(x), 4).ToString();

            // б)

            int k1 = k - (rnd.Next(1, 6) * 10);
            int k2 = k1 + (rnd.Next(3, 6) * 10);

            double x1 = Math.Round((k1 - n * prob) / Math.Sqrt(n * prob * (1 - prob)), 2);
            double x2 = Math.Round((k2 - n * prob) / Math.Sqrt(n * prob * (1 - prob)), 2);

            double fl1 = func_laplace(x1);
            double fl2 = func_laplace(x2);

            while (fl1 >= 4 || fl2 >= 4 || fl1 == fl2)
            {
                k1 = k - (rnd.Next(1, 6) * 10);
                k2 = k1 + (rnd.Next(3, 6) * 10);

                x1 = (k1 - n * prob) / Math.Sqrt(n * prob * (1 - prob));
                x2 = (k2 - n * prob) / Math.Sqrt(n * prob * (1 - prob));

                fl1 = func_laplace(x1);
                fl2 = func_laplace(x2);
            }

            double res = Math.Abs(fl2 - fl1);
            answer += "; б) " + Math.Round(res, 4).ToString();
            return new Tuple<string, string>(task, answer);
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

            string answer = "(" + lambda + "^" + k + "*e^" + (-lambda) + ")/(" + k + "!) ≈ "
                + Math.Round((Math.Pow(lambda, k) * Math.Exp(-lambda)) / factorial(k), 4).ToString();

            return new Tuple<string, string>(task, answer);
        }

        public static Tuple<string, string, string[], string[,]> task5_1_generate()
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

            string answer = "M(X) = " + Math.Round(MX, 4).ToString()
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

            string[] answer_table_headers = { "X", "p" };

            string[,] answer_table_matrix = new string[2, n];
            for (int i = 0; i < n; i++)
                answer_table_matrix[0, i] = (i + 1).ToString();

            for (int i = 0; i < n; i++)
                answer_table_matrix[1, i] = (Math.Round(distribution_series[i], 4).ToString());

            return new Tuple<string, string, string[], string[,]>(task, answer, answer_table_headers, answer_table_matrix);
        }

        public static Tuple<string, string, string[], string[,]> task5_2_generate()
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

            string answer = "M(X) = " + Math.Round(MX, 4).ToString()
                + "\nD(X) = " + Math.Round(DX, 4).ToString();

            string[] answer_table_headers = { "X", "p" };

            string[,] answer_table_matrix = new string[2, n];
            for (int i = 0; i < n; i++)
                answer_table_matrix[0, i] = (i + 1).ToString();
            
            for (int i = 0; i < n; i++)
            {
                answer_table_matrix[1, i] = (Math.Round(distribution_series[i], 4).ToString());
            }

            return new Tuple<string, string, string[], string[,]>(task, answer, answer_table_headers, answer_table_matrix);
        }

        public static Tuple<string, string, string[,], string[,], string[,], string[,], string> task5_4_generate()
        {
            List<int> x_values = new List<int> { 2, 4, 5 };
            List<int> y_values = new List<int> { -1, 1 };

            double px1 = Math.Round((double)(rnd.Next(1, 9)) / 10, 1);
            double px3 = Math.Round((double)(rnd.Next(1, (int)((10 - px1 * 10)))) / 10, 1);
            double px2 = Math.Round(1 - px1 - px3, 1);

            List<double> px = new List<double> { px1, px2, px3 };

            string[,] task_matrix_X = new string[2, 3];
            for (int i = 0; i < 3; i++)
                task_matrix_X[0, i] = x_values[i].ToString();
            for (int i = 0; i < 3; i++)
                task_matrix_X[1, i] = px[i].ToString();

            double py1 = Math.Round((double)(rnd.Next(1, 10)) / 10, 1);
            double py2 = Math.Round(1 - py1, 1);

            List<double> py = new List<double> { py1, py2 };

            string[,] task_matrix_Y = new string[2, 2];
            for (int i = 0; i < 2; i++)
                task_matrix_Y[0, i] = y_values[i].ToString();
            for (int i = 0; i < 2; i++)
                task_matrix_Y[1, i] = py[i].ToString();

            string task = "Независимые случайные величины X и Y " +
                "заданы таблицами распределений.\r\nНайти:\r\n" +
                "1) M(X), M(Y), D(X), D(Y);\r\n" +
                "2) таблицы распределения случайных величин Z_1 = 2X + Y, Z_2 = X * Y;\r\n" +
                "3) M(Z_1), M(Z_2), D(Z_1), D(Z_2) непосредственно по " +
                "таблицам распределений и на основании свойств " +
                "математического ожидания и дисперсии.\r\n";

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
            answer += "2)\n";

            string[,] answer_matrix_Z1 = new string[2, 3];
            for (int i = 0; i < 3; i++)
                answer_matrix_Z1[0, i] = z1_values[i].ToString();
            for (int i = 0; i < 3; i++)
                answer_matrix_Z1[1, i] = pz1[i].ToString();

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

            string[,] answer_matrix_Z2 = new string[2, 3];
            for (int i = 0; i < 3; i++)
                answer_matrix_Z2[0, i] = z2_values[i].ToString();
            for (int i = 0; i < 3; i++)
                answer_matrix_Z2[1, i] = pz2[i].ToString();

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

            string answer2 = "\n3)\nM(Z1) = " + Math.Round(MZ1, 4) +
                ", M(Z2) = " + Math.Round(MZ2, 4) +
                ", D(Z1) = " + Math.Round(DZ1, 4) +
                ", D(Z2) = " + Math.Round(DZ2, 4);

            return new Tuple<string, string, string[,], string[,], string[,], string[,], string>
                (task, answer, task_matrix_X, task_matrix_Y, answer_matrix_Z1, answer_matrix_Z2, answer2);
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