// $ANTLR 3.4 /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g 2012-02-11 10:35:16

  package smartmobili.lang.objc;


import org.antlr.runtime.*;
import java.util.Stack;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;
import java.util.HashMap;

import org.antlr.runtime.tree.*;


/**
* ObjectiveC version 2
* based on an LL ansic grammars and
* and ObjectiveC grammar found in Learning Object C
*
* It's a Work in progress, most of the .h file can be parsed
* June 2008 Cedric Cuche
**/
@SuppressWarnings({"all", "warnings", "unchecked"})
public class ObjectiveCParser extends Parser {
    public static final String[] tokenNames = new String[] {
        "<invalid>", "<EOR>", "<DOWN>", "<UP>", "CHARACTER_LITERAL", "COMMENT", "DECIMAL_LITERAL", "EscapeSequence", "Exponent", "FLOATING_POINT_LITERAL", "FloatTypeSuffix", "HEX_LITERAL", "HexDigit", "IDENTIFIER", "IntegerTypeSuffix", "LETTER", "LINE_COMMENT", "OCTAL_LITERAL", "OctalEscape", "STRING_LITERAL", "UnicodeEscape", "WS", "'!'", "'!='", "'\"'", "'#define'", "'#endif'", "'#if'", "'#ifdef'", "'#ifndef'", "'#import'", "'#include'", "'#undef'", "'%'", "'%='", "'&&'", "'&'", "'&='", "'('", "')'", "'*'", "'*='", "'+'", "'++'", "'+='", "','", "'-'", "'--'", "'-='", "'->'", "'.'", "'.+'", "'...'", "'/'", "'/='", "':'", "';'", "'<'", "'<<'", "'<<='", "'<='", "'='", "'=='", "'>'", "'>='", "'>>'", "'>>='", "'?'", "'@catch'", "'@class'", "'@encode'", "'@end'", "'@finally'", "'@implementation'", "'@interface'", "'@package'", "'@private'", "'@protected'", "'@protocol'", "'@public'", "'@selector'", "'@synchronized'", "'@throw'", "'@trystatement'", "'['", "'\\\\'", "']'", "'^'", "'^='", "'auto'", "'break'", "'bycopy'", "'byref'", "'case'", "'char'", "'const'", "'continue'", "'default'", "'do'", "'double'", "'else'", "'enum'", "'extern'", "'float'", "'for'", "'goto'", "'id'", "'if'", "'in'", "'inout'", "'int'", "'long'", "'oneway'", "'out'", "'register'", "'return'", "'self'", "'short'", "'signed'", "'sizeof'", "'static'", "'struct'", "'super'", "'switch'", "'typedef'", "'union'", "'unsigned'", "'void'", "'volatile'", "'while'", "'{'", "'|'", "'|='", "'||'", "'}'", "'~'"
    };

    public static final int EOF=-1;
    public static final int T__22=22;
    public static final int T__23=23;
    public static final int T__24=24;
    public static final int T__25=25;
    public static final int T__26=26;
    public static final int T__27=27;
    public static final int T__28=28;
    public static final int T__29=29;
    public static final int T__30=30;
    public static final int T__31=31;
    public static final int T__32=32;
    public static final int T__33=33;
    public static final int T__34=34;
    public static final int T__35=35;
    public static final int T__36=36;
    public static final int T__37=37;
    public static final int T__38=38;
    public static final int T__39=39;
    public static final int T__40=40;
    public static final int T__41=41;
    public static final int T__42=42;
    public static final int T__43=43;
    public static final int T__44=44;
    public static final int T__45=45;
    public static final int T__46=46;
    public static final int T__47=47;
    public static final int T__48=48;
    public static final int T__49=49;
    public static final int T__50=50;
    public static final int T__51=51;
    public static final int T__52=52;
    public static final int T__53=53;
    public static final int T__54=54;
    public static final int T__55=55;
    public static final int T__56=56;
    public static final int T__57=57;
    public static final int T__58=58;
    public static final int T__59=59;
    public static final int T__60=60;
    public static final int T__61=61;
    public static final int T__62=62;
    public static final int T__63=63;
    public static final int T__64=64;
    public static final int T__65=65;
    public static final int T__66=66;
    public static final int T__67=67;
    public static final int T__68=68;
    public static final int T__69=69;
    public static final int T__70=70;
    public static final int T__71=71;
    public static final int T__72=72;
    public static final int T__73=73;
    public static final int T__74=74;
    public static final int T__75=75;
    public static final int T__76=76;
    public static final int T__77=77;
    public static final int T__78=78;
    public static final int T__79=79;
    public static final int T__80=80;
    public static final int T__81=81;
    public static final int T__82=82;
    public static final int T__83=83;
    public static final int T__84=84;
    public static final int T__85=85;
    public static final int T__86=86;
    public static final int T__87=87;
    public static final int T__88=88;
    public static final int T__89=89;
    public static final int T__90=90;
    public static final int T__91=91;
    public static final int T__92=92;
    public static final int T__93=93;
    public static final int T__94=94;
    public static final int T__95=95;
    public static final int T__96=96;
    public static final int T__97=97;
    public static final int T__98=98;
    public static final int T__99=99;
    public static final int T__100=100;
    public static final int T__101=101;
    public static final int T__102=102;
    public static final int T__103=103;
    public static final int T__104=104;
    public static final int T__105=105;
    public static final int T__106=106;
    public static final int T__107=107;
    public static final int T__108=108;
    public static final int T__109=109;
    public static final int T__110=110;
    public static final int T__111=111;
    public static final int T__112=112;
    public static final int T__113=113;
    public static final int T__114=114;
    public static final int T__115=115;
    public static final int T__116=116;
    public static final int T__117=117;
    public static final int T__118=118;
    public static final int T__119=119;
    public static final int T__120=120;
    public static final int T__121=121;
    public static final int T__122=122;
    public static final int T__123=123;
    public static final int T__124=124;
    public static final int T__125=125;
    public static final int T__126=126;
    public static final int T__127=127;
    public static final int T__128=128;
    public static final int T__129=129;
    public static final int T__130=130;
    public static final int T__131=131;
    public static final int T__132=132;
    public static final int T__133=133;
    public static final int T__134=134;
    public static final int T__135=135;
    public static final int CHARACTER_LITERAL=4;
    public static final int COMMENT=5;
    public static final int DECIMAL_LITERAL=6;
    public static final int EscapeSequence=7;
    public static final int Exponent=8;
    public static final int FLOATING_POINT_LITERAL=9;
    public static final int FloatTypeSuffix=10;
    public static final int HEX_LITERAL=11;
    public static final int HexDigit=12;
    public static final int IDENTIFIER=13;
    public static final int IntegerTypeSuffix=14;
    public static final int LETTER=15;
    public static final int LINE_COMMENT=16;
    public static final int OCTAL_LITERAL=17;
    public static final int OctalEscape=18;
    public static final int STRING_LITERAL=19;
    public static final int UnicodeEscape=20;
    public static final int WS=21;

    // delegates
    public Parser[] getDelegates() {
        return new Parser[] {};
    }

    // delegators


    public ObjectiveCParser(TokenStream input) {
        this(input, new RecognizerSharedState());
    }
    public ObjectiveCParser(TokenStream input, RecognizerSharedState state) {
        super(input, state);
    }

protected TreeAdaptor adaptor = new CommonTreeAdaptor();

public void setTreeAdaptor(TreeAdaptor adaptor) {
    this.adaptor = adaptor;
}
public TreeAdaptor getTreeAdaptor() {
    return adaptor;
}
    public String[] getTokenNames() { return ObjectiveCParser.tokenNames; }
    public String getGrammarFileName() { return "/Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g"; }


    public static class translation_unit_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "translation_unit"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:26:1: translation_unit : ( external_declaration )+ ;
    public final ObjectiveCParser.translation_unit_return translation_unit() throws RecognitionException {
        ObjectiveCParser.translation_unit_return retval = new ObjectiveCParser.translation_unit_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.external_declaration_return external_declaration1 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:26:17: ( ( external_declaration )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:26:19: ( external_declaration )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:26:19: ( external_declaration )+
            int cnt1=0;
            loop1:
            do {
                int alt1=2;
                int LA1_0 = input.LA(1);

                if ( (LA1_0==COMMENT||LA1_0==IDENTIFIER||LA1_0==LINE_COMMENT||(LA1_0 >= 25 && LA1_0 <= 32)||LA1_0==69||(LA1_0 >= 73 && LA1_0 <= 74)||LA1_0==78||LA1_0==89||(LA1_0 >= 91 && LA1_0 <= 92)||(LA1_0 >= 94 && LA1_0 <= 95)||LA1_0==99||(LA1_0 >= 101 && LA1_0 <= 103)||LA1_0==106||(LA1_0 >= 108 && LA1_0 <= 114)||(LA1_0 >= 117 && LA1_0 <= 118)||(LA1_0 >= 120 && LA1_0 <= 121)||(LA1_0 >= 124 && LA1_0 <= 128)) ) {
                    alt1=1;
                }


                switch (alt1) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:26:19: external_declaration
            	    {
            	    pushFollow(FOLLOW_external_declaration_in_translation_unit47);
            	    external_declaration1=external_declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, external_declaration1.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt1 >= 1 ) break loop1;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(1, input);
                        throw eee;
                }
                cnt1++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "translation_unit"


    public static class external_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "external_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:28:1: external_declaration : ( COMMENT | LINE_COMMENT | preprocessor_declaration | function_definition | declaration | class_interface | class_implementation | category_interface | category_implementation | protocol_declaration | protocol_declaration_list | class_declaration_list );
    public final ObjectiveCParser.external_declaration_return external_declaration() throws RecognitionException {
        ObjectiveCParser.external_declaration_return retval = new ObjectiveCParser.external_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token COMMENT2=null;
        Token LINE_COMMENT3=null;
        ObjectiveCParser.preprocessor_declaration_return preprocessor_declaration4 =null;

        ObjectiveCParser.function_definition_return function_definition5 =null;

        ObjectiveCParser.declaration_return declaration6 =null;

        ObjectiveCParser.class_interface_return class_interface7 =null;

        ObjectiveCParser.class_implementation_return class_implementation8 =null;

        ObjectiveCParser.category_interface_return category_interface9 =null;

        ObjectiveCParser.category_implementation_return category_implementation10 =null;

        ObjectiveCParser.protocol_declaration_return protocol_declaration11 =null;

        ObjectiveCParser.protocol_declaration_list_return protocol_declaration_list12 =null;

        ObjectiveCParser.class_declaration_list_return class_declaration_list13 =null;


        Object COMMENT2_tree=null;
        Object LINE_COMMENT3_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:28:21: ( COMMENT | LINE_COMMENT | preprocessor_declaration | function_definition | declaration | class_interface | class_implementation | category_interface | category_implementation | protocol_declaration | protocol_declaration_list | class_declaration_list )
            int alt2=12;
            switch ( input.LA(1) ) {
            case COMMENT:
                {
                alt2=1;
                }
                break;
            case LINE_COMMENT:
                {
                alt2=2;
                }
                break;
            case 25:
            case 26:
            case 27:
            case 28:
            case 29:
            case 30:
            case 31:
            case 32:
                {
                alt2=3;
                }
                break;
            case 89:
            case 102:
            case 114:
            case 120:
            case 124:
                {
                int LA2_11 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 11, input);

                    throw nvae;

                }
                }
                break;
            case 127:
                {
                int LA2_12 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 12, input);

                    throw nvae;

                }
                }
                break;
            case 94:
                {
                int LA2_13 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 13, input);

                    throw nvae;

                }
                }
                break;
            case 117:
                {
                int LA2_14 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 14, input);

                    throw nvae;

                }
                }
                break;
            case 110:
                {
                int LA2_15 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 15, input);

                    throw nvae;

                }
                }
                break;
            case 111:
                {
                int LA2_16 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 16, input);

                    throw nvae;

                }
                }
                break;
            case 103:
                {
                int LA2_17 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 17, input);

                    throw nvae;

                }
                }
                break;
            case 99:
                {
                int LA2_18 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 18, input);

                    throw nvae;

                }
                }
                break;
            case 118:
                {
                int LA2_19 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 19, input);

                    throw nvae;

                }
                }
                break;
            case 126:
                {
                int LA2_20 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 20, input);

                    throw nvae;

                }
                }
                break;
            case 106:
                {
                int LA2_21 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 21, input);

                    throw nvae;

                }
                }
                break;
            case IDENTIFIER:
                {
                int LA2_22 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 22, input);

                    throw nvae;

                }
                }
                break;
            case 121:
            case 125:
                {
                int LA2_23 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 23, input);

                    throw nvae;

                }
                }
                break;
            case 101:
                {
                int LA2_24 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 24, input);

                    throw nvae;

                }
                }
                break;
            case 95:
                {
                int LA2_25 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 25, input);

                    throw nvae;

                }
                }
                break;
            case 128:
                {
                int LA2_26 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 26, input);

                    throw nvae;

                }
                }
                break;
            case 91:
            case 92:
            case 108:
            case 109:
            case 112:
            case 113:
                {
                int LA2_27 = input.LA(2);

                if ( (synpred5_ObjectiveC()) ) {
                    alt2=4;
                }
                else if ( (synpred6_ObjectiveC()) ) {
                    alt2=5;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 27, input);

                    throw nvae;

                }
                }
                break;
            case 74:
                {
                int LA2_28 = input.LA(2);

                if ( (synpred7_ObjectiveC()) ) {
                    alt2=6;
                }
                else if ( (synpred9_ObjectiveC()) ) {
                    alt2=8;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 28, input);

                    throw nvae;

                }
                }
                break;
            case 73:
                {
                int LA2_29 = input.LA(2);

                if ( (synpred8_ObjectiveC()) ) {
                    alt2=7;
                }
                else if ( (synpred10_ObjectiveC()) ) {
                    alt2=9;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 29, input);

                    throw nvae;

                }
                }
                break;
            case 78:
                {
                int LA2_30 = input.LA(2);

                if ( (synpred11_ObjectiveC()) ) {
                    alt2=10;
                }
                else if ( (synpred12_ObjectiveC()) ) {
                    alt2=11;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 2, 30, input);

                    throw nvae;

                }
                }
                break;
            case 69:
                {
                alt2=12;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 2, 0, input);

                throw nvae;

            }

            switch (alt2) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:29:0: COMMENT
                    {
                    root_0 = (Object)adaptor.nil();


                    COMMENT2=(Token)match(input,COMMENT,FOLLOW_COMMENT_in_external_declaration55); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    COMMENT2_tree = 
                    (Object)adaptor.create(COMMENT2)
                    ;
                    adaptor.addChild(root_0, COMMENT2_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:29:11: LINE_COMMENT
                    {
                    root_0 = (Object)adaptor.nil();


                    LINE_COMMENT3=(Token)match(input,LINE_COMMENT,FOLLOW_LINE_COMMENT_in_external_declaration59); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    LINE_COMMENT3_tree = 
                    (Object)adaptor.create(LINE_COMMENT3)
                    ;
                    adaptor.addChild(root_0, LINE_COMMENT3_tree);
                    }

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:29:26: preprocessor_declaration
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_preprocessor_declaration_in_external_declaration63);
                    preprocessor_declaration4=preprocessor_declaration();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, preprocessor_declaration4.getTree());

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:30:2: function_definition
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_function_definition_in_external_declaration66);
                    function_definition5=function_definition();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, function_definition5.getTree());

                    }
                    break;
                case 5 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:31:3: declaration
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_declaration_in_external_declaration70);
                    declaration6=declaration();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration6.getTree());

                    }
                    break;
                case 6 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:32:3: class_interface
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_class_interface_in_external_declaration75);
                    class_interface7=class_interface();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_interface7.getTree());

                    }
                    break;
                case 7 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:33:3: class_implementation
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_class_implementation_in_external_declaration79);
                    class_implementation8=class_implementation();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_implementation8.getTree());

                    }
                    break;
                case 8 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:34:3: category_interface
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_category_interface_in_external_declaration83);
                    category_interface9=category_interface();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, category_interface9.getTree());

                    }
                    break;
                case 9 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:35:3: category_implementation
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_category_implementation_in_external_declaration87);
                    category_implementation10=category_implementation();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, category_implementation10.getTree());

                    }
                    break;
                case 10 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:36:3: protocol_declaration
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_protocol_declaration_in_external_declaration91);
                    protocol_declaration11=protocol_declaration();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_declaration11.getTree());

                    }
                    break;
                case 11 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:37:3: protocol_declaration_list
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_protocol_declaration_list_in_external_declaration95);
                    protocol_declaration_list12=protocol_declaration_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_declaration_list12.getTree());

                    }
                    break;
                case 12 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:38:3: class_declaration_list
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_class_declaration_list_in_external_declaration99);
                    class_declaration_list13=class_declaration_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_declaration_list13.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "external_declaration"


    public static class preprocessor_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "preprocessor_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:40:1: preprocessor_declaration : ( '#import' file_specification | '#include' file_specification | '#define' macro_specification | '#ifdef' expression | '#if' expression | '#undef' expression | '#ifndef' expression | '#endif' );
    public final ObjectiveCParser.preprocessor_declaration_return preprocessor_declaration() throws RecognitionException {
        ObjectiveCParser.preprocessor_declaration_return retval = new ObjectiveCParser.preprocessor_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal14=null;
        Token string_literal16=null;
        Token string_literal18=null;
        Token string_literal20=null;
        Token string_literal22=null;
        Token string_literal24=null;
        Token string_literal26=null;
        Token string_literal28=null;
        ObjectiveCParser.file_specification_return file_specification15 =null;

        ObjectiveCParser.file_specification_return file_specification17 =null;

        ObjectiveCParser.macro_specification_return macro_specification19 =null;

        ObjectiveCParser.expression_return expression21 =null;

        ObjectiveCParser.expression_return expression23 =null;

        ObjectiveCParser.expression_return expression25 =null;

        ObjectiveCParser.expression_return expression27 =null;


        Object string_literal14_tree=null;
        Object string_literal16_tree=null;
        Object string_literal18_tree=null;
        Object string_literal20_tree=null;
        Object string_literal22_tree=null;
        Object string_literal24_tree=null;
        Object string_literal26_tree=null;
        Object string_literal28_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:40:25: ( '#import' file_specification | '#include' file_specification | '#define' macro_specification | '#ifdef' expression | '#if' expression | '#undef' expression | '#ifndef' expression | '#endif' )
            int alt3=8;
            switch ( input.LA(1) ) {
            case 30:
                {
                alt3=1;
                }
                break;
            case 31:
                {
                alt3=2;
                }
                break;
            case 25:
                {
                alt3=3;
                }
                break;
            case 28:
                {
                alt3=4;
                }
                break;
            case 27:
                {
                alt3=5;
                }
                break;
            case 32:
                {
                alt3=6;
                }
                break;
            case 29:
                {
                alt3=7;
                }
                break;
            case 26:
                {
                alt3=8;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 3, 0, input);

                throw nvae;

            }

            switch (alt3) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:41:0: '#import' file_specification
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal14=(Token)match(input,30,FOLLOW_30_in_preprocessor_declaration106); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal14_tree = 
                    (Object)adaptor.create(string_literal14)
                    ;
                    adaptor.addChild(root_0, string_literal14_tree);
                    }

                    pushFollow(FOLLOW_file_specification_in_preprocessor_declaration108);
                    file_specification15=file_specification();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, file_specification15.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:42:3: '#include' file_specification
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal16=(Token)match(input,31,FOLLOW_31_in_preprocessor_declaration112); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal16_tree = 
                    (Object)adaptor.create(string_literal16)
                    ;
                    adaptor.addChild(root_0, string_literal16_tree);
                    }

                    pushFollow(FOLLOW_file_specification_in_preprocessor_declaration114);
                    file_specification17=file_specification();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, file_specification17.getTree());

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:43:3: '#define' macro_specification
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal18=(Token)match(input,25,FOLLOW_25_in_preprocessor_declaration118); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal18_tree = 
                    (Object)adaptor.create(string_literal18)
                    ;
                    adaptor.addChild(root_0, string_literal18_tree);
                    }

                    pushFollow(FOLLOW_macro_specification_in_preprocessor_declaration120);
                    macro_specification19=macro_specification();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, macro_specification19.getTree());

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:44:3: '#ifdef' expression
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal20=(Token)match(input,28,FOLLOW_28_in_preprocessor_declaration124); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal20_tree = 
                    (Object)adaptor.create(string_literal20)
                    ;
                    adaptor.addChild(root_0, string_literal20_tree);
                    }

                    pushFollow(FOLLOW_expression_in_preprocessor_declaration126);
                    expression21=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression21.getTree());

                    }
                    break;
                case 5 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:45:3: '#if' expression
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal22=(Token)match(input,27,FOLLOW_27_in_preprocessor_declaration130); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal22_tree = 
                    (Object)adaptor.create(string_literal22)
                    ;
                    adaptor.addChild(root_0, string_literal22_tree);
                    }

                    pushFollow(FOLLOW_expression_in_preprocessor_declaration132);
                    expression23=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression23.getTree());

                    }
                    break;
                case 6 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:46:3: '#undef' expression
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal24=(Token)match(input,32,FOLLOW_32_in_preprocessor_declaration136); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal24_tree = 
                    (Object)adaptor.create(string_literal24)
                    ;
                    adaptor.addChild(root_0, string_literal24_tree);
                    }

                    pushFollow(FOLLOW_expression_in_preprocessor_declaration138);
                    expression25=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression25.getTree());

                    }
                    break;
                case 7 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:47:3: '#ifndef' expression
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal26=(Token)match(input,29,FOLLOW_29_in_preprocessor_declaration142); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal26_tree = 
                    (Object)adaptor.create(string_literal26)
                    ;
                    adaptor.addChild(root_0, string_literal26_tree);
                    }

                    pushFollow(FOLLOW_expression_in_preprocessor_declaration144);
                    expression27=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression27.getTree());

                    }
                    break;
                case 8 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:48:3: '#endif'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal28=(Token)match(input,26,FOLLOW_26_in_preprocessor_declaration148); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal28_tree = 
                    (Object)adaptor.create(string_literal28)
                    ;
                    adaptor.addChild(root_0, string_literal28_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "preprocessor_declaration"


    public static class file_specification_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "file_specification"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:50:1: file_specification : ( '<' | '\"' ) ( IDENTIFIER ( '/' | '\\\\' | '.' )? )+ ( '>' | '\"' ) ;
    public final ObjectiveCParser.file_specification_return file_specification() throws RecognitionException {
        ObjectiveCParser.file_specification_return retval = new ObjectiveCParser.file_specification_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set29=null;
        Token IDENTIFIER30=null;
        Token set31=null;
        Token set32=null;

        Object set29_tree=null;
        Object IDENTIFIER30_tree=null;
        Object set31_tree=null;
        Object set32_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:50:19: ( ( '<' | '\"' ) ( IDENTIFIER ( '/' | '\\\\' | '.' )? )+ ( '>' | '\"' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:50:21: ( '<' | '\"' ) ( IDENTIFIER ( '/' | '\\\\' | '.' )? )+ ( '>' | '\"' )
            {
            root_0 = (Object)adaptor.nil();


            set29=(Token)input.LT(1);

            if ( input.LA(1)==24||input.LA(1)==57 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set29)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:50:30: ( IDENTIFIER ( '/' | '\\\\' | '.' )? )+
            int cnt5=0;
            loop5:
            do {
                int alt5=2;
                int LA5_0 = input.LA(1);

                if ( (LA5_0==IDENTIFIER) ) {
                    alt5=1;
                }


                switch (alt5) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:50:31: IDENTIFIER ( '/' | '\\\\' | '.' )?
            	    {
            	    IDENTIFIER30=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_file_specification161); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    IDENTIFIER30_tree = 
            	    (Object)adaptor.create(IDENTIFIER30)
            	    ;
            	    adaptor.addChild(root_0, IDENTIFIER30_tree);
            	    }

            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:50:42: ( '/' | '\\\\' | '.' )?
            	    int alt4=2;
            	    int LA4_0 = input.LA(1);

            	    if ( (LA4_0==50||LA4_0==53||LA4_0==85) ) {
            	        alt4=1;
            	    }
            	    switch (alt4) {
            	        case 1 :
            	            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            	            {
            	            set31=(Token)input.LT(1);

            	            if ( input.LA(1)==50||input.LA(1)==53||input.LA(1)==85 ) {
            	                input.consume();
            	                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
            	                (Object)adaptor.create(set31)
            	                );
            	                state.errorRecovery=false;
            	                state.failed=false;
            	            }
            	            else {
            	                if (state.backtracking>0) {state.failed=true; return retval;}
            	                MismatchedSetException mse = new MismatchedSetException(null,input);
            	                throw mse;
            	            }


            	            }
            	            break;

            	    }


            	    }
            	    break;

            	default :
            	    if ( cnt5 >= 1 ) break loop5;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(5, input);
                        throw eee;
                }
                cnt5++;
            } while (true);


            set32=(Token)input.LT(1);

            if ( input.LA(1)==24||input.LA(1)==63 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set32)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "file_specification"


    public static class macro_specification_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "macro_specification"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:52:1: macro_specification : '.+' ;
    public final ObjectiveCParser.macro_specification_return macro_specification() throws RecognitionException {
        ObjectiveCParser.macro_specification_return retval = new ObjectiveCParser.macro_specification_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal33=null;

        Object string_literal33_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:52:20: ( '.+' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:52:22: '.+'
            {
            root_0 = (Object)adaptor.nil();


            string_literal33=(Token)match(input,51,FOLLOW_51_in_macro_specification191); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal33_tree = 
            (Object)adaptor.create(string_literal33)
            ;
            adaptor.addChild(root_0, string_literal33_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "macro_specification"


    public static class class_interface_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_interface"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:54:1: class_interface : '@interface' ( class_name ( ':' superclass_name )? ( protocol_reference_list )? ( instance_variables )? ( interface_declaration_list )? ) '@end' ;
    public final ObjectiveCParser.class_interface_return class_interface() throws RecognitionException {
        ObjectiveCParser.class_interface_return retval = new ObjectiveCParser.class_interface_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal34=null;
        Token char_literal36=null;
        Token string_literal41=null;
        ObjectiveCParser.class_name_return class_name35 =null;

        ObjectiveCParser.superclass_name_return superclass_name37 =null;

        ObjectiveCParser.protocol_reference_list_return protocol_reference_list38 =null;

        ObjectiveCParser.instance_variables_return instance_variables39 =null;

        ObjectiveCParser.interface_declaration_list_return interface_declaration_list40 =null;


        Object string_literal34_tree=null;
        Object char_literal36_tree=null;
        Object string_literal41_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:54:16: ( '@interface' ( class_name ( ':' superclass_name )? ( protocol_reference_list )? ( instance_variables )? ( interface_declaration_list )? ) '@end' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:55:2: '@interface' ( class_name ( ':' superclass_name )? ( protocol_reference_list )? ( instance_variables )? ( interface_declaration_list )? ) '@end'
            {
            root_0 = (Object)adaptor.nil();


            string_literal34=(Token)match(input,74,FOLLOW_74_in_class_interface199); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal34_tree = 
            (Object)adaptor.create(string_literal34)
            ;
            adaptor.addChild(root_0, string_literal34_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:56:2: ( class_name ( ':' superclass_name )? ( protocol_reference_list )? ( instance_variables )? ( interface_declaration_list )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:57:2: class_name ( ':' superclass_name )? ( protocol_reference_list )? ( instance_variables )? ( interface_declaration_list )?
            {
            pushFollow(FOLLOW_class_name_in_class_interface205);
            class_name35=class_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name35.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:57:13: ( ':' superclass_name )?
            int alt6=2;
            int LA6_0 = input.LA(1);

            if ( (LA6_0==55) ) {
                alt6=1;
            }
            switch (alt6) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:57:14: ':' superclass_name
                    {
                    char_literal36=(Token)match(input,55,FOLLOW_55_in_class_interface208); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal36_tree = 
                    (Object)adaptor.create(char_literal36)
                    ;
                    adaptor.addChild(root_0, char_literal36_tree);
                    }

                    pushFollow(FOLLOW_superclass_name_in_class_interface210);
                    superclass_name37=superclass_name();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, superclass_name37.getTree());

                    }
                    break;

            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:58:2: ( protocol_reference_list )?
            int alt7=2;
            int LA7_0 = input.LA(1);

            if ( (LA7_0==57) ) {
                alt7=1;
            }
            switch (alt7) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:58:4: protocol_reference_list
                    {
                    pushFollow(FOLLOW_protocol_reference_list_in_class_interface217);
                    protocol_reference_list38=protocol_reference_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_reference_list38.getTree());

                    }
                    break;

            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:59:2: ( instance_variables )?
            int alt8=2;
            int LA8_0 = input.LA(1);

            if ( (LA8_0==130) ) {
                alt8=1;
            }
            switch (alt8) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:59:4: instance_variables
                    {
                    pushFollow(FOLLOW_instance_variables_in_class_interface225);
                    instance_variables39=instance_variables();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, instance_variables39.getTree());

                    }
                    break;

            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:60:2: ( interface_declaration_list )?
            int alt9=2;
            int LA9_0 = input.LA(1);

            if ( (LA9_0==IDENTIFIER||LA9_0==42||LA9_0==46||LA9_0==89||(LA9_0 >= 91 && LA9_0 <= 92)||(LA9_0 >= 94 && LA9_0 <= 95)||LA9_0==99||(LA9_0 >= 101 && LA9_0 <= 103)||LA9_0==106||(LA9_0 >= 108 && LA9_0 <= 114)||(LA9_0 >= 117 && LA9_0 <= 118)||(LA9_0 >= 120 && LA9_0 <= 121)||(LA9_0 >= 124 && LA9_0 <= 128)) ) {
                alt9=1;
            }
            switch (alt9) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:60:4: interface_declaration_list
                    {
                    pushFollow(FOLLOW_interface_declaration_list_in_class_interface233);
                    interface_declaration_list40=interface_declaration_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, interface_declaration_list40.getTree());

                    }
                    break;

            }


            }


            string_literal41=(Token)match(input,71,FOLLOW_71_in_class_interface242); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal41_tree = 
            (Object)adaptor.create(string_literal41)
            ;
            adaptor.addChild(root_0, string_literal41_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_interface"


    public static class category_interface_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "category_interface"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:64:1: category_interface : '@interface' ( class_name '(' category_name ')' ( protocol_reference_list )? ( interface_declaration_list )? ) '@end' ;
    public final ObjectiveCParser.category_interface_return category_interface() throws RecognitionException {
        ObjectiveCParser.category_interface_return retval = new ObjectiveCParser.category_interface_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal42=null;
        Token char_literal44=null;
        Token char_literal46=null;
        Token string_literal49=null;
        ObjectiveCParser.class_name_return class_name43 =null;

        ObjectiveCParser.category_name_return category_name45 =null;

        ObjectiveCParser.protocol_reference_list_return protocol_reference_list47 =null;

        ObjectiveCParser.interface_declaration_list_return interface_declaration_list48 =null;


        Object string_literal42_tree=null;
        Object char_literal44_tree=null;
        Object char_literal46_tree=null;
        Object string_literal49_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:64:19: ( '@interface' ( class_name '(' category_name ')' ( protocol_reference_list )? ( interface_declaration_list )? ) '@end' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:65:2: '@interface' ( class_name '(' category_name ')' ( protocol_reference_list )? ( interface_declaration_list )? ) '@end'
            {
            root_0 = (Object)adaptor.nil();


            string_literal42=(Token)match(input,74,FOLLOW_74_in_category_interface250); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal42_tree = 
            (Object)adaptor.create(string_literal42)
            ;
            adaptor.addChild(root_0, string_literal42_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:66:2: ( class_name '(' category_name ')' ( protocol_reference_list )? ( interface_declaration_list )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:67:2: class_name '(' category_name ')' ( protocol_reference_list )? ( interface_declaration_list )?
            {
            pushFollow(FOLLOW_class_name_in_category_interface256);
            class_name43=class_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name43.getTree());

            char_literal44=(Token)match(input,38,FOLLOW_38_in_category_interface258); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal44_tree = 
            (Object)adaptor.create(char_literal44)
            ;
            adaptor.addChild(root_0, char_literal44_tree);
            }

            pushFollow(FOLLOW_category_name_in_category_interface260);
            category_name45=category_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, category_name45.getTree());

            char_literal46=(Token)match(input,39,FOLLOW_39_in_category_interface262); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal46_tree = 
            (Object)adaptor.create(char_literal46)
            ;
            adaptor.addChild(root_0, char_literal46_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:68:2: ( protocol_reference_list )?
            int alt10=2;
            int LA10_0 = input.LA(1);

            if ( (LA10_0==57) ) {
                alt10=1;
            }
            switch (alt10) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:68:4: protocol_reference_list
                    {
                    pushFollow(FOLLOW_protocol_reference_list_in_category_interface267);
                    protocol_reference_list47=protocol_reference_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_reference_list47.getTree());

                    }
                    break;

            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:69:2: ( interface_declaration_list )?
            int alt11=2;
            int LA11_0 = input.LA(1);

            if ( (LA11_0==IDENTIFIER||LA11_0==42||LA11_0==46||LA11_0==89||(LA11_0 >= 91 && LA11_0 <= 92)||(LA11_0 >= 94 && LA11_0 <= 95)||LA11_0==99||(LA11_0 >= 101 && LA11_0 <= 103)||LA11_0==106||(LA11_0 >= 108 && LA11_0 <= 114)||(LA11_0 >= 117 && LA11_0 <= 118)||(LA11_0 >= 120 && LA11_0 <= 121)||(LA11_0 >= 124 && LA11_0 <= 128)) ) {
                alt11=1;
            }
            switch (alt11) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:69:4: interface_declaration_list
                    {
                    pushFollow(FOLLOW_interface_declaration_list_in_category_interface275);
                    interface_declaration_list48=interface_declaration_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, interface_declaration_list48.getTree());

                    }
                    break;

            }


            }


            string_literal49=(Token)match(input,71,FOLLOW_71_in_category_interface284); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal49_tree = 
            (Object)adaptor.create(string_literal49)
            ;
            adaptor.addChild(root_0, string_literal49_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "category_interface"


    public static class class_implementation_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_implementation"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:73:1: class_implementation : '@implementation' ( class_name ( ':' superclass_name )? ( implementation_definition_list )? ) '@end' ;
    public final ObjectiveCParser.class_implementation_return class_implementation() throws RecognitionException {
        ObjectiveCParser.class_implementation_return retval = new ObjectiveCParser.class_implementation_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal50=null;
        Token char_literal52=null;
        Token string_literal55=null;
        ObjectiveCParser.class_name_return class_name51 =null;

        ObjectiveCParser.superclass_name_return superclass_name53 =null;

        ObjectiveCParser.implementation_definition_list_return implementation_definition_list54 =null;


        Object string_literal50_tree=null;
        Object char_literal52_tree=null;
        Object string_literal55_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:73:21: ( '@implementation' ( class_name ( ':' superclass_name )? ( implementation_definition_list )? ) '@end' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:74:2: '@implementation' ( class_name ( ':' superclass_name )? ( implementation_definition_list )? ) '@end'
            {
            root_0 = (Object)adaptor.nil();


            string_literal50=(Token)match(input,73,FOLLOW_73_in_class_implementation292); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal50_tree = 
            (Object)adaptor.create(string_literal50)
            ;
            adaptor.addChild(root_0, string_literal50_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:75:2: ( class_name ( ':' superclass_name )? ( implementation_definition_list )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:76:2: class_name ( ':' superclass_name )? ( implementation_definition_list )?
            {
            pushFollow(FOLLOW_class_name_in_class_implementation298);
            class_name51=class_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name51.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:76:13: ( ':' superclass_name )?
            int alt12=2;
            int LA12_0 = input.LA(1);

            if ( (LA12_0==55) ) {
                alt12=1;
            }
            switch (alt12) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:76:15: ':' superclass_name
                    {
                    char_literal52=(Token)match(input,55,FOLLOW_55_in_class_implementation302); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal52_tree = 
                    (Object)adaptor.create(char_literal52)
                    ;
                    adaptor.addChild(root_0, char_literal52_tree);
                    }

                    pushFollow(FOLLOW_superclass_name_in_class_implementation304);
                    superclass_name53=superclass_name();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, superclass_name53.getTree());

                    }
                    break;

            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:77:2: ( implementation_definition_list )?
            int alt13=2;
            int LA13_0 = input.LA(1);

            if ( (LA13_0==IDENTIFIER||LA13_0==42||LA13_0==46||LA13_0==89||(LA13_0 >= 91 && LA13_0 <= 92)||(LA13_0 >= 94 && LA13_0 <= 95)||LA13_0==99||(LA13_0 >= 101 && LA13_0 <= 103)||LA13_0==106||(LA13_0 >= 108 && LA13_0 <= 114)||(LA13_0 >= 117 && LA13_0 <= 118)||(LA13_0 >= 120 && LA13_0 <= 121)||(LA13_0 >= 124 && LA13_0 <= 128)) ) {
                alt13=1;
            }
            switch (alt13) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:77:4: implementation_definition_list
                    {
                    pushFollow(FOLLOW_implementation_definition_list_in_class_implementation312);
                    implementation_definition_list54=implementation_definition_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, implementation_definition_list54.getTree());

                    }
                    break;

            }


            }


            string_literal55=(Token)match(input,71,FOLLOW_71_in_class_implementation321); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal55_tree = 
            (Object)adaptor.create(string_literal55)
            ;
            adaptor.addChild(root_0, string_literal55_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_implementation"


    public static class category_implementation_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "category_implementation"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:81:1: category_implementation : '@implementation' ( class_name '(' category_name ')' ( implementation_definition_list )? ) '@end' ;
    public final ObjectiveCParser.category_implementation_return category_implementation() throws RecognitionException {
        ObjectiveCParser.category_implementation_return retval = new ObjectiveCParser.category_implementation_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal56=null;
        Token char_literal58=null;
        Token char_literal60=null;
        Token string_literal62=null;
        ObjectiveCParser.class_name_return class_name57 =null;

        ObjectiveCParser.category_name_return category_name59 =null;

        ObjectiveCParser.implementation_definition_list_return implementation_definition_list61 =null;


        Object string_literal56_tree=null;
        Object char_literal58_tree=null;
        Object char_literal60_tree=null;
        Object string_literal62_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:81:24: ( '@implementation' ( class_name '(' category_name ')' ( implementation_definition_list )? ) '@end' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:82:2: '@implementation' ( class_name '(' category_name ')' ( implementation_definition_list )? ) '@end'
            {
            root_0 = (Object)adaptor.nil();


            string_literal56=(Token)match(input,73,FOLLOW_73_in_category_implementation329); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal56_tree = 
            (Object)adaptor.create(string_literal56)
            ;
            adaptor.addChild(root_0, string_literal56_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:82:19: ( class_name '(' category_name ')' ( implementation_definition_list )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:83:2: class_name '(' category_name ')' ( implementation_definition_list )?
            {
            pushFollow(FOLLOW_class_name_in_category_implementation333);
            class_name57=class_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name57.getTree());

            char_literal58=(Token)match(input,38,FOLLOW_38_in_category_implementation335); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal58_tree = 
            (Object)adaptor.create(char_literal58)
            ;
            adaptor.addChild(root_0, char_literal58_tree);
            }

            pushFollow(FOLLOW_category_name_in_category_implementation337);
            category_name59=category_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, category_name59.getTree());

            char_literal60=(Token)match(input,39,FOLLOW_39_in_category_implementation339); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal60_tree = 
            (Object)adaptor.create(char_literal60)
            ;
            adaptor.addChild(root_0, char_literal60_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:84:2: ( implementation_definition_list )?
            int alt14=2;
            int LA14_0 = input.LA(1);

            if ( (LA14_0==IDENTIFIER||LA14_0==42||LA14_0==46||LA14_0==89||(LA14_0 >= 91 && LA14_0 <= 92)||(LA14_0 >= 94 && LA14_0 <= 95)||LA14_0==99||(LA14_0 >= 101 && LA14_0 <= 103)||LA14_0==106||(LA14_0 >= 108 && LA14_0 <= 114)||(LA14_0 >= 117 && LA14_0 <= 118)||(LA14_0 >= 120 && LA14_0 <= 121)||(LA14_0 >= 124 && LA14_0 <= 128)) ) {
                alt14=1;
            }
            switch (alt14) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:84:4: implementation_definition_list
                    {
                    pushFollow(FOLLOW_implementation_definition_list_in_category_implementation344);
                    implementation_definition_list61=implementation_definition_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, implementation_definition_list61.getTree());

                    }
                    break;

            }


            }


            string_literal62=(Token)match(input,71,FOLLOW_71_in_category_implementation351); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal62_tree = 
            (Object)adaptor.create(string_literal62)
            ;
            adaptor.addChild(root_0, string_literal62_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "category_implementation"


    public static class protocol_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:87:1: protocol_declaration : '@protocol' ( protocol_name ( protocol_reference_list )? ( interface_declaration_list )? ) '@end' ;
    public final ObjectiveCParser.protocol_declaration_return protocol_declaration() throws RecognitionException {
        ObjectiveCParser.protocol_declaration_return retval = new ObjectiveCParser.protocol_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal63=null;
        Token string_literal67=null;
        ObjectiveCParser.protocol_name_return protocol_name64 =null;

        ObjectiveCParser.protocol_reference_list_return protocol_reference_list65 =null;

        ObjectiveCParser.interface_declaration_list_return interface_declaration_list66 =null;


        Object string_literal63_tree=null;
        Object string_literal67_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:87:21: ( '@protocol' ( protocol_name ( protocol_reference_list )? ( interface_declaration_list )? ) '@end' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:88:2: '@protocol' ( protocol_name ( protocol_reference_list )? ( interface_declaration_list )? ) '@end'
            {
            root_0 = (Object)adaptor.nil();


            string_literal63=(Token)match(input,78,FOLLOW_78_in_protocol_declaration359); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal63_tree = 
            (Object)adaptor.create(string_literal63)
            ;
            adaptor.addChild(root_0, string_literal63_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:88:13: ( protocol_name ( protocol_reference_list )? ( interface_declaration_list )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:89:2: protocol_name ( protocol_reference_list )? ( interface_declaration_list )?
            {
            pushFollow(FOLLOW_protocol_name_in_protocol_declaration363);
            protocol_name64=protocol_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_name64.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:89:16: ( protocol_reference_list )?
            int alt15=2;
            int LA15_0 = input.LA(1);

            if ( (LA15_0==57) ) {
                alt15=1;
            }
            switch (alt15) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:89:18: protocol_reference_list
                    {
                    pushFollow(FOLLOW_protocol_reference_list_in_protocol_declaration367);
                    protocol_reference_list65=protocol_reference_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_reference_list65.getTree());

                    }
                    break;

            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:90:2: ( interface_declaration_list )?
            int alt16=2;
            int LA16_0 = input.LA(1);

            if ( (LA16_0==IDENTIFIER||LA16_0==42||LA16_0==46||LA16_0==89||(LA16_0 >= 91 && LA16_0 <= 92)||(LA16_0 >= 94 && LA16_0 <= 95)||LA16_0==99||(LA16_0 >= 101 && LA16_0 <= 103)||LA16_0==106||(LA16_0 >= 108 && LA16_0 <= 114)||(LA16_0 >= 117 && LA16_0 <= 118)||(LA16_0 >= 120 && LA16_0 <= 121)||(LA16_0 >= 124 && LA16_0 <= 128)) ) {
                alt16=1;
            }
            switch (alt16) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:90:4: interface_declaration_list
                    {
                    pushFollow(FOLLOW_interface_declaration_list_in_protocol_declaration375);
                    interface_declaration_list66=interface_declaration_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, interface_declaration_list66.getTree());

                    }
                    break;

            }


            }


            string_literal67=(Token)match(input,71,FOLLOW_71_in_protocol_declaration382); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal67_tree = 
            (Object)adaptor.create(string_literal67)
            ;
            adaptor.addChild(root_0, string_literal67_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_declaration"


    public static class protocol_declaration_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_declaration_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:93:1: protocol_declaration_list : ( '@protocol' protocol_list ';' ) ;
    public final ObjectiveCParser.protocol_declaration_list_return protocol_declaration_list() throws RecognitionException {
        ObjectiveCParser.protocol_declaration_list_return retval = new ObjectiveCParser.protocol_declaration_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal68=null;
        Token char_literal70=null;
        ObjectiveCParser.protocol_list_return protocol_list69 =null;


        Object string_literal68_tree=null;
        Object char_literal70_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:93:26: ( ( '@protocol' protocol_list ';' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:94:2: ( '@protocol' protocol_list ';' )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:94:2: ( '@protocol' protocol_list ';' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:94:3: '@protocol' protocol_list ';'
            {
            string_literal68=(Token)match(input,78,FOLLOW_78_in_protocol_declaration_list391); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal68_tree = 
            (Object)adaptor.create(string_literal68)
            ;
            adaptor.addChild(root_0, string_literal68_tree);
            }

            pushFollow(FOLLOW_protocol_list_in_protocol_declaration_list393);
            protocol_list69=protocol_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_list69.getTree());

            char_literal70=(Token)match(input,56,FOLLOW_56_in_protocol_declaration_list394); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal70_tree = 
            (Object)adaptor.create(char_literal70)
            ;
            adaptor.addChild(root_0, char_literal70_tree);
            }

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_declaration_list"


    public static class class_declaration_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_declaration_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:97:1: class_declaration_list : ( '@class' class_list ';' ) ;
    public final ObjectiveCParser.class_declaration_list_return class_declaration_list() throws RecognitionException {
        ObjectiveCParser.class_declaration_list_return retval = new ObjectiveCParser.class_declaration_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal71=null;
        Token char_literal73=null;
        ObjectiveCParser.class_list_return class_list72 =null;


        Object string_literal71_tree=null;
        Object char_literal73_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:97:23: ( ( '@class' class_list ';' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:98:2: ( '@class' class_list ';' )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:98:2: ( '@class' class_list ';' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:98:3: '@class' class_list ';'
            {
            string_literal71=(Token)match(input,69,FOLLOW_69_in_class_declaration_list406); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal71_tree = 
            (Object)adaptor.create(string_literal71)
            ;
            adaptor.addChild(root_0, string_literal71_tree);
            }

            pushFollow(FOLLOW_class_list_in_class_declaration_list408);
            class_list72=class_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, class_list72.getTree());

            char_literal73=(Token)match(input,56,FOLLOW_56_in_class_declaration_list409); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal73_tree = 
            (Object)adaptor.create(char_literal73)
            ;
            adaptor.addChild(root_0, char_literal73_tree);
            }

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_declaration_list"


    public static class class_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:101:1: class_list : class_name ( ',' class_name )* ;
    public final ObjectiveCParser.class_list_return class_list() throws RecognitionException {
        ObjectiveCParser.class_list_return retval = new ObjectiveCParser.class_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal75=null;
        ObjectiveCParser.class_name_return class_name74 =null;

        ObjectiveCParser.class_name_return class_name76 =null;


        Object char_literal75_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:101:11: ( class_name ( ',' class_name )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:102:2: class_name ( ',' class_name )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_class_name_in_class_list420);
            class_name74=class_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name74.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:102:13: ( ',' class_name )*
            loop17:
            do {
                int alt17=2;
                int LA17_0 = input.LA(1);

                if ( (LA17_0==45) ) {
                    alt17=1;
                }


                switch (alt17) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:102:14: ',' class_name
            	    {
            	    char_literal75=(Token)match(input,45,FOLLOW_45_in_class_list423); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal75_tree = 
            	    (Object)adaptor.create(char_literal75)
            	    ;
            	    adaptor.addChild(root_0, char_literal75_tree);
            	    }

            	    pushFollow(FOLLOW_class_name_in_class_list425);
            	    class_name76=class_name();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name76.getTree());

            	    }
            	    break;

            	default :
            	    break loop17;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_list"


    public static class protocol_reference_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_reference_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:104:1: protocol_reference_list : ( '<' protocol_list '>' ) ;
    public final ObjectiveCParser.protocol_reference_list_return protocol_reference_list() throws RecognitionException {
        ObjectiveCParser.protocol_reference_list_return retval = new ObjectiveCParser.protocol_reference_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal77=null;
        Token char_literal79=null;
        ObjectiveCParser.protocol_list_return protocol_list78 =null;


        Object char_literal77_tree=null;
        Object char_literal79_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:104:24: ( ( '<' protocol_list '>' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:105:2: ( '<' protocol_list '>' )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:105:2: ( '<' protocol_list '>' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:105:3: '<' protocol_list '>'
            {
            char_literal77=(Token)match(input,57,FOLLOW_57_in_protocol_reference_list436); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal77_tree = 
            (Object)adaptor.create(char_literal77)
            ;
            adaptor.addChild(root_0, char_literal77_tree);
            }

            pushFollow(FOLLOW_protocol_list_in_protocol_reference_list438);
            protocol_list78=protocol_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_list78.getTree());

            char_literal79=(Token)match(input,63,FOLLOW_63_in_protocol_reference_list440); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal79_tree = 
            (Object)adaptor.create(char_literal79)
            ;
            adaptor.addChild(root_0, char_literal79_tree);
            }

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_reference_list"


    public static class protocol_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:107:1: protocol_list : protocol_name ( ',' protocol_name )* ;
    public final ObjectiveCParser.protocol_list_return protocol_list() throws RecognitionException {
        ObjectiveCParser.protocol_list_return retval = new ObjectiveCParser.protocol_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal81=null;
        ObjectiveCParser.protocol_name_return protocol_name80 =null;

        ObjectiveCParser.protocol_name_return protocol_name82 =null;


        Object char_literal81_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:107:14: ( protocol_name ( ',' protocol_name )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:108:2: protocol_name ( ',' protocol_name )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_protocol_name_in_protocol_list449);
            protocol_name80=protocol_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_name80.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:108:16: ( ',' protocol_name )*
            loop18:
            do {
                int alt18=2;
                int LA18_0 = input.LA(1);

                if ( (LA18_0==45) ) {
                    alt18=1;
                }


                switch (alt18) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:108:17: ',' protocol_name
            	    {
            	    char_literal81=(Token)match(input,45,FOLLOW_45_in_protocol_list452); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal81_tree = 
            	    (Object)adaptor.create(char_literal81)
            	    ;
            	    adaptor.addChild(root_0, char_literal81_tree);
            	    }

            	    pushFollow(FOLLOW_protocol_name_in_protocol_list454);
            	    protocol_name82=protocol_name();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_name82.getTree());

            	    }
            	    break;

            	default :
            	    break loop18;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_list"


    public static class class_name_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_name"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:110:1: class_name : IDENTIFIER ;
    public final ObjectiveCParser.class_name_return class_name() throws RecognitionException {
        ObjectiveCParser.class_name_return retval = new ObjectiveCParser.class_name_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER83=null;

        Object IDENTIFIER83_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:110:11: ( IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:111:2: IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            IDENTIFIER83=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_class_name464); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER83_tree = 
            (Object)adaptor.create(IDENTIFIER83)
            ;
            adaptor.addChild(root_0, IDENTIFIER83_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_name"


    public static class superclass_name_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "superclass_name"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:113:1: superclass_name : IDENTIFIER ;
    public final ObjectiveCParser.superclass_name_return superclass_name() throws RecognitionException {
        ObjectiveCParser.superclass_name_return retval = new ObjectiveCParser.superclass_name_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER84=null;

        Object IDENTIFIER84_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:113:16: ( IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:114:2: IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            IDENTIFIER84=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_superclass_name472); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER84_tree = 
            (Object)adaptor.create(IDENTIFIER84)
            ;
            adaptor.addChild(root_0, IDENTIFIER84_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "superclass_name"


    public static class category_name_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "category_name"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:116:1: category_name : IDENTIFIER ;
    public final ObjectiveCParser.category_name_return category_name() throws RecognitionException {
        ObjectiveCParser.category_name_return retval = new ObjectiveCParser.category_name_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER85=null;

        Object IDENTIFIER85_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:116:14: ( IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:117:2: IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            IDENTIFIER85=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_category_name480); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER85_tree = 
            (Object)adaptor.create(IDENTIFIER85)
            ;
            adaptor.addChild(root_0, IDENTIFIER85_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "category_name"


    public static class protocol_name_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_name"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:119:1: protocol_name : IDENTIFIER ;
    public final ObjectiveCParser.protocol_name_return protocol_name() throws RecognitionException {
        ObjectiveCParser.protocol_name_return retval = new ObjectiveCParser.protocol_name_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER86=null;

        Object IDENTIFIER86_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:119:14: ( IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:120:2: IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            IDENTIFIER86=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_protocol_name488); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER86_tree = 
            (Object)adaptor.create(IDENTIFIER86)
            ;
            adaptor.addChild(root_0, IDENTIFIER86_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_name"


    public static class instance_variables_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "instance_variables"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:122:1: instance_variables : '{' instance_variable_declaration '}' ;
    public final ObjectiveCParser.instance_variables_return instance_variables() throws RecognitionException {
        ObjectiveCParser.instance_variables_return retval = new ObjectiveCParser.instance_variables_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal87=null;
        Token char_literal89=null;
        ObjectiveCParser.instance_variable_declaration_return instance_variable_declaration88 =null;


        Object char_literal87_tree=null;
        Object char_literal89_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:122:19: ( '{' instance_variable_declaration '}' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:123:2: '{' instance_variable_declaration '}'
            {
            root_0 = (Object)adaptor.nil();


            char_literal87=(Token)match(input,130,FOLLOW_130_in_instance_variables496); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal87_tree = 
            (Object)adaptor.create(char_literal87)
            ;
            adaptor.addChild(root_0, char_literal87_tree);
            }

            pushFollow(FOLLOW_instance_variable_declaration_in_instance_variables498);
            instance_variable_declaration88=instance_variable_declaration();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, instance_variable_declaration88.getTree());

            char_literal89=(Token)match(input,134,FOLLOW_134_in_instance_variables500); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal89_tree = 
            (Object)adaptor.create(char_literal89)
            ;
            adaptor.addChild(root_0, char_literal89_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "instance_variables"


    public static class instance_variable_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "instance_variable_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:125:1: instance_variable_declaration : ( visibility_specification | struct_declarator_list instance_variables )+ ;
    public final ObjectiveCParser.instance_variable_declaration_return instance_variable_declaration() throws RecognitionException {
        ObjectiveCParser.instance_variable_declaration_return retval = new ObjectiveCParser.instance_variable_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.visibility_specification_return visibility_specification90 =null;

        ObjectiveCParser.struct_declarator_list_return struct_declarator_list91 =null;

        ObjectiveCParser.instance_variables_return instance_variables92 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:125:30: ( ( visibility_specification | struct_declarator_list instance_variables )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:126:2: ( visibility_specification | struct_declarator_list instance_variables )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:126:2: ( visibility_specification | struct_declarator_list instance_variables )+
            int cnt19=0;
            loop19:
            do {
                int alt19=3;
                int LA19_0 = input.LA(1);

                if ( ((LA19_0 >= 75 && LA19_0 <= 77)||LA19_0==79) ) {
                    alt19=1;
                }
                else if ( (LA19_0==IDENTIFIER||LA19_0==38||LA19_0==40||LA19_0==55) ) {
                    alt19=2;
                }


                switch (alt19) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:126:3: visibility_specification
            	    {
            	    pushFollow(FOLLOW_visibility_specification_in_instance_variable_declaration510);
            	    visibility_specification90=visibility_specification();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, visibility_specification90.getTree());

            	    }
            	    break;
            	case 2 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:126:30: struct_declarator_list instance_variables
            	    {
            	    pushFollow(FOLLOW_struct_declarator_list_in_instance_variable_declaration514);
            	    struct_declarator_list91=struct_declarator_list();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, struct_declarator_list91.getTree());

            	    pushFollow(FOLLOW_instance_variables_in_instance_variable_declaration516);
            	    instance_variables92=instance_variables();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, instance_variables92.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt19 >= 1 ) break loop19;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(19, input);
                        throw eee;
                }
                cnt19++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "instance_variable_declaration"


    public static class visibility_specification_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "visibility_specification"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:129:1: visibility_specification : ( '@private' | '@protected' | '@package' | '@public' );
    public final ObjectiveCParser.visibility_specification_return visibility_specification() throws RecognitionException {
        ObjectiveCParser.visibility_specification_return retval = new ObjectiveCParser.visibility_specification_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set93=null;

        Object set93_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:129:25: ( '@private' | '@protected' | '@package' | '@public' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            {
            root_0 = (Object)adaptor.nil();


            set93=(Token)input.LT(1);

            if ( (input.LA(1) >= 75 && input.LA(1) <= 77)||input.LA(1)==79 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set93)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "visibility_specification"


    public static class interface_declaration_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "interface_declaration_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:135:1: interface_declaration_list : ( declaration | class_method_declaration | instance_method_declaration )+ ;
    public final ObjectiveCParser.interface_declaration_list_return interface_declaration_list() throws RecognitionException {
        ObjectiveCParser.interface_declaration_list_return retval = new ObjectiveCParser.interface_declaration_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.declaration_return declaration94 =null;

        ObjectiveCParser.class_method_declaration_return class_method_declaration95 =null;

        ObjectiveCParser.instance_method_declaration_return instance_method_declaration96 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:135:27: ( ( declaration | class_method_declaration | instance_method_declaration )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:136:2: ( declaration | class_method_declaration | instance_method_declaration )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:136:2: ( declaration | class_method_declaration | instance_method_declaration )+
            int cnt20=0;
            loop20:
            do {
                int alt20=4;
                switch ( input.LA(1) ) {
                case IDENTIFIER:
                case 89:
                case 91:
                case 92:
                case 94:
                case 95:
                case 99:
                case 101:
                case 102:
                case 103:
                case 106:
                case 108:
                case 109:
                case 110:
                case 111:
                case 112:
                case 113:
                case 114:
                case 117:
                case 118:
                case 120:
                case 121:
                case 124:
                case 125:
                case 126:
                case 127:
                case 128:
                    {
                    alt20=1;
                    }
                    break;
                case 42:
                    {
                    alt20=2;
                    }
                    break;
                case 46:
                    {
                    alt20=3;
                    }
                    break;

                }

                switch (alt20) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:136:3: declaration
            	    {
            	    pushFollow(FOLLOW_declaration_in_interface_declaration_list553);
            	    declaration94=declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration94.getTree());

            	    }
            	    break;
            	case 2 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:136:17: class_method_declaration
            	    {
            	    pushFollow(FOLLOW_class_method_declaration_in_interface_declaration_list557);
            	    class_method_declaration95=class_method_declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_method_declaration95.getTree());

            	    }
            	    break;
            	case 3 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:136:44: instance_method_declaration
            	    {
            	    pushFollow(FOLLOW_instance_method_declaration_in_interface_declaration_list561);
            	    instance_method_declaration96=instance_method_declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, instance_method_declaration96.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt20 >= 1 ) break loop20;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(20, input);
                        throw eee;
                }
                cnt20++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "interface_declaration_list"


    public static class class_method_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_method_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:139:1: class_method_declaration : ( '+' method_declaration ) ;
    public final ObjectiveCParser.class_method_declaration_return class_method_declaration() throws RecognitionException {
        ObjectiveCParser.class_method_declaration_return retval = new ObjectiveCParser.class_method_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal97=null;
        ObjectiveCParser.method_declaration_return method_declaration98 =null;


        Object char_literal97_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:139:25: ( ( '+' method_declaration ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:140:2: ( '+' method_declaration )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:140:2: ( '+' method_declaration )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:140:3: '+' method_declaration
            {
            char_literal97=(Token)match(input,42,FOLLOW_42_in_class_method_declaration574); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal97_tree = 
            (Object)adaptor.create(char_literal97)
            ;
            adaptor.addChild(root_0, char_literal97_tree);
            }

            pushFollow(FOLLOW_method_declaration_in_class_method_declaration576);
            method_declaration98=method_declaration();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, method_declaration98.getTree());

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_method_declaration"


    public static class instance_method_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "instance_method_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:143:1: instance_method_declaration : ( '-' method_declaration ) ;
    public final ObjectiveCParser.instance_method_declaration_return instance_method_declaration() throws RecognitionException {
        ObjectiveCParser.instance_method_declaration_return retval = new ObjectiveCParser.instance_method_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal99=null;
        ObjectiveCParser.method_declaration_return method_declaration100 =null;


        Object char_literal99_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:143:28: ( ( '-' method_declaration ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:144:2: ( '-' method_declaration )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:144:2: ( '-' method_declaration )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:144:3: '-' method_declaration
            {
            char_literal99=(Token)match(input,46,FOLLOW_46_in_instance_method_declaration588); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal99_tree = 
            (Object)adaptor.create(char_literal99)
            ;
            adaptor.addChild(root_0, char_literal99_tree);
            }

            pushFollow(FOLLOW_method_declaration_in_instance_method_declaration590);
            method_declaration100=method_declaration();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, method_declaration100.getTree());

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "instance_method_declaration"


    public static class method_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "method_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:147:1: method_declaration : ( method_type )? method_selector ';' ;
    public final ObjectiveCParser.method_declaration_return method_declaration() throws RecognitionException {
        ObjectiveCParser.method_declaration_return retval = new ObjectiveCParser.method_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal103=null;
        ObjectiveCParser.method_type_return method_type101 =null;

        ObjectiveCParser.method_selector_return method_selector102 =null;


        Object char_literal103_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:147:19: ( ( method_type )? method_selector ';' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:148:2: ( method_type )? method_selector ';'
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:148:2: ( method_type )?
            int alt21=2;
            int LA21_0 = input.LA(1);

            if ( (LA21_0==38) ) {
                alt21=1;
            }
            switch (alt21) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:148:4: method_type
                    {
                    pushFollow(FOLLOW_method_type_in_method_declaration603);
                    method_type101=method_type();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, method_type101.getTree());

                    }
                    break;

            }


            pushFollow(FOLLOW_method_selector_in_method_declaration608);
            method_selector102=method_selector();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, method_selector102.getTree());

            char_literal103=(Token)match(input,56,FOLLOW_56_in_method_declaration610); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal103_tree = 
            (Object)adaptor.create(char_literal103)
            ;
            adaptor.addChild(root_0, char_literal103_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "method_declaration"


    public static class implementation_definition_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "implementation_definition_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:150:1: implementation_definition_list : ( function_definition | declaration | class_method_definition | instance_method_definition )+ ;
    public final ObjectiveCParser.implementation_definition_list_return implementation_definition_list() throws RecognitionException {
        ObjectiveCParser.implementation_definition_list_return retval = new ObjectiveCParser.implementation_definition_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.function_definition_return function_definition104 =null;

        ObjectiveCParser.declaration_return declaration105 =null;

        ObjectiveCParser.class_method_definition_return class_method_definition106 =null;

        ObjectiveCParser.instance_method_definition_return instance_method_definition107 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:150:31: ( ( function_definition | declaration | class_method_definition | instance_method_definition )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:2: ( function_definition | declaration | class_method_definition | instance_method_definition )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:2: ( function_definition | declaration | class_method_definition | instance_method_definition )+
            int cnt22=0;
            loop22:
            do {
                int alt22=5;
                switch ( input.LA(1) ) {
                case 89:
                case 102:
                case 114:
                case 120:
                case 124:
                    {
                    int LA22_3 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 127:
                    {
                    int LA22_4 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 94:
                    {
                    int LA22_5 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 117:
                    {
                    int LA22_6 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 110:
                    {
                    int LA22_7 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 111:
                    {
                    int LA22_8 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 103:
                    {
                    int LA22_9 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 99:
                    {
                    int LA22_10 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 118:
                    {
                    int LA22_11 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 126:
                    {
                    int LA22_12 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 106:
                    {
                    int LA22_13 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case IDENTIFIER:
                    {
                    int LA22_14 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 121:
                case 125:
                    {
                    int LA22_15 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 101:
                    {
                    int LA22_16 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 95:
                    {
                    int LA22_17 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 128:
                    {
                    int LA22_18 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 91:
                case 92:
                case 108:
                case 109:
                case 112:
                case 113:
                    {
                    int LA22_19 = input.LA(2);

                    if ( (synpred48_ObjectiveC()) ) {
                        alt22=1;
                    }
                    else if ( (synpred49_ObjectiveC()) ) {
                        alt22=2;
                    }


                    }
                    break;
                case 42:
                    {
                    alt22=3;
                    }
                    break;
                case 46:
                    {
                    alt22=4;
                    }
                    break;

                }

                switch (alt22) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:3: function_definition
            	    {
            	    pushFollow(FOLLOW_function_definition_in_implementation_definition_list619);
            	    function_definition104=function_definition();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, function_definition104.getTree());

            	    }
            	    break;
            	case 2 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:25: declaration
            	    {
            	    pushFollow(FOLLOW_declaration_in_implementation_definition_list623);
            	    declaration105=declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration105.getTree());

            	    }
            	    break;
            	case 3 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:39: class_method_definition
            	    {
            	    pushFollow(FOLLOW_class_method_definition_in_implementation_definition_list627);
            	    class_method_definition106=class_method_definition();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_method_definition106.getTree());

            	    }
            	    break;
            	case 4 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:65: instance_method_definition
            	    {
            	    pushFollow(FOLLOW_instance_method_definition_in_implementation_definition_list631);
            	    instance_method_definition107=instance_method_definition();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, instance_method_definition107.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt22 >= 1 ) break loop22;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(22, input);
                        throw eee;
                }
                cnt22++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "implementation_definition_list"


    public static class class_method_definition_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "class_method_definition"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:153:1: class_method_definition : ( '+' method_definition ) ;
    public final ObjectiveCParser.class_method_definition_return class_method_definition() throws RecognitionException {
        ObjectiveCParser.class_method_definition_return retval = new ObjectiveCParser.class_method_definition_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal108=null;
        ObjectiveCParser.method_definition_return method_definition109 =null;


        Object char_literal108_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:153:24: ( ( '+' method_definition ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:154:2: ( '+' method_definition )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:154:2: ( '+' method_definition )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:154:3: '+' method_definition
            {
            char_literal108=(Token)match(input,42,FOLLOW_42_in_class_method_definition642); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal108_tree = 
            (Object)adaptor.create(char_literal108)
            ;
            adaptor.addChild(root_0, char_literal108_tree);
            }

            pushFollow(FOLLOW_method_definition_in_class_method_definition644);
            method_definition109=method_definition();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, method_definition109.getTree());

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "class_method_definition"


    public static class instance_method_definition_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "instance_method_definition"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:157:1: instance_method_definition : ( '-' method_definition ) ;
    public final ObjectiveCParser.instance_method_definition_return instance_method_definition() throws RecognitionException {
        ObjectiveCParser.instance_method_definition_return retval = new ObjectiveCParser.instance_method_definition_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal110=null;
        ObjectiveCParser.method_definition_return method_definition111 =null;


        Object char_literal110_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:157:27: ( ( '-' method_definition ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:158:2: ( '-' method_definition )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:158:2: ( '-' method_definition )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:158:3: '-' method_definition
            {
            char_literal110=(Token)match(input,46,FOLLOW_46_in_instance_method_definition656); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal110_tree = 
            (Object)adaptor.create(char_literal110)
            ;
            adaptor.addChild(root_0, char_literal110_tree);
            }

            pushFollow(FOLLOW_method_definition_in_instance_method_definition658);
            method_definition111=method_definition();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, method_definition111.getTree());

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "instance_method_definition"


    public static class method_definition_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "method_definition"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:161:1: method_definition : ( method_type )? method_selector ( init_declarator_list )? compound_statement ;
    public final ObjectiveCParser.method_definition_return method_definition() throws RecognitionException {
        ObjectiveCParser.method_definition_return retval = new ObjectiveCParser.method_definition_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.method_type_return method_type112 =null;

        ObjectiveCParser.method_selector_return method_selector113 =null;

        ObjectiveCParser.init_declarator_list_return init_declarator_list114 =null;

        ObjectiveCParser.compound_statement_return compound_statement115 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:161:18: ( ( method_type )? method_selector ( init_declarator_list )? compound_statement )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:162:2: ( method_type )? method_selector ( init_declarator_list )? compound_statement
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:162:2: ( method_type )?
            int alt23=2;
            int LA23_0 = input.LA(1);

            if ( (LA23_0==38) ) {
                alt23=1;
            }
            switch (alt23) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:162:3: method_type
                    {
                    pushFollow(FOLLOW_method_type_in_method_definition671);
                    method_type112=method_type();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, method_type112.getTree());

                    }
                    break;

            }


            pushFollow(FOLLOW_method_selector_in_method_definition675);
            method_selector113=method_selector();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, method_selector113.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:162:33: ( init_declarator_list )?
            int alt24=2;
            int LA24_0 = input.LA(1);

            if ( (LA24_0==IDENTIFIER||LA24_0==38||LA24_0==40) ) {
                alt24=1;
            }
            switch (alt24) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:162:34: init_declarator_list
                    {
                    pushFollow(FOLLOW_init_declarator_list_in_method_definition678);
                    init_declarator_list114=init_declarator_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, init_declarator_list114.getTree());

                    }
                    break;

            }


            pushFollow(FOLLOW_compound_statement_in_method_definition682);
            compound_statement115=compound_statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, compound_statement115.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "method_definition"


    public static class method_selector_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "method_selector"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:164:1: method_selector : ( selector | ( ( keyword_declarator )+ ( parameter_list )? ) );
    public final ObjectiveCParser.method_selector_return method_selector() throws RecognitionException {
        ObjectiveCParser.method_selector_return retval = new ObjectiveCParser.method_selector_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.selector_return selector116 =null;

        ObjectiveCParser.keyword_declarator_return keyword_declarator117 =null;

        ObjectiveCParser.parameter_list_return parameter_list118 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:164:16: ( selector | ( ( keyword_declarator )+ ( parameter_list )? ) )
            int alt27=2;
            int LA27_0 = input.LA(1);

            if ( (LA27_0==IDENTIFIER) ) {
                int LA27_1 = input.LA(2);

                if ( (LA27_1==IDENTIFIER||LA27_1==38||LA27_1==40||LA27_1==56||LA27_1==130) ) {
                    alt27=1;
                }
                else if ( (LA27_1==55) ) {
                    alt27=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 27, 1, input);

                    throw nvae;

                }
            }
            else if ( (LA27_0==55) ) {
                alt27=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 27, 0, input);

                throw nvae;

            }
            switch (alt27) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:2: selector
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_selector_in_method_selector690);
                    selector116=selector();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selector116.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:12: ( ( keyword_declarator )+ ( parameter_list )? )
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:12: ( ( keyword_declarator )+ ( parameter_list )? )
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:13: ( keyword_declarator )+ ( parameter_list )?
                    {
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:13: ( keyword_declarator )+
                    int cnt25=0;
                    loop25:
                    do {
                        int alt25=2;
                        int LA25_0 = input.LA(1);

                        if ( (LA25_0==IDENTIFIER) ) {
                            int LA25_2 = input.LA(2);

                            if ( (LA25_2==55) ) {
                                alt25=1;
                            }


                        }
                        else if ( (LA25_0==55) ) {
                            alt25=1;
                        }


                        switch (alt25) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:13: keyword_declarator
                    	    {
                    	    pushFollow(FOLLOW_keyword_declarator_in_method_selector694);
                    	    keyword_declarator117=keyword_declarator();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, keyword_declarator117.getTree());

                    	    }
                    	    break;

                    	default :
                    	    if ( cnt25 >= 1 ) break loop25;
                    	    if (state.backtracking>0) {state.failed=true; return retval;}
                                EarlyExitException eee =
                                    new EarlyExitException(25, input);
                                throw eee;
                        }
                        cnt25++;
                    } while (true);


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:33: ( parameter_list )?
                    int alt26=2;
                    int LA26_0 = input.LA(1);

                    if ( (LA26_0==89||(LA26_0 >= 91 && LA26_0 <= 92)||(LA26_0 >= 94 && LA26_0 <= 95)||LA26_0==99||(LA26_0 >= 101 && LA26_0 <= 103)||LA26_0==106||(LA26_0 >= 108 && LA26_0 <= 114)||(LA26_0 >= 117 && LA26_0 <= 118)||(LA26_0 >= 120 && LA26_0 <= 121)||(LA26_0 >= 124 && LA26_0 <= 128)) ) {
                        alt26=1;
                    }
                    else if ( (LA26_0==IDENTIFIER) ) {
                        int LA26_2 = input.LA(2);

                        if ( (synpred56_ObjectiveC()) ) {
                            alt26=1;
                        }
                    }
                    switch (alt26) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:34: parameter_list
                            {
                            pushFollow(FOLLOW_parameter_list_in_method_selector698);
                            parameter_list118=parameter_list();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, parameter_list118.getTree());

                            }
                            break;

                    }


                    }


                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "method_selector"


    public static class keyword_declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "keyword_declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:168:1: keyword_declarator : ( selector )? ':' ( method_type )* IDENTIFIER ;
    public final ObjectiveCParser.keyword_declarator_return keyword_declarator() throws RecognitionException {
        ObjectiveCParser.keyword_declarator_return retval = new ObjectiveCParser.keyword_declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal120=null;
        Token IDENTIFIER122=null;
        ObjectiveCParser.selector_return selector119 =null;

        ObjectiveCParser.method_type_return method_type121 =null;


        Object char_literal120_tree=null;
        Object IDENTIFIER122_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:168:19: ( ( selector )? ':' ( method_type )* IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:169:2: ( selector )? ':' ( method_type )* IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:169:2: ( selector )?
            int alt28=2;
            int LA28_0 = input.LA(1);

            if ( (LA28_0==IDENTIFIER) ) {
                alt28=1;
            }
            switch (alt28) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:169:2: selector
                    {
                    pushFollow(FOLLOW_selector_in_keyword_declarator712);
                    selector119=selector();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selector119.getTree());

                    }
                    break;

            }


            char_literal120=(Token)match(input,55,FOLLOW_55_in_keyword_declarator715); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal120_tree = 
            (Object)adaptor.create(char_literal120)
            ;
            adaptor.addChild(root_0, char_literal120_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:169:16: ( method_type )*
            loop29:
            do {
                int alt29=2;
                int LA29_0 = input.LA(1);

                if ( (LA29_0==38) ) {
                    alt29=1;
                }


                switch (alt29) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:169:16: method_type
            	    {
            	    pushFollow(FOLLOW_method_type_in_keyword_declarator717);
            	    method_type121=method_type();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, method_type121.getTree());

            	    }
            	    break;

            	default :
            	    break loop29;
                }
            } while (true);


            IDENTIFIER122=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_keyword_declarator720); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER122_tree = 
            (Object)adaptor.create(IDENTIFIER122)
            ;
            adaptor.addChild(root_0, IDENTIFIER122_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "keyword_declarator"


    public static class selector_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "selector"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:171:1: selector : IDENTIFIER ;
    public final ObjectiveCParser.selector_return selector() throws RecognitionException {
        ObjectiveCParser.selector_return retval = new ObjectiveCParser.selector_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER123=null;

        Object IDENTIFIER123_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:171:9: ( IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:172:1: IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            IDENTIFIER123=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_selector727); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER123_tree = 
            (Object)adaptor.create(IDENTIFIER123)
            ;
            adaptor.addChild(root_0, IDENTIFIER123_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "selector"


    public static class method_type_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "method_type"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:174:1: method_type : '(' type_name ')' ;
    public final ObjectiveCParser.method_type_return method_type() throws RecognitionException {
        ObjectiveCParser.method_type_return retval = new ObjectiveCParser.method_type_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal124=null;
        Token char_literal126=null;
        ObjectiveCParser.type_name_return type_name125 =null;


        Object char_literal124_tree=null;
        Object char_literal126_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:174:12: ( '(' type_name ')' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:175:1: '(' type_name ')'
            {
            root_0 = (Object)adaptor.nil();


            char_literal124=(Token)match(input,38,FOLLOW_38_in_method_type734); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal124_tree = 
            (Object)adaptor.create(char_literal124)
            ;
            adaptor.addChild(root_0, char_literal124_tree);
            }

            pushFollow(FOLLOW_type_name_in_method_type736);
            type_name125=type_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, type_name125.getTree());

            char_literal126=(Token)match(input,39,FOLLOW_39_in_method_type738); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal126_tree = 
            (Object)adaptor.create(char_literal126)
            ;
            adaptor.addChild(root_0, char_literal126_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "method_type"


    public static class type_specifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "type_specifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:177:1: type_specifier : ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | ( 'id' ( protocol_reference_list )? ) | ( class_name ( protocol_reference_list )? ) | struct_or_union_specifier | enum_specifier | IDENTIFIER );
    public final ObjectiveCParser.type_specifier_return type_specifier() throws RecognitionException {
        ObjectiveCParser.type_specifier_return retval = new ObjectiveCParser.type_specifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal127=null;
        Token string_literal128=null;
        Token string_literal129=null;
        Token string_literal130=null;
        Token string_literal131=null;
        Token string_literal132=null;
        Token string_literal133=null;
        Token string_literal134=null;
        Token string_literal135=null;
        Token string_literal136=null;
        Token IDENTIFIER142=null;
        ObjectiveCParser.protocol_reference_list_return protocol_reference_list137 =null;

        ObjectiveCParser.class_name_return class_name138 =null;

        ObjectiveCParser.protocol_reference_list_return protocol_reference_list139 =null;

        ObjectiveCParser.struct_or_union_specifier_return struct_or_union_specifier140 =null;

        ObjectiveCParser.enum_specifier_return enum_specifier141 =null;


        Object string_literal127_tree=null;
        Object string_literal128_tree=null;
        Object string_literal129_tree=null;
        Object string_literal130_tree=null;
        Object string_literal131_tree=null;
        Object string_literal132_tree=null;
        Object string_literal133_tree=null;
        Object string_literal134_tree=null;
        Object string_literal135_tree=null;
        Object string_literal136_tree=null;
        Object IDENTIFIER142_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:177:15: ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | ( 'id' ( protocol_reference_list )? ) | ( class_name ( protocol_reference_list )? ) | struct_or_union_specifier | enum_specifier | IDENTIFIER )
            int alt32=14;
            switch ( input.LA(1) ) {
            case 127:
                {
                alt32=1;
                }
                break;
            case 94:
                {
                alt32=2;
                }
                break;
            case 117:
                {
                alt32=3;
                }
                break;
            case 110:
                {
                alt32=4;
                }
                break;
            case 111:
                {
                alt32=5;
                }
                break;
            case 103:
                {
                alt32=6;
                }
                break;
            case 99:
                {
                alt32=7;
                }
                break;
            case 118:
                {
                alt32=8;
                }
                break;
            case 126:
                {
                alt32=9;
                }
                break;
            case 106:
                {
                alt32=10;
                }
                break;
            case IDENTIFIER:
                {
                int LA32_11 = input.LA(2);

                if ( (synpred71_ObjectiveC()) ) {
                    alt32=11;
                }
                else if ( (true) ) {
                    alt32=14;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 32, 11, input);

                    throw nvae;

                }
                }
                break;
            case 121:
            case 125:
                {
                alt32=12;
                }
                break;
            case 101:
                {
                alt32=13;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 32, 0, input);

                throw nvae;

            }

            switch (alt32) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:0: 'void'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal127=(Token)match(input,127,FOLLOW_127_in_type_specifier745); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal127_tree = 
                    (Object)adaptor.create(string_literal127)
                    ;
                    adaptor.addChild(root_0, string_literal127_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:10: 'char'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal128=(Token)match(input,94,FOLLOW_94_in_type_specifier749); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal128_tree = 
                    (Object)adaptor.create(string_literal128)
                    ;
                    adaptor.addChild(root_0, string_literal128_tree);
                    }

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:19: 'short'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal129=(Token)match(input,117,FOLLOW_117_in_type_specifier753); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal129_tree = 
                    (Object)adaptor.create(string_literal129)
                    ;
                    adaptor.addChild(root_0, string_literal129_tree);
                    }

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:29: 'int'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal130=(Token)match(input,110,FOLLOW_110_in_type_specifier757); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal130_tree = 
                    (Object)adaptor.create(string_literal130)
                    ;
                    adaptor.addChild(root_0, string_literal130_tree);
                    }

                    }
                    break;
                case 5 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:37: 'long'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal131=(Token)match(input,111,FOLLOW_111_in_type_specifier761); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal131_tree = 
                    (Object)adaptor.create(string_literal131)
                    ;
                    adaptor.addChild(root_0, string_literal131_tree);
                    }

                    }
                    break;
                case 6 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:46: 'float'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal132=(Token)match(input,103,FOLLOW_103_in_type_specifier765); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal132_tree = 
                    (Object)adaptor.create(string_literal132)
                    ;
                    adaptor.addChild(root_0, string_literal132_tree);
                    }

                    }
                    break;
                case 7 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:56: 'double'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal133=(Token)match(input,99,FOLLOW_99_in_type_specifier769); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal133_tree = 
                    (Object)adaptor.create(string_literal133)
                    ;
                    adaptor.addChild(root_0, string_literal133_tree);
                    }

                    }
                    break;
                case 8 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:67: 'signed'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal134=(Token)match(input,118,FOLLOW_118_in_type_specifier773); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal134_tree = 
                    (Object)adaptor.create(string_literal134)
                    ;
                    adaptor.addChild(root_0, string_literal134_tree);
                    }

                    }
                    break;
                case 9 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:178:78: 'unsigned'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal135=(Token)match(input,126,FOLLOW_126_in_type_specifier777); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal135_tree = 
                    (Object)adaptor.create(string_literal135)
                    ;
                    adaptor.addChild(root_0, string_literal135_tree);
                    }

                    }
                    break;
                case 10 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:179:4: ( 'id' ( protocol_reference_list )? )
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:179:4: ( 'id' ( protocol_reference_list )? )
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:179:5: 'id' ( protocol_reference_list )?
                    {
                    string_literal136=(Token)match(input,106,FOLLOW_106_in_type_specifier784); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal136_tree = 
                    (Object)adaptor.create(string_literal136)
                    ;
                    adaptor.addChild(root_0, string_literal136_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:179:10: ( protocol_reference_list )?
                    int alt30=2;
                    int LA30_0 = input.LA(1);

                    if ( (LA30_0==57) ) {
                        alt30=1;
                    }
                    switch (alt30) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:179:12: protocol_reference_list
                            {
                            pushFollow(FOLLOW_protocol_reference_list_in_type_specifier788);
                            protocol_reference_list137=protocol_reference_list();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_reference_list137.getTree());

                            }
                            break;

                    }


                    }


                    }
                    break;
                case 11 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:4: ( class_name ( protocol_reference_list )? )
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:4: ( class_name ( protocol_reference_list )? )
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:5: class_name ( protocol_reference_list )?
                    {
                    pushFollow(FOLLOW_class_name_in_type_specifier799);
                    class_name138=class_name();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name138.getTree());

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:16: ( protocol_reference_list )?
                    int alt31=2;
                    int LA31_0 = input.LA(1);

                    if ( (LA31_0==57) ) {
                        alt31=1;
                    }
                    switch (alt31) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:18: protocol_reference_list
                            {
                            pushFollow(FOLLOW_protocol_reference_list_in_type_specifier803);
                            protocol_reference_list139=protocol_reference_list();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_reference_list139.getTree());

                            }
                            break;

                    }


                    }


                    }
                    break;
                case 12 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:181:4: struct_or_union_specifier
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_struct_or_union_specifier_in_type_specifier812);
                    struct_or_union_specifier140=struct_or_union_specifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, struct_or_union_specifier140.getTree());

                    }
                    break;
                case 13 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:182:4: enum_specifier
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_enum_specifier_in_type_specifier817);
                    enum_specifier141=enum_specifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, enum_specifier141.getTree());

                    }
                    break;
                case 14 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:183:4: IDENTIFIER
                    {
                    root_0 = (Object)adaptor.nil();


                    IDENTIFIER142=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_type_specifier823); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    IDENTIFIER142_tree = 
                    (Object)adaptor.create(IDENTIFIER142)
                    ;
                    adaptor.addChild(root_0, IDENTIFIER142_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "type_specifier"


    public static class type_qualifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "type_qualifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:185:1: type_qualifier : ( 'const' | 'volatile' | protocol_qualifier );
    public final ObjectiveCParser.type_qualifier_return type_qualifier() throws RecognitionException {
        ObjectiveCParser.type_qualifier_return retval = new ObjectiveCParser.type_qualifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal143=null;
        Token string_literal144=null;
        ObjectiveCParser.protocol_qualifier_return protocol_qualifier145 =null;


        Object string_literal143_tree=null;
        Object string_literal144_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:185:15: ( 'const' | 'volatile' | protocol_qualifier )
            int alt33=3;
            switch ( input.LA(1) ) {
            case 95:
                {
                alt33=1;
                }
                break;
            case 128:
                {
                alt33=2;
                }
                break;
            case 91:
            case 92:
            case 108:
            case 109:
            case 112:
            case 113:
                {
                alt33=3;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 33, 0, input);

                throw nvae;

            }

            switch (alt33) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:186:2: 'const'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal143=(Token)match(input,95,FOLLOW_95_in_type_qualifier831); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal143_tree = 
                    (Object)adaptor.create(string_literal143)
                    ;
                    adaptor.addChild(root_0, string_literal143_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:186:12: 'volatile'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal144=(Token)match(input,128,FOLLOW_128_in_type_qualifier835); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal144_tree = 
                    (Object)adaptor.create(string_literal144)
                    ;
                    adaptor.addChild(root_0, string_literal144_tree);
                    }

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:186:25: protocol_qualifier
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_protocol_qualifier_in_type_qualifier839);
                    protocol_qualifier145=protocol_qualifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_qualifier145.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "type_qualifier"


    public static class protocol_qualifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_qualifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:188:1: protocol_qualifier : ( 'in' | 'out' | 'inout' | 'bycopy' | 'byref' | 'oneway' );
    public final ObjectiveCParser.protocol_qualifier_return protocol_qualifier() throws RecognitionException {
        ObjectiveCParser.protocol_qualifier_return retval = new ObjectiveCParser.protocol_qualifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set146=null;

        Object set146_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:188:19: ( 'in' | 'out' | 'inout' | 'bycopy' | 'byref' | 'oneway' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            {
            root_0 = (Object)adaptor.nil();


            set146=(Token)input.LT(1);

            if ( (input.LA(1) >= 91 && input.LA(1) <= 92)||(input.LA(1) >= 108 && input.LA(1) <= 109)||(input.LA(1) >= 112 && input.LA(1) <= 113) ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set146)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_qualifier"


    public static class primary_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "primary_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:191:1: primary_expression : ( IDENTIFIER | constant | STRING_LITERAL | ( '(' expression ')' ) | 'self' | message_expression | selector_expression | protocol_expression | encode_expression );
    public final ObjectiveCParser.primary_expression_return primary_expression() throws RecognitionException {
        ObjectiveCParser.primary_expression_return retval = new ObjectiveCParser.primary_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER147=null;
        Token STRING_LITERAL149=null;
        Token char_literal150=null;
        Token char_literal152=null;
        Token string_literal153=null;
        ObjectiveCParser.constant_return constant148 =null;

        ObjectiveCParser.expression_return expression151 =null;

        ObjectiveCParser.message_expression_return message_expression154 =null;

        ObjectiveCParser.selector_expression_return selector_expression155 =null;

        ObjectiveCParser.protocol_expression_return protocol_expression156 =null;

        ObjectiveCParser.encode_expression_return encode_expression157 =null;


        Object IDENTIFIER147_tree=null;
        Object STRING_LITERAL149_tree=null;
        Object char_literal150_tree=null;
        Object char_literal152_tree=null;
        Object string_literal153_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:191:19: ( IDENTIFIER | constant | STRING_LITERAL | ( '(' expression ')' ) | 'self' | message_expression | selector_expression | protocol_expression | encode_expression )
            int alt34=9;
            switch ( input.LA(1) ) {
            case IDENTIFIER:
                {
                alt34=1;
                }
                break;
            case CHARACTER_LITERAL:
            case DECIMAL_LITERAL:
            case FLOATING_POINT_LITERAL:
            case HEX_LITERAL:
            case OCTAL_LITERAL:
                {
                alt34=2;
                }
                break;
            case STRING_LITERAL:
                {
                alt34=3;
                }
                break;
            case 38:
                {
                alt34=4;
                }
                break;
            case 116:
                {
                alt34=5;
                }
                break;
            case 84:
                {
                alt34=6;
                }
                break;
            case 80:
                {
                alt34=7;
                }
                break;
            case 78:
                {
                alt34=8;
                }
                break;
            case 70:
                {
                alt34=9;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 34, 0, input);

                throw nvae;

            }

            switch (alt34) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:192:2: IDENTIFIER
                    {
                    root_0 = (Object)adaptor.nil();


                    IDENTIFIER147=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_primary_expression875); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    IDENTIFIER147_tree = 
                    (Object)adaptor.create(IDENTIFIER147)
                    ;
                    adaptor.addChild(root_0, IDENTIFIER147_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:193:4: constant
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_constant_in_primary_expression880);
                    constant148=constant();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, constant148.getTree());

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:194:4: STRING_LITERAL
                    {
                    root_0 = (Object)adaptor.nil();


                    STRING_LITERAL149=(Token)match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_primary_expression885); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    STRING_LITERAL149_tree = 
                    (Object)adaptor.create(STRING_LITERAL149)
                    ;
                    adaptor.addChild(root_0, STRING_LITERAL149_tree);
                    }

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:195:4: ( '(' expression ')' )
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:195:4: ( '(' expression ')' )
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:195:5: '(' expression ')'
                    {
                    char_literal150=(Token)match(input,38,FOLLOW_38_in_primary_expression891); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal150_tree = 
                    (Object)adaptor.create(char_literal150)
                    ;
                    adaptor.addChild(root_0, char_literal150_tree);
                    }

                    pushFollow(FOLLOW_expression_in_primary_expression893);
                    expression151=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression151.getTree());

                    char_literal152=(Token)match(input,39,FOLLOW_39_in_primary_expression895); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal152_tree = 
                    (Object)adaptor.create(char_literal152)
                    ;
                    adaptor.addChild(root_0, char_literal152_tree);
                    }

                    }


                    }
                    break;
                case 5 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:196:4: 'self'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal153=(Token)match(input,116,FOLLOW_116_in_primary_expression901); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal153_tree = 
                    (Object)adaptor.create(string_literal153)
                    ;
                    adaptor.addChild(root_0, string_literal153_tree);
                    }

                    }
                    break;
                case 6 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:197:4: message_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_message_expression_in_primary_expression906);
                    message_expression154=message_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, message_expression154.getTree());

                    }
                    break;
                case 7 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:198:4: selector_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_selector_expression_in_primary_expression911);
                    selector_expression155=selector_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selector_expression155.getTree());

                    }
                    break;
                case 8 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:199:4: protocol_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_protocol_expression_in_primary_expression916);
                    protocol_expression156=protocol_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_expression156.getTree());

                    }
                    break;
                case 9 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:200:4: encode_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_encode_expression_in_primary_expression921);
                    encode_expression157=encode_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, encode_expression157.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "primary_expression"


    public static class message_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "message_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:202:1: message_expression : ( '[' receiver message_selector ']' ) ;
    public final ObjectiveCParser.message_expression_return message_expression() throws RecognitionException {
        ObjectiveCParser.message_expression_return retval = new ObjectiveCParser.message_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal158=null;
        Token char_literal161=null;
        ObjectiveCParser.receiver_return receiver159 =null;

        ObjectiveCParser.message_selector_return message_selector160 =null;


        Object char_literal158_tree=null;
        Object char_literal161_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:202:19: ( ( '[' receiver message_selector ']' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:203:2: ( '[' receiver message_selector ']' )
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:203:2: ( '[' receiver message_selector ']' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:203:3: '[' receiver message_selector ']'
            {
            char_literal158=(Token)match(input,84,FOLLOW_84_in_message_expression930); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal158_tree = 
            (Object)adaptor.create(char_literal158)
            ;
            adaptor.addChild(root_0, char_literal158_tree);
            }

            pushFollow(FOLLOW_receiver_in_message_expression932);
            receiver159=receiver();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, receiver159.getTree());

            pushFollow(FOLLOW_message_selector_in_message_expression934);
            message_selector160=message_selector();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, message_selector160.getTree());

            char_literal161=(Token)match(input,86,FOLLOW_86_in_message_expression936); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal161_tree = 
            (Object)adaptor.create(char_literal161)
            ;
            adaptor.addChild(root_0, char_literal161_tree);
            }

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "message_expression"


    public static class receiver_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "receiver"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:206:1: receiver : ( expression | class_name | 'super' );
    public final ObjectiveCParser.receiver_return receiver() throws RecognitionException {
        ObjectiveCParser.receiver_return retval = new ObjectiveCParser.receiver_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal164=null;
        ObjectiveCParser.expression_return expression162 =null;

        ObjectiveCParser.class_name_return class_name163 =null;


        Object string_literal164_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:206:9: ( expression | class_name | 'super' )
            int alt35=3;
            switch ( input.LA(1) ) {
            case CHARACTER_LITERAL:
            case DECIMAL_LITERAL:
            case FLOATING_POINT_LITERAL:
            case HEX_LITERAL:
            case OCTAL_LITERAL:
            case STRING_LITERAL:
            case 22:
            case 36:
            case 38:
            case 40:
            case 43:
            case 46:
            case 47:
            case 70:
            case 78:
            case 80:
            case 84:
            case 116:
            case 119:
            case 135:
                {
                alt35=1;
                }
                break;
            case IDENTIFIER:
                {
                int LA35_2 = input.LA(2);

                if ( (synpred89_ObjectiveC()) ) {
                    alt35=1;
                }
                else if ( (synpred90_ObjectiveC()) ) {
                    alt35=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 35, 2, input);

                    throw nvae;

                }
                }
                break;
            case 122:
                {
                alt35=3;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 35, 0, input);

                throw nvae;

            }

            switch (alt35) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:207:2: expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_expression_in_receiver947);
                    expression162=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression162.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:208:4: class_name
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_class_name_in_receiver952);
                    class_name163=class_name();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, class_name163.getTree());

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:209:4: 'super'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal164=(Token)match(input,122,FOLLOW_122_in_receiver958); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal164_tree = 
                    (Object)adaptor.create(string_literal164)
                    ;
                    adaptor.addChild(root_0, string_literal164_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "receiver"


    public static class message_selector_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "message_selector"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:211:1: message_selector : ( selector | ( keyword_argument )+ );
    public final ObjectiveCParser.message_selector_return message_selector() throws RecognitionException {
        ObjectiveCParser.message_selector_return retval = new ObjectiveCParser.message_selector_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.selector_return selector165 =null;

        ObjectiveCParser.keyword_argument_return keyword_argument166 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:211:17: ( selector | ( keyword_argument )+ )
            int alt37=2;
            int LA37_0 = input.LA(1);

            if ( (LA37_0==IDENTIFIER) ) {
                int LA37_1 = input.LA(2);

                if ( (LA37_1==86) ) {
                    alt37=1;
                }
                else if ( (LA37_1==55) ) {
                    alt37=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 37, 1, input);

                    throw nvae;

                }
            }
            else if ( (LA37_0==55) ) {
                alt37=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 37, 0, input);

                throw nvae;

            }
            switch (alt37) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:212:2: selector
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_selector_in_message_selector966);
                    selector165=selector();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selector165.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:213:4: ( keyword_argument )+
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:213:4: ( keyword_argument )+
                    int cnt36=0;
                    loop36:
                    do {
                        int alt36=2;
                        int LA36_0 = input.LA(1);

                        if ( (LA36_0==IDENTIFIER||LA36_0==55) ) {
                            alt36=1;
                        }


                        switch (alt36) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:213:4: keyword_argument
                    	    {
                    	    pushFollow(FOLLOW_keyword_argument_in_message_selector971);
                    	    keyword_argument166=keyword_argument();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, keyword_argument166.getTree());

                    	    }
                    	    break;

                    	default :
                    	    if ( cnt36 >= 1 ) break loop36;
                    	    if (state.backtracking>0) {state.failed=true; return retval;}
                                EarlyExitException eee =
                                    new EarlyExitException(36, input);
                                throw eee;
                        }
                        cnt36++;
                    } while (true);


                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "message_selector"


    public static class keyword_argument_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "keyword_argument"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:215:1: keyword_argument : ( selector )? ':' expression ;
    public final ObjectiveCParser.keyword_argument_return keyword_argument() throws RecognitionException {
        ObjectiveCParser.keyword_argument_return retval = new ObjectiveCParser.keyword_argument_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal168=null;
        ObjectiveCParser.selector_return selector167 =null;

        ObjectiveCParser.expression_return expression169 =null;


        Object char_literal168_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:215:17: ( ( selector )? ':' expression )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:216:2: ( selector )? ':' expression
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:216:2: ( selector )?
            int alt38=2;
            int LA38_0 = input.LA(1);

            if ( (LA38_0==IDENTIFIER) ) {
                alt38=1;
            }
            switch (alt38) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:216:2: selector
                    {
                    pushFollow(FOLLOW_selector_in_keyword_argument980);
                    selector167=selector();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selector167.getTree());

                    }
                    break;

            }


            char_literal168=(Token)match(input,55,FOLLOW_55_in_keyword_argument983); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal168_tree = 
            (Object)adaptor.create(char_literal168)
            ;
            adaptor.addChild(root_0, char_literal168_tree);
            }

            pushFollow(FOLLOW_expression_in_keyword_argument985);
            expression169=expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, expression169.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "keyword_argument"


    public static class selector_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "selector_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:218:1: selector_expression : '@selector' '(' selector_name ')' ;
    public final ObjectiveCParser.selector_expression_return selector_expression() throws RecognitionException {
        ObjectiveCParser.selector_expression_return retval = new ObjectiveCParser.selector_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal170=null;
        Token char_literal171=null;
        Token char_literal173=null;
        ObjectiveCParser.selector_name_return selector_name172 =null;


        Object string_literal170_tree=null;
        Object char_literal171_tree=null;
        Object char_literal173_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:218:20: ( '@selector' '(' selector_name ')' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:219:2: '@selector' '(' selector_name ')'
            {
            root_0 = (Object)adaptor.nil();


            string_literal170=(Token)match(input,80,FOLLOW_80_in_selector_expression993); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal170_tree = 
            (Object)adaptor.create(string_literal170)
            ;
            adaptor.addChild(root_0, string_literal170_tree);
            }

            char_literal171=(Token)match(input,38,FOLLOW_38_in_selector_expression995); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal171_tree = 
            (Object)adaptor.create(char_literal171)
            ;
            adaptor.addChild(root_0, char_literal171_tree);
            }

            pushFollow(FOLLOW_selector_name_in_selector_expression997);
            selector_name172=selector_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, selector_name172.getTree());

            char_literal173=(Token)match(input,39,FOLLOW_39_in_selector_expression999); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal173_tree = 
            (Object)adaptor.create(char_literal173)
            ;
            adaptor.addChild(root_0, char_literal173_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "selector_expression"


    public static class selector_name_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "selector_name"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:221:1: selector_name : ( selector | ( ( selector )? ':' )+ );
    public final ObjectiveCParser.selector_name_return selector_name() throws RecognitionException {
        ObjectiveCParser.selector_name_return retval = new ObjectiveCParser.selector_name_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal176=null;
        ObjectiveCParser.selector_return selector174 =null;

        ObjectiveCParser.selector_return selector175 =null;


        Object char_literal176_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:221:14: ( selector | ( ( selector )? ':' )+ )
            int alt41=2;
            int LA41_0 = input.LA(1);

            if ( (LA41_0==IDENTIFIER) ) {
                int LA41_1 = input.LA(2);

                if ( (LA41_1==39) ) {
                    alt41=1;
                }
                else if ( (LA41_1==55) ) {
                    alt41=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 41, 1, input);

                    throw nvae;

                }
            }
            else if ( (LA41_0==55) ) {
                alt41=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 41, 0, input);

                throw nvae;

            }
            switch (alt41) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:222:2: selector
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_selector_in_selector_name1007);
                    selector174=selector();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selector174.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:223:4: ( ( selector )? ':' )+
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:223:4: ( ( selector )? ':' )+
                    int cnt40=0;
                    loop40:
                    do {
                        int alt40=2;
                        int LA40_0 = input.LA(1);

                        if ( (LA40_0==IDENTIFIER||LA40_0==55) ) {
                            alt40=1;
                        }


                        switch (alt40) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:223:5: ( selector )? ':'
                    	    {
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:223:5: ( selector )?
                    	    int alt39=2;
                    	    int LA39_0 = input.LA(1);

                    	    if ( (LA39_0==IDENTIFIER) ) {
                    	        alt39=1;
                    	    }
                    	    switch (alt39) {
                    	        case 1 :
                    	            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:223:5: selector
                    	            {
                    	            pushFollow(FOLLOW_selector_in_selector_name1013);
                    	            selector175=selector();

                    	            state._fsp--;
                    	            if (state.failed) return retval;
                    	            if ( state.backtracking==0 ) adaptor.addChild(root_0, selector175.getTree());

                    	            }
                    	            break;

                    	    }


                    	    char_literal176=(Token)match(input,55,FOLLOW_55_in_selector_name1016); if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) {
                    	    char_literal176_tree = 
                    	    (Object)adaptor.create(char_literal176)
                    	    ;
                    	    adaptor.addChild(root_0, char_literal176_tree);
                    	    }

                    	    }
                    	    break;

                    	default :
                    	    if ( cnt40 >= 1 ) break loop40;
                    	    if (state.backtracking>0) {state.failed=true; return retval;}
                                EarlyExitException eee =
                                    new EarlyExitException(40, input);
                                throw eee;
                        }
                        cnt40++;
                    } while (true);


                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "selector_name"


    public static class protocol_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "protocol_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:225:1: protocol_expression : '@protocol' '(' protocol_name ')' ;
    public final ObjectiveCParser.protocol_expression_return protocol_expression() throws RecognitionException {
        ObjectiveCParser.protocol_expression_return retval = new ObjectiveCParser.protocol_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal177=null;
        Token char_literal178=null;
        Token char_literal180=null;
        ObjectiveCParser.protocol_name_return protocol_name179 =null;


        Object string_literal177_tree=null;
        Object char_literal178_tree=null;
        Object char_literal180_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:225:20: ( '@protocol' '(' protocol_name ')' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:226:2: '@protocol' '(' protocol_name ')'
            {
            root_0 = (Object)adaptor.nil();


            string_literal177=(Token)match(input,78,FOLLOW_78_in_protocol_expression1026); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal177_tree = 
            (Object)adaptor.create(string_literal177)
            ;
            adaptor.addChild(root_0, string_literal177_tree);
            }

            char_literal178=(Token)match(input,38,FOLLOW_38_in_protocol_expression1028); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal178_tree = 
            (Object)adaptor.create(char_literal178)
            ;
            adaptor.addChild(root_0, char_literal178_tree);
            }

            pushFollow(FOLLOW_protocol_name_in_protocol_expression1030);
            protocol_name179=protocol_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, protocol_name179.getTree());

            char_literal180=(Token)match(input,39,FOLLOW_39_in_protocol_expression1032); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal180_tree = 
            (Object)adaptor.create(char_literal180)
            ;
            adaptor.addChild(root_0, char_literal180_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "protocol_expression"


    public static class encode_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "encode_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:228:1: encode_expression : '@encode' '(' type_name ')' ;
    public final ObjectiveCParser.encode_expression_return encode_expression() throws RecognitionException {
        ObjectiveCParser.encode_expression_return retval = new ObjectiveCParser.encode_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal181=null;
        Token char_literal182=null;
        Token char_literal184=null;
        ObjectiveCParser.type_name_return type_name183 =null;


        Object string_literal181_tree=null;
        Object char_literal182_tree=null;
        Object char_literal184_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:228:18: ( '@encode' '(' type_name ')' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:229:2: '@encode' '(' type_name ')'
            {
            root_0 = (Object)adaptor.nil();


            string_literal181=(Token)match(input,70,FOLLOW_70_in_encode_expression1040); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal181_tree = 
            (Object)adaptor.create(string_literal181)
            ;
            adaptor.addChild(root_0, string_literal181_tree);
            }

            char_literal182=(Token)match(input,38,FOLLOW_38_in_encode_expression1042); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal182_tree = 
            (Object)adaptor.create(char_literal182)
            ;
            adaptor.addChild(root_0, char_literal182_tree);
            }

            pushFollow(FOLLOW_type_name_in_encode_expression1044);
            type_name183=type_name();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, type_name183.getTree());

            char_literal184=(Token)match(input,39,FOLLOW_39_in_encode_expression1046); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal184_tree = 
            (Object)adaptor.create(char_literal184)
            ;
            adaptor.addChild(root_0, char_literal184_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "encode_expression"


    public static class exception_declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "exception_declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:231:1: exception_declarator : declarator ;
    public final ObjectiveCParser.exception_declarator_return exception_declarator() throws RecognitionException {
        ObjectiveCParser.exception_declarator_return retval = new ObjectiveCParser.exception_declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.declarator_return declarator185 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:231:21: ( declarator )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:232:2: declarator
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_declarator_in_exception_declarator1054);
            declarator185=declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator185.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "exception_declarator"


    public static class try_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "try_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:234:1: try_statement : '@trystatement' ;
    public final ObjectiveCParser.try_statement_return try_statement() throws RecognitionException {
        ObjectiveCParser.try_statement_return retval = new ObjectiveCParser.try_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal186=null;

        Object string_literal186_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:234:14: ( '@trystatement' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:235:2: '@trystatement'
            {
            root_0 = (Object)adaptor.nil();


            string_literal186=(Token)match(input,83,FOLLOW_83_in_try_statement1062); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal186_tree = 
            (Object)adaptor.create(string_literal186)
            ;
            adaptor.addChild(root_0, string_literal186_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "try_statement"


    public static class catch_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "catch_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:237:1: catch_statement : '@catch' '(' exception_declarator ')' statement ;
    public final ObjectiveCParser.catch_statement_return catch_statement() throws RecognitionException {
        ObjectiveCParser.catch_statement_return retval = new ObjectiveCParser.catch_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal187=null;
        Token char_literal188=null;
        Token char_literal190=null;
        ObjectiveCParser.exception_declarator_return exception_declarator189 =null;

        ObjectiveCParser.statement_return statement191 =null;


        Object string_literal187_tree=null;
        Object char_literal188_tree=null;
        Object char_literal190_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:237:16: ( '@catch' '(' exception_declarator ')' statement )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:238:2: '@catch' '(' exception_declarator ')' statement
            {
            root_0 = (Object)adaptor.nil();


            string_literal187=(Token)match(input,68,FOLLOW_68_in_catch_statement1070); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal187_tree = 
            (Object)adaptor.create(string_literal187)
            ;
            adaptor.addChild(root_0, string_literal187_tree);
            }

            char_literal188=(Token)match(input,38,FOLLOW_38_in_catch_statement1072); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal188_tree = 
            (Object)adaptor.create(char_literal188)
            ;
            adaptor.addChild(root_0, char_literal188_tree);
            }

            pushFollow(FOLLOW_exception_declarator_in_catch_statement1073);
            exception_declarator189=exception_declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, exception_declarator189.getTree());

            char_literal190=(Token)match(input,39,FOLLOW_39_in_catch_statement1074); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal190_tree = 
            (Object)adaptor.create(char_literal190)
            ;
            adaptor.addChild(root_0, char_literal190_tree);
            }

            pushFollow(FOLLOW_statement_in_catch_statement1075);
            statement191=statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, statement191.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "catch_statement"


    public static class finally_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "finally_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:240:1: finally_statement : '@finally' statement ;
    public final ObjectiveCParser.finally_statement_return finally_statement() throws RecognitionException {
        ObjectiveCParser.finally_statement_return retval = new ObjectiveCParser.finally_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal192=null;
        ObjectiveCParser.statement_return statement193 =null;


        Object string_literal192_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:240:18: ( '@finally' statement )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:241:2: '@finally' statement
            {
            root_0 = (Object)adaptor.nil();


            string_literal192=(Token)match(input,72,FOLLOW_72_in_finally_statement1083); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal192_tree = 
            (Object)adaptor.create(string_literal192)
            ;
            adaptor.addChild(root_0, string_literal192_tree);
            }

            pushFollow(FOLLOW_statement_in_finally_statement1085);
            statement193=statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, statement193.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "finally_statement"


    public static class throw_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "throw_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:243:1: throw_statement : '@throw' '(' IDENTIFIER ')' ;
    public final ObjectiveCParser.throw_statement_return throw_statement() throws RecognitionException {
        ObjectiveCParser.throw_statement_return retval = new ObjectiveCParser.throw_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal194=null;
        Token char_literal195=null;
        Token IDENTIFIER196=null;
        Token char_literal197=null;

        Object string_literal194_tree=null;
        Object char_literal195_tree=null;
        Object IDENTIFIER196_tree=null;
        Object char_literal197_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:243:16: ( '@throw' '(' IDENTIFIER ')' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:244:2: '@throw' '(' IDENTIFIER ')'
            {
            root_0 = (Object)adaptor.nil();


            string_literal194=(Token)match(input,82,FOLLOW_82_in_throw_statement1093); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal194_tree = 
            (Object)adaptor.create(string_literal194)
            ;
            adaptor.addChild(root_0, string_literal194_tree);
            }

            char_literal195=(Token)match(input,38,FOLLOW_38_in_throw_statement1095); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal195_tree = 
            (Object)adaptor.create(char_literal195)
            ;
            adaptor.addChild(root_0, char_literal195_tree);
            }

            IDENTIFIER196=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_throw_statement1096); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER196_tree = 
            (Object)adaptor.create(IDENTIFIER196)
            ;
            adaptor.addChild(root_0, IDENTIFIER196_tree);
            }

            char_literal197=(Token)match(input,39,FOLLOW_39_in_throw_statement1097); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal197_tree = 
            (Object)adaptor.create(char_literal197)
            ;
            adaptor.addChild(root_0, char_literal197_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "throw_statement"


    public static class try_block_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "try_block"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:246:1: try_block : try_statement catch_statement ( finally_statement )? ;
    public final ObjectiveCParser.try_block_return try_block() throws RecognitionException {
        ObjectiveCParser.try_block_return retval = new ObjectiveCParser.try_block_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.try_statement_return try_statement198 =null;

        ObjectiveCParser.catch_statement_return catch_statement199 =null;

        ObjectiveCParser.finally_statement_return finally_statement200 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:246:10: ( try_statement catch_statement ( finally_statement )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:247:2: try_statement catch_statement ( finally_statement )?
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_try_statement_in_try_block1105);
            try_statement198=try_statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, try_statement198.getTree());

            pushFollow(FOLLOW_catch_statement_in_try_block1108);
            catch_statement199=catch_statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, catch_statement199.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:249:2: ( finally_statement )?
            int alt42=2;
            int LA42_0 = input.LA(1);

            if ( (LA42_0==72) ) {
                alt42=1;
            }
            switch (alt42) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:249:4: finally_statement
                    {
                    pushFollow(FOLLOW_finally_statement_in_try_block1113);
                    finally_statement200=finally_statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, finally_statement200.getTree());

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "try_block"


    public static class synchronized_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "synchronized_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:251:1: synchronized_statement : '@synchronized' '(' IDENTIFIER ')' statement ;
    public final ObjectiveCParser.synchronized_statement_return synchronized_statement() throws RecognitionException {
        ObjectiveCParser.synchronized_statement_return retval = new ObjectiveCParser.synchronized_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal201=null;
        Token char_literal202=null;
        Token IDENTIFIER203=null;
        Token char_literal204=null;
        ObjectiveCParser.statement_return statement205 =null;


        Object string_literal201_tree=null;
        Object char_literal202_tree=null;
        Object IDENTIFIER203_tree=null;
        Object char_literal204_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:251:23: ( '@synchronized' '(' IDENTIFIER ')' statement )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:252:2: '@synchronized' '(' IDENTIFIER ')' statement
            {
            root_0 = (Object)adaptor.nil();


            string_literal201=(Token)match(input,81,FOLLOW_81_in_synchronized_statement1124); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal201_tree = 
            (Object)adaptor.create(string_literal201)
            ;
            adaptor.addChild(root_0, string_literal201_tree);
            }

            char_literal202=(Token)match(input,38,FOLLOW_38_in_synchronized_statement1126); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal202_tree = 
            (Object)adaptor.create(char_literal202)
            ;
            adaptor.addChild(root_0, char_literal202_tree);
            }

            IDENTIFIER203=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synchronized_statement1128); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER203_tree = 
            (Object)adaptor.create(IDENTIFIER203)
            ;
            adaptor.addChild(root_0, IDENTIFIER203_tree);
            }

            char_literal204=(Token)match(input,39,FOLLOW_39_in_synchronized_statement1130); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal204_tree = 
            (Object)adaptor.create(char_literal204)
            ;
            adaptor.addChild(root_0, char_literal204_tree);
            }

            pushFollow(FOLLOW_statement_in_synchronized_statement1132);
            statement205=statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, statement205.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "synchronized_statement"


    public static class function_definition_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "function_definition"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:254:1: function_definition : declaration_specifiers declarator compound_statement ;
    public final ObjectiveCParser.function_definition_return function_definition() throws RecognitionException {
        ObjectiveCParser.function_definition_return retval = new ObjectiveCParser.function_definition_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.declaration_specifiers_return declaration_specifiers206 =null;

        ObjectiveCParser.declarator_return declarator207 =null;

        ObjectiveCParser.compound_statement_return compound_statement208 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:254:21: ( declaration_specifiers declarator compound_statement )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:254:23: declaration_specifiers declarator compound_statement
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_declaration_specifiers_in_function_definition1140);
            declaration_specifiers206=declaration_specifiers();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration_specifiers206.getTree());

            pushFollow(FOLLOW_declarator_in_function_definition1142);
            declarator207=declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator207.getTree());

            pushFollow(FOLLOW_compound_statement_in_function_definition1144);
            compound_statement208=compound_statement();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, compound_statement208.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "function_definition"


    public static class declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:256:1: declaration : declaration_specifiers ( init_declarator_list )? ';' ;
    public final ObjectiveCParser.declaration_return declaration() throws RecognitionException {
        ObjectiveCParser.declaration_return retval = new ObjectiveCParser.declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal211=null;
        ObjectiveCParser.declaration_specifiers_return declaration_specifiers209 =null;

        ObjectiveCParser.init_declarator_list_return init_declarator_list210 =null;


        Object char_literal211_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:256:13: ( declaration_specifiers ( init_declarator_list )? ';' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:256:15: declaration_specifiers ( init_declarator_list )? ';'
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_declaration_specifiers_in_declaration1153);
            declaration_specifiers209=declaration_specifiers();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration_specifiers209.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:256:38: ( init_declarator_list )?
            int alt43=2;
            int LA43_0 = input.LA(1);

            if ( (LA43_0==IDENTIFIER||LA43_0==38||LA43_0==40) ) {
                alt43=1;
            }
            switch (alt43) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:256:38: init_declarator_list
                    {
                    pushFollow(FOLLOW_init_declarator_list_in_declaration1155);
                    init_declarator_list210=init_declarator_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, init_declarator_list210.getTree());

                    }
                    break;

            }


            char_literal211=(Token)match(input,56,FOLLOW_56_in_declaration1158); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal211_tree = 
            (Object)adaptor.create(char_literal211)
            ;
            adaptor.addChild(root_0, char_literal211_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "declaration"


    public static class declaration_specifiers_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "declaration_specifiers"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:258:1: declaration_specifiers : ( storage_class_specifier | type_specifier | type_qualifier )+ ;
    public final ObjectiveCParser.declaration_specifiers_return declaration_specifiers() throws RecognitionException {
        ObjectiveCParser.declaration_specifiers_return retval = new ObjectiveCParser.declaration_specifiers_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.storage_class_specifier_return storage_class_specifier212 =null;

        ObjectiveCParser.type_specifier_return type_specifier213 =null;

        ObjectiveCParser.type_qualifier_return type_qualifier214 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:3: ( ( storage_class_specifier | type_specifier | type_qualifier )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:5: ( storage_class_specifier | type_specifier | type_qualifier )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:5: ( storage_class_specifier | type_specifier | type_qualifier )+
            int cnt44=0;
            loop44:
            do {
                int alt44=4;
                switch ( input.LA(1) ) {
                case IDENTIFIER:
                    {
                    int LA44_2 = input.LA(2);

                    if ( (synpred100_ObjectiveC()) ) {
                        alt44=2;
                    }


                    }
                    break;
                case 89:
                case 102:
                case 114:
                case 120:
                case 124:
                    {
                    alt44=1;
                    }
                    break;
                case 94:
                case 99:
                case 101:
                case 103:
                case 106:
                case 110:
                case 111:
                case 117:
                case 118:
                case 121:
                case 125:
                case 126:
                case 127:
                    {
                    alt44=2;
                    }
                    break;
                case 91:
                case 92:
                case 95:
                case 108:
                case 109:
                case 112:
                case 113:
                case 128:
                    {
                    alt44=3;
                    }
                    break;

                }

                switch (alt44) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:6: storage_class_specifier
            	    {
            	    pushFollow(FOLLOW_storage_class_specifier_in_declaration_specifiers1170);
            	    storage_class_specifier212=storage_class_specifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, storage_class_specifier212.getTree());

            	    }
            	    break;
            	case 2 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:32: type_specifier
            	    {
            	    pushFollow(FOLLOW_type_specifier_in_declaration_specifiers1174);
            	    type_specifier213=type_specifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_specifier213.getTree());

            	    }
            	    break;
            	case 3 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:49: type_qualifier
            	    {
            	    pushFollow(FOLLOW_type_qualifier_in_declaration_specifiers1178);
            	    type_qualifier214=type_qualifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_qualifier214.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt44 >= 1 ) break loop44;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(44, input);
                        throw eee;
                }
                cnt44++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "declaration_specifiers"


    public static class storage_class_specifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "storage_class_specifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:261:1: storage_class_specifier : ( 'auto' | 'register' | 'static' | 'extern' | 'typedef' );
    public final ObjectiveCParser.storage_class_specifier_return storage_class_specifier() throws RecognitionException {
        ObjectiveCParser.storage_class_specifier_return retval = new ObjectiveCParser.storage_class_specifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set215=null;

        Object set215_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:261:24: ( 'auto' | 'register' | 'static' | 'extern' | 'typedef' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            {
            root_0 = (Object)adaptor.nil();


            set215=(Token)input.LT(1);

            if ( input.LA(1)==89||input.LA(1)==102||input.LA(1)==114||input.LA(1)==120||input.LA(1)==124 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set215)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "storage_class_specifier"


    public static class init_declarator_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "init_declarator_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:263:1: init_declarator_list : init_declarator ( ',' init_declarator )* ;
    public final ObjectiveCParser.init_declarator_list_return init_declarator_list() throws RecognitionException {
        ObjectiveCParser.init_declarator_list_return retval = new ObjectiveCParser.init_declarator_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal217=null;
        ObjectiveCParser.init_declarator_return init_declarator216 =null;

        ObjectiveCParser.init_declarator_return init_declarator218 =null;


        Object char_literal217_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:263:22: ( init_declarator ( ',' init_declarator )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:263:24: init_declarator ( ',' init_declarator )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_init_declarator_in_init_declarator_list1212);
            init_declarator216=init_declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, init_declarator216.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:263:40: ( ',' init_declarator )*
            loop45:
            do {
                int alt45=2;
                int LA45_0 = input.LA(1);

                if ( (LA45_0==45) ) {
                    alt45=1;
                }


                switch (alt45) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:263:41: ',' init_declarator
            	    {
            	    char_literal217=(Token)match(input,45,FOLLOW_45_in_init_declarator_list1215); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal217_tree = 
            	    (Object)adaptor.create(char_literal217)
            	    ;
            	    adaptor.addChild(root_0, char_literal217_tree);
            	    }

            	    pushFollow(FOLLOW_init_declarator_in_init_declarator_list1217);
            	    init_declarator218=init_declarator();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, init_declarator218.getTree());

            	    }
            	    break;

            	default :
            	    break loop45;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "init_declarator_list"


    public static class init_declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "init_declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:264:1: init_declarator : declarator ( '=' initializer )? ;
    public final ObjectiveCParser.init_declarator_return init_declarator() throws RecognitionException {
        ObjectiveCParser.init_declarator_return retval = new ObjectiveCParser.init_declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal220=null;
        ObjectiveCParser.declarator_return declarator219 =null;

        ObjectiveCParser.initializer_return initializer221 =null;


        Object char_literal220_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:264:17: ( declarator ( '=' initializer )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:264:19: declarator ( '=' initializer )?
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_declarator_in_init_declarator1227);
            declarator219=declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator219.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:264:30: ( '=' initializer )?
            int alt46=2;
            int LA46_0 = input.LA(1);

            if ( (LA46_0==61) ) {
                alt46=1;
            }
            switch (alt46) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:264:31: '=' initializer
                    {
                    char_literal220=(Token)match(input,61,FOLLOW_61_in_init_declarator1230); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal220_tree = 
                    (Object)adaptor.create(char_literal220)
                    ;
                    adaptor.addChild(root_0, char_literal220_tree);
                    }

                    pushFollow(FOLLOW_initializer_in_init_declarator1232);
                    initializer221=initializer();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, initializer221.getTree());

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "init_declarator"


    public static class struct_or_union_specifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "struct_or_union_specifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:266:1: struct_or_union_specifier : ( 'struct' | 'union' ) ( IDENTIFIER | ( IDENTIFIER )? '{' ( struct_declaration )+ '}' ) ;
    public final ObjectiveCParser.struct_or_union_specifier_return struct_or_union_specifier() throws RecognitionException {
        ObjectiveCParser.struct_or_union_specifier_return retval = new ObjectiveCParser.struct_or_union_specifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set222=null;
        Token IDENTIFIER223=null;
        Token IDENTIFIER224=null;
        Token char_literal225=null;
        Token char_literal227=null;
        ObjectiveCParser.struct_declaration_return struct_declaration226 =null;


        Object set222_tree=null;
        Object IDENTIFIER223_tree=null;
        Object IDENTIFIER224_tree=null;
        Object char_literal225_tree=null;
        Object char_literal227_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:266:26: ( ( 'struct' | 'union' ) ( IDENTIFIER | ( IDENTIFIER )? '{' ( struct_declaration )+ '}' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:266:28: ( 'struct' | 'union' ) ( IDENTIFIER | ( IDENTIFIER )? '{' ( struct_declaration )+ '}' )
            {
            root_0 = (Object)adaptor.nil();


            set222=(Token)input.LT(1);

            if ( input.LA(1)==121||input.LA(1)==125 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set222)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:3: ( IDENTIFIER | ( IDENTIFIER )? '{' ( struct_declaration )+ '}' )
            int alt49=2;
            int LA49_0 = input.LA(1);

            if ( (LA49_0==IDENTIFIER) ) {
                int LA49_1 = input.LA(2);

                if ( (synpred109_ObjectiveC()) ) {
                    alt49=1;
                }
                else if ( (true) ) {
                    alt49=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 49, 1, input);

                    throw nvae;

                }
            }
            else if ( (LA49_0==130) ) {
                alt49=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 49, 0, input);

                throw nvae;

            }
            switch (alt49) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:5: IDENTIFIER
                    {
                    IDENTIFIER223=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_struct_or_union_specifier1255); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    IDENTIFIER223_tree = 
                    (Object)adaptor.create(IDENTIFIER223)
                    ;
                    adaptor.addChild(root_0, IDENTIFIER223_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:18: ( IDENTIFIER )? '{' ( struct_declaration )+ '}'
                    {
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:18: ( IDENTIFIER )?
                    int alt47=2;
                    int LA47_0 = input.LA(1);

                    if ( (LA47_0==IDENTIFIER) ) {
                        alt47=1;
                    }
                    switch (alt47) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:18: IDENTIFIER
                            {
                            IDENTIFIER224=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_struct_or_union_specifier1259); if (state.failed) return retval;
                            if ( state.backtracking==0 ) {
                            IDENTIFIER224_tree = 
                            (Object)adaptor.create(IDENTIFIER224)
                            ;
                            adaptor.addChild(root_0, IDENTIFIER224_tree);
                            }

                            }
                            break;

                    }


                    char_literal225=(Token)match(input,130,FOLLOW_130_in_struct_or_union_specifier1262); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal225_tree = 
                    (Object)adaptor.create(char_literal225)
                    ;
                    adaptor.addChild(root_0, char_literal225_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:34: ( struct_declaration )+
                    int cnt48=0;
                    loop48:
                    do {
                        int alt48=2;
                        int LA48_0 = input.LA(1);

                        if ( (LA48_0==IDENTIFIER||(LA48_0 >= 91 && LA48_0 <= 92)||(LA48_0 >= 94 && LA48_0 <= 95)||LA48_0==99||LA48_0==101||LA48_0==103||LA48_0==106||(LA48_0 >= 108 && LA48_0 <= 113)||(LA48_0 >= 117 && LA48_0 <= 118)||LA48_0==121||(LA48_0 >= 125 && LA48_0 <= 128)) ) {
                            alt48=1;
                        }


                        switch (alt48) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:34: struct_declaration
                    	    {
                    	    pushFollow(FOLLOW_struct_declaration_in_struct_or_union_specifier1264);
                    	    struct_declaration226=struct_declaration();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, struct_declaration226.getTree());

                    	    }
                    	    break;

                    	default :
                    	    if ( cnt48 >= 1 ) break loop48;
                    	    if (state.backtracking>0) {state.failed=true; return retval;}
                                EarlyExitException eee =
                                    new EarlyExitException(48, input);
                                throw eee;
                        }
                        cnt48++;
                    } while (true);


                    char_literal227=(Token)match(input,134,FOLLOW_134_in_struct_or_union_specifier1267); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal227_tree = 
                    (Object)adaptor.create(char_literal227)
                    ;
                    adaptor.addChild(root_0, char_literal227_tree);
                    }

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "struct_or_union_specifier"


    public static class struct_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "struct_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:269:1: struct_declaration : specifier_qualifier_list struct_declarator_list ';' ;
    public final ObjectiveCParser.struct_declaration_return struct_declaration() throws RecognitionException {
        ObjectiveCParser.struct_declaration_return retval = new ObjectiveCParser.struct_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal230=null;
        ObjectiveCParser.specifier_qualifier_list_return specifier_qualifier_list228 =null;

        ObjectiveCParser.struct_declarator_list_return struct_declarator_list229 =null;


        Object char_literal230_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:269:20: ( specifier_qualifier_list struct_declarator_list ';' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:269:22: specifier_qualifier_list struct_declarator_list ';'
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_specifier_qualifier_list_in_struct_declaration1277);
            specifier_qualifier_list228=specifier_qualifier_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, specifier_qualifier_list228.getTree());

            pushFollow(FOLLOW_struct_declarator_list_in_struct_declaration1279);
            struct_declarator_list229=struct_declarator_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, struct_declarator_list229.getTree());

            char_literal230=(Token)match(input,56,FOLLOW_56_in_struct_declaration1281); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal230_tree = 
            (Object)adaptor.create(char_literal230)
            ;
            adaptor.addChild(root_0, char_literal230_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "struct_declaration"


    public static class specifier_qualifier_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "specifier_qualifier_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:1: specifier_qualifier_list : ( type_specifier | type_qualifier )+ ;
    public final ObjectiveCParser.specifier_qualifier_list_return specifier_qualifier_list() throws RecognitionException {
        ObjectiveCParser.specifier_qualifier_list_return retval = new ObjectiveCParser.specifier_qualifier_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.type_specifier_return type_specifier231 =null;

        ObjectiveCParser.type_qualifier_return type_qualifier232 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:26: ( ( type_specifier | type_qualifier )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:28: ( type_specifier | type_qualifier )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:28: ( type_specifier | type_qualifier )+
            int cnt50=0;
            loop50:
            do {
                int alt50=3;
                switch ( input.LA(1) ) {
                case IDENTIFIER:
                    {
                    int LA50_2 = input.LA(2);

                    if ( (synpred112_ObjectiveC()) ) {
                        alt50=1;
                    }


                    }
                    break;
                case 94:
                case 99:
                case 101:
                case 103:
                case 106:
                case 110:
                case 111:
                case 117:
                case 118:
                case 121:
                case 125:
                case 126:
                case 127:
                    {
                    alt50=1;
                    }
                    break;
                case 91:
                case 92:
                case 95:
                case 108:
                case 109:
                case 112:
                case 113:
                case 128:
                    {
                    alt50=2;
                    }
                    break;

                }

                switch (alt50) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:29: type_specifier
            	    {
            	    pushFollow(FOLLOW_type_specifier_in_specifier_qualifier_list1291);
            	    type_specifier231=type_specifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_specifier231.getTree());

            	    }
            	    break;
            	case 2 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:46: type_qualifier
            	    {
            	    pushFollow(FOLLOW_type_qualifier_in_specifier_qualifier_list1295);
            	    type_qualifier232=type_qualifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_qualifier232.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt50 >= 1 ) break loop50;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(50, input);
                        throw eee;
                }
                cnt50++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "specifier_qualifier_list"


    public static class struct_declarator_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "struct_declarator_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:273:1: struct_declarator_list : struct_declarator ( ',' struct_declarator )* ;
    public final ObjectiveCParser.struct_declarator_list_return struct_declarator_list() throws RecognitionException {
        ObjectiveCParser.struct_declarator_list_return retval = new ObjectiveCParser.struct_declarator_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal234=null;
        ObjectiveCParser.struct_declarator_return struct_declarator233 =null;

        ObjectiveCParser.struct_declarator_return struct_declarator235 =null;


        Object char_literal234_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:273:24: ( struct_declarator ( ',' struct_declarator )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:273:26: struct_declarator ( ',' struct_declarator )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_struct_declarator_in_struct_declarator_list1306);
            struct_declarator233=struct_declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, struct_declarator233.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:273:44: ( ',' struct_declarator )*
            loop51:
            do {
                int alt51=2;
                int LA51_0 = input.LA(1);

                if ( (LA51_0==45) ) {
                    alt51=1;
                }


                switch (alt51) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:273:45: ',' struct_declarator
            	    {
            	    char_literal234=(Token)match(input,45,FOLLOW_45_in_struct_declarator_list1309); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal234_tree = 
            	    (Object)adaptor.create(char_literal234)
            	    ;
            	    adaptor.addChild(root_0, char_literal234_tree);
            	    }

            	    pushFollow(FOLLOW_struct_declarator_in_struct_declarator_list1311);
            	    struct_declarator235=struct_declarator();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, struct_declarator235.getTree());

            	    }
            	    break;

            	default :
            	    break loop51;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "struct_declarator_list"


    public static class struct_declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "struct_declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:1: struct_declarator : ( declarator | ( declarator )? ':' constant );
    public final ObjectiveCParser.struct_declarator_return struct_declarator() throws RecognitionException {
        ObjectiveCParser.struct_declarator_return retval = new ObjectiveCParser.struct_declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal238=null;
        ObjectiveCParser.declarator_return declarator236 =null;

        ObjectiveCParser.declarator_return declarator237 =null;

        ObjectiveCParser.constant_return constant239 =null;


        Object char_literal238_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:19: ( declarator | ( declarator )? ':' constant )
            int alt53=2;
            switch ( input.LA(1) ) {
            case 40:
                {
                int LA53_1 = input.LA(2);

                if ( (synpred115_ObjectiveC()) ) {
                    alt53=1;
                }
                else if ( (true) ) {
                    alt53=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 53, 1, input);

                    throw nvae;

                }
                }
                break;
            case IDENTIFIER:
                {
                int LA53_2 = input.LA(2);

                if ( (synpred115_ObjectiveC()) ) {
                    alt53=1;
                }
                else if ( (true) ) {
                    alt53=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 53, 2, input);

                    throw nvae;

                }
                }
                break;
            case 38:
                {
                int LA53_3 = input.LA(2);

                if ( (synpred115_ObjectiveC()) ) {
                    alt53=1;
                }
                else if ( (true) ) {
                    alt53=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 53, 3, input);

                    throw nvae;

                }
                }
                break;
            case 55:
                {
                alt53=2;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 53, 0, input);

                throw nvae;

            }

            switch (alt53) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:21: declarator
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_declarator_in_struct_declarator1322);
                    declarator236=declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator236.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:34: ( declarator )? ':' constant
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:34: ( declarator )?
                    int alt52=2;
                    int LA52_0 = input.LA(1);

                    if ( (LA52_0==IDENTIFIER||LA52_0==38||LA52_0==40) ) {
                        alt52=1;
                    }
                    switch (alt52) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:34: declarator
                            {
                            pushFollow(FOLLOW_declarator_in_struct_declarator1326);
                            declarator237=declarator();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator237.getTree());

                            }
                            break;

                    }


                    char_literal238=(Token)match(input,55,FOLLOW_55_in_struct_declarator1329); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal238_tree = 
                    (Object)adaptor.create(char_literal238)
                    ;
                    adaptor.addChild(root_0, char_literal238_tree);
                    }

                    pushFollow(FOLLOW_constant_in_struct_declarator1331);
                    constant239=constant();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, constant239.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "struct_declarator"


    public static class enum_specifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "enum_specifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:277:1: enum_specifier : 'enum' ( identifier ( '{' enumerator_list '}' )? | '{' enumerator_list '}' ) ;
    public final ObjectiveCParser.enum_specifier_return enum_specifier() throws RecognitionException {
        ObjectiveCParser.enum_specifier_return retval = new ObjectiveCParser.enum_specifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal240=null;
        Token char_literal242=null;
        Token char_literal244=null;
        Token char_literal245=null;
        Token char_literal247=null;
        ObjectiveCParser.identifier_return identifier241 =null;

        ObjectiveCParser.enumerator_list_return enumerator_list243 =null;

        ObjectiveCParser.enumerator_list_return enumerator_list246 =null;


        Object string_literal240_tree=null;
        Object char_literal242_tree=null;
        Object char_literal244_tree=null;
        Object char_literal245_tree=null;
        Object char_literal247_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:277:16: ( 'enum' ( identifier ( '{' enumerator_list '}' )? | '{' enumerator_list '}' ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:277:18: 'enum' ( identifier ( '{' enumerator_list '}' )? | '{' enumerator_list '}' )
            {
            root_0 = (Object)adaptor.nil();


            string_literal240=(Token)match(input,101,FOLLOW_101_in_enum_specifier1339); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            string_literal240_tree = 
            (Object)adaptor.create(string_literal240)
            ;
            adaptor.addChild(root_0, string_literal240_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:278:3: ( identifier ( '{' enumerator_list '}' )? | '{' enumerator_list '}' )
            int alt55=2;
            int LA55_0 = input.LA(1);

            if ( (LA55_0==IDENTIFIER) ) {
                alt55=1;
            }
            else if ( (LA55_0==130) ) {
                alt55=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 55, 0, input);

                throw nvae;

            }
            switch (alt55) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:278:5: identifier ( '{' enumerator_list '}' )?
                    {
                    pushFollow(FOLLOW_identifier_in_enum_specifier1346);
                    identifier241=identifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier241.getTree());

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:278:16: ( '{' enumerator_list '}' )?
                    int alt54=2;
                    int LA54_0 = input.LA(1);

                    if ( (LA54_0==130) ) {
                        int LA54_1 = input.LA(2);

                        if ( (synpred117_ObjectiveC()) ) {
                            alt54=1;
                        }
                    }
                    switch (alt54) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:278:17: '{' enumerator_list '}'
                            {
                            char_literal242=(Token)match(input,130,FOLLOW_130_in_enum_specifier1349); if (state.failed) return retval;
                            if ( state.backtracking==0 ) {
                            char_literal242_tree = 
                            (Object)adaptor.create(char_literal242)
                            ;
                            adaptor.addChild(root_0, char_literal242_tree);
                            }

                            pushFollow(FOLLOW_enumerator_list_in_enum_specifier1351);
                            enumerator_list243=enumerator_list();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, enumerator_list243.getTree());

                            char_literal244=(Token)match(input,134,FOLLOW_134_in_enum_specifier1353); if (state.failed) return retval;
                            if ( state.backtracking==0 ) {
                            char_literal244_tree = 
                            (Object)adaptor.create(char_literal244)
                            ;
                            adaptor.addChild(root_0, char_literal244_tree);
                            }

                            }
                            break;

                    }


                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:279:5: '{' enumerator_list '}'
                    {
                    char_literal245=(Token)match(input,130,FOLLOW_130_in_enum_specifier1362); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal245_tree = 
                    (Object)adaptor.create(char_literal245)
                    ;
                    adaptor.addChild(root_0, char_literal245_tree);
                    }

                    pushFollow(FOLLOW_enumerator_list_in_enum_specifier1364);
                    enumerator_list246=enumerator_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, enumerator_list246.getTree());

                    char_literal247=(Token)match(input,134,FOLLOW_134_in_enum_specifier1366); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal247_tree = 
                    (Object)adaptor.create(char_literal247)
                    ;
                    adaptor.addChild(root_0, char_literal247_tree);
                    }

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "enum_specifier"


    public static class enumerator_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "enumerator_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:280:1: enumerator_list : enumerator ( ',' enumerator )* ;
    public final ObjectiveCParser.enumerator_list_return enumerator_list() throws RecognitionException {
        ObjectiveCParser.enumerator_list_return retval = new ObjectiveCParser.enumerator_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal249=null;
        ObjectiveCParser.enumerator_return enumerator248 =null;

        ObjectiveCParser.enumerator_return enumerator250 =null;


        Object char_literal249_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:280:17: ( enumerator ( ',' enumerator )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:280:19: enumerator ( ',' enumerator )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_enumerator_in_enumerator_list1375);
            enumerator248=enumerator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, enumerator248.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:280:30: ( ',' enumerator )*
            loop56:
            do {
                int alt56=2;
                int LA56_0 = input.LA(1);

                if ( (LA56_0==45) ) {
                    alt56=1;
                }


                switch (alt56) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:280:31: ',' enumerator
            	    {
            	    char_literal249=(Token)match(input,45,FOLLOW_45_in_enumerator_list1378); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal249_tree = 
            	    (Object)adaptor.create(char_literal249)
            	    ;
            	    adaptor.addChild(root_0, char_literal249_tree);
            	    }

            	    pushFollow(FOLLOW_enumerator_in_enumerator_list1380);
            	    enumerator250=enumerator();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, enumerator250.getTree());

            	    }
            	    break;

            	default :
            	    break loop56;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "enumerator_list"


    public static class enumerator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "enumerator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:281:1: enumerator : identifier ( '=' constant_expression )? ;
    public final ObjectiveCParser.enumerator_return enumerator() throws RecognitionException {
        ObjectiveCParser.enumerator_return retval = new ObjectiveCParser.enumerator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal252=null;
        ObjectiveCParser.identifier_return identifier251 =null;

        ObjectiveCParser.constant_expression_return constant_expression253 =null;


        Object char_literal252_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:281:12: ( identifier ( '=' constant_expression )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:281:14: identifier ( '=' constant_expression )?
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_identifier_in_enumerator1390);
            identifier251=identifier();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier251.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:281:25: ( '=' constant_expression )?
            int alt57=2;
            int LA57_0 = input.LA(1);

            if ( (LA57_0==61) ) {
                alt57=1;
            }
            switch (alt57) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:281:26: '=' constant_expression
                    {
                    char_literal252=(Token)match(input,61,FOLLOW_61_in_enumerator1393); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal252_tree = 
                    (Object)adaptor.create(char_literal252)
                    ;
                    adaptor.addChild(root_0, char_literal252_tree);
                    }

                    pushFollow(FOLLOW_constant_expression_in_enumerator1395);
                    constant_expression253=constant_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, constant_expression253.getTree());

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "enumerator"


    public static class declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:283:1: declarator : ( '*' ( type_qualifier )* declarator | direct_declarator );
    public final ObjectiveCParser.declarator_return declarator() throws RecognitionException {
        ObjectiveCParser.declarator_return retval = new ObjectiveCParser.declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal254=null;
        ObjectiveCParser.type_qualifier_return type_qualifier255 =null;

        ObjectiveCParser.declarator_return declarator256 =null;

        ObjectiveCParser.direct_declarator_return direct_declarator257 =null;


        Object char_literal254_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:283:12: ( '*' ( type_qualifier )* declarator | direct_declarator )
            int alt59=2;
            int LA59_0 = input.LA(1);

            if ( (LA59_0==40) ) {
                alt59=1;
            }
            else if ( (LA59_0==IDENTIFIER||LA59_0==38) ) {
                alt59=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 59, 0, input);

                throw nvae;

            }
            switch (alt59) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:283:14: '*' ( type_qualifier )* declarator
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal254=(Token)match(input,40,FOLLOW_40_in_declarator1405); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal254_tree = 
                    (Object)adaptor.create(char_literal254)
                    ;
                    adaptor.addChild(root_0, char_literal254_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:283:18: ( type_qualifier )*
                    loop58:
                    do {
                        int alt58=2;
                        int LA58_0 = input.LA(1);

                        if ( ((LA58_0 >= 91 && LA58_0 <= 92)||LA58_0==95||(LA58_0 >= 108 && LA58_0 <= 109)||(LA58_0 >= 112 && LA58_0 <= 113)||LA58_0==128) ) {
                            alt58=1;
                        }


                        switch (alt58) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:283:18: type_qualifier
                    	    {
                    	    pushFollow(FOLLOW_type_qualifier_in_declarator1407);
                    	    type_qualifier255=type_qualifier();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_qualifier255.getTree());

                    	    }
                    	    break;

                    	default :
                    	    break loop58;
                        }
                    } while (true);


                    pushFollow(FOLLOW_declarator_in_declarator1410);
                    declarator256=declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator256.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:283:47: direct_declarator
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_direct_declarator_in_declarator1414);
                    direct_declarator257=direct_declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, direct_declarator257.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "declarator"


    public static class direct_declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "direct_declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:1: direct_declarator : ( identifier ( declarator_suffix )* | '(' declarator ')' ( declarator_suffix )* );
    public final ObjectiveCParser.direct_declarator_return direct_declarator() throws RecognitionException {
        ObjectiveCParser.direct_declarator_return retval = new ObjectiveCParser.direct_declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal260=null;
        Token char_literal262=null;
        ObjectiveCParser.identifier_return identifier258 =null;

        ObjectiveCParser.declarator_suffix_return declarator_suffix259 =null;

        ObjectiveCParser.declarator_return declarator261 =null;

        ObjectiveCParser.declarator_suffix_return declarator_suffix263 =null;


        Object char_literal260_tree=null;
        Object char_literal262_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:19: ( identifier ( declarator_suffix )* | '(' declarator ')' ( declarator_suffix )* )
            int alt62=2;
            int LA62_0 = input.LA(1);

            if ( (LA62_0==IDENTIFIER) ) {
                alt62=1;
            }
            else if ( (LA62_0==38) ) {
                alt62=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 62, 0, input);

                throw nvae;

            }
            switch (alt62) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:21: identifier ( declarator_suffix )*
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_identifier_in_direct_declarator1423);
                    identifier258=identifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier258.getTree());

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:32: ( declarator_suffix )*
                    loop60:
                    do {
                        int alt60=2;
                        int LA60_0 = input.LA(1);

                        if ( (LA60_0==38) ) {
                            int LA60_10 = input.LA(2);

                            if ( (synpred123_ObjectiveC()) ) {
                                alt60=1;
                            }


                        }
                        else if ( (LA60_0==84) ) {
                            alt60=1;
                        }


                        switch (alt60) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:32: declarator_suffix
                    	    {
                    	    pushFollow(FOLLOW_declarator_suffix_in_direct_declarator1425);
                    	    declarator_suffix259=declarator_suffix();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator_suffix259.getTree());

                    	    }
                    	    break;

                    	default :
                    	    break loop60;
                        }
                    } while (true);


                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:286:21: '(' declarator ')' ( declarator_suffix )*
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal260=(Token)match(input,38,FOLLOW_38_in_direct_declarator1448); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal260_tree = 
                    (Object)adaptor.create(char_literal260)
                    ;
                    adaptor.addChild(root_0, char_literal260_tree);
                    }

                    pushFollow(FOLLOW_declarator_in_direct_declarator1450);
                    declarator261=declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator261.getTree());

                    char_literal262=(Token)match(input,39,FOLLOW_39_in_direct_declarator1452); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal262_tree = 
                    (Object)adaptor.create(char_literal262)
                    ;
                    adaptor.addChild(root_0, char_literal262_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:286:40: ( declarator_suffix )*
                    loop61:
                    do {
                        int alt61=2;
                        int LA61_0 = input.LA(1);

                        if ( (LA61_0==38) ) {
                            int LA61_10 = input.LA(2);

                            if ( (synpred125_ObjectiveC()) ) {
                                alt61=1;
                            }


                        }
                        else if ( (LA61_0==84) ) {
                            alt61=1;
                        }


                        switch (alt61) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:286:40: declarator_suffix
                    	    {
                    	    pushFollow(FOLLOW_declarator_suffix_in_direct_declarator1454);
                    	    declarator_suffix263=declarator_suffix();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator_suffix263.getTree());

                    	    }
                    	    break;

                    	default :
                    	    break loop61;
                        }
                    } while (true);


                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "direct_declarator"


    public static class declarator_suffix_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "declarator_suffix"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:288:1: declarator_suffix : ( '[' ( constant_expression )? ']' | '(' ( parameter_list )? ')' );
    public final ObjectiveCParser.declarator_suffix_return declarator_suffix() throws RecognitionException {
        ObjectiveCParser.declarator_suffix_return retval = new ObjectiveCParser.declarator_suffix_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal264=null;
        Token char_literal266=null;
        Token char_literal267=null;
        Token char_literal269=null;
        ObjectiveCParser.constant_expression_return constant_expression265 =null;

        ObjectiveCParser.parameter_list_return parameter_list268 =null;


        Object char_literal264_tree=null;
        Object char_literal266_tree=null;
        Object char_literal267_tree=null;
        Object char_literal269_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:288:19: ( '[' ( constant_expression )? ']' | '(' ( parameter_list )? ')' )
            int alt65=2;
            int LA65_0 = input.LA(1);

            if ( (LA65_0==84) ) {
                alt65=1;
            }
            else if ( (LA65_0==38) ) {
                alt65=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 65, 0, input);

                throw nvae;

            }
            switch (alt65) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:288:21: '[' ( constant_expression )? ']'
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal264=(Token)match(input,84,FOLLOW_84_in_declarator_suffix1464); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal264_tree = 
                    (Object)adaptor.create(char_literal264)
                    ;
                    adaptor.addChild(root_0, char_literal264_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:288:25: ( constant_expression )?
                    int alt63=2;
                    int LA63_0 = input.LA(1);

                    if ( (LA63_0==CHARACTER_LITERAL||LA63_0==DECIMAL_LITERAL||LA63_0==FLOATING_POINT_LITERAL||LA63_0==HEX_LITERAL||LA63_0==IDENTIFIER||LA63_0==OCTAL_LITERAL||LA63_0==STRING_LITERAL||LA63_0==22||LA63_0==36||LA63_0==38||LA63_0==40||LA63_0==43||(LA63_0 >= 46 && LA63_0 <= 47)||LA63_0==70||LA63_0==78||LA63_0==80||LA63_0==84||LA63_0==116||LA63_0==119||LA63_0==135) ) {
                        alt63=1;
                    }
                    switch (alt63) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:288:25: constant_expression
                            {
                            pushFollow(FOLLOW_constant_expression_in_declarator_suffix1466);
                            constant_expression265=constant_expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, constant_expression265.getTree());

                            }
                            break;

                    }


                    char_literal266=(Token)match(input,86,FOLLOW_86_in_declarator_suffix1469); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal266_tree = 
                    (Object)adaptor.create(char_literal266)
                    ;
                    adaptor.addChild(root_0, char_literal266_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:289:7: '(' ( parameter_list )? ')'
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal267=(Token)match(input,38,FOLLOW_38_in_declarator_suffix1477); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal267_tree = 
                    (Object)adaptor.create(char_literal267)
                    ;
                    adaptor.addChild(root_0, char_literal267_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:289:11: ( parameter_list )?
                    int alt64=2;
                    int LA64_0 = input.LA(1);

                    if ( (LA64_0==IDENTIFIER||LA64_0==89||(LA64_0 >= 91 && LA64_0 <= 92)||(LA64_0 >= 94 && LA64_0 <= 95)||LA64_0==99||(LA64_0 >= 101 && LA64_0 <= 103)||LA64_0==106||(LA64_0 >= 108 && LA64_0 <= 114)||(LA64_0 >= 117 && LA64_0 <= 118)||(LA64_0 >= 120 && LA64_0 <= 121)||(LA64_0 >= 124 && LA64_0 <= 128)) ) {
                        alt64=1;
                    }
                    switch (alt64) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:289:11: parameter_list
                            {
                            pushFollow(FOLLOW_parameter_list_in_declarator_suffix1479);
                            parameter_list268=parameter_list();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, parameter_list268.getTree());

                            }
                            break;

                    }


                    char_literal269=(Token)match(input,39,FOLLOW_39_in_declarator_suffix1482); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal269_tree = 
                    (Object)adaptor.create(char_literal269)
                    ;
                    adaptor.addChild(root_0, char_literal269_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "declarator_suffix"


    public static class parameter_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "parameter_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:291:1: parameter_list : parameter_declaration_list ( ',' '...' )? ;
    public final ObjectiveCParser.parameter_list_return parameter_list() throws RecognitionException {
        ObjectiveCParser.parameter_list_return retval = new ObjectiveCParser.parameter_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal271=null;
        Token string_literal272=null;
        ObjectiveCParser.parameter_declaration_list_return parameter_declaration_list270 =null;


        Object char_literal271_tree=null;
        Object string_literal272_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:291:16: ( parameter_declaration_list ( ',' '...' )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:291:18: parameter_declaration_list ( ',' '...' )?
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_parameter_declaration_list_in_parameter_list1490);
            parameter_declaration_list270=parameter_declaration_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, parameter_declaration_list270.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:291:45: ( ',' '...' )?
            int alt66=2;
            int LA66_0 = input.LA(1);

            if ( (LA66_0==45) ) {
                alt66=1;
            }
            switch (alt66) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:291:47: ',' '...'
                    {
                    char_literal271=(Token)match(input,45,FOLLOW_45_in_parameter_list1494); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal271_tree = 
                    (Object)adaptor.create(char_literal271)
                    ;
                    adaptor.addChild(root_0, char_literal271_tree);
                    }

                    string_literal272=(Token)match(input,52,FOLLOW_52_in_parameter_list1496); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal272_tree = 
                    (Object)adaptor.create(string_literal272)
                    ;
                    adaptor.addChild(root_0, string_literal272_tree);
                    }

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "parameter_list"


    public static class parameter_declaration_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "parameter_declaration"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:293:1: parameter_declaration : declaration_specifiers ( ( declarator )? | abstract_declarator ) ;
    public final ObjectiveCParser.parameter_declaration_return parameter_declaration() throws RecognitionException {
        ObjectiveCParser.parameter_declaration_return retval = new ObjectiveCParser.parameter_declaration_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.declaration_specifiers_return declaration_specifiers273 =null;

        ObjectiveCParser.declarator_return declarator274 =null;

        ObjectiveCParser.abstract_declarator_return abstract_declarator275 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:3: ( declaration_specifiers ( ( declarator )? | abstract_declarator ) )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:5: declaration_specifiers ( ( declarator )? | abstract_declarator )
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_declaration_specifiers_in_parameter_declaration1511);
            declaration_specifiers273=declaration_specifiers();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration_specifiers273.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:28: ( ( declarator )? | abstract_declarator )
            int alt68=2;
            switch ( input.LA(1) ) {
            case 40:
                {
                int LA68_1 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 1, input);

                    throw nvae;

                }
                }
                break;
            case IDENTIFIER:
                {
                int LA68_2 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 2, input);

                    throw nvae;

                }
                }
                break;
            case 38:
                {
                int LA68_3 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 3, input);

                    throw nvae;

                }
                }
                break;
            case 45:
                {
                int LA68_4 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 4, input);

                    throw nvae;

                }
                }
                break;
            case 56:
                {
                int LA68_5 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 5, input);

                    throw nvae;

                }
                }
                break;
            case 130:
                {
                int LA68_6 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 6, input);

                    throw nvae;

                }
                }
                break;
            case 39:
                {
                int LA68_7 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 7, input);

                    throw nvae;

                }
                }
                break;
            case EOF:
                {
                int LA68_8 = input.LA(2);

                if ( (synpred131_ObjectiveC()) ) {
                    alt68=1;
                }
                else if ( (true) ) {
                    alt68=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 68, 8, input);

                    throw nvae;

                }
                }
                break;
            case 84:
                {
                alt68=2;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 68, 0, input);

                throw nvae;

            }

            switch (alt68) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: ( declarator )?
                    {
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: ( declarator )?
                    int alt67=2;
                    switch ( input.LA(1) ) {
                        case 40:
                            {
                            int LA67_1 = input.LA(2);

                            if ( (synpred130_ObjectiveC()) ) {
                                alt67=1;
                            }
                            }
                            break;
                        case IDENTIFIER:
                            {
                            int LA67_2 = input.LA(2);

                            if ( (synpred130_ObjectiveC()) ) {
                                alt67=1;
                            }
                            }
                            break;
                        case 38:
                            {
                            int LA67_3 = input.LA(2);

                            if ( (synpred130_ObjectiveC()) ) {
                                alt67=1;
                            }
                            }
                            break;
                    }

                    switch (alt67) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: declarator
                            {
                            pushFollow(FOLLOW_declarator_in_parameter_declaration1514);
                            declarator274=declarator();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, declarator274.getTree());

                            }
                            break;

                    }


                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:43: abstract_declarator
                    {
                    pushFollow(FOLLOW_abstract_declarator_in_parameter_declaration1519);
                    abstract_declarator275=abstract_declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, abstract_declarator275.getTree());

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "parameter_declaration"


    public static class initializer_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "initializer"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:296:1: initializer : ( assignment_expression | '{' initializer ( ',' initializer )* '}' );
    public final ObjectiveCParser.initializer_return initializer() throws RecognitionException {
        ObjectiveCParser.initializer_return retval = new ObjectiveCParser.initializer_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal277=null;
        Token char_literal279=null;
        Token char_literal281=null;
        ObjectiveCParser.assignment_expression_return assignment_expression276 =null;

        ObjectiveCParser.initializer_return initializer278 =null;

        ObjectiveCParser.initializer_return initializer280 =null;


        Object char_literal277_tree=null;
        Object char_literal279_tree=null;
        Object char_literal281_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:296:13: ( assignment_expression | '{' initializer ( ',' initializer )* '}' )
            int alt70=2;
            int LA70_0 = input.LA(1);

            if ( (LA70_0==CHARACTER_LITERAL||LA70_0==DECIMAL_LITERAL||LA70_0==FLOATING_POINT_LITERAL||LA70_0==HEX_LITERAL||LA70_0==IDENTIFIER||LA70_0==OCTAL_LITERAL||LA70_0==STRING_LITERAL||LA70_0==22||LA70_0==36||LA70_0==38||LA70_0==40||LA70_0==43||(LA70_0 >= 46 && LA70_0 <= 47)||LA70_0==70||LA70_0==78||LA70_0==80||LA70_0==84||LA70_0==116||LA70_0==119||LA70_0==135) ) {
                alt70=1;
            }
            else if ( (LA70_0==130) ) {
                alt70=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 70, 0, input);

                throw nvae;

            }
            switch (alt70) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:296:15: assignment_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_assignment_expression_in_initializer1529);
                    assignment_expression276=assignment_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_expression276.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:297:8: '{' initializer ( ',' initializer )* '}'
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal277=(Token)match(input,130,FOLLOW_130_in_initializer1538); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal277_tree = 
                    (Object)adaptor.create(char_literal277)
                    ;
                    adaptor.addChild(root_0, char_literal277_tree);
                    }

                    pushFollow(FOLLOW_initializer_in_initializer1540);
                    initializer278=initializer();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, initializer278.getTree());

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:297:24: ( ',' initializer )*
                    loop69:
                    do {
                        int alt69=2;
                        int LA69_0 = input.LA(1);

                        if ( (LA69_0==45) ) {
                            alt69=1;
                        }


                        switch (alt69) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:297:25: ',' initializer
                    	    {
                    	    char_literal279=(Token)match(input,45,FOLLOW_45_in_initializer1543); if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) {
                    	    char_literal279_tree = 
                    	    (Object)adaptor.create(char_literal279)
                    	    ;
                    	    adaptor.addChild(root_0, char_literal279_tree);
                    	    }

                    	    pushFollow(FOLLOW_initializer_in_initializer1545);
                    	    initializer280=initializer();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, initializer280.getTree());

                    	    }
                    	    break;

                    	default :
                    	    break loop69;
                        }
                    } while (true);


                    char_literal281=(Token)match(input,134,FOLLOW_134_in_initializer1549); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal281_tree = 
                    (Object)adaptor.create(char_literal281)
                    ;
                    adaptor.addChild(root_0, char_literal281_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "initializer"


    public static class type_name_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "type_name"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:299:1: type_name : specifier_qualifier_list abstract_declarator ;
    public final ObjectiveCParser.type_name_return type_name() throws RecognitionException {
        ObjectiveCParser.type_name_return retval = new ObjectiveCParser.type_name_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.specifier_qualifier_list_return specifier_qualifier_list282 =null;

        ObjectiveCParser.abstract_declarator_return abstract_declarator283 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:299:11: ( specifier_qualifier_list abstract_declarator )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:299:13: specifier_qualifier_list abstract_declarator
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_specifier_qualifier_list_in_type_name1558);
            specifier_qualifier_list282=specifier_qualifier_list();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, specifier_qualifier_list282.getTree());

            pushFollow(FOLLOW_abstract_declarator_in_type_name1560);
            abstract_declarator283=abstract_declarator();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, abstract_declarator283.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "type_name"


    public static class abstract_declarator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "abstract_declarator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:1: abstract_declarator : ( '*' ( type_qualifier )* abstract_declarator | '(' abstract_declarator ')' ( abstract_declarator_suffix )+ | ( '[' ( constant_expression )? ']' )+ |);
    public final ObjectiveCParser.abstract_declarator_return abstract_declarator() throws RecognitionException {
        ObjectiveCParser.abstract_declarator_return retval = new ObjectiveCParser.abstract_declarator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal284=null;
        Token char_literal287=null;
        Token char_literal289=null;
        Token char_literal291=null;
        Token char_literal293=null;
        ObjectiveCParser.type_qualifier_return type_qualifier285 =null;

        ObjectiveCParser.abstract_declarator_return abstract_declarator286 =null;

        ObjectiveCParser.abstract_declarator_return abstract_declarator288 =null;

        ObjectiveCParser.abstract_declarator_suffix_return abstract_declarator_suffix290 =null;

        ObjectiveCParser.constant_expression_return constant_expression292 =null;


        Object char_literal284_tree=null;
        Object char_literal287_tree=null;
        Object char_literal289_tree=null;
        Object char_literal291_tree=null;
        Object char_literal293_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:21: ( '*' ( type_qualifier )* abstract_declarator | '(' abstract_declarator ')' ( abstract_declarator_suffix )+ | ( '[' ( constant_expression )? ']' )+ |)
            int alt75=4;
            switch ( input.LA(1) ) {
            case 40:
                {
                int LA75_1 = input.LA(2);

                if ( (synpred135_ObjectiveC()) ) {
                    alt75=1;
                }
                else if ( (true) ) {
                    alt75=4;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 75, 1, input);

                    throw nvae;

                }
                }
                break;
            case 38:
                {
                int LA75_2 = input.LA(2);

                if ( (synpred137_ObjectiveC()) ) {
                    alt75=2;
                }
                else if ( (true) ) {
                    alt75=4;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 75, 2, input);

                    throw nvae;

                }
                }
                break;
            case 84:
                {
                alt75=3;
                }
                break;
            case EOF:
            case IDENTIFIER:
            case 39:
            case 45:
            case 56:
            case 130:
                {
                alt75=4;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 75, 0, input);

                throw nvae;

            }

            switch (alt75) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:23: '*' ( type_qualifier )* abstract_declarator
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal284=(Token)match(input,40,FOLLOW_40_in_abstract_declarator1569); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal284_tree = 
                    (Object)adaptor.create(char_literal284)
                    ;
                    adaptor.addChild(root_0, char_literal284_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:27: ( type_qualifier )*
                    loop71:
                    do {
                        int alt71=2;
                        int LA71_0 = input.LA(1);

                        if ( ((LA71_0 >= 91 && LA71_0 <= 92)||LA71_0==95||(LA71_0 >= 108 && LA71_0 <= 109)||(LA71_0 >= 112 && LA71_0 <= 113)||LA71_0==128) ) {
                            alt71=1;
                        }


                        switch (alt71) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:27: type_qualifier
                    	    {
                    	    pushFollow(FOLLOW_type_qualifier_in_abstract_declarator1571);
                    	    type_qualifier285=type_qualifier();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_qualifier285.getTree());

                    	    }
                    	    break;

                    	default :
                    	    break loop71;
                        }
                    } while (true);


                    pushFollow(FOLLOW_abstract_declarator_in_abstract_declarator1574);
                    abstract_declarator286=abstract_declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, abstract_declarator286.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:5: '(' abstract_declarator ')' ( abstract_declarator_suffix )+
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal287=(Token)match(input,38,FOLLOW_38_in_abstract_declarator1581); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal287_tree = 
                    (Object)adaptor.create(char_literal287)
                    ;
                    adaptor.addChild(root_0, char_literal287_tree);
                    }

                    pushFollow(FOLLOW_abstract_declarator_in_abstract_declarator1583);
                    abstract_declarator288=abstract_declarator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, abstract_declarator288.getTree());

                    char_literal289=(Token)match(input,39,FOLLOW_39_in_abstract_declarator1585); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal289_tree = 
                    (Object)adaptor.create(char_literal289)
                    ;
                    adaptor.addChild(root_0, char_literal289_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:33: ( abstract_declarator_suffix )+
                    int cnt72=0;
                    loop72:
                    do {
                        int alt72=2;
                        int LA72_0 = input.LA(1);

                        if ( (LA72_0==38) ) {
                            int LA72_5 = input.LA(2);

                            if ( (synpred136_ObjectiveC()) ) {
                                alt72=1;
                            }


                        }
                        else if ( (LA72_0==84) ) {
                            alt72=1;
                        }


                        switch (alt72) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:33: abstract_declarator_suffix
                    	    {
                    	    pushFollow(FOLLOW_abstract_declarator_suffix_in_abstract_declarator1587);
                    	    abstract_declarator_suffix290=abstract_declarator_suffix();

                    	    state._fsp--;
                    	    if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) adaptor.addChild(root_0, abstract_declarator_suffix290.getTree());

                    	    }
                    	    break;

                    	default :
                    	    if ( cnt72 >= 1 ) break loop72;
                    	    if (state.backtracking>0) {state.failed=true; return retval;}
                                EarlyExitException eee =
                                    new EarlyExitException(72, input);
                                throw eee;
                        }
                        cnt72++;
                    } while (true);


                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:303:5: ( '[' ( constant_expression )? ']' )+
                    {
                    root_0 = (Object)adaptor.nil();


                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:303:5: ( '[' ( constant_expression )? ']' )+
                    int cnt74=0;
                    loop74:
                    do {
                        int alt74=2;
                        int LA74_0 = input.LA(1);

                        if ( (LA74_0==84) ) {
                            alt74=1;
                        }


                        switch (alt74) {
                    	case 1 :
                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:303:6: '[' ( constant_expression )? ']'
                    	    {
                    	    char_literal291=(Token)match(input,84,FOLLOW_84_in_abstract_declarator1595); if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) {
                    	    char_literal291_tree = 
                    	    (Object)adaptor.create(char_literal291)
                    	    ;
                    	    adaptor.addChild(root_0, char_literal291_tree);
                    	    }

                    	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:303:10: ( constant_expression )?
                    	    int alt73=2;
                    	    int LA73_0 = input.LA(1);

                    	    if ( (LA73_0==CHARACTER_LITERAL||LA73_0==DECIMAL_LITERAL||LA73_0==FLOATING_POINT_LITERAL||LA73_0==HEX_LITERAL||LA73_0==IDENTIFIER||LA73_0==OCTAL_LITERAL||LA73_0==STRING_LITERAL||LA73_0==22||LA73_0==36||LA73_0==38||LA73_0==40||LA73_0==43||(LA73_0 >= 46 && LA73_0 <= 47)||LA73_0==70||LA73_0==78||LA73_0==80||LA73_0==84||LA73_0==116||LA73_0==119||LA73_0==135) ) {
                    	        alt73=1;
                    	    }
                    	    switch (alt73) {
                    	        case 1 :
                    	            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:303:10: constant_expression
                    	            {
                    	            pushFollow(FOLLOW_constant_expression_in_abstract_declarator1597);
                    	            constant_expression292=constant_expression();

                    	            state._fsp--;
                    	            if (state.failed) return retval;
                    	            if ( state.backtracking==0 ) adaptor.addChild(root_0, constant_expression292.getTree());

                    	            }
                    	            break;

                    	    }


                    	    char_literal293=(Token)match(input,86,FOLLOW_86_in_abstract_declarator1600); if (state.failed) return retval;
                    	    if ( state.backtracking==0 ) {
                    	    char_literal293_tree = 
                    	    (Object)adaptor.create(char_literal293)
                    	    ;
                    	    adaptor.addChild(root_0, char_literal293_tree);
                    	    }

                    	    }
                    	    break;

                    	default :
                    	    if ( cnt74 >= 1 ) break loop74;
                    	    if (state.backtracking>0) {state.failed=true; return retval;}
                                EarlyExitException eee =
                                    new EarlyExitException(74, input);
                                throw eee;
                        }
                        cnt74++;
                    } while (true);


                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:304:5: 
                    {
                    root_0 = (Object)adaptor.nil();


                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "abstract_declarator"


    public static class abstract_declarator_suffix_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "abstract_declarator_suffix"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:306:1: abstract_declarator_suffix : ( '[' ( constant_expression )? ']' | '(' ( parameter_declaration_list )? ')' );
    public final ObjectiveCParser.abstract_declarator_suffix_return abstract_declarator_suffix() throws RecognitionException {
        ObjectiveCParser.abstract_declarator_suffix_return retval = new ObjectiveCParser.abstract_declarator_suffix_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal294=null;
        Token char_literal296=null;
        Token char_literal297=null;
        Token char_literal299=null;
        ObjectiveCParser.constant_expression_return constant_expression295 =null;

        ObjectiveCParser.parameter_declaration_list_return parameter_declaration_list298 =null;


        Object char_literal294_tree=null;
        Object char_literal296_tree=null;
        Object char_literal297_tree=null;
        Object char_literal299_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:307:3: ( '[' ( constant_expression )? ']' | '(' ( parameter_declaration_list )? ')' )
            int alt78=2;
            int LA78_0 = input.LA(1);

            if ( (LA78_0==84) ) {
                alt78=1;
            }
            else if ( (LA78_0==38) ) {
                alt78=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 78, 0, input);

                throw nvae;

            }
            switch (alt78) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:307:5: '[' ( constant_expression )? ']'
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal294=(Token)match(input,84,FOLLOW_84_in_abstract_declarator_suffix1617); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal294_tree = 
                    (Object)adaptor.create(char_literal294)
                    ;
                    adaptor.addChild(root_0, char_literal294_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:307:9: ( constant_expression )?
                    int alt76=2;
                    int LA76_0 = input.LA(1);

                    if ( (LA76_0==CHARACTER_LITERAL||LA76_0==DECIMAL_LITERAL||LA76_0==FLOATING_POINT_LITERAL||LA76_0==HEX_LITERAL||LA76_0==IDENTIFIER||LA76_0==OCTAL_LITERAL||LA76_0==STRING_LITERAL||LA76_0==22||LA76_0==36||LA76_0==38||LA76_0==40||LA76_0==43||(LA76_0 >= 46 && LA76_0 <= 47)||LA76_0==70||LA76_0==78||LA76_0==80||LA76_0==84||LA76_0==116||LA76_0==119||LA76_0==135) ) {
                        alt76=1;
                    }
                    switch (alt76) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:307:9: constant_expression
                            {
                            pushFollow(FOLLOW_constant_expression_in_abstract_declarator_suffix1619);
                            constant_expression295=constant_expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, constant_expression295.getTree());

                            }
                            break;

                    }


                    char_literal296=(Token)match(input,86,FOLLOW_86_in_abstract_declarator_suffix1622); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal296_tree = 
                    (Object)adaptor.create(char_literal296)
                    ;
                    adaptor.addChild(root_0, char_literal296_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:308:5: '(' ( parameter_declaration_list )? ')'
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal297=(Token)match(input,38,FOLLOW_38_in_abstract_declarator_suffix1628); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal297_tree = 
                    (Object)adaptor.create(char_literal297)
                    ;
                    adaptor.addChild(root_0, char_literal297_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:308:10: ( parameter_declaration_list )?
                    int alt77=2;
                    int LA77_0 = input.LA(1);

                    if ( (LA77_0==IDENTIFIER||LA77_0==89||(LA77_0 >= 91 && LA77_0 <= 92)||(LA77_0 >= 94 && LA77_0 <= 95)||LA77_0==99||(LA77_0 >= 101 && LA77_0 <= 103)||LA77_0==106||(LA77_0 >= 108 && LA77_0 <= 114)||(LA77_0 >= 117 && LA77_0 <= 118)||(LA77_0 >= 120 && LA77_0 <= 121)||(LA77_0 >= 124 && LA77_0 <= 128)) ) {
                        alt77=1;
                    }
                    switch (alt77) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:308:10: parameter_declaration_list
                            {
                            pushFollow(FOLLOW_parameter_declaration_list_in_abstract_declarator_suffix1631);
                            parameter_declaration_list298=parameter_declaration_list();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, parameter_declaration_list298.getTree());

                            }
                            break;

                    }


                    char_literal299=(Token)match(input,39,FOLLOW_39_in_abstract_declarator_suffix1634); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal299_tree = 
                    (Object)adaptor.create(char_literal299)
                    ;
                    adaptor.addChild(root_0, char_literal299_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "abstract_declarator_suffix"


    public static class parameter_declaration_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "parameter_declaration_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:310:1: parameter_declaration_list : parameter_declaration ( ',' parameter_declaration )* ;
    public final ObjectiveCParser.parameter_declaration_list_return parameter_declaration_list() throws RecognitionException {
        ObjectiveCParser.parameter_declaration_list_return retval = new ObjectiveCParser.parameter_declaration_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal301=null;
        ObjectiveCParser.parameter_declaration_return parameter_declaration300 =null;

        ObjectiveCParser.parameter_declaration_return parameter_declaration302 =null;


        Object char_literal301_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:311:3: ( parameter_declaration ( ',' parameter_declaration )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:311:5: parameter_declaration ( ',' parameter_declaration )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_parameter_declaration_in_parameter_declaration_list1645);
            parameter_declaration300=parameter_declaration();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, parameter_declaration300.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:311:27: ( ',' parameter_declaration )*
            loop79:
            do {
                int alt79=2;
                int LA79_0 = input.LA(1);

                if ( (LA79_0==45) ) {
                    int LA79_1 = input.LA(2);

                    if ( (LA79_1==IDENTIFIER||LA79_1==89||(LA79_1 >= 91 && LA79_1 <= 92)||(LA79_1 >= 94 && LA79_1 <= 95)||LA79_1==99||(LA79_1 >= 101 && LA79_1 <= 103)||LA79_1==106||(LA79_1 >= 108 && LA79_1 <= 114)||(LA79_1 >= 117 && LA79_1 <= 118)||(LA79_1 >= 120 && LA79_1 <= 121)||(LA79_1 >= 124 && LA79_1 <= 128)) ) {
                        alt79=1;
                    }


                }


                switch (alt79) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:311:29: ',' parameter_declaration
            	    {
            	    char_literal301=(Token)match(input,45,FOLLOW_45_in_parameter_declaration_list1649); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal301_tree = 
            	    (Object)adaptor.create(char_literal301)
            	    ;
            	    adaptor.addChild(root_0, char_literal301_tree);
            	    }

            	    pushFollow(FOLLOW_parameter_declaration_in_parameter_declaration_list1651);
            	    parameter_declaration302=parameter_declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, parameter_declaration302.getTree());

            	    }
            	    break;

            	default :
            	    break loop79;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "parameter_declaration_list"


    public static class statement_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "statement_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:313:1: statement_list : ( statement )+ ;
    public final ObjectiveCParser.statement_list_return statement_list() throws RecognitionException {
        ObjectiveCParser.statement_list_return retval = new ObjectiveCParser.statement_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.statement_return statement303 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:313:16: ( ( statement )+ )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:313:18: ( statement )+
            {
            root_0 = (Object)adaptor.nil();


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:313:18: ( statement )+
            int cnt80=0;
            loop80:
            do {
                int alt80=2;
                int LA80_0 = input.LA(1);

                if ( (LA80_0==CHARACTER_LITERAL||LA80_0==DECIMAL_LITERAL||LA80_0==FLOATING_POINT_LITERAL||LA80_0==HEX_LITERAL||LA80_0==IDENTIFIER||LA80_0==OCTAL_LITERAL||LA80_0==STRING_LITERAL||LA80_0==22||LA80_0==36||LA80_0==38||LA80_0==40||LA80_0==43||(LA80_0 >= 46 && LA80_0 <= 47)||LA80_0==56||LA80_0==70||LA80_0==78||LA80_0==80||LA80_0==84||LA80_0==90||LA80_0==93||(LA80_0 >= 96 && LA80_0 <= 98)||(LA80_0 >= 104 && LA80_0 <= 105)||LA80_0==107||(LA80_0 >= 115 && LA80_0 <= 116)||LA80_0==119||LA80_0==123||(LA80_0 >= 129 && LA80_0 <= 130)||LA80_0==135) ) {
                    alt80=1;
                }


                switch (alt80) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:313:19: statement
            	    {
            	    pushFollow(FOLLOW_statement_in_statement_list1664);
            	    statement303=statement();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement303.getTree());

            	    }
            	    break;

            	default :
            	    if ( cnt80 >= 1 ) break loop80;
            	    if (state.backtracking>0) {state.failed=true; return retval;}
                        EarlyExitException eee =
                            new EarlyExitException(80, input);
                        throw eee;
                }
                cnt80++;
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "statement_list"


    public static class statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:315:1: statement : ( labeled_statement | expression ';' | compound_statement | selection_statement | iteration_statement | jump_statement | ';' );
    public final ObjectiveCParser.statement_return statement() throws RecognitionException {
        ObjectiveCParser.statement_return retval = new ObjectiveCParser.statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal306=null;
        Token char_literal311=null;
        ObjectiveCParser.labeled_statement_return labeled_statement304 =null;

        ObjectiveCParser.expression_return expression305 =null;

        ObjectiveCParser.compound_statement_return compound_statement307 =null;

        ObjectiveCParser.selection_statement_return selection_statement308 =null;

        ObjectiveCParser.iteration_statement_return iteration_statement309 =null;

        ObjectiveCParser.jump_statement_return jump_statement310 =null;


        Object char_literal306_tree=null;
        Object char_literal311_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:316:3: ( labeled_statement | expression ';' | compound_statement | selection_statement | iteration_statement | jump_statement | ';' )
            int alt81=7;
            switch ( input.LA(1) ) {
            case IDENTIFIER:
                {
                int LA81_1 = input.LA(2);

                if ( (LA81_1==55) ) {
                    alt81=1;
                }
                else if ( (LA81_1==23||(LA81_1 >= 33 && LA81_1 <= 38)||(LA81_1 >= 40 && LA81_1 <= 50)||(LA81_1 >= 53 && LA81_1 <= 54)||(LA81_1 >= 56 && LA81_1 <= 67)||LA81_1==84||(LA81_1 >= 87 && LA81_1 <= 88)||(LA81_1 >= 131 && LA81_1 <= 133)) ) {
                    alt81=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 81, 1, input);

                    throw nvae;

                }
                }
                break;
            case 93:
            case 97:
                {
                alt81=1;
                }
                break;
            case CHARACTER_LITERAL:
            case DECIMAL_LITERAL:
            case FLOATING_POINT_LITERAL:
            case HEX_LITERAL:
            case OCTAL_LITERAL:
            case STRING_LITERAL:
            case 22:
            case 36:
            case 38:
            case 40:
            case 43:
            case 46:
            case 47:
            case 70:
            case 78:
            case 80:
            case 84:
            case 116:
            case 119:
            case 135:
                {
                alt81=2;
                }
                break;
            case 130:
                {
                alt81=3;
                }
                break;
            case 107:
            case 123:
                {
                alt81=4;
                }
                break;
            case 98:
            case 104:
            case 129:
                {
                alt81=5;
                }
                break;
            case 90:
            case 96:
            case 105:
            case 115:
                {
                alt81=6;
                }
                break;
            case 56:
                {
                alt81=7;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 81, 0, input);

                throw nvae;

            }

            switch (alt81) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:316:5: labeled_statement
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_labeled_statement_in_statement1678);
                    labeled_statement304=labeled_statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, labeled_statement304.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:317:5: expression ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_expression_in_statement1684);
                    expression305=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression305.getTree());

                    char_literal306=(Token)match(input,56,FOLLOW_56_in_statement1686); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal306_tree = 
                    (Object)adaptor.create(char_literal306)
                    ;
                    adaptor.addChild(root_0, char_literal306_tree);
                    }

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:318:5: compound_statement
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_compound_statement_in_statement1692);
                    compound_statement307=compound_statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, compound_statement307.getTree());

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:319:5: selection_statement
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_selection_statement_in_statement1698);
                    selection_statement308=selection_statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, selection_statement308.getTree());

                    }
                    break;
                case 5 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:320:5: iteration_statement
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_iteration_statement_in_statement1704);
                    iteration_statement309=iteration_statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, iteration_statement309.getTree());

                    }
                    break;
                case 6 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:321:5: jump_statement
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_jump_statement_in_statement1710);
                    jump_statement310=jump_statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, jump_statement310.getTree());

                    }
                    break;
                case 7 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:322:5: ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal311=(Token)match(input,56,FOLLOW_56_in_statement1716); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal311_tree = 
                    (Object)adaptor.create(char_literal311)
                    ;
                    adaptor.addChild(root_0, char_literal311_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "statement"


    public static class labeled_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "labeled_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:324:1: labeled_statement : ( identifier ':' statement | 'case' constant_expression ':' statement | 'default' ':' statement );
    public final ObjectiveCParser.labeled_statement_return labeled_statement() throws RecognitionException {
        ObjectiveCParser.labeled_statement_return retval = new ObjectiveCParser.labeled_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal313=null;
        Token string_literal315=null;
        Token char_literal317=null;
        Token string_literal319=null;
        Token char_literal320=null;
        ObjectiveCParser.identifier_return identifier312 =null;

        ObjectiveCParser.statement_return statement314 =null;

        ObjectiveCParser.constant_expression_return constant_expression316 =null;

        ObjectiveCParser.statement_return statement318 =null;

        ObjectiveCParser.statement_return statement321 =null;


        Object char_literal313_tree=null;
        Object string_literal315_tree=null;
        Object char_literal317_tree=null;
        Object string_literal319_tree=null;
        Object char_literal320_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:325:3: ( identifier ':' statement | 'case' constant_expression ':' statement | 'default' ':' statement )
            int alt82=3;
            switch ( input.LA(1) ) {
            case IDENTIFIER:
                {
                alt82=1;
                }
                break;
            case 93:
                {
                alt82=2;
                }
                break;
            case 97:
                {
                alt82=3;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 82, 0, input);

                throw nvae;

            }

            switch (alt82) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:325:5: identifier ':' statement
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_identifier_in_labeled_statement1727);
                    identifier312=identifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier312.getTree());

                    char_literal313=(Token)match(input,55,FOLLOW_55_in_labeled_statement1729); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal313_tree = 
                    (Object)adaptor.create(char_literal313)
                    ;
                    adaptor.addChild(root_0, char_literal313_tree);
                    }

                    pushFollow(FOLLOW_statement_in_labeled_statement1731);
                    statement314=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement314.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:326:5: 'case' constant_expression ':' statement
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal315=(Token)match(input,93,FOLLOW_93_in_labeled_statement1737); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal315_tree = 
                    (Object)adaptor.create(string_literal315)
                    ;
                    adaptor.addChild(root_0, string_literal315_tree);
                    }

                    pushFollow(FOLLOW_constant_expression_in_labeled_statement1739);
                    constant_expression316=constant_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, constant_expression316.getTree());

                    char_literal317=(Token)match(input,55,FOLLOW_55_in_labeled_statement1741); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal317_tree = 
                    (Object)adaptor.create(char_literal317)
                    ;
                    adaptor.addChild(root_0, char_literal317_tree);
                    }

                    pushFollow(FOLLOW_statement_in_labeled_statement1743);
                    statement318=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement318.getTree());

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:327:5: 'default' ':' statement
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal319=(Token)match(input,97,FOLLOW_97_in_labeled_statement1749); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal319_tree = 
                    (Object)adaptor.create(string_literal319)
                    ;
                    adaptor.addChild(root_0, string_literal319_tree);
                    }

                    char_literal320=(Token)match(input,55,FOLLOW_55_in_labeled_statement1751); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal320_tree = 
                    (Object)adaptor.create(char_literal320)
                    ;
                    adaptor.addChild(root_0, char_literal320_tree);
                    }

                    pushFollow(FOLLOW_statement_in_labeled_statement1753);
                    statement321=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement321.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "labeled_statement"


    public static class compound_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "compound_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:1: compound_statement : '{' ( declaration )* ( statement_list )? '}' ;
    public final ObjectiveCParser.compound_statement_return compound_statement() throws RecognitionException {
        ObjectiveCParser.compound_statement_return retval = new ObjectiveCParser.compound_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal322=null;
        Token char_literal325=null;
        ObjectiveCParser.declaration_return declaration323 =null;

        ObjectiveCParser.statement_list_return statement_list324 =null;


        Object char_literal322_tree=null;
        Object char_literal325_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:20: ( '{' ( declaration )* ( statement_list )? '}' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:22: '{' ( declaration )* ( statement_list )? '}'
            {
            root_0 = (Object)adaptor.nil();


            char_literal322=(Token)match(input,130,FOLLOW_130_in_compound_statement1762); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal322_tree = 
            (Object)adaptor.create(char_literal322)
            ;
            adaptor.addChild(root_0, char_literal322_tree);
            }

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:26: ( declaration )*
            loop83:
            do {
                int alt83=2;
                int LA83_0 = input.LA(1);

                if ( (LA83_0==IDENTIFIER) ) {
                    int LA83_1 = input.LA(2);

                    if ( (synpred154_ObjectiveC()) ) {
                        alt83=1;
                    }


                }
                else if ( (LA83_0==89||(LA83_0 >= 91 && LA83_0 <= 92)||(LA83_0 >= 94 && LA83_0 <= 95)||LA83_0==99||(LA83_0 >= 101 && LA83_0 <= 103)||LA83_0==106||(LA83_0 >= 108 && LA83_0 <= 114)||(LA83_0 >= 117 && LA83_0 <= 118)||(LA83_0 >= 120 && LA83_0 <= 121)||(LA83_0 >= 124 && LA83_0 <= 128)) ) {
                    alt83=1;
                }


                switch (alt83) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:27: declaration
            	    {
            	    pushFollow(FOLLOW_declaration_in_compound_statement1765);
            	    declaration323=declaration();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, declaration323.getTree());

            	    }
            	    break;

            	default :
            	    break loop83;
                }
            } while (true);


            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:41: ( statement_list )?
            int alt84=2;
            int LA84_0 = input.LA(1);

            if ( (LA84_0==CHARACTER_LITERAL||LA84_0==DECIMAL_LITERAL||LA84_0==FLOATING_POINT_LITERAL||LA84_0==HEX_LITERAL||LA84_0==IDENTIFIER||LA84_0==OCTAL_LITERAL||LA84_0==STRING_LITERAL||LA84_0==22||LA84_0==36||LA84_0==38||LA84_0==40||LA84_0==43||(LA84_0 >= 46 && LA84_0 <= 47)||LA84_0==56||LA84_0==70||LA84_0==78||LA84_0==80||LA84_0==84||LA84_0==90||LA84_0==93||(LA84_0 >= 96 && LA84_0 <= 98)||(LA84_0 >= 104 && LA84_0 <= 105)||LA84_0==107||(LA84_0 >= 115 && LA84_0 <= 116)||LA84_0==119||LA84_0==123||(LA84_0 >= 129 && LA84_0 <= 130)||LA84_0==135) ) {
                alt84=1;
            }
            switch (alt84) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:41: statement_list
                    {
                    pushFollow(FOLLOW_statement_list_in_compound_statement1769);
                    statement_list324=statement_list();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement_list324.getTree());

                    }
                    break;

            }


            char_literal325=(Token)match(input,134,FOLLOW_134_in_compound_statement1772); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            char_literal325_tree = 
            (Object)adaptor.create(char_literal325)
            ;
            adaptor.addChild(root_0, char_literal325_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "compound_statement"


    public static class selection_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "selection_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:331:1: selection_statement : ( 'if' '(' expression ')' statement ( 'else' statement )? | 'switch' '(' expression ')' statement );
    public final ObjectiveCParser.selection_statement_return selection_statement() throws RecognitionException {
        ObjectiveCParser.selection_statement_return retval = new ObjectiveCParser.selection_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal326=null;
        Token char_literal327=null;
        Token char_literal329=null;
        Token string_literal331=null;
        Token string_literal333=null;
        Token char_literal334=null;
        Token char_literal336=null;
        ObjectiveCParser.expression_return expression328 =null;

        ObjectiveCParser.statement_return statement330 =null;

        ObjectiveCParser.statement_return statement332 =null;

        ObjectiveCParser.expression_return expression335 =null;

        ObjectiveCParser.statement_return statement337 =null;


        Object string_literal326_tree=null;
        Object char_literal327_tree=null;
        Object char_literal329_tree=null;
        Object string_literal331_tree=null;
        Object string_literal333_tree=null;
        Object char_literal334_tree=null;
        Object char_literal336_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:332:3: ( 'if' '(' expression ')' statement ( 'else' statement )? | 'switch' '(' expression ')' statement )
            int alt86=2;
            int LA86_0 = input.LA(1);

            if ( (LA86_0==107) ) {
                alt86=1;
            }
            else if ( (LA86_0==123) ) {
                alt86=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 86, 0, input);

                throw nvae;

            }
            switch (alt86) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:332:5: 'if' '(' expression ')' statement ( 'else' statement )?
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal326=(Token)match(input,107,FOLLOW_107_in_selection_statement1783); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal326_tree = 
                    (Object)adaptor.create(string_literal326)
                    ;
                    adaptor.addChild(root_0, string_literal326_tree);
                    }

                    char_literal327=(Token)match(input,38,FOLLOW_38_in_selection_statement1785); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal327_tree = 
                    (Object)adaptor.create(char_literal327)
                    ;
                    adaptor.addChild(root_0, char_literal327_tree);
                    }

                    pushFollow(FOLLOW_expression_in_selection_statement1787);
                    expression328=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression328.getTree());

                    char_literal329=(Token)match(input,39,FOLLOW_39_in_selection_statement1789); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal329_tree = 
                    (Object)adaptor.create(char_literal329)
                    ;
                    adaptor.addChild(root_0, char_literal329_tree);
                    }

                    pushFollow(FOLLOW_statement_in_selection_statement1791);
                    statement330=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement330.getTree());

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:332:39: ( 'else' statement )?
                    int alt85=2;
                    int LA85_0 = input.LA(1);

                    if ( (LA85_0==100) ) {
                        int LA85_1 = input.LA(2);

                        if ( (synpred156_ObjectiveC()) ) {
                            alt85=1;
                        }
                    }
                    switch (alt85) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:332:40: 'else' statement
                            {
                            string_literal331=(Token)match(input,100,FOLLOW_100_in_selection_statement1794); if (state.failed) return retval;
                            if ( state.backtracking==0 ) {
                            string_literal331_tree = 
                            (Object)adaptor.create(string_literal331)
                            ;
                            adaptor.addChild(root_0, string_literal331_tree);
                            }

                            pushFollow(FOLLOW_statement_in_selection_statement1796);
                            statement332=statement();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, statement332.getTree());

                            }
                            break;

                    }


                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:333:5: 'switch' '(' expression ')' statement
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal333=(Token)match(input,123,FOLLOW_123_in_selection_statement1804); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal333_tree = 
                    (Object)adaptor.create(string_literal333)
                    ;
                    adaptor.addChild(root_0, string_literal333_tree);
                    }

                    char_literal334=(Token)match(input,38,FOLLOW_38_in_selection_statement1806); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal334_tree = 
                    (Object)adaptor.create(char_literal334)
                    ;
                    adaptor.addChild(root_0, char_literal334_tree);
                    }

                    pushFollow(FOLLOW_expression_in_selection_statement1808);
                    expression335=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression335.getTree());

                    char_literal336=(Token)match(input,39,FOLLOW_39_in_selection_statement1810); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal336_tree = 
                    (Object)adaptor.create(char_literal336)
                    ;
                    adaptor.addChild(root_0, char_literal336_tree);
                    }

                    pushFollow(FOLLOW_statement_in_selection_statement1812);
                    statement337=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement337.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "selection_statement"


    public static class iteration_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "iteration_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:335:1: iteration_statement : ( 'while' '(' expression ')' statement | 'do' statement 'while' '(' expression ')' ';' | 'for' '(' ( expression )? ';' ( expression )? ';' ( expression )? ')' statement );
    public final ObjectiveCParser.iteration_statement_return iteration_statement() throws RecognitionException {
        ObjectiveCParser.iteration_statement_return retval = new ObjectiveCParser.iteration_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal338=null;
        Token char_literal339=null;
        Token char_literal341=null;
        Token string_literal343=null;
        Token string_literal345=null;
        Token char_literal346=null;
        Token char_literal348=null;
        Token char_literal349=null;
        Token string_literal350=null;
        Token char_literal351=null;
        Token char_literal353=null;
        Token char_literal355=null;
        Token char_literal357=null;
        ObjectiveCParser.expression_return expression340 =null;

        ObjectiveCParser.statement_return statement342 =null;

        ObjectiveCParser.statement_return statement344 =null;

        ObjectiveCParser.expression_return expression347 =null;

        ObjectiveCParser.expression_return expression352 =null;

        ObjectiveCParser.expression_return expression354 =null;

        ObjectiveCParser.expression_return expression356 =null;

        ObjectiveCParser.statement_return statement358 =null;


        Object string_literal338_tree=null;
        Object char_literal339_tree=null;
        Object char_literal341_tree=null;
        Object string_literal343_tree=null;
        Object string_literal345_tree=null;
        Object char_literal346_tree=null;
        Object char_literal348_tree=null;
        Object char_literal349_tree=null;
        Object string_literal350_tree=null;
        Object char_literal351_tree=null;
        Object char_literal353_tree=null;
        Object char_literal355_tree=null;
        Object char_literal357_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:336:3: ( 'while' '(' expression ')' statement | 'do' statement 'while' '(' expression ')' ';' | 'for' '(' ( expression )? ';' ( expression )? ';' ( expression )? ')' statement )
            int alt90=3;
            switch ( input.LA(1) ) {
            case 129:
                {
                alt90=1;
                }
                break;
            case 98:
                {
                alt90=2;
                }
                break;
            case 104:
                {
                alt90=3;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 90, 0, input);

                throw nvae;

            }

            switch (alt90) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:336:5: 'while' '(' expression ')' statement
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal338=(Token)match(input,129,FOLLOW_129_in_iteration_statement1823); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal338_tree = 
                    (Object)adaptor.create(string_literal338)
                    ;
                    adaptor.addChild(root_0, string_literal338_tree);
                    }

                    char_literal339=(Token)match(input,38,FOLLOW_38_in_iteration_statement1825); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal339_tree = 
                    (Object)adaptor.create(char_literal339)
                    ;
                    adaptor.addChild(root_0, char_literal339_tree);
                    }

                    pushFollow(FOLLOW_expression_in_iteration_statement1827);
                    expression340=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression340.getTree());

                    char_literal341=(Token)match(input,39,FOLLOW_39_in_iteration_statement1829); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal341_tree = 
                    (Object)adaptor.create(char_literal341)
                    ;
                    adaptor.addChild(root_0, char_literal341_tree);
                    }

                    pushFollow(FOLLOW_statement_in_iteration_statement1831);
                    statement342=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement342.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:337:5: 'do' statement 'while' '(' expression ')' ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal343=(Token)match(input,98,FOLLOW_98_in_iteration_statement1837); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal343_tree = 
                    (Object)adaptor.create(string_literal343)
                    ;
                    adaptor.addChild(root_0, string_literal343_tree);
                    }

                    pushFollow(FOLLOW_statement_in_iteration_statement1839);
                    statement344=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement344.getTree());

                    string_literal345=(Token)match(input,129,FOLLOW_129_in_iteration_statement1841); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal345_tree = 
                    (Object)adaptor.create(string_literal345)
                    ;
                    adaptor.addChild(root_0, string_literal345_tree);
                    }

                    char_literal346=(Token)match(input,38,FOLLOW_38_in_iteration_statement1843); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal346_tree = 
                    (Object)adaptor.create(char_literal346)
                    ;
                    adaptor.addChild(root_0, char_literal346_tree);
                    }

                    pushFollow(FOLLOW_expression_in_iteration_statement1845);
                    expression347=expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression347.getTree());

                    char_literal348=(Token)match(input,39,FOLLOW_39_in_iteration_statement1847); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal348_tree = 
                    (Object)adaptor.create(char_literal348)
                    ;
                    adaptor.addChild(root_0, char_literal348_tree);
                    }

                    char_literal349=(Token)match(input,56,FOLLOW_56_in_iteration_statement1849); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal349_tree = 
                    (Object)adaptor.create(char_literal349)
                    ;
                    adaptor.addChild(root_0, char_literal349_tree);
                    }

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:5: 'for' '(' ( expression )? ';' ( expression )? ';' ( expression )? ')' statement
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal350=(Token)match(input,104,FOLLOW_104_in_iteration_statement1855); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal350_tree = 
                    (Object)adaptor.create(string_literal350)
                    ;
                    adaptor.addChild(root_0, string_literal350_tree);
                    }

                    char_literal351=(Token)match(input,38,FOLLOW_38_in_iteration_statement1857); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal351_tree = 
                    (Object)adaptor.create(char_literal351)
                    ;
                    adaptor.addChild(root_0, char_literal351_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:15: ( expression )?
                    int alt87=2;
                    int LA87_0 = input.LA(1);

                    if ( (LA87_0==CHARACTER_LITERAL||LA87_0==DECIMAL_LITERAL||LA87_0==FLOATING_POINT_LITERAL||LA87_0==HEX_LITERAL||LA87_0==IDENTIFIER||LA87_0==OCTAL_LITERAL||LA87_0==STRING_LITERAL||LA87_0==22||LA87_0==36||LA87_0==38||LA87_0==40||LA87_0==43||(LA87_0 >= 46 && LA87_0 <= 47)||LA87_0==70||LA87_0==78||LA87_0==80||LA87_0==84||LA87_0==116||LA87_0==119||LA87_0==135) ) {
                        alt87=1;
                    }
                    switch (alt87) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:15: expression
                            {
                            pushFollow(FOLLOW_expression_in_iteration_statement1859);
                            expression352=expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, expression352.getTree());

                            }
                            break;

                    }


                    char_literal353=(Token)match(input,56,FOLLOW_56_in_iteration_statement1862); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal353_tree = 
                    (Object)adaptor.create(char_literal353)
                    ;
                    adaptor.addChild(root_0, char_literal353_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:31: ( expression )?
                    int alt88=2;
                    int LA88_0 = input.LA(1);

                    if ( (LA88_0==CHARACTER_LITERAL||LA88_0==DECIMAL_LITERAL||LA88_0==FLOATING_POINT_LITERAL||LA88_0==HEX_LITERAL||LA88_0==IDENTIFIER||LA88_0==OCTAL_LITERAL||LA88_0==STRING_LITERAL||LA88_0==22||LA88_0==36||LA88_0==38||LA88_0==40||LA88_0==43||(LA88_0 >= 46 && LA88_0 <= 47)||LA88_0==70||LA88_0==78||LA88_0==80||LA88_0==84||LA88_0==116||LA88_0==119||LA88_0==135) ) {
                        alt88=1;
                    }
                    switch (alt88) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:31: expression
                            {
                            pushFollow(FOLLOW_expression_in_iteration_statement1864);
                            expression354=expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, expression354.getTree());

                            }
                            break;

                    }


                    char_literal355=(Token)match(input,56,FOLLOW_56_in_iteration_statement1867); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal355_tree = 
                    (Object)adaptor.create(char_literal355)
                    ;
                    adaptor.addChild(root_0, char_literal355_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:47: ( expression )?
                    int alt89=2;
                    int LA89_0 = input.LA(1);

                    if ( (LA89_0==CHARACTER_LITERAL||LA89_0==DECIMAL_LITERAL||LA89_0==FLOATING_POINT_LITERAL||LA89_0==HEX_LITERAL||LA89_0==IDENTIFIER||LA89_0==OCTAL_LITERAL||LA89_0==STRING_LITERAL||LA89_0==22||LA89_0==36||LA89_0==38||LA89_0==40||LA89_0==43||(LA89_0 >= 46 && LA89_0 <= 47)||LA89_0==70||LA89_0==78||LA89_0==80||LA89_0==84||LA89_0==116||LA89_0==119||LA89_0==135) ) {
                        alt89=1;
                    }
                    switch (alt89) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:338:47: expression
                            {
                            pushFollow(FOLLOW_expression_in_iteration_statement1869);
                            expression356=expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, expression356.getTree());

                            }
                            break;

                    }


                    char_literal357=(Token)match(input,39,FOLLOW_39_in_iteration_statement1872); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal357_tree = 
                    (Object)adaptor.create(char_literal357)
                    ;
                    adaptor.addChild(root_0, char_literal357_tree);
                    }

                    pushFollow(FOLLOW_statement_in_iteration_statement1874);
                    statement358=statement();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, statement358.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "iteration_statement"


    public static class jump_statement_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "jump_statement"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:340:1: jump_statement : ( 'goto' identifier ';' | 'continue' ';' | 'break' ';' | 'return' ( expression )? ';' );
    public final ObjectiveCParser.jump_statement_return jump_statement() throws RecognitionException {
        ObjectiveCParser.jump_statement_return retval = new ObjectiveCParser.jump_statement_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal359=null;
        Token char_literal361=null;
        Token string_literal362=null;
        Token char_literal363=null;
        Token string_literal364=null;
        Token char_literal365=null;
        Token string_literal366=null;
        Token char_literal368=null;
        ObjectiveCParser.identifier_return identifier360 =null;

        ObjectiveCParser.expression_return expression367 =null;


        Object string_literal359_tree=null;
        Object char_literal361_tree=null;
        Object string_literal362_tree=null;
        Object char_literal363_tree=null;
        Object string_literal364_tree=null;
        Object char_literal365_tree=null;
        Object string_literal366_tree=null;
        Object char_literal368_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:341:3: ( 'goto' identifier ';' | 'continue' ';' | 'break' ';' | 'return' ( expression )? ';' )
            int alt92=4;
            switch ( input.LA(1) ) {
            case 105:
                {
                alt92=1;
                }
                break;
            case 96:
                {
                alt92=2;
                }
                break;
            case 90:
                {
                alt92=3;
                }
                break;
            case 115:
                {
                alt92=4;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 92, 0, input);

                throw nvae;

            }

            switch (alt92) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:341:5: 'goto' identifier ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal359=(Token)match(input,105,FOLLOW_105_in_jump_statement1885); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal359_tree = 
                    (Object)adaptor.create(string_literal359)
                    ;
                    adaptor.addChild(root_0, string_literal359_tree);
                    }

                    pushFollow(FOLLOW_identifier_in_jump_statement1887);
                    identifier360=identifier();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier360.getTree());

                    char_literal361=(Token)match(input,56,FOLLOW_56_in_jump_statement1889); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal361_tree = 
                    (Object)adaptor.create(char_literal361)
                    ;
                    adaptor.addChild(root_0, char_literal361_tree);
                    }

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:342:5: 'continue' ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal362=(Token)match(input,96,FOLLOW_96_in_jump_statement1895); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal362_tree = 
                    (Object)adaptor.create(string_literal362)
                    ;
                    adaptor.addChild(root_0, string_literal362_tree);
                    }

                    char_literal363=(Token)match(input,56,FOLLOW_56_in_jump_statement1897); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal363_tree = 
                    (Object)adaptor.create(char_literal363)
                    ;
                    adaptor.addChild(root_0, char_literal363_tree);
                    }

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:343:5: 'break' ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal364=(Token)match(input,90,FOLLOW_90_in_jump_statement1903); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal364_tree = 
                    (Object)adaptor.create(string_literal364)
                    ;
                    adaptor.addChild(root_0, string_literal364_tree);
                    }

                    char_literal365=(Token)match(input,56,FOLLOW_56_in_jump_statement1905); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal365_tree = 
                    (Object)adaptor.create(char_literal365)
                    ;
                    adaptor.addChild(root_0, char_literal365_tree);
                    }

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:344:5: 'return' ( expression )? ';'
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal366=(Token)match(input,115,FOLLOW_115_in_jump_statement1911); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal366_tree = 
                    (Object)adaptor.create(string_literal366)
                    ;
                    adaptor.addChild(root_0, string_literal366_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:344:14: ( expression )?
                    int alt91=2;
                    int LA91_0 = input.LA(1);

                    if ( (LA91_0==CHARACTER_LITERAL||LA91_0==DECIMAL_LITERAL||LA91_0==FLOATING_POINT_LITERAL||LA91_0==HEX_LITERAL||LA91_0==IDENTIFIER||LA91_0==OCTAL_LITERAL||LA91_0==STRING_LITERAL||LA91_0==22||LA91_0==36||LA91_0==38||LA91_0==40||LA91_0==43||(LA91_0 >= 46 && LA91_0 <= 47)||LA91_0==70||LA91_0==78||LA91_0==80||LA91_0==84||LA91_0==116||LA91_0==119||LA91_0==135) ) {
                        alt91=1;
                    }
                    switch (alt91) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:344:14: expression
                            {
                            pushFollow(FOLLOW_expression_in_jump_statement1913);
                            expression367=expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, expression367.getTree());

                            }
                            break;

                    }


                    char_literal368=(Token)match(input,56,FOLLOW_56_in_jump_statement1916); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal368_tree = 
                    (Object)adaptor.create(char_literal368)
                    ;
                    adaptor.addChild(root_0, char_literal368_tree);
                    }

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "jump_statement"


    public static class expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:347:1: expression : assignment_expression ( ',' assignment_expression )* ;
    public final ObjectiveCParser.expression_return expression() throws RecognitionException {
        ObjectiveCParser.expression_return retval = new ObjectiveCParser.expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal370=null;
        ObjectiveCParser.assignment_expression_return assignment_expression369 =null;

        ObjectiveCParser.assignment_expression_return assignment_expression371 =null;


        Object char_literal370_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:347:12: ( assignment_expression ( ',' assignment_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:347:14: assignment_expression ( ',' assignment_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_assignment_expression_in_expression1928);
            assignment_expression369=assignment_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_expression369.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:347:36: ( ',' assignment_expression )*
            loop93:
            do {
                int alt93=2;
                int LA93_0 = input.LA(1);

                if ( (LA93_0==45) ) {
                    alt93=1;
                }


                switch (alt93) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:347:37: ',' assignment_expression
            	    {
            	    char_literal370=(Token)match(input,45,FOLLOW_45_in_expression1931); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal370_tree = 
            	    (Object)adaptor.create(char_literal370)
            	    ;
            	    adaptor.addChild(root_0, char_literal370_tree);
            	    }

            	    pushFollow(FOLLOW_assignment_expression_in_expression1933);
            	    assignment_expression371=assignment_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_expression371.getTree());

            	    }
            	    break;

            	default :
            	    break loop93;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "expression"


    public static class assignment_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "assignment_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:349:1: assignment_expression : conditional_expression ( assignment_operator assignment_expression )? ;
    public final ObjectiveCParser.assignment_expression_return assignment_expression() throws RecognitionException {
        ObjectiveCParser.assignment_expression_return retval = new ObjectiveCParser.assignment_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.conditional_expression_return conditional_expression372 =null;

        ObjectiveCParser.assignment_operator_return assignment_operator373 =null;

        ObjectiveCParser.assignment_expression_return assignment_expression374 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:349:23: ( conditional_expression ( assignment_operator assignment_expression )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:349:25: conditional_expression ( assignment_operator assignment_expression )?
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_conditional_expression_in_assignment_expression1944);
            conditional_expression372=conditional_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, conditional_expression372.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:350:3: ( assignment_operator assignment_expression )?
            int alt94=2;
            int LA94_0 = input.LA(1);

            if ( (LA94_0==34||LA94_0==37||LA94_0==41||LA94_0==44||LA94_0==48||LA94_0==54||LA94_0==59||LA94_0==61||LA94_0==66||LA94_0==88||LA94_0==132) ) {
                alt94=1;
            }
            switch (alt94) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:350:5: assignment_operator assignment_expression
                    {
                    pushFollow(FOLLOW_assignment_operator_in_assignment_expression1951);
                    assignment_operator373=assignment_operator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_operator373.getTree());

                    pushFollow(FOLLOW_assignment_expression_in_assignment_expression1953);
                    assignment_expression374=assignment_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_expression374.getTree());

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "assignment_expression"


    public static class assignment_operator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "assignment_operator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:351:1: assignment_operator : ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|=' );
    public final ObjectiveCParser.assignment_operator_return assignment_operator() throws RecognitionException {
        ObjectiveCParser.assignment_operator_return retval = new ObjectiveCParser.assignment_operator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set375=null;

        Object set375_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:351:20: ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|=' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            {
            root_0 = (Object)adaptor.nil();


            set375=(Token)input.LT(1);

            if ( input.LA(1)==34||input.LA(1)==37||input.LA(1)==41||input.LA(1)==44||input.LA(1)==48||input.LA(1)==54||input.LA(1)==59||input.LA(1)==61||input.LA(1)==66||input.LA(1)==88||input.LA(1)==132 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set375)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "assignment_operator"


    public static class conditional_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "conditional_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:354:1: conditional_expression : logical_or_expression ( '?' logical_or_expression ':' logical_or_expression )? ;
    public final ObjectiveCParser.conditional_expression_return conditional_expression() throws RecognitionException {
        ObjectiveCParser.conditional_expression_return retval = new ObjectiveCParser.conditional_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal377=null;
        Token char_literal379=null;
        ObjectiveCParser.logical_or_expression_return logical_or_expression376 =null;

        ObjectiveCParser.logical_or_expression_return logical_or_expression378 =null;

        ObjectiveCParser.logical_or_expression_return logical_or_expression380 =null;


        Object char_literal377_tree=null;
        Object char_literal379_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:354:24: ( logical_or_expression ( '?' logical_or_expression ':' logical_or_expression )? )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:354:26: logical_or_expression ( '?' logical_or_expression ':' logical_or_expression )?
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_logical_or_expression_in_conditional_expression2013);
            logical_or_expression376=logical_or_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, logical_or_expression376.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:355:3: ( '?' logical_or_expression ':' logical_or_expression )?
            int alt95=2;
            int LA95_0 = input.LA(1);

            if ( (LA95_0==67) ) {
                alt95=1;
            }
            switch (alt95) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:355:4: '?' logical_or_expression ':' logical_or_expression
                    {
                    char_literal377=(Token)match(input,67,FOLLOW_67_in_conditional_expression2019); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal377_tree = 
                    (Object)adaptor.create(char_literal377)
                    ;
                    adaptor.addChild(root_0, char_literal377_tree);
                    }

                    pushFollow(FOLLOW_logical_or_expression_in_conditional_expression2021);
                    logical_or_expression378=logical_or_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, logical_or_expression378.getTree());

                    char_literal379=(Token)match(input,55,FOLLOW_55_in_conditional_expression2023); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal379_tree = 
                    (Object)adaptor.create(char_literal379)
                    ;
                    adaptor.addChild(root_0, char_literal379_tree);
                    }

                    pushFollow(FOLLOW_logical_or_expression_in_conditional_expression2025);
                    logical_or_expression380=logical_or_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, logical_or_expression380.getTree());

                    }
                    break;

            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "conditional_expression"


    public static class constant_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "constant_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:357:1: constant_expression : conditional_expression ;
    public final ObjectiveCParser.constant_expression_return constant_expression() throws RecognitionException {
        ObjectiveCParser.constant_expression_return retval = new ObjectiveCParser.constant_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        ObjectiveCParser.conditional_expression_return conditional_expression381 =null;



        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:357:21: ( conditional_expression )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:357:23: conditional_expression
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_conditional_expression_in_constant_expression2036);
            conditional_expression381=conditional_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, conditional_expression381.getTree());

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "constant_expression"


    public static class logical_or_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "logical_or_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:359:1: logical_or_expression : logical_and_expression ( '||' logical_and_expression )* ;
    public final ObjectiveCParser.logical_or_expression_return logical_or_expression() throws RecognitionException {
        ObjectiveCParser.logical_or_expression_return retval = new ObjectiveCParser.logical_or_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal383=null;
        ObjectiveCParser.logical_and_expression_return logical_and_expression382 =null;

        ObjectiveCParser.logical_and_expression_return logical_and_expression384 =null;


        Object string_literal383_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:359:23: ( logical_and_expression ( '||' logical_and_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:359:25: logical_and_expression ( '||' logical_and_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_logical_and_expression_in_logical_or_expression2045);
            logical_and_expression382=logical_and_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, logical_and_expression382.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:360:3: ( '||' logical_and_expression )*
            loop96:
            do {
                int alt96=2;
                int LA96_0 = input.LA(1);

                if ( (LA96_0==133) ) {
                    alt96=1;
                }


                switch (alt96) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:360:4: '||' logical_and_expression
            	    {
            	    string_literal383=(Token)match(input,133,FOLLOW_133_in_logical_or_expression2051); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    string_literal383_tree = 
            	    (Object)adaptor.create(string_literal383)
            	    ;
            	    adaptor.addChild(root_0, string_literal383_tree);
            	    }

            	    pushFollow(FOLLOW_logical_and_expression_in_logical_or_expression2053);
            	    logical_and_expression384=logical_and_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, logical_and_expression384.getTree());

            	    }
            	    break;

            	default :
            	    break loop96;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "logical_or_expression"


    public static class logical_and_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "logical_and_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:362:1: logical_and_expression : inclusive_or_expression ( '&&' inclusive_or_expression )* ;
    public final ObjectiveCParser.logical_and_expression_return logical_and_expression() throws RecognitionException {
        ObjectiveCParser.logical_and_expression_return retval = new ObjectiveCParser.logical_and_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal386=null;
        ObjectiveCParser.inclusive_or_expression_return inclusive_or_expression385 =null;

        ObjectiveCParser.inclusive_or_expression_return inclusive_or_expression387 =null;


        Object string_literal386_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:362:24: ( inclusive_or_expression ( '&&' inclusive_or_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:362:26: inclusive_or_expression ( '&&' inclusive_or_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_inclusive_or_expression_in_logical_and_expression2064);
            inclusive_or_expression385=inclusive_or_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, inclusive_or_expression385.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:363:3: ( '&&' inclusive_or_expression )*
            loop97:
            do {
                int alt97=2;
                int LA97_0 = input.LA(1);

                if ( (LA97_0==35) ) {
                    alt97=1;
                }


                switch (alt97) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:363:4: '&&' inclusive_or_expression
            	    {
            	    string_literal386=(Token)match(input,35,FOLLOW_35_in_logical_and_expression2070); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    string_literal386_tree = 
            	    (Object)adaptor.create(string_literal386)
            	    ;
            	    adaptor.addChild(root_0, string_literal386_tree);
            	    }

            	    pushFollow(FOLLOW_inclusive_or_expression_in_logical_and_expression2072);
            	    inclusive_or_expression387=inclusive_or_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, inclusive_or_expression387.getTree());

            	    }
            	    break;

            	default :
            	    break loop97;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "logical_and_expression"


    public static class inclusive_or_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "inclusive_or_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:365:1: inclusive_or_expression : exclusive_or_expression ( '|' exclusive_or_expression )* ;
    public final ObjectiveCParser.inclusive_or_expression_return inclusive_or_expression() throws RecognitionException {
        ObjectiveCParser.inclusive_or_expression_return retval = new ObjectiveCParser.inclusive_or_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal389=null;
        ObjectiveCParser.exclusive_or_expression_return exclusive_or_expression388 =null;

        ObjectiveCParser.exclusive_or_expression_return exclusive_or_expression390 =null;


        Object char_literal389_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:365:25: ( exclusive_or_expression ( '|' exclusive_or_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:365:27: exclusive_or_expression ( '|' exclusive_or_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_exclusive_or_expression_in_inclusive_or_expression2083);
            exclusive_or_expression388=exclusive_or_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, exclusive_or_expression388.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:366:3: ( '|' exclusive_or_expression )*
            loop98:
            do {
                int alt98=2;
                int LA98_0 = input.LA(1);

                if ( (LA98_0==131) ) {
                    alt98=1;
                }


                switch (alt98) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:366:4: '|' exclusive_or_expression
            	    {
            	    char_literal389=(Token)match(input,131,FOLLOW_131_in_inclusive_or_expression2089); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal389_tree = 
            	    (Object)adaptor.create(char_literal389)
            	    ;
            	    adaptor.addChild(root_0, char_literal389_tree);
            	    }

            	    pushFollow(FOLLOW_exclusive_or_expression_in_inclusive_or_expression2091);
            	    exclusive_or_expression390=exclusive_or_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, exclusive_or_expression390.getTree());

            	    }
            	    break;

            	default :
            	    break loop98;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "inclusive_or_expression"


    public static class exclusive_or_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "exclusive_or_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:368:1: exclusive_or_expression : and_expression ( '^' and_expression )* ;
    public final ObjectiveCParser.exclusive_or_expression_return exclusive_or_expression() throws RecognitionException {
        ObjectiveCParser.exclusive_or_expression_return retval = new ObjectiveCParser.exclusive_or_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal392=null;
        ObjectiveCParser.and_expression_return and_expression391 =null;

        ObjectiveCParser.and_expression_return and_expression393 =null;


        Object char_literal392_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:368:25: ( and_expression ( '^' and_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:368:27: and_expression ( '^' and_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_and_expression_in_exclusive_or_expression2102);
            and_expression391=and_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, and_expression391.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:368:42: ( '^' and_expression )*
            loop99:
            do {
                int alt99=2;
                int LA99_0 = input.LA(1);

                if ( (LA99_0==87) ) {
                    alt99=1;
                }


                switch (alt99) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:368:43: '^' and_expression
            	    {
            	    char_literal392=(Token)match(input,87,FOLLOW_87_in_exclusive_or_expression2105); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal392_tree = 
            	    (Object)adaptor.create(char_literal392)
            	    ;
            	    adaptor.addChild(root_0, char_literal392_tree);
            	    }

            	    pushFollow(FOLLOW_and_expression_in_exclusive_or_expression2107);
            	    and_expression393=and_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, and_expression393.getTree());

            	    }
            	    break;

            	default :
            	    break loop99;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "exclusive_or_expression"


    public static class and_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "and_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:370:1: and_expression : equality_expression ( '&' equality_expression )* ;
    public final ObjectiveCParser.and_expression_return and_expression() throws RecognitionException {
        ObjectiveCParser.and_expression_return retval = new ObjectiveCParser.and_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal395=null;
        ObjectiveCParser.equality_expression_return equality_expression394 =null;

        ObjectiveCParser.equality_expression_return equality_expression396 =null;


        Object char_literal395_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:370:16: ( equality_expression ( '&' equality_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:370:18: equality_expression ( '&' equality_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_equality_expression_in_and_expression2118);
            equality_expression394=equality_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, equality_expression394.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:370:38: ( '&' equality_expression )*
            loop100:
            do {
                int alt100=2;
                int LA100_0 = input.LA(1);

                if ( (LA100_0==36) ) {
                    alt100=1;
                }


                switch (alt100) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:370:39: '&' equality_expression
            	    {
            	    char_literal395=(Token)match(input,36,FOLLOW_36_in_and_expression2121); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal395_tree = 
            	    (Object)adaptor.create(char_literal395)
            	    ;
            	    adaptor.addChild(root_0, char_literal395_tree);
            	    }

            	    pushFollow(FOLLOW_equality_expression_in_and_expression2123);
            	    equality_expression396=equality_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, equality_expression396.getTree());

            	    }
            	    break;

            	default :
            	    break loop100;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "and_expression"


    public static class equality_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "equality_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:372:1: equality_expression : relational_expression ( ( '!=' | '==' ) relational_expression )* ;
    public final ObjectiveCParser.equality_expression_return equality_expression() throws RecognitionException {
        ObjectiveCParser.equality_expression_return retval = new ObjectiveCParser.equality_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set398=null;
        ObjectiveCParser.relational_expression_return relational_expression397 =null;

        ObjectiveCParser.relational_expression_return relational_expression399 =null;


        Object set398_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:372:21: ( relational_expression ( ( '!=' | '==' ) relational_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:372:23: relational_expression ( ( '!=' | '==' ) relational_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_relational_expression_in_equality_expression2134);
            relational_expression397=relational_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, relational_expression397.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:373:3: ( ( '!=' | '==' ) relational_expression )*
            loop101:
            do {
                int alt101=2;
                int LA101_0 = input.LA(1);

                if ( (LA101_0==23||LA101_0==62) ) {
                    alt101=1;
                }


                switch (alt101) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:373:4: ( '!=' | '==' ) relational_expression
            	    {
            	    set398=(Token)input.LT(1);

            	    if ( input.LA(1)==23||input.LA(1)==62 ) {
            	        input.consume();
            	        if ( state.backtracking==0 ) adaptor.addChild(root_0, 
            	        (Object)adaptor.create(set398)
            	        );
            	        state.errorRecovery=false;
            	        state.failed=false;
            	    }
            	    else {
            	        if (state.backtracking>0) {state.failed=true; return retval;}
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        throw mse;
            	    }


            	    pushFollow(FOLLOW_relational_expression_in_equality_expression2148);
            	    relational_expression399=relational_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, relational_expression399.getTree());

            	    }
            	    break;

            	default :
            	    break loop101;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "equality_expression"


    public static class relational_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "relational_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:375:1: relational_expression : shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )* ;
    public final ObjectiveCParser.relational_expression_return relational_expression() throws RecognitionException {
        ObjectiveCParser.relational_expression_return retval = new ObjectiveCParser.relational_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set401=null;
        ObjectiveCParser.shift_expression_return shift_expression400 =null;

        ObjectiveCParser.shift_expression_return shift_expression402 =null;


        Object set401_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:375:23: ( shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:375:25: shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_shift_expression_in_relational_expression2159);
            shift_expression400=shift_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, shift_expression400.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:376:2: ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*
            loop102:
            do {
                int alt102=2;
                int LA102_0 = input.LA(1);

                if ( (LA102_0==57||LA102_0==60||(LA102_0 >= 63 && LA102_0 <= 64)) ) {
                    alt102=1;
                }


                switch (alt102) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:376:3: ( '<' | '>' | '<=' | '>=' ) shift_expression
            	    {
            	    set401=(Token)input.LT(1);

            	    if ( input.LA(1)==57||input.LA(1)==60||(input.LA(1) >= 63 && input.LA(1) <= 64) ) {
            	        input.consume();
            	        if ( state.backtracking==0 ) adaptor.addChild(root_0, 
            	        (Object)adaptor.create(set401)
            	        );
            	        state.errorRecovery=false;
            	        state.failed=false;
            	    }
            	    else {
            	        if (state.backtracking>0) {state.failed=true; return retval;}
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        throw mse;
            	    }


            	    pushFollow(FOLLOW_shift_expression_in_relational_expression2179);
            	    shift_expression402=shift_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, shift_expression402.getTree());

            	    }
            	    break;

            	default :
            	    break loop102;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "relational_expression"


    public static class shift_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "shift_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:378:1: shift_expression : additive_expression ( ( '<<' | '>>' ) additive_expression )* ;
    public final ObjectiveCParser.shift_expression_return shift_expression() throws RecognitionException {
        ObjectiveCParser.shift_expression_return retval = new ObjectiveCParser.shift_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set404=null;
        ObjectiveCParser.additive_expression_return additive_expression403 =null;

        ObjectiveCParser.additive_expression_return additive_expression405 =null;


        Object set404_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:378:18: ( additive_expression ( ( '<<' | '>>' ) additive_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:378:20: additive_expression ( ( '<<' | '>>' ) additive_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_additive_expression_in_shift_expression2190);
            additive_expression403=additive_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, additive_expression403.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:378:40: ( ( '<<' | '>>' ) additive_expression )*
            loop103:
            do {
                int alt103=2;
                int LA103_0 = input.LA(1);

                if ( (LA103_0==58||LA103_0==65) ) {
                    alt103=1;
                }


                switch (alt103) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:378:41: ( '<<' | '>>' ) additive_expression
            	    {
            	    set404=(Token)input.LT(1);

            	    if ( input.LA(1)==58||input.LA(1)==65 ) {
            	        input.consume();
            	        if ( state.backtracking==0 ) adaptor.addChild(root_0, 
            	        (Object)adaptor.create(set404)
            	        );
            	        state.errorRecovery=false;
            	        state.failed=false;
            	    }
            	    else {
            	        if (state.backtracking>0) {state.failed=true; return retval;}
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        throw mse;
            	    }


            	    pushFollow(FOLLOW_additive_expression_in_shift_expression2201);
            	    additive_expression405=additive_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, additive_expression405.getTree());

            	    }
            	    break;

            	default :
            	    break loop103;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "shift_expression"


    public static class additive_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "additive_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:380:1: additive_expression : multiplicative_expression ( ( '+' | '-' ) multiplicative_expression )* ;
    public final ObjectiveCParser.additive_expression_return additive_expression() throws RecognitionException {
        ObjectiveCParser.additive_expression_return retval = new ObjectiveCParser.additive_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set407=null;
        ObjectiveCParser.multiplicative_expression_return multiplicative_expression406 =null;

        ObjectiveCParser.multiplicative_expression_return multiplicative_expression408 =null;


        Object set407_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:380:21: ( multiplicative_expression ( ( '+' | '-' ) multiplicative_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:380:23: multiplicative_expression ( ( '+' | '-' ) multiplicative_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_multiplicative_expression_in_additive_expression2212);
            multiplicative_expression406=multiplicative_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, multiplicative_expression406.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:381:3: ( ( '+' | '-' ) multiplicative_expression )*
            loop104:
            do {
                int alt104=2;
                int LA104_0 = input.LA(1);

                if ( (LA104_0==42||LA104_0==46) ) {
                    alt104=1;
                }


                switch (alt104) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:381:4: ( '+' | '-' ) multiplicative_expression
            	    {
            	    set407=(Token)input.LT(1);

            	    if ( input.LA(1)==42||input.LA(1)==46 ) {
            	        input.consume();
            	        if ( state.backtracking==0 ) adaptor.addChild(root_0, 
            	        (Object)adaptor.create(set407)
            	        );
            	        state.errorRecovery=false;
            	        state.failed=false;
            	    }
            	    else {
            	        if (state.backtracking>0) {state.failed=true; return retval;}
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        throw mse;
            	    }


            	    pushFollow(FOLLOW_multiplicative_expression_in_additive_expression2225);
            	    multiplicative_expression408=multiplicative_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, multiplicative_expression408.getTree());

            	    }
            	    break;

            	default :
            	    break loop104;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "additive_expression"


    public static class multiplicative_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "multiplicative_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:383:1: multiplicative_expression : cast_expression ( ( '*' | '/' | '%' ) cast_expression )* ;
    public final ObjectiveCParser.multiplicative_expression_return multiplicative_expression() throws RecognitionException {
        ObjectiveCParser.multiplicative_expression_return retval = new ObjectiveCParser.multiplicative_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set410=null;
        ObjectiveCParser.cast_expression_return cast_expression409 =null;

        ObjectiveCParser.cast_expression_return cast_expression411 =null;


        Object set410_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:383:27: ( cast_expression ( ( '*' | '/' | '%' ) cast_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:383:29: cast_expression ( ( '*' | '/' | '%' ) cast_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_cast_expression_in_multiplicative_expression2236);
            cast_expression409=cast_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, cast_expression409.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:384:3: ( ( '*' | '/' | '%' ) cast_expression )*
            loop105:
            do {
                int alt105=2;
                int LA105_0 = input.LA(1);

                if ( (LA105_0==33||LA105_0==40||LA105_0==53) ) {
                    alt105=1;
                }


                switch (alt105) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:384:4: ( '*' | '/' | '%' ) cast_expression
            	    {
            	    set410=(Token)input.LT(1);

            	    if ( input.LA(1)==33||input.LA(1)==40||input.LA(1)==53 ) {
            	        input.consume();
            	        if ( state.backtracking==0 ) adaptor.addChild(root_0, 
            	        (Object)adaptor.create(set410)
            	        );
            	        state.errorRecovery=false;
            	        state.failed=false;
            	    }
            	    else {
            	        if (state.backtracking>0) {state.failed=true; return retval;}
            	        MismatchedSetException mse = new MismatchedSetException(null,input);
            	        throw mse;
            	    }


            	    pushFollow(FOLLOW_cast_expression_in_multiplicative_expression2254);
            	    cast_expression411=cast_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, cast_expression411.getTree());

            	    }
            	    break;

            	default :
            	    break loop105;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "multiplicative_expression"


    public static class cast_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "cast_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:386:1: cast_expression : ( '(' type_name ')' cast_expression | unary_expression );
    public final ObjectiveCParser.cast_expression_return cast_expression() throws RecognitionException {
        ObjectiveCParser.cast_expression_return retval = new ObjectiveCParser.cast_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal412=null;
        Token char_literal414=null;
        ObjectiveCParser.type_name_return type_name413 =null;

        ObjectiveCParser.cast_expression_return cast_expression415 =null;

        ObjectiveCParser.unary_expression_return unary_expression416 =null;


        Object char_literal412_tree=null;
        Object char_literal414_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:386:17: ( '(' type_name ')' cast_expression | unary_expression )
            int alt106=2;
            int LA106_0 = input.LA(1);

            if ( (LA106_0==38) ) {
                int LA106_1 = input.LA(2);

                if ( (synpred198_ObjectiveC()) ) {
                    alt106=1;
                }
                else if ( (true) ) {
                    alt106=2;
                }
                else {
                    if (state.backtracking>0) {state.failed=true; return retval;}
                    NoViableAltException nvae =
                        new NoViableAltException("", 106, 1, input);

                    throw nvae;

                }
            }
            else if ( (LA106_0==CHARACTER_LITERAL||LA106_0==DECIMAL_LITERAL||LA106_0==FLOATING_POINT_LITERAL||LA106_0==HEX_LITERAL||LA106_0==IDENTIFIER||LA106_0==OCTAL_LITERAL||LA106_0==STRING_LITERAL||LA106_0==22||LA106_0==36||LA106_0==40||LA106_0==43||(LA106_0 >= 46 && LA106_0 <= 47)||LA106_0==70||LA106_0==78||LA106_0==80||LA106_0==84||LA106_0==116||LA106_0==119||LA106_0==135) ) {
                alt106=2;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 106, 0, input);

                throw nvae;

            }
            switch (alt106) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:386:19: '(' type_name ')' cast_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    char_literal412=(Token)match(input,38,FOLLOW_38_in_cast_expression2265); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal412_tree = 
                    (Object)adaptor.create(char_literal412)
                    ;
                    adaptor.addChild(root_0, char_literal412_tree);
                    }

                    pushFollow(FOLLOW_type_name_in_cast_expression2267);
                    type_name413=type_name();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, type_name413.getTree());

                    char_literal414=(Token)match(input,39,FOLLOW_39_in_cast_expression2269); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    char_literal414_tree = 
                    (Object)adaptor.create(char_literal414)
                    ;
                    adaptor.addChild(root_0, char_literal414_tree);
                    }

                    pushFollow(FOLLOW_cast_expression_in_cast_expression2271);
                    cast_expression415=cast_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, cast_expression415.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:386:55: unary_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_unary_expression_in_cast_expression2275);
                    unary_expression416=unary_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, unary_expression416.getTree());

                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "cast_expression"


    public static class unary_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "unary_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:388:1: unary_expression : ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' ( '(' type_name ')' | unary_expression ) );
    public final ObjectiveCParser.unary_expression_return unary_expression() throws RecognitionException {
        ObjectiveCParser.unary_expression_return retval = new ObjectiveCParser.unary_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token string_literal418=null;
        Token string_literal420=null;
        Token string_literal424=null;
        Token char_literal425=null;
        Token char_literal427=null;
        ObjectiveCParser.postfix_expression_return postfix_expression417 =null;

        ObjectiveCParser.unary_expression_return unary_expression419 =null;

        ObjectiveCParser.unary_expression_return unary_expression421 =null;

        ObjectiveCParser.unary_operator_return unary_operator422 =null;

        ObjectiveCParser.cast_expression_return cast_expression423 =null;

        ObjectiveCParser.type_name_return type_name426 =null;

        ObjectiveCParser.unary_expression_return unary_expression428 =null;


        Object string_literal418_tree=null;
        Object string_literal420_tree=null;
        Object string_literal424_tree=null;
        Object char_literal425_tree=null;
        Object char_literal427_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:389:3: ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' ( '(' type_name ')' | unary_expression ) )
            int alt108=5;
            switch ( input.LA(1) ) {
            case CHARACTER_LITERAL:
            case DECIMAL_LITERAL:
            case FLOATING_POINT_LITERAL:
            case HEX_LITERAL:
            case IDENTIFIER:
            case OCTAL_LITERAL:
            case STRING_LITERAL:
            case 38:
            case 70:
            case 78:
            case 80:
            case 84:
            case 116:
                {
                alt108=1;
                }
                break;
            case 43:
                {
                alt108=2;
                }
                break;
            case 47:
                {
                alt108=3;
                }
                break;
            case 22:
            case 36:
            case 40:
            case 46:
            case 135:
                {
                alt108=4;
                }
                break;
            case 119:
                {
                alt108=5;
                }
                break;
            default:
                if (state.backtracking>0) {state.failed=true; return retval;}
                NoViableAltException nvae =
                    new NoViableAltException("", 108, 0, input);

                throw nvae;

            }

            switch (alt108) {
                case 1 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:389:5: postfix_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_postfix_expression_in_unary_expression2287);
                    postfix_expression417=postfix_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, postfix_expression417.getTree());

                    }
                    break;
                case 2 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:390:5: '++' unary_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal418=(Token)match(input,43,FOLLOW_43_in_unary_expression2293); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal418_tree = 
                    (Object)adaptor.create(string_literal418)
                    ;
                    adaptor.addChild(root_0, string_literal418_tree);
                    }

                    pushFollow(FOLLOW_unary_expression_in_unary_expression2295);
                    unary_expression419=unary_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, unary_expression419.getTree());

                    }
                    break;
                case 3 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:391:5: '--' unary_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal420=(Token)match(input,47,FOLLOW_47_in_unary_expression2301); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal420_tree = 
                    (Object)adaptor.create(string_literal420)
                    ;
                    adaptor.addChild(root_0, string_literal420_tree);
                    }

                    pushFollow(FOLLOW_unary_expression_in_unary_expression2303);
                    unary_expression421=unary_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, unary_expression421.getTree());

                    }
                    break;
                case 4 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:392:5: unary_operator cast_expression
                    {
                    root_0 = (Object)adaptor.nil();


                    pushFollow(FOLLOW_unary_operator_in_unary_expression2309);
                    unary_operator422=unary_operator();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, unary_operator422.getTree());

                    pushFollow(FOLLOW_cast_expression_in_unary_expression2311);
                    cast_expression423=cast_expression();

                    state._fsp--;
                    if (state.failed) return retval;
                    if ( state.backtracking==0 ) adaptor.addChild(root_0, cast_expression423.getTree());

                    }
                    break;
                case 5 :
                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:393:5: 'sizeof' ( '(' type_name ')' | unary_expression )
                    {
                    root_0 = (Object)adaptor.nil();


                    string_literal424=(Token)match(input,119,FOLLOW_119_in_unary_expression2317); if (state.failed) return retval;
                    if ( state.backtracking==0 ) {
                    string_literal424_tree = 
                    (Object)adaptor.create(string_literal424)
                    ;
                    adaptor.addChild(root_0, string_literal424_tree);
                    }

                    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:393:14: ( '(' type_name ')' | unary_expression )
                    int alt107=2;
                    int LA107_0 = input.LA(1);

                    if ( (LA107_0==38) ) {
                        int LA107_1 = input.LA(2);

                        if ( (synpred203_ObjectiveC()) ) {
                            alt107=1;
                        }
                        else if ( (true) ) {
                            alt107=2;
                        }
                        else {
                            if (state.backtracking>0) {state.failed=true; return retval;}
                            NoViableAltException nvae =
                                new NoViableAltException("", 107, 1, input);

                            throw nvae;

                        }
                    }
                    else if ( (LA107_0==CHARACTER_LITERAL||LA107_0==DECIMAL_LITERAL||LA107_0==FLOATING_POINT_LITERAL||LA107_0==HEX_LITERAL||LA107_0==IDENTIFIER||LA107_0==OCTAL_LITERAL||LA107_0==STRING_LITERAL||LA107_0==22||LA107_0==36||LA107_0==40||LA107_0==43||(LA107_0 >= 46 && LA107_0 <= 47)||LA107_0==70||LA107_0==78||LA107_0==80||LA107_0==84||LA107_0==116||LA107_0==119||LA107_0==135) ) {
                        alt107=2;
                    }
                    else {
                        if (state.backtracking>0) {state.failed=true; return retval;}
                        NoViableAltException nvae =
                            new NoViableAltException("", 107, 0, input);

                        throw nvae;

                    }
                    switch (alt107) {
                        case 1 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:393:15: '(' type_name ')'
                            {
                            char_literal425=(Token)match(input,38,FOLLOW_38_in_unary_expression2320); if (state.failed) return retval;
                            if ( state.backtracking==0 ) {
                            char_literal425_tree = 
                            (Object)adaptor.create(char_literal425)
                            ;
                            adaptor.addChild(root_0, char_literal425_tree);
                            }

                            pushFollow(FOLLOW_type_name_in_unary_expression2322);
                            type_name426=type_name();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, type_name426.getTree());

                            char_literal427=(Token)match(input,39,FOLLOW_39_in_unary_expression2324); if (state.failed) return retval;
                            if ( state.backtracking==0 ) {
                            char_literal427_tree = 
                            (Object)adaptor.create(char_literal427)
                            ;
                            adaptor.addChild(root_0, char_literal427_tree);
                            }

                            }
                            break;
                        case 2 :
                            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:393:35: unary_expression
                            {
                            pushFollow(FOLLOW_unary_expression_in_unary_expression2328);
                            unary_expression428=unary_expression();

                            state._fsp--;
                            if (state.failed) return retval;
                            if ( state.backtracking==0 ) adaptor.addChild(root_0, unary_expression428.getTree());

                            }
                            break;

                    }


                    }
                    break;

            }
            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "unary_expression"


    public static class unary_operator_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "unary_operator"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:395:1: unary_operator : ( '&' | '*' | '-' | '~' | '!' );
    public final ObjectiveCParser.unary_operator_return unary_operator() throws RecognitionException {
        ObjectiveCParser.unary_operator_return retval = new ObjectiveCParser.unary_operator_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set429=null;

        Object set429_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:395:16: ( '&' | '*' | '-' | '~' | '!' )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            {
            root_0 = (Object)adaptor.nil();


            set429=(Token)input.LT(1);

            if ( input.LA(1)==22||input.LA(1)==36||input.LA(1)==40||input.LA(1)==46||input.LA(1)==135 ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set429)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "unary_operator"


    public static class postfix_expression_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "postfix_expression"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:397:1: postfix_expression : primary_expression ( '[' expression ']' | '(' ( argument_expression_list )? ')' | '.' identifier | '->' identifier | '++' | '--' )* ;
    public final ObjectiveCParser.postfix_expression_return postfix_expression() throws RecognitionException {
        ObjectiveCParser.postfix_expression_return retval = new ObjectiveCParser.postfix_expression_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal431=null;
        Token char_literal433=null;
        Token char_literal434=null;
        Token char_literal436=null;
        Token char_literal437=null;
        Token string_literal439=null;
        Token string_literal441=null;
        Token string_literal442=null;
        ObjectiveCParser.primary_expression_return primary_expression430 =null;

        ObjectiveCParser.expression_return expression432 =null;

        ObjectiveCParser.argument_expression_list_return argument_expression_list435 =null;

        ObjectiveCParser.identifier_return identifier438 =null;

        ObjectiveCParser.identifier_return identifier440 =null;


        Object char_literal431_tree=null;
        Object char_literal433_tree=null;
        Object char_literal434_tree=null;
        Object char_literal436_tree=null;
        Object char_literal437_tree=null;
        Object string_literal439_tree=null;
        Object string_literal441_tree=null;
        Object string_literal442_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:397:20: ( primary_expression ( '[' expression ']' | '(' ( argument_expression_list )? ')' | '.' identifier | '->' identifier | '++' | '--' )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:397:22: primary_expression ( '[' expression ']' | '(' ( argument_expression_list )? ')' | '.' identifier | '->' identifier | '++' | '--' )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_primary_expression_in_postfix_expression2363);
            primary_expression430=primary_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, primary_expression430.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:398:3: ( '[' expression ']' | '(' ( argument_expression_list )? ')' | '.' identifier | '->' identifier | '++' | '--' )*
            loop110:
            do {
                int alt110=7;
                switch ( input.LA(1) ) {
                case 84:
                    {
                    alt110=1;
                    }
                    break;
                case 38:
                    {
                    alt110=2;
                    }
                    break;
                case 50:
                    {
                    alt110=3;
                    }
                    break;
                case 49:
                    {
                    alt110=4;
                    }
                    break;
                case 43:
                    {
                    alt110=5;
                    }
                    break;
                case 47:
                    {
                    alt110=6;
                    }
                    break;

                }

                switch (alt110) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:398:4: '[' expression ']'
            	    {
            	    char_literal431=(Token)match(input,84,FOLLOW_84_in_postfix_expression2368); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal431_tree = 
            	    (Object)adaptor.create(char_literal431)
            	    ;
            	    adaptor.addChild(root_0, char_literal431_tree);
            	    }

            	    pushFollow(FOLLOW_expression_in_postfix_expression2370);
            	    expression432=expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, expression432.getTree());

            	    char_literal433=(Token)match(input,86,FOLLOW_86_in_postfix_expression2372); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal433_tree = 
            	    (Object)adaptor.create(char_literal433)
            	    ;
            	    adaptor.addChild(root_0, char_literal433_tree);
            	    }

            	    }
            	    break;
            	case 2 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:399:5: '(' ( argument_expression_list )? ')'
            	    {
            	    char_literal434=(Token)match(input,38,FOLLOW_38_in_postfix_expression2379); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal434_tree = 
            	    (Object)adaptor.create(char_literal434)
            	    ;
            	    adaptor.addChild(root_0, char_literal434_tree);
            	    }

            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:399:9: ( argument_expression_list )?
            	    int alt109=2;
            	    int LA109_0 = input.LA(1);

            	    if ( (LA109_0==CHARACTER_LITERAL||LA109_0==DECIMAL_LITERAL||LA109_0==FLOATING_POINT_LITERAL||LA109_0==HEX_LITERAL||LA109_0==IDENTIFIER||LA109_0==OCTAL_LITERAL||LA109_0==STRING_LITERAL||LA109_0==22||LA109_0==36||LA109_0==38||LA109_0==40||LA109_0==43||(LA109_0 >= 46 && LA109_0 <= 47)||LA109_0==70||LA109_0==78||LA109_0==80||LA109_0==84||LA109_0==116||LA109_0==119||LA109_0==135) ) {
            	        alt109=1;
            	    }
            	    switch (alt109) {
            	        case 1 :
            	            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:399:9: argument_expression_list
            	            {
            	            pushFollow(FOLLOW_argument_expression_list_in_postfix_expression2381);
            	            argument_expression_list435=argument_expression_list();

            	            state._fsp--;
            	            if (state.failed) return retval;
            	            if ( state.backtracking==0 ) adaptor.addChild(root_0, argument_expression_list435.getTree());

            	            }
            	            break;

            	    }


            	    char_literal436=(Token)match(input,39,FOLLOW_39_in_postfix_expression2384); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal436_tree = 
            	    (Object)adaptor.create(char_literal436)
            	    ;
            	    adaptor.addChild(root_0, char_literal436_tree);
            	    }

            	    }
            	    break;
            	case 3 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:400:5: '.' identifier
            	    {
            	    char_literal437=(Token)match(input,50,FOLLOW_50_in_postfix_expression2390); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal437_tree = 
            	    (Object)adaptor.create(char_literal437)
            	    ;
            	    adaptor.addChild(root_0, char_literal437_tree);
            	    }

            	    pushFollow(FOLLOW_identifier_in_postfix_expression2392);
            	    identifier438=identifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier438.getTree());

            	    }
            	    break;
            	case 4 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:401:5: '->' identifier
            	    {
            	    string_literal439=(Token)match(input,49,FOLLOW_49_in_postfix_expression2398); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    string_literal439_tree = 
            	    (Object)adaptor.create(string_literal439)
            	    ;
            	    adaptor.addChild(root_0, string_literal439_tree);
            	    }

            	    pushFollow(FOLLOW_identifier_in_postfix_expression2400);
            	    identifier440=identifier();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, identifier440.getTree());

            	    }
            	    break;
            	case 5 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:402:5: '++'
            	    {
            	    string_literal441=(Token)match(input,43,FOLLOW_43_in_postfix_expression2406); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    string_literal441_tree = 
            	    (Object)adaptor.create(string_literal441)
            	    ;
            	    adaptor.addChild(root_0, string_literal441_tree);
            	    }

            	    }
            	    break;
            	case 6 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:403:5: '--'
            	    {
            	    string_literal442=(Token)match(input,47,FOLLOW_47_in_postfix_expression2412); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    string_literal442_tree = 
            	    (Object)adaptor.create(string_literal442)
            	    ;
            	    adaptor.addChild(root_0, string_literal442_tree);
            	    }

            	    }
            	    break;

            	default :
            	    break loop110;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "postfix_expression"


    public static class argument_expression_list_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "argument_expression_list"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:406:1: argument_expression_list : assignment_expression ( ',' assignment_expression )* ;
    public final ObjectiveCParser.argument_expression_list_return argument_expression_list() throws RecognitionException {
        ObjectiveCParser.argument_expression_list_return retval = new ObjectiveCParser.argument_expression_list_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token char_literal444=null;
        ObjectiveCParser.assignment_expression_return assignment_expression443 =null;

        ObjectiveCParser.assignment_expression_return assignment_expression445 =null;


        Object char_literal444_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:407:3: ( assignment_expression ( ',' assignment_expression )* )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:407:5: assignment_expression ( ',' assignment_expression )*
            {
            root_0 = (Object)adaptor.nil();


            pushFollow(FOLLOW_assignment_expression_in_argument_expression_list2428);
            assignment_expression443=assignment_expression();

            state._fsp--;
            if (state.failed) return retval;
            if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_expression443.getTree());

            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:407:27: ( ',' assignment_expression )*
            loop111:
            do {
                int alt111=2;
                int LA111_0 = input.LA(1);

                if ( (LA111_0==45) ) {
                    alt111=1;
                }


                switch (alt111) {
            	case 1 :
            	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:407:28: ',' assignment_expression
            	    {
            	    char_literal444=(Token)match(input,45,FOLLOW_45_in_argument_expression_list2431); if (state.failed) return retval;
            	    if ( state.backtracking==0 ) {
            	    char_literal444_tree = 
            	    (Object)adaptor.create(char_literal444)
            	    ;
            	    adaptor.addChild(root_0, char_literal444_tree);
            	    }

            	    pushFollow(FOLLOW_assignment_expression_in_argument_expression_list2433);
            	    assignment_expression445=assignment_expression();

            	    state._fsp--;
            	    if (state.failed) return retval;
            	    if ( state.backtracking==0 ) adaptor.addChild(root_0, assignment_expression445.getTree());

            	    }
            	    break;

            	default :
            	    break loop111;
                }
            } while (true);


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "argument_expression_list"


    public static class identifier_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "identifier"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:409:1: identifier : IDENTIFIER ;
    public final ObjectiveCParser.identifier_return identifier() throws RecognitionException {
        ObjectiveCParser.identifier_return retval = new ObjectiveCParser.identifier_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token IDENTIFIER446=null;

        Object IDENTIFIER446_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:409:12: ( IDENTIFIER )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:409:14: IDENTIFIER
            {
            root_0 = (Object)adaptor.nil();


            IDENTIFIER446=(Token)match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_identifier2444); if (state.failed) return retval;
            if ( state.backtracking==0 ) {
            IDENTIFIER446_tree = 
            (Object)adaptor.create(IDENTIFIER446)
            ;
            adaptor.addChild(root_0, IDENTIFIER446_tree);
            }

            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "identifier"


    public static class constant_return extends ParserRuleReturnScope {
        Object tree;
        public Object getTree() { return tree; }
    };


    // $ANTLR start "constant"
    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:411:1: constant : ( DECIMAL_LITERAL | HEX_LITERAL | OCTAL_LITERAL | CHARACTER_LITERAL | FLOATING_POINT_LITERAL );
    public final ObjectiveCParser.constant_return constant() throws RecognitionException {
        ObjectiveCParser.constant_return retval = new ObjectiveCParser.constant_return();
        retval.start = input.LT(1);


        Object root_0 = null;

        Token set447=null;

        Object set447_tree=null;

        try {
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:411:10: ( DECIMAL_LITERAL | HEX_LITERAL | OCTAL_LITERAL | CHARACTER_LITERAL | FLOATING_POINT_LITERAL )
            // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:
            {
            root_0 = (Object)adaptor.nil();


            set447=(Token)input.LT(1);

            if ( input.LA(1)==CHARACTER_LITERAL||input.LA(1)==DECIMAL_LITERAL||input.LA(1)==FLOATING_POINT_LITERAL||input.LA(1)==HEX_LITERAL||input.LA(1)==OCTAL_LITERAL ) {
                input.consume();
                if ( state.backtracking==0 ) adaptor.addChild(root_0, 
                (Object)adaptor.create(set447)
                );
                state.errorRecovery=false;
                state.failed=false;
            }
            else {
                if (state.backtracking>0) {state.failed=true; return retval;}
                MismatchedSetException mse = new MismatchedSetException(null,input);
                throw mse;
            }


            }

            retval.stop = input.LT(-1);


            if ( state.backtracking==0 ) {

            retval.tree = (Object)adaptor.rulePostProcessing(root_0);
            adaptor.setTokenBoundaries(retval.tree, retval.start, retval.stop);
            }
        }
        catch (RecognitionException re) {
            reportError(re);
            recover(input,re);
    	retval.tree = (Object)adaptor.errorNode(input, retval.start, input.LT(-1), re);

        }

        finally {
        	// do for sure before leaving
        }
        return retval;
    }
    // $ANTLR end "constant"

    // $ANTLR start synpred5_ObjectiveC
    public final void synpred5_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:30:2: ( function_definition )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:30:2: function_definition
        {
        pushFollow(FOLLOW_function_definition_in_synpred5_ObjectiveC66);
        function_definition();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred5_ObjectiveC

    // $ANTLR start synpred6_ObjectiveC
    public final void synpred6_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:31:3: ( declaration )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:31:3: declaration
        {
        pushFollow(FOLLOW_declaration_in_synpred6_ObjectiveC70);
        declaration();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred6_ObjectiveC

    // $ANTLR start synpred7_ObjectiveC
    public final void synpred7_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:32:3: ( class_interface )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:32:3: class_interface
        {
        pushFollow(FOLLOW_class_interface_in_synpred7_ObjectiveC75);
        class_interface();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred7_ObjectiveC

    // $ANTLR start synpred8_ObjectiveC
    public final void synpred8_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:33:3: ( class_implementation )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:33:3: class_implementation
        {
        pushFollow(FOLLOW_class_implementation_in_synpred8_ObjectiveC79);
        class_implementation();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred8_ObjectiveC

    // $ANTLR start synpred9_ObjectiveC
    public final void synpred9_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:34:3: ( category_interface )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:34:3: category_interface
        {
        pushFollow(FOLLOW_category_interface_in_synpred9_ObjectiveC83);
        category_interface();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred9_ObjectiveC

    // $ANTLR start synpred10_ObjectiveC
    public final void synpred10_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:35:3: ( category_implementation )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:35:3: category_implementation
        {
        pushFollow(FOLLOW_category_implementation_in_synpred10_ObjectiveC87);
        category_implementation();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred10_ObjectiveC

    // $ANTLR start synpred11_ObjectiveC
    public final void synpred11_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:36:3: ( protocol_declaration )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:36:3: protocol_declaration
        {
        pushFollow(FOLLOW_protocol_declaration_in_synpred11_ObjectiveC91);
        protocol_declaration();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred11_ObjectiveC

    // $ANTLR start synpred12_ObjectiveC
    public final void synpred12_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:37:3: ( protocol_declaration_list )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:37:3: protocol_declaration_list
        {
        pushFollow(FOLLOW_protocol_declaration_list_in_synpred12_ObjectiveC95);
        protocol_declaration_list();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred12_ObjectiveC

    // $ANTLR start synpred48_ObjectiveC
    public final void synpred48_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:3: ( function_definition )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:3: function_definition
        {
        pushFollow(FOLLOW_function_definition_in_synpred48_ObjectiveC619);
        function_definition();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred48_ObjectiveC

    // $ANTLR start synpred49_ObjectiveC
    public final void synpred49_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:25: ( declaration )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:151:25: declaration
        {
        pushFollow(FOLLOW_declaration_in_synpred49_ObjectiveC623);
        declaration();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred49_ObjectiveC

    // $ANTLR start synpred56_ObjectiveC
    public final void synpred56_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:34: ( parameter_list )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:165:34: parameter_list
        {
        pushFollow(FOLLOW_parameter_list_in_synpred56_ObjectiveC698);
        parameter_list();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred56_ObjectiveC

    // $ANTLR start synpred71_ObjectiveC
    public final void synpred71_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:4: ( ( class_name ( protocol_reference_list )? ) )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:4: ( class_name ( protocol_reference_list )? )
        {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:4: ( class_name ( protocol_reference_list )? )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:5: class_name ( protocol_reference_list )?
        {
        pushFollow(FOLLOW_class_name_in_synpred71_ObjectiveC799);
        class_name();

        state._fsp--;
        if (state.failed) return ;

        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:16: ( protocol_reference_list )?
        int alt114=2;
        int LA114_0 = input.LA(1);

        if ( (LA114_0==57) ) {
            alt114=1;
        }
        switch (alt114) {
            case 1 :
                // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:180:18: protocol_reference_list
                {
                pushFollow(FOLLOW_protocol_reference_list_in_synpred71_ObjectiveC803);
                protocol_reference_list();

                state._fsp--;
                if (state.failed) return ;

                }
                break;

        }


        }


        }

    }
    // $ANTLR end synpred71_ObjectiveC

    // $ANTLR start synpred89_ObjectiveC
    public final void synpred89_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:207:2: ( expression )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:207:2: expression
        {
        pushFollow(FOLLOW_expression_in_synpred89_ObjectiveC947);
        expression();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred89_ObjectiveC

    // $ANTLR start synpred90_ObjectiveC
    public final void synpred90_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:208:4: ( class_name )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:208:4: class_name
        {
        pushFollow(FOLLOW_class_name_in_synpred90_ObjectiveC952);
        class_name();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred90_ObjectiveC

    // $ANTLR start synpred100_ObjectiveC
    public final void synpred100_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:32: ( type_specifier )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:259:32: type_specifier
        {
        pushFollow(FOLLOW_type_specifier_in_synpred100_ObjectiveC1174);
        type_specifier();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred100_ObjectiveC

    // $ANTLR start synpred109_ObjectiveC
    public final void synpred109_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:5: ( IDENTIFIER )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:267:5: IDENTIFIER
        {
        match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_synpred109_ObjectiveC1255); if (state.failed) return ;

        }

    }
    // $ANTLR end synpred109_ObjectiveC

    // $ANTLR start synpred112_ObjectiveC
    public final void synpred112_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:29: ( type_specifier )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:271:29: type_specifier
        {
        pushFollow(FOLLOW_type_specifier_in_synpred112_ObjectiveC1291);
        type_specifier();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred112_ObjectiveC

    // $ANTLR start synpred115_ObjectiveC
    public final void synpred115_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:21: ( declarator )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:275:21: declarator
        {
        pushFollow(FOLLOW_declarator_in_synpred115_ObjectiveC1322);
        declarator();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred115_ObjectiveC

    // $ANTLR start synpred117_ObjectiveC
    public final void synpred117_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:278:17: ( '{' enumerator_list '}' )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:278:17: '{' enumerator_list '}'
        {
        match(input,130,FOLLOW_130_in_synpred117_ObjectiveC1349); if (state.failed) return ;

        pushFollow(FOLLOW_enumerator_list_in_synpred117_ObjectiveC1351);
        enumerator_list();

        state._fsp--;
        if (state.failed) return ;

        match(input,134,FOLLOW_134_in_synpred117_ObjectiveC1353); if (state.failed) return ;

        }

    }
    // $ANTLR end synpred117_ObjectiveC

    // $ANTLR start synpred123_ObjectiveC
    public final void synpred123_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:32: ( declarator_suffix )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:285:32: declarator_suffix
        {
        pushFollow(FOLLOW_declarator_suffix_in_synpred123_ObjectiveC1425);
        declarator_suffix();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred123_ObjectiveC

    // $ANTLR start synpred125_ObjectiveC
    public final void synpred125_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:286:40: ( declarator_suffix )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:286:40: declarator_suffix
        {
        pushFollow(FOLLOW_declarator_suffix_in_synpred125_ObjectiveC1454);
        declarator_suffix();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred125_ObjectiveC

    // $ANTLR start synpred130_ObjectiveC
    public final void synpred130_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: ( declarator )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: declarator
        {
        pushFollow(FOLLOW_declarator_in_synpred130_ObjectiveC1514);
        declarator();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred130_ObjectiveC

    // $ANTLR start synpred131_ObjectiveC
    public final void synpred131_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: ( ( declarator )? )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: ( declarator )?
        {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: ( declarator )?
        int alt120=2;
        int LA120_0 = input.LA(1);

        if ( (LA120_0==IDENTIFIER||LA120_0==38||LA120_0==40) ) {
            alt120=1;
        }
        switch (alt120) {
            case 1 :
                // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:294:29: declarator
                {
                pushFollow(FOLLOW_declarator_in_synpred131_ObjectiveC1514);
                declarator();

                state._fsp--;
                if (state.failed) return ;

                }
                break;

        }


        }

    }
    // $ANTLR end synpred131_ObjectiveC

    // $ANTLR start synpred135_ObjectiveC
    public final void synpred135_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:23: ( '*' ( type_qualifier )* abstract_declarator )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:23: '*' ( type_qualifier )* abstract_declarator
        {
        match(input,40,FOLLOW_40_in_synpred135_ObjectiveC1569); if (state.failed) return ;

        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:27: ( type_qualifier )*
        loop121:
        do {
            int alt121=2;
            int LA121_0 = input.LA(1);

            if ( ((LA121_0 >= 91 && LA121_0 <= 92)||LA121_0==95||(LA121_0 >= 108 && LA121_0 <= 109)||(LA121_0 >= 112 && LA121_0 <= 113)||LA121_0==128) ) {
                alt121=1;
            }


            switch (alt121) {
        	case 1 :
        	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:301:27: type_qualifier
        	    {
        	    pushFollow(FOLLOW_type_qualifier_in_synpred135_ObjectiveC1571);
        	    type_qualifier();

        	    state._fsp--;
        	    if (state.failed) return ;

        	    }
        	    break;

        	default :
        	    break loop121;
            }
        } while (true);


        pushFollow(FOLLOW_abstract_declarator_in_synpred135_ObjectiveC1574);
        abstract_declarator();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred135_ObjectiveC

    // $ANTLR start synpred136_ObjectiveC
    public final void synpred136_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:33: ( abstract_declarator_suffix )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:33: abstract_declarator_suffix
        {
        pushFollow(FOLLOW_abstract_declarator_suffix_in_synpred136_ObjectiveC1587);
        abstract_declarator_suffix();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred136_ObjectiveC

    // $ANTLR start synpred137_ObjectiveC
    public final void synpred137_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:5: ( '(' abstract_declarator ')' ( abstract_declarator_suffix )+ )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:5: '(' abstract_declarator ')' ( abstract_declarator_suffix )+
        {
        match(input,38,FOLLOW_38_in_synpred137_ObjectiveC1581); if (state.failed) return ;

        pushFollow(FOLLOW_abstract_declarator_in_synpred137_ObjectiveC1583);
        abstract_declarator();

        state._fsp--;
        if (state.failed) return ;

        match(input,39,FOLLOW_39_in_synpred137_ObjectiveC1585); if (state.failed) return ;

        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:33: ( abstract_declarator_suffix )+
        int cnt122=0;
        loop122:
        do {
            int alt122=2;
            int LA122_0 = input.LA(1);

            if ( (LA122_0==38||LA122_0==84) ) {
                alt122=1;
            }


            switch (alt122) {
        	case 1 :
        	    // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:302:33: abstract_declarator_suffix
        	    {
        	    pushFollow(FOLLOW_abstract_declarator_suffix_in_synpred137_ObjectiveC1587);
        	    abstract_declarator_suffix();

        	    state._fsp--;
        	    if (state.failed) return ;

        	    }
        	    break;

        	default :
        	    if ( cnt122 >= 1 ) break loop122;
        	    if (state.backtracking>0) {state.failed=true; return ;}
                    EarlyExitException eee =
                        new EarlyExitException(122, input);
                    throw eee;
            }
            cnt122++;
        } while (true);


        }

    }
    // $ANTLR end synpred137_ObjectiveC

    // $ANTLR start synpred154_ObjectiveC
    public final void synpred154_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:27: ( declaration )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:329:27: declaration
        {
        pushFollow(FOLLOW_declaration_in_synpred154_ObjectiveC1765);
        declaration();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred154_ObjectiveC

    // $ANTLR start synpred156_ObjectiveC
    public final void synpred156_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:332:40: ( 'else' statement )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:332:40: 'else' statement
        {
        match(input,100,FOLLOW_100_in_synpred156_ObjectiveC1794); if (state.failed) return ;

        pushFollow(FOLLOW_statement_in_synpred156_ObjectiveC1796);
        statement();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred156_ObjectiveC

    // $ANTLR start synpred198_ObjectiveC
    public final void synpred198_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:386:19: ( '(' type_name ')' cast_expression )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:386:19: '(' type_name ')' cast_expression
        {
        match(input,38,FOLLOW_38_in_synpred198_ObjectiveC2265); if (state.failed) return ;

        pushFollow(FOLLOW_type_name_in_synpred198_ObjectiveC2267);
        type_name();

        state._fsp--;
        if (state.failed) return ;

        match(input,39,FOLLOW_39_in_synpred198_ObjectiveC2269); if (state.failed) return ;

        pushFollow(FOLLOW_cast_expression_in_synpred198_ObjectiveC2271);
        cast_expression();

        state._fsp--;
        if (state.failed) return ;

        }

    }
    // $ANTLR end synpred198_ObjectiveC

    // $ANTLR start synpred203_ObjectiveC
    public final void synpred203_ObjectiveC_fragment() throws RecognitionException {
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:393:15: ( '(' type_name ')' )
        // /Users/Vincent/Projects/parsing/ObjectiveC/antlr-objc/src/smartmobili/lang/objc/ObjectiveC.g:393:15: '(' type_name ')'
        {
        match(input,38,FOLLOW_38_in_synpred203_ObjectiveC2320); if (state.failed) return ;

        pushFollow(FOLLOW_type_name_in_synpred203_ObjectiveC2322);
        type_name();

        state._fsp--;
        if (state.failed) return ;

        match(input,39,FOLLOW_39_in_synpred203_ObjectiveC2324); if (state.failed) return ;

        }

    }
    // $ANTLR end synpred203_ObjectiveC

    // Delegated rules

    public final boolean synpred90_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred90_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred136_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred136_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred89_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred89_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred48_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred48_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred8_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred8_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred6_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred6_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred100_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred100_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred115_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred115_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred7_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred7_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred11_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred11_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred10_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred10_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred56_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred56_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred112_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred112_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred9_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred9_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred203_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred203_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred154_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred154_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred71_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred71_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred130_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred130_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred198_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred198_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred137_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred137_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred131_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred131_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred5_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred5_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred109_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred109_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred135_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred135_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred117_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred117_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred123_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred123_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred156_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred156_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred49_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred49_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred12_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred12_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }
    public final boolean synpred125_ObjectiveC() {
        state.backtracking++;
        int start = input.mark();
        try {
            synpred125_ObjectiveC_fragment(); // can never throw exception
        } catch (RecognitionException re) {
            System.err.println("impossible: "+re);
        }
        boolean success = !state.failed;
        input.rewind(start);
        state.backtracking--;
        state.failed=false;
        return success;
    }


 

    public static final BitSet FOLLOW_external_declaration_in_translation_unit47 = new BitSet(new long[]{0x00000001FE012022L,0xF367F4E8DA004620L,0x0000000000000001L});
    public static final BitSet FOLLOW_COMMENT_in_external_declaration55 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_LINE_COMMENT_in_external_declaration59 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_preprocessor_declaration_in_external_declaration63 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_function_definition_in_external_declaration66 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declaration_in_external_declaration70 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_interface_in_external_declaration75 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_implementation_in_external_declaration79 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_category_interface_in_external_declaration83 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_category_implementation_in_external_declaration87 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_declaration_in_external_declaration91 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_declaration_list_in_external_declaration95 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_declaration_list_in_external_declaration99 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_30_in_preprocessor_declaration106 = new BitSet(new long[]{0x0200000001000000L});
    public static final BitSet FOLLOW_file_specification_in_preprocessor_declaration108 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_31_in_preprocessor_declaration112 = new BitSet(new long[]{0x0200000001000000L});
    public static final BitSet FOLLOW_file_specification_in_preprocessor_declaration114 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_25_in_preprocessor_declaration118 = new BitSet(new long[]{0x0008000000000000L});
    public static final BitSet FOLLOW_macro_specification_in_preprocessor_declaration120 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_28_in_preprocessor_declaration124 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_preprocessor_declaration126 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_27_in_preprocessor_declaration130 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_preprocessor_declaration132 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_32_in_preprocessor_declaration136 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_preprocessor_declaration138 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_29_in_preprocessor_declaration142 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_preprocessor_declaration144 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_26_in_preprocessor_declaration148 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_set_in_file_specification155 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_IDENTIFIER_in_file_specification161 = new BitSet(new long[]{0x8024000001002000L,0x0000000000200000L});
    public static final BitSet FOLLOW_set_in_file_specification178 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_51_in_macro_specification191 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_74_in_class_interface199 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_class_name_in_class_interface205 = new BitSet(new long[]{0x0280440000002000L,0xF367F4E8DA000080L,0x0000000000000005L});
    public static final BitSet FOLLOW_55_in_class_interface208 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_superclass_name_in_class_interface210 = new BitSet(new long[]{0x0200440000002000L,0xF367F4E8DA000080L,0x0000000000000005L});
    public static final BitSet FOLLOW_protocol_reference_list_in_class_interface217 = new BitSet(new long[]{0x0000440000002000L,0xF367F4E8DA000080L,0x0000000000000005L});
    public static final BitSet FOLLOW_instance_variables_in_class_interface225 = new BitSet(new long[]{0x0000440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_interface_declaration_list_in_class_interface233 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000080L});
    public static final BitSet FOLLOW_71_in_class_interface242 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_74_in_category_interface250 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_class_name_in_category_interface256 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_category_interface258 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_category_name_in_category_interface260 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_category_interface262 = new BitSet(new long[]{0x0200440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_protocol_reference_list_in_category_interface267 = new BitSet(new long[]{0x0000440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_interface_declaration_list_in_category_interface275 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000080L});
    public static final BitSet FOLLOW_71_in_category_interface284 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_73_in_class_implementation292 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_class_name_in_class_implementation298 = new BitSet(new long[]{0x0080440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_55_in_class_implementation302 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_superclass_name_in_class_implementation304 = new BitSet(new long[]{0x0000440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_implementation_definition_list_in_class_implementation312 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000080L});
    public static final BitSet FOLLOW_71_in_class_implementation321 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_73_in_category_implementation329 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_class_name_in_category_implementation333 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_category_implementation335 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_category_name_in_category_implementation337 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_category_implementation339 = new BitSet(new long[]{0x0000440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_implementation_definition_list_in_category_implementation344 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000080L});
    public static final BitSet FOLLOW_71_in_category_implementation351 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_78_in_protocol_declaration359 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_protocol_name_in_protocol_declaration363 = new BitSet(new long[]{0x0200440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_protocol_reference_list_in_protocol_declaration367 = new BitSet(new long[]{0x0000440000002000L,0xF367F4E8DA000080L,0x0000000000000001L});
    public static final BitSet FOLLOW_interface_declaration_list_in_protocol_declaration375 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000080L});
    public static final BitSet FOLLOW_71_in_protocol_declaration382 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_78_in_protocol_declaration_list391 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_protocol_list_in_protocol_declaration_list393 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_protocol_declaration_list394 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_69_in_class_declaration_list406 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_class_list_in_class_declaration_list408 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_class_declaration_list409 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_name_in_class_list420 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_class_list423 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_class_name_in_class_list425 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_57_in_protocol_reference_list436 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_protocol_list_in_protocol_reference_list438 = new BitSet(new long[]{0x8000000000000000L});
    public static final BitSet FOLLOW_63_in_protocol_reference_list440 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_name_in_protocol_list449 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_protocol_list452 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_protocol_name_in_protocol_list454 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_class_name464 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_superclass_name472 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_category_name480 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_protocol_name488 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_130_in_instance_variables496 = new BitSet(new long[]{0x0080014000002000L,0x000000000000B800L});
    public static final BitSet FOLLOW_instance_variable_declaration_in_instance_variables498 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_134_in_instance_variables500 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_visibility_specification_in_instance_variable_declaration510 = new BitSet(new long[]{0x0080014000002002L,0x000000000000B800L});
    public static final BitSet FOLLOW_struct_declarator_list_in_instance_variable_declaration514 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_instance_variables_in_instance_variable_declaration516 = new BitSet(new long[]{0x0080014000002002L,0x000000000000B800L});
    public static final BitSet FOLLOW_declaration_in_interface_declaration_list553 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_class_method_declaration_in_interface_declaration_list557 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_instance_method_declaration_in_interface_declaration_list561 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_42_in_class_method_declaration574 = new BitSet(new long[]{0x0080004000002000L});
    public static final BitSet FOLLOW_method_declaration_in_class_method_declaration576 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_46_in_instance_method_declaration588 = new BitSet(new long[]{0x0080004000002000L});
    public static final BitSet FOLLOW_method_declaration_in_instance_method_declaration590 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_method_type_in_method_declaration603 = new BitSet(new long[]{0x0080000000002000L});
    public static final BitSet FOLLOW_method_selector_in_method_declaration608 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_method_declaration610 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_function_definition_in_implementation_definition_list619 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_declaration_in_implementation_definition_list623 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_class_method_definition_in_implementation_definition_list627 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_instance_method_definition_in_implementation_definition_list631 = new BitSet(new long[]{0x0000440000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_42_in_class_method_definition642 = new BitSet(new long[]{0x0080004000002000L});
    public static final BitSet FOLLOW_method_definition_in_class_method_definition644 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_46_in_instance_method_definition656 = new BitSet(new long[]{0x0080004000002000L});
    public static final BitSet FOLLOW_method_definition_in_instance_method_definition658 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_method_type_in_method_definition671 = new BitSet(new long[]{0x0080000000002000L});
    public static final BitSet FOLLOW_method_selector_in_method_definition675 = new BitSet(new long[]{0x0000014000002000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_init_declarator_list_in_method_definition678 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_compound_statement_in_method_definition682 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selector_in_method_selector690 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_keyword_declarator_in_method_selector694 = new BitSet(new long[]{0x0080000000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_parameter_list_in_method_selector698 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selector_in_keyword_declarator712 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_keyword_declarator715 = new BitSet(new long[]{0x0000004000002000L});
    public static final BitSet FOLLOW_method_type_in_keyword_declarator717 = new BitSet(new long[]{0x0000004000002000L});
    public static final BitSet FOLLOW_IDENTIFIER_in_keyword_declarator720 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_selector727 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_method_type734 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_name_in_method_type736 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_method_type738 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_127_in_type_specifier745 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_94_in_type_specifier749 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_117_in_type_specifier753 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_110_in_type_specifier757 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_111_in_type_specifier761 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_103_in_type_specifier765 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_99_in_type_specifier769 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_118_in_type_specifier773 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_126_in_type_specifier777 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_106_in_type_specifier784 = new BitSet(new long[]{0x0200000000000002L});
    public static final BitSet FOLLOW_protocol_reference_list_in_type_specifier788 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_name_in_type_specifier799 = new BitSet(new long[]{0x0200000000000002L});
    public static final BitSet FOLLOW_protocol_reference_list_in_type_specifier803 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_struct_or_union_specifier_in_type_specifier812 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_enum_specifier_in_type_specifier817 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_type_specifier823 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_95_in_type_qualifier831 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_128_in_type_qualifier835 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_qualifier_in_type_qualifier839 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_primary_expression875 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_constant_in_primary_expression880 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_STRING_LITERAL_in_primary_expression885 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_primary_expression891 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_primary_expression893 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_primary_expression895 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_116_in_primary_expression901 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_message_expression_in_primary_expression906 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selector_expression_in_primary_expression911 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_expression_in_primary_expression916 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_encode_expression_in_primary_expression921 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_84_in_message_expression930 = new BitSet(new long[]{0x0000C950004A2A50L,0x0490000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_receiver_in_message_expression932 = new BitSet(new long[]{0x0080000000002000L});
    public static final BitSet FOLLOW_message_selector_in_message_expression934 = new BitSet(new long[]{0x0000000000000000L,0x0000000000400000L});
    public static final BitSet FOLLOW_86_in_message_expression936 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_expression_in_receiver947 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_name_in_receiver952 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_122_in_receiver958 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selector_in_message_selector966 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_keyword_argument_in_message_selector971 = new BitSet(new long[]{0x0080000000002002L});
    public static final BitSet FOLLOW_selector_in_keyword_argument980 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_keyword_argument983 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_keyword_argument985 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_80_in_selector_expression993 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_selector_expression995 = new BitSet(new long[]{0x0080000000002000L});
    public static final BitSet FOLLOW_selector_name_in_selector_expression997 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_selector_expression999 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selector_in_selector_name1007 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selector_in_selector_name1013 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_selector_name1016 = new BitSet(new long[]{0x0080000000002002L});
    public static final BitSet FOLLOW_78_in_protocol_expression1026 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_protocol_expression1028 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_protocol_name_in_protocol_expression1030 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_protocol_expression1032 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_70_in_encode_expression1040 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_encode_expression1042 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_name_in_encode_expression1044 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_encode_expression1046 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_in_exception_declarator1054 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_83_in_try_statement1062 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_68_in_catch_statement1070 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_catch_statement1072 = new BitSet(new long[]{0x0000014000002000L});
    public static final BitSet FOLLOW_exception_declarator_in_catch_statement1073 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_catch_statement1074 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_catch_statement1075 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_72_in_finally_statement1083 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_finally_statement1085 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_82_in_throw_statement1093 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_throw_statement1095 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_IDENTIFIER_in_throw_statement1096 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_throw_statement1097 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_try_statement_in_try_block1105 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000010L});
    public static final BitSet FOLLOW_catch_statement_in_try_block1108 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000100L});
    public static final BitSet FOLLOW_finally_statement_in_try_block1113 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_81_in_synchronized_statement1124 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_synchronized_statement1126 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_IDENTIFIER_in_synchronized_statement1128 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_synchronized_statement1130 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_synchronized_statement1132 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declaration_specifiers_in_function_definition1140 = new BitSet(new long[]{0x0000014000002000L});
    public static final BitSet FOLLOW_declarator_in_function_definition1142 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_compound_statement_in_function_definition1144 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declaration_specifiers_in_declaration1153 = new BitSet(new long[]{0x0100014000002000L});
    public static final BitSet FOLLOW_init_declarator_list_in_declaration1155 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_declaration1158 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_storage_class_specifier_in_declaration_specifiers1170 = new BitSet(new long[]{0x0000000000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_specifier_in_declaration_specifiers1174 = new BitSet(new long[]{0x0000000000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_qualifier_in_declaration_specifiers1178 = new BitSet(new long[]{0x0000000000002002L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_init_declarator_in_init_declarator_list1212 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_init_declarator_list1215 = new BitSet(new long[]{0x0000014000002000L});
    public static final BitSet FOLLOW_init_declarator_in_init_declarator_list1217 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_declarator_in_init_declarator1227 = new BitSet(new long[]{0x2000000000000002L});
    public static final BitSet FOLLOW_61_in_init_declarator1230 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000084L});
    public static final BitSet FOLLOW_initializer_in_init_declarator1232 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_set_in_struct_or_union_specifier1242 = new BitSet(new long[]{0x0000000000002000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_IDENTIFIER_in_struct_or_union_specifier1255 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_struct_or_union_specifier1259 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_130_in_struct_or_union_specifier1262 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_struct_declaration_in_struct_or_union_specifier1264 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000041L});
    public static final BitSet FOLLOW_134_in_struct_or_union_specifier1267 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_specifier_qualifier_list_in_struct_declaration1277 = new BitSet(new long[]{0x0080014000002000L});
    public static final BitSet FOLLOW_struct_declarator_list_in_struct_declaration1279 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_struct_declaration1281 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_type_specifier_in_specifier_qualifier_list1291 = new BitSet(new long[]{0x0000000000002002L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_qualifier_in_specifier_qualifier_list1295 = new BitSet(new long[]{0x0000000000002002L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_struct_declarator_in_struct_declarator_list1306 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_struct_declarator_list1309 = new BitSet(new long[]{0x0080014000002000L});
    public static final BitSet FOLLOW_struct_declarator_in_struct_declarator_list1311 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_declarator_in_struct_declarator1322 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_in_struct_declarator1326 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_struct_declarator1329 = new BitSet(new long[]{0x0000000000020A50L});
    public static final BitSet FOLLOW_constant_in_struct_declarator1331 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_101_in_enum_specifier1339 = new BitSet(new long[]{0x0000000000002000L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_identifier_in_enum_specifier1346 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000000L,0x0000000000000004L});
    public static final BitSet FOLLOW_130_in_enum_specifier1349 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_enumerator_list_in_enum_specifier1351 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_134_in_enum_specifier1353 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_130_in_enum_specifier1362 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_enumerator_list_in_enum_specifier1364 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_134_in_enum_specifier1366 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_enumerator_in_enumerator_list1375 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_enumerator_list1378 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_enumerator_in_enumerator_list1380 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_identifier_in_enumerator1390 = new BitSet(new long[]{0x2000000000000002L});
    public static final BitSet FOLLOW_61_in_enumerator1393 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_constant_expression_in_enumerator1395 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_40_in_declarator1405 = new BitSet(new long[]{0x0000014000002000L,0x0003300098000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_qualifier_in_declarator1407 = new BitSet(new long[]{0x0000014000002000L,0x0003300098000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_declarator_in_declarator1410 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_direct_declarator_in_declarator1414 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_identifier_in_direct_declarator1423 = new BitSet(new long[]{0x0000004000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_declarator_suffix_in_direct_declarator1425 = new BitSet(new long[]{0x0000004000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_38_in_direct_declarator1448 = new BitSet(new long[]{0x0000014000002000L});
    public static final BitSet FOLLOW_declarator_in_direct_declarator1450 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_direct_declarator1452 = new BitSet(new long[]{0x0000004000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_declarator_suffix_in_direct_declarator1454 = new BitSet(new long[]{0x0000004000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_84_in_declarator_suffix1464 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000514040L,0x0000000000000080L});
    public static final BitSet FOLLOW_constant_expression_in_declarator_suffix1466 = new BitSet(new long[]{0x0000000000000000L,0x0000000000400000L});
    public static final BitSet FOLLOW_86_in_declarator_suffix1469 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_declarator_suffix1477 = new BitSet(new long[]{0x0000008000002000L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_parameter_list_in_declarator_suffix1479 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_declarator_suffix1482 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_parameter_declaration_list_in_parameter_list1490 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_parameter_list1494 = new BitSet(new long[]{0x0010000000000000L});
    public static final BitSet FOLLOW_52_in_parameter_list1496 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declaration_specifiers_in_parameter_declaration1511 = new BitSet(new long[]{0x0000014000002002L,0x0000000000100000L});
    public static final BitSet FOLLOW_declarator_in_parameter_declaration1514 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_abstract_declarator_in_parameter_declaration1519 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_assignment_expression_in_initializer1529 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_130_in_initializer1538 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000084L});
    public static final BitSet FOLLOW_initializer_in_initializer1540 = new BitSet(new long[]{0x0000200000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_45_in_initializer1543 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000084L});
    public static final BitSet FOLLOW_initializer_in_initializer1545 = new BitSet(new long[]{0x0000200000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_134_in_initializer1549 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_specifier_qualifier_list_in_type_name1558 = new BitSet(new long[]{0x0000014000000000L,0x0000000000100000L});
    public static final BitSet FOLLOW_abstract_declarator_in_type_name1560 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_40_in_abstract_declarator1569 = new BitSet(new long[]{0x0000014000000000L,0x0003300098100000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_qualifier_in_abstract_declarator1571 = new BitSet(new long[]{0x0000014000000000L,0x0003300098100000L,0x0000000000000001L});
    public static final BitSet FOLLOW_abstract_declarator_in_abstract_declarator1574 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_abstract_declarator1581 = new BitSet(new long[]{0x000001C000000000L,0x0000000000100000L});
    public static final BitSet FOLLOW_abstract_declarator_in_abstract_declarator1583 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_abstract_declarator1585 = new BitSet(new long[]{0x0000004000000000L,0x0000000000100000L});
    public static final BitSet FOLLOW_abstract_declarator_suffix_in_abstract_declarator1587 = new BitSet(new long[]{0x0000004000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_84_in_abstract_declarator1595 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000514040L,0x0000000000000080L});
    public static final BitSet FOLLOW_constant_expression_in_abstract_declarator1597 = new BitSet(new long[]{0x0000000000000000L,0x0000000000400000L});
    public static final BitSet FOLLOW_86_in_abstract_declarator1600 = new BitSet(new long[]{0x0000000000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_84_in_abstract_declarator_suffix1617 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000514040L,0x0000000000000080L});
    public static final BitSet FOLLOW_constant_expression_in_abstract_declarator_suffix1619 = new BitSet(new long[]{0x0000000000000000L,0x0000000000400000L});
    public static final BitSet FOLLOW_86_in_abstract_declarator_suffix1622 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_abstract_declarator_suffix1628 = new BitSet(new long[]{0x0000008000002000L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_parameter_declaration_list_in_abstract_declarator_suffix1631 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_abstract_declarator_suffix1634 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_parameter_declaration_in_parameter_declaration_list1645 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_parameter_declaration_list1649 = new BitSet(new long[]{0x0000000000002000L,0xF367F4E8DA000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_parameter_declaration_in_parameter_declaration_list1651 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_statement_in_statement_list1664 = new BitSet(new long[]{0x0100C950004A2A52L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_labeled_statement_in_statement1678 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_expression_in_statement1684 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_statement1686 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_compound_statement_in_statement1692 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_selection_statement_in_statement1698 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_iteration_statement_in_statement1704 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_jump_statement_in_statement1710 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_56_in_statement1716 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_identifier_in_labeled_statement1727 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_labeled_statement1729 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_labeled_statement1731 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_93_in_labeled_statement1737 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_constant_expression_in_labeled_statement1739 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_labeled_statement1741 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_labeled_statement1743 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_97_in_labeled_statement1749 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_labeled_statement1751 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_labeled_statement1753 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_130_in_compound_statement1762 = new BitSet(new long[]{0x0100C950004A2A50L,0xFBFFFFEFFE114040L,0x00000000000000C7L});
    public static final BitSet FOLLOW_declaration_in_compound_statement1765 = new BitSet(new long[]{0x0100C950004A2A50L,0xFBFFFFEFFE114040L,0x00000000000000C7L});
    public static final BitSet FOLLOW_statement_list_in_compound_statement1769 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_134_in_compound_statement1772 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_107_in_selection_statement1783 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_selection_statement1785 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_selection_statement1787 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_selection_statement1789 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_selection_statement1791 = new BitSet(new long[]{0x0000000000000002L,0x0000001000000000L});
    public static final BitSet FOLLOW_100_in_selection_statement1794 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_selection_statement1796 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_123_in_selection_statement1804 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_selection_statement1806 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_selection_statement1808 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_selection_statement1810 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_selection_statement1812 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_129_in_iteration_statement1823 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_iteration_statement1825 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_iteration_statement1827 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_iteration_statement1829 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_iteration_statement1831 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_98_in_iteration_statement1837 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_iteration_statement1839 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000002L});
    public static final BitSet FOLLOW_129_in_iteration_statement1841 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_iteration_statement1843 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_iteration_statement1845 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_iteration_statement1847 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_iteration_statement1849 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_104_in_iteration_statement1855 = new BitSet(new long[]{0x0000004000000000L});
    public static final BitSet FOLLOW_38_in_iteration_statement1857 = new BitSet(new long[]{0x0100C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_iteration_statement1859 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_iteration_statement1862 = new BitSet(new long[]{0x0100C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_iteration_statement1864 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_iteration_statement1867 = new BitSet(new long[]{0x0000C9D0004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_iteration_statement1869 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_iteration_statement1872 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_iteration_statement1874 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_105_in_jump_statement1885 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_identifier_in_jump_statement1887 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_jump_statement1889 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_96_in_jump_statement1895 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_jump_statement1897 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_90_in_jump_statement1903 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_jump_statement1905 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_115_in_jump_statement1911 = new BitSet(new long[]{0x0100C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_jump_statement1913 = new BitSet(new long[]{0x0100000000000000L});
    public static final BitSet FOLLOW_56_in_jump_statement1916 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_assignment_expression_in_expression1928 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_expression1931 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_assignment_expression_in_expression1933 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_conditional_expression_in_assignment_expression1944 = new BitSet(new long[]{0x2841122400000002L,0x0000000001000004L,0x0000000000000010L});
    public static final BitSet FOLLOW_assignment_operator_in_assignment_expression1951 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_assignment_expression_in_assignment_expression1953 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_logical_or_expression_in_conditional_expression2013 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000008L});
    public static final BitSet FOLLOW_67_in_conditional_expression2019 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_logical_or_expression_in_conditional_expression2021 = new BitSet(new long[]{0x0080000000000000L});
    public static final BitSet FOLLOW_55_in_conditional_expression2023 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_logical_or_expression_in_conditional_expression2025 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_conditional_expression_in_constant_expression2036 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_logical_and_expression_in_logical_or_expression2045 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000000L,0x0000000000000020L});
    public static final BitSet FOLLOW_133_in_logical_or_expression2051 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_logical_and_expression_in_logical_or_expression2053 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000000L,0x0000000000000020L});
    public static final BitSet FOLLOW_inclusive_or_expression_in_logical_and_expression2064 = new BitSet(new long[]{0x0000000800000002L});
    public static final BitSet FOLLOW_35_in_logical_and_expression2070 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_inclusive_or_expression_in_logical_and_expression2072 = new BitSet(new long[]{0x0000000800000002L});
    public static final BitSet FOLLOW_exclusive_or_expression_in_inclusive_or_expression2083 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000000L,0x0000000000000008L});
    public static final BitSet FOLLOW_131_in_inclusive_or_expression2089 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_exclusive_or_expression_in_inclusive_or_expression2091 = new BitSet(new long[]{0x0000000000000002L,0x0000000000000000L,0x0000000000000008L});
    public static final BitSet FOLLOW_and_expression_in_exclusive_or_expression2102 = new BitSet(new long[]{0x0000000000000002L,0x0000000000800000L});
    public static final BitSet FOLLOW_87_in_exclusive_or_expression2105 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_and_expression_in_exclusive_or_expression2107 = new BitSet(new long[]{0x0000000000000002L,0x0000000000800000L});
    public static final BitSet FOLLOW_equality_expression_in_and_expression2118 = new BitSet(new long[]{0x0000001000000002L});
    public static final BitSet FOLLOW_36_in_and_expression2121 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_equality_expression_in_and_expression2123 = new BitSet(new long[]{0x0000001000000002L});
    public static final BitSet FOLLOW_relational_expression_in_equality_expression2134 = new BitSet(new long[]{0x4000000000800002L});
    public static final BitSet FOLLOW_set_in_equality_expression2140 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_relational_expression_in_equality_expression2148 = new BitSet(new long[]{0x4000000000800002L});
    public static final BitSet FOLLOW_shift_expression_in_relational_expression2159 = new BitSet(new long[]{0x9200000000000002L,0x0000000000000001L});
    public static final BitSet FOLLOW_set_in_relational_expression2163 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_shift_expression_in_relational_expression2179 = new BitSet(new long[]{0x9200000000000002L,0x0000000000000001L});
    public static final BitSet FOLLOW_additive_expression_in_shift_expression2190 = new BitSet(new long[]{0x0400000000000002L,0x0000000000000002L});
    public static final BitSet FOLLOW_set_in_shift_expression2193 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_additive_expression_in_shift_expression2201 = new BitSet(new long[]{0x0400000000000002L,0x0000000000000002L});
    public static final BitSet FOLLOW_multiplicative_expression_in_additive_expression2212 = new BitSet(new long[]{0x0000440000000002L});
    public static final BitSet FOLLOW_set_in_additive_expression2217 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_multiplicative_expression_in_additive_expression2225 = new BitSet(new long[]{0x0000440000000002L});
    public static final BitSet FOLLOW_cast_expression_in_multiplicative_expression2236 = new BitSet(new long[]{0x0020010200000002L});
    public static final BitSet FOLLOW_set_in_multiplicative_expression2242 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_cast_expression_in_multiplicative_expression2254 = new BitSet(new long[]{0x0020010200000002L});
    public static final BitSet FOLLOW_38_in_cast_expression2265 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_name_in_cast_expression2267 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_cast_expression2269 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_cast_expression_in_cast_expression2271 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_unary_expression_in_cast_expression2275 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_postfix_expression_in_unary_expression2287 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_43_in_unary_expression2293 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_unary_expression_in_unary_expression2295 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_47_in_unary_expression2301 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_unary_expression_in_unary_expression2303 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_unary_operator_in_unary_expression2309 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_cast_expression_in_unary_expression2311 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_119_in_unary_expression2317 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_38_in_unary_expression2320 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_name_in_unary_expression2322 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_unary_expression2324 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_unary_expression_in_unary_expression2328 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_primary_expression_in_postfix_expression2363 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_84_in_postfix_expression2368 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_expression_in_postfix_expression2370 = new BitSet(new long[]{0x0000000000000000L,0x0000000000400000L});
    public static final BitSet FOLLOW_86_in_postfix_expression2372 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_38_in_postfix_expression2379 = new BitSet(new long[]{0x0000C9D0004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_argument_expression_list_in_postfix_expression2381 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_postfix_expression2384 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_50_in_postfix_expression2390 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_identifier_in_postfix_expression2392 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_49_in_postfix_expression2398 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_identifier_in_postfix_expression2400 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_43_in_postfix_expression2406 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_47_in_postfix_expression2412 = new BitSet(new long[]{0x0006884000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_assignment_expression_in_argument_expression_list2428 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_45_in_argument_expression_list2431 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_assignment_expression_in_argument_expression_list2433 = new BitSet(new long[]{0x0000200000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_identifier2444 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_function_definition_in_synpred5_ObjectiveC66 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declaration_in_synpred6_ObjectiveC70 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_interface_in_synpred7_ObjectiveC75 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_implementation_in_synpred8_ObjectiveC79 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_category_interface_in_synpred9_ObjectiveC83 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_category_implementation_in_synpred10_ObjectiveC87 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_declaration_in_synpred11_ObjectiveC91 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_protocol_declaration_list_in_synpred12_ObjectiveC95 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_function_definition_in_synpred48_ObjectiveC619 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declaration_in_synpred49_ObjectiveC623 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_parameter_list_in_synpred56_ObjectiveC698 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_name_in_synpred71_ObjectiveC799 = new BitSet(new long[]{0x0200000000000002L});
    public static final BitSet FOLLOW_protocol_reference_list_in_synpred71_ObjectiveC803 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_expression_in_synpred89_ObjectiveC947 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_class_name_in_synpred90_ObjectiveC952 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_type_specifier_in_synpred100_ObjectiveC1174 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_IDENTIFIER_in_synpred109_ObjectiveC1255 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_type_specifier_in_synpred112_ObjectiveC1291 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_in_synpred115_ObjectiveC1322 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_130_in_synpred117_ObjectiveC1349 = new BitSet(new long[]{0x0000000000002000L});
    public static final BitSet FOLLOW_enumerator_list_in_synpred117_ObjectiveC1351 = new BitSet(new long[]{0x0000000000000000L,0x0000000000000000L,0x0000000000000040L});
    public static final BitSet FOLLOW_134_in_synpred117_ObjectiveC1353 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_suffix_in_synpred123_ObjectiveC1425 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_suffix_in_synpred125_ObjectiveC1454 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_in_synpred130_ObjectiveC1514 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_declarator_in_synpred131_ObjectiveC1514 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_40_in_synpred135_ObjectiveC1569 = new BitSet(new long[]{0x0000014000000000L,0x0003300098100000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_qualifier_in_synpred135_ObjectiveC1571 = new BitSet(new long[]{0x0000014000000000L,0x0003300098100000L,0x0000000000000001L});
    public static final BitSet FOLLOW_abstract_declarator_in_synpred135_ObjectiveC1574 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_abstract_declarator_suffix_in_synpred136_ObjectiveC1587 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_synpred137_ObjectiveC1581 = new BitSet(new long[]{0x000001C000000000L,0x0000000000100000L});
    public static final BitSet FOLLOW_abstract_declarator_in_synpred137_ObjectiveC1583 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_synpred137_ObjectiveC1585 = new BitSet(new long[]{0x0000004000000000L,0x0000000000100000L});
    public static final BitSet FOLLOW_abstract_declarator_suffix_in_synpred137_ObjectiveC1587 = new BitSet(new long[]{0x0000004000000002L,0x0000000000100000L});
    public static final BitSet FOLLOW_declaration_in_synpred154_ObjectiveC1765 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_100_in_synpred156_ObjectiveC1794 = new BitSet(new long[]{0x0100C950004A2A50L,0x08980B0724114040L,0x0000000000000086L});
    public static final BitSet FOLLOW_statement_in_synpred156_ObjectiveC1796 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_synpred198_ObjectiveC2265 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_name_in_synpred198_ObjectiveC2267 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_synpred198_ObjectiveC2269 = new BitSet(new long[]{0x0000C950004A2A50L,0x0090000000114040L,0x0000000000000080L});
    public static final BitSet FOLLOW_cast_expression_in_synpred198_ObjectiveC2271 = new BitSet(new long[]{0x0000000000000002L});
    public static final BitSet FOLLOW_38_in_synpred203_ObjectiveC2320 = new BitSet(new long[]{0x0000000000002000L,0xE263F4A8D8000000L,0x0000000000000001L});
    public static final BitSet FOLLOW_type_name_in_synpred203_ObjectiveC2322 = new BitSet(new long[]{0x0000008000000000L});
    public static final BitSet FOLLOW_39_in_synpred203_ObjectiveC2324 = new BitSet(new long[]{0x0000000000000002L});

}