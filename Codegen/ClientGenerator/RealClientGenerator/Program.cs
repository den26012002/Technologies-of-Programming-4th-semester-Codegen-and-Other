using System.Net;
using Antlr4.Runtime.Misc;
using AntlrTemplate;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RealClientGenerator.Services;
using RealClientGenerator.Tools;
using AntlrTemplate;
using Newtonsoft.Json;

namespace RealClientGenerator 
{
    public class Program
    {

        /*public static void X()
        {
            return JsonConvert.DeserializeObject<CatsOwner>(new HttpClient().GetAsync("http://localhost:8080/cats_owners/get/0").Result.Content.ReadAsStringAsync().Result);
            Console.WriteLine(JsonConvert.DeserializeObject<CatsOwner>(y.Result.Content.ReadAsStringAsync().Result));
        }*/
        public static void Main(string[] args)
        {
            ArrayList<string> userTypes = new ArrayList<string>();
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\Cat.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\CatsOwner.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\Color.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\DateTime.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsdto\CatsOwnerToServerDto.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsdto\CatToServerDto.java");
            string serverClass = @"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsserver\CatsServerController.java";
            var semanticModel = new SemanticModelService().GetSemanticModel(userTypes, serverClass);
            new CodeGenerationService().GenerateFiles(
                @"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\ClientGenerator\GeneratedClient",
                semanticModel,
                new JavaToCSharpTypesMapper(),
                "CatsServer",
                "Cats.Server",
                "Cats.Entities");
            // System.Console.WriteLine(semanticModel.UserTypes[0].Name);
            // var x = new UserTypesCodeGenerationService(new JavaToCSharpTypesMapper()).GenerateCompilationUnit(semanticModel.UserTypes[0], "Cats", new ArrayList<string>()).NormalizeWhitespace();
            // Console.WriteLine(x.ToFullString());
            /*Object obj = new Object();
            new HttpClient().PostAsync("", new StringContent(JsonConvert.SerializeObject(obj), System.Text.Encoding.UTF8, "application/json"));*/
            // X();
        }
    };    
};
