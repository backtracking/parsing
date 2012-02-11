package smartmobili.lang.objc;

import org.antlr.runtime.ANTLRStringStream;
import org.antlr.runtime.CharStream;
import org.antlr.runtime.CommonTokenStream;
import org.antlr.runtime.RecognitionException;
import org.antlr.runtime.TokenStream;


public class Test {

	
	public static void main(String[] args) throws RecognitionException {

		CharStream charStream = new ANTLRStringStream(
		"#import <Cocoa/Cocoa.h>\n" + 
		"\n" + 
		"\n" + 
		"@interface SimpleCar : NSObject {\n" + 
		"\n" + 
		"	NSString* make;\n" + 
		"	NSString* model;\n" + 
		"	NSNumber* vin;\n" + 
		"	\n" + 
		"}\n" + 
		"\n" + 
		"// set methods\n" + 
		"- (void) setVin:   (NSNumber*)newVin;\n" + 
		"- (void) setMake:  (NSString*)newMake;\n" + 
		"- (void) setModel: (NSString*)newModel;\n" + 
		"\n" + 
		"// convenience method\n" + 
		"- (void) setMake: (NSString*)newMake \n" + 
		"        andModel: (NSString*)newModel;\n" + 
		"\n" + 
		"// get methods\n" + 
		"- (NSString*) make;\n" + 
		"- (NSString*) model;\n" + 
		"- (NSNumber*) vin;\n" + 
		"\n" + 
		"@end");
		
		ObjectiveCLexer lexer = new ObjectiveCLexer(charStream);
		TokenStream tokenStream = new CommonTokenStream(lexer);
		ObjectiveCParser parser = new ObjectiveCParser(tokenStream);
		parser.translation_unit();
		System.out.println("Done!");
	}

}
