# Depression Risk Classification
This project aims to predict individuals' mental health risk based on their inputs.

## Overview
After an extensive data cleaning process, we trained our model using LightGBM Booster and LightGBM Classifier and achieved impressive results:
- **96% accuracy** for employee data.
- **85% accuracy** for student data.
  
## Data Cleaning Experience
The data cleaning process was one of the most challenging yet insightful phases of this project. The dataset, being part of a competition, was heavily "dirty" and required substantial effort to clean and preprocess. This phase greatly improved our understanding of handling real-world datasets and dealing with inconsistencies.

## Deployment Process
To deploy the model, we developed a FastAPI application and ran it inside a Docker container. As part of this process, we wrote a custom Dockerfile to containerize the application, ensuring consistency and portability across different environments.

A simple front-end interface, built with .NET, allows users to interact with the model. While the front-end design is minimal, the focus of this project was on successfully integrating the backend model and deploying it in a containerized setup.

## Workflow:
The user provides input through the web interface.
A POST request is sent to the Python API running in the Docker container.
The API processes the input, runs the prediction model, and returns the results.
The web application displays the results to the user in an intuitive format.

## Technology Stack
Model Training: LightGBMBooster, LGBMClassifier
API Development: FastAPI
Containerization: Docker
Front-End: .NET Framework

## How to Run the Project

Follow these steps to set up and run the project:

### Prerequisites
1. **Install Docker**: [Get Docker here](https://www.docker.com/).
2. **Install .NET SDK**: [Download .NET SDK](https://dotnet.microsoft.com/download).
3. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/depression-risk-classification.git
   cd depression-risk-classification

### Backend (FastAPI + Docker)
Navigate the FastAPI directory
   ```bash
      cd Backend/FastAPI 
 ```
Build the docker image
   ```bash
     docker build -t depression-risk-api .
 ```

Run the docker container
   ```bash
    docker run -d -p 8000:8000 depression-risk-api
 ```

Verify that the API is running by visiting: http://localhost:8000/docs

## Frontend (.NET)
Navigate the DepressionPredictionUI directory
   ```bash
      cd FrontEnd/DepressionPredictionUI 
 ```
Run the application
   ```bash
      dotnet run

 ```

