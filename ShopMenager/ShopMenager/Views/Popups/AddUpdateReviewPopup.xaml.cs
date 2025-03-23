using ShopMenager.ViewModels.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUpdateReviewPopup : ContentPage
    {
        public AddUpdateReviewPopup(AddCustomerPopupViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;    
        }
    }
}