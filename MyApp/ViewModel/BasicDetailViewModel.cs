using CommunityToolkit.Mvvm.ComponentModel;
using MvvmHelpers.Commands;
using MyApp.Model;
using MyApp.View.Login;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MyApp.ViewModel
{
    public partial class BasicDetailViewModel : INotifyPropertyChanged
    {

        private string name;
        private string email;
        private string selectedState;
        private List<string> state;

        public ICommand SubmitCommand { get; }

        // Additional properties for errors
        private string nameErrors;
        private string emailErrors;
        private string stateErrors;

        public string NameErrors
        {
            get { return nameErrors; }
            set
            {
                if (nameErrors != value)
                {
                    nameErrors = value;
                    OnPropertyChanged(nameof(NameErrors));
                }
            }
        }

        public string EmailErrors
        {
            get { return emailErrors; }
            set
            {
                if (emailErrors != value)
                {
                    emailErrors = value;
                    OnPropertyChanged(nameof(EmailErrors));
                }
            }
        }

        public string StateErrors
        {
            get { return stateErrors; }
            set
            {
                if (stateErrors != value)
                {
                    stateErrors = value;
                    OnPropertyChanged(nameof(StateErrors));

                }
            }
        }


        [Required(ErrorMessage = "Name is required.")]
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                    ValidateName();

                }
            }
        }

        private void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                NameErrors = "Name is required.";
            }
            else
            {
                NameErrors = null; // Clear the error if name is provided
            }
        }

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));

                    if (string.IsNullOrEmpty(value))
                    {
                        email = null; // Set email to null when value is empty or null
                    }

                    OnPropertyChanged(nameof(EmailErrors)); // Trigger re-evaluation of email validation
                    ValidateEmail();
                }
            }
        }

        private void ValidateEmail()
        {
            if (string.IsNullOrEmpty(Email))
            {
                EmailErrors = null; // Clear the error if email is empty
            }
            else if (!IsValidEmail(Email))
            {
                EmailErrors = "Invalid email format.";
            }
            else
            {
                EmailErrors = null; // Clear the error if email is provided and valid
            }
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



          [Required(ErrorMessage = "State is required.")]
        public string SelectedState
        {
            get { return selectedState; }
            set
            {
                if (selectedState != value)
                {
                    selectedState = value;
                    OnPropertyChanged(nameof(SelectedState));
                    ValidateSelectedState();
                }
            }
        }

        private void ValidateSelectedState()
        {
            if (string.IsNullOrEmpty(SelectedState))
            {
                StateErrors = "State is required.";
            }
            else
            {
                StateErrors = null; // Clear the error if state is selected
            }
        }
        public List<string> State
        {
            get { return state; }
            set
            {
                if (state != value)
                {
                    state = value;
                    OnPropertyChanged(nameof(State));
                }
            }
        }


    







        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BasicDetailViewModel()
        {
            SubmitCommand = new AsyncCommand(SubmitAsync);
            State = GetStatesList();

        }

        private List<string> GetStatesList()
        {
            return new List<string>
            {
                "Andhra Pradesh",
                "Arunachal Pradesh",
                "Assam",
                "Bihar",
                "Chhattisgarh",
                "Goa",
                "Gujarat",
                "Haryana",
                "Himachal Pradesh",
                "Jharkhand",
                "Karnataka",
                "Kerala",
                "Madhya Pradesh",
                "Maharashtra",
                "Manipur",
                "Meghalaya",
                "Mizoram",
                "Nagaland",
                "Odisha",
                "Punjab",
                "Rajasthan",
                "Sikkim",
                "Tamil Nadu",
                "Telangana",
                "Tripura",
                "Uttar Pradesh",
                "Uttarakhand",
                "West Bengal"
            };
        }


        private void ResetFields()
        {
            Name = string.Empty;
            Email = string.Empty;
            SelectedState = null;
            NameErrors = null;
            EmailErrors = null;
            StateErrors = null;
        }


        private async Task SubmitAsync()
        {
            // Reset error messages
            NameErrors = null;
            EmailErrors = null;
            StateErrors = null;

            var name = Name; // Store the value in a local variable
            var email = Email; // Store the value in a local variable
            var state = SelectedState;

            // Perform validation here
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                foreach (var result in results)
                {
                    foreach (var memberName in result.MemberNames)
                    {
                        Console.WriteLine($"Validation Error for {memberName}: {result.ErrorMessage}");
                        switch (memberName)
                        {
                            case nameof(Name):
                                NameErrors = result.ErrorMessage;
                                break;
                            case nameof(Email):
                                
                                    EmailErrors = result.ErrorMessage;
                                
                                break;
                            case nameof(SelectedState):
                                StateErrors = result.ErrorMessage;
                                break;
                        }
                    }
                }
          
                await Application.Current.MainPage.DisplayAlert("Failed", "Form submitted Failed!", "OK");
                return;
            }

            // Validation passed, you can proceed with the submission logic here

            // Clear fields after successful submission

            ResetFields();
            await Application.Current.MainPage.DisplayAlert("Success", "Form submitted successfully!", "OK");
            await Shell.Current.GoToAsync("//HomePage");
        }




    }

}

    

