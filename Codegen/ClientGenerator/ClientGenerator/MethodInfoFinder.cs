using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using AntlrTemplate.Entities;

namespace AntlrTemplate
{
    public class MethodInfoFinder
    {
        public ArrayList<MethodDeclaration> GetMethodDeclarations(IParseTree context)
        {
            ArrayList<MethodDeclaration> result = new ArrayList<MethodDeclaration>();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.MethodDeclarationContext methodDeclarationContext)
                    {
                        result.Add(GetMethodDeclaration(methodDeclarationContext));
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return result;
        }
        public MethodDeclaration GetMethodDeclaration(ClientGenerator.JavaParser.MethodDeclarationContext context)
        {
            MethodDeclaration result = new MethodDeclaration();
            result.HttpMethodAnnotation = GetHttpMethodAnnotation(context.Parent.Parent as ClientGenerator.JavaParser.ClassBodyDeclarationContext);
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.TypeTypeContext typeTypeContext)
                    {
                        result.ReturnType = new ClassFieldsFinder().GetVariableType(typeTypeContext);
                    }
                    else if (childContext is ClientGenerator.JavaParser.IdentifierContext identifierContext)
                    {
                        result.Name = identifierContext.GetText();
                    }
                    else if (childContext is ClientGenerator.JavaParser.FormalParameterListContext formalParameterListContext)
                    {
                        result.formalParameters = GetFormalParameters(formalParameterListContext);
                    }
                    else if (childContext is ClientGenerator.JavaParser.MethodBodyContext methodBodyContext)
                    {
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return result;
        }
        
        public HttpMethodAnnotation GetHttpMethodAnnotation(ClientGenerator.JavaParser.ClassBodyDeclarationContext classBodyDeclarationContext)
        {
            HttpMethodAnnotation result = new HttpMethodAnnotation();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(classBodyDeclarationContext);
            while (queue.Count > 0)
            {
                var queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.AnnotationContext annotationContext)
                    {
                        result.Name = GetIdentifier(annotationContext);
                        result.HttpUrl = GetLiteral(annotationContext);
                    }
                    else if (childContext is ClientGenerator.JavaParser.MemberDeclarationContext memberDeclarationContext)
                    {
                        continue;
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return result;
        }

        public ArrayList<FormalParameter> GetFormalParameters(ClientGenerator.JavaParser.FormalParameterListContext context)
        {
            ArrayList<FormalParameter> result = new ArrayList<FormalParameter>();
            for (int i = 0; i < context.ChildCount; ++i)
            {
                var childContext = context.GetChild(i);
                if (childContext is ClientGenerator.JavaParser.FormalParameterContext formalParameterContext)
                {
                    result.Add(GetFormalParameter(formalParameterContext));
                }
            }

            return result;
        }

        public FormalParameter GetFormalParameter(ClientGenerator.JavaParser.FormalParameterContext context)
        {
            FormalParameter result = new FormalParameter();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.VariableModifierContext variableModifierContext)
                    {
                        result.HttpParameterAnnotation = GetIdentifier(childContext);
                    }
                    if (childContext is ClientGenerator.JavaParser.TypeTypeContext typeTypeContext)
                    {
                        result.Type = new ClassFieldsFinder().GetVariableType(typeTypeContext);
                    }
                    if (childContext is ClientGenerator.JavaParser.VariableDeclaratorIdContext variableDeclaratorIdContext)
                    {
                        result.Name = GetIdentifier(childContext);
                    }
                }
            }

            return result;
        }

        private string GetIdentifier(IParseTree context)
        {
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.IdentifierContext identifierContext)
                    {
                        return identifierContext.GetText();
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return null;
        }

        private string GetLiteral(IParseTree context)
        {
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.LiteralContext literalContext)
                    {
                        return literalContext.GetText();
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }
            return null;
        }
    }
}
