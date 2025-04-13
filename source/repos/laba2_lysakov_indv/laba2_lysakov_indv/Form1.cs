using System;

namespace laba2_lysakov_indv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double a = random.Next(10, 100); // a �� 1 �� 100
            double b = random.Next(10, 100); // b �� 1 �� 100
            double x = Math.Round(random.NextDouble(), 4);
            //�������� �� 0
            if (x == 0 || x > 1)
            {
                label1.Text = "xx";
                //Environment.Exit(1);
                throw new Exception("������ ������;");
            }


            //������� ������ �������
            double numerator = Math.Cos(a * x);
            double denominator = Math.Log(x * x + b * x, Math.E);
            //���������� �������
            double fraction = (numerator / denominator);
            //������� ���������
            double logPart = Math.Log(Math.PI / (a * x), 2);

            double result = fraction * logPart;
            //����� ��������� �� ����� � �������
            int integerPart = (int)result;
            double fractionalPart = result - integerPart;

            //����������� ����� � �������
            string binarFractionalPart = BinaryCode(fractionalPart);

            label1.Text = "���������( ����� )" + integerPart.ToString();
            label2.Text = "���������( ������� )" + binarFractionalPart.ToString();

            static string BinaryCode(double fraction, int maxLength = 10)
            {

                string binary = "";
                if (fraction < 0)
                {
                    fraction = fraction * (-1);
                    Console.WriteLine("��������� �������� ������� ��� ����� ����� ���������");
                }
                while (fraction > 0 && binary.Length < maxLength)
                {
                    fraction *= 2;
                    int bit = (int)fraction;
                    binary += bit.ToString();
                    fraction -= bit;
                }
                return binary.Length == 0 ? "0" : binary;
            }
        }
    }
}
