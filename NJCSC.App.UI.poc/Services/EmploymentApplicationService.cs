using Newtonsoft.Json;
using NJCSC.App.UI.poc.DTO;
using NJCSC.App.UI.poc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NJCSC.App.UI.poc.Services
{
    public class EmploymentApplicationService
    {

        private  readonly HttpClient _httpClient;
        private readonly Uri _baseAddress = new Uri("https://localhost:44313/");


        public EmploymentApplicationService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = _baseAddress;
        }
        public async Task Save(EmpApplicationModel empApplication)
        {

            var json = JsonConvert.SerializeObject(empApplication);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

           
            var result = await _httpClient.PostAsync("/api/EmploymentApplicaton", stringContent);
        } 

        public async Task<IEnumerable<EmploymentApplicatonDTO>> GetAll()
        {
            var empApplications = new List<EmploymentApplicatonDTO>();
           
          
              var  response = _httpClient.GetAsync("/api/EmploymentApplicaton");

           
               
               
            var content = response.Result.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<IEnumerable<EmploymentApplicatonDTO>>(content.Result);

            empApplications = data.ToList();

            return empApplications;
        }

        public async Task<EmploymentApplicatonDTO> GetById(int? id)
        {

            var empApplication = new EmploymentApplicatonDTO();

            var respone = _httpClient.GetAsync($"/api/EmploymentApplicaton/{id}");

            var content = respone.Result.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<EmploymentApplicatonDTO>(content.Result);

            empApplication = data;

            return empApplication;


        }

        public async Task Edit(EmploymentApplicatonDTO employmentApplicaton)
        {
            var json = JsonConvert.SerializeObject(employmentApplicaton);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");


            var result = await _httpClient.PutAsync($"/api/EmploymentApplicaton/{employmentApplicaton.ApplicationId}", stringContent);

        }




        public async Task Delete(EmpApplicationModel empApplication)
        {
            var json = JsonConvert.SerializeObject(empApplication);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync("/api/EmploymentApplicaton", stringContent);
        }
    }
}
