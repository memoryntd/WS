using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // юзинг для работы с базой SQL Server

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(/*Строка подключения. Можно найти в Обозреватель серверов, в свойствах своего сервера*/);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open(); // Открытие подключения при загрузке формы

            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSet.Name" 
            this.NameTableAdapter.Fill(this.DataSet.Name); // Можно использовать для обновления DataGrid (таблиц на форме)
        }


        private void addButtonName_Click(object sender, EventArgs e)
        {
            //Строка запроса на добавление
            string sql = $@"INSERT INTO TableName (Cell1 , Cell2) VALUES ('{Cell1_TextBox.Text}' , '{Cell2_TextBox.Text}')"; 
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    label_Message.Text = "Успешно"; //Сообщение для пользователя на форме

                    // TODO: Следующими строками можно очищать поля где была введена информация
                    Cell1_TextBox.Text = "";
                    Cell2_TextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                label_Message.Text = ex.ToString() + "Ошибка"; // Сообщение для пользователя на форме с выдачей ошибки
            }
        }
        private void updateButtonName_Click(object sender, EventArgs e)
        {
            // TODO: Строка на обновление записи с выбранным ID новыми данными из текстбоксов на форме.
            string sql = $@"UPDATE TableName SET Cell1 = '{Cell1_TextBox.Text}', Cell2 = '{Cell2_TextBox.Text}' WHERE ID = '{ID_TextBox.Text}'";

            SqlCommand command = new SqlCommand(sql, connection);


            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    label_Message.Text = "Успешно";

                    Cell1_TextBox.Text = "";
                    Cell2_TextBox.Text = "";
                    ID_TextBox.Text = "";

                }

            }
            catch (Exception ex)
            {
                label_Message.Text = ex.ToString() + "Ошибка";

                MessageBox.Show(ex.ToString()); // Еще один способ вывода ошибки в отдельное окно. Полезно когда размеров формы не хватает для вывода всей ошибки
            }
        }
        private void deleteButtonName_Click(object sender, EventArgs e)
        {
            // TODO: Строка на обновление записи с выбранным ID новыми данными из текстбоксов на форме.
            string sql = $@"DELETE FROM TableName WHERE ID = '{ID_TextBox.Text}'";

            SqlCommand command = new SqlCommand(sql, connection);


            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    label_Message.Text = "Успешно";
                    ID_TextBox.Text = "";

                }

            }
            catch (Exception ex)
            {
                label_Message.Text = ex.ToString() + "Ошибка";

                MessageBox.Show(ex.ToString()); // Еще один способ вывода ошибки в отдельное окно. Полезно когда размеров формы не хватает для вывода всей ошибки
            }
        }

    }
}
