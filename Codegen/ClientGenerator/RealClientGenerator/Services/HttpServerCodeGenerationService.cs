using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using AntlrTemplate;
using AntlrTemplate.Entities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RealClientGenerator.Tools;

namespace RealClientGenerator.Services
{
    public class HttpServerCodeGenerationService
    {
        private ITypesMapper _typesMapper;
        public HttpServerCodeGenerationService(ITypesMapper typesMapper)
        {
            _typesMapper = typesMapper;
        }

        public CompilationUnitSyntax GenerateCompilationUnit(ArrayList<MethodDeclaration> httpServerMethodDeclarations, string className, string namespaceName, ArrayList<string> additionalNamespacesNames)
        {
            ArrayList<UsingDirectiveSyntax> usingDirectives = new ArrayList<UsingDirectiveSyntax>();
            usingDirectives.Add(GenerateUsingDirective("System.Net"));
            usingDirectives.Add(GenerateUsingDirective("Newtonsoft.Json"));
            foreach (string additionalNamespaceName in additionalNamespacesNames)
            {
                usingDirectives.Add(GenerateUsingDirective(additionalNamespaceName));
            }

            return SyntaxFactory.CompilationUnit()
                .WithUsings(
                    SyntaxFactory.List<UsingDirectiveSyntax>(usingDirectives))
                .WithMembers(
                    SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                        SyntaxFactory.NamespaceDeclaration(
                            SyntaxFactory.IdentifierName(namespaceName))
                        .WithMembers(
                            SyntaxFactory.SingletonList<MemberDeclarationSyntax>(GenerateClass(httpServerMethodDeclarations, className)))
                        .WithSemicolonToken(
                            SyntaxFactory.Token(SyntaxKind.SemicolonToken))));
        }

        public UsingDirectiveSyntax GenerateUsingDirective(string namespaceName)
        {
            return SyntaxFactory.UsingDirective(
                SyntaxFactory.IdentifierName(namespaceName));
        }

        public ClassDeclarationSyntax GenerateClass(ArrayList<MethodDeclaration> httpServerMethodDeclarations, string className)
        {
            ArrayList<MemberDeclarationSyntax> memberDeclarations = new ArrayList<MemberDeclarationSyntax>();
            for (int i = 0; i < httpServerMethodDeclarations.Count; ++i)
            {
                memberDeclarations.Add(GenerateMethod(httpServerMethodDeclarations[i]));
            }

            return SyntaxFactory.ClassDeclaration(className)
                .WithModifiers(
                    SyntaxFactory.TokenList(
                    SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithMembers(
                    SyntaxFactory.List<MemberDeclarationSyntax>(memberDeclarations))
                .WithSemicolonToken(
                    SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        public MethodDeclarationSyntax GenerateMethod(MethodDeclaration methodDeclaration)
        {
            ArrayList<SyntaxNodeOrToken> formalParameters = new ArrayList<SyntaxNodeOrToken>();
            for (int i = 0; i < methodDeclaration.formalParameters.Count; ++i)
            {
                formalParameters.Add(GenerateParameter(methodDeclaration.formalParameters[i]));
                if (i != methodDeclaration.formalParameters.Count - 1)
                {
                    formalParameters.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                }
            }

            return SyntaxFactory.MethodDeclaration(
                GenerateType(methodDeclaration.ReturnType),
                SyntaxFactory.Identifier(new StringModifier().MakeCSharpName(methodDeclaration.Name)))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            formalParameters)))
                .WithBody(
                    SyntaxFactory.Block(
                        SyntaxFactory.SingletonList<StatementSyntax>(GenerateBody(methodDeclaration))));
        }

        public StatementSyntax GenerateBody(MethodDeclaration methodDeclaration)
        {
            if (methodDeclaration.HttpMethodAnnotation.Name == "GetMapping")
            {
                return SyntaxFactory.ReturnStatement(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.IdentifierName("JsonConvert"),
                                        SyntaxFactory.GenericName(
                                            SyntaxFactory.Identifier("DeserializeObject"))
                                        .WithTypeArgumentList(
                                            SyntaxFactory.TypeArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<TypeSyntax>(
                                                    GenerateType(methodDeclaration.ReturnType))))))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                            SyntaxFactory.Argument(
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.InvocationExpression(
                                                        SyntaxFactory.MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            SyntaxFactory.MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                SyntaxFactory.MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    SyntaxFactory.InvocationExpression(
                                                                        SyntaxFactory.MemberAccessExpression(
                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                            SyntaxFactory.ObjectCreationExpression(
                                                                                SyntaxFactory.IdentifierName("HttpClient"))
                                                                            .WithArgumentList(
                                                                                SyntaxFactory.ArgumentList()),
                                                                            SyntaxFactory.IdentifierName("GetAsync")))
                                                                    .WithArgumentList(
                                                                        SyntaxFactory.ArgumentList(
                                                                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                                                SyntaxFactory.Argument(
                                                                                    SyntaxFactory.InterpolatedStringExpression(
                                                                                        SyntaxFactory.Token(SyntaxKind.InterpolatedStringStartToken))
                                                                                    .WithContents(
                                                                                        SyntaxFactory.SingletonList<InterpolatedStringContentSyntax>(
                                                                                            SyntaxFactory.InterpolatedStringText()
                                                                                            .WithTextToken(
                                                                                                SyntaxFactory.Token(
                                                                                                    SyntaxFactory.TriviaList(),
                                                                                                    SyntaxKind.InterpolatedStringTextToken,
                                                                                                    GenerateLiteral(methodDeclaration),
                                                                                                    GenerateLiteral(methodDeclaration),
                                                                                                    SyntaxFactory.TriviaList())))))))),
                                                                    SyntaxFactory.IdentifierName("Result")),
                                                                SyntaxFactory.IdentifierName("Content")),
                                                            SyntaxFactory.IdentifierName("ReadAsStringAsync"))),
                                                    SyntaxFactory.IdentifierName("Result")))))));
            }
            else
            {
                bool wasBodyParam = false;
                FormalParameter parameterWithBody = null;
                for (int i = 0; i < methodDeclaration.formalParameters.Count; ++i)
                {
                    var formalParameter = methodDeclaration.formalParameters[i];
                    if (formalParameter.HttpParameterAnnotation == "RequestBody")
                    {
                        wasBodyParam = true;
                        parameterWithBody = formalParameter;
                        break;
                    }
                }
                if (wasBodyParam)
                {
                    return SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.ObjectCreationExpression(
                                            SyntaxFactory.IdentifierName("HttpClient"))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList()),
                                        SyntaxFactory.IdentifierName("PostAsync")))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                            new SyntaxNodeOrToken[]{
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.InterpolatedStringExpression(
                                                        SyntaxFactory.Token(SyntaxKind.InterpolatedStringStartToken))
                                                    .WithContents(
                                                        SyntaxFactory.List<InterpolatedStringContentSyntax>(
                                                            new InterpolatedStringContentSyntax[]{
                                                                SyntaxFactory.InterpolatedStringText()
                                                                .WithTextToken(
                                                                    SyntaxFactory.Token(
                                                                        SyntaxFactory.TriviaList(),
                                                                        SyntaxKind.InterpolatedStringTextToken,
                                                                        GenerateLiteral(methodDeclaration),
                                                                        GenerateLiteral(methodDeclaration),
                                                                        SyntaxFactory.TriviaList()))}))),
                                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.ObjectCreationExpression(
                                                        SyntaxFactory.IdentifierName("StringContent"))
                                                    .WithArgumentList(
                                                        SyntaxFactory.ArgumentList(
                                                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                new SyntaxNodeOrToken[]{
                                                                    SyntaxFactory.Argument(
                                                                        SyntaxFactory.InvocationExpression(
                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                SyntaxFactory.IdentifierName("JsonConvert"),
                                                                                SyntaxFactory.IdentifierName("SerializeObject")))
                                                                        .WithArgumentList(
                                                                            SyntaxFactory.ArgumentList(
                                                                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                                                    SyntaxFactory.Argument(
                                                                                        SyntaxFactory.IdentifierName(parameterWithBody.Name)))))),
                                                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                                    SyntaxFactory.Argument(
                                                                        SyntaxFactory.MemberAccessExpression(
                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.IdentifierName("System"),
                                                                                    SyntaxFactory.IdentifierName("Text")),
                                                                                SyntaxFactory.IdentifierName("Encoding")),
                                                                            SyntaxFactory.IdentifierName("UTF8"))),
                                                                    SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                                    SyntaxFactory.Argument(
                                                                        SyntaxFactory.LiteralExpression(
                                                                            SyntaxKind.StringLiteralExpression,
                                                                            SyntaxFactory.Literal("application/json")))}))))}))));
                }
                else
                {
                    return SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        SyntaxFactory.ObjectCreationExpression(
                                            SyntaxFactory.IdentifierName("HttpClient"))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList()),
                                        SyntaxFactory.IdentifierName("PostAsync")))
                                .WithArgumentList(
                                    SyntaxFactory.ArgumentList(
                                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                            new SyntaxNodeOrToken[]{
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.InterpolatedStringExpression(
                                                        SyntaxFactory.Token(SyntaxKind.InterpolatedStringStartToken))
                                                    .WithContents(
                                                        SyntaxFactory.SingletonList<InterpolatedStringContentSyntax>(
                                                            SyntaxFactory.InterpolatedStringText()
                                                            .WithTextToken(
                                                                SyntaxFactory.Token(
                                                                    SyntaxFactory.TriviaList(),
                                                                    SyntaxKind.InterpolatedStringTextToken,
                                                                    GenerateLiteral(methodDeclaration),
                                                                    GenerateLiteral(methodDeclaration),
                                                                    SyntaxFactory.TriviaList()))))),
                                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                                SyntaxFactory.Argument(
                                                    SyntaxFactory.ObjectCreationExpression(
                                                        SyntaxFactory.IdentifierName("StringContent"))
                                                    .WithArgumentList(
                                                        SyntaxFactory.ArgumentList(
                                                            SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                                SyntaxFactory.Argument(
                                                                    SyntaxFactory.LiteralExpression(
                                                                        SyntaxKind.StringLiteralExpression,
                                                                        SyntaxFactory.Literal("")))))))}))));
                }
            }
        }

        public string GenerateLiteral(MethodDeclaration methodDeclaration)
        {
            string result = new StringModifier().DeleteQuotes(methodDeclaration.HttpMethodAnnotation.HttpUrl);
            bool wasRequestParam = false;
            for (int i = 0; i < methodDeclaration.formalParameters.Count; ++i)
            {
                var formalParameter = methodDeclaration.formalParameters[i];
                if (formalParameter.HttpParameterAnnotation == "RequestParam")
                {
                    if (!wasRequestParam)
                    {
                        result += '?';
                        wasRequestParam = true;
                    }
                    else
                    {
                        result += '&';
                    }

                    result += $"{formalParameter.Name}=" + '{' + $"{formalParameter.Name}" + '}';
                }
            }

            return result;
        }

        public TypeSyntax GenerateType(TypeTree typeTree)
        {
            if (typeTree.Name == "ResponseEntity")
            {
                return new UserTypesCodeGenerationService(_typesMapper).GenerateType(typeTree.InnerTypes[0]);
            }

            return new UserTypesCodeGenerationService(_typesMapper).GenerateType(typeTree);
        }

        public ParameterSyntax GenerateParameter(FormalParameter formalParameter)
        {
            return SyntaxFactory.Parameter(
                SyntaxFactory.Identifier(formalParameter.Name))
                .WithType(GenerateType(formalParameter.Type));
        }

        /*
         
                SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.IdentifierName("Cat"),
                    SyntaxFactory.Identifier("GetCatById"))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]{
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("id"))
                                .WithType(
                                    SyntaxFactory.PredefinedType(
                                        SyntaxFactory.Token(SyntaxKind.IntKeyword))),
                                SyntaxFactory.Token(SyntaxKind.CommaToken),
                                SyntaxFactory.Parameter(
                                    SyntaxFactory.Identifier("str"))
                                .WithType(
                                    SyntaxFactory.PredefinedType(
                                        SyntaxFactory.Token(SyntaxKind.StringKeyword)))})))
                .WithBody(
                    SyntaxFactory.Block())
         */
    }
}
