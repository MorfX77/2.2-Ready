using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PR_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ErrorProvider errorProvider = new ErrorProvider();
        private Dictionary<int, int> CountNumbers(string input, int n)
        {
            Dictionary<int, int> numberCount = new Dictionary<int, int>();
            foreach (char c in input)
            {
                if (Char.IsDigit(c))
                {
                    int number = c - '0';//преобразование из символьной переменной в целочисленное значение
                    if (numberCount.ContainsKey(number))
                    {
                        numberCount[number]++;
                    }
                    else
                    {
                        numberCount[number] = 1;
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введеной строки! Он не должен содержать буквы, числа с запятой или символы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            List<KeyValuePair<int, int>> sortedNumbers = new List<KeyValuePair<int, int>>(numberCount);
            sortedNumbers.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            Dictionary<int, int> result = new Dictionary<int, int>();

            for (int i = 0; i < Math.Min(n, sortedNumbers.Count); i++)
            {
                result.Add(sortedNumbers[i].Key, sortedNumbers[i].Value);
            }
            return result;
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void btn_Perform_Click_1(object sender, EventArgs e)
        {
            try
            {
                string input = textBox_Input.Text;
                if (String.IsNullOrEmpty(textBox_Input.Text))
                {
                    errorProvider.SetError(textBox_Input, "Поле не должно быть пустым");
                    await Task.Delay(1500); // Задержка в 3 секунды
                    errorProvider.SetError(textBox_Input, "");
                }
                if (String.IsNullOrEmpty(textBox_N.Text))
                {
                    errorProvider.SetError(textBox_N, "Поле не должно быть пустым");
                    await Task.Delay(1500); // Задержка в 3 секунды
                    errorProvider.SetError(textBox_N, "");
                }
                else
                {
                    int n = int.Parse(textBox_N.Text);
                    Dictionary<int, int> result = CountNumbers(input, n);
                    listBox_First.Items.Clear();
                    foreach (var kvp in result)
                    {
                        listBox_First.Items.Add($"Число {kvp.Key}: {kvp.Value} раз");
                    }
                }
            }
            catch (OverflowException oe)
            {
                MessageBox.Show("Ой... Кажется вы чуть переборщили!", "Ошибка" + oe.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла какая-то ошибка...", "Ошибка" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox_Input.Clear();
            textBox_N.Clear();
        }
    }
}
