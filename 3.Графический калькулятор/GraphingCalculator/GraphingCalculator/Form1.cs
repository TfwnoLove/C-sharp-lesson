using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphingCalculator
{
    public partial class Form1 : Form
    {
        float a, b;
        int oper;
        bool sign = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //обработчик кнопки 1
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 1;
        }
        //обработчик кнопки 0
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 4;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 5;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 6;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 7;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 8;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + 9;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);//в а записываем значение из текстового поля преобразуя во float
            textBox1.Clear();//очищаем текстовое поле, чтобы ввести 2й операнд
            oper = 1;//номер оператора для +
            label1.Text = a.ToString() + "+";//занести значение а и +
        }

        private void button16_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);//в а записываем значение из текстового поля преобразуя во float
            textBox1.Clear();//очищаем текстовое поле, чтобы ввести 2й операнд
            oper = 2;//номер оператора для +
            label1.Text = a.ToString() + "-";//занести значение а и -
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ",";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            calc();
            label1.Text = "";
        }

       

        private void button15_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);//в а записываем значение из текстового поля преобразуя во float
            textBox1.Clear();//очищаем текстовое поле, чтобы ввести 2й операнд
            oper = 3;//номер оператора для +
            label1.Text = a.ToString() + "*";//занести значение а и *
        }

        private void button14_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);//в а записываем значение из текстового поля преобразуя во float
            textBox1.Clear();//очищаем текстовое поле, чтобы ввести 2й операнд
            oper = 4;//номер оператора для +
            label1.Text = a.ToString() + "/";//занести значение а и /
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(sign == true)//если знак true то меняем знак операнда
            {
                textBox1.Text = "-" + textBox1.Text;
                sign = false;
            }
            else if (sign == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");//если false то удаляем знак
                sign = true;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void calc()
        {
            switch (oper)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                case 4:
                    b = a / float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    break;
                default:
                    break;
            }
        }
    }
}
