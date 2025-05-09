using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace orfoo
{
    public partial class Appetizers : Form
    {
        public static Appetizers instance;
        private List<string> selectedOrders = new List<string>();

        private Dictionary<string, double> soupPrices = new Dictionary<string, double>()
        {
            { "Vegetable Soup", 250.00},
            { "Chicken Soup", 300.00 },
            { "Beef Soup", 350.00 },
            { "Salad", 150.00 },
            { "Chips and Dips", 100.00 }
        };
        
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Appetizers(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
        
        public Appetizers()
        {
            InitializeComponent();
            instance = this;

        }

        private void Appetizers_Load(object sender, EventArgs e)
        {


            // Set default selection
            comboBox1.SelectedIndex = 0;
        }

        private void panelAp1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            this.Hide(); // Hide the current form
            homeForm.Show();
        }

        private void panelA1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox != null)
            {
                // Check if the entered text is a valid number
                if (!int.TryParse(textBox.Text, out int quantity) || quantity <= 0)
                {
                    // If invalid, show a warning message or highlight the textbox
                    textBox.BackColor = Color.LightCoral; // Highlight the textbox with a red background
                    toolTip1.SetToolTip(textBox, "Please enter a valid quantity (greater than 0).");
                }
                else
                {
                    // If valid, reset the textbox's background color
                    textBox.BackColor = Color.White;
                    toolTip1.RemoveAll();
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {// Get selected soup type and quantity
            string selectedSoup = comboBox1.SelectedItem?.ToString();
            int quantity;
            bool isValidQuantity = int.TryParse(textBoxSoupQuantity.Text, out quantity);

            // Check if the selected soup and quantity are valid
            if (!string.IsNullOrEmpty(selectedSoup) && isValidQuantity && quantity > 0)
            {
                // Calculate total price
                double pricePerSoup = soupPrices[selectedSoup];
                double totalPrice = pricePerSoup * quantity;

                // Display the total price in label10
                labelSoupPrice.Text = $"{totalPrice:F2}";
            }
            else
            {
                // Show error message if input is invalid
                MessageBox.Show("Please select a soup and enter a valid quantity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
             //List<Appetizers> selectedAppetizers = new List<Appetizers>();

             //// Check if "Vegetable Soup" is selected
             //if (orderCheckBox1.Checked && int.TryParse(textBoxSoupQuantity.Text, out int soupQty) && soupQty > 0)
             //{
             //    double soupPrice = double.Parse(labelSoupPrice.Text.Replace("Rs: ", "")); // Parse price from label
             //    selectedAppetizers.Add(new Appetizers("Vegetable Soup", soupQty, soupPrice));
             //}

             //// Check if "Salad" is selected
             //if (orderCheckBox2.Checked && int.TryParse(textBoxSaladQuantity.Text, out int saladQty) && saladQty > 0)
             //{
             //    double saladPrice = double.Parse(labelSaladPrice.Text.Replace("Rs: ", ""));
             //    selectedAppetizers.Add(new Appetizers("Salad", saladQty, saladPrice));
             //}

             //// Check if "Chips and Dips" is selected
             //if (orderCheckBox3.Checked && int.TryParse(textBoxChipsQuantity.Text, out int chipsQty) && chipsQty > 0)
             //{
             //    double chipsPrice = double.Parse(labelChipsPrice.Text.Replace("Rs: ", ""));
             //    selectedAppetizers.Add(new Appetizers("Chips and Dips", chipsQty, chipsPrice));
             //}

             //// Pass selected appetizers to the Order form
             //if (selectedAppetizers.Count > 0)
             //{
             //    Order orderForm = new Order(selectedAppetizers);
             //    this.Hide(); // Hide the current form
             //    orderForm.Show(); // Show the Order form
             //}
             //else
             //{
             //    MessageBox.Show("Please select at least one appetizer.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             //}

            List<Appetizers> selectedAppetizers = new List<Appetizers>();

            // Add selected appetizers to the list as shown in your code
            if (orderCheckBox1.Checked && int.TryParse(textBoxSoupQuantity.Text, out int soupQty) && soupQty > 0)
            {
                double soupPrice = double.Parse(labelSoupPrice.Text.Replace("Rs: ", ""));
                selectedAppetizers.Add(new Appetizers("Vegetable Soup", soupQty, soupPrice));
            }

            if (selectedAppetizers.Count > 0)
            {
                Order orderForm = new Order(selectedAppetizers);
                this.Hide();
                orderForm.Show();
            }
            else
            {
                MessageBox.Show("Please select at least one appetizer.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int quantity;
            if (int.TryParse(textBoxSaladQuantity.Text, out quantity) && quantity > 0)
            {
                // Define the price for Salad (replace with the actual price if needed)
                double SaladPrice = 150.00; // For example, the price of the Salad

                // Calculate total price
                double totalPrice = SaladPrice * quantity;

                // Display the total price in label11
                labelSaladPrice.Text = $"Rs:{totalPrice:F2}";  // Format to 2 decimal places
            }
            else
            {
                // Show an error message if the quantity is invalid
                MessageBox.Show("Please enter a valid quantity greater than 0.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox != null)
            {
                // Check if the entered text is a valid number
                if (!int.TryParse(textBox.Text, out int quantity) || quantity <= 0)
                {
                    // If invalid, show a warning message or highlight the textbox
                    textBox.BackColor = Color.LightCoral; // Highlight the textbox with a red background
                    toolTip1.SetToolTip(textBox, "Please enter a valid quantity (greater than 0).");
                }
                else
                {
                    // If valid, reset the textbox's background color
                    textBox.BackColor = Color.White;
                    toolTip1.RemoveAll(); // Remove the tool tip when the quantity is valid
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxChipsQuantity.Text, out int quantity) && quantity > 0)
            {
                // Price per "Chips and Dips"
                double chipsAndDipsPrice = 100.00; // Adjust this price as needed

                // Calculate total price
                double totalPrice = chipsAndDipsPrice * quantity;

                // Display total price in the cdPrice label
                labelChipsPrice.Text = $"Rs:{totalPrice:F2}"; // Display with two decimal places
            }
            else
            {
                // Show an error message if the quantity is invalid
                MessageBox.Show("Please enter a valid quantity for Chips and Dips.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox != null)
            {
                // Check if the entered text is a valid number (greater than 0)
                if (!int.TryParse(textBox.Text, out int quantity) || quantity <= 0)
                {
                    // If invalid, show a warning message or highlight the textbox
                    textBox.BackColor = Color.LightCoral; // Highlight the textbox with a red background
                    toolTip1.SetToolTip(textBox, "Please enter a valid quantity (greater than 0).");
                }
                else
                {
                    // If valid, reset the textbox's background color
                    textBox.BackColor = Color.White;
                    toolTip1.RemoveAll();
                }
            }
        }
    }
}
