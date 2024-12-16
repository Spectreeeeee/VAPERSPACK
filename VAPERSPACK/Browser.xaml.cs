using Microsoft.Maui.Controls;
using System;

namespace VAPERSPACK
{
    public partial class Browser : ContentPage
    {
        public Browser()
        {
            InitializeComponent();
        }

        // Handle the "Learn More" button click for each product
        private async void OnProductClicked(object sender, EventArgs e)
        {
            // Get the button that was clicked
            var button = sender as Button;
            if (button == null || button.CommandParameter == null)
                return;

            string productName = button.CommandParameter.ToString();
            await DisplayAlert("Product Details", $"Learn more about {productName}.", "OK");

            // Optionally, navigate to a product details page here
            // await Navigation.PushAsync(new ProductDetailsPage(productName));
        }
    }
}
