using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ClientGenerator;
using ClientGenerator.Entities;

namespace AntlrTemplate
{
    public class SemanticModelService
    {
        public SemanticModel GetSemanticModel(ArrayList<string> userTypesClassesFiles, string serverClassFile)
        {
            SemanticModel semanticModel = new SemanticModel();
            foreach (string file in userTypesClassesFiles)
            {
                string userType = File.ReadAllText(file);
                ICharStream userTypeStream = CharStreams.fromString(userType);
                ITokenSource userTypeLexer = new JavaLexer(userTypeStream);
                ITokenStream userTypeTokens = new CommonTokenStream(userTypeLexer);
                var userTypeParser = new JavaParser(userTypeTokens);
                IParseTree userTypeTree = userTypeParser.compilationUnit();
                var classFieldsFinder = new ClassFieldsFinder();
                semanticModel.UserTypes.Add(classFieldsFinder.GetClassWithFields(userTypeTree));
            }

            string serverClass = File.ReadAllText(serverClassFile);
            ICharStream serverStream = CharStreams.fromString(serverClass);
            ITokenSource serverLexer = new JavaLexer(serverStream);
            ITokenStream serverTokens = new CommonTokenStream(serverLexer);
            var serverParser = new JavaParser(serverTokens);
            IParseTree serverTree = serverParser.compilationUnit();
            var methodInfoFinder = new MethodInfoFinder();
            semanticModel.ServerMethodDeclarations = methodInfoFinder.GetMethodDeclarations(serverTree);

            return semanticModel;
        }
        /*
   string input = "class X { @GetMapping(\"/cats/{id}\") ResponseEntity<Cat> getCatById(@PathVariable int id) { return id; } @GetMapping(\"/cats_owners/{id}\") ResponseEntity<Cat> getCatsOwnerById(int id) {}};";
   ICharStream stream = CharStreams.fromString(input);
   ITokenSource lexer = new JavaLexer(stream);
   ITokenStream tokens = new CommonTokenStream(lexer);
   var parser = new JavaParser(tokens);
   IParseTree tree = parser.compilationUnit();
   var calculator = new AntlrTemplate.MethodInfoFinder();
   var output = calculator.GetMethodDeclarations(tree as ClientGenerator.JavaParser.CompilationUnitContext);
   System.Console.WriteLine($"{input} = {output}");
*/
    }
}
