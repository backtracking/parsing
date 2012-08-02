using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smartmobili.VisualStudio.Core;
using Antlr.Runtime;

namespace Java.EditorExtensions
{
    public class TokenFactory
    {
        public static Token2 CreateToken(IToken token)
        {
            int length = token.StopIndex - token.StartIndex + 1;
            int startPosition = token.StartIndex;
            int endPosition = token.StopIndex;
            switch (token.Type)
            {
                case JavaLexer.IDENT:
                    return new IdentifierToken(token.Type, startPosition, endPosition);

                case JavaLexer.DECIMAL_LITERAL:
                case JavaLexer.FLOATING_POINT_LITERAL:
                    return new NumericLiteralToken(token.Type, startPosition, endPosition);

                case JavaLexer.STRING_LITERAL:
                    return new StringLiteralToken(token.Type, startPosition, endPosition);

                case JavaLexer.BLOCK_COMMENT:
                case JavaLexer.LINE_COMMENT:
                case JavaLexer.JAVADOC_COMMENT:
                    return new CommentLiteralToken(token.Type, startPosition, endPosition);

                case JavaLexer.RETURN:
                case JavaLexer.PACKAGE:
                case JavaLexer.IMPORT:
                case JavaLexer.ABSTRACT:
                case JavaLexer.CLASS:
                case JavaLexer.IMPLEMENTS:
                case JavaLexer.INSTANCEOF:
                case JavaLexer.SUPER:
                case JavaLexer.PUBLIC:
                case JavaLexer.PRIVATE:
                case JavaLexer.PROTECTED:
                case JavaLexer.STATIC:
                case JavaLexer.FINAL:
                case JavaLexer.EXTENDS:
                case JavaLexer.NEW:
                case JavaLexer.THIS:
                case JavaLexer.ASSERT:
                case JavaLexer.GOTO:
                case JavaLexer.IF:
                case JavaLexer.ELSE:
                case JavaLexer.SYNCHRONIZED:
                case JavaLexer.TRY:
                case JavaLexer.CATCH:
                case JavaLexer.FINALLY:
                case JavaLexer.THROW:
                case JavaLexer.THROWS:
                case JavaLexer.FOR:
                case JavaLexer.DO:
                case JavaLexer.WHILE:
                case JavaLexer.SWITCH:
                case JavaLexer.BREAK:
                case JavaLexer.CONTINUE:
                case JavaLexer.DEFAULT:
                case JavaLexer.ENUM:
                case JavaLexer.CONST:
                case JavaLexer.NATIVE:
                case JavaLexer.VOID:
                case JavaLexer.BOOLEAN:
                case JavaLexer.BYTE:
                case JavaLexer.INT:
                case JavaLexer.LONG:
                case JavaLexer.FLOAT:
                case JavaLexer.DOUBLE:
                case JavaLexer.CHAR:
                case JavaLexer.CHARACTER_LITERAL:
                case JavaLexer.TRUE:
                case JavaLexer.FALSE:
                case JavaLexer.NULL:
                    return new KeywordToken(token.Type, startPosition, endPosition);

                case JavaLexer.ASSIGN:
                case JavaLexer.COMMA:
                case JavaLexer.SEMI:
                case JavaLexer.LPAREN:
                case JavaLexer.RPAREN:
                case JavaLexer.LCURLY:
                case JavaLexer.RCURLY:
                case JavaLexer.LBRACK:
                case JavaLexer.RBRACK:
                case JavaLexer.COLON:
                case JavaLexer.DOT:
                case JavaLexer.DOTSTAR:
                case JavaLexer.GREATER_OR_EQUAL:
                case JavaLexer.GREATER_THAN:
                case JavaLexer.LESS_OR_EQUAL:
                case JavaLexer.LESS_THAN:
                case JavaLexer.STAR:
                case JavaLexer.EQUAL:
                case JavaLexer.NOT_EQUAL:
                case JavaLexer.DEC:
                case JavaLexer.INC:
                case JavaLexer.PLUS:
                case JavaLexer.PLUS_ASSIGN:
                case JavaLexer.MINUS:
                case JavaLexer.MINUS_ASSIGN:
                case JavaLexer.DIV:
                case JavaLexer.DIV_ASSIGN:
                case JavaLexer.POST_DEC:
                case JavaLexer.POST_INC:
                case JavaLexer.PRE_DEC:
                case JavaLexer.PRE_INC:
                case JavaLexer.SHIFT_LEFT:
                case JavaLexer.SHIFT_LEFT_ASSIGN:
                case JavaLexer.SHIFT_RIGHT:
                case JavaLexer.SHIFT_RIGHT_ASSIGN:
                case JavaLexer.LOGICAL_AND:
                case JavaLexer.LOGICAL_NOT:
                case JavaLexer.LOGICAL_OR:
                    return new OperatorToken(token.Type, startPosition, endPosition);
                

            }
            //System.Diagnostics.Debug.WriteLine(string.Format("case JavaLexer.{0}:"), );
            return new InvalidToken(token.Type, startPosition, endPosition);
        }
    }
}
