using DepressionPredictionUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace DepressionPredictionUI.Controllers
{
    public class PredictStudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PredictStudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Predict(StudentPredictViewModel model)
        {
            var student = new StudentPredictViewModel
            {
                gender = model.gender,
                age = model.age,
                city = model.city,
                cgpa = model.cgpa,
                academic_pressure = model.academic_pressure,
                study_satisfaction = model.study_satisfaction,
                sleep_duration = model.sleep_duration,
                dietary_habits = model.dietary_habits,
                suicidal_thoughts = model.suicidal_thoughts,
                work_study_hours = model.work_study_hours,
                financial_stress = model.financial_stress,
                family_history_mental_illness = model.family_history_mental_illness
            };

            var client = _httpClientFactory.CreateClient();

            var json = JsonConvert.SerializeObject(student);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:8000/studentpredict", content);
            var result = await response.Content.ReadAsStringAsync();
            var predictionResult = JsonConvert.DeserializeObject<StudentPredictionResult>(result);

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

    public class StudentPredictionResult
    {
        public string Prediction { get; set; }
    }
}

