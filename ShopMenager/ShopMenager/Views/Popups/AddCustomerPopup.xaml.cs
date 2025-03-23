using Rg.Plugins.Popup.Pages;
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
    public partial class AddCustomerPopup : PopupPage
    {
        public AddCustomerPopup(AddCustomerPopupViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}