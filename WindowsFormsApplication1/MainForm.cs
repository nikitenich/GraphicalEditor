﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace GraphicalEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            b = new Bitmap(izomPNL.ClientRectangle.Width, izomPNL.ClientRectangle.Height);
            ActionTabs.SelectTab(StartTab); //открытие специальной пустой вкладки при запуске программы
            /*StartTab.BackColor = groupBox1.BackColor = groupBox2.BackColor = groupBox3.BackColor = CreateGroupBox.BackColor = splitContainer.Panel2.BackColor = splitContainer.Panel1.BackColor =
                RotateTab.BackColor = ScaleTab.BackColor = menuStrip.BackColor = statusStrip.BackColor = backColor; //задаём цвет фона вкладок и так далее
            yozPNL.BackColor = xoyPNL.BackColor = xozPNL.BackColor = izomPNL.BackColor = panelsBackColor; //цвет фона панелей*/
        }


        public double[,] vertexes_arr = new double[1000, 4]; //список вершин //vershin
        public bool izm = false;   // были ли изменения после сохранения?
        public double[,] vertexes_norm = new double[1000, 4]; //нормированные координаты //vertexes_norm
        public double[,] edges_arr = new double[1000, 3]; //список ребер
        public string filename = ""; //название файла
        public double k = 1; //коэффициент нормировки
        double shiftX = 0; //сдвиг
        double shiftY = 0;
        double shiftZ = 0;
        Bitmap b;
        //Color backColor = System.Drawing.ColorTranslator.FromHtml("#bfcfd9");
        Color panelsBackColor = System.Drawing.ColorTranslator.FromHtml("#e2eef6");
        

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

        /// <summary>
        /// Возвращает булеву переменную. Если true - в массиве вершин уже есть такая точка.
        /// </summary>
        /// <returns></returns>
        private bool SearchDuplicatePoint()
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
        private bool SearchDuplicateEdge()
        {
            bool err = false;
            if (edges_arr != null)
                for (int i = 0; edges_arr[i, 0] == -1; i++)
                    if ((edges_arr[i, 1] == Convert.ToDouble(edgeTB_start.Text) && edges_arr[i, 2] == Convert.ToDouble(edgeTB_end.Text)) || (edges_arr[i, 2] == Convert.ToDouble(edgeTB_start.Text) && edges_arr[i, 1] == Convert.ToDouble(edgeTB_end.Text)))
                    {
                        MessageBox.Show("Такое ребро уже есть!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        err = true;
                    }
            return (err);
        }

        /// <summary>
        /// Нормирует координаты по заранее найденным коэффициентам.
        /// </summary>
        /// <param name="vertex">массив вершин</param>
        /// <returns></returns>
        private double[,] NormalizationCoordinates(double[,] vertexes)
        {
            vertexes = (double[,])vertexes.Clone();

            vertexes = ShiftOrigin(vertexes);

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
        /// <param name="verh">массив координат вершин</param>
        /// <returns></returns>
        private bool NormalizationCheck(double[,] vertexes)
        { //bool norma = true;
            for (int i = 0; vertexes[i, 0] == -1; i++)
            {
                if (vertexes[i, 1] > 1 || vertexes[i, 1] < 0) return false;//norma = false;
                if (vertexes[i, 2] > 1 || vertexes[i, 2] < 0) return false;//norma = false;
                if (vertexes[i, 3] > 1 || vertexes[i, 3] < 0) return false;//norma = false;
            }
            return true;
        }

        /// <summary>
        /// Выполняет сдвиг в начало координат
        /// </summary>
        /// <param name="vertexes">Матрица вершин double[,]</param>
        /// <returns></returns> 
        private double[,] ShiftOrigin(double[,] vertexes)
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
        private double[,] GridToArray(DataGridView DG)
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
            dv = ShiftOrigin(dv);
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

        private double[,] MatrixMultiply(double[,] A, double[,] B)
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
        private void picture(double[,] vertexes, double[,] edges)
        {
            double[,] risovat;
            risovat = vertexes;
            Color lineColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            //ось YOZ
            Graphics yoz = Graphics.FromHwnd(yozPNL.Handle);
            yoz.Clear(panelsBackColor);
            yoz.TranslateTransform(1, 249);

            yoz.Clear(panelsBackColor);
            yoz.Clear(panelsBackColor);
                for (int i = 0; edges[i, 0] == -1; i++)
                {
                    yoz.DrawLine(new Pen(lineColor, 1), new Point(Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 1]) - 1, 2] * 248),
                        -Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 1]) - 1, 3] * 248)),
                        new Point(Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 2]) - 1, 2] * 248),
                        -Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 2]) - 1, 3] * 248)));
                }
            //ось XOZ
            Graphics xoz = Graphics.FromHwnd(xozPNL.Handle);
            xoz.Clear(panelsBackColor);
            xoz.TranslateTransform(1, 249);
                for (int i = 0; edges[i, 0] == -1; i++)
                {
                    xoz.DrawLine(new Pen(lineColor, 1), new Point(Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 1]) - 1, 1] * 248),
                        -Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 1]) - 1, 3] * 248)),
                        new Point(Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 2]) - 1, 1] * 248),
                        -Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 2]) - 1, 3] * 248)));
                }

            //ось XOY
            Graphics xoy = Graphics.FromHwnd(xoyPNL.Handle);
            xoy.Clear(panelsBackColor);
            //xoy.TranslateTransform(1, 249);
                for (int i = 0; edges[i, 0] == -1; i++)
                {
                    xoy.DrawLine(new Pen(lineColor, 1), new Point(Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 1]) - 1, 2] * 248),
                        Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 1]) - 1, 1] * 248)),
                        new Point(Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 2]) - 1, 2] * 248),
                        Convert.ToInt32(risovat[Convert.ToInt32(edges[i, 2]) - 1, 1] * 248)));
                }

            // теперь будем строить изометрическую проекцию

            //матрица для получения координат
            double teta = 0.61547973114;
            double fi = -Math.PI / 4;

            double[,] sdvig = new double[4, 4] { { Math.Cos(fi), Math.Sin(fi) * Math.Sin(teta), 0, 0 }, { 0, Math.Cos(fi), 0, 0 }, { Math.Sin(fi), -Math.Cos(fi) * Math.Sin(teta), 0, 0 }, { 0, 0, 0, 1 } };
            double[,] koord = new double[1, 4];//координаты точки
            double[,] izometr = (double[,])vertexes.Clone();

            //будем вращать

            double a = Math.PI / 4;
            double b = 0;
            double g = Math.PI / 4;

            double[,] Rz = new double[4, 4] { { Math.Cos(a), Math.Sin(a), 0, 0 }, { -Math.Sin(a), Math.Cos(a), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            double[,] Rx = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(b), Math.Sin(b), 0 }, { 0, -Math.Sin(b), Math.Cos(b), 0 }, { 0, 0, 0, 1 } };
            double[,] Ry = new double[4, 4] { { Math.Cos(g), 0, Math.Sin(g), 0 }, { 0, 1, 0, 0 }, { -Math.Sin(g), 0, Math.Cos(g), 0 }, { 0, 0, 0, 1 } };

            double[,] kord = new double[1, 4]; //координаты точки

            for (int i = 0; izometr[i, 0] == -1; i++) //цикл поворота
            {
                kord[0, 0] = izometr[i, 1];
                kord[0, 1] = izometr[i, 2];
                kord[0, 2] = izometr[i, 3];
                kord[0, 3] = 1;
                kord = MatrixMultiply(kord, Rz);
                kord = MatrixMultiply(kord, Rx);
                kord = MatrixMultiply(kord, Ry);

                izometr[i, 1] = kord[0, 0];
                izometr[i, 2] = kord[0, 1];
                izometr[i, 3] = kord[0, 2];
            }

            for (int i = 0; izometr[i, 0] == -1; i++) //цикл преобразования
            {
                koord[0, 0] = izometr[i, 1];
                koord[0, 1] = izometr[i, 2];
                koord[0, 2] = izometr[i, 3];
                koord[0, 3] = 1;
                koord = MatrixMultiply(koord, sdvig);
                izometr[i, 1] = koord[0, 0] * 10000;
                izometr[i, 2] = koord[0, 1] * 10000;
                izometr[i, 3] = koord[0, 2] * 10000;
            }


            //придется нестандартно двигать и нормировать

            double X = izometr[0, 1];
            double Y = izometr[0, 2];
            double Z = izometr[0, 3];

            for (int i = 0; izometr[i, 0] == -1; i++)
            {
                if (izometr[i, 1] < X) X = izometr[i, 1];
                if (izometr[i, 2] < Y) Y = izometr[i, 2];
                if (izometr[i, 3] < Z) Z = izometr[i, 3];
            }

            //придется немного подвигать
            for (int i = 0; izometr[i, 0] == -1; i++)  //двигаем каждую координату
            {
                izometr[i, 1] = izometr[i, 1] - X;
                izometr[i, 2] = izometr[i, 2] - Y;
                izometr[i, 3] = izometr[i, 3] - Z;
            }
            //подвигали

            double kn = 0;
            for (int i = 0; izometr[i, 0] == -1; i++)
            {
                if (izometr[i, 1] > kn) kn = izometr[i, 1];
                if (izometr[i, 2] > kn) kn = izometr[i, 2];
                if (izometr[i, 3] > kn) kn = izometr[i, 3];
            }
            //нашли кэф нормировки

            //немножко понормируем
            for (int i = 0; risovat[i, 0] == -1; i++)
            {
                izometr[i, 1] = izometr[i, 1] / kn;
                izometr[i, 2] = izometr[i, 2] / kn;
                izometr[i, 3] = izometr[i, 3] / kn;
            }
            //понормировали

            Graphics izom = Graphics.FromHwnd(izomPNL.Handle);
            izom.Clear(panelsBackColor);
            izom.TranslateTransform(1, 1);
                for (int i = 0; edges[i, 0] == -1; i++)
                {
                    izom.DrawLine(new Pen(lineColor, 1), new Point(Convert.ToInt32(izometr[Convert.ToInt32(edges[i, 1]) - 1, 2] * 248),
                        Convert.ToInt32(izometr[Convert.ToInt32(edges[i, 1]) - 1, 1] * 248)),
                        new Point(Convert.ToInt32(izometr[Convert.ToInt32(edges[i, 2]) - 1, 2] * 248),
                        Convert.ToInt32(izometr[Convert.ToInt32(edges[i, 2]) - 1, 1] * 248)));
                }
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
            {
                {
                    try
                    {
                        Array.Clear(vertex, 4, 1000);
                        Array.Clear(edge, 3, 1000);
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
                }
            }
            filename = OFD.FileName;
            izm = false;
        }

        /// <summary>
        /// Диалог "Сохранить как...".
        /// </summary>
        /// <param name="vertex">Двумерный массив. Список вершин</param>
        /// <param name="edge">Двумерный массив. Список ребер</param>

        private void saveAS(double[,] vertex, double[,] edge)
        {
            if (izm == true)
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
                izm = false;
            }
        }

        //=======================================================================================//

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

        //ДИАЛОГ СОЗДАНИЯ НОВОГО ДОКУМЕНТА
        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool NF = false;
            if (izm == true)
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

            if (NF == true || izm == false)
            {
                Array.Clear(vertexes_arr, 4, 1000);
                Array.Clear(edges_arr, 3, 1000);
                izm = false;

                EdgesGrid.Rows.Clear();
                VertexGrid.Rows.Clear();

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
            Graphics xoz = Graphics.FromHwnd(xozPNL.Handle); xoz.Clear(panelsBackColor);
            Graphics yoz = Graphics.FromHwnd(yozPNL.Handle); yoz.Clear(panelsBackColor);
            Graphics xoy = Graphics.FromHwnd(xoyPNL.Handle); xoy.Clear(panelsBackColor);
            Graphics izom = Graphics.FromHwnd(izomPNL.Handle); izom.Clear(panelsBackColor);
        }

        //ДИАЛОГ ОТКРЫТИЯ ДОКУМЕНТА
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k = 1; //коэффициент нормировки
            shiftX = 0; //сдвиг
            shiftY = 0;
            shiftZ = 0;

            bool NF = false;
            if (izm == true)
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

            if (NF == true || izm == false)
            {
                Array.Clear(vertexes_arr, 4, 1000);
                Array.Clear(edges_arr, 3, 1000);
                izm = false;
                openFile(vertexes_arr, edges_arr);
                VertexGrid.Rows.Clear();
                EdgesGrid.Rows.Clear();
                int i = 0;
                while (vertexes_arr[i, 0] == -1)
                {
                    VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);
                    i++;
                }
                i = 0;
                while (edges_arr[i, 0] == -1)
                {
                    EdgesGrid.Rows.Add(edges_arr[i, 0], edges_arr[i, 1], edges_arr[i, 2]);
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
            vertexes_norm = NormalizationCoordinates(vertexes_arr);
            picture(vertexes_norm, edges_arr);
        }

        //---------------------------------------//


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
        //---------------------------------------//


        // ПРОВЕРКА ВВОДА В ТЕКСТОВЫЕ ПОЛЯ
        private void ScaleRoughTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ScaleRoughTextBox, false, e);
            
        }

        private void ScaleAccuratelyOXBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ScaleAccuratelyOXBox, false, e);
        }

        private void ScaleAccuratelyOYBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ScaleAccuratelyOYBox, false, e);
        }

        private void ScaleAccuratelyOZBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ScaleAccuratelyOZBox, false, e);
        }

        private void ShiftRoughTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ShiftRoughTextBox, false, e);
        }

        private void ShiftAccuratelyOXBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ShiftAccuratelyOXBox, true, e);
        }

        private void ShiftAccuratelyOYBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ShiftAccuratelyOYBox, true, e);
        }

        private void ShiftAccuratelyOZBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(ShiftAccuratelyOZBox, true, e);
        }

        private void RotateRoughTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(RotateRoughTextBox, false, e);
        }

        private void RotateAccuratelyOXBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(RotateAccuratelyOXBox, true, e);
        }

        private void RotateAccuratelyOYBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(RotateAccuratelyOZBox, true, e);
        }

        private void RotateAccuratelyOZBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(RotateAccuratelyOZBox, true, e);
        }

        private void vertexTB_X_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(vertexTB_X, true, e);
        }

        private void vertexTB_Y_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(vertexTB_Y, true, e);
        }

        private void vertexTB_Z_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressKey(vertexTB_Z, true, e);
        }

        private void edgeTB_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void edgeTB_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
                e.Handled = true;
        }
        //=====================================================================//


        //Добавление вершины
        private void AddVertexButton_Click(object sender, EventArgs e)
        {
            if (vertexTB_X.Text == "" || vertexTB_Y.Text == "" || vertexTB_Z.Text == "")
                MessageBox.Show("Введены не все координаты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (SearchDuplicatePoint() == false)
                {
                    VertexGrid.Rows.Add(VertexGrid.NewRowIndex, vertexTB_X.Text, vertexTB_Y.Text, vertexTB_Z.Text);
                    vertexes_arr = GridToArray(VertexGrid);
                    izm = true;
                }

                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }

                //picture(vertexes_norm, edges_arr);
                vertexTB_X.Clear(); vertexTB_Y.Clear(); vertexTB_Z.Clear();
            }
        }

        //Редактирование вершины
        private void EditVertexButton_Click(object sender, EventArgs e)
        {
            if (VertexGrid.CurrentRow != null)
            {
                if (vertexTB_X.Text == "" || vertexTB_Y.Text == "" || vertexTB_Z.Text == "")
                    MessageBox.Show("Введены не все координаты!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    if (SearchDuplicatePoint() == false)
                {
                    VertexGrid.CurrentRow.SetValues(-1, vertexTB_X.Text, vertexTB_Y.Text, vertexTB_X.Text);
                    vertexes_arr = GridToArray(VertexGrid);
                    izm = true;
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                    if (NormalizationCheck(vertexes_norm) != true)
                    {
                        coefficient(vertexes_arr);
                        vertexes_norm = NormalizationCoordinates(vertexes_arr);
                    }
                    //picture(vertexes_norm, edges_arr);
                }
            }
            else MessageBox.Show("Не выбрана строка для изменения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Удаление вершины
        private void DeleteVertexButton_Click(object sender, EventArgs e)
        {
            int current = VertexGrid.CurrentRow.Index + 1;

            for (int i = 0; Convert.ToInt32(edges_arr[i, 0]) == -1; i++)
                if ((current == Convert.ToInt32(edges_arr[i, 1])) || (current == Convert.ToInt32(edges_arr[i, 2])))
                {
                    EdgesGrid.Rows.Remove(EdgesGrid.Rows[i]);
                    Array.Clear(edges_arr, 3, 1000);
                    edges_arr = GridToArray(EdgesGrid);
                    EdgesGrid.Rows.Clear();

                    int n = 0;
                    while (edges_arr[n, 0] == -1)
                    {
                        EdgesGrid.Rows.Add(edges_arr[n, 0], edges_arr[n, 1], edges_arr[n, 2]);
                        n++;
                    }
                    i = -1;

                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                    if (NormalizationCheck(vertexes_norm) != true)
                    {
                        coefficient(vertexes_arr);
                        vertexes_norm = NormalizationCoordinates(vertexes_arr);
                    }
                    //picture(vertexes_norm, edges_arr);
                }

            VertexGrid.Rows.Remove(VertexGrid.CurrentRow);
            vertexes_arr = GridToArray(VertexGrid);

            for (int i = 0; Convert.ToInt32(edges_arr[i, 0]) == -1; i++) //сдвигаем точки ребер
            {
                if (edges_arr[i, 2] > current) edges_arr[i, 2] = edges_arr[i, 2] - 1;
                if (edges_arr[i, 1] > current) edges_arr[i, 1] = edges_arr[i, 1] - 1;
            }
            EdgesGrid.Rows.Clear();
            for (int n = 0; edges_arr[n, 0] == -1; n++)
                EdgesGrid.Rows.Add(edges_arr[n, 0], edges_arr[n, 1], edges_arr[n, 2]);

            izm = true;
        }

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
                if (Convert.ToInt32(edgeTB_start.Text) < 1 || Convert.ToInt32(edgeTB_start.Text) > VertexGrid.Rows.Count || Convert.ToInt32(edgeTB_end.Text) < 1 || Convert.ToInt32(edgeTB_end.Text) > VertexGrid.Rows.Count)
                {
                    MessageBox.Show("Таких вершин не существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    norm = false;
                }

            if (edgeTB_start.Text == edgeTB_end.Text)
            {
                MessageBox.Show("Начало и конец отрезка не могут быть равны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                norm = false;
            }

            if (norm == true && SearchDuplicateEdge() == false)
            {
                EdgesGrid.Rows.Add(EdgesGrid.NewRowIndex, edgeTB_start.Text, edgeTB_end.Text);
                edges_arr = GridToArray(EdgesGrid);
                izm = true;

                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }
                picture(vertexes_norm, edges_arr);
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
                if (Convert.ToInt32(edgeTB_start.Text) < 1 || Convert.ToInt32(edgeTB_start.Text) > VertexGrid.Rows.Count || Convert.ToInt32(edgeTB_end.Text) < 1 || Convert.ToInt32(edgeTB_end.Text) > VertexGrid.Rows.Count)
                {
                    MessageBox.Show("Таких вершин не существует", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    norm = false;
                }

            if (edgeTB_start.Text == edgeTB_end.Text)
            {
                MessageBox.Show("Начало и конец отрезка не могут быть равны!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                norm = false;
            }

            if (norm == true && SearchDuplicateEdge() == false)
            {
                EdgesGrid.CurrentRow.SetValues(EdgesGrid.NewRowIndex, edgeTB_start.Text, edgeTB_end.Text);
                edges_arr = GridToArray(EdgesGrid);
                izm = true;
                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }
                picture(vertexes_norm, edges_arr);
            }
        }

        //Удаление ребра
        private void DeleteEdgeButton_Click(object sender, EventArgs e)
        {
            if (EdgesGrid.CurrentRow != null)
            {
                EdgesGrid.Rows.Remove(EdgesGrid.CurrentRow);
                edges_arr = GridToArray(EdgesGrid);
                izm = true;

                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }
                picture(vertexes_norm, edges_arr);
            }
        }

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

                if (ShiftRoughcheckedListBox.GetItemCheckState(0) == CheckState.Checked) Dx = -Convert.ToDouble(ShiftRoughTextBox.Text) * Math.PI / 180;
                if (ShiftRoughcheckedListBox.GetItemCheckState(1) == CheckState.Checked) Dy = -Convert.ToDouble(ShiftRoughTextBox.Text) * Math.PI / 180;
                if (ShiftRoughcheckedListBox.GetItemCheckState(2) == CheckState.Checked) Dz = -Convert.ToDouble(ShiftRoughTextBox.Text) * Math.PI / 180;

                //матрица сдвига
                double[,] sdvig = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { Dx, Dy, Dz, 1 } };
                double[,] koord = new double[1, 4];//координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл свдига
                {
                    koord[0, 0] = vertexes_arr[i, 1];
                    koord[0, 1] = vertexes_arr[i, 2];
                    koord[0, 2] = vertexes_arr[i, 3];
                    koord[0, 3] = 1;
                    koord = MatrixMultiply(koord, sdvig);
                    vertexes_arr[i, 1] = koord[0, 0];
                    vertexes_arr[i, 2] = koord[0, 1];
                    vertexes_arr[i, 3] = koord[0, 2];
                }
                VertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                editTSS(tss_TX, readTSS(tss_TX) + Dx);
                editTSS(tss_TY, readTSS(tss_TY) + Dy);
                editTSS(tss_TZ, readTSS(tss_TZ) + Dz);
            }
            vertexes_norm = NormalizationCoordinates(vertexes_arr);
            if (NormalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = NormalizationCoordinates(vertexes_arr);
            }
            picture(vertexes_norm, edges_arr);
            izm = true;
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
                double[,] sdvig = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { Dx, Dy, Dz, 1 } };
                double[,] coord = new double[1, 4];//координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл свдига
                {
                    coord[0, 0] = vertexes_arr[i, 1];
                    coord[0, 1] = vertexes_arr[i, 2];
                    coord[0, 2] = vertexes_arr[i, 3];
                    coord[0, 3] = 1;
                    coord = MatrixMultiply(coord, sdvig);
                    vertexes_arr[i, 1] = coord[0, 0];
                    vertexes_arr[i, 2] = coord[0, 1];
                    vertexes_arr[i, 3] = coord[0, 2];
                }
                VertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                editTSS(tss_TX, readTSS(tss_TX) + Dx);
                editTSS(tss_TY, readTSS(tss_TY) + Dy);
                editTSS(tss_TZ, readTSS(tss_TZ) + Dz);
            }

            vertexes_norm= NormalizationCoordinates(vertexes_arr);
            if (NormalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = NormalizationCoordinates(vertexes_arr);
            }

            picture(vertexes_norm, edges_arr);
            izm = true;
        }

        //Точный сдвиг
        private void ShiftAccuratelyButton_Click(object sender, EventArgs e)
        {
            //матрица сдвига
            double[,] sdvig = new double[4, 4] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { Convert.ToDouble(ShiftAccuratelyOXBox.Text), Convert.ToDouble(ShiftAccuratelyOYBox.Text), Convert.ToDouble(ShiftAccuratelyOZBox.Text), 1 } };
            double[,] koord = new double[1, 4];//координаты точки

            for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл свдига
            {
                koord[0, 0] = vertexes_arr[i, 1];
                koord[0, 1] = vertexes_arr[i, 2];
                koord[0, 2] = vertexes_arr[i, 3];
                koord[0, 3] = 1;
                koord = MatrixMultiply(koord, sdvig);
                vertexes_arr[i, 1] = koord[0, 0];
                vertexes_arr[i, 2] = koord[0, 1];
                vertexes_arr[i, 3] = koord[0, 2];
            }
            VertexGrid.Rows.Clear();

            for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

            vertexes_norm = NormalizationCoordinates(vertexes_arr);
            if (NormalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = NormalizationCoordinates(vertexes_arr);
            }
            picture(vertexes_norm, edges_arr);
            izm = true;

            editTSS(tss_TX, readTSS(tss_TX) + Convert.ToDouble(ShiftAccuratelyOXBox.Text));
            editTSS(tss_TY, readTSS(tss_TY) + Convert.ToDouble(ShiftAccuratelyOYBox.Text));
            editTSS(tss_TZ, readTSS(tss_TZ) + Convert.ToDouble(ShiftAccuratelyOZBox.Text));
        }

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

                //матрица масштабирования
                double[,] Rz = new double[4, 4] { { Math.Cos(a), Math.Sin(a), 0, 0 }, { -Math.Sin(a), Math.Cos(a), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                double[,] Rx = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(b), Math.Sin(b), 0 }, { 0, -Math.Sin(b), Math.Cos(b), 0 }, { 0, 0, 0, 1 } };
                double[,] Ry = new double[4, 4] { { Math.Cos(g), 0, Math.Sin(g), 0 }, { 0, 1, 0, 0 }, { -Math.Sin(g), 0, Math.Cos(g), 0 }, { 0, 0, 0, 1 } };

                double[,] koord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
                {
                    koord[0, 0] = vertexes_arr[i, 1];
                    koord[0, 1] = vertexes_arr[i, 2];
                    koord[0, 2] = vertexes_arr[i, 3];
                    koord[0, 3] = 1;
                    koord = MatrixMultiply(koord, Rz);
                    koord = MatrixMultiply(koord, Rx);
                    koord = MatrixMultiply(koord, Ry);
                    vertexes_arr[i, 1] = koord[0, 0];
                    vertexes_arr[i, 2] = koord[0, 1];
                    vertexes_arr[i, 3] = koord[0, 2];
                }
                VertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }
                picture(vertexes_norm, edges_arr);
                izm = true;

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

                //матрица масштабирования
                double[,] Rz = new double[4, 4] { { Math.Cos(a), Math.Sin(a), 0, 0 }, { -Math.Sin(a), Math.Cos(a), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                double[,] Rx = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(b), Math.Sin(b), 0 }, { 0, -Math.Sin(b), Math.Cos(b), 0 }, { 0, 0, 0, 1 } };
                double[,] Ry = new double[4, 4] { { Math.Cos(g), 0, Math.Sin(g), 0 }, { 0, 1, 0, 0 }, { -Math.Sin(g), 0, Math.Cos(g), 0 }, { 0, 0, 0, 1 } };

                double[,] koord = new double[1, 4];//координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
                {
                    koord[0, 0] = vertexes_arr[i, 1];
                    koord[0, 1] = vertexes_arr[i, 2];
                    koord[0, 2] = vertexes_arr[i, 3];
                    koord[0, 3] = 1;
                    koord = MatrixMultiply(koord, Rz);
                    koord = MatrixMultiply(koord, Rx);
                    koord = MatrixMultiply(koord, Ry);
                    vertexes_arr[i, 1] = koord[0, 0];
                    vertexes_arr[i, 2] = koord[0, 1];
                    vertexes_arr[i, 3] = koord[0, 2];
                }
                VertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }
                picture(vertexes_norm, edges_arr);
                izm = true;

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

            //матрица масштабирования
            double[,] Rz = new double[4, 4] { { Math.Cos(a), Math.Sin(a), 0, 0 }, { -Math.Sin(a), Math.Cos(a), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            double[,] Rx = new double[4, 4] { { 1, 0, 0, 0 }, { 0, Math.Cos(b), Math.Sin(b), 0 }, { 0, -Math.Sin(b), Math.Cos(b), 0 }, { 0, 0, 0, 1 } };
            double[,] Ry = new double[4, 4] { { Math.Cos(g), 0, Math.Sin(g), 0 }, { 0, 1, 0, 0 }, { -Math.Sin(g), 0, Math.Cos(g), 0 }, { 0, 0, 0, 1 } };

            double[,] koord = new double[1, 4];//координаты точки

            for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
            {
                koord[0, 0] = vertexes_arr[i, 1];
                koord[0, 1] = vertexes_arr[i, 2];
                koord[0, 2] = vertexes_arr[i, 3];
                koord[0, 3] = 1;
                koord = MatrixMultiply(koord, Rz);
                koord = MatrixMultiply(koord, Rx);
                koord = MatrixMultiply(koord, Ry);
                vertexes_arr[i, 1] = koord[0, 0];
                vertexes_arr[i, 2] = koord[0, 1];
                vertexes_arr[i, 3] = koord[0, 2];
            }
            VertexGrid.Rows.Clear();

            for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

            vertexes_norm = NormalizationCoordinates(vertexes_arr);
            if (NormalizationCheck(vertexes_norm) != true)
            {
                coefficient(vertexes_arr);
                vertexes_norm = NormalizationCoordinates(vertexes_arr);
            }
            picture(vertexes_norm, edges_arr);
            izm = true;

            editTSS(tss_RX, readTSS(tss_RX) + b);
            editTSS(tss_RY, readTSS(tss_RY) + g);
            editTSS(tss_RZ, readTSS(tss_RZ) + a);
        }

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
                        double[,] shift = new double[4, 4] { { Sx, 0, 0, 0 }, { 0, Sy, 0, 0 }, { 0, 0, Sz, 0 }, { 0, 0, 0, 1 } };
                        double[,] koord = new double[1, 4];//координаты точки

                        for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
                        {
                            koord[0, 0] = vertexes_arr[i, 1];
                            koord[0, 1] = vertexes_arr[i, 2];
                            koord[0, 2] = vertexes_arr[i, 3];
                            koord[0, 3] = 1;
                            koord = MatrixMultiply(koord, shift);
                            vertexes_arr[i, 1] = koord[0, 0];
                            vertexes_arr[i, 2] = koord[0, 1];
                            vertexes_arr[i, 3] = koord[0, 2];
                        }
                        VertexGrid.Rows.Clear();

                        for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                            VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                        editTSS(tss_SX, readTSS(tss_SX) * Sx);
                        editTSS(tss_SY, readTSS(tss_SY) * Sy);
                        editTSS(tss_SZ, readTSS(tss_SZ) * Sz);
                    }

                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                    if (NormalizationCheck(vertexes_norm) != true)
                    {
                        coefficient(vertexes_arr);
                        vertexes_norm = NormalizationCoordinates(vertexes_arr);
                    }
                    picture(vertexes_norm, edges_arr);
                    izm = true;
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
                double[,] shift = new double[4, 4] { { Sx, 0, 0, 0 }, { 0, Sy, 0, 0 }, { 0, 0, Sz, 0 }, { 0, 0, 0, 1 } };
                double[,] koord = new double[1, 4]; //координаты точки

                for (int i = 0; vertexes_arr[i, 0] == -1; i++) //цикл масштабирования
                {
                    koord[0, 0] = vertexes_arr[i, 1];
                    koord[0, 1] = vertexes_arr[i, 2];
                    koord[0, 2] = vertexes_arr[i, 3];
                    koord[0, 3] = 1;
                    koord = MatrixMultiply(koord, shift);
                    vertexes_arr[i, 1] = koord[0, 0];
                    vertexes_arr[i, 2] = koord[0, 1];
                    vertexes_arr[i, 3] = koord[0, 2];
                }
                VertexGrid.Rows.Clear();

                for (int i = 0; vertexes_arr[i, 0] == -1; i++)
                    VertexGrid.Rows.Add(vertexes_arr[i, 0], vertexes_arr[i, 1], vertexes_arr[i, 2], vertexes_arr[i, 3]);

                vertexes_norm = NormalizationCoordinates(vertexes_arr);
                if (NormalizationCheck(vertexes_norm) != true)
                {
                    coefficient(vertexes_arr);
                    vertexes_norm = NormalizationCoordinates(vertexes_arr);
                }
                picture(vertexes_norm, edges_arr);
                izm = true;

                editTSS(tss_SX, readTSS(tss_SX) * Sx);
                editTSS(tss_SY, readTSS(tss_SY) * Sy);
                editTSS(tss_SZ, readTSS(tss_SZ) * Sz);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (izm == true)
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

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            izomPNL.DrawToBitmap(b, izomPNL.ClientRectangle);
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect;
            int pbWidth = e.MarginBounds.Width;
            int pbHeight = e.MarginBounds.Height;
            int ImageWidth = b.Width; int ImageHeight = b.Height;

            SizeF sizef = new SizeF(ImageWidth / b.HorizontalResolution, ImageHeight / b.VerticalResolution);
            float fSeale = Math.Min(pbWidth / sizef.Width, pbHeight / sizef.Height);
            sizef.Width *= fSeale;
            sizef.Height *= fSeale;
            Size size = Size.Ceiling(sizef);
            rect = new Rectangle(e.MarginBounds.Location.X, e.MarginBounds.Location.Y, size.Width, size.Height);
            g.DrawImage(b, rect);
        }
    }
}