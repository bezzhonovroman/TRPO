using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace TRPOLAB2
{
    partial class ManualInputForm : Form
    {
        private Form parent;
        private Polygon[] polygons;
        private double inputX = -1;
        private double inputY = -1;
        private int seed = 0;

        public ManualInputForm()
        {
            InitializeComponent();
        }

        private void ManualInputForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parent.Show();
        }

        public void show(Form parent, ref Polygon[] polygons)
        {
            this.Show();
            this.parent = parent;
            this.polygons = polygons;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            pictureBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = "Информация: ";
            label3.Text = "Точка находится в области (-ях):";
            if (validatePoint(textBox1.Text, textBox2.Text) && validateValues())
                inspection(new Point(inputX, inputY));
        }

        private void inspection(Point point)
        {
            label7.Text = "Информация: ";
            label3.Text = "Точка находится в области (-ях):";
            label3.Text = string.Format("Точка ({0};{1}) находится в области (-ях): ", point.getX().ToString("F3"), point.getY().ToString("F3"));
            label3.Refresh();
            int numberOfZone = 0;
            foreach (Polygon p in polygons)
            {
                if (p.isDotInsidePolygonSpecialInspection(new Point(inputX, inputY)))
                {
                    label3.Text += (numberOfZone + 1).ToString() + " ";
                }
                numberOfZone++;
            }
            using (StreamWriter writer = File.AppendText("result.txt"))
            {
                writer.WriteLine(label3.Text);
                writer.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = "Информация: ";
            label3.Text = "Точка находится в области (-ях):";
            using (StreamReader streamReader = new StreamReader(Path.GetFullPath("data.txt")))
            {
                string coordinatesLine = streamReader.ReadLine();
               
                if (!validateStringFromText(coordinatesLine))
                {
                    return;
                }
                if (!fileHasNoMoreData(streamReader))
                {
                    return;
                }
                streamReader.Close();
                string[] parts = coordinatesLine.Split(';');

                if (validatePoint(parts[0], parts[1]) && validateValues())
                {
                    inspection(new Point(inputX, inputY));
                }
            }
        }

        private bool fileHasNoMoreData(StreamReader reader)
        {
            string data = reader.ReadToEnd();
            if (data == null || data.Equals("")) return true;
            label7.Text = "Информация: в файле должна содержаться координата \n одной точки в формате Х;Y";
            return false;
        }

        private bool validateStringFromText(String str)
        {
            if (str == null)
            {
                label7.Text = "Информация: неверно задан формат координат (формат Х;Y)";
                return false;
            }

            string[] parts = str.Split(';');
            if (parts.Length < 2 || parts.Length > 2)
            {
                label7.Text = "Информация: необходимо задать одну точку \n в формате Х;Y";
                return false;
            }

            return true;
        }

        private bool validatePoint(string x, string y)
        {
            if (!double.TryParse(x, out inputX))
            {
                label7.Text = "Информация: введите в поле X значение или измените формат";
                return false;
            }
            if (!double.TryParse(y, out inputY))
            {
                label7.Text = "Информация: введите в поле Y значение или измените формат";
                return false;
            }
            return true;
        }

        private bool validateValues()
        {
            if (!(0 <= inputX) || !(0 <= inputY && 7 >= inputY))
            {
                label7.Text = "Информация: значения недопустимы (0 <= X; 0 <= Y <= 7)";
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label7.Text = "Информация: ";
            label3.Text = "Точка находится в области (-ях):";
            Random random = new Random(seed);
            seed = random.Next();
            inputY = random.NextDouble() * 7;
            inputX = random.NextDouble() * 10;
            inspection(new Point(inputX, inputY));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Rectangle rectangle = pictureBox2.ClientRectangle;
            System.Drawing.Point locateCursor = Cursor.Position;
            System.Drawing.Point point = pictureBox2.PointToClient(locateCursor);
            pictureBox2.Refresh();

            System.Drawing.Point location = pictureBox2.Location;
            System.Drawing.Point coordMouse = ActiveForm.PointToClient(locateCursor);
            inputX = ((double)coordMouse.X - location.X) / rectangle.Width * 10.7D;
            inputY = ((double)location.Y + rectangle.Height - coordMouse.Y) / rectangle.Height * 7D;
            inspection(new Point(inputX, inputY));
            SolidBrush myBrush = new SolidBrush(Color.Red);
            Graphics formGraphics;
            formGraphics = pictureBox2.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(point.X, point.Y, 4, 4));
            myBrush.Dispose();
            formGraphics.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "Точка находится в области (-ях):";
            label7.Text = "Информация:";
            groupBox1.Enabled = true;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            pictureBox2.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label3.Text = "Точка находится в области (-ях):";
            label7.Text = "Информация:";
            groupBox1.Enabled = false;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
            pictureBox2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label3.Text = "Точка находится в области (-ях):";
            label7.Text = "Информация:";
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
            pictureBox2.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label3.Text = "Точка находится в области (-ях):";
            label7.Text = "Информация:";
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            pictureBox2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManualInputForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
