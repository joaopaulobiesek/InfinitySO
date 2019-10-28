using System.Collections.Generic;
using System.Security.Claims;

namespace InfinitySO.Models.Claims
{
    public static class MainClaim
    {
        public static List<Claim> MainClaims = new List<Claim>()
        {
            new Claim("Home", "1"),
            new Claim("Admin", "1"),
            new Claim("FullAcess", "1"),
            new Claim("MainBoard", "1"), // Cadastro Principal
            new Claim("MainBoardEdit", "2"), // Cadastro Principal
            new Claim("MainBoardDelete", "3"), // Cadastro Principal
            new Claim("Category", "1"), //Adicionar Espa;o do local
            new Claim("CategoryEdit", "2"), //Adicionar Espa;o do local
            new Claim("CategoryDelete", "3"), //Adicionar Espa;o do local
            new Claim("Place", "1"), // Cadastrar Local
            new Claim("PlaceEdit", "2"), // Cadastrar Local
            new Claim("PlaceDelete", "3"), // Cadastrar Local
            new Claim("Company", "1"), // Empresa  
            new Claim("CompanyEdit", "2"), // Empresa  
            new Claim("CompanyDelete", "3"), // Empresa            
            new Claim("Supply", "1"), //Suprimento           
            new Claim("SupplyEdit", "2"), //Suprimento           
            new Claim("SupplyDelete", "3"), //Suprimento
            new Claim("Certificate", "1"),//Certificado
            new Claim("CertificateEdit", "2"),//Certificado
            new Claim("CertificateDelete", "3"),//Certificado
            new Claim("Employee", "1"),//Funcionario
            new Claim("EmployeeEdit", "2"),//Funcionario
            new Claim("EmployeeDelete", "3"),//Funcionario
            new Claim("Journey", "1"), //Jornada trabalhada
            new Claim("JourneyEdit", "2"), //Jornada trabalhada
            new Claim("JourneyDelete", "3"), //Jornada trabalhada
            new Claim("Scale", "1"), // Escala
            new Claim("ScaleEdit", "2"), // Escala
            new Claim("ScaleDelete", "3"), // Escala
            new Claim("TimePoint", "1"), // Bater ponto sem opáo de deletar e editar
            new Claim("Patrimony", "1"), //Patrimonio
            new Claim("PatrimonyEdit", "2"), //Patrimonio
            new Claim("PatrimonyDelete", "3"), //Patrimonio
            new Claim("StudentFinancial", "1"), //Financeiro Estudantil
            new Claim("StudentFinancialEdit", "2"), //Financeiro Estudantil
            new Claim("StudentFinancialDelete", "3"), //Financeiro Estudantil
            new Claim("Student", "1"), // Estudante
            new Claim("StudentEdit", "2"), // Estudante
            new Claim("StudentDelete", "3"), // Estudante
            new Claim("UserDataLogin", "1"), // Cadastrar acesso
            new Claim("UserDataLoginEdit", "2"), // Cadastrar acesso
            new Claim("UserDataLoginDelete", "3") // Cadastrar acesso
            //new Claim("Create", "5"),
            //new Claim("Edit", "5"),
            //new Claim("Delete", "5"),
            //new Claim("Home", "5"),
            //new Claim("Admin", "5"),
            //new Claim("FullAcess", "5"),
            //new Claim("Address", "5"),
            //new Claim("Category", "5"),
            //new Claim("Company", "5"),
            //new Claim("Department", "5"),
            //new Claim("MainBoard", "5"),
            //new Claim("Place", "5"),
            //new Claim("Sector", "5"),           
            //new Claim("Supply", "5"),
            //new Claim("SupplyAdd", "5"),
            //new Claim("SupplyWithdrawal", "5"),
            //new Claim("Certificate", "5"),
            //new Claim("CertificateCourse", "5"),
            //new Claim("CertificateProgrammatic", "5"),
            //new Claim("Employee", "5"),
            //new Claim("Journey", "5"),
            //new Claim("Scale", "5"),
            //new Claim("ScaleFormatting", "5"),
            //new Claim("TimePoint", "5"),
            //new Claim("HistoricPatrimony", "5"),
            //new Claim("Patrimony", "5"),
            //new Claim("Product", "5"),
            //new Claim("BilletValue", "5"),
            //new Claim("Course", "5"),
            //new Claim("Period", "5"),
            //new Claim("Semester", "5"),
            //new Claim("StudentFinancial", "5"),
            //new Claim("Student", "5"),
            //new Claim("UserDataLogin", "5")
        };
    }
}
