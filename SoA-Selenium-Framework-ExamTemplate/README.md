🐾 PetClinic Automation Framework - Endava Final Exam

📖 Project Overview
This solution provides automated testing for the **Spring PetClinic** application.
It was developed as a final exam project for the **Endava .NET School of Automation**.
The solution is divided into two main projects:
1. **`SeleniumFramework.UiTests`**: using Selenium & Reqnroll.
2. **`SeleniumFramework.ApiTests`**: using RestSharp.

The project covers:
* **Manual Testing:** Test Cases and Bug Reports (**Note:** For the complete Test Cases and detailed Bug Reports, please feel free to contact me. I can provide the full Excel/Word files.).
* **UI Automation:** End-to-end scenarios using Selenium and Reqnroll.
* **API Automation:** Integration tests using RestSharp.

🏗️ Architecture & Design Patterns

Тhe framework follows **Clean Architecture** principles and implements:
* **Page Object Model (POM)**: For separation of concerns.
* **Factory & Builder Patterns**: Using **Bogus** for efficient test data generation.
* **Dependency Injection (DI)**: No static state; fully injectable WebDriver and contexts.
* **BDD-First Approach**: Using **Reqnroll** to bridge the gap between business requirements and implementation.

🚀 How to Run the Tests

### 1. Prerequisites
* **Docker**: The application must be running locally.
  ```bash
  docker run -p 8080:8080 springcommunity/spring-framework-petclinic
  docker run -p 9966:9966 springcommunity/spring-petclinic-rest

UI URL: http://localhost:8080
API Swagger UI: http://localhost:9966/petclinic/swagger-ui.html

### 2. Execution
1. Clone the repository and open the SeleniumFramework.sln in Visual Studio 2022.
2. Build the solution to restore dependencies (Ctrl+Shift+B). 
3. Run test via Test Explorer.

### 3. Generate Allure Report
* Allure Command Line: For generating reports (npm install -g allure).

The solution generates a unified Allure report for both **UI (Selenium)** and **API (RestSharp)** tests.
To view the combined results, follow these steps:
1. Run the Tests
Execute all tests from the **Test Explorer** in Visual Studio or via CLI.
This will generate separate `allure-results` folders in each project's output directory.
2. Aggregate Results
Since the projects are separate, you need to copy the API results into the UI results folder to see them together.
Run the following command in PowerShell:

**Note on Paths:** 
The commands below use paths relative to the Solution Root (where the `.sln` file is located).

```powershell
copy ".\SeleniumFramework.ApiTests\bin\Debug\net8.0\allure-results\*" ".\SeleniumFramework.UiTests\bin\Debug\net8.0\allure-results\"
3.Serve the Report
allure serve ".\SeleniumFramework.UiTests\bin\Debug\net8.0\allure-results"

