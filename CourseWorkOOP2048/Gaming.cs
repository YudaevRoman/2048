using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace CourseWorkOOP2048
{
    //Структуры
    //Структура одной ячейки в поле
    public class Cell : Label 
    {   
        //Конструктор
        public Cell(Color col, ushort num)
        {
            BackColor = col;
            Text = num == 0 ? "" : num.ToString();
            Font = new Font("Arial", 24, FontStyle.Bold);
            TextAlign = ContentAlignment.MiddleCenter;
        }
    }
    //Структура поля
    public struct Field
    {
        //Словари
        //Цвета ячеек
        public Dictionary<ushort, Color> CellColor { get; }
        
        //Свойства
        //Список ячеек
        public Cell[,] Cells { get; set; }
        //Размер поля
        public byte Size { get; set; }
        
        //Конструктор
        public Field(byte size)
        {
            Size = size;
            Cells = new Cell[size, size];
            CellColor = new Dictionary<ushort, Color>();
            CellColor = CreateDictionary();
            for (byte i = 0; i < Size; i++)
                for (byte j = 0; j < Size; j++)
                    Cells[i,j] = new Cell(CellColor[0], 0);
        }

        //Внешние методы
        //Метод обновления ячеек поля
        public void Update()
        {
            for (byte i = 0; i < Size; i++)
                for (byte j = 0; j < Size; j++)
                    if (Cells[i, j].Text == "")
                        Cells[i, j].BackColor = CellColor[0];
                    else Cells[i, j].BackColor =
                        CellColor[Convert.ToUInt16(Cells[i, j].Text)];
        }

        //Внутренние методы
        //Метод составление словаря
        private Dictionary<ushort, Color> CreateDictionary()
        {
            Dictionary<ushort, Color> dictionary;
            dictionary = new Dictionary<ushort, Color>();
            dictionary.Add(0000, Color.FromArgb(216, 206, 196));
            dictionary.Add(0002, Color.FromArgb(240, 228, 217));
            dictionary.Add(0004, Color.FromArgb(238, 225, 199));
            dictionary.Add(0008, Color.FromArgb(253, 175, 112));
            dictionary.Add(0016, Color.FromArgb(255, 143, 086));
            dictionary.Add(0032, Color.FromArgb(255, 112, 080));
            dictionary.Add(0064, Color.FromArgb(255, 070, 018));
            dictionary.Add(0128, Color.FromArgb(241, 210, 104));
            dictionary.Add(0256, Color.FromArgb(241, 208, 086));
            dictionary.Add(0512, Color.FromArgb(240, 203, 065));
            dictionary.Add(1024, Color.FromArgb(242, 201, 039));
            dictionary.Add(2048, Color.FromArgb(243, 197, 000));
            return dictionary;
        }
    }
    
    //Класс игры
    class Gaming
    {
        //События
        //Событие проигрыша
        public event EventHandler OnGameOver;
        //Событие победы
        public event EventHandler OnVictory;

        //Константы
        //Максимальный размер буффера
        private const short maxStateBuffers = 5;

        //Поля 
        //Отрисовка поля
        private Panel map;
        //Игровое поле
        private Field playingField;
        //Расстояние между ячейками
        private byte betweenCells;
        //Размер поля
        private byte fieldSize;
        //Размер одной ячейки
        private ushort cellSize;
        //Очки
        private ushort score = 0;
        //Буфер поля
        private List<StateBuffer> stateBuffers;
        //Текущее положение буффера
        private short currentStateBuffers = 0;

        //Структуры
        public struct StateBuffer
        {
            //Свойства
            //Поле
            public Cell[,] Cells { get; set; }
            //Счёт
            public ushort Score { get; set; }
            
            //Конструкторы
            public StateBuffer(Cell[,] cells, ushort score)
            {
                Cells = new Cell[cells.GetLength(0), cells.GetLength(1)];
                for (byte i = 0; i < cells.GetLength(0); i++)
                    for (byte j = 0; j < cells.GetLength(1); j++)
                    {
                        if (cells[i, j].Text == "")
                        {
                            Cells[i, j] = new Cell(cells[i, j].BackColor, 0);
                        }
                        else
                        {
                            Cells[i, j] = new Cell(
                                cells[i, j].BackColor,
                                Convert.ToUInt16(cells[i, j].Text));
                        }
                    }
                Score = score; 
            }
        }

        //Конструктор
        public Gaming() => betweenCells = 3;

        //Внешние методы
        //Начать игру
        public void Start(byte size, Panel newMap)
        {
            map = newMap;
            fieldSize = size;
            playingField = new Field(fieldSize);
            DataСalculation();
            RandomCell();
            playingField.Update();
            UpdateBuffer(new StateBuffer(playingField.Cells, score));
        }
        //Двигать поле
        public void Move(Keys move)
        {
            if (fieldSize > 0)
            {
                if (FieldMove(move))
                {
                    RandomCell();
                    playingField.Update();
                    UpdateBuffer(new StateBuffer(playingField.Cells, score));
                    if (CheckVictory())
                    {
                        if (OnVictory != null)
                            OnVictory(null, EventArgs.Empty);
                    }
                    else if( CheckGameOver())
                    {
                        if (OnGameOver != null)
                            OnGameOver(null, EventArgs.Empty);
                    }
                }

            }
        }
        //Показать счёт
        public ushort GetScore() => score;
        //Вернуть прошлое состояние
        public void Undo()
        {
            if (currentStateBuffers > 0)
            {
                currentStateBuffers--;
                for (byte i = 0; i < fieldSize; i++)
                    for (byte j = 0; j < fieldSize; j++)
                    {
                        if (stateBuffers[currentStateBuffers].
                                Cells[i, j].Text == "")
                        {
                            playingField.Cells[i, j] = 
                                new Cell(stateBuffers[currentStateBuffers].
                                Cells[i, j].BackColor, 0);
                        }
                        else
                        {
                            playingField.Cells[i, j] =
                                new Cell(
                                    stateBuffers[currentStateBuffers].
                                    Cells[i, j].BackColor,
                                    Convert.ToUInt16(
                                        stateBuffers[currentStateBuffers].
                                        Cells[i, j].Text));
                        }
                    }
                score = stateBuffers[currentStateBuffers].Score;
                ResetField();
            }
        }
        //Возобновить действие
        public void Redo()
        {
            if (currentStateBuffers < stateBuffers.Count - 1)
            {
                currentStateBuffers++;
                for (byte i = 0; i < fieldSize; i++)
                    for (byte j = 0; j < fieldSize; j++)
                    {
                        if (stateBuffers[currentStateBuffers].
                                Cells[i, j].Text == "")
                        {
                            playingField.Cells[i, j] =
                                new Cell(stateBuffers[currentStateBuffers].
                                Cells[i, j].BackColor, 0);
                        }
                        else
                        {
                            playingField.Cells[i, j] =
                                new Cell(
                                    stateBuffers[currentStateBuffers].
                                    Cells[i, j].BackColor,
                                    Convert.ToUInt16(
                                        stateBuffers[currentStateBuffers].
                                        Cells[i, j].Text));
                        }
                    }
                score = stateBuffers[currentStateBuffers].Score;
                ResetField();
            }
        }

        //Внутренние методы
        //Метод проверки поражения
        private bool CheckGameOver()
        {
            for (byte j = 0; j < fieldSize; j++)
                if (CheckMove(Keys.Up, new Point(fieldSize - 1, j)))
                    return false;
            for (byte j = 0; j < fieldSize; j++)
                if (CheckMove(Keys.Down, new Point(0, j)))
                    return false;
            for (byte j = 0; j < fieldSize; j++)
                if (CheckMove(Keys.Left, new Point(j, fieldSize - 1)))
                    return false;
            for (byte j = 0; j < fieldSize; j++)
                if (CheckMove(Keys.Right, new Point(j, 0)))
                    return false;
            return true;
        }
        //Метод проверки победы
        private bool CheckVictory()
        {
            for (byte i = 0; i < fieldSize; i++)
                for (byte j = 0; j < fieldSize; j++)
                {
                    if (
                        playingField.Cells[i, j].Text != "" &&
                        Convert.ToUInt16(playingField.Cells[i, j].Text) == (ushort)2048)
                        return true;
                }
            return false;
        }
        //Обновление буфера
        private void UpdateBuffer(StateBuffer state)
        {
            if (currentStateBuffers != stateBuffers.Count - 1 &&
                stateBuffers.Count > 0)
            {
                while (stateBuffers.Count != currentStateBuffers + 1)
                    stateBuffers.RemoveAt(currentStateBuffers + 1);
            }
            stateBuffers = stateBuffers.Append(state).ToList();
            if (stateBuffers.Count > maxStateBuffers)
            {
                stateBuffers.RemoveAt(0);
                if (currentStateBuffers != stateBuffers.Count - 1)
                    currentStateBuffers--;
            }
            else {
                if (currentStateBuffers == stateBuffers.Count - 2)
                    currentStateBuffers++;
                else if (currentStateBuffers > 0) currentStateBuffers--;
            } 
        }
        //Метод составления списка пустых ячеек
        private List<Point> GetEmptyCells()
        {
            List<Point> emptyCells = new List<Point>();
            for (byte i = 0; i < fieldSize; i++)
                for (byte j = 0; j < fieldSize; j++)
                    if (playingField.Cells[i, j].Text == "")
                        emptyCells.Add(new Point(i, j));
            return emptyCells;
        }
        //Метод генерации  числа в случайной ячейке
        private void RandomCell()
        {
            List<Point> emptyCells = GetEmptyCells();
            if (emptyCells.Count > 0)
            {
                Random ran = new Random();
                int value = (ran.Next(0, 9) == 9) ? 4 : 2;
                int pos = ran.Next(emptyCells.Count);
                playingField.Cells[emptyCells[pos].X, emptyCells[pos].Y].Text =
                    value.ToString();
            }
        }
        //Метод проверка наличия движения
        private bool CheckMove(Keys move, Point pos)
        {
            switch(move)
            {
                case Keys.Up:
                    {
                        if (pos.X - 1 >= 0)
                        {
                            if (
                               playingField.Cells[pos.X - 1, pos.Y].Text == "" ||
                               playingField.Cells[pos.X - 1, pos.Y].Text ==
                               playingField.Cells[pos.X, pos.Y].Text) return true;
                            else return false;
                        }
                        else return false;
                    }
                case Keys.Down:
                    {
                        if (pos.X + 1 <= fieldSize - 1)
                        {
                            if (
                               playingField.Cells[pos.X + 1, pos.Y].Text == "" ||
                               playingField.Cells[pos.X + 1, pos.Y].Text ==
                               playingField.Cells[pos.X, pos.Y].Text) return true;
                            else return false;
                        }
                        else return false;
                    }
                case Keys.Left:
                    {
                        if (pos.Y - 1 >= 0)
                        {
                            if (
                               playingField.Cells[pos.X, pos.Y - 1].Text == "" ||
                               playingField.Cells[pos.X, pos.Y - 1].Text ==
                               playingField.Cells[pos.X, pos.Y].Text) return true;
                            else return false;
                        }
                        else return false;
                    }
                case Keys.Right:
                    {
                        if (pos.Y + 1 <= fieldSize - 1)
                        {
                            if (
                               playingField.Cells[pos.X, pos.Y + 1].Text == "" ||
                               playingField.Cells[pos.X, pos.Y + 1].Text ==
                               playingField.Cells[pos.X, pos.Y].Text) return true;
                            else return false;
                        }
                        else return false;
                    }
                default: return false;
            }
        }
        //Метод движения ячейки
        private bool CellMove(Keys move, Point pos)
        {
            bool check = false;
            switch (move)
            {
                case Keys.Up:
                    {
                        byte count = 0;
                        while (CheckMove(move, new Point(pos.X - count, pos.Y)))
                        {
                            if (!check &&
                                playingField.Cells[pos.X - count, pos.Y].Text != "") 
                                check = true;
                            if (playingField.Cells[pos.X - 1 - count, pos.Y].Text == "")
                            {
                                playingField.Cells[pos.X - 1 - count, pos.Y].Text =
                                    playingField.Cells[pos.X - count, pos.Y].Text;
                            }
                            else
                            {
                                ushort x1 = Convert.ToUInt16(
                                    playingField.Cells[pos.X - count, pos.Y].Text);
                                score += (ushort)(x1 * 2);
                                playingField.Cells[pos.X - 1 - count, pos.Y].Text =
                                    (x1 * 2).ToString();
                            }
                            playingField.Cells[pos.X - count, pos.Y].Text = "";
                            count++;
                        }
                        return check;
                    }
                case Keys.Down:
                    {
                        byte count = 0;
                        while (CheckMove(move, new Point(pos.X + count, pos.Y)))
                        {
                            if (!check &&
                                playingField.Cells[pos.X + count, pos.Y].Text != "")
                                check = true;
                            if (playingField.Cells[pos.X + 1 + count, pos.Y].Text == "")
                            {
                                playingField.Cells[pos.X + 1 + count, pos.Y].Text =
                                    playingField.Cells[pos.X + count, pos.Y].Text;
                            }
                            else
                            {
                                ushort x1 = Convert.ToUInt16(
                                    playingField.Cells[pos.X + count, pos.Y].Text);
                                score += (ushort)(x1 * 2);
                                playingField.Cells[pos.X + 1 + count, pos.Y].Text =
                                    (x1 * 2).ToString();
                            }
                            playingField.Cells[pos.X + count, pos.Y].Text = "";
                            count++;
                        }
                        return check;
                    }
                case Keys.Left:
                    {
                        byte count = 0;
                        while (CheckMove(move, new Point(pos.X, pos.Y - count)))
                        {
                            if (!check &&
                                playingField.Cells[pos.X, pos.Y - count].Text != "")
                                check = true;
                            if (playingField.Cells[pos.X, pos.Y - 1 - count].Text == "")
                            {
                                playingField.Cells[pos.X, pos.Y - 1 - count].Text =
                                    playingField.Cells[pos.X, pos.Y - count].Text;
                            }
                            else
                            {
                                ushort x1 = Convert.ToUInt16(
                                    playingField.Cells[pos.X, pos.Y - count].Text);
                                score += (ushort)(x1 * 2);
                                playingField.Cells[pos.X, pos.Y - 1 - count].Text =
                                    (x1 * 2).ToString();
                            }
                            playingField.Cells[pos.X, pos.Y - count].Text = "";
                            count++;
                        }
                        return check;
                    }
                case Keys.Right:
                    {
                        byte count = 0;
                        while (CheckMove(move, new Point(pos.X, pos.Y + count)))
                        {
                            if (!check &&
                                playingField.Cells[pos.X, pos.Y + count].Text != "")
                                check = true;
                            if (playingField.Cells[pos.X, pos.Y + 1 + count].Text == "")
                            {
                                playingField.Cells[pos.X, pos.Y + 1 + count].Text =
                                    playingField.Cells[pos.X, pos.Y + count].Text;
                            }
                            else
                            {
                                ushort x1 = Convert.ToUInt16(
                                    playingField.Cells[pos.X, pos.Y + count].Text);
                                score += (ushort)(x1 * 2);
                                playingField.Cells[pos.X, pos.Y + 1 + count].Text =
                                    (x1 * 2).ToString();
                            }
                            playingField.Cells[pos.X, pos.Y + count].Text = "";
                            count++;
                        }
                        return check;
                    }
                default: return check;
            }
        }
        //Метод движения ячеек поля
        private bool FieldMove(Keys move)
        {
            bool check = false;
            switch (move)
            {
                case Keys.Up:
                    {
                        for(short i = 0; i < fieldSize; i++)
                            for(short j = 0; j < fieldSize; j++)
                                if(CellMove(move, new Point(i, j)) && !check) 
                                    check = true;
                        return check;
                    }
                case Keys.Down:
                    {
                        for (short i = (short)(fieldSize - 1); i >= 0; i--)
                            for (short j = 0; j < fieldSize; j++)
                                if (CellMove(move, new Point(i, j)) && !check)
                                    check = true;
                        return check;
                    }
                case Keys.Left:
                    {
                        for (short j = 0; j < fieldSize; j++)
                            for (short i = 0; i < fieldSize; i++)
                                if (CellMove(move, new Point(i, j)) && !check)
                                    check = true;
                        return check;
                    }
                case Keys.Right:
                    {
                        for (short j = (short)(fieldSize - 1); j >= 0; j--)
                            for (short i = 0; i < fieldSize; i++)
                                if (CellMove(move, new Point(i, j)) && !check)
                                    check = true;
                        return check;
                    }
                default: return check;
            }
        }
        //Метод сброса поля
        private void ResetField()
        {
            //Очиситить поле
            while (map.Controls.Count > 0) map.Controls.RemoveAt(0);
            //Добавление ячеек к панели
            for (byte i = 0; i < fieldSize; i++)
                for (byte j = 0; j < fieldSize; j++)
                    map.Controls.Add(playingField.Cells[i, j]);
            //Рассчёт размера одной ячейки
            cellSize = (ushort)Math.Round(
                    (((double)map.Width -
                    ((fieldSize + 2) * betweenCells)) /
                    (double)fieldSize)
                );
            //Расположение ячеек на панели
            for (byte i = 0; i < fieldSize; i++)
                for (byte j = 0; j < fieldSize; j++)
                {
                    playingField.Cells[i, j].Location = new Point(
                        cellSize * j + betweenCells * (j + 1),
                        cellSize * i + betweenCells * (i + 1)
                        );
                    playingField.Cells[i, j].Size = new Size(
                            cellSize, cellSize
                        );
                }
        }
        //Метод рассчёт данных поля
        private void DataСalculation()
        {
            //Инициализация буффера
            stateBuffers = new List<StateBuffer>();
            //Текущее положение буффера
            currentStateBuffers = 0;
            //Обнуление счёта
            score = 0;
            //Сбросить поле
            ResetField();
        }
    }
}
