using ShopMenager.ViewModels.CategoryVM;
using ShopMenager.ViewModels.EmployeeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.EmployeeV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddEmployeeView : ContentPage
	{
		public AddEmployeeView ()
		{
			InitializeComponent ();
            BindingContext = App.Services.GetService<AddEmployeeViewModel>();
        }
	}
}