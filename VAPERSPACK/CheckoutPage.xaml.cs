using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace VAPERSPACK
{
    public partial class CheckoutPage : ContentPage
    {
        public List<CartItem> CartItems { get; set; } // List of cart items
        public decimal TotalPrice { get; set; } // Total price of cart items

        public CheckoutPage(List<CartItem> cartItems, decimal totalPrice)
        {
            InitializeComponent(); // Links the XAML file to this code-behind

            // Initialize properties
            CartItems = cartItems;
            TotalPrice = totalPrice;

            // Set BindingContext for data binding in XAML
            BindingContext = this;
        }

        // Finalize the order when the "Place Order" button is clicked
        private async void FinalizeOrder_Clicked(object sender, EventArgs e)
        {
            // Check if any required fields are empty
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(AddressEntry.Text) ||
                string.IsNullOrWhiteSpace(PhoneEntry.Text) ||
                string.IsNullOrWhiteSpace(CardNumberEntry.Text) ||
                string.IsNullOrWhiteSpace(ExpiryDateEntry.Text) ||
                string.IsNullOrWhiteSpace(CvcEntry.Text))
            {
                // Display an error if validation fails
                await DisplayAlert("Error", "Please fill in all required fields.", "OK");
                return;
            }

            // Display a confirmation message
            await DisplayAlert("Order Placed", "Your order has been successfully placed!", "OK");

            // Optionally, navigate back or reset fields after placing the order
            await Navigation.PopToRootAsync();
        }
    }

    // CartItem class to represent individual items in the cart
    public class CartItem
    {
        public string ProductName { get; set; } // Name of the product
        public int Quantity { get; set; } // Quantity of the product
        public decimal Price { get; set; } // Price of the product
        public string? Name { get; internal set; }
        public decimal TotalPrice { get; internal set; }
        public string Image { get; internal set; }
    }
}
