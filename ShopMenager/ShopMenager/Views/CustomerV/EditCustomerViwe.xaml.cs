using ShopMenager.ViewModels.CustomerVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopMenager.Views.CustomerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCustomerViwe : BasePage<EditCustomerViewModel>
    {
        public EditCustomerViwe()
        {
            InitializeComponent();
        }
    }
}