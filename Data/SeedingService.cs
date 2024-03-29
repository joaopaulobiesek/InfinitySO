﻿using System.Linq;
using System.Threading.Tasks;
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

        public async Task Seed()
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
            Course cur19 = new Course { Name = "CST Gestão Ambiental" };
            Course cur20 = new Course { Name = "CST Gestão Comercial" };
            Course cur21 = new Course { Name = "CST Gestão da Segurança Pública" };
            Course cur22 = new Course { Name = "CST Gestão de Produção Industrial" };
            Course cur23 = new Course { Name = "CST Gestão de Recursos Humanos" };
            Course cur24 = new Course { Name = "CST Gestão Financeira" };
            Course cur25 = new Course { Name = "CST Gestão Hospitalar" };
            Course cur26 = new Course { Name = "CST Gestão Pública" };
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
            Course cur38 = new Course { Name = "CST em Comércio Exterior" };
            Course cur39 = new Course { Name = "CST em Gestão de Turismo" };
            Course cur40 = new Course { Name = "Engenharia Civil" };
            Course cur41 = new Course { Name = "Engenharia Computação" };
            Course cur42 = new Course { Name = "Engenharia de Produção" };
            Course cur43 = new Course { Name = "Engenharia Elétrica" };
            Course cur44 = new Course { Name = "Engenharia Mecânica" };
            Course cur45 = new Course { Name = "Farmácia" };
            Course cur46 = new Course { Name = "Filosofia - Lic." };
            Course cur47 = new Course { Name = "Letras - Português" };
            Course cur48 = new Course { Name = "Letras - Português e Espanhol" };
            Course cur49 = new Course { Name = "Letras - Português e Inglês" };
            Course cur50 = new Course { Name = "Teologia" };

            Period per1 = new Period { Semester = sem1, Course = cur1, CodPeriod = "CUR00" };
            Period per2 = new Period { Semester = sem2, Course = cur2, CodPeriod = "2Licen1" };
            Period per3 = new Period { Semester = sem3, Course = cur2, CodPeriod = "2Licen2" };
            Period per4 = new Period { Semester = sem4, Course = cur2, CodPeriod = "2Licen3" };
            Period per5 = new Period { Semester = sem2, Course = cur3, CodPeriod = "ADM1" };
            Period per6 = new Period { Semester = sem3, Course = cur3, CodPeriod = "ADM2" };
            Period per7 = new Period { Semester = sem4, Course = cur3, CodPeriod = "ADM3" };
            Period per8 = new Period { Semester = sem5, Course = cur3, CodPeriod = "ADM4" };
            Period per9 = new Period { Semester = sem6, Course = cur3, CodPeriod = "ADM5" };
            Period per10 = new Period { Semester = sem7, Course = cur3, CodPeriod = "ADM6" };
            Period per11 = new Period { Semester = sem8, Course = cur3, CodPeriod = "ADM7" };
            Period per12 = new Period { Semester = sem9, Course = cur3, CodPeriod = "ADM8" };
            Period per13 = new Period { Semester = sem2, Course = cur4, CodPeriod = "AGRO1" };
            Period per14 = new Period { Semester = sem3, Course = cur4, CodPeriod = "AGRO2" };
            Period per15 = new Period { Semester = sem4, Course = cur4, CodPeriod = "AGRO3" };
            Period per16 = new Period { Semester = sem5, Course = cur4, CodPeriod = "AGRO4" };
            Period per17 = new Period { Semester = sem6, Course = cur4, CodPeriod = "AGRO5" };
            Period per18 = new Period { Semester = sem7, Course = cur4, CodPeriod = "AGRO6" };
            Period per19 = new Period { Semester = sem8, Course = cur4, CodPeriod = "AGRO7" };
            Period per20 = new Period { Semester = sem9, Course = cur4, CodPeriod = "AGRO8" };
            Period per21 = new Period { Semester = sem10, Course = cur4, CodPeriod = "AGRO9" };
            Period per22 = new Period { Semester = sem11, Course = cur4, CodPeriod = "AGRO10" };
            Period per23 = new Period { Semester = sem2, Course = cur5, CodPeriod = "ARTVIS1" };
            Period per24 = new Period { Semester = sem3, Course = cur5, CodPeriod = "ARTVIS2" };
            Period per25 = new Period { Semester = sem4, Course = cur5, CodPeriod = "ARTVIS3" };
            Period per26 = new Period { Semester = sem5, Course = cur5, CodPeriod = "ARTVIS4" };
            Period per27 = new Period { Semester = sem6, Course = cur5, CodPeriod = "ARTVIS5" };
            Period per28 = new Period { Semester = sem7, Course = cur5, CodPeriod = "ARTVIS6" };
            Period per29 = new Period { Semester = sem8, Course = cur5, CodPeriod = "ARTVIS7" };
            Period per30 = new Period { Semester = sem9, Course = cur5, CodPeriod = "ARTVIS8" };
            Period per31 = new Period { Semester = sem2, Course = cur6, CodPeriod = "CBIO1" };
            Period per32 = new Period { Semester = sem3, Course = cur6, CodPeriod = "CBIO2" };
            Period per33 = new Period { Semester = sem4, Course = cur6, CodPeriod = "CBIO3" };
            Period per34 = new Period { Semester = sem5, Course = cur6, CodPeriod = "CBIO4" };
            Period per35 = new Period { Semester = sem6, Course = cur6, CodPeriod = "CBIO5" };
            Period per36 = new Period { Semester = sem7, Course = cur6, CodPeriod = "CBIO6" };
            Period per37 = new Period { Semester = sem8, Course = cur6, CodPeriod = "CBIO7" };
            Period per38 = new Period { Semester = sem9, Course = cur6, CodPeriod = "CBIO8" };
            Period per39 = new Period { Semester = sem2, Course = cur7, CodPeriod = "CCON1" };
            Period per40 = new Period { Semester = sem3, Course = cur7, CodPeriod = "CCON2" };
            Period per41 = new Period { Semester = sem4, Course = cur7, CodPeriod = "CCON3" };
            Period per42 = new Period { Semester = sem5, Course = cur7, CodPeriod = "CCON4" };
            Period per43 = new Period { Semester = sem6, Course = cur7, CodPeriod = "CCON5" };
            Period per44 = new Period { Semester = sem7, Course = cur7, CodPeriod = "CCON6" };
            Period per45 = new Period { Semester = sem8, Course = cur7, CodPeriod = "CCON7" };
            Period per46 = new Period { Semester = sem9, Course = cur7, CodPeriod = "CCON8" };
            Period per47 = new Period { Semester = sem2, Course = cur8, CodPeriod = "CECO1" };
            Period per48 = new Period { Semester = sem3, Course = cur8, CodPeriod = "CECO2" };
            Period per49 = new Period { Semester = sem4, Course = cur8, CodPeriod = "CECO3" };
            Period per50 = new Period { Semester = sem5, Course = cur8, CodPeriod = "CECO4" };
            Period per51 = new Period { Semester = sem6, Course = cur8, CodPeriod = "CECO5" };
            Period per52 = new Period { Semester = sem7, Course = cur8, CodPeriod = "CECO6" };
            Period per53 = new Period { Semester = sem8, Course = cur8, CodPeriod = "CECO7" };
            Period per54 = new Period { Semester = sem9, Course = cur8, CodPeriod = "CECO8" };
            Period per55 = new Period { Semester = sem2, Course = cur9, CodPeriod = "CSTAGRO1" };
            Period per56 = new Period { Semester = sem3, Course = cur9, CodPeriod = "CSTAGRO2" };
            Period per57 = new Period { Semester = sem4, Course = cur9, CodPeriod = "CSTAGRO3" };
            Period per58 = new Period { Semester = sem5, Course = cur9, CodPeriod = "CSTAGRO4" };
            Period per59 = new Period { Semester = sem6, Course = cur9, CodPeriod = "CSTAGRO5" };
            Period per60 = new Period { Semester = sem7, Course = cur9, CodPeriod = "CSTAGRO6" };
            Period per61 = new Period { Semester = sem2, Course = cur10, CodPeriod = "CSTADS1" };
            Period per62 = new Period { Semester = sem3, Course = cur10, CodPeriod = "CSTADS2" };
            Period per63 = new Period { Semester = sem4, Course = cur10, CodPeriod = "CSTADS3" };
            Period per64 = new Period { Semester = sem5, Course = cur10, CodPeriod = "CSTADS4" };
            Period per65 = new Period { Semester = sem6, Course = cur10, CodPeriod = "CSTADS5" };
            Period per66 = new Period { Semester = sem7, Course = cur10, CodPeriod = "CSTADS6" };
            Period per67 = new Period { Semester = sem2, Course = cur11, CodPeriod = "CSTEIP1" };
            Period per68 = new Period { Semester = sem3, Course = cur11, CodPeriod = "CSTEIP2" };
            Period per69 = new Period { Semester = sem4, Course = cur11, CodPeriod = "CSTEIP3" };
            Period per70 = new Period { Semester = sem5, Course = cur11, CodPeriod = "CSTEIP4" };
            Period per71 = new Period { Semester = sem6, Course = cur11, CodPeriod = "CSTEIP5" };
            Period per72 = new Period { Semester = sem2, Course = cur12, CodPeriod = "CSTEMPRE1" };
            Period per73 = new Period { Semester = sem3, Course = cur12, CodPeriod = "CSTEMPRE2" };
            Period per74 = new Period { Semester = sem4, Course = cur12, CodPeriod = "CSTEMPRE3" };
            Period per75 = new Period { Semester = sem5, Course = cur12, CodPeriod = "CSTEMPRE4" };
            Period per76 = new Period { Semester = sem2, Course = cur13, CodPeriod = "CSTLOG1" };
            Period per77 = new Period { Semester = sem3, Course = cur13, CodPeriod = "CSTLOG2" };
            Period per78 = new Period { Semester = sem4, Course = cur13, CodPeriod = "CSTLOG3" };
            Period per79 = new Period { Semester = sem5, Course = cur13, CodPeriod = "CSTLOG4" };
            Period per80 = new Period { Semester = sem2, Course = cur14, CodPeriod = "CSTMKT1" };
            Period per81 = new Period { Semester = sem3, Course = cur14, CodPeriod = "CSTMKT2" };
            Period per82 = new Period { Semester = sem4, Course = cur14, CodPeriod = "CSTMKT3" };
            Period per83 = new Period { Semester = sem5, Course = cur14, CodPeriod = "CSTMKT4" };
            Period per84 = new Period { Semester = sem2, Course = cur15, CodPeriod = "CSTMKTDIG1" };
            Period per85 = new Period { Semester = sem3, Course = cur15, CodPeriod = "CSTMKTDIG2" };
            Period per86 = new Period { Semester = sem4, Course = cur15, CodPeriod = "CSTMKTDIG3" };
            Period per87 = new Period { Semester = sem5, Course = cur15, CodPeriod = "CSTMKTDIG4" };
            Period per88 = new Period { Semester = sem2, Course = cur16, CodPeriod = "CSTPROG1" };
            Period per89 = new Period { Semester = sem3, Course = cur16, CodPeriod = "CSTPROG2" };
            Period per90 = new Period { Semester = sem4, Course = cur16, CodPeriod = "CSTPROG3" };
            Period per91 = new Period { Semester = sem5, Course = cur16, CodPeriod = "CSTPROG4" };
            Period per92 = new Period { Semester = sem2, Course = cur17, CodPeriod = "CSTSEGT1" };
            Period per93 = new Period { Semester = sem3, Course = cur17, CodPeriod = "CSTSEGT2" };
            Period per94 = new Period { Semester = sem4, Course = cur17, CodPeriod = "CSTSEGT3" };
            Period per95 = new Period { Semester = sem5, Course = cur17, CodPeriod = "CSTSEGT4" };
            Period per96 = new Period { Semester = sem6, Course = cur17, CodPeriod = "CSTSEGT5" };
            Period per97 = new Period { Semester = sem7, Course = cur17, CodPeriod = "CSTSEGT6" };
            Period per98 = new Period { Semester = sem2, Course = cur18, CodPeriod = "CSTJURCNOT1" };
            Period per99 = new Period { Semester = sem3, Course = cur18, CodPeriod = "CSTJURCNOT2" };
            Period per100 = new Period { Semester = sem4, Course = cur18, CodPeriod = "CSTJURCNOT3" };
            Period per101 = new Period { Semester = sem5, Course = cur18, CodPeriod = "CSTJURCNOT4" };
            Period per102 = new Period { Semester = sem2, Course = cur19, CodPeriod = "GAMB1" };
            Period per103 = new Period { Semester = sem3, Course = cur19, CodPeriod = "GAMB2" };
            Period per104 = new Period { Semester = sem4, Course = cur19, CodPeriod = "GAMB3" };
            Period per105 = new Period { Semester = sem5, Course = cur19, CodPeriod = "GAMB4" };
            Period per106 = new Period { Semester = sem6, Course = cur19, CodPeriod = "GAMB5" };
            Period per107 = new Period { Semester = sem7, Course = cur19, CodPeriod = "GAMB6" };
            Period per108 = new Period { Semester = sem2, Course = cur20, CodPeriod = "GCOM1" };
            Period per109 = new Period { Semester = sem3, Course = cur20, CodPeriod = "GCOM2" };
            Period per110 = new Period { Semester = sem4, Course = cur20, CodPeriod = "GCOM3" };
            Period per111 = new Period { Semester = sem5, Course = cur20, CodPeriod = "GCOM4" };
            Period per112 = new Period { Semester = sem2, Course = cur21, CodPeriod = "GSPUB1" };
            Period per113 = new Period { Semester = sem3, Course = cur21, CodPeriod = "GSPUB2" };
            Period per114 = new Period { Semester = sem4, Course = cur21, CodPeriod = "GSPUB3" };
            Period per115 = new Period { Semester = sem5, Course = cur21, CodPeriod = "GSPUB4" };
            Period per116 = new Period { Semester = sem2, Course = cur22, CodPeriod = "GPIND1" };
            Period per117 = new Period { Semester = sem3, Course = cur22, CodPeriod = "GPIND2" };
            Period per118 = new Period { Semester = sem4, Course = cur22, CodPeriod = "GPIND3" };
            Period per119 = new Period { Semester = sem5, Course = cur22, CodPeriod = "GPIND4" };
            Period per120 = new Period { Semester = sem6, Course = cur22, CodPeriod = "GPIND5" };
            Period per121 = new Period { Semester = sem7, Course = cur22, CodPeriod = "GPIND6" };
            Period per122 = new Period { Semester = sem2, Course = cur23, CodPeriod = "GRH1" };
            Period per123 = new Period { Semester = sem3, Course = cur23, CodPeriod = "GRH2" };
            Period per124 = new Period { Semester = sem4, Course = cur23, CodPeriod = "GRH3" };
            Period per125 = new Period { Semester = sem5, Course = cur23, CodPeriod = "GRH4" };
            Period per126 = new Period { Semester = sem2, Course = cur24, CodPeriod = "GFIN1" };
            Period per127 = new Period { Semester = sem3, Course = cur24, CodPeriod = "GFIN2" };
            Period per128 = new Period { Semester = sem4, Course = cur24, CodPeriod = "GFIN3" };
            Period per129 = new Period { Semester = sem5, Course = cur24, CodPeriod = "GFIN4" };
            Period per130 = new Period { Semester = sem2, Course = cur25, CodPeriod = "GHOSP1" };
            Period per131 = new Period { Semester = sem3, Course = cur25, CodPeriod = "GHOSP2" };
            Period per132 = new Period { Semester = sem4, Course = cur25, CodPeriod = "GHOSP3" };
            Period per133 = new Period { Semester = sem5, Course = cur25, CodPeriod = "GHOSP4" };
            Period per134 = new Period { Semester = sem6, Course = cur25, CodPeriod = "GHOSP5" };
            Period per135 = new Period { Semester = sem7, Course = cur25, CodPeriod = "GHOSP6" };
            Period per136 = new Period { Semester = sem2, Course = cur26, CodPeriod = "GPUB1" };
            Period per137 = new Period { Semester = sem3, Course = cur26, CodPeriod = "GPUB2" };
            Period per138 = new Period { Semester = sem4, Course = cur26, CodPeriod = "GPUB3" };
            Period per139 = new Period { Semester = sem5, Course = cur26, CodPeriod = "GPUB4" };
            Period per140 = new Period { Semester = sem2, Course = cur27, CodPeriod = "EDUFB1" };
            Period per141 = new Period { Semester = sem3, Course = cur27, CodPeriod = "EDUFB2" };
            Period per142 = new Period { Semester = sem4, Course = cur27, CodPeriod = "EDUFB3" };
            Period per143 = new Period { Semester = sem5, Course = cur27, CodPeriod = "EDUFB4" };
            Period per144 = new Period { Semester = sem6, Course = cur27, CodPeriod = "EDUFB5" };
            Period per145 = new Period { Semester = sem7, Course = cur27, CodPeriod = "EDUFB6" };
            Period per146 = new Period { Semester = sem8, Course = cur27, CodPeriod = "EDUFB7" };
            Period per147 = new Period { Semester = sem9, Course = cur27, CodPeriod = "EDUFB8" };
            Period per148 = new Period { Semester = sem2, Course = cur28, CodPeriod = "EDUFL1" };
            Period per149 = new Period { Semester = sem3, Course = cur28, CodPeriod = "EDUFL2" };
            Period per150 = new Period { Semester = sem4, Course = cur28, CodPeriod = "EDUFL3" };
            Period per151 = new Period { Semester = sem5, Course = cur28, CodPeriod = "EDUFL4" };
            Period per152 = new Period { Semester = sem6, Course = cur28, CodPeriod = "EDUFL5" };
            Period per153 = new Period { Semester = sem7, Course = cur28, CodPeriod = "EDUFL6" };
            Period per154 = new Period { Semester = sem8, Course = cur28, CodPeriod = "EDUFL7" };
            Period per155 = new Period { Semester = sem9, Course = cur28, CodPeriod = "EDUFL8" };
            Period per156 = new Period { Semester = sem2, Course = cur29, CodPeriod = "ENFER1" };
            Period per157 = new Period { Semester = sem3, Course = cur29, CodPeriod = "ENFER2" };
            Period per158 = new Period { Semester = sem4, Course = cur29, CodPeriod = "ENFER3" };
            Period per159 = new Period { Semester = sem5, Course = cur29, CodPeriod = "ENFER4" };
            Period per160 = new Period { Semester = sem6, Course = cur29, CodPeriod = "ENFER5" };
            Period per161 = new Period { Semester = sem7, Course = cur29, CodPeriod = "ENFER6" };
            Period per162 = new Period { Semester = sem8, Course = cur29, CodPeriod = "ENFER7" };
            Period per163 = new Period { Semester = sem9, Course = cur29, CodPeriod = "ENFER8" };
            Period per164 = new Period { Semester = sem10, Course = cur29, CodPeriod = "ENFER9" };
            Period per165 = new Period { Semester = sem11, Course = cur29, CodPeriod = "ENFER10" };
            Period per166 = new Period { Semester = sem2, Course = cur30, CodPeriod = "FPEDAG1" };
            Period per167 = new Period { Semester = sem3, Course = cur30, CodPeriod = "FPEDAG2" };
            Period per168 = new Period { Semester = sem2, Course = cur31, CodPeriod = "GEO1" };
            Period per169 = new Period { Semester = sem3, Course = cur31, CodPeriod = "GEO2" };
            Period per170 = new Period { Semester = sem4, Course = cur31, CodPeriod = "GEO3" };
            Period per171 = new Period { Semester = sem5, Course = cur31, CodPeriod = "GEO4" };
            Period per172 = new Period { Semester = sem6, Course = cur31, CodPeriod = "GEO5" };
            Period per173 = new Period { Semester = sem7, Course = cur31, CodPeriod = "GEO6" };
            Period per174 = new Period { Semester = sem8, Course = cur31, CodPeriod = "GEO7" };
            Period per175 = new Period { Semester = sem9, Course = cur31, CodPeriod = "GEO8" };
            Period per176 = new Period { Semester = sem2, Course = cur32, CodPeriod = "HIS1" };
            Period per177 = new Period { Semester = sem3, Course = cur32, CodPeriod = "HIS2" };
            Period per178 = new Period { Semester = sem4, Course = cur32, CodPeriod = "HIS3" };
            Period per179 = new Period { Semester = sem5, Course = cur32, CodPeriod = "HIS4" };
            Period per180 = new Period { Semester = sem6, Course = cur32, CodPeriod = "HIS5" };
            Period per181 = new Period { Semester = sem7, Course = cur32, CodPeriod = "HIS6" };
            Period per182 = new Period { Semester = sem8, Course = cur32, CodPeriod = "HIS7" };
            Period per183 = new Period { Semester = sem9, Course = cur32, CodPeriod = "HIS8" };
            Period per184 = new Period { Semester = sem2, Course = cur33, CodPeriod = "LETRAS1" };
            Period per185 = new Period { Semester = sem3, Course = cur33, CodPeriod = "LETRAS2" };
            Period per186 = new Period { Semester = sem4, Course = cur33, CodPeriod = "LETRAS3" };
            Period per187 = new Period { Semester = sem5, Course = cur33, CodPeriod = "LETRAS4" };
            Period per188 = new Period { Semester = sem6, Course = cur33, CodPeriod = "LETRAS5" };
            Period per189 = new Period { Semester = sem7, Course = cur33, CodPeriod = "LETRAS6" };
            Period per190 = new Period { Semester = sem8, Course = cur33, CodPeriod = "LETRAS7" };
            Period per191 = new Period { Semester = sem9, Course = cur33, CodPeriod = "LETRAS8" };
            Period per192 = new Period { Semester = sem2, Course = cur34, CodPeriod = "MATEM1" };
            Period per193 = new Period { Semester = sem3, Course = cur34, CodPeriod = "MATEM2" };
            Period per194 = new Period { Semester = sem4, Course = cur34, CodPeriod = "MATEM3" };
            Period per195 = new Period { Semester = sem5, Course = cur34, CodPeriod = "MATEM4" };
            Period per196 = new Period { Semester = sem6, Course = cur34, CodPeriod = "MATEM5" };
            Period per197 = new Period { Semester = sem7, Course = cur34, CodPeriod = "MATEM6" };
            Period per198 = new Period { Semester = sem8, Course = cur34, CodPeriod = "MATEM7" };
            Period per199 = new Period { Semester = sem9, Course = cur34, CodPeriod = "MATEM8" };
            Period per200 = new Period { Semester = sem2, Course = cur35, CodPeriod = "PEDAG1" };
            Period per201 = new Period { Semester = sem3, Course = cur35, CodPeriod = "PEDAG2" };
            Period per202 = new Period { Semester = sem4, Course = cur35, CodPeriod = "PEDAG3" };
            Period per203 = new Period { Semester = sem5, Course = cur35, CodPeriod = "PEDAG4" };
            Period per204 = new Period { Semester = sem6, Course = cur35, CodPeriod = "PEDAG5" };
            Period per205 = new Period { Semester = sem7, Course = cur35, CodPeriod = "PEDAG6" };
            Period per206 = new Period { Semester = sem8, Course = cur35, CodPeriod = "PEDAG7" };
            Period per207 = new Period { Semester = sem9, Course = cur35, CodPeriod = "PEDAG8" };
            Period per208 = new Period { Semester = sem2, Course = cur36, CodPeriod = "SERSOC1" };
            Period per209 = new Period { Semester = sem3, Course = cur36, CodPeriod = "SERSOC2" };
            Period per210 = new Period { Semester = sem4, Course = cur36, CodPeriod = "SERSOC3" };
            Period per211 = new Period { Semester = sem5, Course = cur36, CodPeriod = "SERSOC4" };
            Period per212 = new Period { Semester = sem6, Course = cur36, CodPeriod = "SERSOC5" };
            Period per213 = new Period { Semester = sem7, Course = cur36, CodPeriod = "SERSOC6" };
            Period per214 = new Period { Semester = sem8, Course = cur36, CodPeriod = "SERSOC7" };
            Period per215 = new Period { Semester = sem9, Course = cur36, CodPeriod = "SERSOC8" };
            Period per216 = new Period { Semester = sem2, Course = cur37, CodPeriod = "SOC1" };
            Period per217 = new Period { Semester = sem3, Course = cur37, CodPeriod = "SOC2" };
            Period per218 = new Period { Semester = sem4, Course = cur37, CodPeriod = "SOC3" };
            Period per219 = new Period { Semester = sem5, Course = cur37, CodPeriod = "SOC4" };
            Period per220 = new Period { Semester = sem6, Course = cur37, CodPeriod = "SOC5" };
            Period per221 = new Period { Semester = sem7, Course = cur37, CodPeriod = "SOC6" };
            Period per222 = new Period { Semester = sem8, Course = cur37, CodPeriod = "SOC7" };
            Period per223 = new Period { Semester = sem9, Course = cur37, CodPeriod = "SOC8" };
            Period per224 = new Period { Semester = sem2, Course = cur38, CodPeriod = "COMEXT1" };
            Period per225 = new Period { Semester = sem3, Course = cur38, CodPeriod = "COMEXT2" };
            Period per226 = new Period { Semester = sem4, Course = cur38, CodPeriod = "COMEXT3" };
            Period per227 = new Period { Semester = sem5, Course = cur38, CodPeriod = "COMEXT4" };
            Period per228 = new Period { Semester = sem2, Course = cur39, CodPeriod = "GTUR1" };
            Period per229 = new Period { Semester = sem3, Course = cur39, CodPeriod = "GTUR2" };
            Period per230 = new Period { Semester = sem4, Course = cur39, CodPeriod = "GTUR3" };
            Period per231 = new Period { Semester = sem5, Course = cur39, CodPeriod = "GTUR4" };
            Period per232 = new Period { Semester = sem2, Course = cur40, CodPeriod = "ENGCIV1" };
            Period per233 = new Period { Semester = sem3, Course = cur40, CodPeriod = "ENGCIV2" };
            Period per234 = new Period { Semester = sem4, Course = cur40, CodPeriod = "ENGCIV3" };
            Period per235 = new Period { Semester = sem5, Course = cur40, CodPeriod = "ENGCIV4" };
            Period per236 = new Period { Semester = sem6, Course = cur40, CodPeriod = "ENGCIV5" };
            Period per237 = new Period { Semester = sem7, Course = cur40, CodPeriod = "ENGCIV6" };
            Period per238 = new Period { Semester = sem8, Course = cur40, CodPeriod = "ENGCIV7" };
            Period per239 = new Period { Semester = sem9, Course = cur40, CodPeriod = "ENGCIV8" };
            Period per240 = new Period { Semester = sem10, Course = cur40, CodPeriod = "ENGCIV9" };
            Period per241 = new Period { Semester = sem11, Course = cur40, CodPeriod = "ENGCIV10" };
            Period per242 = new Period { Semester = sem2, Course = cur41, CodPeriod = "ENGCOMP1" };
            Period per243 = new Period { Semester = sem3, Course = cur41, CodPeriod = "ENGCOMP2" };
            Period per244 = new Period { Semester = sem4, Course = cur41, CodPeriod = "ENGCOMP3" };
            Period per246 = new Period { Semester = sem5, Course = cur41, CodPeriod = "ENGCOMP4" };
            Period per247 = new Period { Semester = sem6, Course = cur41, CodPeriod = "ENGCOMP5" };
            Period per248 = new Period { Semester = sem7, Course = cur41, CodPeriod = "ENGCOMP6" };
            Period per249 = new Period { Semester = sem8, Course = cur41, CodPeriod = "ENGCOMP7" };
            Period per250 = new Period { Semester = sem9, Course = cur41, CodPeriod = "ENGCOMP8" };
            Period per251 = new Period { Semester = sem10, Course = cur41, CodPeriod = "ENGCOMP9" };
            Period per252 = new Period { Semester = sem11, Course = cur41, CodPeriod = "ENGCOMP10" };
            Period per253 = new Period { Semester = sem2, Course = cur42, CodPeriod = "ENGPRO1" };
            Period per254 = new Period { Semester = sem3, Course = cur42, CodPeriod = "ENGPRO2" };
            Period per255 = new Period { Semester = sem4, Course = cur42, CodPeriod = "ENGPRO3" };
            Period per256 = new Period { Semester = sem5, Course = cur42, CodPeriod = "ENGPRO4" };
            Period per257 = new Period { Semester = sem6, Course = cur42, CodPeriod = "ENGPRO5" };
            Period per258 = new Period { Semester = sem7, Course = cur42, CodPeriod = "ENGPRO6" };
            Period per259 = new Period { Semester = sem8, Course = cur42, CodPeriod = "ENGPRO7" };
            Period per260 = new Period { Semester = sem9, Course = cur42, CodPeriod = "ENGPRO8" };
            Period per261 = new Period { Semester = sem10, Course = cur42, CodPeriod = "ENGPRO9" };
            Period per262 = new Period { Semester = sem11, Course = cur42, CodPeriod = "ENGPRO10" };
            Period per263 = new Period { Semester = sem2, Course = cur43, CodPeriod = "ENGELE1" };
            Period per264 = new Period { Semester = sem3, Course = cur43, CodPeriod = "ENGELE2" };
            Period per265 = new Period { Semester = sem4, Course = cur43, CodPeriod = "ENGELE3" };
            Period per266 = new Period { Semester = sem5, Course = cur43, CodPeriod = "ENGELE4" };
            Period per267 = new Period { Semester = sem6, Course = cur43, CodPeriod = "ENGELE5" };
            Period per268 = new Period { Semester = sem7, Course = cur43, CodPeriod = "ENGELE6" };
            Period per269 = new Period { Semester = sem8, Course = cur43, CodPeriod = "ENGELE7" };
            Period per270 = new Period { Semester = sem9, Course = cur43, CodPeriod = "ENGELE8" };
            Period per271 = new Period { Semester = sem10, Course = cur43, CodPeriod = "ENGELE9" };
            Period per272 = new Period { Semester = sem11, Course = cur43, CodPeriod = "ENGELE10" };
            Period per273 = new Period { Semester = sem2, Course = cur44, CodPeriod = "ENGMEC1" };
            Period per274 = new Period { Semester = sem3, Course = cur44, CodPeriod = "ENGMEC2" };
            Period per275 = new Period { Semester = sem4, Course = cur44, CodPeriod = "ENGMEC3" };
            Period per276 = new Period { Semester = sem5, Course = cur44, CodPeriod = "ENGMEC4" };
            Period per277 = new Period { Semester = sem6, Course = cur44, CodPeriod = "ENGMEC5" };
            Period per278 = new Period { Semester = sem7, Course = cur44, CodPeriod = "ENGMEC6" };
            Period per279 = new Period { Semester = sem8, Course = cur44, CodPeriod = "ENGMEC7" };
            Period per280 = new Period { Semester = sem9, Course = cur44, CodPeriod = "ENGMEC8" };
            Period per281 = new Period { Semester = sem10, Course = cur44, CodPeriod = "ENGMEC9" };
            Period per282 = new Period { Semester = sem11, Course = cur44, CodPeriod = "ENGMEC10" };
            Period per283 = new Period { Semester = sem2, Course = cur45, CodPeriod = "FARM1" };
            Period per284 = new Period { Semester = sem3, Course = cur45, CodPeriod = "FARM2" };
            Period per285 = new Period { Semester = sem4, Course = cur45, CodPeriod = "FARM3" };
            Period per286 = new Period { Semester = sem5, Course = cur45, CodPeriod = "FARM4" };
            Period per287 = new Period { Semester = sem6, Course = cur45, CodPeriod = "FARM5" };
            Period per288 = new Period { Semester = sem7, Course = cur45, CodPeriod = "FARM6" };
            Period per289 = new Period { Semester = sem8, Course = cur45, CodPeriod = "FARM7" };
            Period per290 = new Period { Semester = sem9, Course = cur45, CodPeriod = "FARM8" };
            Period per291 = new Period { Semester = sem10, Course = cur45, CodPeriod = "FARM9" };
            Period per292 = new Period { Semester = sem11, Course = cur45, CodPeriod = "FARM10" };
            Period per293 = new Period { Semester = sem2, Course = cur46, CodPeriod = "FILO1" };
            Period per294 = new Period { Semester = sem3, Course = cur46, CodPeriod = "FILO2" };
            Period per295 = new Period { Semester = sem4, Course = cur46, CodPeriod = "FILO3" };
            Period per296 = new Period { Semester = sem5, Course = cur46, CodPeriod = "FILO4" };
            Period per297 = new Period { Semester = sem6, Course = cur46, CodPeriod = "FILO5" };
            Period per298 = new Period { Semester = sem7, Course = cur46, CodPeriod = "FILO6" };
            Period per299 = new Period { Semester = sem8, Course = cur46, CodPeriod = "FILO7" };
            Period per300 = new Period { Semester = sem9, Course = cur46, CodPeriod = "FILO8" };
            Period per301 = new Period { Semester = sem2, Course = cur47, CodPeriod = "LETRASPOR1" };
            Period per302 = new Period { Semester = sem3, Course = cur47, CodPeriod = "LETRASPOR2" };
            Period per303 = new Period { Semester = sem4, Course = cur47, CodPeriod = "LETRASPOR3" };
            Period per304 = new Period { Semester = sem5, Course = cur47, CodPeriod = "LETRASPOR4" };
            Period per305 = new Period { Semester = sem6, Course = cur47, CodPeriod = "LETRASPOR5" };
            Period per306 = new Period { Semester = sem7, Course = cur47, CodPeriod = "LETRASPOR6" };
            Period per307 = new Period { Semester = sem8, Course = cur47, CodPeriod = "LETRASPOR7" };
            Period per308 = new Period { Semester = sem9, Course = cur47, CodPeriod = "LETRASPOR8" };
            Period per309 = new Period { Semester = sem2, Course = cur48, CodPeriod = "LETRASPORESP1" };
            Period per310 = new Period { Semester = sem3, Course = cur48, CodPeriod = "LETRASPORESP2" };
            Period per311 = new Period { Semester = sem4, Course = cur48, CodPeriod = "LETRASPORESP3" };
            Period per312 = new Period { Semester = sem5, Course = cur48, CodPeriod = "LETRASPORESP4" };
            Period per313 = new Period { Semester = sem6, Course = cur48, CodPeriod = "LETRASPORESP5" };
            Period per314 = new Period { Semester = sem7, Course = cur48, CodPeriod = "LETRASPORESP6" };
            Period per315 = new Period { Semester = sem8, Course = cur48, CodPeriod = "LETRASPORESP7" };
            Period per316 = new Period { Semester = sem9, Course = cur48, CodPeriod = "LETRASPORESP8" };
            Period per317 = new Period { Semester = sem2, Course = cur49, CodPeriod = "LETRASPORING1" };
            Period per318 = new Period { Semester = sem3, Course = cur49, CodPeriod = "LETRASPORING2" };
            Period per319 = new Period { Semester = sem4, Course = cur49, CodPeriod = "LETRASPORING3" };
            Period per320 = new Period { Semester = sem5, Course = cur49, CodPeriod = "LETRASPORING4" };
            Period per321 = new Period { Semester = sem6, Course = cur49, CodPeriod = "LETRASPORING5" };
            Period per322 = new Period { Semester = sem7, Course = cur49, CodPeriod = "LETRASPORING6" };
            Period per323 = new Period { Semester = sem8, Course = cur49, CodPeriod = "LETRASPORING7" };
            Period per324 = new Period { Semester = sem9, Course = cur49, CodPeriod = "LETRASPORING8" };
            Period per325 = new Period { Semester = sem2, Course = cur50, CodPeriod = "TEO1" };
            Period per326 = new Period { Semester = sem3, Course = cur50, CodPeriod = "TEO2" };
            Period per327 = new Period { Semester = sem4, Course = cur50, CodPeriod = "TEO3" };
            Period per328 = new Period { Semester = sem5, Course = cur50, CodPeriod = "TEO4" };
            Period per329 = new Period { Semester = sem6, Course = cur50, CodPeriod = "TEO5" };
            Period per330 = new Period { Semester = sem7, Course = cur50, CodPeriod = "TEO6" };
            Period per331 = new Period { Semester = sem8, Course = cur50, CodPeriod = "TEO7" };
            Period per332 = new Period { Semester = sem9, Course = cur50, CodPeriod = "TEO8" };

            Journey j1 = new Journey { Name = "Folga", Duration = "00:00" };
            Journey j2 = new Journey { Name = "Horario Comercial", Duration = "08:00", Input1 = "08:00", Input2 = "14:00", Output1 = "12:00", Output2 = "18:00" };
            Journey j3 = new Journey { Name = "Horario Sabado", Duration = "04:00", Input1 = "08:00", Output1 = "12:00" };

            Scale s1 = new Scale { Name = "Escala 5x2" };

            ScaleFormatting sf1 = new ScaleFormatting { Journey = j1, Scale = s1, Week = System.DayOfWeek.Sunday };
            ScaleFormatting sf2 = new ScaleFormatting { Journey = j2, Scale = s1, Week = System.DayOfWeek.Monday };
            ScaleFormatting sf3 = new ScaleFormatting { Journey = j2, Scale = s1, Week = System.DayOfWeek.Tuesday };
            ScaleFormatting sf4 = new ScaleFormatting { Journey = j2, Scale = s1, Week = System.DayOfWeek.Wednesday };
            ScaleFormatting sf5 = new ScaleFormatting { Journey = j2, Scale = s1, Week = System.DayOfWeek.Thursday };
            ScaleFormatting sf6 = new ScaleFormatting { Journey = j2, Scale = s1, Week = System.DayOfWeek.Friday };
            ScaleFormatting sf7 = new ScaleFormatting { Journey = j3, Scale = s1, Week = System.DayOfWeek.Saturday };

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
            SystemController sys14 = new SystemController { Name = "Formatação da Escala", NameController = "EmployeeScaleFormatting", NameClaim = "ScaleFormatting", ValueClaim = 5, IsCheck = false };
            SystemController sys15 = new SystemController { Name = "Ponto eletrônico", NameController = "EmployeeTimePoint", NameClaim = "TimePoint", ValueClaim = 5, IsCheck = false };
            SystemController sys16 = new SystemController { Name = "Histórico do Patrimônio", NameController = "PatrimonyHistoricPatrimony", NameClaim = "HistoricPatrimony", ValueClaim = 5, IsCheck = false };
            SystemController sys17 = new SystemController { Name = "Patrimônio", NameController = "PatrimonyPatrimony", NameClaim = "Patrimony", ValueClaim = 5, IsCheck = false };
            SystemController sys18 = new SystemController { Name = "Produto", NameController = "PatrimonyProduct", NameClaim = "Product", ValueClaim = 5, IsCheck = false };
            SystemController sys19 = new SystemController { Name = "Valor Boleto", NameController = "StudentBilletValue", NameClaim = "BilletValue", ValueClaim = 5, IsCheck = false };
            SystemController sys20 = new SystemController { Name = "Curso", NameController = "StudentCourse", NameClaim = "Course", ValueClaim = 5, IsCheck = false };
            SystemController sys21 = new SystemController { Name = "Período", NameController = "StudentPeriod", NameClaim = "Period", ValueClaim = 5, IsCheck = false };
            SystemController sys22 = new SystemController { Name = "Semestre", NameController = "StudentSemester", NameClaim = "Semester", ValueClaim = 5, IsCheck = false };
            SystemController sys23 = new SystemController { Name = "Financeiro Estudantil", NameController = "StudentStudentFinancial", NameClaim = "StudentFinancial", ValueClaim = 5, IsCheck = false };
            SystemController sys24 = new SystemController { Name = "Estudante", NameController = "StudentStudent", NameClaim = "Student", ValueClaim = 5, IsCheck = false };
            SystemController sys25 = new SystemController { Name = "Usuário Log-in", NameController = "UserDataLoginUserDataLogin", NameClaim = "UserDataLogin", ValueClaim = 5, IsCheck = false };
            /*Novo*/
            SystemController sys26 = new SystemController { Name = "Suprimento", NameController = "AdministrationSupply", NameClaim = "Supply", ValueClaim = 5, IsCheck = false };
            SystemController sys27 = new SystemController { Name = "Adicionar Suprimento", NameController = "AdministrationSupplyAdd", NameClaim = "SupplyAdd", ValueClaim = 5, IsCheck = false };
            SystemController sys28 = new SystemController { Name = "Remover Suprimento", NameController = "AdministrationSupplyWithdrawal", NameClaim = "SupplyWithdrawal", ValueClaim = 5, IsCheck = false };
            SystemController sys29 = new SystemController { Name = "Certificado", NameController = "CertificateCertificate", NameClaim = "Certificate", ValueClaim = 5, IsCheck = false };
            SystemController sys30 = new SystemController { Name = "Curso Certificado", NameController = "CertificateCertificateCourse", NameClaim = "CertificateCourse", ValueClaim = 5, IsCheck = false };
            SystemController sys31 = new SystemController { Name = "Certificado Programatico", NameController = "CertificateCertificateProgrammatic", NameClaim = "CertificateProgrammatic", ValueClaim = 5, IsCheck = false };

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
            SystemSubController sub34 = new SystemSubController { SystemController = sys14, Name = "Criar", NameSubController = "EmployeeScaleFormattingCreate", NameClaim = "ScaleFormattingCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub35 = new SystemSubController { SystemController = sys14, Name = "Editar", NameSubController = "EmployeeScaleFormattingEdit", NameClaim = "ScaleFormattingEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub36 = new SystemSubController { SystemController = sys14, Name = "Deletar", NameSubController = "EmployeeScaleFormattingDelete", NameClaim = "ScaleFormattingDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub37 = new SystemSubController { SystemController = sys15, Name = "Criar", NameSubController = "EmployeeTimePointCreate", NameClaim = "TimePointCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub38 = new SystemSubController { SystemController = sys15, Name = "Editar", NameSubController = "EmployeeTimePointEdit", NameClaim = "TimePointEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub39 = new SystemSubController { SystemController = sys15, Name = "Deletar", NameSubController = "EmployeeTimePointDelete", NameClaim = "TimePointDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub40 = new SystemSubController { SystemController = sys16, Name = "Criar", NameSubController = "PatrimonyHistoricPatrimonyCreate", NameClaim = "HistoricPatrimonyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub41 = new SystemSubController { SystemController = sys16, Name = "Editar", NameSubController = "PatrimonyHistoricPatrimonyEdit", NameClaim = "HistoricPatrimonyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub42 = new SystemSubController { SystemController = sys16, Name = "Deletar", NameSubController = "PatrimonyHistoricPatrimonyDelete", NameClaim = "HistoricPatrimonyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub43 = new SystemSubController { SystemController = sys17, Name = "Criar", NameSubController = "PatrimonyPatrimonyCreate", NameClaim = "PatrimonyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub44 = new SystemSubController { SystemController = sys17, Name = "Editar", NameSubController = "PatrimonyPatrimonyEdit", NameClaim = "PatrimonyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub45 = new SystemSubController { SystemController = sys17, Name = "Deletar", NameSubController = "PatrimonyPatrimonyDelete", NameClaim = "PatrimonyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub46 = new SystemSubController { SystemController = sys18, Name = "Criar", NameSubController = "PatrimonyProductCreate", NameClaim = "ProductCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub47 = new SystemSubController { SystemController = sys18, Name = "Editar", NameSubController = "PatrimonyProductEdit", NameClaim = "ProductEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub48 = new SystemSubController { SystemController = sys18, Name = "Deletar", NameSubController = "PatrimonyProductDelete", NameClaim = "ProductDelete", ValueClaim = 5, IsCheck = false };
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
            /*Novo*/
            SystemSubController sub70 = new SystemSubController { SystemController = sys26, Name = "Criar", NameSubController = "AdministrationSupplyCreate", NameClaim = "SupplyCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub71 = new SystemSubController { SystemController = sys26, Name = "Editar", NameSubController = "AdministrationSupplyEdit", NameClaim = "SupplyEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub72 = new SystemSubController { SystemController = sys26, Name = "Deletar", NameSubController = "AdministrationSupplyDelete", NameClaim = "SupplyDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub73 = new SystemSubController { SystemController = sys27, Name = "Criar", NameSubController = "AdministrationSupplyAddCreate", NameClaim = "SupplyAddCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub74 = new SystemSubController { SystemController = sys27, Name = "Editar", NameSubController = "AdministrationSupplyAddEdit", NameClaim = "SupplyAddEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub75 = new SystemSubController { SystemController = sys27, Name = "Deletar", NameSubController = "AdministrationSupplyAddDelete", NameClaim = "SupplyAddDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub76 = new SystemSubController { SystemController = sys28, Name = "Criar", NameSubController = "AdministrationSupplyWithdrawalCreate", NameClaim = "SupplyWithdrawalCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub77 = new SystemSubController { SystemController = sys28, Name = "Editar", NameSubController = "AdministrationSupplyWithdrawalEdit", NameClaim = "SupplyWithdrawalEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub78 = new SystemSubController { SystemController = sys28, Name = "Deletar", NameSubController = "AdministrationSupplyWithdrawalDelete", NameClaim = "SupplyWithdrawalDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub79 = new SystemSubController { SystemController = sys29, Name = "Criar", NameSubController = "CertificateCertificateCreate", NameClaim = "CertificateCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub80 = new SystemSubController { SystemController = sys29, Name = "Editar", NameSubController = "CertificateCertificateEdit", NameClaim = "CertificateEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub81 = new SystemSubController { SystemController = sys29, Name = "Deletar", NameSubController = "CertificateCertificateDelete", NameClaim = "CertificateDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub82 = new SystemSubController { SystemController = sys30, Name = "Criar", NameSubController = "CertificateCertificateCourseCreate", NameClaim = "CertificateCourseCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub83 = new SystemSubController { SystemController = sys30, Name = "Editar", NameSubController = "CertificateCertificateCourseEdit", NameClaim = "CertificateCourseEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub84 = new SystemSubController { SystemController = sys30, Name = "Deletar", NameSubController = "CertificateCertificateCourseDelete", NameClaim = "CertificateCourseDelete", ValueClaim = 5, IsCheck = false };
            SystemSubController sub85 = new SystemSubController { SystemController = sys31, Name = "Criar", NameSubController = "CertificateCertificateProgrammaticCreate", NameClaim = "CertificateProgrammaticCreate", ValueClaim = 5, IsCheck = false };
            SystemSubController sub86 = new SystemSubController { SystemController = sys31, Name = "Editar", NameSubController = "CertificateCertificateProgrammaticEdit", NameClaim = "CertificateProgrammaticEdit", ValueClaim = 5, IsCheck = false };
            SystemSubController sub87 = new SystemSubController { SystemController = sys31, Name = "Deletar", NameSubController = "CertificateCertificateProgrammaticDelete", NameClaim = "CertificateProgrammaticDelete", ValueClaim = 5, IsCheck = false };


            await _context.SystemController.AddRangeAsync(sys4, sys5, sys6, sys7, sys8, sys9, sys10, sys11, sys12, sys13, sys14, sys15, sys16, sys17, sys18, sys19, sys20, sys21, sys22, sys23, sys24, sys25, sys26, sys27, sys28, sys29, sys30, sys31);

            await _context.SystemSubController.AddRangeAsync(sub4, sub5, sub6, sub7, sub8, sub9, sub10, sub11, sub12, sub13, sub14, sub15, sub16, sub17, sub18, sub19, sub20, sub21, sub22, sub23, sub24, sub25, sub26,
                                                       sub27, sub28, sub29, sub30, sub31, sub32, sub33, sub34, sub35, sub36, sub37, sub38, sub39, sub40, sub41, sub42, sub43, sub44, sub45, sub46, sub47, sub48,
                                                       sub49, sub50, sub51, sub52, sub53, sub54, sub55, sub56, sub57, sub58, sub59, sub60, sub61, sub62, sub63, sub64, sub65, sub66, sub67, sub68, sub69,
                                                       sub70, sub71, sub72, sub73, sub74, sub75, sub76, sub77, sub78, sub79, sub80, sub81, sub82, sub83, sub84, sub85, sub86, sub87);

            await _context.Department.AddRangeAsync(d1, d2, d3);

            await _context.Sector.AddRangeAsync(sc1, sc2, sc3, sc4, sc5, sc6, sc7, sc8, sc9, sc10, sc11, sc12);

            await _context.Journey.AddRangeAsync(j1, j2, j3);

            await _context.Scale.AddAsync(s1);

            await _context.ScaleFormatting.AddRangeAsync(sf1, sf2, sf3, sf4, sf5, sf6, sf7);

            await _context.Semester.AddRangeAsync(sem1, sem2, sem3, sem4, sem5, sem6, sem7, sem8, sem9, sem10, sem11);

            await _context.Course.AddRangeAsync(cur1, cur2, cur3, cur4, cur5, cur6, cur7, cur8, cur9, cur10, cur11, cur12, cur13, cur14, cur15, cur16, cur17, cur18, cur19,
                                     cur20, cur21, cur22, cur23, cur24, cur25, cur26, cur27, cur28, cur29, cur30, cur31, cur32, cur33, cur34, cur35, cur36, cur37, cur38,
                                     cur39, cur40, cur41, cur42, cur43, cur44, cur45, cur46, cur47, cur48, cur49, cur50);

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
                                     per221, per222, per223, per224, per225, per226, per227, per228, per229, per230, per231, per232, per233, per234, per235, per236,
                                     per237, per238, per239, per240, per241, per242, per243, per244, per246, per247, per248, per249, per250, per251, per252, per253,
                                     per254, per255, per256, per257, per258, per259, per260, per261, per262, per263, per264, per265, per266, per267, per268, per269,
                                     per270, per271, per272, per273, per274, per275, per276, per277, per278, per279, per280, per281, per282, per283, per284, per285,
                                     per286, per287, per288, per289, per290, per291, per292, per293, per294, per295, per296, per297, per298, per299, per300, per301,
                                     per302, per303, per304, per305, per306, per307, per308, per309, per310, per311, per312, per313, per314, per315, per316, per317,
                                     per318, per319, per320, per321, per322, per323, per324, per325, per326, per327, per328, per329, per330, per331, per332);

            await _context.SaveChangesAsync();
        }
    }
}