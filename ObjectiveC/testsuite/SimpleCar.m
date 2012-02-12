//
//  SimpleCar.m
//  CarClassTest
//
//

#import "SimpleCar.h"


@implementation SimpleCar

// set methods
- (void) setVin: (NSNumber*)newVin{
	
	[vin release];
	vin = [[NSNumber alloc] init];
    vin = newVin;
	
}

- (void) setMake: (NSString*)newMake{
	
	[make release];
	make = [[NSString alloc] initWithString:newMake];
	
}

- (void) setModel: (NSString*)newModel{

	[model release];
	model = [[NSString alloc] initWithString:newModel];

}

// convenience method
- (void) setMake: (NSString*)newMake 
		andModel: (NSString*)newModel{
	
	// Reuse our code from earlier
	[self setMake:newMake];
	[self setModel:newModel];
	
}

// get methods
- (NSString*) make{
	return make;
}

- (NSString*) model{
    return model;
}

- (NSNumber*) vin{
    return vin;	
}

@end
