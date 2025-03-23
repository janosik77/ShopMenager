using Xamarin.Forms;
using ShopMenager.Views.CustomerV;
using ShopMenager.Views.CategoryV;
using ShopMenager.Views.DiscountV;
using ShopMenager.Views.EmployeeV;
using ShopMenager.Views.OrderItemsV;
using ShopMenager.Views.OrderV;
using ShopMenager.Views.PaymentsV;
using ShopMenager.Views.PorductV;
using ShopMenager.Views.ReviewV;

namespace ShopMenager
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute(nameof(AddCustomerView), typeof(AddCustomerView));
            Routing.RegisterRoute(nameof(CustomerDetailsView), typeof(CustomerDetailsView));
            Routing.RegisterRoute(nameof(EditCustomerViwe), typeof(EditCustomerViwe));

            Routing.RegisterRoute(nameof(AddCategoryView), typeof(AddCategoryView));
            Routing.RegisterRoute(nameof(EditCategoryView), typeof(EditCategoryView));
            Routing.RegisterRoute(nameof(CategoryDetailView), typeof(CategoryDetailView));

            Routing.RegisterRoute(nameof(AddDiscountView), typeof(AddDiscountView));
            Routing.RegisterRoute(nameof(EditDiscountView), typeof(EditDiscountView));
            Routing.RegisterRoute(nameof(DiscountDetailView), typeof(DiscountDetailView));

            Routing.RegisterRoute(nameof(AddEmployeeView), typeof(AddEmployeeView));
            Routing.RegisterRoute(nameof(EditEmployeeView), typeof(EditEmployeeView));
            Routing.RegisterRoute(nameof(EmployeeDetailsView), typeof(EmployeeDetailsView));

            Routing.RegisterRoute(nameof(AddOrderItemView), typeof(AddOrderItemView));
            Routing.RegisterRoute(nameof(EditOrderItemView), typeof(EditOrderItemView));
            Routing.RegisterRoute(nameof(OrderItemDetailView), typeof(OrderItemDetailView));

            Routing.RegisterRoute(nameof(AddOrderView), typeof(AddOrderView));
            Routing.RegisterRoute(nameof(EditorderView), typeof(EditorderView));
            Routing.RegisterRoute(nameof(OrderDetailView), typeof(OrderDetailView));

            Routing.RegisterRoute(nameof(AddPaymentView), typeof(AddPaymentView));
            Routing.RegisterRoute(nameof(EditPaymentView), typeof(EditPaymentView));
            Routing.RegisterRoute(nameof(PaymentDetailView), typeof(PaymentDetailView));

            Routing.RegisterRoute(nameof(AddProductView), typeof(AddProductView));
            Routing.RegisterRoute(nameof(EditproductView), typeof(EditproductView));
            Routing.RegisterRoute(nameof(productDetailView), typeof(productDetailView));
            
            Routing.RegisterRoute(nameof(AddReviewView), typeof(AddReviewView));
            Routing.RegisterRoute(nameof(EditReviewView), typeof(EditReviewView));
            Routing.RegisterRoute(nameof(ReviewdetailView), typeof(ReviewdetailView));



            InitializeComponent();
        }

    }
}
