using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace GraphicalEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ActionTabs.SelectTab(StartTab); //открытие специальной пустой вкладки при запуске программы
            yozPic.Image = new Bitmap(274, 274);
            xozPic.Image = new Bitmap(274, 274);
            xoyPic.Image = new Bitmap(274, 274);
            izomPic.Image = new Bitmap(274, 274);
        }

        #region Глобальные переменные
        public double[,] vertexes_arr = new double[1000, 4]; //список вершин
        public bool figureIsChanged = false;   // были ли изменения после сохранения?
        public double[,] vertexes_norm = new double[1000, 4]; //нормированные координаты
        public double[,] edges_arr = new double[1000, 3]; //список ребер
        public string filename = ""; //название файла
        public double k = 1; //коэффициент нормировки
        double shiftX = 0; //сдвиг
        double shiftY = 0;
        double shiftZ = 0;
        Color panelsBackColor = ColorTranslator.FromHtml("#e2eef6");
        #endregion

        #region Проверка текстовых полей
        /// <summary>
        /// Позволяет вести числовые данные в textbox только в стандартной форме. Для события KeyPress.
        /// </summary>
        /// <param name="TB">Name textBox'a </param>
        /// <param name="e">Просто e</param>
        /// <param name="min">Если нужен минус, то true</param>
        private void PressKey(TextBox TB, bool min, KeyPressEventArgs e)
        {

            if ((e.KeyChar <= 43 /*+*/ || e.KeyChar >= 58 /*:*/) //мат. знаки и цифры
                && e.KeyChar != 8 /*BS*/ || e.KeyChar == 47 /* /, точка в русской */)
                e.Handled = true;

            if (e.KeyChar == '.') e.KeyChar = ',';

            if (e.KeyChar == ',' && TB.Text.IndexOf(",") != -1)
                e.Handled = true;

            if (min == true)
            {
                if (e.KeyChar == '-' && TB.Text.IndexOf("-") != -1)
                    e.Handled = true;

                if (e.KeyChar == '-' && TB.SelectionStart != 0)
                    e.Handled = true;
            }
            else
            {
                if (e.KeyChar == '-')
                    e.Handled = true;
            }
        }

        // ПРОВЕРКА ВВОДА В ТЕКСТОВЫЕ ПОЛЯ
        //true - будет минус

        private void keyPress_withoutMinus(object sender, KeyPressEventArgs e)
        {
            TextBox text = sender as TextBox;
            PressKey(text, false, e);
        }

        private void keyPress_withMinus(object sender, KeyPressEventArgs e)
        {
            TextBox text = sender as TextBox;
            PressKey(text, true, e);
        }
        #endregion
        
        #region Функции
        /// <summary>
        /// Обновляет количество элементов в DataGridView
        /// </summary>
        /// <param name="dg">DataGridView для пересчёта количества элементов</param>
        /// <param name="e">Просто е</param>
        private void gridCounter(DataGridView dg, EventArgs e) {
            for (int i = 0; i < dg.RowCount; i++)
            {
                DataGridViewRowHeaderCell cell = dg.Rows[i].HeaderCell;
                cell.Value = (i + 1).ToString();
                dg.Rows[i].HeaderCell = cell;
            }
        }

        /// <summary>
        /// Возвращает булеву переменную. Если true - в массиве вершин уже есть такая точка.
        /// </summary>
        /// <returns></returns>
        private bool searchDuplicatePoint()
        {
            bool err = false;
            if (vertexes_arr != null)
                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    if (vertexes_arr[i, 1] == Convert.ToDouble(vertexTB_X.Text) && vertexes_arr[i, 2] == Convert.ToDouble(vertexTB_Y.Text) && vertexes_arr[i, 3] == Convert.ToDouble(vertexTB_Z.Text))
                    {
                        MessageBox.Show("Такая точка уже есть!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true;
                    }
            return (err);
        }

        /// <summary>
        /// Возвращает булеву переменную. Если true - в массиве уже есть такое ребро
        /// </summary>
        /// <returns></returns>
        private bool searchDuplicateEdge()
        {
            bool err = false;
            if (edges_arr != null)
                for (int i = 0; edges_arr[i, 0] == -1; i++)
                    if ((edges_arr[i, 1] == Convert.ToDouble(edgeTB_start.Text) && edges_arr[i, 2] == Convert.ToDouble(edgeTB_end.Text)) || (edges_arr[i, 2] == Convert.ToDouble(edgeTB_start.Text) && edges_arr[i, 1] == Convert.ToDouble(edgeTB_end.Text)))
                    {
                        MessageBox.Show("Такое ребро уже есть!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true;
                    }
            return err;
        }

        /// <summary>
        /// Нормирует координаты по заранее найденным коэффициентам.
        /// </summary>
        /// <param name="vertex">массив вершин</param>
        /// <returns></returns>
        private double[,] normalizationCoordinates(double[,] vertexes)
        {
            vertexes = (double[,])vertexes.Clone();
            vertexes = shiftOrigin(vertexes);

            for (int i = 0; vertexes[i, 0] == -1; i++)
            {
                vertexes[i, 1] = vertexes[i, 1] / k;
                vertexes[i, 2] = vertexes[i, 2] / k;
                vertexes[i, 3] = vertexes[i, 3] / k;
            }
            return vertexes;
        }

        /// <summary>
        /// Проверяет, приведен ли массив к нормированным координатам.
        /// </summary>
        /// <param name="vertexes">массив координат вершин</param>
        /// <returns></returns>
        private bool normalizationCheck(double[,] vertexes)
        {
            for (int i = 0; vertexes[i, 0] == -1; i++)
            {
                if (vertexes[i, 1] > 1 || vertexes[i, 1] < 0) return false;
                if (vertexes[i, 2] > 1 || vertexes[i, 2] < 0) return false;
                if (vertexes[i, 3] > 1 || vertexes[i, 3] < 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Выполняет сдвиг в начало координат
        /// </summary>
        /// <param name="vertexes">Матрица вершин double[,]</param>
        /// <returns></returns> 
        private double[,] shiftOrigin(double[,] vertexes)
        {
            vertexes = (double[,])vertexes.Clone();

            for (int i = 0; vertexes[i, 0] == -1; i++)  //двигаем каждую координату
            {
                vertexes[i, 1] = vertexes[i, 1] - shiftX;
                vertexes[i, 2] = vertexes[i, 2] - shiftY;
                vertexes[i, 3] = vertexes[i, 3] - shiftZ;
            }
            return vertexes;
        }

        /// <summary>
        /// Передает DataGridView в двумерный массив
        /// </summary>
        /// <param name="DG">Имя DataGridView</param>
        /// <returns>Возвращает массив</returns>
        private double[,] gridToArray(DataGridView DG)
        {
            int size = 0, size2 = 0;
            size = DG.RowCount;
            size2 = DG.ColumnCount;

            double[,] array = new double[1000, 4];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size2; j++)
                    array[i, j] = double.Parse(DG.Rows[i].Cells[j].Value.ToString());

            return array;
        }

        /// <summary>
        /// Находит коэффициенты нормировки и сдвига и присваивает их публичным переменным
        /// </summary>
        /// <param name="vertexes">массив координат вершин</param>
        private void coefficient(double[,] vertexes)
        {
            shiftX = vertexes[0, 1];
            shiftY = vertexes[0, 2];
            shiftZ = vertexes[0, 3];

            for (int i = 0; vertexes[i, 0] == -1; i++)
            {
                if (vertexes[i, 1] < shiftX) shiftX = vertexes[i, 1];
                if (vertexes[i, 2] < shiftY) shiftY = vertexes[i, 2];
                if (vertexes[i, 3] < shiftZ) shiftZ = vertexes[i, 3];
            }

            double[,] dv = (double[,])vertexes.Clone();
            dv = shiftOrigin(dv);
            for (int i = 0; dv[i, 0] == -1; i++)
            { 
                if (dv[i, 1] > k) k = dv[i, 1];
                if (dv[i, 2] > k) k = dv[i, 2];
                if (dv[i, 3] > k) k = dv[i, 3];
            }
        }

        /// <summary>
        /// Возвращает двумерный массив размером [1,4] полученный в результате умножения двух матриц
        /// <param name="A">Матрица [1,4], либо правим код. </param>
        /// <param name="B">Матрица [4,4], либо правим код. </param>
        /// </summary>

        private double[,] matrixMultiply(double[,] A, double[,] B)
        {
            double[,] C = new double[1, 4];
            int m = 0, n = 0, k = 0, l = 0, i = 0, j = 0; //A[m,n] B[k,l] C[i,j];

            while (i < 4)
            {
                while (j < 1)
                {
                    while (n < 4)
                    {
                        C[j, i] = C[j, i] + A[m, n] * B[k, l];
                        n++; k++;
                    }
                    j++; m++;
                    n = 0; k = 0;
                }
                j = 0; m = 0; n = 0; k = 0;
                i++; l++;
            }
            return C;
        }

        /// <summary>
        /// Рисует по таблице координат во всех плоскостях
        /// </summary>
        /// <param name="vertexes">Массив вершин</param>
        /// <param name="edges">Массив ребер</param>
        private void drawImages(double[,] vertexes, double[,] edges)
        {
            Color lineColor = ColorTranslator.FromHtml("#000000");
            
            //YOZ
            Graphics yoz = Graphics.FromImage(yozPic.Image);
            yoz.Clear(panelsBackColor);
            int horizon_origin = 10, vertical_origin = yozPic.Height - 10; //смещение начала координат
            int horizon_max = yozPic.Width - 20, vertical_max = yozPic.Height - 20; //Максимальное увеличение
            yoz.TranslateTransform((float)horizon_origin, (float)vertical_origin);

            for (int i = 0; edges[i, 0] == -1; i++)
            {
                int y1 = (int)Math.Truncate(vertexes[Convert.ToInt32(edges[i, 1]) - 1, 2] * horizon_max);
                int z1 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 1]) - 1, 3] * -1 * vertical_max));
                int y2 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i,2]-1),2] * horizon_max));
                int z2 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 2]-1), 3] * -1 * vertical_max));

                Point point1 = new Point(y1, z1);
                Point point2 = new Point(y2, z2);
                yoz.SmoothingMode = SmoothingMode.HighQuality;
                yoz.DrawLine(new Pen(lineColor, 1), point1, point2);
            }
            yoz.Dispose();
            yozPic.Invalidate();

            //XOZ
            Graphics xoz = Graphics.FromImage(xozPic.Image);
            xoz.Clear(panelsBackColor);
            xoz.TranslateTransform((float)horizon_origin, (float)vertical_origin);

            for (int i = 0; edges[i, 0] == -1; i++)
            {
                int x1 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 1]) - 1, 1] * horizon_max));
                int z1 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 1]) - 1, 3] * -1 * vertical_max));
                int x2 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 2] - 1), 1] * horizon_max));
                int z2 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 2] - 1), 3] * -1 * vertical_max));

                Point point1 = new Point(x1, z1);
                Point point2 = new Point(x2, z2);
                xoz.SmoothingMode = SmoothingMode.HighQuality;
                xoz.DrawLine(new Pen(lineColor, 1), point1, point2);
            }
            xoz.Dispose();
            xozPic.Invalidate();

            //XOY
            Graphics xoy = Graphics.FromImage(xoyPic.Image);
            xoy.Clear(panelsBackColor);
            horizon_origin = 10; vertical_origin = 10; //смещение начала координат
            horizon_max = xoyPic.Width - 20; vertical_max = xoyPic.Height - 20; //Максимальное увеличение
            xoy.TranslateTransform((float)horizon_origin, (float)vertical_origin);

            for (int i = 0; edges[i, 0] == -1; i++)
            {
                int x1 = (int)Math.Truncate(vertexes[Convert.ToInt32(edges[i, 1] - 1), 1] * horizon_max);
                int y1 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 1] - 1), 2] * 1 * vertical_max));
                int x2 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 2] - 1), 1] * horizon_max));
                int y2 = (int)(Math.Truncate(vertexes[Convert.ToInt32(edges[i, 2] - 1), 2] * 1 * vertical_max));

                Point point1 = new Point(y1, x1);
                Point point2 = new Point(y2, x2);
                xoy.SmoothingMode = SmoothingMode.HighQuality;
                xoy.DrawLine(new Pen(lineColor, 1), point1, point2);
            }
            xoy.Dispose();
            xoyPic.Invalidate();


            //ИЗОМЕТРИЯ
            Graphics izom = Graphics.FromImage(izomPic.Image);
            izom.Clear(panelsBackColor);
            horizon_origin = 10; vertical_origin = izomPic.Height - 10; //смещение начала координат
            horizon_max = izomPic.Width - 15; vertical_max = izomPic.Height - 15; //Максимальное увеличение
            izom.TranslateTransform((float)horizon_origin, (float)vertical_origin);

            //Матрица для построенния изометрии
            double alpha_r = 45 * (Math.PI / 180);
            double beta_r = 35.26439 * Math.PI / 180;
            double[,] izomMatrix = new double[4, 4]
            {
                    {Math.Cos(alpha_r), Math.Sin(alpha_r)*Math.Sin(beta_r), 0, 0 },
                    {0, Math.Cos(alpha_r), 0, 0 },
                    {Math.Sin(alpha_r), -1*Math.Cos(alpha_r)*Math.Sin(beta_r), 0, 0 },
                    {0, 0, 0, 1 }
            };

            //Перевод градусов в радианы
            double alpha = 180 * Math.PI / 180;
            double beta = 270 * Math.PI / 180;

            //Поворот относительно оси Z
            double[,] Rz = new double[4, 4]
            {
                {Math.Cos(alpha), Math.Sin(alpha), 0, 0 },
                {-1*Math.Sin(alpha), Math.Cos(alpha), 0, 0 },
                {0, 0, 1, 0 },
                {0, 0, 0, 1 }
            };

            //Поворот относительно оси X
            double[,] Rx = new double[4, 4]
            {
                {1, 0, 0, 0 },
                {0, Math.Cos(beta), Math.Sin(beta), 0 },
                {0, -1*Math.Sin(beta), Math.Cos(beta), 0 },
                {0, 0, 0, 1 }
            };

            double[,] startEdgeCoord = new double[1, 4]; //Координаты начала ребра
            double[,] endEdgeCoord = new double[1, 4]; //Координаты конца ребра

            for (int i = 0; edges[i, 0] == -1; i++)
            {
                startEdgeCoord[0, 0] = vertexes[Convert.ToInt32(edges[i, 1] - 1), 1]; //Запоминаем координаты вершин
                startEdgeCoord[0, 1] = vertexes[Convert.ToInt32(edges[i, 1] - 1), 2];
                startEdgeCoord[0, 2] = vertexes[Convert.ToInt32(edges[i, 1] - 1), 3];
                startEdgeCoord[0, 3] = 1;
                endEdgeCoord[0, 0] = vertexes[Convert.ToInt32(edges[i, 2] - 1), 1]; //Запоминаем координаты вершин
                endEdgeCoord[0, 1] = vertexes[Convert.ToInt32(edges[i, 2] - 1), 2];
                endEdgeCoord[0, 2] = vertexes[Convert.ToInt32(edges[i, 2] - 1), 3];
                endEdgeCoord[0, 3] = 1;

                startEdgeCoord = matrixMultiply(startEdgeCoord, Rz); //Поворачиваем
                startEdgeCoord = matrixMultiply(startEdgeCoord, Rx);
                startEdgeCoord = matrixMultiply(startEdgeCoord, izomMatrix); //и умножаем на общую матрицу изометрии

                endEdgeCoord = matrixMultiply(endEdgeCoord, Rz);
                endEdgeCoord = matrixMultiply(endEdgeCoord, Rx);
                endEdgeCoord = matrixMultiply(endEdgeCoord, izomMatrix);

                Point point1 = new Point((int)(Math.Truncate(horizon_max * 0.5 + startEdgeCoord[0, 0] * horizon_max * 0.5)), (int)((-1) * (Math.Truncate(vertical_max * 0.5 + startEdgeCoord[0, 1] * vertical_max * 0.5))));
                Point point2 = new Point((int)(Math.Truncate(horizon_max * 0.5 + endEdgeCoord[0, 0] * horizon_max * 0.5)), (int)((-1) * (Math.Truncate(vertical_max * 0.5 + endEdgeCoord[0, 1] * vertical_max * 0.5))));

                izom.SmoothingMode = SmoothingMode.HighQuality;
                izom.DrawLine(new Pen(lineColor, 1), point1, point2);
            }
            izom.Dispose();
            izomPic.Invalidate();
        }

        /// <summary>
        /// Заносит значение в StatusStrip, не удаляя при этом заголовочную информацию в нём
        /// </summary>
        /// <param name="label">Элемент, к которому обращаемся</param>
        /// <param name="n">Значение к занесению</param>
        private void editTSS(ToolStripStatusLabel label, double n)
        {
            if (!(label.Text.EndsWith("=")))
                label.Text = label.Text.Remove(3);
            label.Text = label.Text + Convert.ToString(n);
        }

        /// <summary>
        /// Удаление всей графики с рисунка, замена на сплошной фон
        /// </summary>
        /// <param name="i">Элемент PictureBox</param>
        private void clearImage(PictureBox i) {
            Graphics g = Graphics.FromImage(i.Image);
            g.Clear(panelsBackColor);
            g.Dispose();
            i.Invalidate();
        }

        /// <summary>
        /// Возвращает значение из StatusStrip для дальнейшего использования
        /// </summary>
        /// <param name="label">Элемент, к которому обращаемся</param>
        private double readTSS(ToolStripStatusLabel label)
        {
            return Convert.ToDouble(label.Text.Remove(0, 3));
        }

        /// <summary>
        /// диалог открыть
        /// </summary>
        /// <param name="vertex">Двумерный массив. Список вершин</param>
        /// <param name="edge">Двумерный массив. Список ребер</param>
        private void openFile(double[,] vertex, double[,] edge)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "nikitenich's graphical format (*.ngf)|*.ngf";
            OFD.Title = "Открыть документ";
            if (OFD.ShowDialog() != DialogResult.Cancel)
                try
                {
                    Array.Clear(vertex, 0, 1000);
                    Array.Clear(edge, 0, 1000);
                    StreamReader f = new StreamReader(OFD.FileName);
                    string read = null;
                    read = f.ReadLine();
                    read = f.ReadLine();
                    for (int i = 0; read != "Edge"; i++)   //выводим массив вершин
                        for (int j = 0; j < 4; j++)
                        {
                            vertex[i, j] = Convert.ToDouble(read);
                            read = f.ReadLine();
                        }
                    read = f.ReadLine();
                    for (int i = 0; read != null; i++)   //выводим массив ребер
                        for (int j = 0; j < 3; j++)
                        {
                            edge[i, j] = Convert.ToDouble(read);
                            read = f.ReadLine();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), ex.Source);
                }
            filename = OFD.FileName;
            figureIsChanged = false;
        }

        /// <summary>
        /// Диалог "Сохранить как...".
        /// </summary>
        /// <param name="vertex">Двумерный массив. Список вершин</param>
        /// <param name="edge">Двумерный массив. Список ребер</param>

        private void saveAS(double[,] vertex, double[,] edge)
        {
            if (figureIsChanged == true)
            {
                StreamWriter SW;
                SaveFileDialog SFD = new SaveFileDialog();
                if (filename == "" || filename == null)
                {
                    SFD.FileName = "";
                    SFD.Filter = "nikitenich's graphical format (*.ngf)|*.ngf";

                    if (SFD.ShowDialog() == DialogResult.OK)
                    {
                        SW = new StreamWriter(SFD.FileName);
                        SW.Write("Vertex\n");
                        for (int i = 0; vertex[i, 0] == -1; i++)   //массив вершин
                            for (int j = 0; j < 4; j++)
                                SW.Write(vertex[i, j] + "\n");
                        SW.Write("Edge\n");

                        for (int i = 0; edge[i, 0] == -1; i++)   //массив ребер
                            for (int j = 0; j < 3; j++)
                                SW.Write(edge[i, j] + "\n");
                        SW.Close();
                    }
                }
                else
                {
                    SFD.FileName = filename;

                    SW = new StreamWriter(SFD.FileName);
                    SW.Write("Vertex\n");
                    for (int i = 0; vertex[i, 0] == -1; i++)   //массив вершин
                        for (int j = 0; j < 4; j++)
                            SW.Write(vertex[i, j] + "\n");

                    SW.Write("Edge\n");

                    for (int i = 0; edge[i, 0] == -1; i++)   //массив ребер
                        for (int j = 0; j < 3; j++)
                            SW.Write(edge[i, j] + "\n");

                    SW.Close();
                }
                filename = SFD.FileName;
                figureIsChanged = false;
            }
        }
        #endregion

        #region GUI
        //Помещение в поля для ввода значений из таблиц
        private void vertexGrid_SelectionChanged(object sender, EventArgs e)
        {
            int curRow = 1;
            try
            {
                curRow = vertexGrid.CurrentCell.RowIndex;
                vertexTB_X.Text = Convert.ToString(vertexes_arr[curRow, 1]);
                vertexTB_Y.Text = Convert.ToString(vertexes_arr[curRow, 2]);
                vertexTB_Z.Text = Convert.ToString(vertexes_arr[curRow, 3]);
            }
            catch (NullReferenceException) { curRow = 1; }
        }

        private void edgesGrid_SelectionChanged(object sender, EventArgs e)
        {
            int curRow = 1;
            try
            {
                curRow = edgesGrid.CurrentCell.RowIndex;
                edgeTB_start.Text = Convert.ToString(edges_arr[curRow, 1]);
                edgeTB_end.Text = Convert.ToString(edges_arr[curRow, 2]);
            }
            catch (NullReferenceException) { curRow = 1; }
        }

        //Выделение текста при нажатии на поле либо же при его фокусировке
        private void textBox_selection(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text != null) text.SelectAll();
        }

        //Выход
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Сохранить кнопка
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAS(vertexes_arr, edges_arr);
        }

        //Сохранить как... кнопка
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filename = null;
            saveAS(vertexes_arr, edges_arr);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutWindow = new AboutBox();
            aboutWindow.ShowDialog();
        }


        //ВЫБОР ВКЛАДОК ЧЕРЕЗ КОНТЕКСТНОЕ МЕНЮ
        private void ScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionTabs.SelectTab(ScaleTab);
        }

        private void RotateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionTabs.SelectTab(RotateTab);
        }

        private void ShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionTabs.SelectTab(ShiftTab);
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateGroupBox.Text = "Редактировать";
            ActionTabs.SelectTab(CreateTab);
        }

        //КНОПОЧКИ В ПОВОРОТЕ, МАСШТАБИРОВАНИИ, СДВИГЕ, ПОЯВЛЕНИЕ НУЖНЫХ БЛОКОВ
        private void ShiftRoughRB_CheckedChanged(object sender, EventArgs e)
        {
            ShiftRoughGroupBox.Visible = true;
            ShiftAccuratelyGroupBox.Visible = false;
        }

        private void ShiftAccuratelyRB_CheckedChanged(object sender, EventArgs e)
        {
            ShiftRoughGroupBox.Visible = false;
            ShiftAccuratelyGroupBox.Visible = true;
        }

        private void ScaleRoughRB_CheckedChanged(object sender, EventArgs e)
        {
            ScaleRoughGroupBox.Visible = true;
            ScaleAccuratelyGroupBox.Visible = false;
        }

        private void ScaleAccuratelyRB_CheckedChanged(object sender, EventArgs e)
        {
            ScaleRoughGroupBox.Visible = false;
            ScaleAccuratelyGroupBox.Visible = true;
        }

        private void RotateRoughRB_CheckedChanged(object sender, EventArgs e)
        {
            RotateRoughGroupBox.Visible = true;
            RotateAccuratelyGroupBox.Visible = false;
        }

        private void RotateAccuratelyRB_CheckedChanged(object sender, EventArgs e)
        {
            RotateRoughGroupBox.Visible = false;
            RotateAccuratelyGroupBox.Visible = true;
        }

        //Отрисовка нумерации таблиц
        private void VertexGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gridCounter(vertexGrid, e);
        }

        private void EdgesGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            gridCounter(edgesGrid, e);
        }

        private void VertexGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            gridCounter(vertexGrid, e);
        }

        private void EdgesGrid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            gridCounter(edgesGrid, e);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (figureIsChanged == true)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Сохранить изменения?", "Выход", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveAS(vertexes_arr, edges_arr);
                    e.Cancel = false;
                }
                if (result == DialogResult.No)
                    e.Cancel = false;
            }
        }
        #endregion

        #region Диалоги работы с документом
        //ДИАЛОГ СОЗДАНИЯ НОВОГО ДОКУМЕНТА
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool NF = false;
            if (figureIsChanged == true)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения перед созданием нового файла?", "Новый файл", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveAS(vertexes_arr, edges_arr);
                    NF = true;
                }
                if (result == DialogResult.No)
                    NF = true;
            }

            if (NF == true || figureIsChanged == false)
            {
                Array.Clear(vertexes_arr, 0, 1000);
                Array.Clear(edges_arr, 0, 1000);
                figureIsChanged = false;

                edgesGrid.Rows.Clear();
                vertexGrid.Rows.Clear();

                ActionTabs.SelectTab(CreateTab);
                CreateGroupBox.Text = "Создать";

                //активируем элементы меню
                SaveToolStripMenuItem.Enabled = true;
                SaveAsToolStripMenuItem.Enabled = true;
                EditToolStripMenuItem.Enabled = true;
                ActionToolStripMenuItem.Enabled = true;
                PrintToolStripMenuItem.Enabled = true;

                editTSS(tss_RX, 0);
                editTSS(tss_RY, 0);
                editTSS(tss_RZ, 0);

                editTSS(tss_TX, 0);
                editTSS(tss_TY, 0);
                editTSS(tss_TZ, 0);

                editTSS(tss_SX, 1);
                editTSS(tss_SY, 1);
                editTSS(tss_SZ, 1);
            }
            clearImage(xoyPic); clearImage(xozPic); clearImage(izomPic); clearImage(yozPic);
        }

        //ДИАЛОГ ОТКРЫТИЯ ДОКУМЕНТА
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 1; //коэффициент нормировки
            shiftX = 0; //сдвиг
            shiftY = 0;
            shiftZ = 0;

            bool NF = false;
            if (figureIsChanged == true)
            {
                DialogResult result = MessageBox.Show("Сохранить изменения перед созданием нового файла?", "Новый файл", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    saveAS(vertexes_arr, edges_arr);
                    NF = true;
                }
                if (result == DialogResult.No)
                    NF = true;
            }

            if (NF == true || figureIsChanged == false)
            {
                Array.Clear(vertexes_arr, 0, 1000);
                Array.Clear(edges_arr, 0, 1000);
                figureIsChanged = false;
                openFile(vertexes_arr, edges_arr);
                vertexGrid.Rows.Clear();
                edgesGrid.Rows.Clear();
                int i = 0;
                while (vertexes_arr[i, 0] == -1)
                {
                    vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);
                    i++;
                }
                i = 0;
                while (edges_arr[i, 0] == -1)
                {
                    edgesGrid.Rows.Add(edges_arr[i, 0], edges_arr[i, 1], edges_arr[i, 2]);
                    i++;
                }

                if (vertexes_arr != null)
                {
                    ActionTabs.SelectTab(CreateTab);
                    CreateGroupBox.Text = "Редактировать";

                    //активируем элементы меню
                    SaveToolStripMenuItem.Enabled = true;
                    SaveAsToolStripMenuItem.Enabled = true;
                    EditToolStripMenuItem.Enabled = true;
                    ActionToolStripMenuItem.Enabled = true;
                    PrintToolStripMenuItem.Enabled = true;

                    editTSS(tss_RX, 0);
                    editTSS(tss_RY, 0);
                    editTSS(tss_RZ, 0);

                    editTSS(tss_TX, 0);
                    editTSS(tss_TY, 0);
                    editTSS(tss_TZ, 0);

                    editTSS(tss_SX, 1);
                    editTSS(tss_SY, 1);
                    editTSS(tss_SZ, 1);
                }
            }

            coefficient(vertexes_arr);
            vertexes_norm = normalizationCoordinates(vertexes_arr);
            drawImages(vertexes_norm, edges_arr);
        }
        #endregion

        #region Вершины
        //Добавление вершины
        private void AddVertexButton_Click(object sender, EventArgs e)
        {
            if (vertexTB_X.Text == "" || vertexTB_Y.Text == "" || vertexTB_Z.Text == "")
                MessageBox.Show("Введены не все координаты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (searchDuplicatePoint() == false)
                {
                    vertexGrid.Rows.Add(vertexGrid.NewRowIndex, vertexTB_X.Text, vertexTB_Y.Text, vertexTB_Z.Text);
                    vertexes_arr = gridToArray(vertexGrid);
                    figureIsChanged = true;
                }

                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }

                drawImages(vertexes_norm, edges_arr);
                vertexTB_X.Clear(); vertexTB_Y.Clear(); vertexTB_Z.Clear();
            }
        }

        //Редактирование вершины
        private void EditVertexButton_Click(object sender, EventArgs e)
        {
            if (vertexGrid.CurrentRow != null)
            {
                if (vertexTB_X.Text == "" || vertexTB_Y.Text == "" || vertexTB_Z.Text == "")
                    MessageBox.Show("Введены не все координаты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (searchDuplicatePoint() == false)
                {
                    vertexGrid.CurrentRow.SetValues(-1, vertexTB_X.Text, vertexTB_Y.Text, vertexTB_Z.Text);
                    vertexes_arr = gridToArray(vertexGrid);
                    figureIsChanged = true;
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                    if (normalizationCheck(vertexes_norm) != true)
                    {
                        coefficient(vertexes_arr);
                        vertexes_norm = normalizationCoordinates(vertexes_arr);
                    }
                    drawImages(vertexes_norm, edges_arr);
                    vertexTB_X.Clear(); vertexTB_Y.Clear(); vertexTB_Z.Clear();
                }
            }
            else MessageBox.Show("Не выбрана строка для изменения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Удаление вершины
        private void DeleteVertexButton_Click(object sender, EventArgs e)
        {
            int current = vertexGrid.CurrentRow.Index + 1;

            for (int i = 0; Convert.ToInt32(edges_arr[i, 0]) == -1; i++)
                if ((current == Convert.ToInt32(edges_arr[i, 1])) || (current == Convert.ToInt32(edges_arr[i, 2])))
                {
                    edgesGrid.Rows.Remove(edgesGrid.Rows[i]);
                    Array.Clear(edges_arr, 0, 1000);
                    edges_arr = gridToArray(edgesGrid);
                    edgesGrid.Rows.Clear();

                    int n = 0;
                    while (edges_arr[n, 0] == -1)
                    {
                        edgesGrid.Rows.Add(edges_arr[n, 0], edges_arr[n, 1], edges_arr[n, 2]);
                        n++;
                    }
                    i = -1;

                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                    if (normalizationCheck(vertexes_norm) != true)
                    {
                        coefficient(vertexes_arr);
                        vertexes_norm = normalizationCoordinates(vertexes_arr);
                    }
                    drawImages(vertexes_norm, edges_arr);
                }

            vertexGrid.Rows.Remove(vertexGrid.CurrentRow);
            vertexes_arr = gridToArray(vertexGrid);

            for (int i = 0; Convert.ToInt32(edges_arr[i, 0]) == -1; i++) //сдвигаем точки ребер
            {
                if (edges_arr[i, 2] > current) edges_arr[i, 2] = edges_arr[i, 2] - 1;
                if (edges_arr[i, 1] > current) edges_arr[i, 1] = edges_arr[i, 1] - 1;
            }
            edgesGrid.Rows.Clear();
            for (int n = 0; edges_arr[n, 0] == -1; n++)
                edgesGrid.Rows.Add(edges_arr[n, 0], edges_arr[n, 1], edges_arr[n, 2]);

            figureIsChanged = true;
        }
        #endregion

        #region Рёбра
        //Добавление ребра
        private void AddEdgeButton_Click(object sender, EventArgs e)
        {
            bool norm = true;

            if (edgeTB_start.Text == "" || edgeTB_end.Text == "")
            {
                MessageBox.Show("Вы не ввели индексы вершин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                norm = false;
            }
            else
                if (Convert.ToInt32(edgeTB_start.Text) < 1 || Convert.ToInt32(edgeTB_start.Text) > vertexGrid.Rows.Count || Convert.ToInt32(edgeTB_end.Text) < 1 || Convert.ToInt32(edgeTB_end.Text) > vertexGrid.Rows.Count)
                {
                    MessageBox.Show("Таких вершин не существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    norm = false;
                }

            if (edgeTB_start.Text == edgeTB_end.Text)
            {
                MessageBox.Show("Начало и конец отрезка не могут быть равны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                norm = false;
            }

            if (norm == true && searchDuplicateEdge() == false)
            {
                edgesGrid.Rows.Add(edgesGrid.NewRowIndex, edgeTB_start.Text, edgeTB_end.Text);
                edges_arr = gridToArray(edgesGrid);
                figureIsChanged = true;

                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }
                drawImages(vertexes_norm, edges_arr);
                edgeTB_start.Clear(); edgeTB_end.Clear();
            }
        }

        //редактирование ребра
        private void EditEdgeButton_Click(object sender, EventArgs e)
        {
            bool norm = true;

            if (edgeTB_start.Text == "" || edgeTB_end.Text == "")
            {
                MessageBox.Show("Вы не ввели индексы вершин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                norm = false;
            }
            else
                if (Convert.ToInt32(edgeTB_start.Text) < 1 || Convert.ToInt32(edgeTB_start.Text) > vertexGrid.Rows.Count || Convert.ToInt32(edgeTB_end.Text) < 1 || Convert.ToInt32(edgeTB_end.Text) > vertexGrid.Rows.Count)
                {
                    MessageBox.Show("Таких вершин не существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    norm = false;
                }

            if (edgeTB_start.Text == edgeTB_end.Text)
            {
                MessageBox.Show("Начало и конец отрезка не могут быть равны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                norm = false;
            }

            if (norm == true && searchDuplicateEdge() == false)
            {
                edgesGrid.CurrentRow.SetValues(edgesGrid.NewRowIndex, edgeTB_start.Text, edgeTB_end.Text);
                edges_arr = gridToArray(edgesGrid);
                figureIsChanged = true;
                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }
                drawImages(vertexes_norm, edges_arr);
            }
        }

        //Удаление ребра
        private void DeleteEdgeButton_Click(object sender, EventArgs e)
        {
            if (edgesGrid.CurrentRow != null)
            {
                edgesGrid.Rows.Remove(edgesGrid.CurrentRow);
                edges_arr = gridToArray(edgesGrid);
                figureIsChanged = true;

                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }
                drawImages(vertexes_norm, edges_arr);
            }
        }
        #endregion

        #region Сдвиг
        //грубый сдвиг влево
        private void ShiftRoughLeftButton_Click(object sender, EventArgs e)
        {
            if (ShiftRoughcheckedListBox.CheckedItems.Count == 0)
                MessageBox.Show("Не выбрана ни одна ось!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                double Dx = 0;
                double Dy = 0;
                double Dz = 0;

                if (ShiftRoughcheckedListBox.GetItemCheckState(0) == CheckState.Checked) Dx = -Convert.ToDouble(ShiftRoughTextBox.Text);
                if (ShiftRoughcheckedListBox.GetItemCheckState(1) == CheckState.Checked) Dy = -Convert.ToDouble(ShiftRoughTextBox.Text);
                if (ShiftRoughcheckedListBox.GetItemCheckState(2) == CheckState.Checked) Dz = -Convert.ToDouble(ShiftRoughTextBox.Text);

                //матрица сдвига
                double[,] shift = new double[4, 4] { 
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { Dx, Dy, Dz, 1 }
                };
                double[,] сoord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл свдига
                {
                    сoord[0, 0] = vertexes_arr[i, 1];
                    сoord[0, 1] = vertexes_arr[i, 2];
                    сoord[0, 2] = vertexes_arr[i, 3];
                    сoord[0, 3] = 1;
                    сoord = matrixMultiply(сoord, shift);
                    vertexes_arr[i, 1] = сoord[0, 0];
                    vertexes_arr[i, 2] = сoord[0, 1];
                    vertexes_arr[i, 3] = сoord[0, 2];
                }
                vertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                editTSS(tss_TX, readTSS(tss_TX) + Dx);
                editTSS(tss_TY, readTSS(tss_TY) + Dy);
                editTSS(tss_TZ, readTSS(tss_TZ) + Dz);
            }
            vertexes_norm = normalizationCoordinates(vertexes_arr);
            if (normalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = normalizationCoordinates(vertexes_arr);
            }
            drawImages(vertexes_norm, edges_arr);
            figureIsChanged = true;
        }

        //Грубый сдвиг вправо
        private void ShiftRoughRightButton_Click(object sender, EventArgs e)
        {
            if (ShiftRoughcheckedListBox.CheckedItems.Count == 0)
                MessageBox.Show("Не выбрана ни одна ось!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                double Dx = 0;
                double Dy = 0;
                double Dz = 0;

                if (ShiftRoughcheckedListBox.GetItemCheckState(0) == CheckState.Checked) Dx = Convert.ToDouble(ShiftRoughTextBox.Text);
                if (ShiftRoughcheckedListBox.GetItemCheckState(1) == CheckState.Checked) Dy = Convert.ToDouble(ShiftRoughTextBox.Text);
                if (ShiftRoughcheckedListBox.GetItemCheckState(2) == CheckState.Checked) Dz = Convert.ToDouble(ShiftRoughTextBox.Text);

                //матрица сдвига
                double[,] shift = new double[4, 4] { 
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 }, 
                    { 0, 0, 1, 0 }, 
                    { Dx, Dy, Dz, 1 }
                };
                double[,] coord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл свдига
                {
                    coord[0, 0] = vertexes_arr[i, 1];
                    coord[0, 1] = vertexes_arr[i, 2];
                    coord[0, 2] = vertexes_arr[i, 3];
                    coord[0, 3] = 1;
                    coord = matrixMultiply(coord, shift);
                    vertexes_arr[i, 1] = coord[0, 0];
                    vertexes_arr[i, 2] = coord[0, 1];
                    vertexes_arr[i, 3] = coord[0, 2];
                }

                vertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                editTSS(tss_TX, readTSS(tss_TX) + Dx);
                editTSS(tss_TY, readTSS(tss_TY) + Dy);
                editTSS(tss_TZ, readTSS(tss_TZ) + Dz);
            }

            vertexes_norm = normalizationCoordinates(vertexes_arr);
            if (normalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = normalizationCoordinates(vertexes_arr);
            }

            drawImages(vertexes_norm, edges_arr);
            figureIsChanged = true;
        }

        //Точный сдвиг
        private void ShiftAccuratelyButton_Click(object sender, EventArgs e)
        {
            //матрица сдвига
            double[,] shift = new double[4, 4] { 
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 }, 
                { Convert.ToDouble(ShiftAccuratelyOXBox.Text), Convert.ToDouble(ShiftAccuratelyOYBox.Text), Convert.ToDouble(ShiftAccuratelyOZBox.Text), 1 }
            };
            double[,] сoord = new double[1, 4]; //координаты точки

            for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл свдига
            {
                сoord[0, 0] = vertexes_arr[i, 1];
                сoord[0, 1] = vertexes_arr[i, 2];
                сoord[0, 2] = vertexes_arr[i, 3];
                сoord[0, 3] = 1;
                сoord = matrixMultiply(сoord, shift);
                vertexes_arr[i, 1] = сoord[0, 0];
                vertexes_arr[i, 2] = сoord[0, 1];
                vertexes_arr[i, 3] = сoord[0, 2];
            }
            vertexGrid.Rows.Clear();

            for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

            vertexes_norm = normalizationCoordinates(vertexes_arr);
            if (normalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = normalizationCoordinates(vertexes_arr);
            }
            drawImages(vertexes_norm, edges_arr);
            figureIsChanged = true;

            editTSS(tss_TX, readTSS(tss_TX) + Convert.ToDouble(ShiftAccuratelyOXBox.Text));
            editTSS(tss_TY, readTSS(tss_TY) + Convert.ToDouble(ShiftAccuratelyOYBox.Text));
            editTSS(tss_TZ, readTSS(tss_TZ) + Convert.ToDouble(ShiftAccuratelyOZBox.Text));
        }
        #endregion

        #region Поворот
        //Грубый поворот влево
        private void RotateRoughLeftButton_Click(object sender, EventArgs e)
        {
            if (RotateRoughcheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не выбрана ни одна ось!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double a = 0;
                double b = 0;
                double g = 0;

                if (RotateRoughcheckedListBox.GetItemCheckState(2) == CheckState.Checked) a = -Convert.ToDouble(RotateRoughTextBox.Text) * Math.PI / 180; //oz
                if (RotateRoughcheckedListBox.GetItemCheckState(0) == CheckState.Checked) b = -Convert.ToDouble(RotateRoughTextBox.Text) * Math.PI / 180; //ox
                if (RotateRoughcheckedListBox.GetItemCheckState(1) == CheckState.Checked) g = -Convert.ToDouble(RotateRoughTextBox.Text) * Math.PI / 180; //oy

                //матрицы поворота
                double[,] Rz = new double[4, 4] { 
                    { Math.Cos(a), Math.Sin(a), 0, 0 },
                    { -Math.Sin(a), Math.Cos(a), 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
                double[,] Rx = new double[4, 4] { 
                    { 1, 0, 0, 0 },
                    { 0, Math.Cos(b), Math.Sin(b), 0 },
                    { 0, -Math.Sin(b), Math.Cos(b), 0 },
                    { 0, 0, 0, 1 }
                };
                double[,] Ry = new double[4, 4] {
                    { Math.Cos(g), 0, Math.Sin(g), 0 },
                    { 0, 1, 0, 0 },
                    { -Math.Sin(g), 0, Math.Cos(g), 0 },
                    { 0, 0, 0, 1 }
                };

                double[,] сoord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл поворота
                {
                    сoord[0, 0] = vertexes_arr[i, 1];
                    сoord[0, 1] = vertexes_arr[i, 2];
                    сoord[0, 2] = vertexes_arr[i, 3];
                    сoord[0, 3] = 1;
                    сoord = matrixMultiply(сoord, Rz);
                    сoord = matrixMultiply(сoord, Rx);
                    сoord = matrixMultiply(сoord, Ry);
                    vertexes_arr[i, 1] = сoord[0, 0];
                    vertexes_arr[i, 2] = сoord[0, 1];
                    vertexes_arr[i, 3] = сoord[0, 2];
                }
                vertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }
                drawImages(vertexes_norm, edges_arr);
                figureIsChanged = true;

                editTSS(tss_RX, readTSS(tss_RX) + b);
                editTSS(tss_RY, readTSS(tss_RY) + g);
                editTSS(tss_RZ, readTSS(tss_RZ) + a);
            }
        }


        //Грубый поворот вправо
        private void RotateRoughRightButton_Click(object sender, EventArgs e)
        {
            if (RotateRoughcheckedListBox.CheckedItems.Count == 0)
                MessageBox.Show("Не выбрана ни одна ось!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {
                double a = 0;
                double b = 0;
                double g = 0;

                if (RotateRoughcheckedListBox.GetItemCheckState(2) == CheckState.Checked) a = Convert.ToDouble(RotateRoughTextBox.Text) * Math.PI / 180; //oz
                if (RotateRoughcheckedListBox.GetItemCheckState(0) == CheckState.Checked) b = Convert.ToDouble(RotateRoughTextBox.Text) * Math.PI / 180; //ox
                if (RotateRoughcheckedListBox.GetItemCheckState(1) == CheckState.Checked) g = Convert.ToDouble(RotateRoughTextBox.Text) * Math.PI / 180; //oy

                //матрицы поворота
                double[,] Rz = new double[4, 4] { 
                    { Math.Cos(a), Math.Sin(a), 0, 0 },
                    { -Math.Sin(a), Math.Cos(a), 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                };
                double[,] Rx = new double[4, 4] { 
                    { 1, 0, 0, 0 }, 
                    { 0, Math.Cos(b), Math.Sin(b), 0 },
                    { 0, -Math.Sin(b), Math.Cos(b), 0 },
                    { 0, 0, 0, 1 }
                };
                double[,] Ry = new double[4, 4] { 
                    { Math.Cos(g), 0, Math.Sin(g), 0 },
                    { 0, 1, 0, 0 },
                    { -Math.Sin(g), 0, Math.Cos(g), 0 },
                    { 0, 0, 0, 1 }
                };

                double[,] сoord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл поворота
                {
                    сoord[0, 0] = vertexes_arr[i, 1];
                    сoord[0, 1] = vertexes_arr[i, 2];
                    сoord[0, 2] = vertexes_arr[i, 3];
                    сoord[0, 3] = 1;
                    сoord = matrixMultiply(сoord, Rz);
                    сoord = matrixMultiply(сoord, Rx);
                    сoord = matrixMultiply(сoord, Ry);
                    vertexes_arr[i, 1] = сoord[0, 0];
                    vertexes_arr[i, 2] = сoord[0, 1];
                    vertexes_arr[i, 3] = сoord[0, 2];
                }
                vertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }
                drawImages(vertexes_norm, edges_arr);
                figureIsChanged = true;

                editTSS(tss_RX, readTSS(tss_RX) + b);
                editTSS(tss_RY, readTSS(tss_RY) + g);
                editTSS(tss_RZ, readTSS(tss_RZ) + a);
            }
        }

        //Точный поворот
        private void RotateAccuratelyButton_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(RotateAccuratelyOZBox.Text);
            double b = Convert.ToDouble(RotateAccuratelyOXBox.Text);
            double g = Convert.ToDouble(RotateAccuratelyOYBox.Text);

            //матрицы поворота
            double[,] Rz = new double[4, 4] { 
                { Math.Cos(a), Math.Sin(a), 0, 0 },
                { -Math.Sin(a), Math.Cos(a), 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            double[,] Rx = new double[4, 4] { 
                { 1, 0, 0, 0 },
                { 0, Math.Cos(b), Math.Sin(b), 0 },
                { 0, -Math.Sin(b), Math.Cos(b), 0 },
                { 0, 0, 0, 1 }
            };
            double[,] Ry = new double[4, 4] { 
                { Math.Cos(g), 0, Math.Sin(g), 0 },
                { 0, 1, 0, 0 },
                { -Math.Sin(g), 0, Math.Cos(g), 0 },
                { 0, 0, 0, 1 }
            };

            double[,] сoord = new double[1, 4]; //координаты точки

            for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл поворота
            {
                сoord[0, 0] = vertexes_arr[i, 1];
                сoord[0, 1] = vertexes_arr[i, 2];
                сoord[0, 2] = vertexes_arr[i, 3];
                сoord[0, 3] = 1;
                сoord = matrixMultiply(сoord, Rz);
                сoord = matrixMultiply(сoord, Rx);
                сoord = matrixMultiply(сoord, Ry);
                vertexes_arr[i, 1] = сoord[0, 0];
                vertexes_arr[i, 2] = сoord[0, 1];
                vertexes_arr[i, 3] = сoord[0, 2];
            }
            vertexGrid.Rows.Clear();

            for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

            vertexes_norm = normalizationCoordinates(vertexes_arr);
            if (normalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = normalizationCoordinates(vertexes_arr);
            }
            drawImages(vertexes_norm, edges_arr);
            figureIsChanged = true;

            editTSS(tss_RX, readTSS(tss_RX) + b);
            editTSS(tss_RY, readTSS(tss_RY) + g);
            editTSS(tss_RZ, readTSS(tss_RZ) + a);
        }
        #endregion

        #region Масштаб
        //ГРУБЫЙ МАСШТАБ
        private void ScaleButton_Click(object sender, EventArgs e)
        {
            try
            {

                if (ScaleRoughcheckedListBox.CheckedItems.Count == 0)
                    MessageBox.Show("Не выбрана ни одна ось", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (Convert.ToDouble(ScaleRoughTextBox.Text) == 0)
                        MessageBox.Show("Коэффициент масштабирования не может быть равен нулю", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (Convert.ToDouble(ScaleRoughTextBox.Text) < 1) k = 1;

                        double Sx = 1;
                        double Sy = 1;
                        double Sz = 1;

                        if (ScaleRoughcheckedListBox.GetItemCheckState(0) == CheckState.Checked) Sx = Convert.ToDouble(ScaleRoughTextBox.Text);
                        if (ScaleRoughcheckedListBox.GetItemCheckState(1) == CheckState.Checked) Sy = Convert.ToDouble(ScaleRoughTextBox.Text);
                        if (ScaleRoughcheckedListBox.GetItemCheckState(2) == CheckState.Checked) Sz = Convert.ToDouble(ScaleRoughTextBox.Text);

                        //матрица масштабирования
                        double[,] scale = new double[4, 4] { 
                            { Sx, 0, 0, 0 },
                            { 0, Sy, 0, 0 }, 
                            { 0, 0, Sz, 0 },
                            { 0, 0, 0, 1 }
                        };
                        double[,] сoord = new double[1, 4]; //координаты точки

                        for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
                        {
                            сoord[0, 0] = vertexes_arr[i, 1];
                            сoord[0, 1] = vertexes_arr[i, 2];
                            сoord[0, 2] = vertexes_arr[i, 3];
                            сoord[0, 3] = 1;
                            сoord = matrixMultiply(сoord, scale);
                            vertexes_arr[i, 1] = сoord[0, 0];
                            vertexes_arr[i, 2] = сoord[0, 1];
                            vertexes_arr[i, 3] = сoord[0, 2];
                        }
                        vertexGrid.Rows.Clear();

                        for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                            vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                        editTSS(tss_SX, readTSS(tss_SX) * Sx);
                        editTSS(tss_SY, readTSS(tss_SY) * Sy);
                        editTSS(tss_SZ, readTSS(tss_SZ) * Sz);
                    }

                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                    if (normalizationCheck(vertexes_norm) != true)
                    {
                        coefficient(vertexes_arr);
                        vertexes_norm = normalizationCoordinates(vertexes_arr);
                    }
                    drawImages(vertexes_norm, edges_arr);
                    figureIsChanged = true;
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Пустое окно", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        //ТОЧНЫЙ МАСШТАБ
        private void ScaleAccuratelyButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(ScaleAccuratelyOXBox.Text) == 0 || Convert.ToDouble(ScaleAccuratelyOYBox.Text) == 0 || Convert.ToDouble(ScaleAccuratelyOZBox.Text) == 0)
                MessageBox.Show("Коэффициент масштабирования не может быть равен нулю", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (Convert.ToDouble(ScaleAccuratelyOXBox.Text) < 1 || Convert.ToDouble(ScaleAccuratelyOYBox.Text) < 1 || Convert.ToDouble(ScaleAccuratelyOZBox.Text) < 1) k = 1;

                double Sx = Convert.ToDouble(ScaleAccuratelyOXBox.Text);
                double Sy = Convert.ToDouble(ScaleAccuratelyOYBox.Text);
                double Sz = Convert.ToDouble(ScaleAccuratelyOZBox.Text);

                //матрица масштабирования
                double[,] scale = new double[4, 4] { 
                    { Sx, 0, 0, 0 },
                    { 0, Sy, 0, 0 }, 
                    { 0, 0, Sz, 0 },
                    { 0, 0, 0, 1 }
                };
                double[,] сoord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
                {
                    сoord[0, 0] = vertexes_arr[i, 1];
                    сoord[0, 1] = vertexes_arr[i, 2];
                    сoord[0, 2] = vertexes_arr[i, 3];
                    сoord[0, 3] = 1;
                    сoord = matrixMultiply(сoord, scale);
                    vertexes_arr[i, 1] = сoord[0, 0];
                    vertexes_arr[i, 2] = сoord[0, 1];
                    vertexes_arr[i, 3] = сoord[0, 2];
                }
                vertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    vertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                vertexes_norm = normalizationCoordinates(vertexes_arr);
                if (normalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = normalizationCoordinates(vertexes_arr);
                }
                drawImages(vertexes_norm, edges_arr);
                figureIsChanged = true;

                editTSS(tss_SX, readTSS(tss_SX) * Sx);
                editTSS(tss_SY, readTSS(tss_SY) * Sy);
                editTSS(tss_SZ, readTSS(tss_SZ) * Sz);
            }
        }
        #endregion

        #region Печать
        //ПЕЧАТЬ
        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect;
            int pbWidth = e.MarginBounds.Width;
            int pbHeight = e.MarginBounds.Height;
            int ImageWidth = izomPic.Image.Width; int ImageHeight = izomPic.Height;

            SizeF sizef = new SizeF(ImageWidth / izomPic.Image.HorizontalResolution, ImageHeight / izomPic.Image.VerticalResolution);
            float fSeale = Math.Min(pbWidth / sizef.Width, pbHeight / sizef.Height);
            sizef.Width *= fSeale;
            sizef.Height *= fSeale;
            Size size = Size.Ceiling(sizef);
            rect = new Rectangle(e.MarginBounds.Location.X, e.MarginBounds.Location.Y, size.Width, size.Height);
            g.DrawImage(izomPic.Image, rect);
        }
        #endregion
    }
}