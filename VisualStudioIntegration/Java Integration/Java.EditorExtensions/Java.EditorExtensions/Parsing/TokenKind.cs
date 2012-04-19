/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

//abstract	continue	for	new	switch
//assert***	default	goto*	package	synchronized
//boolean	do	if	private	this
//break	double	implements	protected	throw
//byte	else	import	public	throws
//case	enum****	instanceof	return	transient
//catch	extends	int	short	try
//char	final	interface	static	void
//class	finally	long	strictfp**	volatile
//const*	float	native	super	while

namespace Java.EditorExtensions
{
    public enum TokenKind {
        EndOfFile = -1,
        Error = 0,
        NewLine = 1,
        Indent = 2,
        Dedent = 3,
        Comment = 4,
        Name = 8,
        Constant = 9,
        Ellipsis = 10,
        Arrow = 11,
        Dot = 31,


        Add = 32,
        AddEqual = 33,
        Subtract = 34,
        SubtractEqual = 35,
        Power = 36,
        PowerEqual = 37,
        Multiply = 38,
        MultiplyEqual = 39,
        FloorDivide = 40,
        FloorDivideEqual = 41,
        Divide = 42,
        DivideEqual = 43,
        Mod = 44,
        ModEqual = 45,
        LeftShift = 46,
        LeftShiftEqual = 47,
        RightShift = 48,
        RightShiftEqual = 49,
        BitwiseAnd = 50,
        BitwiseAndEqual = 51,
        BitwiseOr = 52,
        BitwiseOrEqual = 53,
        ExclusiveOr = 54,
        ExclusiveOrEqual = 55,
        LessThan = 56,
        GreaterThan = 57,
        LessThanOrEqual = 58,
        GreaterThanOrEqual = 59,
        Equals = 60,
        NotEquals = 61,
        LessThanGreaterThan = 62,
        LeftParenthesis = 63,
        RightParenthesis = 64,
        LeftBracket = 65,
        RightBracket = 66,
        LeftBrace = 67,
        RightBrace = 68,
        Comma = 69,
        Colon = 70,
        BackQuote = 71,
        Semicolon = 72,
        Assign = 73,
        Twiddle = 74,
        At = 75,

        FirstKeyword = KeywordAbstract,
        LastKeyword = KeywordTrue,
        KeywordAbstract = 76,
        KeywordAssert = 77,
        KeywordBoolean = 78,
        KeywordBreak = 79,
        KeywordByte = 80,
        KeywordCase = 81,
        KeywordCatch = 82,
        KeywordChar = 83,
        KeywordClass = 84,
        KeywordConst = 85,
        KeywordContinue = 86,
        KeywordDefault = 87,
        KeywordDo = 88,
        KeywordDouble = 89,
        KeywordElse = 90,
        KeywordEnum = 91,
        KeywordExtends = 92,
        KeywordFinally = 93,
        KeywordFloat = 94,
        KeywordFor = 95,
        KeywordGoto = 96,
        KeywordIf = 97,
        KeywordImplements = 98,
        KeywordImport = 99,
        KeywordInstanceof = 100,
        KeywordInt = 101,
        KeywordInterface = 102,
        KeywordLong = 103,
        KeywordNative = 104,
        KeywordNew = 105,
        KeywordPackage = 106,
        KeywordPrivate = 107,
        KeywordProtected = 108,
        KeywordPublic = 109,
        KeywordReturn = 110,
        KeywordShort = 111,
        KeywordStatic = 112,
        KeywordStrictfp = 113,
        KeywordSuper = 114,
        KeywordSynchronized = 115,
        KeywordSwitch = 116,
        KeywordThis = 117,
        KeywordThrow = 118,
        KeywordThrows = 119,
        KeywordTransient = 120,
        KeywordTry = 121,
        KeywordVoid = 122,
        KeywordVolatile = 123,
        KeywordWhile = 124,
        // Reserved words for literal values
        KeywordFalse = 125,
        KeywordNull = 126,
        KeywordTrue = 127,

        NLToken,
        ExplicitLineJoin
    }

    internal static class Tokens {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly Token EndOfFileToken = new VerbatimToken(TokenKind.EndOfFile, "", "<eof>");
        public static readonly Token ImpliedNewLineToken = new VerbatimToken(TokenKind.NewLine, "", "<newline>");
        public static readonly Token NewLineToken = new VerbatimToken(TokenKind.NewLine, "\n", "<newline>");
        public static readonly Token NewLineTokenCRLF = new VerbatimToken(TokenKind.NewLine, "\r\n", "<newline>");
        public static readonly Token NewLineTokenCR = new VerbatimToken(TokenKind.NewLine, "\r", "<newline>");
        public static readonly Token NLToken = new VerbatimToken(TokenKind.NLToken, "\n", "<NL>");  // virtual token used for error reporting
        public static readonly Token NLTokenCRLF = new VerbatimToken(TokenKind.NLToken, "\r\n", "<NL>");  // virtual token used for error reporting
        public static readonly Token NLTokenCR = new VerbatimToken(TokenKind.NLToken, "\r", "<NL>");  // virtual token used for error reporting
        public static readonly Token IndentToken = new DentToken(TokenKind.Indent, "<indent>");
        public static readonly Token DedentToken = new DentToken(TokenKind.Dedent, "<dedent>");
        public static readonly Token CommentToken = new SymbolToken(TokenKind.Comment, "<comment>");
        public static readonly Token NoneToken = new ConstantValueToken(null);
        public static readonly Token DotToken = new SymbolToken(TokenKind.Dot, ".");

        public static readonly Token Ellipsis = new SymbolToken(TokenKind.Ellipsis, "...");

        #region Generated Tokens

        // *** BEGIN GENERATED CODE ***
        // generated by function: tokens_generator from: generate_ops.py

        private static readonly Token symAddToken = new OperatorToken(TokenKind.Add, "+", 4);
        private static readonly Token symAddEqualToken = new StatementSymbolToken(TokenKind.AddEqual, "+=");
        private static readonly Token symSubtractToken = new OperatorToken(TokenKind.Subtract, "-", 4);
        private static readonly Token symSubtractEqualToken = new StatementSymbolToken(TokenKind.SubtractEqual, "-=");
        private static readonly Token symPowerToken = new OperatorToken(TokenKind.Power, "**", 6);
        private static readonly Token symPowerEqualToken = new StatementSymbolToken(TokenKind.PowerEqual, "**=");
        private static readonly Token symMultiplyToken = new OperatorToken(TokenKind.Multiply, "*", 5);
        private static readonly Token symMultiplyEqualToken = new SymbolToken(TokenKind.MultiplyEqual, "*=");
        private static readonly Token symFloorDivideToken = new OperatorToken(TokenKind.FloorDivide, "//", 5);
        private static readonly Token symFloorDivideEqualToken = new StatementSymbolToken(TokenKind.FloorDivideEqual, "//=");
        private static readonly Token symDivideToken = new OperatorToken(TokenKind.Divide, "/", 5);
        private static readonly Token symDivideEqualToken = new StatementSymbolToken(TokenKind.DivideEqual, "/=");
        private static readonly Token symModToken = new OperatorToken(TokenKind.Mod, "%", 5);
        private static readonly Token symModEqualToken = new StatementSymbolToken(TokenKind.ModEqual, "%=");
        private static readonly Token symLeftShiftToken = new OperatorToken(TokenKind.LeftShift, "<<", 3);
        private static readonly Token symLeftShiftEqualToken = new StatementSymbolToken(TokenKind.LeftShiftEqual, "<<=");
        private static readonly Token symRightShiftToken = new OperatorToken(TokenKind.RightShift, ">>", 3);
        private static readonly Token symRightShiftEqualToken = new StatementSymbolToken(TokenKind.RightShiftEqual, ">>=");
        private static readonly Token symBitwiseAndToken = new OperatorToken(TokenKind.BitwiseAnd, "&", 2);
        private static readonly Token symBitwiseAndEqualToken = new StatementSymbolToken(TokenKind.BitwiseAndEqual, "&=");
        private static readonly Token symBitwiseOrToken = new OperatorToken(TokenKind.BitwiseOr, "|", 0);
        private static readonly Token symBitwiseOrEqualToken = new StatementSymbolToken(TokenKind.BitwiseOrEqual, "|=");
        private static readonly Token symExclusiveOrToken = new OperatorToken(TokenKind.ExclusiveOr, "^", 1);
        private static readonly Token symExclusiveOrEqualToken = new StatementSymbolToken(TokenKind.ExclusiveOrEqual, "^=");
        private static readonly Token symLessThanToken = new OperatorToken(TokenKind.LessThan, "<", -1);
        private static readonly Token symGreaterThanToken = new OperatorToken(TokenKind.GreaterThan, ">", -1);
        private static readonly Token symLessThanOrEqualToken = new OperatorToken(TokenKind.LessThanOrEqual, "<=", -1);
        private static readonly Token symGreaterThanOrEqualToken = new OperatorToken(TokenKind.GreaterThanOrEqual, ">=", -1);
        private static readonly Token symEqualsToken = new OperatorToken(TokenKind.Equals, "==", -1);
        private static readonly Token symNotEqualsToken = new OperatorToken(TokenKind.NotEquals, "!=", -1);
        private static readonly Token symLessThanGreaterThanToken = new SymbolToken(TokenKind.LessThanGreaterThan, "<>");
        private static readonly Token symLeftParenthesisToken = new SymbolToken(TokenKind.LeftParenthesis, "(");
        private static readonly Token symRightParenthesisToken = new SymbolToken(TokenKind.RightParenthesis, ")");
        private static readonly Token symLeftBracketToken = new SymbolToken(TokenKind.LeftBracket, "[");
        private static readonly Token symRightBracketToken = new SymbolToken(TokenKind.RightBracket, "]");
        private static readonly Token symLeftBraceToken = new SymbolToken(TokenKind.LeftBrace, "{");
        private static readonly Token symRightBraceToken = new SymbolToken(TokenKind.RightBrace, "}");
        private static readonly Token symCommaToken = new SymbolToken(TokenKind.Comma, ",");
        private static readonly Token symColonToken = new SymbolToken(TokenKind.Colon, ":");
        private static readonly Token symBackQuoteToken = new SymbolToken(TokenKind.BackQuote, "`");
        private static readonly Token symSemicolonToken = new SymbolToken(TokenKind.Semicolon, ";");
        private static readonly Token symAssignToken = new SymbolToken(TokenKind.Assign, "=");
        private static readonly Token symTwiddleToken = new SymbolToken(TokenKind.Twiddle, "~");
        private static readonly Token symAtToken = new StatementSymbolToken(TokenKind.At, "@");
        private static readonly Token symArrowToken = new SymbolToken(TokenKind.Arrow, "->");

        public static Token AddToken {
            get { return symAddToken; }
        }

        public static Token AddEqualToken {
            get { return symAddEqualToken; }
        }

        public static Token SubtractToken {
            get { return symSubtractToken; }
        }

        public static Token SubtractEqualToken {
            get { return symSubtractEqualToken; }
        }

        public static Token PowerToken {
            get { return symPowerToken; }
        }

        public static Token PowerEqualToken {
            get { return symPowerEqualToken; }
        }

        public static Token MultiplyToken {
            get { return symMultiplyToken; }
        }

        public static Token MultiplyEqualToken {
            get { return symMultiplyEqualToken; }
        }

        public static Token FloorDivideToken {
            get { return symFloorDivideToken; }
        }

        public static Token FloorDivideEqualToken {
            get { return symFloorDivideEqualToken; }
        }

        public static Token DivideToken {
            get { return symDivideToken; }
        }

        public static Token DivideEqualToken {
            get { return symDivideEqualToken; }
        }

        public static Token ModToken {
            get { return symModToken; }
        }

        public static Token ModEqualToken {
            get { return symModEqualToken; }
        }

        public static Token LeftShiftToken {
            get { return symLeftShiftToken; }
        }

        public static Token LeftShiftEqualToken {
            get { return symLeftShiftEqualToken; }
        }

        public static Token RightShiftToken {
            get { return symRightShiftToken; }
        }

        public static Token RightShiftEqualToken {
            get { return symRightShiftEqualToken; }
        }

        public static Token BitwiseAndToken {
            get { return symBitwiseAndToken; }
        }

        public static Token BitwiseAndEqualToken {
            get { return symBitwiseAndEqualToken; }
        }

        public static Token BitwiseOrToken {
            get { return symBitwiseOrToken; }
        }

        public static Token BitwiseOrEqualToken {
            get { return symBitwiseOrEqualToken; }
        }

        public static Token ExclusiveOrToken {
            get { return symExclusiveOrToken; }
        }

        public static Token ExclusiveOrEqualToken {
            get { return symExclusiveOrEqualToken; }
        }

        public static Token LessThanToken {
            get { return symLessThanToken; }
        }

        public static Token GreaterThanToken {
            get { return symGreaterThanToken; }
        }

        public static Token LessThanOrEqualToken {
            get { return symLessThanOrEqualToken; }
        }

        public static Token GreaterThanOrEqualToken {
            get { return symGreaterThanOrEqualToken; }
        }

        public static Token EqualsToken {
            get { return symEqualsToken; }
        }

        public static Token NotEqualsToken {
            get { return symNotEqualsToken; }
        }

        public static Token LessThanGreaterThanToken {
            get { return symLessThanGreaterThanToken; }
        }

        public static Token LeftParenthesisToken {
            get { return symLeftParenthesisToken; }
        }

        public static Token RightParenthesisToken {
            get { return symRightParenthesisToken; }
        }

        public static Token LeftBracketToken {
            get { return symLeftBracketToken; }
        }

        public static Token RightBracketToken {
            get { return symRightBracketToken; }
        }

        public static Token LeftBraceToken {
            get { return symLeftBraceToken; }
        }

        public static Token RightBraceToken {
            get { return symRightBraceToken; }
        }

        public static Token CommaToken {
            get { return symCommaToken; }
        }

        public static Token ColonToken {
            get { return symColonToken; }
        }

        public static Token BackQuoteToken {
            get { return symBackQuoteToken; }
        }

        public static Token SemicolonToken {
            get { return symSemicolonToken; }
        }

        public static Token AssignToken {
            get { return symAssignToken; }
        }

        public static Token TwiddleToken {
            get { return symTwiddleToken; }
        }

        public static Token AtToken {
            get { return symAtToken; }
        }

        public static Token ArrowToken {
            get {
                return symArrowToken;
            }
        }

       
        private static readonly Token kwAbstractToken = new SymbolToken(TokenKind.KeywordAbstract, "abstract");
        private static readonly Token kwAssertToken = new SymbolToken(TokenKind.KeywordAssert, "assert");
        private static readonly Token kwBooleanToken = new SymbolToken(TokenKind.KeywordBoolean, "boolean");
        private static readonly Token kwBreakToken = new SymbolToken(TokenKind.KeywordBreak, "break");
        private static readonly Token kwByteToken = new SymbolToken(TokenKind.KeywordByte, "byte");
        private static readonly Token kwCaseToken = new SymbolToken(TokenKind.KeywordCase, "case");
        private static readonly Token kwCatchToken = new SymbolToken(TokenKind.KeywordCatch, "catch");
        private static readonly Token kwCharToken = new SymbolToken(TokenKind.KeywordChar, "char");
        private static readonly Token kwClassToken = new SymbolToken(TokenKind.KeywordClass, "class");
        private static readonly Token kwConstToken = new SymbolToken(TokenKind.KeywordConst, "const");
        private static readonly Token kwContinueToken = new SymbolToken(TokenKind.KeywordContinue, "continue");
        private static readonly Token kwDefaultToken = new SymbolToken(TokenKind.KeywordDefault, "default");
        private static readonly Token kwDoToken = new SymbolToken(TokenKind.KeywordDo, "do");
        private static readonly Token kwDoubleToken = new SymbolToken(TokenKind.KeywordDouble, "double");
        private static readonly Token kwElseToken = new SymbolToken(TokenKind.KeywordElse, "else");
        private static readonly Token kwEnumToken = new SymbolToken(TokenKind.KeywordEnum, "enum");
        private static readonly Token kwExtendsToken = new SymbolToken(TokenKind.KeywordExtends, "extends");
        private static readonly Token kwFinallyToken = new SymbolToken(TokenKind.KeywordFinally, "finally");
        private static readonly Token kwFloatToken = new SymbolToken(TokenKind.KeywordFloat, "float");
        private static readonly Token kwForToken = new SymbolToken(TokenKind.KeywordFor, "for");
        private static readonly Token kwGotoToken = new SymbolToken(TokenKind.KeywordGoto, "goto");
        private static readonly Token kwIfToken = new SymbolToken(TokenKind.KeywordIf, "if");
        private static readonly Token kwInstanceofToken = new SymbolToken(TokenKind.KeywordInstanceof, "instanceof");
        private static readonly Token kwImportToken = new SymbolToken(TokenKind.KeywordImport, "import");
        private static readonly Token kwImplementsToken = new SymbolToken(TokenKind.KeywordImplements, "implements");
        private static readonly Token kwIntToken = new SymbolToken(TokenKind.KeywordInt, "int");
        private static readonly Token kwInterfaceToken = new SymbolToken(TokenKind.KeywordInterface, "interface");
        private static readonly Token kwLongToken = new SymbolToken(TokenKind.KeywordLong, "long");
        private static readonly Token kwNativeToken = new SymbolToken(TokenKind.KeywordNative, "native");
        private static readonly Token kwNewToken = new SymbolToken(TokenKind.KeywordNew, "new");
        private static readonly Token kwPackageToken = new SymbolToken(TokenKind.KeywordPackage, "package");
        private static readonly Token kwPrivateToken = new SymbolToken(TokenKind.KeywordPrivate, "private");
        private static readonly Token kwProtectedToken = new SymbolToken(TokenKind.KeywordProtected, "protected");
        private static readonly Token kwPublicToken = new SymbolToken(TokenKind.KeywordPublic, "public");
        private static readonly Token kwReturnToken = new SymbolToken(TokenKind.KeywordReturn, "return");
        private static readonly Token kwShortToken = new SymbolToken(TokenKind.KeywordShort, "short");
        private static readonly Token kwStaticToken = new SymbolToken(TokenKind.KeywordStatic, "static");
        private static readonly Token kwStrictfpToken = new SymbolToken(TokenKind.KeywordStrictfp, "strictfp");
        private static readonly Token kwSuperToken = new SymbolToken(TokenKind.KeywordSuper, "super");
        private static readonly Token kwSynchronizedToken = new SymbolToken(TokenKind.KeywordSynchronized, "synchronized");
        private static readonly Token kwSwitchToken = new SymbolToken(TokenKind.KeywordSwitch, "switch");
        private static readonly Token kwThisToken = new SymbolToken(TokenKind.KeywordThis, "this");
        private static readonly Token kwThrowToken = new SymbolToken(TokenKind.KeywordThrow, "throw");
        private static readonly Token kwThrowsToken = new SymbolToken(TokenKind.KeywordThrows, "throws");
        private static readonly Token kwTransientToken = new SymbolToken(TokenKind.KeywordTransient, "transient");
        private static readonly Token kwTryToken = new SymbolToken(TokenKind.KeywordTry, "try");
        private static readonly Token kwVoidToken = new SymbolToken(TokenKind.KeywordVoid, "void");
        private static readonly Token kwVolatileToken = new SymbolToken(TokenKind.KeywordVolatile, "volatile");
        private static readonly Token kwWhileToken = new SymbolToken(TokenKind.KeywordWhile, "while");
        private static readonly Token kwFalseToken = new SymbolToken(TokenKind.KeywordFalse, "false");
        private static readonly Token kwNullToken = new SymbolToken(TokenKind.KeywordNull, "null");
        private static readonly Token kwTrueToken = new SymbolToken(TokenKind.KeywordTrue, "true");


        public static Token KeywordAbstractToken    { get { return kwAbstractToken; } }
        public static Token KeywordAssertToken      { get { return kwAssertToken; } }
        public static Token KeywordBooleanToken     { get { return kwBooleanToken; } }
        public static Token KeywordBreakToken       { get { return kwBreakToken; } }
        public static Token KeywordByteToken        { get { return kwByteToken; } }
        public static Token KeywordCaseToken        { get { return kwCaseToken; } }
        public static Token KeywordCatchToken       { get { return kwCatchToken; } }
        public static Token KeywordCharToken        { get { return kwCharToken; } }
        public static Token KeywordClassToken       { get { return kwClassToken; } }
        public static Token KeywordConstToken       { get { return kwConstToken; } }
        public static Token KeywordContinueToken    { get { return kwContinueToken; } }
        public static Token KeywordDefaultToken     { get { return kwDefaultToken; } }
        public static Token KeywordDoToken          { get { return kwDoToken; } }
        public static Token KeywordDoubleToken      { get { return kwDoubleToken; } }
        public static Token KeywordElseToken        { get { return kwElseToken; } }
        public static Token KeywordEnumToken        { get { return kwEnumToken; } }
        public static Token KeywordExtendsToken     { get { return kwExtendsToken; } }
        public static Token KeywordFinallyToken     { get { return kwFinallyToken; } }
        public static Token KeywordFloatToken       { get { return kwFloatToken; } }
        public static Token KeywordForToken         { get { return kwForToken; } }
        public static Token KeywordGotoToken        { get { return kwGotoToken; } }
        public static Token KeywordIfToken          { get { return kwIfToken; } }
        public static Token KeywordInstanceofToken  { get { return kwInstanceofToken; } }
        public static Token KeywordImplementsToken  { get { return kwImplementsToken; } }
        public static Token KeywordImportToken      { get { return kwImportToken; } }
        public static Token KeywordIntToken         { get { return kwIntToken; } }
        public static Token KeywordInterfaceToken   { get { return kwInterfaceToken; } }
        public static Token KeywordLongToken        { get { return kwLongToken; } }
        public static Token KeywordNativeToken      { get { return kwNativeToken; } }
        public static Token KeywordNewToken         { get { return kwNewToken; } }
        public static Token KeywordPackageToken     { get { return kwPackageToken; } }
        public static Token KeywordPrivateToken     { get { return kwPrivateToken; } }
        public static Token KeywordProtectedToken   { get { return kwProtectedToken; } }
        public static Token KeywordPublicToken      { get { return kwPublicToken; } }
        public static Token KeywordReturnToken      { get { return kwReturnToken; } }
        public static Token KeywordShortToken       { get { return kwShortToken; } }
        public static Token KeywordStaticToken      { get { return kwStaticToken; } }
        public static Token KeywordStrictfpToken    { get { return kwStrictfpToken; } }
        public static Token KeywordSuperToken       { get { return kwSuperToken; } }
        public static Token KeywordSynchronizedToken { get { return kwSynchronizedToken; } }
        public static Token KeywordSwitchToken      { get { return kwSwitchToken; } }
        public static Token KeywordThisToken        { get { return kwThisToken; } }
        public static Token KeywordThrowToken       { get { return kwThrowToken; } }
        public static Token KeywordThrowsToken      { get { return kwThrowsToken; } }
        public static Token KeywordTransientToken   { get { return kwTransientToken; } }
        public static Token KeywordTryToken         { get { return kwTryToken; } }
        public static Token KeywordVoidToken        { get { return kwVoidToken; } }
        public static Token KeywordVolatileToken    { get { return kwVolatileToken; } }
        public static Token KeywordWhileToken       { get { return kwWhileToken; } }
        public static Token KeywordFalseToken       { get { return kwFalseToken; } }
        public static Token KeywordNullToken        { get { return kwNullToken; } }
        public static Token KeywordTrueToken        { get { return kwTrueToken; } }      
       

        #endregion
    }
}
