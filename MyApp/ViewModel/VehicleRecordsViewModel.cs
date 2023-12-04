using CommunityToolkit.Mvvm.ComponentModel;
using MyApp.Model;
using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;


namespace MyApp.ViewModel
{
    public class VehicleRecordsViewModel : ObservableObject
    {
        private IPurchaseVehicleService _purchaseVehicleService;

        public VehicleRecordsViewModel(IPurchaseVehicleService purchaseVehicleService)
        {
            _purchaseVehicleService = purchaseVehicleService;
            LoadVehicleRecord();
        }

        private ObservableCollection<PurchaseVehicleRecordModel> _vehiclesRecord;

        public ObservableCollection<PurchaseVehicleRecordModel> VehiclesRecord
        {
            get => _vehiclesRecord;
            set
            {
                _vehiclesRecord = value;
                OnPropertyChanged(nameof(VehiclesRecord));
            }
        }
        public async Task LoadVehicleRecord()
        {
            try
            {
                var Record = await _purchaseVehicleService.GetVehicleRecord();
                VehiclesRecord = new ObservableCollection<PurchaseVehicleRecordModel>(Record);
                // Handle the payment status as needed (e.g., update UI, process data)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Add methods and logic related to your view here
    }
}
