using System;


namespace Sorted
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public class MySorter
    {
        public void bubblesort(int[] array, Form1 form)
        {
            DateTime start_time = DateTime.Now;
            int count_s = 0;
            int count_per = 0;

            int temp = 0;
            for (int write = 0; write < array.Length; write++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    count_s++;

                    if (array[sort] > array[sort + 1])
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                        count_per++;
                    }
                }
            }

            DateTime end_time = DateTime.Now;
            TimeSpan d_time = (end_time - start_time);
            double all_secod = d_time.TotalMilliseconds;

            form.textBox8.Text = $"{{{string.Join(", ", array)}}}";

            form.textBox11.Text = count_s.ToString();
            form.textBox12.Text = count_per.ToString();
            form.textBox13.Text = all_secod.ToString();
        }

        public void shakersort(int[] array, Form1 form)
        {
            DateTime start_time = DateTime.Now;
            int count_s = 0;
            int count_per = 0;
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;

                for (var j = i; j < array.Length - i - 1; j++)
                {
                    count_s++;
                    if (array[j] > array[j + 1])
                    {
                        count_per++;
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }


                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    count_s++;
                    if (array[j - 1] > array[j])
                    {
                        count_per++;
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }
            DateTime end_time = DateTime.Now;
            TimeSpan d_time = (end_time - start_time);
            double all_secod = d_time.TotalMilliseconds;


            form.textBox9.Text = "{" + string.Join(", ", array) + "}";

            form.textBox16.Text = count_s.ToString();
            form.textBox15.Text = count_per.ToString();
            form.textBox14.Text = all_secod.ToString();
        }

        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }


        static void SwapG(ref int item1, ref int item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }


        public void gnomesort(int[] array, Form1 form)
        {
            DateTime start_time = DateTime.Now;
            int count_s = 0;
            int count_per = 0;
            var index = 1;
            var nextIndex = index + 1;

            while (index < array.Length)
            {
                count_s++;
                if (array[index - 1] < array[index])
                {
                    count_per++;
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    count_per++;
                    SwapG(ref array[index - 1], ref array[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }
            DateTime end_time = DateTime.Now;
            TimeSpan d_time = (end_time - start_time);
            double all_secod = d_time.TotalMilliseconds;

            form.textBox10.Text = "{" + string.Join(", ", array) + "}";

            form.textBox19.Text = count_s.ToString();
            form.textBox18.Text = count_per.ToString();
            form.textBox17.Text = all_secod.ToString();

        }

    }
}