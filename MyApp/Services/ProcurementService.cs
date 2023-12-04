﻿using MyApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Services
{
    public class ProcurementService : IProcurementService
    {
        private readonly HttpClient _httpClient;
        public ProcurementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ProcurementFilterModel>> GetFilters()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://10.0.2.2:5158/api/Procurement/filter");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ProcurementFilterModel>>(responseBody);
                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }
        }
        public async Task<List<ProcurementDetialModel>> GetAllProcurements()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://10.0.2.2:5158/api/Procurement/Procurement");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var Proucrementfull = JsonConvert.DeserializeObject<List<ProcurementDetialModel>>(responseBody);
                    return Proucrementfull;
                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }
        }

        public async Task<List<ProcurementDetialModel>> GetFilterProcurement(int Id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://10.0.2.2:5158/api/Procurement/Procurement?Id={Id}");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var Procurmentfilter = JsonConvert.DeserializeObject<List<ProcurementDetialModel>>(responseBody);
                    return Procurmentfilter;
                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }
        }
    public async    Task<List<ProcurementClosedModel>> GetClosedProcurements()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://10.0.2.2:5158/api/Procurement/ProcurementClosed");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var Proucrementclosed = JsonConvert.DeserializeObject<List<ProcurementClosedModel>>(responseBody);
                    return Proucrementclosed;
                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }

        }
       public async Task<List<ProcurmentInProcessModel>> GetInprocessProcurements()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://10.0.2.2:5158/api/Procurement/ProcurementStatus");
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var ProucrementInprocess = JsonConvert.DeserializeObject<List<ProcurmentInProcessModel>>(responseBody);
                    return ProucrementInprocess;
                }
                else
                {
                    // Handle non-success status codes
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception($"Exception: {ex.Message}");
            }

        }
    }
}