using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ClientGenerator.Entities;

namespace AntlrTemplate
{
    public class ClassFieldsFinder
    {
        public ClassWithFields GetClassWithFields(IParseTree context)
        {
            ClassWithFields result = new ClassWithFields();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.ClassDeclarationContext classDeclarationContext)
                    {
                        result.Name = GetIdentifier(childContext);
                        result.Fields = GetClassFields(classDeclarationContext);
                        queue.Clear();
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return result;
        }

        public ArrayList<ClassField> GetClassFields(ClientGenerator.JavaParser.ClassDeclarationContext context)
        {
            ArrayList<ClassField> result = new ArrayList<ClassField>();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(context);
            while (queue.Count > 0)
            {
                IParseTree queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.FieldDeclarationContext fieldDeclarationContext)
                    {
                        result.Add(GetClassField(fieldDeclarationContext));
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return result;
        }

        public ClassField GetClassField(ClientGenerator.JavaParser.FieldDeclarationContext fieldDeclarationContext)
        {
            ClassField result = new ClassField();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(fieldDeclarationContext);
            while (queue.Count > 0)
            {
                var queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.TypeTypeContext typeTypeContext)
                    {
                        result.Type = GetVariableType(typeTypeContext);
                    }
                    else if (childContext is ClientGenerator.JavaParser.VariableDeclaratorContext variableDeclaratorContext)
                    {
                        result.Name = GetVariableName(variableDeclaratorContext);
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }
            return result;
        }

        public TypeTree GetVariableType(ClientGenerator.JavaParser.TypeTypeContext typeTypeContext)
        {
            TypeTree result = new TypeTree();
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(typeTypeContext);
            while (queue.Count > 0)
            {
                /*var queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.ClassOrInterfaceTypeContext || childContext is ClientGenerator.JavaParser.PrimitiveTypeContext)
                    {
                        if (childContext.ChildCount == 1)
                        {
                            result.Name = GetIdentifier(childContext);
                        }
                        else
                        {
                            result.GenericContainerNames.Add(GetIdentifier(childContext));
                            queue.Enqueue(childContext.GetChild(1));
                        }
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }*/
                var queueContext = queue.Dequeue();
                for (int i = 0; i < queueContext.ChildCount; ++i)
                {
                    var childContext = queueContext.GetChild(i);
                    if (childContext is ClientGenerator.JavaParser.IdentifierContext || childContext is ClientGenerator.JavaParser.PrimitiveTypeContext)
                    {
                        result.Name = childContext.GetText();
                    }
                    else if (childContext is ClientGenerator.JavaParser.TypeTypeContext innerTypeContext)
                    {
                        result.InnerTypes.Add(GetVariableType(innerTypeContext));
                    }
                    else
                    {
                        queue.Enqueue(childContext);
                    }
                }
            }

            return result;
        }

        public string GetVariableName(ClientGenerator.JavaParser.VariableDeclaratorContext variableDeclaratorContext)
        {
            Queue<IParseTree> queue = new Queue<IParseTree>();
            queue.Enqueue(variableDeclaratorContext);
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

        private string GetIdentifier(IParseTree context)
        {
            for (int i = 0; i < context.ChildCount; ++i)
            {
                if (context.GetChild(i) is ClientGenerator.JavaParser.IdentifierContext identifierContext)
                {
                    return identifierContext.GetText();
                }
            }

            return null;
        }

    }
}
