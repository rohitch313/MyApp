using Microsoft.Maui.ApplicationModel.Communication;
using MyApp.ViewModel;
using System;

namespace MyApp.View.Login;

public partial class BasicDetailView : ContentPage
{
	public BasicDetailView( BasicDetailViewModel basicDetailViewModel)
	{
		InitializeComponent();
        BindingContext = basicDetailViewModel;



        // Populate the list of states
        // Assuming you have a method to get the list of states
    }

   

   
}