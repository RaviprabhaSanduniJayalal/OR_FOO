﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace orfoo
{
    public partial class Order : Form
    {

        private List<Appetizers> appetizers;
        private List<Appetizers> selectedAppetizers;

        public Order(List<Appetizers> appetizers)
        {
            InitializeComponent();
            this.appetizers = appetizers;
            selectedAppetizers = appetizers;
            DisplaySelectedAppetizers(); // Optional: Method to populate the form with the passed data
        }

        public Order()
        {
        }

        private void DisplaySelectedAppetizers()
        {
            foreach (var appetizer in selectedAppetizers)
            {
                // Example: Add each appetizer's details to a ListBox, Label, or any UI element
                Console.WriteLine($"{appetizer.Name}, Quantity: {appetizer.Quantity}, Price: {appetizer.Price:F2}");
            }
        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home form = new Home();
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            this.Hide(); // Hide the current form
            homeForm.Show();
        }

        private void Order_Load(object sender, EventArgs e)
        {


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
