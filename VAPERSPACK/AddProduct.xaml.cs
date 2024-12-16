using Microsoft.Maui.Controls;

namespace VAPERSPACK
{
    public partial class AddProduct : ContentPage
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        // Event handler for product name change
        private void OnProductNameChanged(object sender, EventArgs e)
        {
            string selectedProduct = ProductNamePicker.SelectedItem?.ToString().Trim().ToLower();

            // Update the product image based on the selected product
            switch (selectedProduct)
            {
                case "vape1":
                    ProductImage.Source = "vape1.png";
                    break;
                case "vape2":
                    ProductImage.Source = "vape2.png";
                    break;
                case "vape3":
                    ProductImage.Source = "vape3.png";
                    break;
                case "vape4":
                    ProductImage.Source = "vape4.png";
                    break;
                default:
                    ProductImage.Source = "placeholder.png";  // Default image
                    break;
            }
        }

        // Event handler for product price change
        private void OnProductPriceChanged(object sender, EventArgs e)
        {
            // You can handle any specific actions when the price is changed, if necessary
        }

        // Button click event to add the product
        private void OnAddProductClicked(object sender, EventArgs e)
        {
            // Get selected values from pickers
            string productName = ProductNamePicker.SelectedItem?.ToString() ?? "N/A";
            string productPrice = ProductPricePicker.SelectedItem?.ToString() ?? "N/A";
            string productQuantity = ProductQuantityPicker.SelectedItem?.ToString() ?? "0";  // Default to 0 if no selection

            // Create a new stack layout for the product entry
            var productEntryStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 15,
                Children =
                {
                    new Image
                    {
                        Source = ProductImage.Source,
                        HeightRequest = 100,
                        WidthRequest = 100
                    },
                    new VerticalStackLayout
                    {
                        Spacing = 5,
                        Children =
                        {
                            new Label { Text = $"Name: {productName}", FontSize = 14 },
                            new Label { Text = $"Price: ₱{productPrice}", FontSize = 14 },
                            new Label { Text = $"Quantity: {productQuantity}", FontSize = 14 }
                        }
                    }
                }
            };

            // Add the created product entry to the Product List
            ProductListStackLayout.Children.Add(productEntryStackLayout);

            // Optional: Clear the pickers after adding the product
            ProductNamePicker.SelectedIndex = -1;  // Clear selected product
            ProductPricePicker.SelectedIndex = -1;  // Clear selected price
            ProductQuantityPicker.SelectedIndex = -1; // Clear selected quantity
        }
    }
}
