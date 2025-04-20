using Microcharts;
using ShopMenager.Services.ApiService;
using ShopMenager.ViewModels.Abstract;
using SkiaSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ShopMenager.ViewModels
{
    public class HomePageViewModel : BaseViewModel<HomePageDto>
    {
        private readonly IDataStore<HomePageDto> _service;
        public HomePageViewModel(IDataStore<HomePageDto> itemService) : base(itemService)
        {
            _service = itemService;
            Title = "Home";
            LoadCommand = new Command(async () => await LoadAsync());
        }

        #region Properties
        private HomePageDto _dto;
        public HomePageDto HomePageDto
        { 
            get => _dto; 
            set => SetProperty(ref _dto, value);
        }

        private int _totalCustomers;
        public int TotalCustomers
        {
            get => _totalCustomers;
            set => SetProperty(ref _totalCustomers, value);
        }

        private int _pendingOrders;
        public int PendingOrders
        {
            get => _pendingOrders;
            set => SetProperty(ref _pendingOrders, value);
        }

        private int _canceledOrders;
        public int CanceledOrders
        {
            get => _canceledOrders;
            set => SetProperty(ref _canceledOrders, value);
        }

        private int _complitedOrders;
        public int ComplitedOrders
        {
            get => _complitedOrders;
            set => SetProperty(ref _complitedOrders, value);
        }

        private decimal _totalIncome;
        public decimal TotalIncome
        {
            get => _totalIncome;
            set => SetProperty(ref _totalIncome, value);
        }

        private int _totalOrders;
        public int TotalOrders
        {
            get => _totalOrders;
            set => SetProperty(ref _totalOrders, value);
        }

        private Dictionary<string, int> _orderStatusCounts;
        public Dictionary<string, int> OrderStatusCounts
        {
            get => _orderStatusCounts;
            set => SetProperty(ref _orderStatusCounts, value);
        }

        private Dictionary<string, decimal> _paymentStatusSums;
        public Dictionary<string, decimal> PaymentStatusSums
        {
            get => _paymentStatusSums;
            set => SetProperty(ref _paymentStatusSums, value);
        }

        private List<BestCustomer> _topCustomers;
        public List<BestCustomer> TopCustomers
        {
            get => _topCustomers;
            set => SetProperty(ref _topCustomers, value);
        }

        //Charts
        private Chart _ordersStatusChart;
        public Chart OrdersStatusChart
        {
            get => _ordersStatusChart;
            set => SetProperty(ref _ordersStatusChart, value);
        }

        private Chart _paymentsChart;
        public Chart PaymentsChart
        {
            get => _paymentsChart;
            set => SetProperty(ref _paymentsChart, value);
        }

        #endregion

        #region Commands
        public ICommand LoadCommand { get; }
        #endregion

        #region Helpers
        public async Task LoadAsync(bool forceRefresh = true)
        {
            try
            {
                IsBusy = true;

                var dto = (await _service.GetItemsAsync(forceRefresh)).FirstOrDefault();
                HomePageDto = dto;
                TotalCustomers = HomePageDto.TotalCustomers;
                PendingOrders = HomePageDto.PendingOrders;
                CanceledOrders = HomePageDto.CanceledOrders;
                ComplitedOrders = HomePageDto.ComplitedOrders;
                TotalIncome = HomePageDto.TotalIncome;
                OrderStatusCounts = (Dictionary<string,int>)HomePageDto.OrderStatusCounts;
                PaymentStatusSums = (Dictionary<string, decimal>)HomePageDto.PaymentStatusSums;
                TopCustomers = (List<BestCustomer>)HomePageDto.TopCustomers;
                TotalOrders = ComplitedOrders + CanceledOrders + PendingOrders;

                BuildCharts();

            }
            finally
            {
                IsBusy = false;
            }
        }

        private void BuildCharts()
        {
            if (OrderStatusCounts != null)
            {
                var entries = OrderStatusCounts.Select(kv =>
                {
                    SKColor c;
                    switch (kv.Key)
                    {
                        case "Pending":
                            c = SKColor.Parse("#f39c12");
                            break;
                        case "Completed":
                            c = SKColor.Parse("#2ecc71");
                            break;
                        case "Canceled":
                            c = SKColor.Parse("#e74c3c");
                            break;
                        default:
                            c = SKColor.Parse("#7f8c8d"); 
                            break;
                    }
                    return new ChartEntry(kv.Value)
                    {
                        Label = kv.Key,
                        ValueLabel = kv.Value.ToString(),
                        Color = c,
                        TextColor = c,
                        ValueLabelColor = c
                    };
                })
                .ToList();    

                OrdersStatusChart = new DonutChart
                {
                    Entries = entries,                    
                    LabelTextSize = 50,
                    BackgroundColor = SKColor.Parse("#0a0a0a")
                };
                OnPropertyChanged(nameof(OrdersStatusChart));
            }

            if (PaymentStatusSums != null)
            {

                var entries = PaymentStatusSums
                    .Select(kv =>
                    {
                        SKColor c;
                        switch (kv.Key)
                        {
                            case "Pending":
                                c = SKColor.Parse("#f39c12");
                                break;
                            case "Completed":
                                c = SKColor.Parse("#2ecc71");
                                break;
                            case "Failed":
                                c = SKColor.Parse("#e74c3c");
                                break;
                            default:
                                c = SKColor.Parse("#7f8c8d");
                                break;
                        }

                        return new ChartEntry((float)kv.Value)
                        {
                            Label = kv.Key,
                            ValueLabel = kv.Value.ToString(),
                            Color = c,
                            TextColor = c,
                            ValueLabelColor = c
                        };

                    })
                    .ToList();

                PaymentsChart = new BarChart
                {
                    Entries = entries,
                    LabelTextSize = 50,
                    BackgroundColor = SKColor.Parse("#0a0a0a")
                };
                OnPropertyChanged(nameof(PaymentsChart));
            }
        }
        #endregion
    }
}
