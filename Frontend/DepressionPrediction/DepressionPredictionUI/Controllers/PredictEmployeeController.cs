using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DepressionPredictionUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DepressionPredictionUI.Controllers
{
    public class PredictEmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PredictEmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Predict(EmployeePredictViewModel model)
        {
            var student = new EmployeePredictViewModel
            {
                gender = model.gender,
                age = model.age,
                city = model.city,
                profession = model.profession,
                work_pressure = model.work_pressure,
                job_satisfaction = model.job_satisfaction,
                sleep_duration = model.sleep_duration,
                dietary_habits = model.dietary_habits,
                degree = model.degree,
                suicidal_thoughts = model.suicidal_thoughts,
                work_study_hours = model.work_study_hours,
                financial_stress = model.financial_stress,
                family_history_mental_illness = model.family_history_mental_illness
            };

            var client = _httpClientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(student);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:8000/employeepredict", content);
            var result = await response.Content.ReadAsStringAsync();
            var predictionResult = JsonConvert.DeserializeObject<EmployeePredictionResult>(result);

            if (predictionResult.Prediction == "Depresyon riski var")
            {
                return RedirectToAction("Index", "Depression");
            }
            else
            {
                return RedirectToAction("Index", "NoDepression");
            }
        }
    }

    public class EmployeePredictionResult
    {
        public string Prediction { get; set; }
    }
}
