using Microsoft.Maui.Controls;

namespace VAPERSPACK
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Handle button click to navigate to the shop
        private async void GoToShop_Clicked(object sender, EventArgs e)
        {
            // Navigate to the ShopPage
            await Navigation.PushAsync(new ShopPage());
        }

        private async void AddProduct_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProduct());        }
    }
}
