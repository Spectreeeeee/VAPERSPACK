using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace VAPERSPACK
{
    public partial class CartPage : ContentPage
    {
        private Dictionary<string, (int Quantity, decimal Price)> _cart;

        public CartPage(Dictionary<string, (int Quantity, decimal Price)> cart)
        {
            InitializeComponent();
            _cart = cart;

            DisplayCartItems(); // Populate the cart items dynamically
        }

        // Method to display the cart items dynamically
        private void DisplayCartItems()
        {
            var cartItemsText = new StringBuilder();
            decimal totalAmount = 0;

            foreach (var item in _cart)
            {
                if (item.Value.Quantity > 0)
                {
                    cartItemsText.AppendLine($"{item.Key}: {item.Value.Quantity} x ₱{item.Value.Price}");
                    totalAmount += item.Value.Quantity * item.Value.Price;
                }
            }

            CartItemsLabel.Text = cartItemsText.Length > 0 ? cartItemsText.ToString() : "No items in the cart.";
            TotalAmountLabel.Text = $"Total: ₱{totalAmount}";
        }

        // Method to proceed to payment (you can extend this to actual payment logic)
        private async void ProceedToPayment_Clicked(object sender, EventArgs e)
        {
            // Simulate proceeding to the payment screen
            await DisplayAlert("Proceeding to Payment", "Redirecting to the payment screen...", "OK");
            // Navigate to payment or perform checkout logic here
        }
    }
}
