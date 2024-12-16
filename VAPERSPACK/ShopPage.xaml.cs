using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VAPERSPACK
{
    public partial class ShopPage : ContentPage
    {
        // Dictionary to hold cart items with quantity and price
        private Dictionary<string, (int Quantity, decimal Price)> _cart = new Dictionary<string, (int, decimal)>
        {
            { "VapeM8", (0, 330m) },
            { "Elbaf", (0, 400m) },
            { "Aspire", (0, 450m) },
            { "Upends", (0, 500m) }
        };

        public ShopPage()
        {
            InitializeComponent();
            UpdateCartSummary();
        }

        // Method to proceed to checkout
        private async void ProceedToCheckout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(_cart)); // Pass the cart dictionary to CartPage
        }

        // Method to increment quantity for a product
        private void IncrementQuantity_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string productName = button.CommandParameter.ToString();

            if (_cart.ContainsKey(productName))
            {
                var current = _cart[productName];
                _cart[productName] = (current.Quantity + 1, current.Price); // Increase the quantity
                UpdateQuantityLabel(productName, current.Quantity + 1); // Update the label for the specific product
            }

            UpdateCartSummary(); // Update total items and amount
        }

        // Method to decrement quantity for a product
        private void DecrementQuantity_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string productName = button.CommandParameter.ToString();

            if (_cart.ContainsKey(productName) && _cart[productName].Quantity > 0)
            {
                var current = _cart[productName];
                _cart[productName] = (current.Quantity - 1, current.Price); // Decrease the quantity
                UpdateQuantityLabel(productName, current.Quantity - 1); // Update the label for the specific product
            }

            UpdateCartSummary(); // Update total items and amount
        }

        // Method to add item to cart
        private void AddToCart_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string productName = button.CommandParameter.ToString();

            if (_cart.ContainsKey(productName))
            {
                var current = _cart[productName];
                _cart[productName] = (current.Quantity + 1, current.Price); // Increment the quantity
                DisplayAlert("Success", $"{productName} added to cart.", "OK"); // Show confirmation
            }

            UpdateCartSummary(); // Update total items and amount
        }

        // Method to update quantity label on the UI
        private void UpdateQuantityLabel(string productName, int quantity)
        {
            switch (productName)
            {
                case "VapeM8":
                    QuantityLabelVapeM8.Text = quantity.ToString();
                    break;
                case "Elbaf":
                    QuantityLabelElbaf.Text = quantity.ToString();
                    break;
                case "Aspire":
                    QuantityLabelAspire.Text = quantity.ToString();
                    break;
                case "Upends":
                    QuantityLabelUpends.Text = quantity.ToString();
                    break;
            }
        }

        // Method to update the cart summary (total items and total amount)
        private void UpdateCartSummary()
        {
            int totalItems = _cart.Values.Sum(item => item.Quantity);
            decimal totalAmount = _cart.Values.Sum(item => item.Quantity * item.Price);

            TotalItemsLabel.Text = $"Total Items: {totalItems}";
            TotalAmountLabel.Text = $"Total Amount: ₱{totalAmount}";
        }

        // Method to clear the cart
        private void ClearCart_Clicked(object sender, EventArgs e)
        {
            foreach (var key in _cart.Keys.ToList())
            {
                _cart[key] = (0, _cart[key].Price); // Set quantity to 0 for all products
            }

            UpdateCartSummary(); // Update total items and amount
            DisplayAlert("Cart Cleared", "Your cart has been cleared.", "OK");
        }

        // Method to delete a product from the cart
        private void DeleteProduct_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string productName = button.CommandParameter.ToString();

            if (_cart.ContainsKey(productName))
            {
                _cart[productName] = (0, _cart[productName].Price); // Set quantity to 0 for that product
                DisplayAlert("Deleted", $"{productName} removed from the cart.", "OK");
            }

            UpdateCartSummary(); // Update total items and amount
        }
    }
}
