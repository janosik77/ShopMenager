using ShopMenager.ViewModels.CustomerVM;
using ShopMenager.ViewModels.PaymentVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.PaymentsV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPaymentView : ContentPage
	{
		public EditPaymentView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<EditPaymentViewModel>();
        }
	}
}