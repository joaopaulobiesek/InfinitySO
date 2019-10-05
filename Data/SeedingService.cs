using System.Linq;
using InfinitySO.Models.ModelsAdministration;
using InfinitySO.Models.ModelsEmployee;
using InfinitySO.Models.ModelsStudent;
using InfinitySO.Models.ModelsSystem;

namespace InfinitySO.Data
{
    public class SeedingService
    {
        private readonly ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void Seed()
        {
            if (_context.Department.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new Department { Name = "Administrativo" };
            Department d2 = new Department { Name = "Acadêmico" };
            Department d3 = new Department { Name = "Marketing" };

            Sector sc1 = new Sector { Department = d1, Name = "Direção", Initials = "Dir" };
            Sector sc2 = new Sector { Department = d1, Name = "Financeiro", Initials = "Fin" };
            Sector sc3 = new Sector { Department = d3, Name = "Comercial", Initials = "Com" };
            Sector sc4 = new Sector { Department = d2, Name = "ACO", Initials = "Aco" };
            Sector sc5 = new Sector { Department = d2, Name = "Coordenação", Initials = "Coo" };
            Sector sc6 = new Sector { Department = d2, Name = "Estagio", Initials = "Est" };
            Sector sc7 = new Sector { Department = d2, Name = "Aluno", Initials = "Alu" };
            Sector sc8 = new Sector { Department = d2, Name = "Matricula", Initials = "Mat" };
            Sector sc9 = new Sector { Department = d2, Name = "Pos-Graduação", Initials = "Pos" };
            Sector sc10 = new Sector { Department = d2, Name = "TI", Initials = "Ti" };
            Sector sc11 = new Sector { Department = d2, Name = "Tutor", Initials = "Tut" };
            Sector sc12 = new Sector { Department = d2, Name = "Técnico de Laboratório", Initials = "Lab" };


            Semester sem1 = new Semester { Number = 0, Name = "Semestre" };
            Semester sem2 = new Semester { Number = 1, Name = "1º Semestre" };
            Semester sem3 = new Semester { Number = 2, Name = "2º Semestre" };
            Semester sem4 = new Semester { Number = 3, Name = "3º Semestre" };
            Semester sem5 = new Semester { Number = 4, Name = "4º Semestre" };
            Semester sem6 = new Semester { Number = 5, Name = "5º Semestre" };
            Semester sem7 = new Semester { Number = 6, Name = "6º Semestre" };
            Semester sem8 = new Semester { Number = 7, Name = "7º Semestre" };
            Semester sem9 = new Semester { Number = 8, Name = "8º Semestre" };
            Semester sem10 = new Semester { Number = 9, Name = "9º Semestre" };
            Semester sem11 = new Semester { Number = 10, Name = "10º Semestre" };

            Course cur1 = new Course { Name = "0-CURSO" };
            Course cur2 = new Course { Name = "2º Licenciatura" };
            Course cur3 = new Course { Name = "Administração" };
            Course cur4 = new Course { Name = "Agronomia - Barcharelado" };
            Course cur5 = new Course { Name = "Artes Visuais - Lic." };
            Course cur6 = new Course { Name = "Ciências Biológicas - Lic." };
            Course cur7 = new Course { Name = "Ciências Contábeis" };
            Course cur8 = new Course { Name = "Ciências Econômicas" };
            Course cur9 = new Course { Name = "CST Agronegócio" };
            Course cur10 = new Course { Name = "CST Análise e Desenvolvimento de Sistemas" };
            Course cur11 = new Course { Name = "CST Embelezamento e Imagem Pessoal" };
            Course cur12 = new Course { Name = "CST Empreendedorismo" };
            Course cur13 = new Course { Name = "CST Logística" };
            Course cur14 = new Course { Name = "CST Marketing" };
            Course cur15 = new Course { Name = "CST Marketing Digital" };
            Course cur16 = new Course { Name = "CST Processos Gerencias" };
            Course cur17 = new Course { Name = "CST Segurança do Trabalho" };
            Course cur18 = new Course { Name = "CST Serviços Jurídicos, Cartório e Notas" };
            Course cur19 = new Course { Name = "Gestão Ambiental" };
            Course cur20 = new Course { Name = "Gestão Comercial" };
            Course cur21 = new Course { Name = "Gestão da Segurança Pública" };
            Course cur22 = new Course { Name = "Gestão de Produção Industrial" };
            Course cur23 = new Course { Name = "Gestão de Recursos Humanos" };
            Course cur24 = new Course { Name = "Gestão Financeira" };
            Course cur25 = new Course { Name = "Gestão Hospitalar" };
            Course cur26 = new Course { Name = "Gestão Pública" };
            Course cur27 = new Course { Name = "Educação Fisica - Bacharelado" };
            Course cur28 = new Course { Name = "Educação Fisica - Lic." };
            Course cur29 = new Course { Name = "Enfermagem" };
            Course cur30 = new Course { Name = "Formação Pedagógica" };
            Course cur31 = new Course { Name = "Geografia - Lic." };
            Course cur32 = new Course { Name = "História - Lic." };
            Course cur33 = new Course { Name = "Letras - Lic." };
            Course cur34 = new Course { Name = "Matemática - Lic." };
            Course cur35 = new Course { Name = "Pedagógia - Lic." };
            Course cur36 = new Course { Name = "Serviço Social" };
            Course cur37 = new Course { Name = "Sociologia - Lic." };

            Period per1 = new Period { Semester = sem1, Course = cur1 };
            Period per2 = new Period { Semester = sem2, Course = cur2 };
            Period per3 = new Period { Semester = sem3, Course = cur2 };
            Period per4 = new Period { Semester = sem4, Course = cur2 };
            Period per5 = new Period { Semester = sem2, Course = cur3 };
            Period per6 = new Period { Semester = sem3, Course = cur3 };
            Period per7 = new Period { Semester = sem4, Course = cur3 };
            Period per8 = new Period { Semester = sem5, Course = cur3 };
            Period per9 = new Period { Semester = sem6, Course = cur3 };
            Period per10 = new Period { Semester = sem7, Course = cur3 };
            Period per11 = new Period { Semester = sem8, Course = cur3 };
            Period per12 = new Period { Semester = sem9, Course = cur3 };
            Period per13 = new Period { Semester = sem2, Course = cur4 };
            Period per14 = new Period { Semester = sem3, Course = cur4 };
            Period per15 = new Period { Semester = sem4, Course = cur4 };
            Period per16 = new Period { Semester = sem5, Course = cur4 };
            Period per17 = new Period { Semester = sem6, Course = cur4 };
            Period per18 = new Period { Semester = sem7, Course = cur4 };
            Period per19 = new Period { Semester = sem8, Course = cur4 };
            Period per20 = new Period { Semester = sem9, Course = cur4 };
            Period per21 = new Period { Semester = sem10, Course = cur4 };
            Period per22 = new Period { Semester = sem11, Course = cur4 };
            Period per23 = new Period { Semester = sem2, Course = cur5 };
            Period per24 = new Period { Semester = sem3, Course = cur5 };
            Period per25 = new Period { Semester = sem4, Course = cur5 };
            Period per26 = new Period { Semester = sem5, Course = cur5 };
            Period per27 = new Period { Semester = sem6, Course = cur5 };
            Period per28 = new Period { Semester = sem7, Course = cur5 };
            Period per29 = new Period { Semester = sem8, Course = cur5 };
            Period per30 = new Period { Semester = sem9, Course = cur5 };
            Period per31 = new Period { Semester = sem2, Course = cur6 };
            Period per32 = new Period { Semester = sem3, Course = cur6 };
            Period per33 = new Period { Semester = sem4, Course = cur6 };
            Period per34 = new Period { Semester = sem5, Course = cur6 };
            Period per35 = new Period { Semester = sem6, Course = cur6 };
            Period per36 = new Period { Semester = sem7, Course = cur6 };
            Period per37 = new Period { Semester = sem8, Course = cur6 };
            Period per38 = new Period { Semester = sem9, Course = cur6 };
            Period per39 = new Period { Semester = sem2, Course = cur7 };
            Period per40 = new Period { Semester = sem3, Course = cur7 };
            Period per41 = new Period { Semester = sem4, Course = cur7 };
            Period per42 = new Period { Semester = sem5, Course = cur7 };
            Period per43 = new Period { Semester = sem6, Course = cur7 };
            Period per44 = new Period { Semester = sem7, Course = cur7 };
            Period per45 = new Period { Semester = sem8, Course = cur7 };
            Period per46 = new Period { Semester = sem9, Course = cur7 };
            Period per47 = new Period { Semester = sem2, Course = cur8 };
            Period per48 = new Period { Semester = sem3, Course = cur8 };
            Period per49 = new Period { Semester = sem4, Course = cur8 };
            Period per50 = new Period { Semester = sem5, Course = cur8 };
            Period per51 = new Period { Semester = sem6, Course = cur8 };
            Period per52 = new Period { Semester = sem7, Course = cur8 };
            Period per53 = new Period { Semester = sem8, Course = cur8 };
            Period per54 = new Period { Semester = sem9, Course = cur8 };
            Period per55 = new Period { Semester = sem2, Course = cur9 };
            Period per56 = new Period { Semester = sem3, Course = cur9 };
            Period per57 = new Period { Semester = sem4, Course = cur9 };
            Period per58 = new Period { Semester = sem5, Course = cur9 };
            Period per59 = new Period { Semester = sem6, Course = cur9 };
            Period per60 = new Period { Semester = sem7, Course = cur9 };
            Period per61 = new Period { Semester = sem2, Course = cur10 };
            Period per62 = new Period { Semester = sem3, Course = cur10 };
            Period per63 = new Period { Semester = sem4, Course = cur10 };
            Period per64 = new Period { Semester = sem5, Course = cur10 };
            Period per65 = new Period { Semester = sem6, Course = cur10 };
            Period per66 = new Period { Semester = sem7, Course = cur10 };
            Period per67 = new Period { Semester = sem2, Course = cur11 };
            Period per68 = new Period { Semester = sem3, Course = cur11 };
            Period per69 = new Period { Semester = sem4, Course = cur11 };
            Period per70 = new Period { Semester = sem5, Course = cur11 };
            Period per71 = new Period { Semester = sem6, Course = cur11 };
            Period per72 = new Period { Semester = sem2, Course = cur12 };
            Period per73 = new Period { Semester = sem3, Course = cur12 };
            Period per74 = new Period { Semester = sem4, Course = cur12 };
            Period per75 = new Period { Semester = sem5, Course = cur12 };
            Period per76 = new Period { Semester = sem2, Course = cur13 };
            Period per77 = new Period { Semester = sem3, Course = cur13 };
            Period per78 = new Period { Semester = sem4, Course = cur13 };
            Period per79 = new Period { Semester = sem5, Course = cur13 };
            Period per80 = new Period { Semester = sem2, Course = cur14 };
            Period per81 = new Period { Semester = sem3, Course = cur14 };
            Period per82 = new Period { Semester = sem4, Course = cur14 };
            Period per83 = new Period { Semester = sem5, Course = cur14 };
            Period per84 = new Period { Semester = sem2, Course = cur15 };
            Period per85 = new Period { Semester = sem3, Course = cur15 };
            Period per86 = new Period { Semester = sem4, Course = cur15 };
            Period per87 = new Period { Semester = sem5, Course = cur15 };
            Period per88 = new Period { Semester = sem2, Course = cur16 };
            Period per89 = new Period { Semester = sem3, Course = cur16 };
            Period per90 = new Period { Semester = sem4, Course = cur16 };
            Period per91 = new Period { Semester = sem5, Course = cur16 };
            Period per92 = new Period { Semester = sem2, Course = cur17 };
            Period per93 = new Period { Semester = sem3, Course = cur17 };
            Period per94 = new Period { Semester = sem4, Course = cur17 };
            Period per95 = new Period { Semester = sem5, Course = cur17 };
            Period per96 = new Period { Semester = sem6, Course = cur17 };
            Period per97 = new Period { Semester = sem7, Course = cur17 };
            Period per98 = new Period { Semester = sem2, Course = cur18 };
            Period per99 = new Period { Semester = sem3, Course = cur18 };
            Period per100 = new Period { Semester = sem4, Course = cur18 };
            Period per101 = new Period { Semester = sem5, Course = cur18 };
            Period per102 = new Period { Semester = sem2, Course = cur19 };
            Period per103 = new Period { Semester = sem3, Course = cur19 };
            Period per104 = new Period { Semester = sem4, Course = cur19 };
            Period per105 = new Period { Semester = sem5, Course = cur19 };
            Period per106 = new Period { Semester = sem6, Course = cur19 };
            Period per107 = new Period { Semester = sem7, Course = cur19 };
            Period per108 = new Period { Semester = sem2, Course = cur20 };
            Period per109 = new Period { Semester = sem3, Course = cur20 };
            Period per110 = new Period { Semester = sem4, Course = cur20 };
            Period per111 = new Period { Semester = sem5, Course = cur20 };
            Period per112 = new Period { Semester = sem2, Course = cur21 };
            Period per113 = new Period { Semester = sem3, Course = cur21 };
            Period per114 = new Period { Semester = sem4, Course = cur21 };
            Period per115 = new Period { Semester = sem5, Course = cur21 };
            Period per116 = new Period { Semester = sem2, Course = cur22 };
            Period per117 = new Period { Semester = sem3, Course = cur22 };
            Period per118 = new Period { Semester = sem4, Course = cur22 };
            Period per119 = new Period { Semester = sem5, Course = cur22 };
            Period per120 = new Period { Semester = sem6, Course = cur22 };
            Period per121 = new Period { Semester = sem7, Course = cur22 };
            Period per122 = new Period { Semester = sem2, Course = cur23 };
            Period per123 = new Period { Semester = sem3, Course = cur23 };
            Period per124 = new Period { Semester = sem4, Course = cur23 };
            Period per125 = new Period { Semester = sem5, Course = cur23 };
            Period per126 = new Period { Semester = sem2, Course = cur24 };
            Period per127 = new Period { Semester = sem3, Course = cur24 };
            Period per128 = new Period { Semester = sem4, Course = cur24 };
            Period per129 = new Period { Semester = sem5, Course = cur24 };
            Period per130 = new Period { Semester = sem2, Course = cur25 };
            Period per131 = new Period { Semester = sem3, Course = cur25 };
            Period per132 = new Period { Semester = sem4, Course = cur25 };
            Period per133 = new Period { Semester = sem5, Course = cur25 };
            Period per134 = new Period { Semester = sem6, Course = cur25 };
            Period per135 = new Period { Semester = sem7, Course = cur25 };
            Period per136 = new Period { Semester = sem2, Course = cur26 };
            Period per137 = new Period { Semester = sem3, Course = cur26 };
            Period per138 = new Period { Semester = sem4, Course = cur26 };
            Period per139 = new Period { Semester = sem5, Course = cur26 };
            Period per140 = new Period { Semester = sem2, Course = cur27 };
            Period per141 = new Period { Semester = sem3, Course = cur27 };
            Period per142 = new Period { Semester = sem4, Course = cur27 };
            Period per143 = new Period { Semester = sem5, Course = cur27 };
            Period per144 = new Period { Semester = sem6, Course = cur27 };
            Period per145 = new Period { Semester = sem7, Course = cur27 };
            Period per146 = new Period { Semester = sem8, Course = cur27 };
            Period per147 = new Period { Semester = sem9, Course = cur27 };
            Period per148 = new Period { Semester = sem2, Course = cur28 };
            Period per149 = new Period { Semester = sem3, Course = cur28 };
            Period per150 = new Period { Semester = sem4, Course = cur28 };
            Period per151 = new Period { Semester = sem5, Course = cur28 };
            Period per152 = new Period { Semester = sem6, Course = cur28 };
            Period per153 = new Period { Semester = sem7, Course = cur28 };
            Period per154 = new Period { Semester = sem8, Course = cur28 };
            Period per155 = new Period { Semester = sem9, Course = cur28 };
            Period per156 = new Period { Semester = sem2, Course = cur29 };
            Period per157 = new Period { Semester = sem3, Course = cur29 };
            Period per158 = new Period { Semester = sem4, Course = cur29 };
            Period per159 = new Period { Semester = sem5, Course = cur29 };
            Period per160 = new Period { Semester = sem6, Course = cur29 };
            Period per161 = new Period { Semester = sem7, Course = cur29 };
            Period per162 = new Period { Semester = sem8, Course = cur29 };
            Period per163 = new Period { Semester = sem9, Course = cur29 };
            Period per164 = new Period { Semester = sem10, Course = cur29 };
            Period per165 = new Period { Semester = sem11, Course = cur29 };
            Period per166 = new Period { Semester = sem2, Course = cur30 };
            Period per167 = new Period { Semester = sem3, Course = cur30 };
            Period per168 = new Period { Semester = sem2, Course = cur31 };
            Period per169 = new Period { Semester = sem3, Course = cur31 };
            Period per170 = new Period { Semester = sem4, Course = cur31 };
            Period per171 = new Period { Semester = sem5, Course = cur31 };
            Period per172 = new Period { Semester = sem6, Course = cur31 };
            Period per173 = new Period { Semester = sem7, Course = cur31 };
            Period per174 = new Period { Semester = sem8, Course = cur31 };
            Period per175 = new Period { Semester = sem9, Course = cur31 };
            Period per176 = new Period { Semester = sem2, Course = cur32 };
            Period per177 = new Period { Semester = sem3, Course = cur32 };
            Period per178 = new Period { Semester = sem4, Course = cur32 };
            Period per179 = new Period { Semester = sem5, Course = cur32 };
            Period per180 = new Period { Semester = sem6, Course = cur32 };
            Period per181 = new Period { Semester = sem7, Course = cur32 };
            Period per182 = new Period { Semester = sem8, Course = cur32 };
            Period per183 = new Period { Semester = sem9, Course = cur32 };
            Period per184 = new Period { Semester = sem2, Course = cur33 };
            Period per185 = new Period { Semester = sem3, Course = cur33 };
            Period per186 = new Period { Semester = sem4, Course = cur33 };
            Period per187 = new Period { Semester = sem5, Course = cur33 };
            Period per188 = new Period { Semester = sem6, Course = cur33 };
            Period per189 = new Period { Semester = sem7, Course = cur33 };
            Period per190 = new Period { Semester = sem8, Course = cur33 };
            Period per191 = new Period { Semester = sem9, Course = cur33 };
            Period per192 = new Period { Semester = sem2, Course = cur34 };
            Period per193 = new Period { Semester = sem3, Course = cur34 };
            Period per194 = new Period { Semester = sem4, Course = cur34 };
            Period per195 = new Period { Semester = sem5, Course = cur34 };
            Period per196 = new Period { Semester = sem6, Course = cur34 };
            Period per197 = new Period { Semester = sem7, Course = cur34 };
            Period per198 = new Period { Semester = sem8, Course = cur34 };
            Period per199 = new Period { Semester = sem9, Course = cur34 };
            Period per200 = new Period { Semester = sem2, Course = cur35 };
            Period per201 = new Period { Semester = sem3, Course = cur35 };
            Period per202 = new Period { Semester = sem4, Course = cur35 };
            Period per203 = new Period { Semester = sem5, Course = cur35 };
            Period per204 = new Period { Semester = sem6, Course = cur35 };
            Period per205 = new Period { Semester = sem7, Course = cur35 };
            Period per206 = new Period { Semester = sem8, Course = cur35 };
            Period per207 = new Period { Semester = sem9, Course = cur35 };
            Period per208 = new Period { Semester = sem2, Course = cur36 };
            Period per209 = new Period { Semester = sem3, Course = cur36 };
            Period per210 = new Period { Semester = sem4, Course = cur36 };
            Period per211 = new Period { Semester = sem5, Course = cur36 };
            Period per212 = new Period { Semester = sem6, Course = cur36 };
            Period per213 = new Period { Semester = sem7, Course = cur36 };
            Period per214 = new Period { Semester = sem8, Course = cur36 };
            Period per215 = new Period { Semester = sem9, Course = cur36 };
            Period per216 = new Period { Semester = sem2, Course = cur37 };
            Period per217 = new Period { Semester = sem3, Course = cur37 };
            Period per218 = new Period { Semester = sem4, Course = cur37 };
            Period per219 = new Period { Semester = sem5, Course = cur37 };
            Period per220 = new Period { Semester = sem6, Course = cur37 };
            Period per221 = new Period { Semester = sem7, Course = cur37 };
            Period per222 = new Period { Semester = sem8, Course = cur37 };
            Period per223 = new Period { Semester = sem9, Course = cur37 };

            Journey j1 = new Journey { Name = "Folga", Duration = "00:00" };
            Journey j2 = new Journey { Name = "Horario Comercial", Duration = "08:00", Input1 = "08:00", Input2 = "14:00", Output1 = "12:00", Output2 = "18:00" };
            Journey j3 = new Journey { Name = "Horario Sabado", Duration = "04:00", Input1 = "08:00", Output1 = "12:00" };

            Scale s1 = new Scale { Name = "Escala 5x2", SundayJourney = j1, MondayJourney = j2, TuesdayJourney = j2, WednesdayJourney = j2, ThursdayJourney = j2, FridayJourney = j2, SaturdayJourney = j1 };

            SystemController sys4 = new SystemController { Name = "Endereço", NameController = "AdministrationAddress", NameClaim = "Address", ValueClaim = 5, IsCheck = false };
            SystemController sys5 = new SystemController { Name = "Categoria", NameController = "AdministrationCategory", NameClaim = "Category", ValueClaim = 5, IsCheck = false };
            SystemController sys6 = new SystemController { Name = "Empresa", NameController = "AdministrationCompany", NameClaim = "Company", ValueClaim = 5, IsCheck = false };
            SystemController sys7 = new SystemController { Name = "Departamento", NameController = "AdministrationDepartment", NameClaim = "Department", ValueClaim = 5, IsCheck = false };
            SystemController sys8 = new SystemController { Name = "Cadastro principal", NameController = "AdministrationMainBoard", NameClaim = "MainBoard", ValueClaim = 5, IsCheck = false };
            SystemController sys9 = new SystemController { Name = "Lugar", NameController = "AdministrationPlace", NameClaim = "Place", ValueClaim = 5, IsCheck = false };
            SystemController sys10 = new SystemController { Name = "Setor", NameController = "AdministrationSector", NameClaim = "Sector", ValueClaim = 5, IsCheck = false };
            SystemController sys11 = new SystemController { Name = "Funcionário", NameController = "EmployeeEmployee", NameClaim = "Employee", ValueClaim = 5, IsCheck = false };
            SystemController sys12 = new SystemController { Name = "Jornada", NameController = "EmployeeJourney", NameClaim = "Journey", ValueClaim = 5, IsCheck = false };
            SystemController sys13 = new SystemController { Name = "Escala", NameController = "EmployeeScale", NameClaim = "Scale", ValueClaim = 5, IsCheck = false };
            SystemController sys14 = new SystemController { Name = "Ponto eletrônico", NameController = "EmployeeTimePoint", NameClaim = "TimePoint", ValueClaim = 5, IsCheck = false };
            SystemController sys15 = new SystemController { Name = "SubCategoria", NameController = "PatrimonySubCategory", NameClaim = "SubCategory", ValueClaim = 5, IsCheck = false };
            SystemController sys16 = new SystemController { Name = "Serial Patrimônio", NameController = "PatrimonyPatrimonyKey", NameClaim = "PatrimonyKey", ValueClaim = 5, IsCheck = false };
            SystemController sys17 = new SystemController { Name = "Descrição Serial Patrimônio", NameController = "PatrimonyPatrimonyKeyDescription", NameClaim = "PatrimonyKeyDescription", ValueClaim = 5, IsCheck = false };
            SystemController sys18 = new SystemController { Name = "Patrimônio", NameController = "PatrimonyPatrimony", NameClaim = "Patrimony", ValueClaim = 5, IsCheck = false };
            SystemController sys19 = new SystemController { Name = "Valor Boleto", NameController = "StudentBilletValue", NameClaim = "BilletValue", ValueClaim = 5, IsCheck = false };
            SystemController sys20 = new SystemController { Name = "Curso", NameController = "StudentCourse", NameClaim = "Course", ValueClaim = 5, IsCheck = false };
            SystemController sys21 = new SystemController { Name = "Período", NameController = "StudentPeriod", NameClaim = "Period", ValueClaim = 5, IsCheck = false };
            SystemController sys22 = new SystemController { Name = "Semestre", NameController = "StudentSemester", NameClaim = "Semester", ValueClaim = 5, IsCheck = false };
            SystemController sys23 = new SystemController { Name = "Financeiro Estudantil", NameController = "StudentStudentFinancial", NameClaim = "StudentFinancial", ValueClaim = 5, IsCheck = false };
            SystemController sys24 = new SystemController { Name = "Estudante", NameController = "StudentStudent", NameClaim = "Student", ValueClaim = 5, IsCheck = false };
            SystemController sys25 = new SystemController { Name = "Usuário Log-in", NameController = "UserDataLoginUserDataLogin", NameClaim = "UserDataLogin", ValueClaim = 5, IsCheck = false };

            SystemSubController sub4 = new SystemSubController { SystemController = sys4, Name = "Criar", NameSubController = "AdministrationAddressCreate", NameClaim = "AddressCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub5 = new SystemSubController { SystemController = sys4, Name = "Editar", NameSubController = "AdministrationAddressEdit", NameClaim = "AddressEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub6 = new SystemSubController { SystemController = sys4, Name = "Deletar", NameSubController = "AdministrationAddressDelete", NameClaim = "AddressDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub7 = new SystemSubController { SystemController = sys5, Name = "Criar", NameSubController = "AdministrationCategoryCreate", NameClaim = "CategoryCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub8 = new SystemSubController { SystemController = sys5, Name = "Editar", NameSubController = "AdministrationCategoryEdit", NameClaim = "CategoryEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub9 = new SystemSubController { SystemController = sys5, Name = "Deletar", NameSubController = "AdministrationCategoryDelete", NameClaim = "CategoryDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub10 = new SystemSubController { SystemController = sys6, Name = "Criar", NameSubController = "AdministrationCompanyCreate", NameClaim = "CompanyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub11 = new SystemSubController { SystemController = sys6, Name = "Editar", NameSubController = "AdministrationCompanyEdit", NameClaim = "CompanyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub12 = new SystemSubController { SystemController = sys6, Name = "Deletar", NameSubController = "AdministrationCompanyDelete", NameClaim = "CompanyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub13 = new SystemSubController { SystemController = sys7, Name = "Criar", NameSubController = "AdministrationDepartmentCreate", NameClaim = "DepartmentCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub14 = new SystemSubController { SystemController = sys7, Name = "Editar", NameSubController = "AdministrationDepartmentEdit", NameClaim = "DepartmentEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub15 = new SystemSubController { SystemController = sys7, Name = "Deletar", NameSubController = "AdministrationDepartmentDelete", NameClaim = "DepartmentDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub16 = new SystemSubController { SystemController = sys8, Name = "Criar", NameSubController = "AdministrationMainBoardCreate", NameClaim = "MainBoardCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub17 = new SystemSubController { SystemController = sys8, Name = "Editar", NameSubController = "AdministrationMainBoardEdit", NameClaim = "MainBoardEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub18 = new SystemSubController { SystemController = sys8, Name = "Deletar", NameSubController = "AdministrationMainBoardDelete", NameClaim = "MainBoardDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub19 = new SystemSubController { SystemController = sys9, Name = "Criar", NameSubController = "AdministrationPlaceCreate", NameClaim = "PlaceCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub20 = new SystemSubController { SystemController = sys9, Name = "Editar", NameSubController = "AdministrationPlaceEdit", NameClaim = "PlaceEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub21 = new SystemSubController { SystemController = sys9, Name = "Deletar", NameSubController = "AdministrationPlaceDelete", NameClaim = "PlaceDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub22 = new SystemSubController { SystemController = sys10, Name = "Criar", NameSubController = "AdministrationSectorCreate", NameClaim = "SectorCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub23 = new SystemSubController { SystemController = sys10, Name = "Editar", NameSubController = "AdministrationSectorEdit", NameClaim = "SectorEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub24 = new SystemSubController { SystemController = sys10, Name = "Deletar", NameSubController = "AdministrationSectorDelete", NameClaim = "SectorDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub25 = new SystemSubController { SystemController = sys11, Name = "Criar", NameSubController = "EmployeeEmployeeCreate", NameClaim = "EmployeeCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub26 = new SystemSubController { SystemController = sys11, Name = "Editar", NameSubController = "EmployeeEmployeeEdit", NameClaim = "EmployeeEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub27 = new SystemSubController { SystemController = sys11, Name = "Deletar", NameSubController = "EmployeeEmployeeDelete", NameClaim = "EmployeeDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub28 = new SystemSubController { SystemController = sys12, Name = "Criar", NameSubController = "EmployeeJourneyCreate", NameClaim = "JourneyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub29 = new SystemSubController { SystemController = sys12, Name = "Editar", NameSubController = "EmployeeJourneyEdit", NameClaim = "JourneyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub30 = new SystemSubController { SystemController = sys12, Name = "Deletar", NameSubController = "EmployeeJourneyDelete", NameClaim = "JourneyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub31 = new SystemSubController { SystemController = sys13, Name = "Criar", NameSubController = "EmployeeScaleCreate", NameClaim = "ScaleCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub32 = new SystemSubController { SystemController = sys13, Name = "Editar", NameSubController = "EmployeeScaleEdit", NameClaim = "ScaleEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub33 = new SystemSubController { SystemController = sys13, Name = "Deletar", NameSubController = "EmployeeScaleDelete", NameClaim = "ScaleDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub34 = new SystemSubController { SystemController = sys14, Name = "Criar", NameSubController = "EmployeeTimePointCreate", NameClaim = "TimePointCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub35 = new SystemSubController { SystemController = sys14, Name = "Editar", NameSubController = "EmployeeTimePointEdit", NameClaim = "TimePointEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub36 = new SystemSubController { SystemController = sys14, Name = "Deletar", NameSubController = "EmployeeTimePointDelete", NameClaim = "TimePointDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub37 = new SystemSubController { SystemController = sys15, Name = "Criar", NameSubController = "PatrimonySubCategoryCreate", NameClaim = "SubCategoryCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub38 = new SystemSubController { SystemController = sys15, Name = "Editar", NameSubController = "PatrimonySubCategoryEdit", NameClaim = "SubCategoryEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub39 = new SystemSubController { SystemController = sys15, Name = "Deletar", NameSubController = "PatrimonySubCategoryDelete", NameClaim = "SubCategoryDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub40 = new SystemSubController { SystemController = sys16, Name = "Criar", NameSubController = "PatrimonyPatrimonyKeyCreate", NameClaim = "PatrimonyKeyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub41 = new SystemSubController { SystemController = sys16, Name = "Editar", NameSubController = "PatrimonyPatrimonyKeyEdit", NameClaim = "PatrimonyKeyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub42 = new SystemSubController { SystemController = sys16, Name = "Deletar", NameSubController = "PatrimonyPatrimonyKeyDelete", NameClaim = "PatrimonyKeyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub43 = new SystemSubController { SystemController = sys17, Name = "Criar", NameSubController = "PatrimonyPatrimonyKeyDescriptionCreate", NameClaim = "PatrimonyKeyDescriptionCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub44 = new SystemSubController { SystemController = sys17, Name = "Editar", NameSubController = "PatrimonyPatrimonyKeyDescriptionEdit", NameClaim = "PatrimonyKeyDescriptionEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub45 = new SystemSubController { SystemController = sys17, Name = "Deletar", NameSubController = "PatrimonyPatrimonyKeyDescriptionDelete", NameClaim = "PatrimonyKeyDescriptionDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub46 = new SystemSubController { SystemController = sys18, Name = "Criar", NameSubController = "PatrimonyPatrimonyCreate", NameClaim = "PatrimonyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub47 = new SystemSubController { SystemController = sys18, Name = "Editar", NameSubController = "PatrimonyPatrimonyEdit", NameClaim = "PatrimonyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub48 = new SystemSubController { SystemController = sys18, Name = "Deletar", NameSubController = "PatrimonyPatrimonyDelete", NameClaim = "PatrimonyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub49 = new SystemSubController { SystemController = sys19, Name = "Criar", NameSubController = "StudentBilletValueCreate", NameClaim = "BilletValueCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub50 = new SystemSubController { SystemController = sys19, Name = "Editar", NameSubController = "StudentBilletValueEdit", NameClaim = "BilletValueEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub51 = new SystemSubController { SystemController = sys19, Name = "Deletar", NameSubController = "StudentBilletValueDelete", NameClaim = "BilletValueDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub52 = new SystemSubController { SystemController = sys20, Name = "Criar", NameSubController = "StudentCourseCreate", NameClaim = "CourseCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub53 = new SystemSubController { SystemController = sys20, Name = "Editar", NameSubController = "StudentCourseEdit", NameClaim = "CourseEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub54 = new SystemSubController { SystemController = sys20, Name = "Deletar", NameSubController = "StudentCourseDelete", NameClaim = "CourseDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub55 = new SystemSubController { SystemController = sys21, Name = "Criar", NameSubController = "StudentPeriodCreate", NameClaim = "PeriodCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub56 = new SystemSubController { SystemController = sys21, Name = "Editar", NameSubController = "StudentPeriodEdit", NameClaim = "PeriodEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub57 = new SystemSubController { SystemController = sys21, Name = "Deletar", NameSubController = "StudentPeriodDelete", NameClaim = "PeriodDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub58 = new SystemSubController { SystemController = sys22, Name = "Criar", NameSubController = "StudentSemesterCreate", NameClaim = "SemesterCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub59 = new SystemSubController { SystemController = sys22, Name = "Editar", NameSubController = "StudentSemesterEdit", NameClaim = "SemesterEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub60 = new SystemSubController { SystemController = sys22, Name = "Deletar", NameSubController = "StudentSemesterDelete", NameClaim = "SemesterDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub61 = new SystemSubController { SystemController = sys23, Name = "Criar", NameSubController = "StudentStudentFinancialCreate", NameClaim = "StudentFinancialCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub62 = new SystemSubController { SystemController = sys23, Name = "Editar", NameSubController = "StudentStudentFinancialEdit", NameClaim = "StudentFinancialEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub63 = new SystemSubController { SystemController = sys23, Name = "Deletar", NameSubController = "StudentStudentFinancialDelete", NameClaim = "StudentFinancialDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub64 = new SystemSubController { SystemController = sys24, Name = "Criar", NameSubController = "StudentStudentCreate", NameClaim = "StudentCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub65 = new SystemSubController { SystemController = sys24, Name = "Editar", NameSubController = "StudentStudentEdit", NameClaim = "StudentEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub66 = new SystemSubController { SystemController = sys24, Name = "Deletar", NameSubController = "StudentStudentDelete", NameClaim = "StudentDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub67 = new SystemSubController { SystemController = sys25, Name = "Criar", NameSubController = "UserDataLoginUserDataLoginCreate", NameClaim = "UserDataLoginCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub68 = new SystemSubController { SystemController = sys25, Name = "Editar", NameSubController = "UserDataLoginUserDataLoginEdit", NameClaim = "UserDataLoginEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub69 = new SystemSubController { SystemController = sys25, Name = "Deletar", NameSubController = "UserDataLoginUserDataLoginDelete", NameClaim = "UserDataLoginDelete", ValueClaim = 5, IsCheck = false };

            await _context.SystemController.AddRangeAsync(sys4, sys5, sys6, sys7, sys8, sys9, sys10, sys11, sys12, sys13, sys14, sys15, sys16, sys17, sys19, sys20, sys21, sys22, sys23, sys24, sys25);

            await _context.SystemSubController.AddRangeAsync(sub4, sub5, sub6, sub7, sub8, sub9, sub10, sub11, sub12, sub13, sub14, sub15, sub16, sub17, sub18, sub19, sub20, sub21, sub22, sub23, sub24, sub25, sub26,
                                                       sub27, sub28, sub29, sub30, sub31, sub32, sub33, sub34, sub35, sub36, sub37, sub38, sub39, sub40, sub41, sub42, sub43, sub44, sub45, sub46, sub47, sub48,
                                                       sub49, sub50, sub51, sub52, sub53, sub54, sub55, sub56, sub57, sub58, sub59, sub60, sub61, sub62, sub63, sub64, sub65, sub66, sub67, sub68, sub69);

            await _context.Department.AddRangeAsync(d1, d2, d3);

            await _context.Sector.AddRangeAsync(sc1, sc2, sc3, sc4, sc5, sc6, sc7, sc8, sc9, sc10, sc11, sc12);

            await _context.Journey.AddRangeAsync(j1, j2, j3);

            await _context.Scale.AddAsync(s1);

            await _context.Semester.AddRangeAsync(sem1, sem2, sem3, sem4, sem5, sem6, sem7, sem8, sem9, sem10, sem11);

            await _context.Course.AddRangeAsync(cur1, cur2, cur3, cur4, cur5, cur6, cur7, cur8, cur9, cur10, cur11, cur12, cur13, cur14, cur15, cur16, cur17, cur18, cur19,
                                     cur20, cur21, cur22, cur23, cur24, cur25, cur26, cur27, cur28, cur29, cur30, cur31, cur32, cur33, cur34, cur35, cur36, cur37);

            await _context.Period.AddRangeAsync(per1, per2, per3, per4, per5, per6, per7, per8, per9, per10, per11, per12, per13, per14, per15, per16, per17, per18, per19,
                                     per20, per21, per22, per23, per24, per25, per26, per27, per28, per29, per30, per31, per32, per33, per34, per35, per36, per37,
                                     per38, per39, per40, per41, per42, per43, per44, per45, per46, per47, per48, per49, per50, per51, per52, per53, per54, per55,
                                     per56, per57, per58, per59, per60, per61, per62, per63, per64, per65, per66, per67, per68, per69, per70, per71, per72, per73,
                                     per74, per75, per76, per77, per78, per79, per80, per81, per82, per83, per84, per85, per86, per87, per88, per89, per90, per91,
                                     per92, per93, per94, per95, per96, per97, per98, per99, per100, per101, per102, per103, per104, per105, per106, per107, per108,
                                     per109, per110, per111, per112, per113, per114, per115, per116, per117, per118, per119, per120, per121, per122, per123, per124,
                                     per125, per126, per127, per128, per129, per130, per131, per132, per133, per134, per135, per136, per137, per138, per139, per140,
                                     per141, per142, per143, per144, per145, per146, per147, per148, per149, per150, per151, per152, per153, per154, per155, per156,
                                     per157, per158, per159, per160, per161, per162, per163, per164, per165, per166, per167, per168, per169, per170, per171, per172,
                                     per173, per174, per175, per176, per177, per178, per179, per180, per181, per182, per183, per184, per185, per186, per187, per188,
                                     per189, per190, per191, per192, per193, per194, per195, per196, per197, per198, per199, per200, per201, per202, per203, per204,
                                     per205, per206, per207, per208, per209, per210, per211, per212, per213, per214, per215, per216, per217, per218, per219, per220,
                                     per221, per222, per223);

            await _context.SaveChangesAsync();
        }
    }
}