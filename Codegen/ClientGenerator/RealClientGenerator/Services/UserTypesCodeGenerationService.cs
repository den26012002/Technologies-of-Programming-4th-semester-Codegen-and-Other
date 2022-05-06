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
    public class UserTypesCodeGenerationService
    {
        private ITypesMapper _typesMapper;
        public UserTypesCodeGenerationService(ITypesMapper typesMapper)
        {
            _typesMapper = typesMapper;
        }
        public TypeSyntax GenerateType(TypeTree typeTree)
        {
            if (typeTree.InnerTypes.Count == 0)
            {
                return SyntaxFactory.IdentifierName(_typesMapper.GetMappedType(typeTree.Name));
            }
            else
            {
                ArrayList<SyntaxNodeOrToken> innerTypes = new ArrayList<SyntaxNodeOrToken>();
                for (int i = 0; i < typeTree.InnerTypes.Count; ++i)
                {
                    TypeTree type = typeTree.InnerTypes[i];
                    innerTypes.Add(GenerateType(type));
                    if (i != typeTree.InnerTypes.Count - 1)
                    {
                        innerTypes.Add(SyntaxFactory.Token(SyntaxKind.CommaToken));
                    }
                }
                return SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier(_typesMapper.GetMappedType(typeTree.Name)))
                    .WithTypeArgumentList(
                        SyntaxFactory.TypeArgumentList(
                            SyntaxFactory.SeparatedList<TypeSyntax>(innerTypes)));
            }
        }

        public PropertyDeclarationSyntax GenerateProperty(ClassField classField)
        {
            return SyntaxFactory.PropertyDeclaration(
                GenerateType(classField.Type),
                SyntaxFactory.Identifier(new StringModifier().MakeCSharpName(classField.Name)))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithAccessorList(
                    SyntaxFactory.AccessorList(
                        SyntaxFactory.List<AccessorDeclarationSyntax>(
                            new AccessorDeclarationSyntax[]{
                                SyntaxFactory.AccessorDeclaration(
                                    SyntaxKind.GetAccessorDeclaration)
                                .WithSemicolonToken(
                                    SyntaxFactory.Token(SyntaxKind.SemicolonToken)),
                                SyntaxFactory.AccessorDeclaration(
                                    SyntaxKind.SetAccessorDeclaration)
                                .WithSemicolonToken(
                                    SyntaxFactory.Token(SyntaxKind.SemicolonToken))})));
        }

        public ClassDeclarationSyntax GenerateClass(ClassWithFields classWithFields)
        {
            ArrayList<MemberDeclarationSyntax> classProperties = new ArrayList<MemberDeclarationSyntax>();
            for (int i = 0; i < classWithFields.Fields.Count; ++i)
            {
                classProperties.Add(GenerateProperty(classWithFields.Fields[i]));
            }
            return SyntaxFactory.ClassDeclaration(classWithFields.Name)
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)))
                .WithMembers(
                SyntaxFactory.List<MemberDeclarationSyntax>(classProperties))
                .WithSemicolonToken(
                SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        }

        public UsingDirectiveSyntax GenerateUsingDirective(string namespaceName)
        {
            return SyntaxFactory.UsingDirective(
                SyntaxFactory.IdentifierName(namespaceName));
        }

        public CompilationUnitSyntax GenerateCompilationUnit(ClassWithFields classWithFields, string namespaceName, ArrayList<string> additionalNamespacesNames)
        {
            ArrayList<UsingDirectiveSyntax> usingDirectives = new ArrayList<UsingDirectiveSyntax>();
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
                            SyntaxFactory.SingletonList<MemberDeclarationSyntax>(GenerateClass(classWithFields)))
                        .WithSemicolonToken(
                            SyntaxFactory.Token(SyntaxKind.SemicolonToken))));
        }
    }
}
