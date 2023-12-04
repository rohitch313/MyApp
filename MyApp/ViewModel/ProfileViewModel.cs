using MyApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace MyApp.ViewModel

{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ProfileModel> _profileCollection;

        public ObservableCollection<ProfileModel> ProfileCollection
        {
            get { return _profileCollection; }
            set
            {
                if (_profileCollection != value)
                {
                    _profileCollection = value;
                    OnPropertyChanged(nameof(ProfileCollection));
                }
            }
        }

        public ProfileViewModel()
        {
            // Initialize the ProfileCollection with static data
            ProfileCollection = new ObservableCollection<ProfileModel>
            {
                new ProfileModel
                {
                    ContactNumber = "123-456-7890",
                    Email = "example@email.com",
                    ShopAddress = "123 Main St",
                    ResidenceAddress = "456 Elm St",
                    AlternativeContactNumber = "987-654-3210",
                    Type = "Retail",
                    City = "Sample City",
                    AccountDetails = "Account123",
                    RepaymentAccountDetails = "Repayment456"
                },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
