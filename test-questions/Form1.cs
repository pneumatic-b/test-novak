using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test_questions
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//начальные настройки
			panelQ1.Show();
			panelQ2.Hide();
			panelQ3.Hide();
			rbQ1none.Checked = true;
		}

		private void rbQ1red_CheckedChanged(object sender, EventArgs e)
		{
			//чистим открытый вопрос
			if (textQ1other.Text != "")
			{
				textQ1other.Text = "";
				textQ1other.ReadOnly = true;
			}
			
			textQ1.Text = "Красный";
		}

		private void rbQ1black_CheckedChanged(object sender, EventArgs e)
		{
			//чистим открытый вопрос
			if (textQ1other.Text != "")
			{
				textQ1other.Text = "";
				textQ1other.ReadOnly = true;
			}
			textQ1.Text = "Чёрный";

		}

		private void rbQ1white_CheckedChanged(object sender, EventArgs e)
		{
			//чистим открытый вопрос
			if (textQ1other.Text != "")
			{
				textQ1other.Text = "";
				textQ1other.ReadOnly = true;
			}

			textQ1.Text = "Белый";
		}

		private void rbQ1none_CheckedChanged(object sender, EventArgs e)
		{
			//чистим открытый вопрос
			if (textQ1other.Text != "")
			{
				textQ1other.Text = "";
				textQ1other.ReadOnly = true;
			}

			textQ1.Text = "Нет любимого";
		}

		private void rbQ1other_CheckedChanged(object sender, EventArgs e)
		{
			textQ1other.ReadOnly = false;
			textQ1.Text = "";
		}

		private void textQ1other_TextChanged(object sender, EventArgs e)
		{
			textQ1.Text = textQ1other.Text.Replace(",", ";");
		}
		//перейти от первого вопроса ко второму или третьему
		private void btQ1forward_Click(object sender, EventArgs e)
		{
			//проверка заполнен ли другой цвет
			if (rbQ1other.Checked && textQ1other.Text == "")
			{
				string err = "Ваш цвет не заполнен";
				MessageBox.Show(err);
				return;
			}
			
			//проверка на то, к какому вопросу возвращаться
			if (textQ1.Text == "Нет любимого")
			{
				panelQ3.Show();
				panelQ2.Hide();
				panelQ1.Hide();
			}
			else
			{
				panelQ3.Hide();
				panelQ2.Show();
				panelQ1.Hide();
			}
		}

		private void cbQ1_1_Click(object sender, EventArgs e)
		{
			if (cbQ2_1.Checked)
			{
				textQ2_1.Text = "С домом";
				//несовместимые ответы
				if (cbQ2_5.Checked)
				{
					cbQ2_5.Checked = false;
				}
			}
			else
			{
				textQ2_1.Text = "Не выбран";
			}
		}

		private void cbQ1_2_Click(object sender, EventArgs e)
		{
			if (cbQ2_2.Checked)
			{
				textQ2_2.Text = "С природой";
				//несовместимые ответы
				if (cbQ2_5.Checked)
				{
					cbQ2_5.Checked = false;
				}
			}
			else
			{
				textQ2_2.Text = "Не выбран";
			}
		}

		private void cbQ1_3_Click(object sender, EventArgs e)
		{
			if (cbQ2_3.Checked)
			{
				textQ2_3.Text = "С эмоциями";
				//несовместимые ответы
				if (cbQ2_5.Checked)
				{
					cbQ2_5.Checked = false;
				}
			}
			else
			{
				textQ2_3.Text = "Не выбран";
			}
		}

		private void cbQ1_4_Click(object sender, EventArgs e)
		{
			if (cbQ2_4.Checked)
			{
				textQ2other.ReadOnly = false;
				//несовместимые ответы
				if (cbQ2_5.Checked)
				{
					cbQ2_5.Checked = false;
				}
			}
			else
			{
				textQ2_4.Text = "Не выбран";
				textQ2other.ReadOnly = true;
			}
		}
		private void textQ2other_TextChanged(object sender, EventArgs e)
		{
			textQ2_4.Text = textQ2other.Text.Replace(",", ";");
		}
		private void cbQ1_5_Click(object sender, EventArgs e)
		{
			if (cbQ2_5.Checked)
			{
				textQ2_5.Text = "Затрудняюсь ответить";

				//отменяем другие выборы
				textQ2_1.Text = "Не выбран";
				cbQ2_1.Checked = false;

				textQ2_2.Text = "Не выбран";
				cbQ2_2.Checked = false;

				textQ2_3.Text = "Не выбран";
				cbQ2_3.Checked = false;

				textQ2_4.Text = "Не выбран";
				textQ2other.Text = "";
				textQ2other.ReadOnly = true;
				cbQ2_4.Checked = false;

			}
			else
			{
				textQ2_5.Text = "Не выбран";
			}
		}
		//вернуться со второго вопроса к первому
		private void btQ2back_Click(object sender, EventArgs e)
		{
			//проверка открытого вопроса
			if (cbQ2_4.Checked && textQ2other.Text == "")
			{
				string err = "Ваша связь не заполнена";
				MessageBox.Show(err);
				return;
			}

			panelQ1.Show();
			panelQ2.Hide();
			panelQ3.Hide();
		}
		//перейти от второго вопроса к третьему
		private void btQ2forward_Click(object sender, EventArgs e)
		{
			//проверка открытого вопроса
			if (cbQ2_4.Checked && textQ2other.Text == "")
			{
				string err = "Ваша связь не заполнена";
				MessageBox.Show(err);
				return;
			}

			panelQ1.Hide();
			panelQ2.Hide();
			panelQ3.Show();
		}

		private void checkedListQ3_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void checkedListQ3_ItemCheck(object sender, ItemCheckEventArgs e)
		{

			int sCount = checkedListQ3.CheckedItems.Count;
			if (e.NewValue == CheckState.Checked) { ++sCount; }
			if (e.NewValue == CheckState.Unchecked) { --sCount; }
			//поверка на количество ответов
			if (sCount > 3)
			{
				string err = "Выбрано больше трёх вариантов";
				e.NewValue = CheckState.Unchecked;
				MessageBox.Show(err);
			}
					   
		}

		private void checkedListQ3_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			textQ3_3.Text = "Не выбран";
			textQ3_2.Text = "Не выбран";
			textQ3_1.Text = "Не выбран";
			
			//проверяем не пустой ли список
			if (checkedListQ3.CheckedItems.Count != 0)
			{
				
				// если выбрано 3 варианта
				if (checkedListQ3.CheckedItems.Count > 2)
				{
					textQ3_3.Text = checkedListQ3.CheckedItems[2].ToString();
				}
				// если выбрано 2 варианта
				if (checkedListQ3.CheckedItems.Count > 1)
				{
					textQ3_2.Text = checkedListQ3.CheckedItems[1].ToString();
				}
				// если выбран 1 вариант
				if (checkedListQ3.CheckedItems.Count > 0)
				{
					textQ3_1.Text = checkedListQ3.CheckedItems[0].ToString();
				}
			}
		}

		private void btQ3back_Click(object sender, EventArgs e)
		{
			//проверка на то, к какому вопросу возвращаться
			if (textQ1.Text == "Нет любимого")
			{
				panelQ3.Hide();
				panelQ2.Hide();
				panelQ1.Show();
			}
			else
			{
				panelQ3.Hide();
				panelQ2.Show();
				panelQ1.Hide();
			}

		}

		private void save_Click(object sender, EventArgs e)
		{
			//собираем файл
			string csv = "";

			//заголовки
			{
				csv += "Вопрос,Ответ\r\n";
			}

			//первый вопрос
			csv += "Q1. Ваш любимый цвет," + textQ1.Text.ToString() + "\r\n";

			//второй вопрос
			if (textQ1.Text != "Нет любимого") 
			{ 
				csv += "Q2. С чем вы связываете ваш любимый цвет," + textQ2_1.Text.ToString() + "\r\n";
				csv += "Q2. С чем вы связываете ваш любимый цвет," + textQ2_2.Text.ToString() + "\r\n";
				csv += "Q2. С чем вы связываете ваш любимый цвет," + textQ2_3.Text.ToString() + "\r\n";
				csv += "Q2. С чем вы связываете ваш любимый цвет," + textQ2_4.Text.ToString() + "\r\n";
				csv += "Q2. С чем вы связываете ваш любимый цвет," + textQ2_5.Text.ToString() + "\r\n";
			}
			else
			{
				csv += "Q2. С чем вы связываете ваш любимый цвет,Пропущен\r\n";
			}

			//третий вопрос
			csv += "Q3. Назовите ваши любимые нечётные числа среди названных," + textQ3_1.Text.ToString() + "\r\n";
			csv += "Q3. Назовите ваши любимые нечётные числа среди названных," + textQ3_2.Text.ToString() + "\r\n";
			csv += "Q3. Назовите ваши любимые нечётные числа среди названных," + textQ3_3.Text.ToString() + "\r\n";

			//выбираем папку и файл
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.CheckPathExists = true;
			saveFileDialog1.InitialDirectory = Application.StartupPath;
			saveFileDialog1.Title = "Сохраняем в CSV";
			saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
			saveFileDialog1.FilterIndex = 2;
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{

				//Пишем
				File.WriteAllText(saveFileDialog1.FileName, csv);
				string mess = "Файл записан";
				MessageBox.Show(mess);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
