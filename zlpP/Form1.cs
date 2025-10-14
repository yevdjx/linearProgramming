using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace zlpP
{
    public partial class Form1 : Form
    {
        // Поля класса
        private List<Constraint> constraints;    // Список ограничений задачи
        private List<PointF> points;             // Все точки пересечений ограничений
        private List<PointF> feasiblePoints;     // Допустимые точки (вершины многоугольника решений)
        private PointF optimalPoint;             // Оптимальная точка решения
        private double optimalValue;             // Оптимальное значение целевой функции
        private bool isSolved = false;           // Флаг решения задачи
        private int currentStep = 0;             // Текущий шаг пошагового решения
        private List<string> steps;              // Список шагов решения для отображения

        // Конструктор формы
        public Form1()
        {
            InitializeComponent();

            constraints = new List<Constraint>();
            points = new List<PointF>();
            feasiblePoints = new List<PointF>();
            steps = new List<string>();

            AddDefaultConstraint();  // Добавляем ограничение по умолчанию
            InitializeDataGridView(); // Настраиваем таблицу ограничений
            InitializeData();         // Инициализируем данные
        }

        // Инициализация данных
        private void InitializeData()
        {
            constraints = new List<Constraint>();
            points = new List<PointF>();
            feasiblePoints = new List<PointF>();
            steps = new List<string>();

            AddDefaultConstraint();
        }

        // Класс ограничения
        public class Constraint
        {
            public double A { get; set; }
            public double B { get; set; }
            public string Inequality { get; set; }
            public double C { get; set; }

            public Constraint(double a, double b, string inequality, double c)
            {
                A = a;
                B = b;
                Inequality = inequality;
                C = c;
            }

            public bool IsSatisfied(double x, double y)
            {
                double value = A * x + B * y;

                switch (Inequality)
                {
                    case "<=": return value <= C + 0.001;
                    case ">=": return value >= C - 0.001;
                    case "=": return Math.Abs(value - C) < 0.001;
                    default: return false;
                }
            }
        }

        // Инициализация таблицы 
        private void InitializeDataGridView()
        {
            dataGridViewConstraints.RowHeadersVisible = false;

            // Настройка столбцов DataGridView
            dataGridViewConstraints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Создаем столбцы если их нет
            if (dataGridViewConstraints.Columns.Count == 0)
            {
                dataGridViewConstraints.Columns.Add("A", "Коэф. х₁");
                dataGridViewConstraints.Columns.Add("B", "Коэф. х₂");
                dataGridViewConstraints.Columns.Add("Sign", "Знак");
                dataGridViewConstraints.Columns.Add("C", "Значение");
            }

            // Устанавливаем одинаковую ширину для трех столбцов
            int equalWidth = 90;
            dataGridViewConstraints.Columns["A"].Width = equalWidth;
            dataGridViewConstraints.Columns["B"].Width = equalWidth;
            dataGridViewConstraints.Columns["Sign"].Width = equalWidth;

            dataGridViewConstraints.Columns["C"].Width = 110;
        }

        // Добавление ограничения по умолчанию
        private void AddDefaultConstraint()
        {
            dataGridViewConstraints.Rows.Add(1, 1, "<=", 10);
            UpdateConstraints();
        }

        // Обновление списка ограничений из таблицы
        private void UpdateConstraints()
        {
            constraints = new List<Constraint>();
            foreach (DataGridViewRow row in dataGridViewConstraints.Rows)
            {
                if (row.IsNewRow) continue;

                double a = Convert.ToDouble(row.Cells["A"].Value ?? 1);
                double b = Convert.ToDouble(row.Cells["B"].Value ?? 1);
                string sign = row.Cells["Sign"].Value?.ToString() ?? "<=";
                double c = Convert.ToDouble(row.Cells["C"].Value ?? 5);

                constraints.Add(new Constraint(a, b, sign, c));
            }
            isSolved = false;
            panelRight.Invalidate();
        }

        // Поиск всех точек пересечения ограничений
        private void FindAllPoints()
        {
            points.Clear();

            // Всегда добавляем начало координат
            points.Add(new PointF(0, 0));

            // Находим пересечения всех ограничений попарно
            for (int i = 0; i < constraints.Count; i++)
            {
                for (int j = i + 1; j < constraints.Count; j++)
                {
                    PointF? intersection = GetIntersection(constraints[i], constraints[j]);
                    if (intersection.HasValue && intersection.Value.X >= -0.001 && intersection.Value.Y >= -0.001)
                    {
                        points.Add(intersection.Value);
                    }
                }
                // Пересечения с осями для каждого ограничения
                AddAxisIntersections(constraints[i]);
            }

            // Добавляем точки далеко на осях для неограниченных областей
            AddFarPointsForUnboundedRegions();
        }

        // Добавление точек для неограниченных областей
        private void AddFarPointsForUnboundedRegions()
        {
            // Находим максимальные значения из ограничений
            float maxX = 0, maxY = 0;

            foreach (var constraint in constraints)
            {
                if (constraint.A != 0)
                {
                    float x = (float)(constraint.C / constraint.A);
                    if (x > maxX) maxX = x;
                }

                if (constraint.B != 0)
                {
                    float y = (float)(constraint.C / constraint.B);
                    if (y > maxY) maxY = y;
                }
            }

            // Добавляем точки далеко за пределами в 2 раза дальше максимальных значений
            float farX = Math.Max(maxX * 2, 50f);
            float farY = Math.Max(maxY * 2, 50f);

            points.Add(new PointF(farX, 0));
            points.Add(new PointF(0, farY));
            points.Add(new PointF(farX, farY));
        }

        // Добавление точек пересечения с осями координат
        private void AddAxisIntersections(Constraint c)
        {
            // С осью X (y = 0)
            if (Math.Abs(c.A) > 1e-10)
            {
                float x = (float)(c.C / c.A);
                if (x >= -0.001)
                    points.Add(new PointF(Math.Max(0, x), 0));
            }

            // С осью Y (x = 0)
            if (Math.Abs(c.B) > 1e-10)
            {
                float y = (float)(c.C / c.B);
                if (y >= -0.001)
                    points.Add(new PointF(0, Math.Max(0, y)));
            }
        }

        // Поиск точки пересечения двух ограничений
        private PointF? GetIntersection(Constraint c1, Constraint c2)
        {
            double det = c1.A * c2.B - c2.A * c1.B;
            if (Math.Abs(det) < 1e-10) return null;

            double x = (c2.B * c1.C - c1.B * c2.C) / det;
            double y = (c1.A * c2.C - c2.A * c1.C) / det;

            // Проверяем, что точка неотрицательная 
            if (x >= -0.001 && y >= -0.001)
                return new PointF((float)x, (float)y);

            return null;
        }

        // Поиск допустимых точек (принадлежащих области решений)
        private void FindFeasiblePoints()
        {
            feasiblePoints.Clear();

            // Сначала находим все допустимые точки
            foreach (PointF p in points)
            {
                if (IsPointFeasible(p))
                {
                    // Проверяем на дубликаты
                    if (!feasiblePoints.Any(existing =>
                        Math.Abs(existing.X - p.X) < 0.01 && Math.Abs(existing.Y - p.Y) < 0.01))
                    {
                        feasiblePoints.Add(p);
                    }
                }
            }

            // Если область неограниченная, находим "угловые" точки для построения полигона
            if (feasiblePoints.Count >= 3)
            {
                FindConvexHull();
            }
        }

        // Построение выпуклой оболочки точек
        private void FindConvexHull()
        {
            if (feasiblePoints.Count < 3) return;

            var hull = new List<PointF>();

            // Находим самую левую-нижнюю точку
            PointF startPoint = feasiblePoints[0];
            foreach (PointF p in feasiblePoints)
            {
                if (p.X < startPoint.X || (p.X == startPoint.X && p.Y < startPoint.Y))
                    startPoint = p;
            }

            hull.Add(startPoint);

            // Сортируем точки по полярному углу относительно startPoint
            var sortedPoints = feasiblePoints
                .Where(p => p != startPoint)
                .OrderBy(p => Math.Atan2(p.Y - startPoint.Y, p.X - startPoint.X))
                .ThenBy(p => Distance(startPoint, p))
                .ToList();

            foreach (PointF point in sortedPoints)
            {
                while (hull.Count >= 2 && CrossProduct(hull[hull.Count - 2], hull[hull.Count - 1], point) <= 0)
                {
                    hull.RemoveAt(hull.Count - 1);
                }
                hull.Add(point);
            }

            feasiblePoints = hull;
        }

        // Вычисление расстояния между двумя точками
        private float Distance(PointF a, PointF b)
        {
            float dx = a.X - b.X;
            float dy = a.Y - b.Y;
            return dx * dx + dy * dy;
        }

        // Векторное произведение для определения ориентации
        private float CrossProduct(PointF a, PointF b, PointF c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        // Проверка точки на допустимость (удовлетворяет всем ограничениям)
        private bool IsPointFeasible(PointF p)
        {
            // Проверяем неотрицательность
            if (p.X < -0.001 || p.Y < -0.001) return false;

            // Проверяем все ограничения
            foreach (Constraint c in constraints)
            {
                if (!c.IsSatisfied(p.X, p.Y))
                    return false;
            }
            return true;
        }

        // Поиск оптимального решения
        private void FindOptimalSolution(double x1coef, double x2coef, bool isMax)
        {
            if (feasiblePoints.Count == 0)
                throw new Exception("Нет допустимых решений");

            optimalValue = isMax ? double.MinValue : double.MaxValue;
            optimalPoint = feasiblePoints[0];

            foreach (PointF p in feasiblePoints)
            {
                double value = x1coef * p.X + x2coef * p.Y;

                if ((isMax && value > optimalValue) || (!isMax && value < optimalValue))
                {
                    optimalValue = value;
                    optimalPoint = p;
                }
            }
        }

        // Генерация шагов решения для отображения
        private void GenerateSteps(double x1coef, double x2coef, bool isMax)
        {
            steps.Clear();

            steps.Add("ШАГ 1: Построение ограничений");
            for (int i = 0; i < constraints.Count; i++)
            {
                steps.Add($"Ограничение {i + 1}: {FormatConstraint(constraints[i])}");
            }

            steps.Add("\nШАГ 2: Определение полуплоскостей");
            for (int i = 0; i < constraints.Count; i++)
            {
                steps.Add($"Ограничение {i + 1} - {GetHalfPlaneDesc(constraints[i])}");
            }

            steps.Add("\nШАГ 3: Область допустимых решений");
            steps.Add("Пересечение всех полуплоскостей и первой четверти");

            steps.Add("\nШАГ 4: Вершины многоугольника");
            for (int i = 0; i < feasiblePoints.Count; i++)
            {
                steps.Add($"{GetPointName(i)}({feasiblePoints[i].X:F2}, {feasiblePoints[i].Y:F2})");
            }

            // информация про масштаб
            float scale = CalculateOptimalScale();
            steps.Add($"\nМасштаб: {scale:F1}, Максимальные координаты: X={feasiblePoints.Max(p => p.X):F1}, Y={feasiblePoints.Max(p => p.Y):F1}");

            steps.Add("\nШАГ 5: Вектор градиента");
            steps.Add($"Градиент: ({x1coef}, {x2coef})");
            steps.Add("Направление наискорейшего роста функции");

            steps.Add("\nШАГ 6: Вычисление значений");
            foreach (PointF p in feasiblePoints)
            {
                double val = x1coef * p.X + x2coef * p.Y;
                steps.Add($"F({p.X:F2}, {p.Y:F2}) = {val:F2}");
            }

            steps.Add($"\nРЕЗУЛЬТАТ: {(isMax ? "МАКСИМУМ" : "МИНИМУМ")}");
            steps.Add($"F({optimalPoint.X:F2}, {optimalPoint.Y:F2}) = {optimalValue:F2}");
        }

        // Форматирование ограничения в читаемый вид
        private string FormatConstraint(Constraint c)
        {
            string result = "";

            // Коэффициент при x1
            if (Math.Abs(c.A) > 1e-10)
            {
                if (c.A == 1)
                    result += "x₁";
                else if (c.A == -1)
                    result += "-x₁";
                else
                    result += $"{c.A}x₁";
            }

            // Коэффициент при x2
            if (Math.Abs(c.B) > 1e-10)
            {
                if (result.Length > 0)
                    result += c.B >= 0 ? " + " : " - ";
                else if (c.B < 0)
                    result += "-";

                if (Math.Abs(c.B) == 1)
                    result += "x₂";
                else
                    result += $"{Math.Abs(c.B)}x₂";
            }

            // Если оба коэффициента нулевые
            if (string.IsNullOrEmpty(result))
                result = "0";

            // Знак неравенства и значение
            result += $" {c.Inequality} {c.C}";

            return result;
        }

        // Получение описания полуплоскости
        private string GetHalfPlaneDesc(Constraint c)
        {
            return c.Inequality == "<=" ? "полуплоскость ниже прямой" : "полуплоскость выше прямой";
        }

        // Получение имени точки
        private string GetPointName(int index)
        {
            return ((char)('A' + index)).ToString();
        }

        // Основный метод решения задачи
        private void SolveProblem()
        {
            try
            {
                // Получаем коэффициенты целевой функции из интерфейса
                double x1coef = Convert.ToDouble(txtX1.Text);
                double x2coef = Convert.ToDouble(txtX2.Text);
                bool isMax = rbMax.Checked; // Определяем направление оптимизации

                // Сбрасываем состояние решения
                isSolved = false;

                // Основные этапы:
                FindAllPoints();        // Находим все точки пересечений ограничений
                FindFeasiblePoints();   // Определяем допустимые точки

                if (feasiblePoints.Count == 0)
                {
                    MessageBox.Show("Область допустимых решений пуста!");
                    return;
                }

                FindOptimalSolution(x1coef, x2coef, isMax); // Находим оптимальное решение
                GenerateSteps(x1coef, x2coef, isMax);       // Генерируем шаги решения

                // Обновляем отображение
                currentStep = Math.Min(steps.Count - 1, 28);
                UpdateStepDisplay();
                isSolved = true;
                panelRight.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        // Отрисовка координатной системы
        private void DrawCoordinateSystem(Graphics g)
        {
            int width = panelRight.Width;
            int height = panelRight.Height;

            int offsetX = width / 10;      // ось y всегда на 10% от левого края
            int offsetY = height * 9 / 10; // ось x всегда на 10% от нижнего края

            float scale = CalculateOptimalScale();

            g.DrawLine(Pens.Black, 0, offsetY, width, offsetY); // ось x
            g.DrawLine(Pens.Black, offsetX, 0, offsetX, height); // ось y

            // Стрелки осей
            DrawAxisArrows(g, width, height, offsetX, offsetY);

            // Засечки и подписи
            DrawGridMarks(g, width, height, offsetX, offsetY, scale);

            // Подписи осей
            g.DrawString("X₁", Font, Brushes.Black, width - 20, offsetY + 5);
            g.DrawString("X₂", Font, Brushes.Black, offsetX + 5, 5);
        }

        // Отрисовка засечек и подписей на осях
        private void DrawGridMarks(Graphics g, int width, int height, int offsetX, int offsetY, float scale)
        {
            // Вычисляем максимальные значения, которые можно отобразить
            float maxVisibleX = (width - offsetX - 20) / scale; // макс X справа от оси Y
            float maxVisibleY = (offsetY - 20) / scale;         // макс Y над осью X
            float minVisibleX = -offsetX / scale;               // мин X слева от оси Y
            float minVisibleY = -(height - offsetY) / scale;    // мин Y под осью X

            // Определяем шаг для засечек
            float visibleRange = Math.Max(maxVisibleX - minVisibleX, maxVisibleY - minVisibleY);
            float step = GetOptimalStep(visibleRange);

            // Засечки на оси X (положительные)
            for (float i = step; i <= maxVisibleX; i += step)
            {
                int x = offsetX + (int)(i * scale);
                if (x < width - 20)
                {
                    g.DrawLine(Pens.Gray, x, offsetY - 3, x, offsetY + 3);
                    string label = FormatLabel(i);
                    g.DrawString(label, Font, Brushes.Black, x - 8, offsetY + 5);
                }
            }

            // Засечки на оси X (отрицательные)
            for (float i = -step; i >= minVisibleX; i -= step)
            {
                int x = offsetX + (int)(i * scale);
                if (x > 20)
                {
                    g.DrawLine(Pens.Gray, x, offsetY - 3, x, offsetY + 3);
                    string label = FormatLabel(i);
                    g.DrawString(label, Font, Brushes.Black, x - 8, offsetY + 5);
                }
            }

            // Засечки на оси Y (положительные)
            for (float i = step; i <= maxVisibleY; i += step)
            {
                int y = offsetY - (int)(i * scale);
                if (y > 20)
                {
                    g.DrawLine(Pens.Gray, offsetX - 3, y, offsetX + 3, y);
                    string label = FormatLabel(i);
                    g.DrawString(label, Font, Brushes.Black, offsetX + 5, y - 8);
                }
            }

            // Засечки на оси Y (отрицательные)
            for (float i = -step; i >= minVisibleY; i -= step)
            {
                int y = offsetY - (int)(i * scale);
                if (y < height - 20)
                {
                    g.DrawLine(Pens.Gray, offsetX - 3, y, offsetX + 3, y);
                    string label = FormatLabel(i);
                    g.DrawString(label, Font, Brushes.Black, offsetX + 5, y - 8);
                }
            }

            g.DrawString("0", Font, Brushes.Black, offsetX + 3, offsetY + 3);
        }

        // Форматирование подписей на осях
        private string FormatLabel(float value)
        {
            // Для больших чисел используем целочисленный формат
            if (Math.Abs(value) >= 100)
                return value.ToString("F0");

            // Для средних чисел используем одну decimal
            if (Math.Abs(value) >= 10)
                return value.ToString("F0");

            // Для маленьких чисел используем одну decimal
            return value.ToString("F1");
        }

        // Определение оптимального шага для засечек
        private float GetOptimalStep(float range)
        {
            // Для больших диапазонов используем большие шаги
            if (range <= 5) return 1f;
            if (range <= 10) return 2f;
            if (range <= 20) return 5f;
            if (range <= 50) return 10f;
            if (range <= 100) return 20f;
            if (range <= 200) return 50f;
            if (range <= 500) return 100f;
            if (range <= 1000) return 200f;

            // Для очень больших диапазонов
            return (float)Math.Pow(10, Math.Ceiling(Math.Log10(range)) - 1);
        }

        // Отрисовка стрелок на осях
        private void DrawAxisArrows(Graphics g, int width, int height, int offsetX, int offsetY)
        {
            // Стрелка оси X
            g.DrawLine(Pens.Black, width - 10, offsetY - 5, width, offsetY);
            g.DrawLine(Pens.Black, width - 10, offsetY + 5, width, offsetY);

            // Стрелка оси Y
            g.DrawLine(Pens.Black, offsetX - 5, 10, offsetX, 0);
            g.DrawLine(Pens.Black, offsetX + 5, 10, offsetX, 0);
        }

        // Отрисовка ограничений
        private void DrawConstraints(Graphics g)
        {
            if (constraints.Count == 0) return;

            int width = panelRight.Width;
            int height = panelRight.Height;

            // Положение осей
            int offsetX = width / 10;
            int offsetY = height * 9 / 10;

            float scale = CalculateOptimalScale();

            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown };

            for (int i = 0; i < constraints.Count; i++)
            {
                if (i > currentStep) break;

                DrawConstraintLine(g, constraints[i], colors[i % colors.Length], offsetX, offsetY, scale, width, height);
            }
        }

        // Отрисовка линии ограничения
        private void DrawConstraintLine(Graphics g, Constraint constraint, Color color, int offsetX, int offsetY, float scale, int width, int height)
        {
            Pen pen = new Pen(color, 2);

            // Вычисляем точки пересечения с границами экрана
            PointF p1, p2;

            if (Math.Abs(constraint.B) > 1e-10)
            {
                // Наклонная линия
                // Вычисляем Y для X на левой и правой границах
                float x1 = -offsetX / scale;  // левая граница
                float y1 = (float)((constraint.C - constraint.A * x1) / constraint.B);

                float x2 = (width - offsetX) / scale; // правая граница
                float y2 = (float)((constraint.C - constraint.A * x2) / constraint.B);

                // Вычисляем X для Y на верхней и нижней границах
                float y3 = offsetY / scale;    // верхняя граница
                float x3 = (float)((constraint.C - constraint.B * y3) / constraint.A);

                float y4 = -(height - offsetY) / scale; // нижняя граница
                float x4 = (float)((constraint.C - constraint.B * y4) / constraint.A);

                // Выбираем две точки, которые находятся в пределах экрана
                List<PointF> points = new List<PointF>();

                // Проверяем точки на границах
                if (y1 >= -(height - offsetY) / scale && y1 <= offsetY / scale)
                    points.Add(new PointF(offsetX + x1 * scale, offsetY - y1 * scale));

                if (y2 >= -(height - offsetY) / scale && y2 <= offsetY / scale)
                    points.Add(new PointF(offsetX + x2 * scale, offsetY - y2 * scale));

                if (x3 >= -offsetX / scale && x3 <= (width - offsetX) / scale)
                    points.Add(new PointF(offsetX + x3 * scale, offsetY - y3 * scale));

                if (x4 >= -offsetX / scale && x4 <= (width - offsetX) / scale)
                    points.Add(new PointF(offsetX + x4 * scale, offsetY - y4 * scale));

                if (points.Count >= 2)
                {
                    p1 = points[0];
                    p2 = points[1];
                    g.DrawLine(pen, p1, p2);
                }
            }
            else
            {
                // Вертикальная линия
                float x = (float)(constraint.C / constraint.A);
                p1 = new PointF(offsetX + x * scale, 0);
                p2 = new PointF(offsetX + x * scale, height);
                g.DrawLine(pen, p1, p2);
            }

            pen.Dispose();
        }

        // Отрисовка области допустимых решений
        private void DrawFeasibleRegion(Graphics g)
        {
            if (feasiblePoints.Count < 3) return;

            int width = panelRight.Width;
            int height = panelRight.Height;

            // Положение осей
            int offsetX = width / 10;
            int offsetY = height * 9 / 10;

            float scale = CalculateOptimalScale();

            // Преобразуем точки в экранные координаты относительно осей
            PointF[] screenPoints = feasiblePoints
                .Select(p => new PointF(offsetX + p.X * scale, offsetY - p.Y * scale))
                .ToArray();

            // Заливаем область допустимых решений
            using (var regionBrush = new SolidBrush(Color.FromArgb(180, Color.LightBlue)))
            {
                g.FillPolygon(regionBrush, screenPoints);
            }

            // Контур полигона
            using (var borderPen = new Pen(Color.Blue, 2))
            {
                g.DrawPolygon(borderPen, screenPoints);
            }

            // Рисуем вершины полигона
            for (int i = 0; i < screenPoints.Length; i++)
            {
                g.FillEllipse(Brushes.Red, screenPoints[i].X - 4, screenPoints[i].Y - 4, 8, 8);
                char pointName = (char)('A' + i);
                g.DrawString(pointName.ToString(), Font, Brushes.Black,
                    screenPoints[i].X + 5, screenPoints[i].Y - 10);
            }
        }

        // Отрисовка оптимальной точки
        private void DrawOptimalPoint(Graphics g)
        {
            if (!isSolved) return;

            int width = panelRight.Width;
            int height = panelRight.Height;

            // Положение осей
            int offsetX = width / 10;
            int offsetY = height * 9 / 10;

            float scale = CalculateOptimalScale();

            // Координаты оптимальной точки на экране относительно фикс осей
            PointF screenPoint = new PointF(
                offsetX + optimalPoint.X * scale,
                offsetY - optimalPoint.Y * scale);

            // Выделяем оптимальную точку
            g.FillEllipse(Brushes.Gold, screenPoint.X - 6, screenPoint.Y - 6, 12, 12);
            g.DrawEllipse(new Pen(Color.DarkRed, 2), screenPoint.X - 6, screenPoint.Y - 6, 12, 12);

            // Подпись оптимальной точки
            int optimalIndex = feasiblePoints.FindIndex(p =>
                Math.Abs(p.X - optimalPoint.X) < 0.001 &&
                Math.Abs(p.Y - optimalPoint.Y) < 0.001);

            if (optimalIndex >= 0)
            {
                char pointName = (char)('A' + optimalIndex);
                g.DrawString($"{pointName}*", new Font(Font, FontStyle.Bold),
                    Brushes.DarkRed, screenPoint.X + 8, screenPoint.Y - 12);
            }
        }

        // Отрисовка стрелки
        private void DrawArrow(Graphics g, Pen pen, PointF start, PointF end)
        {
            float arrowSize = 8;
            float dx = end.X - start.X;
            float dy = end.Y - start.Y;
            float length = (float)Math.Sqrt(dx * dx + dy * dy);

            if (length > 0)
            {
                float unitX = dx / length;
                float unitY = dy / length;

                PointF arrow1 = new PointF(
                    end.X - unitX * arrowSize + unitY * arrowSize / 2,
                    end.Y - unitY * arrowSize - unitX * arrowSize / 2);
                PointF arrow2 = new PointF(
                    end.X - unitX * arrowSize - unitY * arrowSize / 2,
                    end.Y - unitY * arrowSize + unitX * arrowSize / 2);

                g.DrawLine(pen, end, arrow1);
                g.DrawLine(pen, end, arrow2);
            }
        }

        // Отрисовка вектора градиента
        private void DrawGradient(Graphics g)
        {
            if (!isSolved) return;

            double x1coef = Convert.ToDouble(txtX1.Text);
            double x2coef = Convert.ToDouble(txtX2.Text);

            int width = panelRight.Width;
            int height = panelRight.Height;

            // Положение осей
            int offsetX = width / 10;
            int offsetY = height * 9 / 10;

            float scale = CalculateOptimalScale();

            // Нормализуем вектор градиента
            double length = Math.Sqrt(x1coef * x1coef + x2coef * x2coef);
            if (length < 1e-10) return;

            double normA = x1coef / length * 5; // увеличиваем длину вектора
            double normB = x2coef / length * 5;

            // Вектор начинается из начала координат (0,0)
            PointF start = new PointF(offsetX, offsetY);
            PointF end = new PointF(
                offsetX + (float)normA * scale,
                offsetY - (float)normB * scale);

            // Рисуем вектор градиента
            using (Pen gradientPen = new Pen(Color.DarkGreen, 3))
            {
                g.DrawLine(gradientPen, start, end);
                DrawArrow(g, gradientPen, start, end);
            }

            // Подпись градиента
            g.DrawString($"Градиент ({x1coef}, {x2coef})",
                Font, Brushes.DarkGreen, end.X + 5, end.Y - 5);
        }

        // Вычисление оптимального масштаба для отображения
        private float CalculateOptimalScale()
        {
            if (feasiblePoints.Count == 0)
                return 40f;

            try
            {
                int width = panelRight.Width;
                int height = panelRight.Height;

                // Положение осей
                int offsetX = width / 10;
                int offsetY = height * 9 / 10;

                // Найти границы полигона решений
                float minX = feasiblePoints.Min(p => p.X);
                float maxX = feasiblePoints.Max(p => p.X);
                float minY = feasiblePoints.Min(p => p.Y);
                float maxY = feasiblePoints.Max(p => p.Y);

                // Вычисляем необходимую область отображения с запасом 20%
                float requiredWidth = (maxX - minX) * 1.2f;
                float requiredHeight = (maxY - minY) * 1.2f;

                // Если числа очень большие, уменьшаем масштаб более агрессивно
                if (requiredWidth > 1000 || requiredHeight > 1000)
                {
                    float maxDimension = Math.Max(requiredWidth, requiredHeight);
                    float scaleForLarge = Math.Min(width, height) / maxDimension * 0.8f;
                    return Math.Max(scaleForLarge, 1f); // Минимальный масштаб 1
                }

                // Доступная область для графика (от фиксированных осей)
                float availableWidthRight = width - offsetX - 20;  // справа от оси Y
                float availableWidthLeft = offsetX - 20;           // слева от оси Y
                float availableHeightUp = offsetY - 20;            // над осью X
                float availableHeightDown = height - offsetY - 20; // под осью X

                // Вычислить масштаб для каждой четверти
                float scaleRight = availableWidthRight / Math.Max(maxX, 0.1f);
                float scaleLeft = availableWidthLeft / Math.Max(-minX, 0.1f);
                float scaleUp = availableHeightUp / Math.Max(maxY, 0.1f);
                float scaleDown = availableHeightDown / Math.Max(-minY, 0.1f);

                // Взять наименьший масштаб для гарантии полного отображения
                float scale = Math.Min(Math.Min(scaleRight, scaleLeft), Math.Min(scaleUp, scaleDown));

                // Ограничить масштаб разумными пределами
                scale = Math.Max(scale, 1f);   // минимальный масштаб уменьшен для больших чисел
                scale = Math.Min(scale, 200f);

                return scale;
            }
            catch (Exception)
            {
                return 40f;
            }
        }

        // Обновление отображения текущего шага
        private void UpdateStepDisplay()
        {
            lblStep.Text = $"Шаг {currentStep + 1}/{steps.Count}";

            if (steps.Count > 0 && currentStep < steps.Count)
            {
                txtSolution.Text = string.Join("\n", steps.Take(currentStep + 1));
                txtSolution.SelectionStart = txtSolution.Text.Length;
                txtSolution.ScrollToCaret();
            }
        }

        // Обработчики событий кнопок

        private void btnAddConstraint_Click_1(object sender, EventArgs e)
        {
            dataGridViewConstraints.Rows.Add(1, 1, "<=", 5);
            UpdateConstraints();
        }

        private void btnSolve_Click_1(object sender, EventArgs e)
        {
            SolveProblem();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            dataGridViewConstraints.Rows.Clear();
            constraints.Clear();
            points.Clear();
            feasiblePoints.Clear();
            steps.Clear();
            currentStep = 0;
            isSolved = false;

            txtX1.Clear();
            txtX2.Clear();

            rbMax.Checked = true;
            rbMin.Checked = false;

            txtSolution.Clear();
            lblStep.Text = "Шаг 0/0";
            panelRight.Invalidate();

            AddDefaultConstraint();
        }

        private void btnNextStep_Click_1(object sender, EventArgs e)
        {
            if (currentStep < steps.Count - 1)
            {
                currentStep++;
                UpdateStepDisplay();
                panelRight.Invalidate();
            }
        }

        private void btnPrevStep_Click_1(object sender, EventArgs e)
        {
            if (currentStep > 0)
            {
                currentStep--;
                UpdateStepDisplay();
                panelRight.Invalidate();
            }
        }

        // Обработчик отрисовки правой панели
        private void panelRight_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawCoordinateSystem(g);

            if (constraints.Count > 0)
            {
                DrawConstraints(g);

                if (isSolved && currentStep >= 2)
                {
                    DrawFeasibleRegion(g);
                }

                if (isSolved && currentStep >= 5)
                {
                    DrawOptimalPoint(g);
                }

                if (isSolved && currentStep >= 4)
                {
                    DrawGradient(g);
                }
            }
        }

        // Обработчик изменения значений в таблице ограничений
        private void dataGridViewConstraints_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            UpdateConstraints();
        }


    }
}