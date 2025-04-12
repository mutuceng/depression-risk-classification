from fastapi import FastAPI
from fastapi import HTTPException
from pydantic import BaseModel
import joblib
import numpy as np

emp_model = joblib.load('app/lgbm_empmodel.pkl')
std_model = joblib.load('app/lgbm_stdmodel.pkl')

class EmployeePredictRequest(BaseModel):
    gender: int  # 0 veya 1 gibi cinsiyet bilgisi
    age: int  # Yaş bilgisi
    city: int  # Şehir ID'si veya kodu
    profession: int  # Meslek ID'si veya kodu
    work_pressure: float  # İş stresi (örneğin 1.0 ile 5.0 arasında)
    job_satisfaction: float  # İş tatmini (örneğin 1.0 ile 5.0 arasında)
    sleep_duration: int  # Uyku süresi (saat olarak)
    dietary_habits: int  # Diyet alışkanlıkları (örneğin, 1: sağlıklı, 2: sağlıksız)
    degree: float  # Eğitim seviyesi (örneğin, 1.0: Lise, 2.0: Üniversite)
    suicidal_thoughts: int  # İntihar düşüncesi geçmişi (0: Hayır, 1: Evet)
    work_study_hours: float  # Çalışma/okuma saatleri
    financial_stress: float  # Finansal stres (örneğin 1.0 ile 5.0 arasında)
    family_history_mental_illness: int  # Ailede mental hastalık geçmişi (0: Hayır, 1: Evet)


class StudentPredictRequest(BaseModel):
    gender: int  # 0 veya 1 gibi cinsiyet bilgisi
    age: int  # Yaş bilgisi
    city: int  # Şehir ID'si veya kodu
    cgpa: float  # ortalama
    academic_pressure: float  # akamedi stresi (örneğin 1.0 ile 5.0 arasında)
    study_satisfaction: float  # çalışma tatmini (örneğin 1.0 ile 5.0 arasında)
    sleep_duration: int  # Uyku süresi (saat olarak)
    dietary_habits: int  # Diyet alışkanlıkları (örneğin, 1: sağlıklı, 2: sağlıksız)
    degree: float  # Eğitim seviyesi (örneğin, 1.0: Lise, 2.0: Üniversite)
    suicidal_thoughts: int  # İntihar düşüncesi geçmişi (0: Hayır, 1: Evet)
    work_study_hours: float  # Çalışma/okuma saatleri
    financial_stress: float  # Finansal stres (örneğin 1.0 ile 5.0 arasında)
    family_history_mental_illness: int  # Ailede mental hastalık geçmişi (0: Hayır, 1: Evet)


app = FastAPI()

@app.get("/")
def read_root():
    return {"message": "Employee Depression Prediction API"}  

@app.post("/employeepredict")
def predict(request: EmployeePredictRequest):
    try:
        data = np.array([[request.gender, request.age, request.city, request.profession, request.work_pressure, request.job_satisfaction, request.sleep_duration, request.dietary_habits, request.degree, request.suicidal_thoughts, request.work_study_hours, request.financial_stress, request.family_history_mental_illness]])
        prediction = emp_model.predict(data)
        result_map = {0: "Depresyon riski yok", 1: "Depresyon riski var"}
        return {"prediction": result_map[int(prediction[0])]}
    except KeyError:
        raise HTTPException(status_code=400, detail="Invalid input format. 'features' key is missing.")
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))
    

@app.post("/studentpredict")
def predict(request: StudentPredictRequest):
    try:
        data = np.array([[request.gender, request.age, request.city, request.cgpa, request.academic_pressure, request.study_satisfaction, request.sleep_duration, request.dietary_habits, request.suicidal_thoughts, request.work_study_hours, request.financial_stress, request.family_history_mental_illness]])
        prediction = emp_model.predict(data)
        result_map = {0: "Depresyon riski yok", 1: "Depresyon riski var"}
        return {"prediction": result_map[int(prediction[0])]}
    except KeyError:
        raise HTTPException(status_code=400, detail="Invalid input format. 'features' key is missing.")
    except Exception as e:
        raise HTTPException(status_code=500, detail=str(e))