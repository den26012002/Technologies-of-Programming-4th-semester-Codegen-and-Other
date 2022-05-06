// Template generated code from Antlr4BuildTasks.Template v 8.17
namespace ClientGenerator
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Misc;
    using Antlr4.Runtime.Tree;
    using AntlrTemplate;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            ArrayList<string> userTypes = new ArrayList<string>();
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\Cat.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\CatsOwner.java");
            userTypes.Add(@"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsentities\Color.java");
            string serverClass = @"D:\ИТМО\4-й семестр\Технологии программирования\den26012002\Codegen\cats-server\src\main\java\den26012002\catsserver\CatsServerController.java";
            var semanticModel = new SemanticModelService().GetSemanticModel(userTypes, serverClass);
            System.Console.WriteLine(semanticModel.UserTypes[0].Name);
        }
    }
}
