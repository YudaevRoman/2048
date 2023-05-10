using System;
using System.Windows.Forms;

namespace CourseWorkOOP2048
{
    //Класс формы
    public partial class Game2048 : Form
    {
        //Класс игры
        Gaming gaming;

        //Конструктор по умолчанию
        public Game2048()
        {
            InitializeComponent();
            gaming = new Gaming();
            gaming.OnGameOver += Gaming_OnGameOver;
            gaming.OnVictory += Gaming_OnVictory;
            gaming.Start(0, pPlayingField);
        }

        //Оповещение о поражении
        private void Gaming_OnGameOver(object sender, EventArgs e)
        {
            MessageBox.Show(
                "GAME OVER\r\nВаш счёт: " + gaming.GetScore(),
                "Игра окончена"
                );
            //gaming.Start(0, pPlayingField);
        }

        //Оповещение о победе
        private void Gaming_OnVictory(object sender, EventArgs e)
        {
            MessageBox.Show(
                "YOU VICTORY!\r\nВаш счёт: " + gaming.GetScore(),
                "Игра окончена"
                );
            //gaming.Start(0, pPlayingField);
        }

        //Событие нажатия клавиши
        private void Game2048_KeyUp(object sender, KeyEventArgs e)
        {
            gaming.Move(e.KeyCode);
            lShowScore.Text = gaming.GetScore().ToString();
        }

        //Вернуть прошлый результат
        private void вернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gaming.Undo();
            lShowScore.Text = gaming.GetScore().ToString();
        }
        //Повторить действие
        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gaming.Redo();
            lShowScore.Text = gaming.GetScore().ToString();
        }
        //Начать новую игру
        private void начатьНовуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gaming.Start(4, pPlayingField);
            lShowScore.Text = gaming.GetScore().ToString();
        }

        //Выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e) 
            => Close();
    }
}
