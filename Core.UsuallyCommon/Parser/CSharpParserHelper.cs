using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public class CSharpParserHelper
    {
        public CSharpParserHelper(String context)
        {
            root = CSharpSyntaxTree.ParseText(context).GetCompilationUnitRoot();
            collector = new ObjectCollector();
            collector.Visit(root);
        }
        public CompilationUnitSyntax root { get; set; }
        public ObjectCollector collector { get; set; }


        public List<string> GetUsing()
        { 
            var list = new List<string>();
            foreach (var item in collector.Usings)
            {
                list.Add(item.Name.ToStringExtension());
            } 
            return list; 
        }

        public void GetClass()
        {
            var s = collector.classList;
            var p  = s.FirstOrDefault().Protertys;
        }
    }


    public class Classs
    {
        public Classs()
        {
            Methods = new List<Method>();
            Protertys = new List<Proterty>();
        }
        public string Name { get; set; }

        public string Comment { get; set; }

        public List<Method> Methods { get; set; }

        public List<Proterty> Protertys { get; set; }
    }

    public class Proterty
    {
        public string ClassName { get; set; }
        public string Name { get; set; } 
        public string Comment { get; set; } 
        public string ProtertyType { get; set; } 
    }

    public class Method
    {

        public Method()
        {
            MethodArguments = new List<MethodArgument>();
        }
        public string ClassName { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; } 

        public string ReturnType { get; set; }

        public List<MethodArgument> MethodArguments { get; set; }
    }

    public class MethodArgument
    {
        public string ClassName { get; set; }

        public string MethodName { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public string ArgumentType { get; set; }
    }

    public class ObjectCollector : CSharpSyntaxWalker
    {
        public ICollection<UsingDirectiveSyntax> Usings { get; } = new List<UsingDirectiveSyntax>();
        // </Snippet4>
        public ICollection<ClassDeclarationSyntax> Classs { get; } = new List<ClassDeclarationSyntax>();

        public List<Classs> classList = new List<Classs>();

        // <SNippet5>
        public override void VisitUsingDirective(UsingDirectiveSyntax node)
        {
            this.Usings.Add(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var trivia = node.GetLeadingTrivia().FirstOrDefault(x=>x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia || x.Kind() == SyntaxKind.SingleLineCommentTrivia);
            var name = node.Identifier.Value.ToStringExtension();
            var comment = trivia.Token.LeadingTrivia.ToStringExtension();
            Classs.Add(node);

            var classs = new Classs() { Name = name, Comment = comment };
            foreach (var item in node.Members)
            {
                if(item.GetType() == typeof(PropertyDeclarationSyntax))
                {
                    var proterty = item as PropertyDeclarationSyntax;
                    var protertyComment = proterty.GetLeadingTrivia().FirstOrDefault(x => x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia 
                    || x.Kind() == SyntaxKind.SingleLineCommentTrivia).Token.LeadingTrivia.ToStringExtension();
                    var protertys = new Proterty() {  ClassName = name,ProtertyType=proterty.Type.ToString(), Comment = protertyComment, Name= proterty.Identifier.ValueText};
                    classs.Protertys.Add(protertys);
                }
                if (item.GetType() == typeof(MethodDeclarationSyntax))
                {
                    var methods = item as MethodDeclarationSyntax;
                    var returnType = ((Microsoft.CodeAnalysis.CSharp.Syntax.PredefinedTypeSyntax)methods.ReturnType).Keyword.ValueText;
                    var methodComment =   methods.GetLeadingTrivia().FirstOrDefault(x => x.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia
                    || x.Kind() == SyntaxKind.SingleLineCommentTrivia).Token.LeadingTrivia.ToStringExtension();

                    Method methodClass = new Method() {  ClassName = name,
                     Name = methods.Identifier.ValueText, ReturnType = returnType, Comment = methodComment
                    };

                    var paramsList = methods.ParameterList.Parameters;
                    foreach (var iparams in paramsList)
                    {
                         MethodArgument methodArgument = new MethodArgument() {  Name = iparams.Identifier.ValueText,
                         ArgumentType = iparams.Type.ToStringExtension(),
                         ClassName = name,
                         MethodName = methods.Identifier.ValueText,
                        };
                        methodClass.MethodArguments.Add(methodArgument);

                    }

                    classs.Methods.Add(methodClass);
                }
            }

            classList.Add(classs);
        } 
    }
}
