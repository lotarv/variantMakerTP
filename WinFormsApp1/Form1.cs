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
                MessageBox.Show("������� ��������� ��������� ����!");
                return;
            }

            //���������� ��������� � ��������: (TEST VERSION)

            // �������� ����������� ���� ������ �����
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Word Documents (*.docx)|*.docx",
                Title = "��������� �������� Word",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    // ���������� ��������� ���������
                    MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // ���������� ������
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());

                    // ���������� ������
                    run.AppendChild(new Text($"������� ��������� ������:\n\n"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text("����� 1"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text($"{GenereationConfig.amount1_1} ����� #1 � {GenereationConfig.amount1_2} ����� #2"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text("����� 2"));

                    para = body.AppendChild(new Paragraph());
                    run = para.AppendChild(new Run());

                    run.AppendChild(new Text($"{GenereationConfig.amount2_1} ����� # 1 � {GenereationConfig.amount2_2} ����� #2"));




                    // ���������� ���������
                    mainPart.Document.Save();
                }

                MessageBox.Show("�������� ������� ������ ��� ��������.");
            }




        }
    }
}
