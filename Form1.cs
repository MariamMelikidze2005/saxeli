using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form1 : Form
    {
        private ProductManager productManager;
        private Cart cart;

        public Form1()
        {
            InitializeComponent();
            productManager = new ProductManager();
            cart = new Cart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                productManager.LoadProductsFromJson("products.json");
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }

        // Refresh DataGridView with products
        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productManager.Products;
            AddCheckboxColumn();
            InitializeCheckboxes();
        }

        // Add checkbox column to the DataGridView
        private void AddCheckboxColumn()
        {
            if (dataGridView1.Columns["SelectColumn"] == null)
            {
                var checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Select",
                    Name = "SelectColumn",
                    FalseValue = false,
                    TrueValue = true
                };
                dataGridView1.Columns.Insert(0, checkBoxColumn);
            }
        }

        // Initialize all checkboxes to unchecked
        private void InitializeCheckboxes()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["SelectColumn"].Value = false;
            }
        }

        // Add eBook product
        private void addbook_Click(object sender, EventArgs e)
        {
            var ebook = new EBook
            {
                Id = 1,
                Name = "E-book",
                Price = 20,
                Stock = 100,
                Category = "Digital",
                Description = "An amazing e-book on programming",
                FileSizeInMB = 5.5
            };
            productManager.Products.Add(ebook);
            RefreshDataGridView();
        }

        // Add laptop product
        private void addleptop_Click(object sender, EventArgs e)
        {
            var laptop = new Laptop
            {
                Id = 2,
                Name = "Laptop",
                Price = 1000,
                Stock = 10,
                Category = "Physical",
                Description = "High-performance laptop",
                Weight = 2.5,
                Dimensions = "38x25x2 cm"
            };
            productManager.Products.Add(laptop);
            RefreshDataGridView();
        }

        // Add headphones product
        private void addHeadphones_Click(object sender, EventArgs e)
        {
            var headphones = new Headphones
            {
                Id = 3,
                Name = "Headphones",
                Price = 50,
                Stock = 25,
                Category = "Physical",
                Description = "Noise-cancelling headphones",
                Weight = 0.3,
                Dimensions = "20x18x10 cm"
            };
            productManager.Products.Add(headphones);
            RefreshDataGridView();
        }

        // Delete product by ID
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxfordelete.Text, out int productId))
            {
                var productToDelete = productManager.Products.FirstOrDefault(p => p.Id == productId);
                if (productToDelete != null)
                {
                    productManager.Products.Remove(productToDelete);
                    MessageBox.Show($"Product with ID {productId} was deleted successfully.");
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show($"No product found with ID {productId}. Please check the ID and try again.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Product ID.");
            }
        }

        // Calculate and display total price of selected products
        private void sum_Click(object sender, EventArgs e)
        {
            decimal total = 0;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["SelectColumn"] is DataGridViewCheckBoxCell checkBoxCell &&
                        checkBoxCell.Value is bool isChecked && isChecked)
                    {
                        if (row.DataBoundItem is Product product)
                        {
                            total += product.Price;
                        }
                    }
                }

                MessageBox.Show($"Total Price: {total:C}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void buy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buy functionality is not yet implemented.");
        }
    }
}
