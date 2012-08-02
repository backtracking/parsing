using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JSourceUnmarshaller = com.habelitz.jsobjectizer.unmarshaller.JSourceUnmarshaller;
using JavaSource = com.habelitz.jsobjectizer.jsom.api.JavaSource;

using com.habelitz.jsobjectizer.unmarshaller.antlrbridge;
using com.habelitz.jsobjectizer.unmarshaller;
using com.habelitz.core;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.util;
using com.habelitz.jsobjectizer.jsom.api.statement;
using com.habelitz.jsobjectizer.jsom.api.expression;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;
using com.habelitz.jsobjectizer.jsom;

namespace JSourceObjectizerConsole
{
    public class TokenCollection<T>
    {
        private List<T> _tokenLines;

        public TokenCollection()
        {
            //_tokenLines.
        }

        public void Insert(T element, int posInLine)
        {

        }
    }

    public class SourceLineCollection
    {
        private List<TokenCollection<JSOM>> _srcLines;

        public SourceLineCollection(int capacity)
        {
            _srcLines = new List<TokenCollection<JSOM>>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                _srcLines.Add(new TokenCollection<JSOM>());
            }

        }

        public void Insert(JSOM jsom)
        {
            int line = jsom.getLineNumber();
            int posInLine = jsom.getCharPositionInLine();
            _srcLines[line].Insert(jsom, posInLine);
        }

    }

    public class TravAction : TraverseAction
    {
        private SourceLineCollection _srcLines;

        public TravAction(int lineCount)
        {
            _srcLines = new SourceLineCollection(lineCount);
        }

        public
        void actionPerformed(Annotation pAnnotation)
        {
            System.Diagnostics.Debug.WriteLine("Annotation");
        }

        
        public
        void actionPerformed(AnnotationDeclaration pAnnotationDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("AnnotationDeclaration");
        }

      
        public
        void actionPerformed(AnnotationElementValue pAnnotationElementValue)
        {
            System.Diagnostics.Debug.WriteLine("AnnotationElementValue");
        }

       
        public
        void actionPerformed(AnnotationInitializer pAnnotationInitializer)
        {
            System.Diagnostics.Debug.WriteLine("AnnotationInitializer");
        }

       
        public 
        void actionPerformed(
            AnnotationMethodDeclaration pAnnotationMethodDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("AnnotationMethodDeclaration");
        }

        public 
        void actionPerformed(
            AnnotationTopLevelScope pAnnotationTopLevelScope)
        {
            System.Diagnostics.Debug.WriteLine("AnnotationTopLevelScope");
        }

      
        public
        void actionPerformed(ArrayElementAccess pArrayElementAccess)
        {
            System.Diagnostics.Debug.WriteLine("ArrayElementAccess");
        }

       
        public
        void actionPerformed(ArrayTypeDeclarator pArrayTypeDeclarator)
        {
            System.Diagnostics.Debug.WriteLine("ArrayTypeDeclarator");
        }

       
        public
        void actionPerformed(AssertStatement pAssertStatement)
        {
            System.Diagnostics.Debug.WriteLine("AssertStatement");
        }

      
        public 
        void actionPerformed(
            BinaryOperatorExpression pBinaryOperatorExpression)
        {
            System.Diagnostics.Debug.WriteLine("BinaryOperatorExpression");
        }

        
        public
        void actionPerformed(BreakStatement pBreakStatement)
        {
            System.Diagnostics.Debug.WriteLine("BreakStatement");
        }

        public
        void actionPerformed(ClassConstructorCall pClassConstructorCall)
        {
            System.Diagnostics.Debug.WriteLine("ClassConstructorCall");
        }

       
        public
        void actionPerformed(ClassDeclaration pClassDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("ClassDeclaration");
        }

       
        public
        void actionPerformed(ClassExtendsClause pClassExtendsClause)
        {
            System.Diagnostics.Debug.WriteLine("ClassExtendsClause");
        }

       
        public
        void actionPerformed(ClassTopLevelScope pClassTopLevelScope)
        {
            string s = string.Format(
               "ClassTopLevelScope({0},{1})",
               pClassTopLevelScope.getLineNumber(),
               pClassTopLevelScope.getCharPositionInLine());

            System.Diagnostics.Debug.WriteLine(s);
        }

       
        public
        void actionPerformed(ComplexTypeIdentifier pTypeIdentifier)
        {
            System.Diagnostics.Debug.WriteLine("ComplexTypeIdentifier");
        }

       
        public
        void actionPerformed(ConditionalExpression pConditionalExpression)
        {
            System.Diagnostics.Debug.WriteLine("ConditionalExpression");
        }

       
        public
        void actionPerformed(ConstructorDefinition pConstructorDefinition)
        {
            System.Diagnostics.Debug.WriteLine("ConstructorDefinition");
        }

        public
        void actionPerformed(ContinueStatement pContinueStatement)
        {
            System.Diagnostics.Debug.WriteLine("ContinueStatement");
        }

       
        public
        void actionPerformed(DotExpression pDotExpression)
        {
            System.Diagnostics.Debug.WriteLine("DotExpression");
        }

       
        public
        void actionPerformed(EnumConstant pEnumConstant)
        {
            System.Diagnostics.Debug.WriteLine("EnumConstant");
        }

       
        public
        void actionPerformed(EnumDeclaration pEnumDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("EnumDeclaration");
        }

       
        public
        void actionPerformed(EnumTopLevelScope pEnumTopLevelScope)
        {
            System.Diagnostics.Debug.WriteLine("EnumTopLevelScope");
        }

        
        public 
        void actionPerformed(
            ExplicitConstructorCall pExplicitConstructorCall)
        {
            System.Diagnostics.Debug.WriteLine("ExplicitConstructorCall");
        }

       
        public
        void actionPerformed(ExpressionStatement pExpressionStatement)
        {
            System.Diagnostics.Debug.WriteLine("ExpressionStatement");
        }

       
        public
        void actionPerformed(ForEachStatement pForEachStatement)
        {
            System.Diagnostics.Debug.WriteLine("ForEachStatement");
        }

       
        public 
        void actionPerformed(
            FormalParameterDeclaration pFormalParameterDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("FormalParameterDeclaration");
        }

       
        public
        void actionPerformed(FormalParameterList pFormalParameterList)
        {
            System.Diagnostics.Debug.WriteLine("FormalParameterList");
        }

        
        public
        void actionPerformed(ForStatement pForStatement)
        {
            System.Diagnostics.Debug.WriteLine("ForStatement");
        }

       
        public
        void actionPerformed(GenericTypeArgument pGenericTypeArgument)
        {
            System.Diagnostics.Debug.WriteLine("GenericTypeArgument");
        }

       
        public
        void actionPerformed(GenericTypeParameter pGenericTypeParameter)
        {
            System.Diagnostics.Debug.WriteLine("GenericTypeParameter");
        }

        public
        void actionPerformed(Identifier pIdentifier)
        {
            System.Diagnostics.Debug.WriteLine("Identifier");
        }

       
        public
        void actionPerformed(IfStatement pIfStatement)
        {
            System.Diagnostics.Debug.WriteLine("IfStatement");
        }

        public
        void actionPerformed(ImplementsClause pImplementsClause)
        {
            System.Diagnostics.Debug.WriteLine("ImplementsClause");
        }

        
        public
        void actionPerformed(ImportDeclaration pImportDeclaration)
        {
            AST2ImportDeclaration importDecl = (AST2ImportDeclaration)pImportDeclaration;
           
            string s = string.Format(
               "ImportDeclaration({0},{1})",
               pImportDeclaration.getLineNumber(),
               pImportDeclaration.getCharPositionInLine());

            System.Diagnostics.Debug.WriteLine(s);
        }

        public
        void actionPerformed(InstanceofExpression pInstanceofExpression)
        {
            System.Diagnostics.Debug.WriteLine("InstanceofExpression");
        }

       
        public
        void actionPerformed(InterfaceDeclaration pInterfaceDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("InterfaceDeclaration");
        }

       
        public
        void actionPerformed(InterfaceExtendsClause pInterfaceExtendsClause)
        {
            System.Diagnostics.Debug.WriteLine("InterfaceExtendsClause");
        }

        public
        void actionPerformed(InterfaceTopLevelScope pInterfaceTopLevelScope)
        {
            System.Diagnostics.Debug.WriteLine("InterfaceTopLevelScope");
        }

       
        public
        void actionPerformed(JavaSource pJavaSource)
        {
            System.Diagnostics.Debug.WriteLine("JavaSource");
        }

       
        public
        void actionPerformed(LabeledStatement pLabeledStatement)
        {
            System.Diagnostics.Debug.WriteLine("LabeledStatement");
        }

        
        public
        void actionPerformed(Literal pLiteral)
        {
            System.Diagnostics.Debug.WriteLine("Literal");
        }

       
        public
        void actionPerformed(LocalClassDeclaration pLocalClassDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("LocalClassDeclaration");
        }

        
        public 
        void actionPerformed(
            LocalVariableDeclaration pLocalVariableDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("LocalVariableDeclaration");
        }

       
        public
        void actionPerformed(MethodCall pMethodCall)
        {
            System.Diagnostics.Debug.WriteLine("MethodCall");
        }

       
        public
        void actionPerformed(MethodDeclaration pMethodDeclaration)
        {
            string s = string.Format(
               "MethodDeclaration({0},{1})",
               pMethodDeclaration.getLineNumber(),
               pMethodDeclaration.getCharPositionInLine());

            System.Diagnostics.Debug.WriteLine(s);
        }

       
        public
        void actionPerformed(MethodDefinition pMethodDefinition)
        {
            string s = string.Format(
               "MethodDefinition({0},{1})",
               pMethodDefinition.getLineNumber(),
               pMethodDefinition.getCharPositionInLine());

            System.Diagnostics.Debug.WriteLine(s);
        }

        
        public
        void actionPerformed(ModifierList pModifierList)
        {
            System.Diagnostics.Debug.WriteLine("ModifierList");
        }

        public
        void actionPerformed(PackageDeclaration pPackageDeclaration)
        {
            string s = string.Format(
               "PackageDeclaration({0},{1})",
               pPackageDeclaration.getLineNumber(),
               pPackageDeclaration.getCharPositionInLine());

            System.Diagnostics.Debug.WriteLine(s);
        }

        public 
        void actionPerformed(
            ParenthesizedExpression pParenthesizedExpression)
        {
            System.Diagnostics.Debug.WriteLine("ParenthesizedExpression");
        }

        public 
        void actionPerformed(
            PrimaryExpressionKeyword pPrimaryExpressionKeyword)
        {
            System.Diagnostics.Debug.WriteLine("PrimaryExpressionKeyword");
        }

        
        public
        void actionPerformed(PrimitiveType pPrimitiveType)
        {
            System.Diagnostics.Debug.WriteLine("PrimitiveType");
        }

        
        public
        void actionPerformed(QualifiedIdentifier pQualifiedIdentifier)
        {
            string s = string.Format(
                "QualifiedIdentifier({0},{1}) : {2}",
                pQualifiedIdentifier.getLineNumber(),
                pQualifiedIdentifier.getCharPositionInLine(),
                pQualifiedIdentifier.ToString());

            System.Diagnostics.Debug.WriteLine(s);
        }

       
        public
        void actionPerformed(ReturnStatement pReturnStatement)
        {
            System.Diagnostics.Debug.WriteLine("ReturnStatement");
        }

        public
        void actionPerformed(StatementBlockScope pStatementBlockScope)
        {
            System.Diagnostics.Debug.WriteLine("StatementBlockScope");
        }

        
        public
        void actionPerformed(StaticArrayCreator pStaticArrayCreator)
        {
            System.Diagnostics.Debug.WriteLine("StaticArrayCreator");
        }

       
        public
        void actionPerformed(SwitchStatement pSwitchStatement)
        {
            System.Diagnostics.Debug.WriteLine("SwitchStatement");
        }

        
        public
        void actionPerformed(SwitchLabel pSwitchLabel)
        {
            System.Diagnostics.Debug.WriteLine("SwitchLabel");
        }

        
        public
        void actionPerformed(SynchronizedStatement pSynchronizedStatement)
        {
            System.Diagnostics.Debug.WriteLine("SynchronizedStatement");
        }

      
        public
        void actionPerformed(ThrowsClause pThrowsClause)
        {
            System.Diagnostics.Debug.WriteLine("ThrowsClause");
        }

       
        public
        void actionPerformed(ThrowStatement pThrowStatement)
        {
            System.Diagnostics.Debug.WriteLine("ThrowStatement");
        }

       
        public
        void actionPerformed(TryStatement pTryStatement)
        {
            System.Diagnostics.Debug.WriteLine("TryStatement");
        }

       
        public
        void actionPerformed(Catch pCatchClause)
        {
            System.Diagnostics.Debug.WriteLine("Catch");
        }

       
        public
        void actionPerformed(com.habelitz.jsobjectizer.jsom.api.Type pType)
        {
            System.Diagnostics.Debug.WriteLine("Type");
        }

        public
        void actionPerformed(TypeCast pTypeCast)
        {
            System.Diagnostics.Debug.WriteLine("TypeCast");
        }

      
        public
        void actionPerformed(TypeMemberDeclaration pTypeMemberDeclaration)
        {
            System.Diagnostics.Debug.WriteLine("TypeMemberDeclaration");
        }

        
        public 
        void actionPerformed(
            UnaryOperatorExpression pUnaryOperatorExpression)
        {
            System.Diagnostics.Debug.WriteLine("UnaryOperatorExpression");
        }

        
        public
        void actionPerformed(VariableDeclarator pVariableDeclarator)
        {
            System.Diagnostics.Debug.WriteLine("VariableDeclarator");
        }

        
        public 
        void actionPerformed(
            VariableDeclaratorIdentifier pVariableDeclaratorIdentifier)
        {
            System.Diagnostics.Debug.WriteLine("VariableDeclaratorIdentifier");
        }

       
        public
        void actionPerformed(VariableInitializer pVariableInitializer)
        {
            System.Diagnostics.Debug.WriteLine("VariableInitializer");
        }

        
        public
        void actionPerformed(WhileAndDoStatements pWhileAndDoStatements)
        {
            System.Diagnostics.Debug.WriteLine("WhileAndDoStatements");
        }

       
        public
        void actionPerformedForElseClause(IfStatement pIfStatement)
        {
            System.Diagnostics.Debug.WriteLine("IfStatement");
        }

        
        public
        bool isMemberTraversingEnabled()
        {
            //System.Diagnostics.Debug.WriteLine("isMemberTraversingEnabled");
            return true;
            
        }

       
        public
        void performAction(Annotation pAnnotation)
        {
            //System.Diagnostics.Debug.WriteLine("Annotation");
        }

       
        public
        void performAction(AnnotationDeclaration pAnnotationDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("AnnotationDeclaration");
        }

        
        public
        void performAction(AnnotationElementValue pAnnotationElementValue)
        {
            //System.Diagnostics.Debug.WriteLine("AnnotationElementValue");
        }

        
        public
        void performAction(AnnotationInitializer pAnnotationInitializer)
        {
            //System.Diagnostics.Debug.WriteLine("AnnotationInitializer");
        }

       
        public 
        void performAction(
            AnnotationMethodDeclaration pAnnotationMethodDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("AnnotationMethodDeclaration");
        }

       
        public
        void performAction(AnnotationTopLevelScope pAnnotationTopLevelScope)
        {
            //System.Diagnostics.Debug.WriteLine("AnnotationTopLevelScope");
        }

       
        public
        void performAction(ArrayElementAccess pArrayElementAccess)
        {
            //System.Diagnostics.Debug.WriteLine("ArrayElementAccess");
        }

        public
        void performAction(ArrayTypeDeclarator pArrayTypeDeclarator)
        {
            //System.Diagnostics.Debug.WriteLine("ArrayTypeDeclarator");
        }

       
        public
        void performAction(AssertStatement pAssertStatement)
        {
            //System.Diagnostics.Debug.WriteLine("AssertStatement");
        }

       
        public 
        void performAction(
            BinaryOperatorExpression pBinaryOperatorExpression)
        {
            //System.Diagnostics.Debug.WriteLine("BinaryOperatorExpression");
        }

       
        public
        void performAction(BreakStatement pBreakStatement)
        {
            //System.Diagnostics.Debug.WriteLine("BreakStatement");
        }

      
        public
        void performAction(ClassConstructorCall pClassConstructorCall)
        {
            //System.Diagnostics.Debug.WriteLine("ClassConstructorCall");
        }

       
        public
        void performAction(ClassDeclaration pClassDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("ClassDeclaration");
        }

      
        public
        void performAction(ClassExtendsClause pClassExtendsClause)
        {
            //System.Diagnostics.Debug.WriteLine("ClassExtendsClause");
        }

       
        public
        void performAction(ClassTopLevelScope pClassTopLevelScope)
        {
            //System.Diagnostics.Debug.WriteLine("ClassTopLevelScope");
        }

       
        public
        void performAction(ComplexTypeIdentifier pTypeIdentifier)
        {
            //System.Diagnostics.Debug.WriteLine("ComplexTypeIdentifier");
        }

       
        public
        void performAction(ConditionalExpression pConditionalExpression)
        {
            //System.Diagnostics.Debug.WriteLine("ConditionalExpression");
        }

        public
        void performAction(ConstructorDefinition pConstructorDefinition)
        {
            //System.Diagnostics.Debug.WriteLine("ConstructorDefinition");
        }

       
        public
        void performAction(ContinueStatement pContinueStatement)
        {
            //System.Diagnostics.Debug.WriteLine("ContinueStatement");
        }

        
        public
        void performAction(DotExpression pDotExpression)
        {
            //System.Diagnostics.Debug.WriteLine("DotExpression");
        }

      
        public
        void performAction(EnumConstant pEnumConstant)
        {
            //System.Diagnostics.Debug.WriteLine("EnumConstant");
        }

      
        public
        void performAction(EnumDeclaration pEnumDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("EnumDeclaration");
        }

       
        public
        void performAction(EnumTopLevelScope pEnumTopLevelScope)
        {
            //System.Diagnostics.Debug.WriteLine("EnumTopLevelScope");
        }

        
        public
        void performAction(ExplicitConstructorCall pExplicitConstructorCall)
        {
            //System.Diagnostics.Debug.WriteLine("ExplicitConstructorCall");
        }

       
        public
        void performAction(ExpressionStatement pExpressionStatement)
        {
            //System.Diagnostics.Debug.WriteLine("ExpressionStatement");
        }

        public
        void performAction(ForEachStatement pForEachStatement)
        {
            //System.Diagnostics.Debug.WriteLine("ForEachStatement");
        }

     
        public 
        void performAction(
            FormalParameterDeclaration pFormalParameterDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("FormalParameterDeclaration");
        }

       
        public
        void performAction(FormalParameterList pFormalParameterList)
        {
            //System.Diagnostics.Debug.WriteLine("FormalParameterList");
        }

      
        public
        void performAction(ForStatement pForStatement)
        {
            //System.Diagnostics.Debug.WriteLine("ForStatement");
        }

    
        public
        void performAction(GenericTypeArgument pGenericTypeArgument)
        {
            //System.Diagnostics.Debug.WriteLine("GenericTypeArgument");
        }

        
        public
        void performAction(GenericTypeParameter pGenericTypeParameter)
        {
            //System.Diagnostics.Debug.WriteLine("GenericTypeParameter");
        }

       
        public
        void performAction(Identifier pIdentifier)
        {
            //System.Diagnostics.Debug.WriteLine("Identifier");
        }

        public
        void performAction(IfStatement pIfStatement)
        {
            //System.Diagnostics.Debug.WriteLine("pIfStatement");
        }

     
        public
        void performAction(ImplementsClause pImplementsClause)
        {
            //System.Diagnostics.Debug.WriteLine("ImplementsClause");
        }

       
        public
        void performAction(ImportDeclaration pImportDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("ImportDeclaration");
        }

        
        public
        void performAction(InstanceofExpression pInstanceofExpression)
        {
            //System.Diagnostics.Debug.WriteLine("InstanceofExpression");
        }

       
        public
        void performAction(InterfaceDeclaration pInterfaceDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("InterfaceDeclaration");
        }

        
        public
        void performAction(InterfaceExtendsClause pInterfaceExtendsClause)
        {
            //System.Diagnostics.Debug.WriteLine("InterfaceExtendsClause");
        }

        
        public
        void performAction(InterfaceTopLevelScope pInterfaceTopLevelScope)
        {
            //System.Diagnostics.Debug.WriteLine("InterfaceTopLevelScope");
        }

       
        public
        void performAction(JavaSource pJavaSource)
        {
            //System.Diagnostics.Debug.WriteLine("JavaSource");
        }

     
        public
        void performAction(LabeledStatement pLabeledStatement)
        {
            //System.Diagnostics.Debug.WriteLine("LabeledStatement");
        }

       
        public
        void performAction(Literal pLiteral)
        {
            //System.Diagnostics.Debug.WriteLine("Literal");
        }

       
        public
        void performAction(LocalClassDeclaration pLocalClassDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("LocalClassDeclaration");
        }

       
        public 
        void performAction(
            LocalVariableDeclaration pLocalVariableDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("LocalVariableDeclaration");
        }

        
        public
        void performAction(MethodCall pMethodCall)
        {
            //System.Diagnostics.Debug.WriteLine("MethodCall");
        }

      
        public
        void performAction(MethodDeclaration pMethodDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("MethodDeclaration");
        }

       
        public
        void performAction(MethodDefinition pMethodDefinition)
        {
            //System.Diagnostics.Debug.WriteLine("MethodDefinition");
        }

        public
        void performAction(ModifierList pModifierList)
        {
            //System.Diagnostics.Debug.WriteLine("ModifierList");
        }

        public
        void performAction(PackageDeclaration pPackageDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("PackageDeclaration");
        }

        public
        void performAction(ParenthesizedExpression pParenthesizedExpression)
        {
            //System.Diagnostics.Debug.WriteLine("ParenthesizedExpression");
        }

       
        public 
        void performAction(
            PrimaryExpressionKeyword pPrimaryExpressionKeyword)
        {
            //System.Diagnostics.Debug.WriteLine("PrimaryExpressionKeyword");
        }

      
        public
        void performAction(PrimitiveType pPrimitiveType)
        {
            //System.Diagnostics.Debug.WriteLine("PrimitiveType");
        }

       
        public
        void performAction(QualifiedIdentifier pQualifiedIdentifier)
        {
            //System.Diagnostics.Debug.WriteLine("QualifiedIdentifier");
        }

       
        public
        void performAction(ReturnStatement pReturnStatement)
        {
            //System.Diagnostics.Debug.WriteLine("ReturnStatement");
        }

      
        public
        void performAction(StatementBlockScope pStatementBlockScope)
        {
            //System.Diagnostics.Debug.WriteLine("StatementBlockScope");
        }

        
        public
        void performAction(StaticArrayCreator pStaticArrayCreator)
        {
            //System.Diagnostics.Debug.WriteLine("StaticArrayCreator");
        }

       
        public
        void performAction(SwitchStatement pSwitchStatement)
        {
            //System.Diagnostics.Debug.WriteLine("SwitchStatement");
        }

       
        public
        void performAction(SwitchLabel pSwitchLabel)
        {
            //System.Diagnostics.Debug.WriteLine("SwitchLabel");
        }

      
        public
        void performAction(SynchronizedStatement pSynchronizedStatement)
        {
            //System.Diagnostics.Debug.WriteLine("SynchronizedStatement");
        }

       
        public
        void performAction(ThrowsClause pThrowsClause)
        {
            //System.Diagnostics.Debug.WriteLine("ThrowsClause");
        }

       
        public
        void performAction(ThrowStatement pThrowStatement)
        {
            //System.Diagnostics.Debug.WriteLine("ThrowStatement");
        }

       
        public
        void performAction(TryStatement pTryStatement)
        {
            //System.Diagnostics.Debug.WriteLine("TryStatement");
        }

      
        public
        void performAction(Catch pCatchClause)
        {
            //System.Diagnostics.Debug.WriteLine("Catch");
        }

     
        public
        void performAction(com.habelitz.jsobjectizer.jsom.api.Type pType)
        {
            //System.Diagnostics.Debug.WriteLine("Type");
        }

        
        public
        void performAction(TypeCast pTypeCast)
        {
            //System.Diagnostics.Debug.WriteLine("TypeCast");
        }

      
        public
        void performAction(TypeMemberDeclaration pTypeMemberDeclaration)
        {
            //System.Diagnostics.Debug.WriteLine("TypeMemberDeclaration");
        }

       
        public
        void performAction(UnaryOperatorExpression pUnaryOperatorExpression)
        {
            //System.Diagnostics.Debug.WriteLine("UnaryOperatorExpression");
        }

      
        public
        void performAction(VariableDeclarator pVariableDeclarator)
        {
            //System.Diagnostics.Debug.WriteLine("VariableDeclarator");
        }

       
        public 
        void performAction(
            VariableDeclaratorIdentifier pVariableDeclaratorIdentifier)
        {
            //System.Diagnostics.Debug.WriteLine("VariableDeclaratorIdentifier");
        }

       
        public
        void performAction(VariableInitializer pVariableInitializer)
        {
            //System.Diagnostics.Debug.WriteLine("VariableInitializer");
        }

       
        public
        void performAction(WhileAndDoStatements pWhileAndDoStatements)
        {
            //System.Diagnostics.Debug.WriteLine("WhileAndDoStatements");
        }

        
        public
        void performActionForElseClause(IfStatement pIfStatement)
        {
            //System.Diagnostics.Debug.WriteLine("IfStatement");
        }

        
        public
        void setMemberTraversingEnabledState(bool pNewState)
        {
            //System.Diagnostics.Debug.WriteLine("setMemberTraversingEnabledState");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            JavaSource javaSource = null;
            try
            {
                string pname = @"C:\Developer\cygwin\home\Vincent\projects\parsing\VisualStudioIntegration\Java Integration\Java.EditorExtensions\Test\ImapServiceServlet.java";
                JFile file = new JFile(pname);
                javaSource = new JSourceUnmarshaller().unmarshal(file, null);
            }
            catch (JSourceUnmarshallerException e)
            {
                System.Diagnostics.Debug.Write(e.Message);
            }
            if (javaSource != null)
            {
                int count = javaSource.getLineCount();
                javaSource.traverseAll(new TravAction(count));
                // do something with it
                List<ClassDeclaration> classes = javaSource.getClassDeclarations();
                if (classes != null)
                {
                    ClassDeclaration classDecl = classes[0];
                    string ident = classDecl.getIdentifier();
                    string s = classDecl.ToString();
                }

            }
        }
    }
}
