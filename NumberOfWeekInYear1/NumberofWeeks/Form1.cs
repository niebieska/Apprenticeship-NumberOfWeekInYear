using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace NumberofWeeks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime iDate;
            iDate = dateTimePicker1.Value;
            Count c = new Count();
            c.NumberOfWeek(iDate);
           
            textBox1.Text= "Numer tygodnia w roku:" +' ' + c.NumberOfWeek(iDate).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void oProgamieToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
            
            public class Count
    {
         
        public int NumberOfWeek(DateTime date)
        {
            int[] NumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int WeekNumber = 0;
            int Substract = WeekDay(date.DayOfWeek.ToString());
            int SumofDays = date.Day - Substract;

            for (int i = 0; i < date.Month - 1; i++)
            {
                SumofDays += NumberOfDays[i];

            }
            WeekNumber = SumofDays / 7;


            if (SumofDays % 7 > 3)
            {
                WeekNumber += 2;
            }
            else
            {
                WeekNumber++;
            }

            if (WeekNumber == 53)
            {
                if (LastThursdayInYear(date.Year) < date.Day && (LastThursdayInYear(date.Year) + 1) != 31) { WeekNumber--; }

            }
            return WeekNumber;
          
        }
        
        public int LastThursdayInYear(int y)
        {
            int LastThursdayNumber = 0;
            int m = 12;
            for (int i = 1; i <= 31; i++)
            {
                if (ActualDayOfWeek(i, m, y) == "Thursday")
                {
                    LastThursdayNumber = i;
                }

            }
            return LastThursdayNumber;
        }

        public string ActualDayOfWeek(int d, int m, int y)
        {
            DateTime date = new DateTime(y, m, d);
            return date.DayOfWeek.ToString();

        }

        
        public int WeekDay(string a)
        {
            int substract = 0;

            string[] DaysNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            
           
                    for (int i = 0; i < 7; i++)
                    {
                        if (a == DaysNames[i]) { substract = i; }

                    }
                
            return substract;
            }
        

    }



}

