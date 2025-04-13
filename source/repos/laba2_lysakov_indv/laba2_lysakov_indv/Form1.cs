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
            double a = random.Next(10, 100); // a от 1 до 100
            double b = random.Next(10, 100); // b от 1 до 100
            double x = Math.Round(random.NextDouble(), 4);
            //проверка на 0
            if (x == 0 || x > 1)
            {
                label1.Text = "xx";
                //Environment.Exit(1);
                throw new Exception("Ошибка данных;");
            }


            //подсчёт частей деления
            double numerator = Math.Cos(a * x);
            double denominator = Math.Log(x * x + b * x, Math.E);
            //выполнение деления
            double fraction = (numerator / denominator);
            //подсчёт логарифма
            double logPart = Math.Log(Math.PI / (a * x), 2);

            double result = fraction * logPart;
            //делим результат на целое и дробное
            int integerPart = (int)result;
            double fractionalPart = result - integerPart;

            //преобразуем дробь в двоичку
            string binarFractionalPart = BinaryCode(fractionalPart);

            label1.Text = "Результат( целое )" + integerPart.ToString();
            label2.Text = "Результат( дробное )" + binarFractionalPart.ToString();

            static string BinaryCode(double fraction, int maxLength = 10)
            {

                string binary = "";
                if (fraction < 0)
                {
                    fraction = fraction * (-1);
                    Console.WriteLine("Программа перевела бинарку без учета знака выражения");
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
