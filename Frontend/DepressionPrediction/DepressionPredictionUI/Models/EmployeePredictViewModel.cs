namespace DepressionPredictionUI.Models
{
    public class EmployeePredictViewModel
    {
        public int gender { get; set; }  // 0 veya 1 gibi cinsiyet bilgisi
        public int age { get; set; }  // Yaş bilgisi
        public int city { get; set; }  // Şehir ID'si veya kodu
        public int profession { get; set; }  // Meslek ID'si veya kodu
        public float work_pressure { get; set; }  // İş stresi (örneğin 1.0 ile 5.0 arasında)
        public float job_satisfaction { get; set; }  // İş tatmini (örneğin 1.0 ile 5.0 arasında)
        public int sleep_duration { get; set; }  // Uyku süresi (saat olarak)
        public int dietary_habits { get; set; }  // Diyet alışkanlıkları (örneğin, 1: sağlıklı, 2: sağlıksız)
        public float degree { get; set; }  // Eğitim seviyesi (örneğin, 1.0: Lise, 2.0: Üniversite)
        public int suicidal_thoughts { get; set; }  // İntihar düşüncesi geçmişi (0: Hayır, 1: Evet)
        public float work_study_hours { get; set; }  // Çalışma/okuma saatleri
        public float financial_stress { get; set; }  // Finansal stres (örneğin 1.0 ile 5.0 arasında)
        public int family_history_mental_illness { get; set; }  // Ailede mental hastalık geçmişi (0: Hayır, 1: Evet)
    }
}
