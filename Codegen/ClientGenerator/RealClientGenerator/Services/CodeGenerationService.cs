using Antlr4.Runtime.Misc;
using AntlrTemplate;
using RealClientGenerator.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ClientGenerator.Entities;

namespace RealClientGenerator.Services
{
    public class CodeGenerationService
    {
        public void GenerateFiles(
            string filesLocationFolder,
            ClientGenerator.Entities.SemanticModel semanticModel,
            ITypesMapper typesMapper,
            string serverClassName,
            string serverClassNamespaceName,
            string entitiesNamespaceName)
        {
            ArrayList<string> serverClassAdditionalNamespacesNames = new ArrayList<string>();
            serverClassAdditionalNamespacesNames.Add(entitiesNamespaceName);
            ArrayList<string> entitiesNamespaceAdditionalNamespacesNames = new ArrayList<string>();
            entitiesNamespaceAdditionalNamespacesNames.Add(serverClassNamespaceName);
            using (FileStream ofstream = new FileStream(filesLocationFolder + $"/{serverClassName}.cs", FileMode.OpenOrCreate))
            {
                ofstream.Write(
                    Encoding.Default.GetBytes(
                    new HttpServerCodeGenerationService(typesMapper)
                    .GenerateCompilationUnit(
                        semanticModel.ServerMethodDeclarations,
                        serverClassName,
                        serverClassNamespaceName,
                        serverClassAdditionalNamespacesNames)
                    .NormalizeWhitespace()
                    .ToFullString()));
            }

            foreach (ClassWithFields userType in semanticModel.UserTypes)
            {
                using (FileStream ofstream = new FileStream(filesLocationFolder + $"/{userType.Name}.cs", FileMode.OpenOrCreate))
                {
                    ofstream.Write(
                        Encoding.Default.GetBytes(
                        new UserTypesCodeGenerationService(typesMapper)
                        .GenerateCompilationUnit(
                            userType,
                            entitiesNamespaceName,
                            entitiesNamespaceAdditionalNamespacesNames)
                        .NormalizeWhitespace()
                        .ToFullString()));
                }
            }
        }
    }
}
