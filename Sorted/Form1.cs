namespace Sorted
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void StartSort(int[] array, Form1 form)
        {
            MySorter sorter = new MySorter();
            //sorter.bubblesort(array, form);
            new Thread(() => sorter.bubblesort(array, form)).Start();
            new Thread(() => sorter.shakersort(array, form)).Start();
            new Thread(() => sorter.gnomesort(array, form)).Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load_2(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }


        private void listBox27_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string s_size = textBox4.Text;
            string s_start_d = this.textBox6.Text;
            string s_end_d = this.textBox5.Text;

            int size = Convert.ToInt32(s_size);
            int start_d = Convert.ToInt32(s_start_d);
            int end_d = Convert.ToInt32(s_end_d);

            int[] our_array = new int[size];
            Random random = new Random();

            for (int x = 0; x < our_array.Length; x++)
            {
                our_array[x] = random.Next(start_d, end_d);
            }

            textBox7.Text = "{" + string.Join(", ", our_array) + "}";

            StartSort(our_array, this);
        }
    }
}