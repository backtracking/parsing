//
//  SimpleCar.h
//  CarClassTest
//
//

#import <Cocoa/Cocoa.h>


@interface SimpleCar : NSObject {

	NSString* make;
	NSString* model;
	NSNumber* vin;
	
}

// set methods
- (void) setVin:   (NSNumber*)newVin;
- (void) setMake:  (NSString*)newMake;
- (void) setModel: (NSString*)newModel;

// convenience method
- (void) setMake: (NSString*)newMake 
        andModel: (NSString*)newModel;

// get methods
- (NSString*) make;
- (NSString*) model;
- (NSNumber*) vin;

@end


